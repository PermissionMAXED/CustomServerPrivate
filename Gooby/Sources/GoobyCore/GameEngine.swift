public enum GameSimulation {
    public static let tickSeconds: Int64 = 60
    public static let offlineCapSeconds: Int64 = 8 * 60 * 60

    public static func advance(_ state: inout GameState, to now: GameInstant) -> [GameEvent] {
        guard now >= state.lastSimulatedAt else { return [] }
        let (difference, overflowed) = now.secondsSinceEpoch.subtractingReportingOverflow(
            state.lastSimulatedAt.secondsSinceEpoch
        )
        let elapsed = overflowed ? Int64.max : difference
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
    public static let duplicateMoonCrownCarrots = 25
    public static let minigameDurationSeconds: Int64 = 5 * 60

    @discardableResult
    public static func reconcileProgression(
        _ state: inout GameState,
        at now: GameInstant
    ) -> [GameEvent] {
        var candidate = state
        var events: [GameEvent] = []
        unlockBondEntitlements(state: &candidate, events: &events)
        unlockAchievements(state: &candidate, at: now, events: &events)
        state = candidate
        return events
    }

    @discardableResult
    public static func apply(
        _ command: GameCommand,
        to state: inout GameState,
        at now: GameInstant
    ) throws -> [GameEvent] {
        var candidate = state
        var events = GameSimulation.advance(&candidate, to: now)

        switch command {
        case let .move(room):
            candidate.currentRoom = room
            candidate.isSleeping = false
            events.append(.moved(room))

        case .feed:
            try feed(GoobyCatalog.gardenCarrot, state: &candidate, events: &events)

        case let .feedFood(itemID):
            try feed(itemID, state: &candidate, events: &events)

        case .wash:
            try requireRoom(.washroom, state: candidate)
            candidate.isSleeping = false
            candidate.needs.cleanliness.adjust(by: 350)
            candidate.careStatistics.baths = incremented(candidate.careStatistics.baths)
            events.append(.washed)
            addBond(5, state: &candidate, events: &events)

        case .pet:
            guard !candidate.isSleeping else {
                throw GameRuleError.petIsSleeping
            }
            candidate.needs.fun.adjust(by: 150)
            events.append(.petted)
            addBond(3, state: &candidate, events: &events)

        case .play:
            try requireRoom(.playroom, state: candidate)
            let energy = candidate.needs.energy.value
            guard energy >= 100 else {
                throw GameRuleError.insufficientEnergy(required: 100, available: energy)
            }
            candidate.isSleeping = false
            candidate.needs.energy.adjust(by: -80)
            candidate.needs.fun.adjust(by: 300)
            candidate.careStatistics.playSessions = incremented(
                candidate.careStatistics.playSessions
            )
            events.append(.played)
            addBond(8, state: &candidate, events: &events)

        case .beginSleep:
            try requireRoom(.bedroom, state: candidate)
            candidate.isSleeping = true
            events.append(.sleepChanged(true))

        case .endSleep:
            candidate.isSleeping = false
            events.append(.sleepChanged(false))

        case .claimDailyReward:
            try claimDailyReward(state: &candidate, at: now, events: &events)

        case let .purchase(itemID):
            try purchase(itemID, state: &candidate, events: &events)

        case let .equip(itemID):
            try equip(itemID, state: &candidate, events: &events)

        case let .unequip(slot):
            candidate.equippedCosmetics[slot] = nil
            events.append(.unequipped(slot: slot))

        case let .renamePet(name):
            let validated = try GamePreferences.validatedPetName(name)
            candidate.preferences.petName = validated
            events.append(.petRenamed(validated))

        case let .setSoundEnabled(enabled):
            candidate.preferences.soundEnabled = enabled
            events.append(.preferencesChanged)

        case let .setHapticsEnabled(enabled):
            candidate.preferences.hapticsEnabled = enabled
            events.append(.preferencesChanged)

        case let .setReduceMotionEnabled(enabled):
            candidate.preferences.reduceMotionEnabled = enabled
            events.append(.preferencesChanged)

        case let .startMinigame(kind):
            try startMinigame(kind, state: &candidate, at: now, events: &events)

        case let .pauseMinigame(runID):
            try setMinigamePaused(
                true,
                runID: runID,
                state: &candidate,
                at: now,
                events: &events
            )

        case let .resumeMinigame(runID):
            try setMinigamePaused(
                false,
                runID: runID,
                state: &candidate,
                at: now,
                events: &events
            )

        case let .cancelMinigame(runID):
            try cancelMinigame(runID: runID, state: &candidate, events: &events)

        case let .finishMinigame(runID, submission):
            try finishMinigame(
                runID: runID,
                submission: submission,
                state: &candidate,
                at: now,
                events: &events
            )
        }

        unlockBondEntitlements(state: &candidate, events: &events)
        unlockAchievements(state: &candidate, at: now, events: &events)
        state = candidate
        return events
    }

    private static func feed(
        _ itemID: ItemID,
        state: inout GameState,
        events: inout [GameEvent]
    ) throws {
        try requireRoom(.kitchen, state: state)
        guard let item = GoobyCatalog.item(id: itemID),
              case let .food(fullness) = item.kind
        else {
            throw GameRuleError.unknownItem(itemID)
        }
        let quantity = state.foodQuantity(itemID)
        guard quantity > 0 else {
            throw GameRuleError.foodNotOwned(itemID)
        }
        state.foodInventory[itemID] = quantity - 1
        state.isSleeping = false
        state.needs.fullness.adjust(by: fullness)
        state.careStatistics.meals = incremented(state.careStatistics.meals)
        events.append(.inventoryChanged(itemID: itemID, quantity: quantity - 1))
        events.append(.foodConsumed(itemID: itemID, quantity: quantity - 1))
        events.append(.fed)
        addBond(5, state: &state, events: &events)
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
        let (total, overflowed) = state.bondPoints.addingReportingOverflow(points)
        state.bondPoints = max(0, overflowed && points > 0 ? Int.max : total)
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

    private static func unlockBondEntitlements(
        state: inout GameState,
        events: inout [GameEvent]
    ) {
        if state.bondLevel >= 3 {
            unlockItem(
                GoobyCatalog.friendshipRibbon,
                duplicateCarrots: 0,
                state: &state,
                events: &events
            )
        }
    }

    private static func claimDailyReward(
        state: inout GameState,
        at now: GameInstant,
        events: inout [GameEvent]
    ) throws {
        let day = now.secondsSinceEpoch / DailyRewardSchedule.secondsPerDay
        let eligibility = DailyRewardSchedule.eligibility(
            for: state.dailyReward,
            at: now,
            cycleCount: dailyCarrotRewards.count
        )
        let step: Int
        switch eligibility {
        case let .eligible(eligibleStep):
            step = eligibleStep
        case .alreadyClaimed:
            throw GameRuleError.dailyRewardAlreadyClaimed
        case .clockRollback:
            throw GameRuleError.clockRollback
        }

        let reward = dailyCarrotRewards[step - 1]
        state.dailyReward.lastClaimedDay = day
        state.dailyReward.streakStep = step
        addCarrots(reward, state: &state, events: &events)
        events.append(.dailyRewardClaimed(step: step, carrots: reward))
        if step == dailyCarrotRewards.count {
            unlockItem(
                GoobyCatalog.moonCrown,
                duplicateCarrots: duplicateMoonCrownCarrots,
                state: &state,
                events: &events
            )
        }
    }

    private static func purchase(
        _ itemID: ItemID,
        state: inout GameState,
        events: inout [GameEvent]
    ) throws {
        guard let item = GoobyCatalog.item(id: itemID) else {
            throw GameRuleError.unknownItem(itemID)
        }
        guard item.acquisition == .shop || item.acquisition == .legacy else {
            throw GameRuleError.itemNotPurchasable(itemID)
        }
        guard state.bondLevel >= item.requiredBondLevel else {
            throw GameRuleError.itemLocked(requiredBondLevel: item.requiredBondLevel)
        }

        switch item.kind {
        case .food:
            try spendCarrots(item.price, state: &state, events: &events)
            let quantity = incremented(state.foodQuantity(itemID))
            state.foodInventory[itemID] = quantity
            events.append(.inventoryChanged(itemID: itemID, quantity: quantity))
            events.append(.purchased(itemID))

        case .cosmetic, .roomDecoration:
            if state.ownedItems.contains(itemID) {
                events.append(.purchaseAlreadyOwned(itemID))
                return
            }
            try spendCarrots(item.price, state: &state, events: &events)
            state.ownedItems.append(itemID)
            state.ownedItems.sort()
            events.append(.purchased(itemID))
        }
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

    private static func unlockItem(
        _ itemID: ItemID,
        duplicateCarrots: Int,
        state: inout GameState,
        events: inout [GameEvent]
    ) {
        if state.ownedItems.contains(itemID) {
            if duplicateCarrots > 0 {
                addCarrots(duplicateCarrots, state: &state, events: &events)
                events.append(.duplicateItemConverted(itemID, carrots: duplicateCarrots))
            }
            return
        }
        state.ownedItems.append(itemID)
        state.ownedItems.sort()
        events.append(.itemUnlocked(itemID))
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
        if kind == .gardenEcho, state.bondLevel < 2 {
            throw GameRuleError.featureLocked(requiredBondLevel: 2)
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

    private static func setMinigamePaused(
        _ paused: Bool,
        runID: MinigameRunID,
        state: inout GameState,
        at now: GameInstant,
        events: inout [GameEvent]
    ) throws {
        guard var run = state.activeMinigame else {
            throw GameRuleError.noActiveMinigame
        }
        guard run.id == runID else {
            throw GameRuleError.invalidMinigameRun
        }

        if paused {
            guard let resumedAt = run.lastResumedAt else { return }
            let elapsed = try elapsedSeconds(from: resumedAt, to: now)
            run.accumulatedActiveSeconds = addingClamped(
                run.accumulatedActiveSeconds,
                elapsed
            )
            run.lastResumedAt = nil
        } else {
            guard run.lastResumedAt == nil else { return }
            run.lastResumedAt = now
        }
        state.activeMinigame = run
        events.append(.minigamePauseChanged(runID: runID, paused: paused))
    }

    private static func cancelMinigame(
        runID: MinigameRunID,
        state: inout GameState,
        events: inout [GameEvent]
    ) throws {
        guard let run = state.activeMinigame else {
            throw GameRuleError.noActiveMinigame
        }
        guard run.id == runID else {
            throw GameRuleError.invalidMinigameRun
        }
        state.activeMinigame = nil
        events.append(.minigameCancelled(runID))
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

        var activeSeconds = run.accumulatedActiveSeconds
        if let resumedAt = run.lastResumedAt {
            let elapsed = try elapsedSeconds(from: resumedAt, to: now)
            activeSeconds = addingClamped(activeSeconds, elapsed)
        }
        guard activeSeconds <= minigameDurationSeconds else {
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
        state.bestMinigameScores[run.kind] = max(
            score,
            state.bestMinigameScores[run.kind] ?? 0
        )
        addCarrots(reward, state: &state, events: &events)
        addBond(min(score / 20, 10), state: &state, events: &events)
        events.append(.minigameFinished(runID: runID, score: score, carrots: reward))
    }

    private static func unlockAchievements(
        state: inout GameState,
        at now: GameInstant,
        events: inout [GameEvent]
    ) {
        for definition in GoobyAchievements.definitions
        where definition.progress(in: state) >= definition.target
            && !state.unlockedAchievements.contains(definition.id) {
            state.unlockedAchievements.append(definition.id)
            state.unlockedAchievements.sort()
            state.achievementUnlockDates[definition.id] = now
            addCarrots(definition.carrotReward, state: &state, events: &events)
            events.append(
                .achievementUnlocked(definition.id, carrots: definition.carrotReward)
            )
        }
    }

    private static func incremented(_ value: Int) -> Int {
        value == Int.max ? Int.max : max(0, value + 1)
    }

    private static func elapsedSeconds(
        from start: GameInstant,
        to end: GameInstant
    ) throws -> Int64 {
        guard end >= start else {
            throw GameRuleError.clockRollback
        }
        let (elapsed, overflowed) = end.secondsSinceEpoch.subtractingReportingOverflow(
            start.secondsSinceEpoch
        )
        return overflowed ? .max : elapsed
    }

    private static func addingClamped(_ lhs: Int64, _ rhs: Int64) -> Int64 {
        let (total, overflowed) = lhs.addingReportingOverflow(rhs)
        return overflowed ? .max : total
    }
}
