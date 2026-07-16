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
            try migrator.decodeAndMigrate(Data(#"{"schemaVersion":4}"#.utf8))
        ) { error in
            XCTAssertEqual(error as? SaveMigrationError, .unsupportedFutureSchema(4))
        }
    }

    func testMissingSaveLoadsDefaultsWithoutWritingFiles() async throws {
        let directory = try makeTemporaryDirectory()
        defer { try? FileManager.default.removeItem(at: directory) }
        let store = JSONSaveStore(directoryURL: directory)

        let loaded = try await store.load(now: now)

        XCTAssertEqual(loaded.state, GameState.new(now: now))
        XCTAssertEqual(loaded.source, .missing)
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

        XCTAssertEqual(loaded.state, state)
        XCTAssertEqual(loaded.source, .primary)
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

        XCTAssertEqual(recovered.state, first)
        XCTAssertEqual(recovered.source, .recoveredBackup)
    }

    func testCorruptionWithoutBackupRequiresRecoveryAndPreservesCorruptFile() async throws {
        let directory = try makeTemporaryDirectory()
        defer { try? FileManager.default.removeItem(at: directory) }
        let store = JSONSaveStore(directoryURL: directory)
        let corruption = Data("broken".utf8)
        try corruption.write(to: store.primaryURL)

        do {
            _ = try await store.load(now: now)
            XCTFail("Existing corruption must fail closed")
        } catch {
            XCTAssertEqual(
                error as? SaveRecoveryRequired,
                SaveRecoveryRequired(primary: .corrupt, backup: .missing)
            )
        }
        XCTAssertEqual(try Data(contentsOf: store.primaryURL), corruption)
        XCTAssertFalse(FileManager.default.fileExists(atPath: store.backupURL.path))
    }

    func testSaveNeverRepairsUnconfirmedCorruptPrimaryAndBackup() async throws {
        let directory = try makeTemporaryDirectory()
        defer { try? FileManager.default.removeItem(at: directory) }
        let store = JSONSaveStore(directoryURL: directory)
        try Data("bad-primary".utf8).write(to: store.primaryURL, options: .atomic)
        try Data("bad-backup".utf8).write(to: store.backupURL, options: .atomic)
        var state = GameState.new(now: now)
        state.carrots = 64

        do {
            try await store.save(state, at: now)
            XCTFail("Unusable files must not be overwritten")
        } catch {
            XCTAssertEqual(
                error as? SaveRecoveryRequired,
                SaveRecoveryRequired(primary: .corrupt, backup: .corrupt)
            )
        }
        XCTAssertEqual(try Data(contentsOf: store.primaryURL), Data("bad-primary".utf8))
        XCTAssertEqual(try Data(contentsOf: store.backupURL), Data("bad-backup".utf8))
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
            XCTAssertEqual(
                error as? SaveRecoveryRequired,
                SaveRecoveryRequired(primary: .futureSchema(999), backup: .missing)
            )
        }
        XCTAssertEqual(try Data(contentsOf: store.primaryURL), future)

        do {
            try await store.save(GameState.new(now: now), at: now)
            XCTFail("Saving over a future schema must fail")
        } catch {
            XCTAssertEqual(
                error as? SaveRecoveryRequired,
                SaveRecoveryRequired(primary: .futureSchema(999), backup: .missing)
            )
        }
        XCTAssertEqual(try Data(contentsOf: store.primaryURL), future)
    }

    func testFutureBackupAlsoBlocksDestructiveSave() async throws {
        let directory = try makeTemporaryDirectory()
        defer { try? FileManager.default.removeItem(at: directory) }
        let store = JSONSaveStore(directoryURL: directory)
        let future = Data(#"{"schemaVersion":999}"#.utf8)
        try future.write(to: store.backupURL, options: .atomic)

        do {
            try await store.save(GameState.new(now: now), at: now)
            XCTFail("A future backup must be retained")
        } catch {
            XCTAssertEqual(
                error as? SaveRecoveryRequired,
                SaveRecoveryRequired(primary: .missing, backup: .futureSchema(999))
            )
        }
        XCTAssertEqual(try Data(contentsOf: store.backupURL), future)
        XCTAssertFalse(FileManager.default.fileExists(atPath: store.primaryURL.path))
    }

    func testFutureBackupIsPreservedEvenWhenPrimaryIsUsable() async throws {
        let directory = try makeTemporaryDirectory()
        defer { try? FileManager.default.removeItem(at: directory) }
        let store = JSONSaveStore(directoryURL: directory)
        let current = GameState.new(now: now)
        try await store.save(current, at: now)
        let future = Data(#"{"schemaVersion":999,"future":true}"#.utf8)
        try future.write(to: store.backupURL, options: .atomic)
        var candidate = current
        candidate.carrots = 88

        do {
            try await store.save(candidate, at: now)
            XCTFail("A future backup must be preserved")
        } catch {
            XCTAssertEqual(
                error as? SaveRecoveryRequired,
                SaveRecoveryRequired(primary: .valid, backup: .futureSchema(999))
            )
        }
        XCTAssertEqual(try Data(contentsOf: store.backupURL), future)
        let loaded = try await store.load(now: now)
        XCTAssertEqual(loaded.state, current)
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

    func testVersionTwoMigrationPreservesProgressAndCreatesLegacyDayLedger() throws {
        let data = try fixture(named: "save-v2")
        let migrated = try SaveMigrator().decodeAndMigrate(data)

        XCTAssertEqual(migrated.schemaVersion, 3)
        XCTAssertEqual(migrated.state.carrots, 247)
        XCTAssertEqual(migrated.state.bondPoints, 88)
        XCTAssertEqual(migrated.state.needs.fullness.value, 530)
        XCTAssertEqual(migrated.state.foodQuantity(GoobyCatalog.gardenCarrot), 9)
        XCTAssertEqual(migrated.state.foodQuantity(ItemID(rawValue: "legacy-snack")), 2)
        XCTAssertTrue(migrated.state.ownedItems.contains(ItemID(rawValue: "unknown-safe-owned-item")))
        XCTAssertEqual(migrated.state.preferences.petName, "Mochi")
        XCTAssertEqual(migrated.state.bestMinigameScores[.carrotCatch], 140)
        XCTAssertEqual(
            migrated.state.dailyReward.claimedLocalDays,
            [DailyRewardSchedule.legacyUTCKey(day: 20_000)]
        )
    }

    func testCheckedInVersionThreeFixtureDecodesWithoutLoss() throws {
        let migrated = try SaveMigrator().decodeAndMigrate(try fixture(named: "save-v3"))

        XCTAssertEqual(migrated.state.carrots, 91)
        XCTAssertEqual(migrated.state.dailyReward.visitStep, 2)
        XCTAssertEqual(
            migrated.state.dailyReward.claimedLocalDays.map(\.rawValue),
            ["2024-10-03", "2024-10-05"]
        )
        XCTAssertEqual(migrated.state.equippedCosmetics.neck, GoobyCatalog.sunshineBow)
    }

    func testSemanticMalformedStateNormalizesWithoutDroppingSafeUnknownOwnership() throws {
        var state = GameState.new(now: now)
        let unknown = ItemID(rawValue: "future-cosmetic")
        state.carrots = -100
        state.bondPoints = -4
        state.ownedItems = [unknown, unknown, GoobyCatalog.sunshineBow]
        state.foodInventory = [GoobyCatalog.gardenCarrot: -9]
        state.equippedCosmetics.head = GoobyCatalog.sunshineBow
        state.unlockedAchievements = [.firstMeal, .firstMeal]
        state.rewardedMinigameRuns = [
            MinigameRunID(rawValue: "same"),
            MinigameRunID(rawValue: "same"),
        ]
        state.bestMinigameScores[.carrotCatch] = -1
        state.dailyReward.visitStep = -7
        state.dailyReward.claimedLocalDays = [
            LocalDayKey(rawValue: "not-a-day"),
            LocalDayKey(rawValue: "2024-11-03"),
            LocalDayKey(rawValue: "2024-11-03"),
        ]
        let data = try JSONEncoder().encode(SaveEnvelope(savedAt: now, state: state))

        let normalized = try SaveMigrator().decodeAndMigrate(data).state

        XCTAssertEqual(normalized.carrots, 0)
        XCTAssertEqual(normalized.bondPoints, 0)
        XCTAssertTrue(normalized.ownedItems.contains(unknown))
        XCTAssertEqual(normalized.ownedItems.filter { $0 == unknown }.count, 1)
        XCTAssertEqual(normalized.foodInventory, [:])
        XCTAssertNil(normalized.equippedCosmetics.head)
        XCTAssertEqual(normalized.unlockedAchievements, [.firstMeal])
        XCTAssertEqual(normalized.rewardedMinigameRuns, [MinigameRunID(rawValue: "same")])
        XCTAssertEqual(normalized.bestMinigameScores[.carrotCatch], 0)
        XCTAssertEqual(normalized.dailyReward.visitStep, 0)
        XCTAssertEqual(
            normalized.dailyReward.claimedLocalDays,
            [LocalDayKey(rawValue: "2024-11-03")]
        )
    }

    func testUnsafeSemanticIdentityIsClassifiedInvalidAndNeverWrittenOver() async throws {
        let directory = try makeTemporaryDirectory()
        defer { try? FileManager.default.removeItem(at: directory) }
        let store = JSONSaveStore(directoryURL: directory)
        var invalid = String(decoding: try fixture(named: "save-v3"), as: UTF8.self)
        invalid = invalid.replacingOccurrences(
            of: #""petID": "gooby""#,
            with: #""petID": "other-pet""#
        )
        let bytes = Data(invalid.utf8)
        try bytes.write(to: store.primaryURL)

        do {
            _ = try await store.load(now: now)
            XCTFail("Unsafe semantic identity must require recovery")
        } catch {
            XCTAssertEqual(
                error as? SaveRecoveryRequired,
                SaveRecoveryRequired(primary: .invalid(["petID"]), backup: .missing)
            )
        }
        XCTAssertEqual(try Data(contentsOf: store.primaryURL), bytes)
    }

    func testConfirmedDamagedResetReplacesBothFiles() async throws {
        let directory = try makeTemporaryDirectory()
        defer { try? FileManager.default.removeItem(at: directory) }
        let store = JSONSaveStore(directoryURL: directory)
        try Data("primary-damage".utf8).write(to: store.primaryURL)
        try Data("backup-damage".utf8).write(to: store.backupURL)

        let fresh = try await store.reset(now: now, discardingDamagedSave: true)
        let loaded = try await store.load(now: now)

        XCTAssertEqual(fresh, GameState.new(now: now))
        XCTAssertEqual(loaded.state, fresh)
        XCTAssertEqual(loaded.source, .primary)
    }

    func testResetFailuresLeaveOldPrimaryEffectiveAtEveryWritePoint() async throws {
        for point in [SaveWritePoint.resetBackup, .resetPrimary] {
            let directory = try makeTemporaryDirectory()
            defer { try? FileManager.default.removeItem(at: directory) }
            let setup = JSONSaveStore(directoryURL: directory)
            var old = GameState.new(now: now)
            old.carrots = 333
            try await setup.save(old, at: now)

            let failing = JSONSaveStore(
                directoryURL: directory,
                beforeWrite: { candidate in
                    if candidate == point { throw InjectedFailure.write }
                }
            )
            do {
                _ = try await failing.reset(
                    now: self.now.adding(seconds: 1),
                    discardingDamagedSave: false
                )
                XCTFail("Expected injected failure at \(point)")
            } catch {
                XCTAssertEqual(error as? InjectedFailure, .write)
            }
            let loaded = try await setup.load(now: now)
            XCTAssertEqual(loaded.state, old)
            XCTAssertEqual(loaded.source, .primary)
        }
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
        XCTAssertEqual(reloaded.state, reset)
        XCTAssertTrue(FileManager.default.fileExists(atPath: store.primaryURL.path))
        XCTAssertTrue(FileManager.default.fileExists(atPath: store.backupURL.path))
    }

    private func makeTemporaryDirectory() throws -> URL {
        let url = FileManager.default.temporaryDirectory
            .appendingPathComponent("GoobyTests-\(UUID().uuidString)", isDirectory: true)
        try FileManager.default.createDirectory(at: url, withIntermediateDirectories: true)
        return url
    }

    private func fixture(named name: String) throws -> Data {
        let url = try XCTUnwrap(
            Bundle.module.url(
                forResource: name,
                withExtension: "json",
                subdirectory: "Fixtures"
            )
        )
        return try Data(contentsOf: url)
    }
}

private enum InjectedFailure: Error, Equatable {
    case write
}
