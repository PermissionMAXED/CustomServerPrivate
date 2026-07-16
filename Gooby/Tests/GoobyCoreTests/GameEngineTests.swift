import GoobyCore
import XCTest

final class GameEngineTests: XCTestCase {
    private let now = GameInstant(secondsSinceEpoch: 1_728_000_000)

    func testCareCommandsEnforceRooms() {
        var state = GameState.new(now: now)

        XCTAssertThrowsError(try GameEngine.apply(.feed, to: &state, at: now)) { error in
            XCTAssertEqual(error as? GameRuleError, .wrongRoom(required: .kitchen))
        }
        XCTAssertThrowsError(try GameEngine.apply(.wash, to: &state, at: now)) { error in
            XCTAssertEqual(error as? GameRuleError, .wrongRoom(required: .washroom))
        }
        XCTAssertNoThrow(try GameEngine.apply(.play, to: &state, at: now))
        XCTAssertThrowsError(try GameEngine.apply(.beginSleep, to: &state, at: now)) { error in
            XCTAssertEqual(error as? GameRuleError, .wrongRoom(required: .bedroom))
        }
    }

    func testFeedConsumesOwnedFoodAndCannotCreateNegativeInventory() throws {
        var state = GameState.new(now: now)
        state.currentRoom = .kitchen
        state.needs.fullness = NeedValue(400)

        let events = try GameEngine.apply(.feed, to: &state, at: now)

        XCTAssertEqual(state.carrots, 35)
        XCTAssertEqual(state.needs.fullness.value, 650)
        XCTAssertEqual(state.foodQuantity(GoobyCatalog.gardenCarrot), 2)
        XCTAssertTrue(
            events.contains(
                .foodConsumed(itemID: GoobyCatalog.gardenCarrot, quantity: 2)
            )
        )

        state.foodInventory[GoobyCatalog.gardenCarrot] = 0
        XCTAssertThrowsError(try GameEngine.apply(.feed, to: &state, at: now)) { error in
            XCTAssertEqual(
                error as? GameRuleError,
                .foodNotOwned(GoobyCatalog.gardenCarrot)
            )
        }
        XCTAssertEqual(state.foodQuantity(GoobyCatalog.gardenCarrot), 0)
    }

    func testPlayRequiresEnergy() {
        var state = GameState.new(now: now)
        state.needs.energy = NeedValue(99)

        XCTAssertThrowsError(try GameEngine.apply(.play, to: &state, at: now)) { error in
            XCTAssertEqual(
                error as? GameRuleError,
                .insufficientEnergy(required: 100, available: 99)
            )
        }
    }

    func testSleepStartsOnlyInBedroomAndMovementWakesGooby() throws {
        var state = GameState.new(now: now)
        _ = try GameEngine.apply(.move(to: .bedroom), to: &state, at: now)
        _ = try GameEngine.apply(.beginSleep, to: &state, at: now)
        XCTAssertTrue(state.isSleeping)

        _ = try GameEngine.apply(.move(to: .kitchen), to: &state, at: now)
        XCTAssertFalse(state.isSleeping)
    }

    func testPetImprovesFunAndCannotWakeSleepingGooby() throws {
        var state = GameState.new(now: now)
        state.needs.fun = NeedValue(500)

        let events = try GameEngine.apply(.pet, to: &state, at: now)

        XCTAssertEqual(state.needs.fun.value, 650)
        XCTAssertEqual(state.bondPoints, 3)
        XCTAssertTrue(events.contains(.petted))

        state.currentRoom = .bedroom
        _ = try GameEngine.apply(.beginSleep, to: &state, at: now)
        XCTAssertThrowsError(try GameEngine.apply(.pet, to: &state, at: now)) { error in
            XCTAssertEqual(error as? GameRuleError, .petIsSleeping)
        }
    }

    func testPurchaseIsIdempotentAndNeverDoubleCharges() throws {
        var state = GameState.new(now: now)

        let first = try GameEngine.apply(
            .purchase(itemID: GoobyCatalog.cozyBow),
            to: &state,
            at: now
        )
        let balance = state.carrots
        let second = try GameEngine.apply(
            .purchase(itemID: GoobyCatalog.cozyBow),
            to: &state,
            at: now
        )

        XCTAssertEqual(balance, 10)
        XCTAssertEqual(state.carrots, balance)
        XCTAssertEqual(state.ownedItems, [GoobyCatalog.cozyBow])
        XCTAssertTrue(first.contains(.purchased(GoobyCatalog.cozyBow)))
        XCTAssertTrue(second.contains(.purchaseAlreadyOwned(GoobyCatalog.cozyBow)))
    }

    func testPurchasesHonorBondUnlocksAndBalance() {
        var state = GameState.new(now: now)

        XCTAssertThrowsError(
            try GameEngine.apply(
                .purchase(itemID: GoobyCatalog.roundSpecs),
                to: &state,
                at: now
            )
        ) { error in
            XCTAssertEqual(error as? GameRuleError, .itemLocked(requiredBondLevel: 2))
        }

        state.bondPoints = BondProgress.thresholds[1]
        state.carrots = 34
        XCTAssertThrowsError(
            try GameEngine.apply(
                .purchase(itemID: GoobyCatalog.roundSpecs),
                to: &state,
                at: now
            )
        ) { error in
            XCTAssertEqual(
                error as? GameRuleError,
                .insufficientCarrots(required: 35, available: 34)
            )
        }
        XCTAssertEqual(state.carrots, 34)
        XCTAssertTrue(state.ownedItems.isEmpty)

        state.bondPoints = 0
        state.carrots = -10
        XCTAssertThrowsError(
            try GameEngine.apply(
                .purchase(itemID: GoobyCatalog.cozyBow),
                to: &state,
                at: now
            )
        ) { error in
            XCTAssertEqual(
                error as? GameRuleError,
                .insufficientCarrots(required: 20, available: 0)
            )
        }
        XCTAssertEqual(state.carrots, -10)
    }

    func testEquippingRequiresAnOwnedCosmetic() throws {
        var state = GameState.new(now: now)

        XCTAssertThrowsError(
            try GameEngine.apply(
                .equip(itemID: GoobyCatalog.cozyBow),
                to: &state,
                at: now
            )
        ) { error in
            XCTAssertEqual(error as? GameRuleError, .itemNotOwned(GoobyCatalog.cozyBow))
        }

        _ = try GameEngine.apply(
            .purchase(itemID: GoobyCatalog.cozyBow),
            to: &state,
            at: now
        )
        _ = try GameEngine.apply(
            .equip(itemID: GoobyCatalog.cozyBow),
            to: &state,
            at: now
        )
        XCTAssertEqual(state.equippedCosmetics.head, GoobyCatalog.cozyBow)
    }

    func testRoomDecorationsCannotBeEquipped() throws {
        var state = GameState.new(now: now)
        state.bondPoints = BondProgress.thresholds[4]
        state.carrots = 100
        _ = try GameEngine.apply(
            .purchase(itemID: GoobyCatalog.carrotPlanter),
            to: &state,
            at: now
        )

        XCTAssertThrowsError(
            try GameEngine.apply(
                .equip(itemID: GoobyCatalog.carrotPlanter),
                to: &state,
                at: now
            )
        ) { error in
            XCTAssertEqual(
                error as? GameRuleError,
                .itemNotEquippable(GoobyCatalog.carrotPlanter)
            )
        }
    }

    func testBondLevelCrossingEmitsLevelAndUnlockOnce() throws {
        var state = GameState.new(now: now)
        state.currentRoom = .kitchen
        state.bondPoints = 24

        let first = try GameEngine.apply(.feed, to: &state, at: now)
        let second = try GameEngine.apply(.feed, to: &state, at: now)

        XCTAssertEqual(state.bondLevel, 2)
        XCTAssertTrue(first.contains(.bondLevelChanged(level: 2)))
        XCTAssertTrue(first.contains(.featureUnlocked("garden-echo")))
        XCTAssertFalse(second.contains(.bondLevelChanged(level: 2)))
    }

    func testAchievementsUnlockExactlyOnce() throws {
        var state = GameState.new(now: now)
        state.currentRoom = .kitchen

        let first = try GameEngine.apply(.feed, to: &state, at: now)
        let second = try GameEngine.apply(.feed, to: &state, at: now)

        XCTAssertTrue(first.contains(.achievementUnlocked(.firstMeal, carrots: 5)))
        XCTAssertFalse(second.contains(.achievementUnlocked(.firstMeal, carrots: 5)))
        XCTAssertEqual(
            state.unlockedAchievements.filter { $0 == .firstMeal }.count,
            1
        )
    }

    func testSevenStepDailyRewardCyclesOnConsecutiveDays() throws {
        var state = GameState.new(now: now)
        let initialCarrots = state.carrots
        var awarded: [Int] = []

        for offset in 0 ..< 8 {
            let claimTime = now.adding(seconds: Int64(offset) * 86_400)
            let events = try GameEngine.apply(.claimDailyReward, to: &state, at: claimTime)
            for event in events {
                if case let .dailyRewardClaimed(_, carrots) = event {
                    awarded.append(carrots)
                }
            }
        }

        XCTAssertEqual(awarded, GameEngine.dailyCarrotRewards + [5])
        XCTAssertEqual(
            state.carrots,
            initialCarrots + awarded.reduce(0, +)
                + (GoobyAchievements.definition(id: .carrotCollector)?.carrotReward ?? 0)
        )
        XCTAssertTrue(state.unlockedAchievements.contains(.carrotCollector))
    }

    func testDailyRewardRejectsSameDayAndRollback() throws {
        var state = GameState.new(now: now)
        _ = try GameEngine.apply(.claimDailyReward, to: &state, at: now)

        XCTAssertThrowsError(
            try GameEngine.apply(
                .claimDailyReward,
                to: &state,
                at: now.adding(seconds: 60)
            )
        ) { error in
            XCTAssertEqual(error as? GameRuleError, .dailyRewardAlreadyClaimed)
        }
        XCTAssertThrowsError(
            try GameEngine.apply(
                .claimDailyReward,
                to: &state,
                at: now.adding(seconds: -86_400)
            )
        ) { error in
            XCTAssertEqual(error as? GameRuleError, .clockRollback)
        }
    }

    func testDailyRewardGapResetsToStepOne() throws {
        var state = GameState.new(now: now)
        _ = try GameEngine.apply(.claimDailyReward, to: &state, at: now)
        let events = try GameEngine.apply(
            .claimDailyReward,
            to: &state,
            at: now.adding(seconds: 3 * 86_400)
        )

        XCTAssertTrue(events.contains(.dailyRewardClaimed(step: 1, carrots: 5)))
    }

    func testFoodPurchaseIncrementsQuantityAndSelectedFoodIsConsumed() throws {
        var state = GameState.new(now: now)
        state.carrots = 30

        let purchase = try GameEngine.apply(
            .purchase(itemID: GoobyCatalog.berryBun),
            to: &state,
            at: now
        )
        XCTAssertEqual(state.carrots, 22)
        XCTAssertEqual(state.foodQuantity(GoobyCatalog.berryBun), 1)
        XCTAssertTrue(
            purchase.contains(
                .inventoryChanged(itemID: GoobyCatalog.berryBun, quantity: 1)
            )
        )

        state.currentRoom = .kitchen
        state.needs.fullness = NeedValue(200)
        _ = try GameEngine.apply(
            .feedFood(itemID: GoobyCatalog.berryBun),
            to: &state,
            at: now
        )
        XCTAssertEqual(state.foodQuantity(GoobyCatalog.berryBun), 0)
        XCTAssertEqual(state.needs.fullness.value, 600)
    }

    func testFailedPurchaseIsAtomicAndDuplicateCosmeticNeverCharges() throws {
        var state = GameState.new(now: now)
        state.carrots = 19
        let beforeFailure = state

        XCTAssertThrowsError(
            try GameEngine.apply(
                .purchase(itemID: GoobyCatalog.sunshineBow),
                to: &state,
                at: now
            )
        ) { error in
            XCTAssertEqual(
                error as? GameRuleError,
                .insufficientCarrots(required: 20, available: 19)
            )
        }
        XCTAssertEqual(state, beforeFailure)

        state.carrots = 40
        _ = try GameEngine.apply(
            .purchase(itemID: GoobyCatalog.sunshineBow),
            to: &state,
            at: now
        )
        let purchasedBalance = state.carrots
        let duplicate = try GameEngine.apply(
            .purchase(itemID: GoobyCatalog.sunshineBow),
            to: &state,
            at: now
        )
        XCTAssertEqual(state.carrots, purchasedBalance)
        XCTAssertEqual(
            state.ownedItems.filter { $0 == GoobyCatalog.sunshineBow }.count,
            1
        )
        XCTAssertTrue(duplicate.contains(.purchaseAlreadyOwned(GoobyCatalog.sunshineBow)))
    }

    func testEquippingReplacesSlotAndUnequipClearsOnlyThatSlot() throws {
        var state = GameState.new(now: now)
        state.ownedItems = [GoobyCatalog.cloudCap, GoobyCatalog.moonCrown, GoobyCatalog.starCape]

        _ = try GameEngine.apply(
            .equip(itemID: GoobyCatalog.cloudCap),
            to: &state,
            at: now
        )
        _ = try GameEngine.apply(
            .equip(itemID: GoobyCatalog.starCape),
            to: &state,
            at: now
        )
        _ = try GameEngine.apply(
            .equip(itemID: GoobyCatalog.moonCrown),
            to: &state,
            at: now
        )

        XCTAssertEqual(state.equippedCosmetics.head, GoobyCatalog.moonCrown)
        XCTAssertEqual(state.equippedCosmetics.body, GoobyCatalog.starCape)
        let events = try GameEngine.apply(.unequip(slot: .head), to: &state, at: now)
        XCTAssertNil(state.equippedCosmetics.head)
        XCTAssertEqual(state.equippedCosmetics.body, GoobyCatalog.starCape)
        XCTAssertTrue(events.contains(.unequipped(slot: .head)))
    }

    func testBondLevelsSpanOneThroughTenAndRibbonUnlocksOnce() throws {
        let maximumThreshold = try XCTUnwrap(BondProgress.thresholds.last)
        XCTAssertEqual(BondProgress.level(for: 0), 1)
        XCTAssertEqual(BondProgress.level(for: maximumThreshold), 10)

        var state = GameState.new(now: now)
        state.currentRoom = .kitchen
        state.bondPoints = BondProgress.thresholds[2] - 1
        let first = try GameEngine.apply(.feed, to: &state, at: now)
        let second = try GameEngine.apply(.feed, to: &state, at: now)

        XCTAssertEqual(state.bondLevel, 3)
        XCTAssertTrue(first.contains(.bondLevelChanged(level: 3)))
        XCTAssertTrue(first.contains(.itemUnlocked(GoobyCatalog.friendshipRibbon)))
        XCTAssertFalse(second.contains(.itemUnlocked(GoobyCatalog.friendshipRibbon)))
        XCTAssertEqual(
            state.ownedItems.filter { $0 == GoobyCatalog.friendshipRibbon }.count,
            1
        )
    }

    func testProgressionReconciliationUnlocksMissedEntitlementsOnlyOnce() {
        var state = GameState.new(now: now)
        state.bondPoints = BondProgress.thresholds[2]
        state.careStatistics.playSessions = 1

        let first = GameEngine.reconcileProgression(&state, at: now)
        let balance = state.carrots
        let second = GameEngine.reconcileProgression(&state, at: now.adding(seconds: 1))

        XCTAssertTrue(first.contains(.itemUnlocked(GoobyCatalog.friendshipRibbon)))
        XCTAssertTrue(first.contains(.achievementUnlocked(.playtime, carrots: 8)))
        XCTAssertTrue(second.isEmpty)
        XCTAssertEqual(state.carrots, balance)
    }

    func testDaySevenUnlocksCrownAndLaterDuplicateConvertsToCarrots() throws {
        var state = GameState.new(now: now)
        for offset in 0 ..< 7 {
            _ = try GameEngine.apply(
                .claimDailyReward,
                to: &state,
                at: now.adding(seconds: Int64(offset) * 86_400)
            )
        }
        XCTAssertTrue(state.ownedItems.contains(GoobyCatalog.moonCrown))

        for offset in 7 ..< 13 {
            _ = try GameEngine.apply(
                .claimDailyReward,
                to: &state,
                at: now.adding(seconds: Int64(offset) * 86_400)
            )
        }
        let beforeDuplicate = state.carrots
        let events = try GameEngine.apply(
            .claimDailyReward,
            to: &state,
            at: now.adding(seconds: 13 * 86_400)
        )

        XCTAssertTrue(
            events.contains(
                .duplicateItemConverted(
                    GoobyCatalog.moonCrown,
                    carrots: GameEngine.duplicateMoonCrownCarrots
                )
            )
        )
        XCTAssertEqual(
            state.carrots,
            beforeDuplicate + GameEngine.dailyCarrotRewards[6]
                + GameEngine.duplicateMoonCrownCarrots
        )
    }

    func testAchievementRewardAndUnlockDateAreGrantedExactlyOnce() throws {
        var state = GameState.new(now: now)
        state.currentRoom = .washroom
        let first = try GameEngine.apply(.wash, to: &state, at: now)
        let balance = state.carrots
        let second = try GameEngine.apply(.wash, to: &state, at: now.adding(seconds: 1))

        XCTAssertTrue(first.contains(.achievementUnlocked(.squeakyClean, carrots: 5)))
        XCTAssertFalse(second.contains(.achievementUnlocked(.squeakyClean, carrots: 5)))
        XCTAssertEqual(state.carrots, balance)
        XCTAssertEqual(state.achievementDate(.squeakyClean), now)
    }

    func testRenameAndFeedbackSettingsValidateAndPersistInState() throws {
        var state = GameState.new(now: now)
        _ = try GameEngine.apply(.renamePet("  Mochi  "), to: &state, at: now)
        _ = try GameEngine.apply(.setSoundEnabled(false), to: &state, at: now)
        _ = try GameEngine.apply(.setHapticsEnabled(false), to: &state, at: now)
        _ = try GameEngine.apply(.setReduceMotionEnabled(true), to: &state, at: now)

        XCTAssertEqual(state.preferences.petName, "Mochi")
        XCTAssertFalse(state.preferences.soundEnabled)
        XCTAssertFalse(state.preferences.hapticsEnabled)
        XCTAssertTrue(state.preferences.reduceMotionEnabled)

        let snapshot = state
        XCTAssertThrowsError(try GameEngine.apply(.renamePet("   "), to: &state, at: now)) {
            XCTAssertEqual($0 as? GameRuleError, .invalidPetName)
        }
        XCTAssertEqual(state, snapshot)
    }

    func testExtremePersistedCountersSaturateWithoutTrapping() throws {
        var state = GameState.new(now: now)
        state.currentRoom = .kitchen
        state.careStatistics.meals = .max
        state.bondPoints = .max
        state.foodInventory[GoobyCatalog.berryBun] = .max
        state.carrots = .max

        _ = try GameEngine.apply(
            .feedFood(itemID: GoobyCatalog.gardenCarrot),
            to: &state,
            at: now
        )
        _ = try GameEngine.apply(
            .purchase(itemID: GoobyCatalog.berryBun),
            to: &state,
            at: now
        )

        XCTAssertEqual(state.careStatistics.meals, .max)
        XCTAssertEqual(state.bondPoints, .max)
        XCTAssertEqual(state.foodQuantity(GoobyCatalog.berryBun), .max)
    }
}
