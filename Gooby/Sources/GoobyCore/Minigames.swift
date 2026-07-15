public enum MinigameKind: String, Codable, CaseIterable, Sendable {
    case carrotCatch
    case gardenEcho
}

public struct ActiveMinigameRun: Codable, Equatable, Sendable {
    public let id: MinigameRunID
    public let kind: MinigameKind
    public let seed: UInt64
    public let startedAt: GameInstant

    public init(id: MinigameRunID, kind: MinigameKind, seed: UInt64, startedAt: GameInstant) {
        self.id = id
        self.kind = kind
        self.seed = seed
        self.startedAt = startedAt
    }
}

public struct CarrotCatchMove: Codable, Equatable, Sendable {
    public let lane: Int

    public init(lane: Int) {
        self.lane = lane
    }
}

public struct CarrotCatchResult: Codable, Equatable, Sendable {
    public let score: Int
    public let carrotLanes: [Int]

    public init(score: Int, carrotLanes: [Int]) {
        self.score = score
        self.carrotLanes = carrotLanes
    }
}

public enum CarrotCatch {
    public static let laneRange = -2 ... 2
    public static let maximumMoves = 20

    public static func carrotLanes(seed: UInt64, count: Int) -> [Int] {
        guard count > 0 else { return [] }
        var random = SplitMix64(seed: seed)
        return (0 ..< min(count, maximumMoves)).map { _ in
            random.next(upperBound: laneRange.count) + laneRange.lowerBound
        }
    }

    public static func play(seed: UInt64, moves: [CarrotCatchMove]) -> CarrotCatchResult? {
        guard !moves.isEmpty,
              moves.count <= maximumMoves,
              moves.allSatisfy({ laneRange.contains($0.lane) })
        else {
            return nil
        }

        let lanes = carrotLanes(seed: seed, count: moves.count)
        let score = zip(lanes, moves).reduce(into: 0) { total, pair in
            if pair.0 == pair.1.lane {
                total += 10
            }
        }
        return CarrotCatchResult(score: score, carrotLanes: lanes)
    }
}

public struct GardenEchoRound: Codable, Equatable, Sendable {
    public let symbols: [Int]

    public init(symbols: [Int]) {
        self.symbols = symbols
    }
}

public struct GardenEchoResult: Codable, Equatable, Sendable {
    public let score: Int
    public let completedRounds: Int

    public init(score: Int, completedRounds: Int) {
        self.score = score
        self.completedRounds = completedRounds
    }
}

public enum GardenEcho {
    public static let symbolRange = 0 ..< 4
    public static let maximumRounds = 5

    public static func sequence(seed: UInt64, round: Int) -> [Int] {
        guard (1 ... maximumRounds).contains(round) else { return [] }
        var random = SplitMix64(seed: seed)
        let countThroughRound = (1 ... round).reduce(0) { $0 + $1 + 2 }
        let generated = (0 ..< countThroughRound).map { _ in
            random.next(upperBound: symbolRange.count)
        }
        return Array(generated.suffix(round + 2))
    }

    public static func play(seed: UInt64, rounds: [GardenEchoRound]) -> GardenEchoResult? {
        guard !rounds.isEmpty,
              rounds.count <= maximumRounds,
              rounds.allSatisfy({ !$0.symbols.isEmpty && $0.symbols.allSatisfy(symbolRange.contains) })
        else {
            return nil
        }

        var completed = 0
        for (offset, submitted) in rounds.enumerated() {
            let round = offset + 1
            guard submitted.symbols == sequence(seed: seed, round: round) else {
                break
            }
            completed += 1
        }
        return GardenEchoResult(score: completed * 25, completedRounds: completed)
    }
}

public enum MinigameSubmission: Codable, Equatable, Sendable {
    case carrotCatch(moves: [CarrotCatchMove])
    case gardenEcho(rounds: [GardenEchoRound])
}
