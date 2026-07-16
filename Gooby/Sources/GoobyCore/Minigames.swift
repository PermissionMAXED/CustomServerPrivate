public enum MinigameKind: String, Codable, CaseIterable, Hashable, Sendable {
    case carrotCatch
    case gardenEcho
}

public enum CarrotCatchTimingMode: String, Codable, Equatable, Sendable {
    case standard
    case relaxed
}

public enum CarrotCatchRunStage: String, Codable, Equatable, Sendable {
    case instructions
    case countdown
    case playing
    case terminal
}

public struct CarrotCatchProgress: Codable, Equatable, Sendable {
    public var game: CarrotCatchGame
    public var stage: CarrotCatchRunStage
    public var timingMode: CarrotCatchTimingMode
    public var countdownRemaining: Int
    public var accumulatedPlayingSeconds: Int64
    public var lastPlayingAt: GameInstant?

    public init(
        seed: UInt64,
        game: CarrotCatchGame? = nil,
        stage: CarrotCatchRunStage = .instructions,
        timingMode: CarrotCatchTimingMode = .standard,
        countdownRemaining: Int = 3,
        accumulatedPlayingSeconds: Int64 = 0,
        lastPlayingAt: GameInstant? = nil
    ) {
        self.game = game ?? CarrotCatchGame(seed: seed)
        self.stage = stage
        self.timingMode = timingMode
        self.countdownRemaining = countdownRemaining
        self.accumulatedPlayingSeconds = accumulatedPlayingSeconds
        self.lastPlayingAt = lastPlayingAt
    }
}

public struct GardenEchoProgress: Codable, Equatable, Sendable {
    public var game: GardenEchoGame
    public var currentSequence: [Int]
    public var replayCount: Int
    public var playbackIndex: Int

    public init(
        seed: UInt64,
        game: GardenEchoGame? = nil,
        currentSequence: [Int]? = nil,
        replayCount: Int = 0,
        playbackIndex: Int = 0
    ) {
        let initialGame = game ?? GardenEchoGame(seed: seed)
        self.game = initialGame
        self.currentSequence = currentSequence ?? initialGame.sequence
        self.replayCount = replayCount
        self.playbackIndex = playbackIndex
    }
}

public enum MinigameProgress: Codable, Equatable, Sendable {
    case carrotCatch(CarrotCatchProgress)
    case gardenEcho(GardenEchoProgress)
}

public struct ActiveMinigameRun: Codable, Equatable, Sendable {
    public let id: MinigameRunID
    public let kind: MinigameKind
    public let seed: UInt64
    public let startedAt: GameInstant
    public var accumulatedActiveSeconds: Int64
    public var lastResumedAt: GameInstant?
    public var progress: MinigameProgress

    public init(
        id: MinigameRunID,
        kind: MinigameKind,
        seed: UInt64,
        startedAt: GameInstant,
        accumulatedActiveSeconds: Int64 = 0,
        lastResumedAt: GameInstant? = nil,
        progress: MinigameProgress? = nil
    ) {
        self.id = id
        self.kind = kind
        self.seed = seed
        self.startedAt = startedAt
        self.accumulatedActiveSeconds = accumulatedActiveSeconds
        self.lastResumedAt = lastResumedAt ?? startedAt
        self.progress = progress ?? Self.initialProgress(kind: kind, seed: seed)
    }

    public var isPaused: Bool { lastResumedAt == nil }

    private enum CodingKeys: String, CodingKey {
        case id
        case kind
        case seed
        case startedAt
        case accumulatedActiveSeconds
        case lastResumedAt
        case progress
    }

    public init(from decoder: Decoder) throws {
        let container = try decoder.container(keyedBy: CodingKeys.self)
        id = try container.decode(MinigameRunID.self, forKey: .id)
        kind = try container.decode(MinigameKind.self, forKey: .kind)
        seed = try container.decode(UInt64.self, forKey: .seed)
        startedAt = try container.decode(GameInstant.self, forKey: .startedAt)
        accumulatedActiveSeconds = try container.decodeIfPresent(
            Int64.self,
            forKey: .accumulatedActiveSeconds
        ) ?? 0
        if container.contains(.lastResumedAt) {
            lastResumedAt = try container.decodeIfPresent(
                GameInstant.self,
                forKey: .lastResumedAt
            )
        } else {
            lastResumedAt = startedAt
        }
        progress = try container.decodeIfPresent(
            MinigameProgress.self,
            forKey: .progress
        ) ?? Self.initialProgress(kind: kind, seed: seed)
    }

    public func encode(to encoder: Encoder) throws {
        var container = encoder.container(keyedBy: CodingKeys.self)
        try container.encode(id, forKey: .id)
        try container.encode(kind, forKey: .kind)
        try container.encode(seed, forKey: .seed)
        try container.encode(startedAt, forKey: .startedAt)
        try container.encode(accumulatedActiveSeconds, forKey: .accumulatedActiveSeconds)
        if let lastResumedAt {
            try container.encode(lastResumedAt, forKey: .lastResumedAt)
        } else {
            try container.encodeNil(forKey: .lastResumedAt)
        }
        try container.encode(progress, forKey: .progress)
    }

    private static func initialProgress(kind: MinigameKind, seed: UInt64) -> MinigameProgress {
        switch kind {
        case .carrotCatch:
            .carrotCatch(CarrotCatchProgress(seed: seed))
        case .gardenEcho:
            .gardenEcho(GardenEchoProgress(seed: seed))
        }
    }
}

public struct CarrotCatchMove: Codable, Equatable, Sendable {
    public let lane: Int?

    public init(lane: Int) {
        self.lane = lane
    }

    public init(missed: Void = ()) {
        lane = nil
    }
}

public struct CarrotCatchResult: Codable, Equatable, Sendable {
    public let score: Int
    public let carrotLanes: [Int]
    public let catches: Int
    public let misses: Int
    public let bestStreak: Int

    public init(
        score: Int,
        carrotLanes: [Int],
        catches: Int,
        misses: Int,
        bestStreak: Int
    ) {
        self.score = score
        self.carrotLanes = carrotLanes
        self.catches = catches
        self.misses = misses
        self.bestStreak = bestStreak
    }
}

public enum CarrotCatch {
    public static let laneRange = -1 ... 1
    public static let maximumMoves = 20
    public static let standardDurationSeconds = 30
    public static let pointsPerCatch = 10

    public static func carrotLanes(seed: UInt64, count: Int) -> [Int] {
        guard count > 0 else { return [] }
        var random = SplitMix64(seed: seed)
        return (0 ..< min(count, maximumMoves)).map { _ in
            random.next(upperBound: laneRange.count) + laneRange.lowerBound
        }
    }

    public static func play(seed: UInt64, moves: [CarrotCatchMove]) -> CarrotCatchResult? {
        guard moves.count <= maximumMoves,
              moves.allSatisfy({ move in
                  guard let lane = move.lane else { return true }
                  return laneRange.contains(lane)
              })
        else {
            return nil
        }

        let lanes = carrotLanes(seed: seed, count: moves.count)
        var catches = 0
        var streak = 0
        var bestStreak = 0
        for (target, move) in zip(lanes, moves) {
            if target == move.lane {
                catches += 1
                streak += 1
                bestStreak = max(bestStreak, streak)
            } else {
                streak = 0
            }
        }
        return CarrotCatchResult(
            score: catches * pointsPerCatch,
            carrotLanes: lanes,
            catches: catches,
            misses: moves.count - catches,
            bestStreak: bestStreak
        )
    }
}

public struct CarrotCatchGame: Codable, Equatable, Sendable {
    public let seed: UInt64
    public private(set) var moves: [CarrotCatchMove]
    public private(set) var isPaused: Bool
    public private(set) var isFinished: Bool

    public init(seed: UInt64) {
        self.seed = seed
        moves = []
        isPaused = false
        isFinished = false
    }

    public var currentLane: Int? {
        guard !isFinished else { return nil }
        return CarrotCatch.carrotLanes(seed: seed, count: CarrotCatch.maximumMoves)[moves.count]
    }

    public var result: CarrotCatchResult? {
        guard isFinished else { return nil }
        return CarrotCatch.play(seed: seed, moves: moves)
    }

    @discardableResult
    public mutating func catchCarrot(in lane: Int) -> Bool {
        guard !isPaused, !isFinished, CarrotCatch.laneRange.contains(lane) else {
            return false
        }
        moves.append(CarrotCatchMove(lane: lane))
        finishIfNeeded()
        return true
    }

    @discardableResult
    public mutating func missCarrot() -> Bool {
        guard !isPaused, !isFinished else { return false }
        moves.append(CarrotCatchMove())
        finishIfNeeded()
        return true
    }

    mutating func finishRemainingAsMisses() {
        guard !isFinished else { return }
        while moves.count < CarrotCatch.maximumMoves {
            moves.append(CarrotCatchMove())
        }
        isFinished = true
        isPaused = false
    }

    public mutating func pause() {
        guard !isFinished else { return }
        isPaused = true
    }

    public mutating func resume() {
        guard !isFinished else { return }
        isPaused = false
    }

    private mutating func finishIfNeeded() {
        if moves.count == CarrotCatch.maximumMoves {
            isFinished = true
            isPaused = false
        }
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
    public static let maximumMistakes = 3
    public static let pointsPerRound = 25

    public static func sequence(seed: UInt64, round: Int) -> [Int] {
        guard (1 ... maximumRounds).contains(round) else { return [] }
        var random = SplitMix64(seed: seed)
        return (0 ..< round + 2).map { _ in
            random.next(upperBound: symbolRange.count)
        }
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
        return GardenEchoResult(
            score: completed * pointsPerRound,
            completedRounds: completed
        )
    }
}

public enum GardenEchoPhase: String, Codable, Equatable, Sendable {
    case sequence
    case input
    case finished
}

public enum GardenEchoInputResult: Codable, Equatable, Sendable {
    case ignored
    case correct(nextIndex: Int)
    case roundCompleted(Int)
    case retry(mistakes: Int)
    case gameCompleted
    case gameOver
}

public struct GardenEchoGame: Codable, Equatable, Sendable {
    public let seed: UInt64
    public private(set) var round: Int
    public private(set) var phase: GardenEchoPhase
    public private(set) var input: [Int]
    public private(set) var submittedRounds: [GardenEchoRound]
    public private(set) var mistakes: Int
    public private(set) var isPaused: Bool

    public init(seed: UInt64) {
        self.seed = seed
        round = 1
        phase = .sequence
        input = []
        submittedRounds = []
        mistakes = 0
        isPaused = false
    }

    public var sequence: [Int] {
        GardenEcho.sequence(seed: seed, round: round)
    }

    public var completedRounds: Int {
        var completed = 0
        for (offset, submitted) in submittedRounds.enumerated() {
            guard submitted.symbols == GardenEcho.sequence(seed: seed, round: offset + 1) else {
                break
            }
            completed += 1
        }
        return completed
    }

    public var result: GardenEchoResult? {
        guard phase == .finished else { return nil }
        return GardenEcho.play(seed: seed, rounds: submittedRounds)
    }

    @discardableResult
    public mutating func beginInput() -> Bool {
        guard !isPaused, phase == .sequence else { return false }
        input = []
        phase = .input
        return true
    }

    @discardableResult
    public mutating func submit(symbol: Int) -> GardenEchoInputResult {
        guard !isPaused, phase == .input, GardenEcho.symbolRange.contains(symbol) else {
            return .ignored
        }
        guard sequence[input.count] == symbol else {
            mistakes += 1
            if mistakes >= GardenEcho.maximumMistakes {
                input.append(symbol)
                submittedRounds.append(GardenEchoRound(symbols: input))
                input = []
                phase = .finished
                return .gameOver
            }
            input = []
            phase = .sequence
            return .retry(mistakes: mistakes)
        }

        input.append(symbol)
        guard input.count == sequence.count else {
            return .correct(nextIndex: input.count)
        }

        submittedRounds.append(GardenEchoRound(symbols: input))
        input = []
        if round == GardenEcho.maximumRounds {
            phase = .finished
            return .gameCompleted
        }
        let completedRound = round
        round += 1
        phase = .sequence
        return .roundCompleted(completedRound)
    }

    public mutating func replaySequence() {
        guard phase != .finished else { return }
        input = []
        phase = .sequence
    }

    public mutating func pause() {
        guard phase != .finished else { return }
        isPaused = true
    }

    public mutating func resume() {
        guard phase != .finished else { return }
        isPaused = false
    }
}
