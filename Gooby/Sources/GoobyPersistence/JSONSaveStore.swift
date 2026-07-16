import Foundation
import GoobyCore

public protocol GameStateRepository: Sendable {
    func load(now: GameInstant) async throws -> GameStateLoadResult
    func save(_ state: GameState, at now: GameInstant) async throws
    func reset(now: GameInstant, discardingDamagedSave: Bool) async throws -> GameState
}

public extension GameStateRepository {
    func reset(now: GameInstant) async throws -> GameState {
        try await reset(now: now, discardingDamagedSave: false)
    }
}

public enum GameStateLoadSource: Equatable, Sendable {
    case missing
    case primary
    case recoveredBackup
}

public struct GameStateLoadResult: Equatable, Sendable {
    public let state: GameState
    public let source: GameStateLoadSource

    public init(state: GameState, source: GameStateLoadSource) {
        self.state = state
        self.source = source
    }
}

public enum SaveFileCondition: Equatable, Sendable {
    case missing
    case valid
    case corrupt
    case unreadable
    case futureSchema(Int)
    case invalid([String])
}

public struct SaveRecoveryRequired: Error, Equatable, Sendable {
    public let primary: SaveFileCondition
    public let backup: SaveFileCondition

    public init(primary: SaveFileCondition, backup: SaveFileCondition) {
        self.primary = primary
        self.backup = backup
    }
}

public enum SaveWritePoint: Equatable, Sendable {
    case saveBackup
    case savePrimary
    case resetBackup
    case resetPrimary
}

public actor JSONSaveStore: GameStateRepository {
    public nonisolated let primaryURL: URL
    public nonisolated let backupURL: URL

    private let directoryURL: URL
    private let migrator: any SaveMigrating
    private let fileManager: FileManager
    private let beforeWrite: (@Sendable (SaveWritePoint) throws -> Void)?

    public init(
        directoryURL: URL,
        fileName: String = "gooby-save.json",
        migrator: any SaveMigrating = SaveMigrator(),
        beforeWrite: (@Sendable (SaveWritePoint) throws -> Void)? = nil
    ) {
        self.directoryURL = directoryURL
        primaryURL = directoryURL.appendingPathComponent(fileName)
        backupURL = directoryURL.appendingPathComponent("\(fileName).backup")
        self.migrator = migrator
        self.beforeWrite = beforeWrite
        fileManager = FileManager()
    }

    public func load(now: GameInstant) async throws -> GameStateLoadResult {
        let primary = inspect(at: primaryURL)
        if case let .valid(state, _) = primary {
            return GameStateLoadResult(state: state, source: .primary)
        }
        let backup = inspect(at: backupURL)
        if case let .valid(state, _) = backup {
            return GameStateLoadResult(state: state, source: .recoveredBackup)
        }
        if primary.condition == .missing, backup.condition == .missing {
            return GameStateLoadResult(state: GameState.new(now: now), source: .missing)
        }
        throw SaveRecoveryRequired(
            primary: primary.condition,
            backup: backup.condition
        )
    }

    public func save(_ state: GameState, at now: GameInstant) async throws {
        try GameStateValidator.validate(state, savedAt: now)
        try fileManager.createDirectory(
            at: directoryURL,
            withIntermediateDirectories: true
        )

        let newData = try Self.encode(SaveEnvelope(savedAt: now, state: state))
        let primary = inspect(at: primaryURL)
        let backup = inspect(at: backupURL)
        if primary.condition.isFutureSchema || backup.condition.isFutureSchema {
            throw SaveRecoveryRequired(
                primary: primary.condition,
                backup: backup.condition
            )
        }
        guard primary.isValid || backup.isValid
            || (primary.condition == .missing && backup.condition == .missing)
        else {
            throw SaveRecoveryRequired(
                primary: primary.condition,
                backup: backup.condition
            )
        }

        if case let .valid(_, primaryData) = primary {
            try beforeWrite?(.saveBackup)
            try primaryData.write(to: backupURL, options: .atomic)
        } else if backup.condition == .missing {
            try beforeWrite?(.saveBackup)
            try newData.write(to: backupURL, options: .atomic)
        }
        try beforeWrite?(.savePrimary)
        try newData.write(to: primaryURL, options: .atomic)
    }

    public func reset(
        now: GameInstant,
        discardingDamagedSave: Bool
    ) async throws -> GameState {
        try fileManager.createDirectory(
            at: directoryURL,
            withIntermediateDirectories: true
        )
        let primary = inspect(at: primaryURL)
        let backup = inspect(at: backupURL)
        if !discardingDamagedSave,
           primary.condition.isFutureSchema || backup.condition.isFutureSchema {
            throw SaveRecoveryRequired(
                primary: primary.condition,
                backup: backup.condition
            )
        }
        if !discardingDamagedSave,
           !primary.isValid,
           !backup.isValid,
           !(primary.condition == .missing && backup.condition == .missing) {
            throw SaveRecoveryRequired(
                primary: primary.condition,
                backup: backup.condition
            )
        }

        let state = GameState.new(now: now)
        let data = try Self.encode(SaveEnvelope(savedAt: now, state: state))
        let oldBackup = backup.data
        do {
            try beforeWrite?(.resetBackup)
            try data.write(to: backupURL, options: .atomic)
            try beforeWrite?(.resetPrimary)
            try data.write(to: primaryURL, options: .atomic)
        } catch {
            if let oldBackup {
                try? oldBackup.write(to: backupURL, options: .atomic)
            } else {
                try? fileManager.removeItem(at: backupURL)
            }
            throw error
        }
        return state
    }

    private func inspect(at url: URL) -> InspectedSave {
        guard fileManager.fileExists(atPath: url.path) else {
            return .unusable(.missing, nil)
        }

        let data: Data
        do {
            data = try Data(contentsOf: url)
        } catch {
            return .unusable(.unreadable, nil)
        }
        do {
            return .valid(try migrator.decodeAndMigrate(data).state, data)
        } catch let error as SaveMigrationError {
            switch error {
            case let .unsupportedFutureSchema(version):
                return .unusable(.futureSchema(version), data)
            case let .invalidState(issues):
                return .unusable(.invalid(issues), data)
            case .malformedEnvelope, .unsupportedPastSchema:
                return .unusable(.corrupt, data)
            }
        } catch {
            return .unusable(.corrupt, data)
        }
    }

    private static func encode(_ envelope: SaveEnvelope) throws -> Data {
        let encoder = JSONEncoder()
        encoder.outputFormatting = [.sortedKeys]
        return try encoder.encode(envelope)
    }

    private enum InspectedSave {
        case valid(GameState, Data)
        case unusable(SaveFileCondition, Data?)

        var condition: SaveFileCondition {
            switch self {
            case .valid:
                .valid
            case let .unusable(condition, _):
                condition
            }
        }

        var isValid: Bool {
            if case .valid = self { return true }
            return false
        }

        var data: Data? {
            switch self {
            case let .valid(_, data):
                data
            case let .unusable(_, data):
                data
            }
        }
    }
}

private extension SaveFileCondition {
    var isFutureSchema: Bool {
        if case .futureSchema = self { return true }
        return false
    }
}
