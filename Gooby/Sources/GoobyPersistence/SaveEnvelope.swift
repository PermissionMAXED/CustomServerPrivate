import Foundation
import GoobyCore

public struct SaveEnvelope: Codable, Equatable, Sendable {
    public static let currentSchemaVersion = 3

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
    case invalidState([String])
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
            let migrated: SaveEnvelope
            switch version {
            case 1:
                migrated = try migrateVersionOne(decoded)
            case 2:
                migrated = try migrateVersionTwo(decoded)
            case SaveEnvelope.currentSchemaVersion:
                migrated = decoded
            default:
                throw SaveMigrationError.unsupportedPastSchema(version)
            }
            guard migrated.state.petID == .gooby else {
                throw SaveMigrationError.invalidState(["petID"])
            }
            return SaveEnvelope(
                savedAt: migrated.savedAt,
                state: GameStateValidator.normalized(
                    migrated.state,
                    savedAt: migrated.savedAt
                )
            )
        } catch let error as SaveMigrationError {
            throw error
        } catch {
            throw SaveMigrationError.malformedEnvelope
        }
    }

    private func migrateVersionOne(_ envelope: SaveEnvelope) throws -> SaveEnvelope {
        SaveEnvelope(savedAt: envelope.savedAt, state: envelope.state)
    }

    private func migrateVersionTwo(_ envelope: SaveEnvelope) throws -> SaveEnvelope {
        var state = envelope.state
        if state.dailyReward.claimedLocalDays.isEmpty,
           let legacyDay = state.dailyReward.lastClaimedDay {
            state.dailyReward.claimedLocalDays = [
                DailyRewardSchedule.legacyUTCKey(day: legacyDay),
            ]
        }
        return SaveEnvelope(savedAt: envelope.savedAt, state: state)
    }
}

public enum GameStateValidator {
    public static func normalized(_ value: GameState, savedAt: GameInstant) -> GameState {
        var state = value
        state.carrots = max(0, state.carrots)
        state.bondPoints = max(0, state.bondPoints)
        state.careStatistics.meals = max(0, state.careStatistics.meals)
        state.careStatistics.baths = max(0, state.careStatistics.baths)
        state.careStatistics.playSessions = max(0, state.careStatistics.playSessions)

        if state.createdAt > state.lastSimulatedAt {
            state.createdAt = state.lastSimulatedAt
        }
        if state.isSleeping, state.currentRoom != .bedroom {
            state.isSleeping = false
        }

        state.ownedItems = unique(state.ownedItems.filter { !$0.rawValue.isEmpty }).sorted()
        state.foodInventory = Dictionary(
            uniqueKeysWithValues: state.foodInventory.compactMap { item, quantity in
                guard !item.rawValue.isEmpty, quantity > 0 else { return nil }
                return (item, quantity)
            }
        )
        normalizeEquipment(&state.equippedCosmetics, owned: Set(state.ownedItems))

        state.unlockedAchievements = unique(
            state.unlockedAchievements.filter { !$0.rawValue.isEmpty }
        ).sorted()
        let unlocked = Set(state.unlockedAchievements)
        state.achievementUnlockDates = state.achievementUnlockDates.filter {
            unlocked.contains($0.key) && !$0.key.rawValue.isEmpty
        }

        let cycleCount = max(1, GameEngine.dailyCarrotRewards.count)
        if state.dailyReward.visitStep <= 0 {
            state.dailyReward.visitStep = 0
        } else {
            state.dailyReward.visitStep = ((state.dailyReward.visitStep - 1) % cycleCount) + 1
        }
        state.dailyReward.claimedLocalDays = unique(
            state.dailyReward.claimedLocalDays.filter(DailyRewardSchedule.isValid)
        )
        if state.dailyReward.claimedLocalDays.isEmpty,
           let legacyDay = state.dailyReward.lastClaimedDay {
            state.dailyReward.claimedLocalDays = [
                DailyRewardSchedule.legacyUTCKey(day: legacyDay),
            ]
        }

        let trimmedName = state.preferences.petName.trimmingCharacters(
            in: .whitespacesAndNewlines
        )
        state.preferences.petName = trimmedName.isEmpty
            ? "Gooby"
            : String(trimmedName.prefix(GamePreferences.maximumPetNameLength))

        state.rewardedMinigameRuns = unique(
            state.rewardedMinigameRuns.filter { !$0.rawValue.isEmpty }
        )
        state.bestMinigameScores = Dictionary(
            uniqueKeysWithValues: state.bestMinigameScores.map { ($0.key, max(0, $0.value)) }
        )
        if let run = state.activeMinigame, !isValid(run, savedAt: savedAt) {
            state.activeMinigame = nil
        }
        return state
    }

    public static func validate(_ state: GameState, savedAt: GameInstant) throws {
        guard state.petID == .gooby else {
            throw SaveMigrationError.invalidState(["petID"])
        }
        let normalizedState = normalized(state, savedAt: savedAt)
        guard normalizedState == state else {
            throw SaveMigrationError.invalidState(validationIssues(in: state, normalized: normalizedState))
        }
    }

    private static func validationIssues(in state: GameState, normalized: GameState) -> [String] {
        var issues: [String] = []
        if state.carrots != normalized.carrots { issues.append("carrots") }
        if state.bondPoints != normalized.bondPoints { issues.append("bondPoints") }
        if state.ownedItems != normalized.ownedItems { issues.append("ownedItems") }
        if state.foodInventory != normalized.foodInventory { issues.append("foodInventory") }
        if state.equippedCosmetics != normalized.equippedCosmetics { issues.append("equipment") }
        if state.dailyReward != normalized.dailyReward { issues.append("dailyReward") }
        if state.activeMinigame != normalized.activeMinigame { issues.append("activeMinigame") }
        if issues.isEmpty { issues.append("state") }
        return issues
    }

    private static func normalizeEquipment(
        _ equipment: inout EquippedCosmetics,
        owned: Set<ItemID>
    ) {
        for slot in CosmeticSlot.allCases {
            guard let itemID = equipment[slot] else { continue }
            guard owned.contains(itemID),
                  let item = GoobyCatalog.item(id: itemID),
                  case let .cosmetic(expectedSlot) = item.kind,
                  expectedSlot == slot
            else {
                equipment[slot] = nil
                continue
            }
        }
    }

    private static func isValid(_ run: ActiveMinigameRun, savedAt: GameInstant) -> Bool {
        guard !run.id.rawValue.isEmpty,
              run.accumulatedActiveSeconds >= 0,
              run.startedAt <= savedAt,
              run.lastResumedAt.map({ $0 >= run.startedAt }) ?? true
        else {
            return false
        }
        switch (run.kind, run.progress) {
        case let (.carrotCatch, .carrotCatch(progress)):
            guard progress.game.seed == run.seed,
                  progress.game.moves.count <= CarrotCatch.maximumMoves,
                  progress.game.moves.allSatisfy({
                      $0.lane.map(CarrotCatch.laneRange.contains) ?? true
                  }),
                  (0 ... 3).contains(progress.countdownRemaining),
                  progress.accumulatedPlayingSeconds >= 0
            else {
                return false
            }
            if progress.stage == .terminal {
                return progress.game.isFinished
                    && progress.game.moves.count == CarrotCatch.maximumMoves
            }
            return !progress.game.isFinished
        case let (.gardenEcho, .gardenEcho(progress)):
            guard progress.game.seed == run.seed,
                  progress.currentSequence == progress.game.sequence,
                  (1 ... GardenEcho.maximumRounds).contains(progress.game.round),
                  (0 ... GardenEcho.maximumMistakes).contains(progress.game.mistakes),
                  progress.replayCount >= 0,
                  progress.playbackIndex >= 0
            else {
                return false
            }
            return progress.game.submittedRounds.count <= GardenEcho.maximumRounds
                && progress.game.input.allSatisfy(GardenEcho.symbolRange.contains)
        default:
            return false
        }
    }

    private static func unique<Element: Hashable>(_ values: [Element]) -> [Element] {
        var seen: Set<Element> = []
        return values.filter { seen.insert($0).inserted }
    }
}
