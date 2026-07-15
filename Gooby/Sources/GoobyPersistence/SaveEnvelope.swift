import Foundation
import GoobyCore

public struct SaveEnvelope: Codable, Equatable, Sendable {
    public static let currentSchemaVersion = 2

    public let schemaVersion: Int
    public let savedAt: GameInstant
    public let state: GameState

    public init(
        schemaVersion: Int = SaveEnvelope.currentSchemaVersion,
        savedAt: GameInstant,
        state: GameState
    ) {
        self.schemaVersion = schemaVersion
        self.savedAt = savedAt
        self.state = state
    }
}

public enum SaveMigrationError: Error, Equatable, Sendable {
    case malformedEnvelope
    case unsupportedPastSchema(Int)
    case unsupportedFutureSchema(Int)
}

public protocol SaveMigrating: Sendable {
    func decodeAndMigrate(_ data: Data) throws -> SaveEnvelope
    func schemaVersion(in data: Data) throws -> Int
}

public struct SaveMigrator: SaveMigrating {
    public init() {}

    public func schemaVersion(in data: Data) throws -> Int {
        struct Header: Decodable {
            let schemaVersion: Int
        }

        do {
            return try JSONDecoder().decode(Header.self, from: data).schemaVersion
        } catch {
            throw SaveMigrationError.malformedEnvelope
        }
    }

    public func decodeAndMigrate(_ data: Data) throws -> SaveEnvelope {
        let version = try schemaVersion(in: data)
        guard version <= SaveEnvelope.currentSchemaVersion else {
            throw SaveMigrationError.unsupportedFutureSchema(version)
        }
        guard version >= 1 else {
            throw SaveMigrationError.unsupportedPastSchema(version)
        }

        do {
            let decoded = try JSONDecoder().decode(SaveEnvelope.self, from: data)
            if decoded.schemaVersion == SaveEnvelope.currentSchemaVersion {
                return decoded
            }
            return SaveEnvelope(savedAt: decoded.savedAt, state: decoded.state)
        } catch {
            throw SaveMigrationError.malformedEnvelope
        }
    }
}
