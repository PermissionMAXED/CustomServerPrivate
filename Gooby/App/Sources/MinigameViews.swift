import GoobyCore
import SwiftUI
import UIKit

struct ArcadeView: View {
    @Bindable var store: GameStore
    let state: GameState

    @Environment(\.dismiss) private var dismiss
    @Environment(\.dynamicTypeSize) private var dynamicTypeSize
    @State private var showsGame = false
    @State private var presentedRun: ActiveMinigameRun?

    private var currentState: GameState { store.state ?? state }

    var body: some View {
        ZStack {
            ArcadeBackground()
            ScrollView {
                LazyVStack(spacing: 16) {
                    arcadeHeader
                    if let run = currentState.activeMinigame {
                        activeRunCard(run)
                    }
                    gameCard(
                        kind: .carrotCatch,
                        title: "Carrot Catch",
                        subtitle: "Catch a seeded garden parade in three clear lanes.",
                        symbol: "carrot.fill",
                        rules: "30 seconds • Left, Center, Right • 10 points each",
                        tint: GoobyPalette.coral,
                        locked: false
                    )
                    gameCard(
                        kind: .gardenEcho,
                        title: "Garden Echo",
                        subtitle: "Repeat Leaf, Moon, Star, and Berry patterns.",
                        symbol: "music.note.list",
                        rules: "5 rounds • 3 retries • no input timer",
                        tint: GoobyPalette.sky,
                        locked: currentState.bondLevel < 2
                    )
                    playroomLink
                }
                .padding(18)
            }
            .scrollIndicators(.hidden)
        }
        .navigationTitle("Pocket Arcade")
        .navigationBarTitleDisplayMode(.inline)
        .navigationDestination(isPresented: $showsGame) {
            if let run = presentedRun {
                destination(for: run)
            } else {
                ContentUnavailableView(
                    "Run ended",
                    systemImage: "gamecontroller",
                    description: Text("Choose a game to begin another seeded run.")
                )
            }
        }
        .toolbar {
            ToolbarItem(placement: .confirmationAction) {
                Button("Home") { dismiss() }
                    .accessibilityIdentifier("arcade.home")
                    .accessibilityHint("Returns to Gooby’s home")
            }
        }
    }

    private var arcadeHeader: some View {
        VStack(spacing: 8) {
            Image(systemName: "gamecontroller.fill")
                .font(.system(size: dynamicTypeSize.isAccessibilitySize ? 42 : 56))
                .foregroundStyle(GoobyPalette.coral)
                .accessibilityHidden(true)
            Text("Play together, grow together")
                .font(.system(.title2, design: .rounded, weight: .black))
                .multilineTextAlignment(.center)
            Text("Every result is validated by Gooby’s deterministic game rules. Rewards save once.")
                .font(.subheadline)
                .foregroundStyle(.secondary)
                .multilineTextAlignment(.center)
        }
        .frame(maxWidth: .infinity)
        .arcadeCard()
    }

    private func activeRunCard(_ run: ActiveMinigameRun) -> some View {
        VStack(alignment: .leading, spacing: 10) {
            Label("Run in progress", systemImage: "pause.circle.fill")
                .font(.headline)
            Text("\(run.kind.title) is ready to continue.")
                .foregroundStyle(.secondary)
            ViewThatFits {
                HStack(spacing: 10) {
                    continueButton(run)
                    cancelButton(run)
                }
                VStack(spacing: 10) {
                    continueButton(run)
                    cancelButton(run)
                }
            }
        }
        .arcadeCard()
        .accessibilityIdentifier("arcade.active-run")
    }

    private func continueButton(_ run: ActiveMinigameRun) -> some View {
        Button("Continue Run") {
            presentedRun = run
            showsGame = true
        }
        .buttonStyle(ArcadePrimaryButtonStyle(tint: GoobyPalette.mint))
        .accessibilityIdentifier("arcade.continue")
    }

    private func cancelButton(_ run: ActiveMinigameRun) -> some View {
        Button("Cancel Run", role: .destructive) {
            Task { await store.dispatch(.cancelMinigame(runID: run.id)) }
        }
        .buttonStyle(ArcadeSecondaryButtonStyle())
        .accessibilityIdentifier("arcade.cancel")
        .accessibilityHint("Ends this run without granting a reward")
    }

    private func gameCard(
        kind: MinigameKind,
        title: String,
        subtitle: String,
        symbol: String,
        rules: String,
        tint: Color,
        locked: Bool
    ) -> some View {
        VStack(alignment: .leading, spacing: 12) {
            HStack(alignment: .top, spacing: 12) {
                Image(systemName: symbol)
                    .font(.title)
                    .foregroundStyle(tint)
                    .frame(width: 48, height: 48)
                    .background(tint.opacity(0.16), in: RoundedRectangle(cornerRadius: 15))
                    .accessibilityHidden(true)
                VStack(alignment: .leading, spacing: 4) {
                    Text(title)
                        .font(.system(.title3, design: .rounded, weight: .black))
                    Text(subtitle)
                        .font(.subheadline)
                        .foregroundStyle(.secondary)
                }
                Spacer(minLength: 0)
            }
            Label(rules, systemImage: "list.bullet")
                .font(.caption.weight(.semibold))
                .foregroundStyle(.secondary)
            Label(
                "Best: \(currentState.bestMinigameScores[kind] ?? 0)",
                systemImage: "trophy.fill"
            )
            .font(.subheadline.weight(.bold))
            .accessibilityIdentifier("arcade.best.\(kind.rawValue)")

            Button(locked ? "Unlock at Bond Level 2" : "Play \(title)") {
                start(kind)
            }
            .buttonStyle(ArcadePrimaryButtonStyle(tint: tint))
            .disabled(locked || currentState.activeMinigame != nil)
            .accessibilityIdentifier("arcade.play.\(kind.rawValue)")
            .accessibilityHint(
                locked
                    ? "Grow Gooby’s bond to level 2"
                    : "Starts a new validated \(title) run"
            )
        }
        .arcadeCard()
        .accessibilityElement(children: .contain)
    }

    private var playroomLink: some View {
        Button {
            Task {
                _ = await store.dispatch(.move(to: .playroom))
                dismiss()
            }
        } label: {
            Label("Visit Gooby’s Playroom", systemImage: "hare.fill")
                .frame(maxWidth: .infinity)
        }
        .buttonStyle(ArcadeSecondaryButtonStyle())
        .accessibilityIdentifier("arcade.playroom")
        .accessibilityHint("Returns home and moves Gooby to the playroom")
    }

    private func start(_ kind: MinigameKind) {
        Task {
            if await store.dispatch(.startMinigame(kind: kind)),
               let run = store.state?.activeMinigame {
                presentedRun = run
                showsGame = true
            }
        }
    }

    @ViewBuilder
    private func destination(for run: ActiveMinigameRun) -> some View {
        switch run.kind {
        case .carrotCatch:
            CarrotCatchView(store: store, initialRun: run)
        case .gardenEcho:
            GardenEchoView(store: store, initialRun: run)
        }
    }
}

private enum CarrotCatchStage: Hashable {
    case instructions
    case countdown
    case playing
    case result
}

private struct CarrotCatchView: View {
    @Bindable var store: GameStore
    @State private var run: ActiveMinigameRun
    @State private var game: CarrotCatchGame
    @State private var stage: CarrotCatchStage = .instructions
    @State private var countdown = 3
    @State private var remainingSeconds: Int
    @State private var relaxedTiming = false
    @State private var isSubmitting = false
    @State private var finalResult: CarrotCatchResult?
    @State private var pausedByScene = false

    @Environment(\.scenePhase) private var scenePhase
    @Environment(\.dismiss) private var dismiss
    @Environment(\.accessibilityVoiceOverEnabled) private var voiceOverEnabled
    @Environment(\.accessibilityReduceMotion) private var systemReduceMotion
    @Environment(\.dynamicTypeSize) private var dynamicTypeSize

    init(store: GameStore, initialRun: ActiveMinigameRun) {
        self.store = store
        _run = State(initialValue: initialRun)
        var initialGame = CarrotCatchGame(seed: initialRun.seed)
        if initialRun.isPaused {
            initialGame.pause()
        }
        _game = State(initialValue: initialGame)
        _remainingSeconds = State(
            initialValue: store.usesShortMinigameCountdown
                ? 5
                : CarrotCatch.standardDurationSeconds
        )
    }

    private var currentResult: CarrotCatchResult {
        CarrotCatch.play(seed: run.seed, moves: game.moves)
            ?? CarrotCatchResult(score: 0, carrotLanes: [], catches: 0, misses: 0, bestStreak: 0)
    }

    private var reduceMotion: Bool {
        systemReduceMotion || (store.state?.preferences.reduceMotionEnabled ?? false)
    }

    var body: some View {
        ZStack {
            ArcadeBackground()
            ScrollView {
                VStack(spacing: 16) {
                    scoreStrip
                    switch stage {
                    case .instructions:
                        instructions
                    case .countdown:
                        countdownView
                    case .playing:
                        gardenBoard
                        laneControls
                    case .result:
                        resultView
                    }
                }
                .padding(18)
            }
            .scrollIndicators(.hidden)
        }
        .navigationTitle("Carrot Catch")
        .navigationBarTitleDisplayMode(.inline)
        .toolbar {
            if stage == .playing {
                ToolbarItem(placement: .topBarTrailing) {
                    Button(game.isPaused ? "Resume" : "Pause") {
                        togglePause()
                    }
                    .accessibilityIdentifier("carrot.pause")
                }
            }
        }
        .task(id: stage) {
            guard stage == .playing else { return }
            while stage == .playing, remainingSeconds > 0, !Task.isCancelled {
                try? await Task.sleep(for: .seconds(1))
                guard !Task.isCancelled, stage == .playing else { return }
                if !game.isPaused, !relaxedTiming {
                    remainingSeconds -= 1
                }
            }
            if stage == .playing, remainingSeconds == 0 {
                game.finishRemainingAsMisses()
                await finish()
            }
        }
        .onChange(of: scenePhase) { _, phase in
            handleScenePhase(phase)
        }
        .onDisappear {
            guard stage != .result else { return }
            Task {
                if store.state?.activeMinigame?.id == run.id {
                    _ = await store.dispatch(.cancelMinigame(runID: run.id))
                }
            }
        }
    }

    private var scoreStrip: some View {
        ViewThatFits {
            HStack(spacing: 10) { scoreItems }
            VStack(spacing: 8) { scoreItems }
        }
        .font(.system(.subheadline, design: .rounded, weight: .bold))
        .arcadeCard()
        .accessibilityElement(children: .combine)
        .accessibilityLabel(
            "Score \(currentResult.score), streak \(currentResult.bestStreak), \(timeDescription)"
        )
    }

    @ViewBuilder
    private var scoreItems: some View {
        Label("\(currentResult.score)", systemImage: "star.fill")
            .accessibilityIdentifier("carrot.score")
        Spacer(minLength: 4)
        Label("\(currentResult.bestStreak) streak", systemImage: "flame.fill")
        Spacer(minLength: 4)
        Label(timeDescription, systemImage: relaxedTiming ? "infinity" : "timer")
            .accessibilityIdentifier("carrot.time")
    }

    private var instructions: some View {
        VStack(spacing: 16) {
            Image(systemName: "carrot.fill")
                .font(.system(size: 62))
                .foregroundStyle(GoobyPalette.coral)
                .rotationEffect(.degrees(-18))
                .shadow(color: GoobyPalette.ink.opacity(0.18), radius: 8, y: 5)
                .accessibilityHidden(true)
            Text("Catch the garden parade")
                .font(.system(.title2, design: .rounded, weight: .black))
                .multilineTextAlignment(.center)
            Text(
                "A seeded carrot appears in Left, Center, or Right. Press the matching large button. Every choice advances exactly one carrot—no floating physics or frame-time scoring."
            )
            .foregroundStyle(.secondary)
            .multilineTextAlignment(.center)
            VStack(alignment: .leading, spacing: 9) {
                Label("20 carrots, 10 points each", systemImage: "number.circle.fill")
                Label("Standard play lasts up to 30 seconds", systemImage: "timer")
                Label("Pause anytime; backgrounding pauses too", systemImage: "pause.circle")
            }
            .font(.subheadline.weight(.semibold))
            .frame(maxWidth: .infinity, alignment: .leading)

            Toggle("Relaxed timing", isOn: $relaxedTiming)
                .accessibilityIdentifier("carrot.relaxed")
                .accessibilityHint("Stops the countdown without changing score or rewards")
            Text("VoiceOver starts with relaxed timing. Rewards and all 20 carrots stay identical.")
                .font(.caption)
                .foregroundStyle(.secondary)

            Button("Start Carrot Catch") {
                beginCountdown()
            }
            .buttonStyle(ArcadePrimaryButtonStyle(tint: GoobyPalette.coral))
            .accessibilityIdentifier("carrot.start")
        }
        .arcadeCard()
        .onAppear {
            if voiceOverEnabled || store.usesShortMinigameCountdown {
                relaxedTiming = true
            }
        }
    }

    private var countdownView: some View {
        VStack(spacing: 12) {
            Text("\(countdown)")
                .font(.system(size: dynamicTypeSize.isAccessibilitySize ? 76 : 108, weight: .black))
                .foregroundStyle(GoobyPalette.coral)
                .contentTransition(.numericText())
                .accessibilityIdentifier("carrot.countdown")
            Text("Basket ready!")
                .font(.system(.title2, design: .rounded, weight: .black))
        }
        .frame(maxWidth: .infinity, minHeight: 320)
        .arcadeCard()
    }

    private var gardenBoard: some View {
        VStack(spacing: 14) {
            Text(game.isPaused ? "Garden paused" : "Carrot \(game.moves.count + 1) of 20")
                .font(.headline)
            ZStack(alignment: .bottom) {
                RoundedRectangle(cornerRadius: 28)
                    .fill(
                        LinearGradient(
                            colors: [GoobyPalette.sky.opacity(0.55), GoobyPalette.mint.opacity(0.42)],
                            startPoint: .top,
                            endPoint: .bottom
                        )
                    )
                HStack(alignment: .bottom, spacing: 0) {
                    ForEach(Array(CarrotCatch.laneRange), id: \.self) { lane in
                        laneColumn(lane)
                    }
                }
                .padding(14)
                if game.isPaused {
                    Label("Paused", systemImage: "pause.fill")
                        .font(.title2.bold())
                        .padding(18)
                        .background(.regularMaterial, in: Capsule())
                }
            }
            .frame(height: dynamicTypeSize.isAccessibilitySize ? 260 : 310)
            .shadow(color: GoobyPalette.ink.opacity(0.14), radius: 14, y: 8)
            .accessibilityElement(children: .ignore)
            .accessibilityLabel("Carrot garden")
            .accessibilityValue(boardStatus)
            .accessibilityIdentifier("carrot.target")

            Label(
                currentResult.catches == 0
                    ? "Gooby is cheering beside the basket."
                    : "Gooby cheers for \(currentResult.catches) catches!",
                systemImage: "hare.fill"
            )
            .font(.subheadline.weight(.bold))
        }
    }

    private func laneColumn(_ lane: Int) -> some View {
        VStack(spacing: 8) {
            if game.currentLane == lane {
                Image(systemName: "carrot.fill")
                    .font(.system(size: 48, weight: .bold))
                    .foregroundStyle(GoobyPalette.coral)
                    .rotation3DEffect(
                        .degrees(reduceMotion ? 0 : -12),
                        axis: (x: 0, y: 1, z: 0)
                    )
                    .shadow(color: .black.opacity(0.20), radius: 5, y: 5)
                    .accessibilityHidden(true)
            } else {
                Spacer().frame(height: 48)
            }
            Image(systemName: lane == 0 ? "basket.fill" : "leaf.fill")
                .font(.title2)
                .foregroundStyle(lane == 0 ? GoobyPalette.gold : GoobyPalette.mint)
                .accessibilityHidden(true)
            Text(laneName(lane))
                .font(.caption.weight(.black))
        }
        .frame(maxWidth: .infinity, maxHeight: .infinity, alignment: .bottom)
        .background(
            lane == game.currentLane ? Color.white.opacity(0.30) : Color.clear,
            in: RoundedRectangle(cornerRadius: 18)
        )
    }

    private var laneControls: some View {
        ViewThatFits {
            HStack(spacing: 10) { laneButtons }
            VStack(spacing: 10) { laneButtons }
        }
        .disabled(game.isPaused || isSubmitting)
        .accessibilityElement(children: .contain)
    }

    @ViewBuilder
    private var laneButtons: some View {
        ForEach(Array(CarrotCatch.laneRange), id: \.self) { lane in
            Button {
                choose(lane)
            } label: {
                VStack(spacing: 5) {
                    Image(systemName: laneSymbol(lane))
                    Text(laneName(lane))
                }
                .frame(maxWidth: .infinity)
            }
            .buttonStyle(ArcadePrimaryButtonStyle(tint: laneTint(lane)))
            .accessibilityLabel("\(laneName(lane)) lane, \(laneNumber(lane))")
            .accessibilityHint("Moves the basket and catches or misses the current carrot")
            .accessibilityIdentifier("carrot.lane.\(laneName(lane).lowercased())")
        }
    }

    private var resultView: some View {
        let result = finalResult ?? currentResult
        return VStack(spacing: 16) {
            Image(systemName: result.catches == CarrotCatch.maximumMoves ? "trophy.fill" : "hare.fill")
                .font(.system(size: 64))
                .foregroundStyle(GoobyPalette.gold)
                .accessibilityHidden(true)
            Text(result.catches == CarrotCatch.maximumMoves ? "Perfect harvest!" : "Garden gathered!")
                .font(.system(.title, design: .rounded, weight: .black))
                .multilineTextAlignment(.center)
            Text("\(result.score) points")
                .font(.system(.largeTitle, design: .rounded, weight: .black))
                .accessibilityIdentifier("carrot.result.score")
            Text(
                "\(result.catches) catches • \(result.misses) misses • best streak \(result.bestStreak)"
            )
            .font(.headline)
            .multilineTextAlignment(.center)
            Label(
                "+\(result.score / 10) carrots • +\(min(result.score / 20, 10)) bond",
                systemImage: "gift.fill"
            )
            .font(.headline)
            .foregroundStyle(GoobyPalette.ink)
            .accessibilityIdentifier("carrot.result.reward")
            Text("Best score: \(store.state?.bestMinigameScores[.carrotCatch] ?? result.score)")
                .font(.subheadline.weight(.bold))
                .accessibilityIdentifier("carrot.result.best")
            Button("Play Again") {
                restart()
            }
            .buttonStyle(ArcadePrimaryButtonStyle(tint: GoobyPalette.coral))
            .accessibilityIdentifier("carrot.restart")
            Button("Back to Arcade") { dismiss() }
                .buttonStyle(ArcadeSecondaryButtonStyle())
                .accessibilityIdentifier("carrot.done")
        }
        .arcadeCard()
        .accessibilityElement(children: .contain)
    }

    private var timeDescription: String {
        relaxedTiming ? "Relaxed" : "\(remainingSeconds) seconds"
    }

    private var boardStatus: String {
        guard let lane = game.currentLane else { return "All carrots completed" }
        return "Carrot \(game.moves.count + 1) of 20, \(laneName(lane)) lane"
    }

    private func beginCountdown() {
        stage = .countdown
        Task {
            let start = store.usesShortMinigameCountdown ? 1 : 3
            countdown = start
            for value in stride(from: start, through: 1, by: -1) {
                countdown = value
                try? await Task.sleep(for: .seconds(1))
                guard !Task.isCancelled, stage == .countdown else { return }
            }
            if run.isPaused {
                _ = await store.dispatch(.resumeMinigame(runID: run.id))
                game.resume()
            }
            stage = .playing
            UIAccessibility.post(
                notification: .announcement,
                argument: "Carrot Catch started. \(boardStatus)"
            )
        }
    }

    private func choose(_ lane: Int) {
        guard let target = game.currentLane else { return }
        let caught = target == lane
        guard game.catchCarrot(in: lane) else { return }
        store.playMinigameFeedback(.carrotCatch(caught: caught))
        UIAccessibility.post(
            notification: .announcement,
            argument: caught ? "Caught! \(boardStatus)" : "Missed. \(boardStatus)"
        )
        if store.usesCondensedDemoMinigames, game.moves.count == 3 {
            game.finishRemainingAsMisses()
        }
        if game.isFinished {
            Task { await finish() }
        }
    }

    private func togglePause() {
        Task {
            if game.isPaused {
                if await store.dispatch(.resumeMinigame(runID: run.id)) {
                    game.resume()
                }
            } else if await store.dispatch(.pauseMinigame(runID: run.id)) {
                game.pause()
            }
        }
    }

    private func finish() async {
        guard !isSubmitting, let result = game.result else { return }
        isSubmitting = true
        if await store.dispatch(
            .finishMinigame(runID: run.id, submission: .carrotCatch(moves: game.moves))
        ) {
            finalResult = result
            stage = .result
            UIAccessibility.post(
                notification: .screenChanged,
                argument: "Carrot Catch complete, \(result.score) points"
            )
        }
        isSubmitting = false
    }

    private func restart() {
        Task {
            guard await store.dispatch(.startMinigame(kind: .carrotCatch)),
                  let next = store.state?.activeMinigame
            else { return }
            run = next
            game = CarrotCatchGame(seed: next.seed)
            remainingSeconds = store.usesShortMinigameCountdown
                ? 5
                : CarrotCatch.standardDurationSeconds
            finalResult = nil
            stage = .instructions
        }
    }

    private func handleScenePhase(_ phase: ScenePhase) {
        switch phase {
        case .inactive, .background:
            guard stage == .playing, !game.isPaused else { return }
            pausedByScene = true
            game.pause()
        case .active:
            guard pausedByScene else { return }
            pausedByScene = false
            Task {
                if await store.resumeActiveMinigame() {
                    game.resume()
                }
            }
        default:
            break
        }
    }

    private func laneName(_ lane: Int) -> String {
        switch lane {
        case -1: "Left"
        case 0: "Center"
        default: "Right"
        }
    }

    private func laneNumber(_ lane: Int) -> String {
        "\(lane + 2) of 3"
    }

    private func laneSymbol(_ lane: Int) -> String {
        switch lane {
        case -1: "arrow.left.circle.fill"
        case 0: "circle.circle.fill"
        default: "arrow.right.circle.fill"
        }
    }

    private func laneTint(_ lane: Int) -> Color {
        switch lane {
        case -1: GoobyPalette.sky
        case 0: GoobyPalette.mint
        default: GoobyPalette.coral
        }
    }
}

private struct EchoPad: Identifiable {
    let id: Int
    let name: String
    let number: Int
    let symbol: String
    let pitch: String
    let tint: Color

    static let all = [
        EchoPad(id: 0, name: "Leaf", number: 1, symbol: "leaf.fill", pitch: "low G", tint: GoobyPalette.mint),
        EchoPad(id: 1, name: "Moon", number: 2, symbol: "moon.fill", pitch: "middle C", tint: GoobyPalette.sky),
        EchoPad(id: 2, name: "Star", number: 3, symbol: "star.fill", pitch: "E", tint: GoobyPalette.gold),
        EchoPad(id: 3, name: "Berry", number: 4, symbol: "circle.grid.cross.fill", pitch: "high G", tint: GoobyPalette.coral),
    ]
}

private struct GardenEchoView: View {
    @Bindable var store: GameStore
    @State private var run: ActiveMinigameRun
    @State private var game: GardenEchoGame
    @State private var showsInstructions = true
    @State private var highlightedSymbol: Int?
    @State private var playbackGeneration = 0
    @State private var isSubmitting = false
    @State private var finalResult: GardenEchoResult?
    @State private var status = "Listen to the garden, then echo it."
    @State private var pausedByScene = false

    @Environment(\.scenePhase) private var scenePhase
    @Environment(\.dismiss) private var dismiss
    @Environment(\.accessibilityReduceMotion) private var systemReduceMotion
    @Environment(\.dynamicTypeSize) private var dynamicTypeSize

    init(store: GameStore, initialRun: ActiveMinigameRun) {
        self.store = store
        _run = State(initialValue: initialRun)
        var initialGame = GardenEchoGame(seed: initialRun.seed)
        if initialRun.isPaused {
            initialGame.pause()
        }
        _game = State(initialValue: initialGame)
    }

    private var reduceMotion: Bool {
        systemReduceMotion || (store.state?.preferences.reduceMotionEnabled ?? false)
    }

    private var columns: [GridItem] {
        dynamicTypeSize.isAccessibilitySize
            ? [GridItem(.flexible())]
            : [GridItem(.flexible()), GridItem(.flexible())]
    }

    var body: some View {
        ZStack {
            ArcadeBackground()
            ScrollView {
                VStack(spacing: 16) {
                    echoProgress
                    if showsInstructions {
                        instructions
                    } else if game.phase == .finished || finalResult != nil {
                        resultView
                    } else {
                        echoGarden
                        padGrid
                        echoActions
                    }
                }
                .padding(18)
            }
            .scrollIndicators(.hidden)
        }
        .navigationTitle("Garden Echo")
        .navigationBarTitleDisplayMode(.inline)
        .onChange(of: scenePhase) { _, phase in
            handleScenePhase(phase)
        }
        .onDisappear {
            playbackGeneration += 1
            guard game.phase != .finished, finalResult == nil else { return }
            Task {
                if store.state?.activeMinigame?.id == run.id {
                    _ = await store.dispatch(.cancelMinigame(runID: run.id))
                }
            }
        }
    }

    private var echoProgress: some View {
        ViewThatFits {
            HStack(spacing: 12) { progressItems }
            VStack(spacing: 8) { progressItems }
        }
        .font(.system(.subheadline, design: .rounded, weight: .bold))
        .arcadeCard()
        .accessibilityElement(children: .combine)
        .accessibilityLabel(
            "Round \(game.round) of \(GardenEcho.maximumRounds), \(game.mistakes) of 3 mistakes"
        )
    }

    @ViewBuilder
    private var progressItems: some View {
        Label("Round \(game.round)/5", systemImage: "music.note.list")
            .accessibilityIdentifier("echo.round")
        Spacer(minLength: 4)
        Label("\(game.completedRounds * 25) points", systemImage: "star.fill")
            .accessibilityIdentifier("echo.score")
        Spacer(minLength: 4)
        Label("\(game.mistakes)/3 mistakes", systemImage: "heart.fill")
    }

    private var instructions: some View {
        VStack(spacing: 16) {
            Image(systemName: "music.quarternote.3")
                .font(.system(size: 60))
                .foregroundStyle(GoobyPalette.sky)
                .accessibilityHidden(true)
            Text("Listen, remember, echo")
                .font(.system(.title2, design: .rounded, weight: .black))
                .multilineTextAlignment(.center)
            Text(
                "Each round grows from three to seven seeded pads. Every pad has a symbol, number, name, pitch, and haptic—color is never the only clue."
            )
            .foregroundStyle(.secondary)
            .multilineTextAlignment(.center)
            VStack(alignment: .leading, spacing: 9) {
                Label("No input timer", systemImage: "infinity")
                Label("Replay the sequence whenever needed", systemImage: "arrow.counterclockwise")
                Label("Three mistakes end the run; retries keep the same sequence", systemImage: "heart.fill")
            }
            .font(.subheadline.weight(.semibold))
            .frame(maxWidth: .infinity, alignment: .leading)
            Button("Start Garden Echo") {
                showsInstructions = false
                startPlayback()
            }
            .buttonStyle(ArcadePrimaryButtonStyle(tint: GoobyPalette.sky))
            .accessibilityIdentifier("echo.start")
        }
        .arcadeCard()
    }

    private var echoGarden: some View {
        VStack(spacing: 12) {
            Label(
                game.isPaused ? "Garden paused" : status,
                systemImage: game.phase == .input ? "hand.tap.fill" : "ear.fill"
            )
            .font(.headline)
            .multilineTextAlignment(.center)
            .accessibilityIdentifier("echo.status")
            .accessibilityAddTraits(.updatesFrequently)

            ZStack {
                RoundedRectangle(cornerRadius: 28)
                    .fill(
                        LinearGradient(
                            colors: [GoobyPalette.sky.opacity(0.46), GoobyPalette.mint.opacity(0.38)],
                            startPoint: .topLeading,
                            endPoint: .bottomTrailing
                        )
                    )
                HStack(spacing: 18) {
                    Image(systemName: "hare.fill")
                        .font(.system(size: 60))
                        .foregroundStyle(GoobyPalette.apricot)
                        .shadow(color: .black.opacity(0.18), radius: 7, y: 5)
                    Image(systemName: highlightedSymbol.map { EchoPad.all[$0].symbol } ?? "sparkles")
                        .font(.system(size: 68))
                        .foregroundStyle(
                            highlightedSymbol.map { EchoPad.all[$0].tint } ?? GoobyPalette.gold
                        )
                        .scaleEffect(highlightedSymbol == nil || reduceMotion ? 1 : 1.12)
                }
            }
            .frame(height: dynamicTypeSize.isAccessibilitySize ? 180 : 220)
            .accessibilityElement(children: .ignore)
            .accessibilityLabel("Gooby’s echo garden")
            .accessibilityValue(accessibleSequenceStatus)
        }
    }

    private var padGrid: some View {
        LazyVGrid(columns: columns, spacing: 12) {
            ForEach(EchoPad.all) { pad in
                Button {
                    press(pad)
                } label: {
                    HStack(spacing: 10) {
                        Image(systemName: pad.symbol)
                            .font(.title2)
                        VStack(alignment: .leading, spacing: 2) {
                            Text("\(pad.number) • \(pad.name)")
                                .font(.headline)
                            Text("Pitch \(pad.pitch)")
                                .font(.caption)
                                .opacity(0.85)
                        }
                        Spacer(minLength: 0)
                    }
                    .frame(maxWidth: .infinity, minHeight: 64)
                }
                .buttonStyle(
                    EchoPadButtonStyle(
                        tint: pad.tint,
                        highlighted: highlightedSymbol == pad.id
                    )
                )
                .disabled(game.phase != .input || game.isPaused || isSubmitting)
                .accessibilityLabel("Pad \(pad.number), \(pad.name)")
                .accessibilityValue("Pitch \(pad.pitch)")
                .accessibilityHint("Enters this symbol in the sequence")
                .accessibilityIdentifier("echo.pad.\(pad.name.lowercased())")
            }
        }
        .accessibilityElement(children: .contain)
    }

    private var echoActions: some View {
        ViewThatFits {
            HStack(spacing: 10) { actionButtons }
            VStack(spacing: 10) { actionButtons }
        }
    }

    @ViewBuilder
    private var actionButtons: some View {
        Button("Replay Sequence") {
            startPlayback()
        }
        .buttonStyle(ArcadeSecondaryButtonStyle())
        .disabled(game.isPaused || isSubmitting)
        .accessibilityIdentifier("echo.replay")
        .accessibilityHint("Announces and plays the current sequence again with no penalty")

        Button(game.isPaused ? "Resume" : "Pause") {
            togglePause()
        }
        .buttonStyle(ArcadeSecondaryButtonStyle())
        .accessibilityIdentifier("echo.pause")
    }

    private var resultView: some View {
        let result = finalResult
            ?? GardenEchoResult(score: game.completedRounds * 25, completedRounds: game.completedRounds)
        return VStack(spacing: 16) {
            Image(systemName: result.completedRounds == GardenEcho.maximumRounds ? "trophy.fill" : "music.note")
                .font(.system(size: 64))
                .foregroundStyle(GoobyPalette.gold)
                .accessibilityHidden(true)
            Text(result.completedRounds == GardenEcho.maximumRounds ? "Garden in harmony!" : "A lovely echo!")
                .font(.system(.title, design: .rounded, weight: .black))
                .multilineTextAlignment(.center)
            Text("\(result.score) points")
                .font(.system(.largeTitle, design: .rounded, weight: .black))
                .accessibilityIdentifier("echo.result.score")
            Text("\(result.completedRounds) of 5 rounds • \(game.mistakes) mistakes")
                .font(.headline)
            Label(
                "+\(result.score / 10) carrots • +\(min(result.score / 20, 10)) bond",
                systemImage: "gift.fill"
            )
            .font(.headline)
            .accessibilityIdentifier("echo.result.reward")
            Text("Best score: \(store.state?.bestMinigameScores[.gardenEcho] ?? result.score)")
                .font(.subheadline.weight(.bold))
                .accessibilityIdentifier("echo.result.best")
            Button("Play Again") {
                restart()
            }
            .buttonStyle(ArcadePrimaryButtonStyle(tint: GoobyPalette.sky))
            .accessibilityIdentifier("echo.restart")
            Button("Back to Arcade") { dismiss() }
                .buttonStyle(ArcadeSecondaryButtonStyle())
                .accessibilityIdentifier("echo.done")
        }
        .arcadeCard()
    }

    private var accessibleSequenceStatus: String {
        let names = game.sequence.map { padDescription($0) }.joined(separator: ", ")
        return switch game.phase {
        case .sequence: "Sequence playing: \(names)"
        case .input: "Input \(game.input.count + 1) of \(game.sequence.count)"
        case .finished: "Run complete"
        }
    }

    private func startPlayback() {
        guard !game.isPaused, game.phase != .finished else { return }
        playbackGeneration += 1
        let generation = playbackGeneration
        game.replaySequence()
        highlightedSymbol = nil
        status = "Listen to \(game.sequence.count) garden notes."
        let spoken = game.sequence.map { padDescription($0) }.joined(separator: ", ")
        UIAccessibility.post(
            notification: .announcement,
            argument: "Round \(game.round) sequence: \(spoken)"
        )
        Task { await playSequence(generation: generation) }
    }

    private func playSequence(generation: Int) async {
        let delay = store.usesShortMinigameCountdown ? 0.08 : 0.55
        for symbol in game.sequence {
            guard generation == playbackGeneration, !game.isPaused else { return }
            highlightedSymbol = symbol
            store.playMinigameFeedback(.gardenEcho(symbol: symbol))
            try? await Task.sleep(for: .seconds(delay))
            guard generation == playbackGeneration else { return }
            highlightedSymbol = nil
            try? await Task.sleep(for: .seconds(delay / 2))
        }
        guard generation == playbackGeneration, game.beginInput() else { return }
        status = "Your turn • input 1 of \(game.sequence.count)"
        UIAccessibility.post(notification: .announcement, argument: "Your turn")
    }

    private func press(_ pad: EchoPad) {
        store.playMinigameFeedback(.gardenEcho(symbol: pad.id))
        let outcome = game.submit(symbol: pad.id)
        switch outcome {
        case .ignored:
            return
        case let .correct(nextIndex):
            status = "Correct • input \(nextIndex + 1) of \(game.sequence.count)"
        case let .roundCompleted(round):
            status = "Round \(round) complete!"
            UIAccessibility.post(notification: .announcement, argument: status)
            if store.usesCondensedDemoMinigames {
                Task { await finish() }
            } else {
                Task {
                    try? await Task.sleep(
                        for: .seconds(store.usesShortMinigameCountdown ? 0.08 : 0.65)
                    )
                    startPlayback()
                }
            }
        case .gameCompleted, .gameOver:
            Task { await finish() }
        case let .retry(mistakes):
            status = "Try that round again • mistake \(mistakes) of 3"
            UIAccessibility.post(notification: .announcement, argument: status)
            Task {
                try? await Task.sleep(for: .seconds(store.usesShortMinigameCountdown ? 0.08 : 0.65))
                startPlayback()
            }
        }
    }

    private func togglePause() {
        playbackGeneration += 1
        Task {
            if game.isPaused {
                if await store.dispatch(.resumeMinigame(runID: run.id)) {
                    game.resume()
                    startPlayback()
                }
            } else if await store.dispatch(.pauseMinigame(runID: run.id)) {
                game.pause()
                highlightedSymbol = nil
                status = "Paused safely"
            }
        }
    }

    private func finish() async {
        let result = game.result
            ?? (store.usesCondensedDemoMinigames
                ? GardenEcho.play(seed: run.seed, rounds: game.submittedRounds)
                : nil)
        guard !isSubmitting, let result else { return }
        isSubmitting = true
        if await store.dispatch(
            .finishMinigame(
                runID: run.id,
                submission: .gardenEcho(rounds: game.submittedRounds)
            )
        ) {
            finalResult = result
            UIAccessibility.post(
                notification: .screenChanged,
                argument: "Garden Echo complete, \(result.score) points"
            )
        }
        isSubmitting = false
    }

    private func restart() {
        Task {
            guard await store.dispatch(.startMinigame(kind: .gardenEcho)),
                  let next = store.state?.activeMinigame
            else { return }
            run = next
            game = GardenEchoGame(seed: next.seed)
            finalResult = nil
            showsInstructions = true
            status = "Listen to the garden, then echo it."
        }
    }

    private func handleScenePhase(_ phase: ScenePhase) {
        switch phase {
        case .inactive, .background:
            guard game.phase != .finished, !game.isPaused else { return }
            pausedByScene = true
            playbackGeneration += 1
            game.pause()
        case .active:
            guard pausedByScene else { return }
            pausedByScene = false
            Task {
                if await store.resumeActiveMinigame() {
                    game.resume()
                    if !showsInstructions {
                        startPlayback()
                    }
                }
            }
        default:
            break
        }
    }

    private func padDescription(_ symbol: Int) -> String {
        let pad = EchoPad.all[symbol]
        return "\(pad.number) \(pad.name)"
    }
}

private extension MinigameKind {
    var title: String {
        switch self {
        case .carrotCatch: "Carrot Catch"
        case .gardenEcho: "Garden Echo"
        }
    }
}

private struct ArcadeBackground: View {
    var body: some View {
        LinearGradient(
            colors: [
                GoobyPalette.cream,
                GoobyPalette.mint.opacity(0.24),
                GoobyPalette.sky.opacity(0.22),
            ],
            startPoint: .topLeading,
            endPoint: .bottomTrailing
        )
        .ignoresSafeArea()
    }
}

private struct ArcadeCardModifier: ViewModifier {
    @Environment(\.accessibilityReduceTransparency) private var reduceTransparency

    func body(content: Content) -> some View {
        content
            .padding(16)
            .frame(maxWidth: .infinity)
            .background(
                reduceTransparency ? GoobyPalette.cream : Color.white.opacity(0.72),
                in: RoundedRectangle(cornerRadius: 22)
            )
            .overlay {
                RoundedRectangle(cornerRadius: 22)
                    .stroke(GoobyPalette.ink.opacity(0.12), lineWidth: 1)
            }
    }
}

private struct ArcadePrimaryButtonStyle: ButtonStyle {
    let tint: Color
    @Environment(\.accessibilityReduceMotion) private var reduceMotion

    func makeBody(configuration: Configuration) -> some View {
        configuration.label
            .font(.system(.headline, design: .rounded, weight: .bold))
            .foregroundStyle(.white)
            .padding(.horizontal, 14)
            .frame(maxWidth: .infinity, minHeight: 54)
            .background(
                tint.opacity(configuration.isPressed ? 0.72 : 1),
                in: RoundedRectangle(cornerRadius: 17)
            )
            .scaleEffect(configuration.isPressed && !reduceMotion ? 0.98 : 1)
    }
}

private struct ArcadeSecondaryButtonStyle: ButtonStyle {
    @Environment(\.accessibilityReduceTransparency) private var reduceTransparency

    func makeBody(configuration: Configuration) -> some View {
        configuration.label
            .font(.system(.headline, design: .rounded, weight: .bold))
            .foregroundStyle(GoobyPalette.ink)
            .padding(.horizontal, 14)
            .frame(maxWidth: .infinity, minHeight: 54)
            .background(
                reduceTransparency
                    ? GoobyPalette.cream
                    : Color.white.opacity(configuration.isPressed ? 0.50 : 0.82),
                in: RoundedRectangle(cornerRadius: 17)
            )
            .overlay {
                RoundedRectangle(cornerRadius: 17)
                    .stroke(GoobyPalette.ink.opacity(0.14), lineWidth: 1)
            }
    }
}

private struct EchoPadButtonStyle: ButtonStyle {
    let tint: Color
    let highlighted: Bool

    func makeBody(configuration: Configuration) -> some View {
        configuration.label
            .foregroundStyle(GoobyPalette.ink)
            .padding(.horizontal, 14)
            .background(
                tint.opacity(highlighted || configuration.isPressed ? 0.62 : 0.24),
                in: RoundedRectangle(cornerRadius: 18)
            )
            .overlay {
                RoundedRectangle(cornerRadius: 18)
                    .stroke(tint, lineWidth: highlighted ? 4 : 2)
            }
    }
}

private extension View {
    func arcadeCard() -> some View {
        modifier(ArcadeCardModifier())
    }
}
