import Foundation
import GoobyCore
import GoobyPersistence
import XCTest

final class JSONSaveStoreTests: XCTestCase, @unchecked Sendable {
    private let now = GameInstant(secondsSinceEpoch: 1_728_000_000)

    func testSaveEnvelopeCodableRoundTrip() throws {
        var state = GameState.new(now: now)
        state.carrots = 77
        state.ownedItems = [GoobyCatalog.cozyBow]
        let envelope = SaveEnvelope(savedAt: now.adding(seconds: 5), state: state)

        let data = try JSONEncoder().encode(envelope)
        let decoded = try SaveMigrator().decodeAndMigrate(data)

        XCTAssertEqual(decoded, envelope)
        XCTAssertEqual(decoded.schemaVersion, SaveEnvelope.currentSchemaVersion)
    }

    func testCheckedInVersionOneFixtureDecodes() throws {
        let fixtureURL = try XCTUnwrap(
            Bundle.module.url(
                forResource: "save-v1",
                withExtension: "json",
                subdirectory: "Fixtures"
            )
        )
        let fixtureData = try Data(contentsOf: fixtureURL)
        let envelope = try SaveMigrator().decodeAndMigrate(fixtureData)

        XCTAssertEqual(envelope.schemaVersion, SaveEnvelope.currentSchemaVersion)
        XCTAssertEqual(envelope.savedAt, GameInstant(secondsSinceEpoch: 1_000))
        XCTAssertEqual(envelope.state, GameState.new(now: GameInstant(secondsSinceEpoch: 1_000)))
    }

    func testMigrationBoundaryRejectsPastAndFutureSchemas() {
        let migrator = SaveMigrator()

        XCTAssertThrowsError(
            try migrator.decodeAndMigrate(Data(#"{"schemaVersion":0}"#.utf8))
        ) { error in
            XCTAssertEqual(error as? SaveMigrationError, .unsupportedPastSchema(0))
        }
        XCTAssertThrowsError(
            try migrator.decodeAndMigrate(Data(#"{"schemaVersion":3}"#.utf8))
        ) { error in
            XCTAssertEqual(error as? SaveMigrationError, .unsupportedFutureSchema(3))
        }
    }

    func testMissingSaveLoadsDefaultsWithoutWritingFiles() async throws {
        let directory = try makeTemporaryDirectory()
        defer { try? FileManager.default.removeItem(at: directory) }
        let store = JSONSaveStore(directoryURL: directory)

        let loaded = try await store.load(now: now)

        XCTAssertEqual(loaded, GameState.new(now: now))
        XCTAssertFalse(FileManager.default.fileExists(atPath: store.primaryURL.path))
        XCTAssertFalse(FileManager.default.fileExists(atPath: store.backupURL.path))
    }

    func testSaveWritesSortedJSONAndReloadsState() async throws {
        let directory = try makeTemporaryDirectory()
        defer { try? FileManager.default.removeItem(at: directory) }
        let store = JSONSaveStore(directoryURL: directory)
        var state = GameState.new(now: now)
        state.carrots = 81

        try await store.save(state, at: now)
        let loaded = try await store.load(now: now.adding(seconds: 100))
        let primaryText = try String(contentsOf: store.primaryURL, encoding: .utf8)

        XCTAssertEqual(loaded, state)
        XCTAssertTrue(primaryText.hasPrefix(#"{"savedAt":"#))
        XCTAssertTrue(FileManager.default.fileExists(atPath: store.backupURL.path))
    }

    func testCorruptPrimaryRecoversPreviousStateFromBackup() async throws {
        let directory = try makeTemporaryDirectory()
        defer { try? FileManager.default.removeItem(at: directory) }
        let store = JSONSaveStore(directoryURL: directory)
        var first = GameState.new(now: now)
        first.carrots = 41
        var second = first
        second.carrots = 42
        try await store.save(first, at: now)
        try await store.save(second, at: now.adding(seconds: 1))
        try Data("not-json".utf8).write(to: store.primaryURL, options: .atomic)

        let recovered = try await store.load(now: now)

        XCTAssertEqual(recovered, first)
    }

    func testCorruptionWithoutBackupReturnsDefaultsAndPreservesCorruptFile() async throws {
        let directory = try makeTemporaryDirectory()
        defer { try? FileManager.default.removeItem(at: directory) }
        let store = JSONSaveStore(directoryURL: directory)
        let corruption = Data("broken".utf8)
        try corruption.write(to: store.primaryURL)

        let loaded = try await store.load(now: now)

        XCTAssertEqual(loaded, GameState.new(now: now))
        XCTAssertEqual(try Data(contentsOf: store.primaryURL), corruption)
    }

    func testSaveRepairsCorruptPrimaryAndBackupBeforeWritingFreshState() async throws {
        let directory = try makeTemporaryDirectory()
        defer { try? FileManager.default.removeItem(at: directory) }
        let store = JSONSaveStore(directoryURL: directory)
        try Data("bad-primary".utf8).write(to: store.primaryURL, options: .atomic)
        try Data("bad-backup".utf8).write(to: store.backupURL, options: .atomic)
        var state = GameState.new(now: now)
        state.carrots = 64

        try await store.save(state, at: now)

        let primary = try SaveMigrator().decodeAndMigrate(
            Data(contentsOf: store.primaryURL)
        )
        let backup = try SaveMigrator().decodeAndMigrate(
            Data(contentsOf: store.backupURL)
        )
        XCTAssertEqual(primary.state, state)
        XCTAssertEqual(backup.state, state)
    }

    func testFutureSchemaIsNeverDestroyedByLoadOrSave() async throws {
        let directory = try makeTemporaryDirectory()
        defer { try? FileManager.default.removeItem(at: directory) }
        let store = JSONSaveStore(directoryURL: directory)
        let future = Data(#"{"payload":{"future":true},"schemaVersion":999}"#.utf8)
        try future.write(to: store.primaryURL, options: .atomic)

        do {
            _ = try await store.load(now: now)
            XCTFail("A future schema must be surfaced to the caller")
        } catch {
            XCTAssertEqual(error as? SaveMigrationError, .unsupportedFutureSchema(999))
        }
        XCTAssertEqual(try Data(contentsOf: store.primaryURL), future)

        do {
            try await store.save(GameState.new(now: now), at: now)
            XCTFail("Saving over a future schema must fail")
        } catch {
            XCTAssertEqual(error as? SaveMigrationError, .unsupportedFutureSchema(999))
        }
        XCTAssertEqual(try Data(contentsOf: store.primaryURL), future)
    }

    func testFutureBackupAlsoBlocksDestructiveSave() async throws {
        let directory = try makeTemporaryDirectory()
        defer { try? FileManager.default.removeItem(at: directory) }
        let store = JSONSaveStore(directoryURL: directory)
        let future = Data(#"{"schemaVersion":3}"#.utf8)
        try future.write(to: store.backupURL, options: .atomic)

        do {
            try await store.save(GameState.new(now: now), at: now)
            XCTFail("A future backup must be retained")
        } catch {
            XCTAssertEqual(error as? SaveMigrationError, .unsupportedFutureSchema(3))
        }
        XCTAssertEqual(try Data(contentsOf: store.backupURL), future)
        XCTAssertFalse(FileManager.default.fileExists(atPath: store.primaryURL.path))
    }

    func testActorSerializesConcurrentSavesIntoAValidEnvelope() async throws {
        let directory = try makeTemporaryDirectory()
        defer { try? FileManager.default.removeItem(at: directory) }
        let store = JSONSaveStore(directoryURL: directory)

        try await withThrowingTaskGroup(of: Void.self) { group in
            for carrots in 50 ..< 70 {
                group.addTask {
                    var state = GameState.new(now: self.now)
                    state.carrots = carrots
                    try await store.save(
                        state,
                        at: self.now.adding(seconds: Int64(carrots))
                    )
                }
            }
            try await group.waitForAll()
        }

        let envelope = try SaveMigrator().decodeAndMigrate(Data(contentsOf: store.primaryURL))
        XCTAssertTrue((50 ..< 70).contains(envelope.state.carrots))
        XCTAssertNoThrow(
            try SaveMigrator().decodeAndMigrate(Data(contentsOf: store.backupURL))
        )
    }

    func testVersionOneMigrationPreservesCarrotsAndOwnedItemsWithNewDefaults() throws {
        let fixtureURL = try XCTUnwrap(
            Bundle.module.url(
                forResource: "save-v1",
                withExtension: "json",
                subdirectory: "Fixtures"
            )
        )
        var fixture = try String(contentsOf: fixtureURL, encoding: .utf8)
        fixture = fixture.replacingOccurrences(of: #""carrots": 30"#, with: #""carrots": 247"#)
        fixture = fixture.replacingOccurrences(
            of: #""ownedItems": []"#,
            with: #""ownedItems": ["cozy-bow"]"#
        )

        let migrated = try SaveMigrator().decodeAndMigrate(Data(fixture.utf8))

        XCTAssertEqual(migrated.schemaVersion, SaveEnvelope.currentSchemaVersion)
        XCTAssertEqual(migrated.state.carrots, 247)
        XCTAssertEqual(migrated.state.ownedItems, [GoobyCatalog.cozyBow])
        XCTAssertEqual(migrated.state.foodQuantity(GoobyCatalog.gardenCarrot), 3)
        XCTAssertEqual(migrated.state.preferences, GamePreferences())
    }

    func testResetDeletesPreviousProgressAndPersistsFreshState() async throws {
        let directory = try makeTemporaryDirectory()
        defer { try? FileManager.default.removeItem(at: directory) }
        let store = JSONSaveStore(directoryURL: directory)
        var state = GameState.new(now: now)
        state.carrots = 999
        state.ownedItems = [GoobyCatalog.sunshineBow]
        try await store.save(state, at: now)

        let reset = try await store.reset(now: now.adding(seconds: 10))
        let reloaded = try await store.load(now: now.adding(seconds: 10))

        XCTAssertEqual(reset, GameState.new(now: now.adding(seconds: 10)))
        XCTAssertEqual(reloaded, reset)
        XCTAssertTrue(FileManager.default.fileExists(atPath: store.primaryURL.path))
        XCTAssertTrue(FileManager.default.fileExists(atPath: store.backupURL.path))
    }

    private func makeTemporaryDirectory() throws -> URL {
        let url = FileManager.default.temporaryDirectory
            .appendingPathComponent("GoobyTests-\(UUID().uuidString)", isDirectory: true)
        try FileManager.default.createDirectory(at: url, withIntermediateDirectories: true)
        return url
    }
}
