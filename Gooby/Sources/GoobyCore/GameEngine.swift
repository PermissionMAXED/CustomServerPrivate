public enum GameSimulation {
    public static let tickSeconds: Int64 = 60
    public static let offlineCapSeconds: Int64 = 8 * 60 * 60

    public static func advance(_ state: inout GameState, to now: GameInstant) -> [GameEvent] {
        let elapsed = now.secondsSinceEpoch - state.lastSimulatedAt.secondsSinceEpoch
        guard elapsed >= tickSeconds else {
            return []
        }

        let simulatedSeconds = min(elapsed, offlineCapSeconds)
        let minutes = Int(simulatedSeconds / tickSeconds)
        guard minutes > 0 else { return [] }

        for _ in 0 ..< minutes {
            applyTick(to: &state)
        }

        if elapsed > offlineCapSeconds {
            state.lastSimulatedAt = now
        } else {
            state.lastSimulatedAt = state.lastSimulatedAt.adding(
                seconds: Int64(minutes) * tickSeconds
            )
        }
        return [.simulated(minutes: minutes)]
    }

    private static func applyTick(to state: inout GameState) {
        if state.isSleeping {
            state.needs.fullness.adjust(by: -1, floor: 200)
            state.needs.cleanliness.adjust(by: -1, floor: 150)
            state.needs.energy.adjust(by: 4, floor: 100)
            state.needs.fun.adjust(by: 0, floor: 100)
        } else {
            state.needs.fullness.adjust(by: -2, floor: 200)
            state.needs.cleanliness.adjust(by: -1, floor: 150)
            state.needs.energy.adjust(by: -1, floor: 100)
            state.needs.fun.adjust(by: -1, floor: 100)
        }
    }
}

public enum GameEngine {
    public static let dailyCarrotRewards = [5, 7, 9, 12, 15, 20, 30]
    public static let minigameDurationSeconds: Int64 = 5 * 60

    @discardableResult
    public static func apply(
        _ command: GameCommand,
        to state: inout GameState,
        at now: GameInstant
    ) throws -> [GameEvent] {
        var events = GameSimulation.advance(&state, to: now)

        switch command {
        case let .move(room):
            state.currentRoom = room
            state.isSleeping = false
            events.append(.moved(room))

        case .feed:
            try requireRoom(.kitchen, state: state)
            try spendCarrots(2, state: &state, events: &events)
            state.isSleeping = false
            state.needs.fullness.adjust(by: 250)
            state.careStatistics.meals += 1
            events.append(.fed)
            addBond(5, state: &state, events: &events)

        case .wash:
            try requireRoom(.washroom, state: state)
            state.isSleeping = false
            state.needs.cleanliness.adjust(by: 350)
            state.careStatistics.baths += 1
            events.append(.washed)
            addBond(5, state: &state, events: &events)

        case .pet:
            guard !state.isSleeping else {
                throw GameRuleError.petIsSleeping
            }
            state.needs.fun.adjust(by: 150)
            events.append(.petted)
            addBond(3, state: &state, events: &events)

        case .play:
            try requireRoom(.playroom, state: state)
            let energy = state.needs.energy.value
            guard energy >= 100 else {
                throw GameRuleError.insufficientEnergy(required: 100, available: energy)
            }
            state.isSleeping = false
            state.needs.energy.adjust(by: -80)
            state.needs.fun.adjust(by: 300)
            state.careStatistics.playSessions += 1
            events.append(.played)
            addBond(8, state: &state, events: &events)

        case .beginSleep:
            try requireRoom(.bedroom, state: state)
            state.isSleeping = true
            events.append(.sleepChanged(true))

        case .endSleep:
            state.isSleeping = false
            events.append(.sleepChanged(false))

        case .claimDailyReward:
            try claimDailyReward(state: &state, at: now, events: &events)

        case let .purchase(itemID):
            try purchase(itemID, state: &state, events: &events)

        case let .equip(itemID):
            try equip(itemID, state: &state, events: &events)

        case let .startMinigame(kind):
            try startMinigame(kind, state: &state, at: now, events: &events)

        case let .finishMinigame(runID, submission):
            try finishMinigame(
                runID: runID,
                submission: submission,
                state: &state,
                at: now,
                events: &events
            )
        }

        unlockAchievements(state: &state, events: &events)
        return events
    }

    private static func requireRoom(_ room: RoomID, state: GameState) throws {
        guard state.currentRoom == room else {
            throw GameRuleError.wrongRoom(required: room)
        }
    }

    private static func spendCarrots(
        _ amount: Int,
        state: inout GameState,
        events: inout [GameEvent]
    ) throws {
        state.carrots = max(0, state.carrots)
        guard state.carrots >= amount else {
            throw GameRuleError.insufficientCarrots(required: amount, available: state.carrots)
        }
        state.carrots -= amount
        events.append(.carrotsChanged(delta: -amount, balance: state.carrots))
    }

    private static func addCarrots(
        _ amount: Int,
        state: inout GameState,
        events: inout [GameEvent]
    ) {
        guard amount > 0 else { return }
        state.carrots = max(0, state.carrots)
        let (newBalance, overflowed) = state.carrots.addingReportingOverflow(amount)
        state.carrots = overflowed ? Int.max : newBalance
        events.append(.carrotsChanged(delta: amount, balance: state.carrots))
    }

    private static func addBond(
        _ points: Int,
        state: inout GameState,
        events: inout [GameEvent]
    ) {
        let oldLevel = state.bondLevel
        state.bondPoints = max(0, state.bondPoints + points)
        let newLevel = state.bondLevel
        guard newLevel > oldLevel else { return }

        for level in (oldLevel + 1) ... newLevel {
            events.append(.bondLevelChanged(level: level))
            let previous = Set(BondProgress.unlockedFeatures(at: level - 1))
            for feature in BondProgress.unlockedFeatures(at: level) where !previous.contains(feature) {
                events.append(.featureUnlocked(feature))
            }
        }
    }

    private static func claimDailyReward(
        state: inout GameState,
        at now: GameInstant,
        events: inout [GameEvent]
    ) throws {
        let day = now.secondsSinceEpoch / 86_400
        let lastDay = state.dailyReward.lastClaimedDay

        if let lastDay {
            guard day >= lastDay else {
                throw GameRuleError.clockRollback
            }
            guard day != lastDay else {
                throw GameRuleError.dailyRewardAlreadyClaimed
            }
        }

        let step: Int
        if let lastDay, day == lastDay + 1 {
            step = state.dailyReward.streakStep % dailyCarrotRewards.count
        } else {
            step = 0
        }

        let reward = dailyCarrotRewards[step]
        state.dailyReward.lastClaimedDay = day
        state.dailyReward.streakStep = step + 1
        addCarrots(reward, state: &state, events: &events)
        events.append(.dailyRewardClaimed(step: step + 1, carrots: reward))
    }

    private static func purchase(
        _ itemID: ItemID,
        state: inout GameState,
        events: inout [GameEvent]
    ) throws {
        guard let item = GoobyCatalog.item(id: itemID) else {
            throw GameRuleError.unknownItem(itemID)
        }
        if state.ownedItems.contains(itemID) {
            events.append(.purchaseAlreadyOwned(itemID))
            return
        }
        guard state.bondLevel >= item.requiredBondLevel else {
            throw GameRuleError.itemLocked(requiredBondLevel: item.requiredBondLevel)
        }
        try spendCarrots(item.price, state: &state, events: &events)
        state.ownedItems.append(itemID)
        state.ownedItems.sort()
        events.append(.purchased(itemID))
    }

    private static func equip(
        _ itemID: ItemID,
        state: inout GameState,
        events: inout [GameEvent]
    ) throws {
        guard let item = GoobyCatalog.item(id: itemID) else {
            throw GameRuleError.unknownItem(itemID)
        }
        guard state.ownedItems.contains(itemID) else {
            throw GameRuleError.itemNotOwned(itemID)
        }
        guard case let .cosmetic(slot) = item.kind else {
            throw GameRuleError.itemNotEquippable(itemID)
        }
        state.equippedCosmetics[slot] = itemID
        events.append(.equipped(itemID, slot: slot))
    }

    private static func startMinigame(
        _ kind: MinigameKind,
        state: inout GameState,
        at now: GameInstant,
        events: inout [GameEvent]
    ) throws {
        guard state.activeMinigame == nil else {
            throw GameRuleError.minigameAlreadyActive
        }
        if kind == .gardenEcho, state.bondLevel < 1 {
            throw GameRuleError.featureLocked(requiredBondLevel: 1)
        }

        var random = SplitMix64(seed: state.randomState)
        let seed = random.next()
        let identifierBits = random.next()
        state.randomState = random.state
        let run = ActiveMinigameRun(
            id: MinigameRunID(rawValue: String(identifierBits, radix: 16)),
            kind: kind,
            seed: seed,
            startedAt: now
        )
        state.activeMinigame = run
        events.append(.minigameStarted(run))
    }

    private static func finishMinigame(
        runID: MinigameRunID,
        submission: MinigameSubmission,
        state: inout GameState,
        at now: GameInstant,
        events: inout [GameEvent]
    ) throws {
        if state.rewardedMinigameRuns.contains(runID) {
            events.append(.minigameRewardAlreadyGranted(runID))
            return
        }
        guard let run = state.activeMinigame else {
            throw GameRuleError.noActiveMinigame
        }
        guard run.id == runID else {
            throw GameRuleError.invalidMinigameRun
        }

        let elapsed = now.secondsSinceEpoch - run.startedAt.secondsSinceEpoch
        guard elapsed >= 0 else {
            throw GameRuleError.clockRollback
        }
        guard elapsed <= minigameDurationSeconds else {
            throw GameRuleError.minigameExpired
        }

        let score: Int
        switch (run.kind, submission) {
        case let (.carrotCatch, .carrotCatch(moves)):
            guard let result = CarrotCatch.play(seed: run.seed, moves: moves) else {
                throw GameRuleError.invalidMinigameSubmission
            }
            score = result.score

        case let (.gardenEcho, .gardenEcho(rounds)):
            guard let result = GardenEcho.play(seed: run.seed, rounds: rounds) else {
                throw GameRuleError.invalidMinigameSubmission
            }
            score = result.score

        default:
            throw GameRuleError.invalidMinigameSubmission
        }

        let reward = score / 10
        state.activeMinigame = nil
        state.rewardedMinigameRuns.append(runID)
        addCarrots(reward, state: &state, events: &events)
        addBond(min(score / 20, 10), state: &state, events: &events)
        events.append(.minigameFinished(runID: runID, score: score, carrots: reward))
    }

    private static func unlockAchievements(
        state: inout GameState,
        events: inout [GameEvent]
    ) {
        let candidates: [(AchievementID, Bool)] = [
            (.firstMeal, state.careStatistics.meals >= 1),
            (.squeakyClean, state.careStatistics.baths >= 1),
            (.playtime, state.careStatistics.playSessions >= 1),
            (.carrotCollector, state.carrots >= 100),
            (.bestBunny, state.bondLevel >= 4),
        ]

        for (achievement, earned) in candidates
        where earned && !state.unlockedAchievements.contains(achievement) {
            state.unlockedAchievements.append(achievement)
            state.unlockedAchievements.sort()
            events.append(.achievementUnlocked(achievement))
        }
    }
}
