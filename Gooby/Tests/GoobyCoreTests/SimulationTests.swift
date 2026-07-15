import GoobyCore
import XCTest

final class SimulationTests: XCTestCase {
    private let start = GameInstant(secondsSinceEpoch: 1_700_000_000)

    func testNewStateHasStableDefaultsAndBoundedNeeds() {
        let state = GameState.new(now: start)

        XCTAssertEqual(state.petID, .gooby)
        XCTAssertEqual(state.lastSimulatedAt, start)
        XCTAssertEqual(state.currentRoom, .playroom)
        XCTAssertEqual(state.carrots, 30)
        XCTAssertEqual(NeedValue(-1).value, 0)
        XCTAssertEqual(NeedValue(1_001).value, 1_000)
    }

    func testSimulationIsPartitionInvariant() {
        var oneStep = GameState.new(now: start)
        var partitioned = oneStep

        _ = GameSimulation.advance(&oneStep, to: start.adding(seconds: 10 * 60))
        for minute in 1 ... 10 {
            _ = GameSimulation.advance(
                &partitioned,
                to: start.adding(seconds: Int64(minute * 60))
            )
        }

        XCTAssertEqual(oneStep, partitioned)
    }

    func testPartialMinutesAreRetainedAcrossCalls() {
        var state = GameState.new(now: start)

        XCTAssertTrue(
            GameSimulation.advance(&state, to: start.adding(seconds: 59)).isEmpty
        )
        XCTAssertEqual(state.lastSimulatedAt, start)
        XCTAssertEqual(
            GameSimulation.advance(&state, to: start.adding(seconds: 61)),
            [.simulated(minutes: 1)]
        )
        XCTAssertEqual(state.lastSimulatedAt, start.adding(seconds: 60))
    }

    func testOfflineSimulationCapsAtEightHoursAndConsumesExcessTime() {
        var state = GameState.new(now: start)
        let returnTime = start.adding(seconds: 12 * 60 * 60)

        XCTAssertEqual(
            GameSimulation.advance(&state, to: returnTime),
            [.simulated(minutes: 480)]
        )
        XCTAssertEqual(state.lastSimulatedAt, returnTime)
        XCTAssertTrue(GameSimulation.advance(&state, to: returnTime).isEmpty)
    }

    func testOfflineNeedsStopAtSafetyFloors() {
        var state = GameState.new(now: start)
        state.needs = Needs(
            fullness: NeedValue(201),
            cleanliness: NeedValue(151),
            energy: NeedValue(101),
            fun: NeedValue(101)
        )

        _ = GameSimulation.advance(
            &state,
            to: start.adding(seconds: GameSimulation.offlineCapSeconds)
        )

        XCTAssertEqual(state.needs.fullness.value, 200)
        XCTAssertEqual(state.needs.cleanliness.value, 150)
        XCTAssertEqual(state.needs.energy.value, 100)
        XCTAssertEqual(state.needs.fun.value, 100)
    }

    func testClockRollbackDoesNotRewindOrSimulate() {
        var state = GameState.new(now: start)
        let future = start.adding(seconds: 120)
        _ = GameSimulation.advance(&state, to: future)
        let snapshot = state

        XCTAssertTrue(GameSimulation.advance(&state, to: start).isEmpty)
        XCTAssertEqual(state, snapshot)
    }

    func testSleepRestoresEnergyUsingTheSameFixedTicks() {
        var state = GameState.new(now: start)
        state.currentRoom = .bedroom
        state.needs.energy = NeedValue(500)
        _ = try? GameEngine.apply(.beginSleep, to: &state, at: start)

        _ = GameSimulation.advance(&state, to: start.adding(seconds: 10 * 60))

        XCTAssertEqual(state.needs.energy.value, 540)
        XCTAssertEqual(state.needs.fullness.value, 790)
        XCTAssertTrue(state.isSleeping)
    }
}
