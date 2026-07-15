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

    func testFeedSpendsCarrotsAndCannotCreateNegativeBalance() throws {
        var state = GameState.new(now: now)
        state.currentRoom = .kitchen
        state.needs.fullness = NeedValue(400)

        let events = try GameEngine.apply(.feed, to: &state, at: now)

        XCTAssertEqual(state.carrots, 28)
        XCTAssertEqual(state.needs.fullness.value, 650)
        XCTAssertTrue(events.contains(.carrotsChanged(delta: -2, balance: 28)))

        state.carrots = 1
        XCTAssertThrowsError(try GameEngine.apply(.feed, to: &state, at: now)) { error in
            XCTAssertEqual(
                error as? GameRuleError,
                .insufficientCarrots(required: 2, available: 1)
            )
        }
        XCTAssertEqual(state.carrots, 1)
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
                .purchase(itemID: GoobyCatalog.sunnyScarf),
                to: &state,
                at: now
            )
        ) { error in
            XCTAssertEqual(error as? GameRuleError, .itemLocked(requiredBondLevel: 1))
        }

        state.bondPoints = BondProgress.thresholds[1]
        state.carrots = 34
        XCTAssertThrowsError(
            try GameEngine.apply(
                .purchase(itemID: GoobyCatalog.sunnyScarf),
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
        XCTAssertEqual(state.carrots, 0)
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

        XCTAssertEqual(state.bondLevel, 1)
        XCTAssertTrue(first.contains(.bondLevelChanged(level: 1)))
        XCTAssertTrue(first.contains(.featureUnlocked("garden-echo")))
        XCTAssertFalse(second.contains(.bondLevelChanged(level: 1)))
    }

    func testAchievementsUnlockExactlyOnce() throws {
        var state = GameState.new(now: now)
        state.currentRoom = .kitchen

        let first = try GameEngine.apply(.feed, to: &state, at: now)
        let second = try GameEngine.apply(.feed, to: &state, at: now)

        XCTAssertTrue(first.contains(.achievementUnlocked(.firstMeal)))
        XCTAssertFalse(second.contains(.achievementUnlocked(.firstMeal)))
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
        XCTAssertEqual(state.carrots, initialCarrots + awarded.reduce(0, +))
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
}
