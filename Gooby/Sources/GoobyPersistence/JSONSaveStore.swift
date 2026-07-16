import Foundation
import GoobyCore

public protocol GameStateRepository: Sendable {
    func load(now: GameInstant) async throws -> GameState
    func save(_ state: GameState, at now: GameInstant) async throws
    func reset(now: GameInstant) async throws -> GameState
}

public actor JSONSaveStore: GameStateRepository {
    public nonisolated let primaryURL: URL
    public nonisolated let backupURL: URL

    private let directoryURL: URL
    private let migrator: any SaveMigrating
    private let fileManager: FileManager

    public init(
        directoryURL: URL,
        fileName: String = "gooby-save.json",
        migrator: any SaveMigrating = SaveMigrator()
    ) {
        self.directoryURL = directoryURL
        primaryURL = directoryURL.appendingPathComponent(fileName)
        backupURL = directoryURL.appendingPathComponent("\(fileName).backup")
        self.migrator = migrator
        fileManager = FileManager()
    }

    public func load(now: GameInstant) async throws -> GameState {
        if let state = try loadCandidate(at: primaryURL) {
            return state
        }
        if let state = try loadCandidate(at: backupURL) {
            return state
        }
        return GameState.new(now: now)
    }

    public func save(_ state: GameState, at now: GameInstant) async throws {
        try fileManager.createDirectory(
            at: directoryURL,
            withIntermediateDirectories: true
        )
        try rejectFutureSchemaIfPresent(at: primaryURL)
        try rejectFutureSchemaIfPresent(at: backupURL)

        let newData = try Self.encode(SaveEnvelope(savedAt: now, state: state))
        if let primaryData = try? Data(contentsOf: primaryURL),
           (try? migrator.decodeAndMigrate(primaryData)) != nil {
            try primaryData.write(to: backupURL, options: .atomic)
        } else if !isValidSave(at: backupURL) {
            try newData.write(to: backupURL, options: .atomic)
        }
        try newData.write(to: primaryURL, options: .atomic)
    }

    public func reset(now: GameInstant) async throws -> GameState {
        if fileManager.fileExists(atPath: primaryURL.path) {
            try fileManager.removeItem(at: primaryURL)
        }
        if fileManager.fileExists(atPath: backupURL.path) {
            try fileManager.removeItem(at: backupURL)
        }
        let state = GameState.new(now: now)
        try await save(state, at: now)
        return state
    }

    private func loadCandidate(at url: URL) throws -> GameState? {
        guard fileManager.fileExists(atPath: url.path) else {
            return nil
        }

        do {
            let data = try Data(contentsOf: url)
            return try migrator.decodeAndMigrate(data).state
        } catch let error as SaveMigrationError {
            if case .unsupportedFutureSchema = error {
                throw error
            }
            return nil
        } catch {
            return nil
        }
    }

    private func rejectFutureSchemaIfPresent(at url: URL) throws {
        guard let data = try? Data(contentsOf: url),
              let version = try? migrator.schemaVersion(in: data)
        else {
            return
        }
        guard version <= SaveEnvelope.currentSchemaVersion else {
            throw SaveMigrationError.unsupportedFutureSchema(version)
        }
    }

    private func isValidSave(at url: URL) -> Bool {
        guard let data = try? Data(contentsOf: url) else { return false }
        return (try? migrator.decodeAndMigrate(data)) != nil
    }

    private static func encode(_ envelope: SaveEnvelope) throws -> Data {
        let encoder = JSONEncoder()
        encoder.outputFormatting = [.sortedKeys]
        return try encoder.encode(envelope)
    }
}
