import GoobyCore
import SwiftUI

enum GoobyBrand {
    static let name = "Gooby"
    static let subtitle = "A little world for a big-hearted bunny."
}

enum GoobyPalette {
    static let ink = Color(red: 0.24, green: 0.14, blue: 0.15)
    static let cream = Color(red: 0.99, green: 0.93, blue: 0.80)
    static let apricot = Color(red: 0.91, green: 0.65, blue: 0.43)
    static let coral = Color(red: 0.88, green: 0.39, blue: 0.36)
    static let mint = Color(red: 0.38, green: 0.66, blue: 0.56)
    static let sky = Color(red: 0.39, green: 0.58, blue: 0.76)
    static let gold = Color(red: 0.92, green: 0.66, blue: 0.24)
}

struct AppRootView: View {
    @Bindable var store: GameStore
    @State private var selectedTab = 0

    var body: some View {
        Group {
            switch store.phase {
            case .idle, .loading:
                LoadingView()
            case .failed:
                LoadErrorView(message: store.errorMessage ?? "Gooby could not wake up.") {
                    Task { await store.start() }
                }
            case .ready:
                if let state = store.state {
                    MainShellView(
                        store: store,
                        state: state,
                        selectedTab: $selectedTab
                    )
                } else {
                    LoadingView()
                }
            }
        }
        .fullScreenCover(isPresented: $store.showsWelcome) {
            WelcomeView(onContinue: store.dismissWelcome)
        }
        .alert(
            "A little snag",
            isPresented: Binding(
                get: { store.phase == .ready && store.errorMessage != nil },
                set: { showing in
                    if !showing { store.clearError() }
                }
            )
        ) {
            Button("OK", role: .cancel) { store.clearError() }
        } message: {
            Text(store.errorMessage ?? "")
        }
    }
}

private struct LoadingView: View {
    var body: some View {
        ZStack {
            GoobyBackground()
            VStack(spacing: 16) {
                ProgressView()
                    .controlSize(.large)
                    .tint(GoobyPalette.coral)
                Text("Waking Gooby…")
                    .font(.system(.headline, design: .rounded, weight: .bold))
                    .foregroundStyle(GoobyPalette.ink)
            }
        }
        .accessibilityElement(children: .combine)
        .accessibilityLabel("Waking Gooby")
    }
}

private struct LoadErrorView: View {
    let message: String
    let retry: () -> Void

    var body: some View {
        ZStack {
            GoobyBackground()
            ContentUnavailableView {
                Label("Gooby needs a moment", systemImage: "externaldrive.badge.exclamationmark")
            } description: {
                Text(message)
            } actions: {
                Button("Try Again", action: retry)
                    .buttonStyle(GoobyPrimaryButtonStyle())
                    .accessibilityHint("Attempts to load Gooby’s saved care state again")
            }
            .padding()
        }
    }
}

private struct WelcomeView: View {
    let onContinue: () -> Void

    var body: some View {
        ZStack {
            GoobyBackground()
            VStack(spacing: 24) {
                Spacer()
                Image(systemName: "hare.fill")
                    .font(.system(size: 88, weight: .bold))
                    .foregroundStyle(GoobyPalette.apricot)
                    .padding(28)
                    .background(.thinMaterial, in: Circle())
                    .accessibilityHidden(true)
                VStack(spacing: 10) {
                    Text("Meet Gooby")
                        .font(.system(.largeTitle, design: .rounded, weight: .black))
                    Text("A soft-hearted rabbit who loves snacks, splashes, naps, and time with you.")
                        .font(.system(.body, design: .rounded, weight: .medium))
                        .multilineTextAlignment(.center)
                        .foregroundStyle(.secondary)
                }
                Spacer()
                Button("Start caring", action: onContinue)
                    .buttonStyle(GoobyPrimaryButtonStyle())
                    .accessibilityHint("Opens Gooby’s home")
            }
            .padding(30)
        }
        .interactiveDismissDisabled()
    }
}

private struct MainShellView: View {
    @Bindable var store: GameStore
    let state: GameState
    @Binding var selectedTab: Int

    var body: some View {
        TabView(selection: $selectedTab) {
            NavigationStack {
                HomeView(store: store, state: state) {
                    selectedTab = 1
                }
            }
            .tabItem { Label("Home", systemImage: "house.fill") }
            .tag(0)

            NavigationStack {
                JournalView(state: state)
            }
            .tabItem { Label("Journal", systemImage: "book.closed.fill") }
            .tag(1)
        }
        .tint(GoobyPalette.coral)
    }
}

private struct HomeView: View {
    @Bindable var store: GameStore
    let state: GameState
    let onOpenJournal: () -> Void

    @Environment(\.dynamicTypeSize) private var dynamicTypeSize
    @State private var presentedDestination: HomeDestination?
    @State private var selectedFood = "Garden Carrot"

    private let columns = [
        GridItem(.flexible(), spacing: 10),
        GridItem(.flexible(), spacing: 10),
    ]

    var body: some View {
        ZStack {
            GoobyBackground()
            ScrollView {
                LazyVStack(spacing: 16) {
                    header
                    hero
                    needs
                    roomPicker
                    actionCard
                    destinations
                }
                .padding(.horizontal, 16)
                .padding(.bottom, 28)
            }
            .scrollIndicators(.hidden)
        }
        .navigationTitle(GoobyBrand.name)
        .navigationBarTitleDisplayMode(.inline)
        .toolbarBackground(.hidden, for: .navigationBar)
        .sheet(item: $presentedDestination) { destination in
            destinationView(destination)
        }
    }

    private var header: some View {
        HStack(alignment: .center, spacing: 12) {
            VStack(alignment: .leading, spacing: 3) {
                Text(store.mood)
                    .font(.system(.title2, design: .rounded, weight: .black))
                    .foregroundStyle(GoobyPalette.ink)
                Text("Bond level \(state.bondLevel) • \(state.bondPoints) points")
                    .font(.system(.subheadline, design: .rounded, weight: .semibold))
                    .foregroundStyle(.secondary)
                Text(statusSummary)
                    .font(.caption)
                    .foregroundStyle(.secondary)
                    .accessibilityIdentifier("gooby.status")
            }
            Spacer()
            Label("\(state.carrots)", systemImage: "carrot.fill")
                .font(.system(.headline, design: .rounded, weight: .bold))
                .foregroundStyle(GoobyPalette.ink)
                .padding(.horizontal, 12)
                .frame(minHeight: 44)
                .background(.thinMaterial, in: Capsule())
                .accessibilityLabel("Carrots")
                .accessibilityValue("\(state.carrots)")
        }
        .padding(.top, 4)
    }

    private var hero: some View {
        ZStack(alignment: .bottomLeading) {
            RoundedRectangle(cornerRadius: 30, style: .continuous)
                .fill(.ultraThinMaterial)
                .overlay {
                    RoundedRectangle(cornerRadius: 30, style: .continuous)
                        .stroke(.white.opacity(0.55), lineWidth: 1)
                }
            GoobyRealityView(
                state: state,
                events: store.latestEvents,
                eventRevision: store.eventRevision
            ) {
                Task { await store.dispatch(.pet) }
            }
            VStack(alignment: .leading, spacing: 2) {
                Text(state.currentRoom.displayName)
                    .font(.system(.headline, design: .rounded, weight: .bold))
                    .accessibilityIdentifier("room.current")
                Text(state.isSleeping ? "Sleeping softly" : "Tap Gooby to pet")
                    .font(.caption)
                    .foregroundStyle(.secondary)
                    .accessibilityIdentifier("gooby.activity")
            }
            .padding(.horizontal, 14)
            .padding(.vertical, 10)
            .background(.regularMaterial, in: Capsule())
            .padding(14)
        }
        .frame(height: dynamicTypeSize.isAccessibilitySize ? 300 : 340)
        .shadow(color: GoobyPalette.ink.opacity(0.10), radius: 18, y: 9)
        .accessibilityElement(children: .contain)
    }

    private var needs: some View {
        VStack(alignment: .leading, spacing: 12) {
            Text("How Gooby feels")
                .font(.system(.headline, design: .rounded, weight: .bold))
            LazyVGrid(columns: columns, spacing: 10) {
                NeedMeter(
                    name: "Fullness",
                    symbol: "fork.knife",
                    value: state.needs.fullness.value,
                    tint: GoobyPalette.coral,
                    identifier: "need.fullness"
                )
                NeedMeter(
                    name: "Cleanliness",
                    symbol: "sparkles",
                    value: state.needs.cleanliness.value,
                    tint: GoobyPalette.sky,
                    identifier: "need.cleanliness"
                )
                NeedMeter(
                    name: "Energy",
                    symbol: "bolt.fill",
                    value: state.needs.energy.value,
                    tint: GoobyPalette.gold,
                    identifier: "need.energy"
                )
                NeedMeter(
                    name: "Fun",
                    symbol: "party.popper.fill",
                    value: state.needs.fun.value,
                    tint: GoobyPalette.mint,
                    identifier: "need.fun"
                )
            }
        }
        .goobyCard()
    }

    private var roomPicker: some View {
        VStack(alignment: .leading, spacing: 10) {
            Text("Choose a room")
                .font(.system(.headline, design: .rounded, weight: .bold))
            ScrollView(.horizontal) {
                HStack(spacing: 9) {
                    ForEach(RoomID.allCases, id: \.self) { room in
                        Button {
                            Task { await store.dispatch(.move(to: room)) }
                        } label: {
                            Label(room.displayName, systemImage: room.symbolName)
                                .font(.system(.subheadline, design: .rounded, weight: .bold))
                                .padding(.horizontal, 13)
                                .frame(minHeight: 48)
                                .background(
                                    room == state.currentRoom
                                        ? GoobyPalette.ink
                                        : Color.white.opacity(0.60),
                                    in: Capsule()
                                )
                                .foregroundStyle(
                                    room == state.currentRoom ? Color.white : GoobyPalette.ink
                                )
                        }
                        .buttonStyle(.plain)
                        .accessibilityIdentifier("room.\(room.rawValue)")
                        .accessibilityHint(
                            room == state.currentRoom
                                ? "Current room"
                                : "Moves Gooby to the \(room.displayName.lowercased())"
                        )
                    }
                }
            }
            .scrollIndicators(.hidden)
        }
    }

    private var actionCard: some View {
        VStack(alignment: .leading, spacing: 12) {
            HStack {
                Label(primaryTitle, systemImage: primarySymbol)
                    .font(.system(.title3, design: .rounded, weight: .black))
                Spacer()
                Text(state.currentRoom.displayName)
                    .font(.caption.weight(.bold))
                    .foregroundStyle(.secondary)
            }

            if state.currentRoom == .kitchen {
                Picker("Owned food", selection: $selectedFood) {
                    Label("Garden Carrot • 2", systemImage: "carrot.fill")
                        .tag("Garden Carrot")
                }
                .pickerStyle(.menu)
                .frame(minHeight: 44)
                .accessibilityIdentifier("food.picker")
                .accessibilityHint("Selects an owned food to feed Gooby")
            }

            HStack(spacing: 10) {
                Button(primaryTitle) {
                    Task { await store.dispatch(primaryCommand) }
                }
                .buttonStyle(GoobyPrimaryButtonStyle())
                .disabled(primaryDisabled)
                .accessibilityIdentifier("care.primary")
                .accessibilityHint(primaryHint)

                Button {
                    Task { await store.dispatch(.pet) }
                } label: {
                    Label("Pet", systemImage: "hand.raised.fill")
                        .frame(maxWidth: .infinity)
                }
                .buttonStyle(GoobySecondaryButtonStyle())
                .disabled(state.isSleeping)
                .accessibilityIdentifier("care.pet")
                .accessibilityHint(
                    state.isSleeping
                        ? "Wake Gooby before petting"
                        : "Pets Gooby in any room"
                )
            }

            if let disabledReason {
                Label(disabledReason, systemImage: "info.circle.fill")
                    .font(.caption)
                    .foregroundStyle(.secondary)
                    .accessibilityIdentifier("care.disabled-reason")
            }
        }
        .goobyCard()
    }

    private var destinations: some View {
        LazyVGrid(columns: columns, spacing: 10) {
            DestinationButton(title: "Daily", symbol: "gift.fill", tint: GoobyPalette.gold) {
                Task { await store.dispatch(.claimDailyReward) }
            }
            DestinationButton(title: "Arcade", symbol: "gamecontroller.fill", tint: GoobyPalette.sky) {
                presentedDestination = .arcade
            }
            DestinationButton(title: "Shop", symbol: "bag.fill", tint: GoobyPalette.coral) {
                presentedDestination = .shop
            }
            DestinationButton(title: "Journal", symbol: "book.closed.fill", tint: GoobyPalette.mint) {
                onOpenJournal()
            }
        }
    }

    @ViewBuilder
    private func destinationView(_ destination: HomeDestination) -> some View {
        switch destination {
        case .arcade:
            NavigationStack { ArcadeView(state: state) }
        case .shop:
            NavigationStack { ShopView(store: store, state: state) }
        }
    }

    private var primaryTitle: String {
        switch state.currentRoom {
        case .kitchen: "Feed Gooby"
        case .washroom: "Clean Gooby"
        case .bedroom: state.isSleeping ? "Wake Gooby" : "Tuck In"
        case .playroom: "Play Together"
        }
    }

    private var primarySymbol: String {
        switch state.currentRoom {
        case .kitchen: "carrot.fill"
        case .washroom: "bubbles.and.sparkles.fill"
        case .bedroom: state.isSleeping ? "sun.max.fill" : "moon.zzz.fill"
        case .playroom: "figure.play"
        }
    }

    private var primaryCommand: GameCommand {
        switch state.currentRoom {
        case .kitchen: .feed
        case .washroom: .wash
        case .bedroom: state.isSleeping ? .endSleep : .beginSleep
        case .playroom: .play
        }
    }

    private var primaryDisabled: Bool {
        switch state.currentRoom {
        case .kitchen: state.carrots < 2 || state.isSleeping
        case .washroom: state.isSleeping
        case .bedroom: false
        case .playroom: state.needs.energy.value < 100 || state.isSleeping
        }
    }

    private var disabledReason: String? {
        if state.isSleeping, state.currentRoom != .bedroom {
            return "Gooby is sleeping. Move rooms to wake up."
        }
        if state.currentRoom == .kitchen, state.carrots < 2 {
            return "Gooby needs 2 carrots for a snack."
        }
        if state.currentRoom == .playroom, state.needs.energy.value < 100 {
            return "Gooby needs at least 10% energy to play."
        }
        if state.isSleeping {
            return "Petting waits until Gooby wakes."
        }
        return nil
    }

    private var primaryHint: String {
        if let disabledReason { return disabledReason }
        return switch state.currentRoom {
        case .kitchen: "Uses the selected owned food and improves fullness"
        case .washroom: "Improves cleanliness"
        case .bedroom: state.isSleeping ? "Wakes Gooby" : "Starts restoring energy over time"
        case .playroom: "Uses a little energy and improves fun"
        }
    }

    private var statusSummary: String {
        "\(store.mood), \(state.currentRoom.displayName), "
            + (state.isSleeping ? "sleeping" : "awake")
    }
}

private struct NeedMeter: View {
    let name: String
    let symbol: String
    let value: Int
    let tint: Color
    let identifier: String

    @Environment(\.accessibilityDifferentiateWithoutColor) private var differentiatesWithoutColor

    private var percent: Int { value / 10 }

    var body: some View {
        VStack(alignment: .leading, spacing: 8) {
            HStack {
                Image(systemName: symbol)
                    .foregroundStyle(tint)
                    .accessibilityHidden(true)
                Text(name)
                    .font(.system(.subheadline, design: .rounded, weight: .bold))
                Spacer()
                Text("\(percent)%")
                    .font(.system(.subheadline, design: .rounded, weight: .black))
                    .accessibilityIdentifier("\(identifier).value")
            }
            ProgressView(value: Double(value), total: 1_000)
                .tint(tint)
                .scaleEffect(y: 1.5)
                .accessibilityHidden(true)
            if differentiatesWithoutColor {
                Text(levelCue)
                    .font(.caption2.weight(.bold))
                    .foregroundStyle(.secondary)
            }
        }
        .padding(12)
        .background(Color.white.opacity(0.52), in: RoundedRectangle(cornerRadius: 16))
        .accessibilityElement(children: .contain)
        .accessibilityLabel(name)
        .accessibilityValue("\(percent) percent, \(levelCue)")
        .accessibilityIdentifier(identifier)
    }

    private var levelCue: String {
        switch percent {
        case 75 ... 100: "Doing great"
        case 50 ..< 75: "Comfortable"
        case 25 ..< 50: "Needs care soon"
        default: "Needs care now"
        }
    }
}

private struct DestinationButton: View {
    let title: String
    let symbol: String
    let tint: Color
    let action: () -> Void

    var body: some View {
        Button(action: action) {
            HStack(spacing: 10) {
                Image(systemName: symbol)
                    .foregroundStyle(tint)
                Text(title)
                    .font(.system(.subheadline, design: .rounded, weight: .bold))
                Spacer()
                Image(systemName: "chevron.right")
                    .font(.caption.weight(.black))
                    .foregroundStyle(.tertiary)
            }
            .padding(13)
            .frame(minHeight: 54)
            .background(.thinMaterial, in: RoundedRectangle(cornerRadius: 17))
        }
        .buttonStyle(.plain)
        .accessibilityHint("Opens \(title.lowercased())")
    }
}

private struct JournalView: View {
    let state: GameState

    var body: some View {
        ZStack {
            GoobyBackground()
            List {
                Section("Today with Gooby") {
                    JournalRow(
                        symbol: "fork.knife",
                        title: "Meals shared",
                        value: "\(state.careStatistics.meals)"
                    )
                    JournalRow(
                        symbol: "drop.fill",
                        title: "Bubble baths",
                        value: "\(state.careStatistics.baths)"
                    )
                    JournalRow(
                        symbol: "figure.play",
                        title: "Play sessions",
                        value: "\(state.careStatistics.playSessions)"
                    )
                }
                Section("Treasures") {
                    JournalRow(
                        symbol: "medal.fill",
                        title: "Achievements",
                        value: "\(state.unlockedAchievements.count)"
                    )
                    JournalRow(
                        symbol: "bag.fill",
                        title: "Owned keepsakes",
                        value: "\(state.ownedItems.count)"
                    )
                }
            }
            .scrollContentBackground(.hidden)
        }
        .navigationTitle("Gooby’s Journal")
    }
}

private struct JournalRow: View {
    let symbol: String
    let title: String
    let value: String

    var body: some View {
        Label {
            HStack {
                Text(title)
                Spacer()
                Text(value).fontWeight(.bold)
            }
        } icon: {
            Image(systemName: symbol).foregroundStyle(GoobyPalette.coral)
        }
        .frame(minHeight: 44)
    }
}

private struct ArcadeView: View {
    let state: GameState

    var body: some View {
        List {
            Label("Carrot Catch", systemImage: "carrot.fill")
            Label(
                state.bondLevel >= 1 ? "Garden Echo" : "Garden Echo • Bond level 1",
                systemImage: "music.note.list"
            )
            .foregroundStyle(state.bondLevel >= 1 ? .primary : .secondary)
        }
        .navigationTitle("Pocket Arcade")
        .toolbar {
            ToolbarItem(placement: .confirmationAction) {
                DismissButton()
            }
        }
    }
}

private struct ShopView: View {
    @Bindable var store: GameStore
    let state: GameState

    var body: some View {
        List(GoobyCatalog.items) { item in
            HStack {
                VStack(alignment: .leading) {
                    Text(item.name).fontWeight(.bold)
                    Text("Bond level \(item.requiredBondLevel)")
                        .font(.caption)
                        .foregroundStyle(.secondary)
                }
                Spacer()
                if state.ownedItems.contains(item.id) {
                    Text("Owned")
                        .foregroundStyle(GoobyPalette.mint)
                        .fontWeight(.bold)
                } else {
                    Button("\(item.price) 🥕") {
                        Task { await store.dispatch(.purchase(itemID: item.id)) }
                    }
                    .frame(minHeight: 44)
                }
            }
        }
        .navigationTitle("Cozy Shop")
        .toolbar {
            ToolbarItem(placement: .confirmationAction) {
                DismissButton()
            }
        }
    }
}

private struct DismissButton: View {
    @Environment(\.dismiss) private var dismiss

    var body: some View {
        Button("Done") { dismiss() }
    }
}

private enum HomeDestination: String, Identifiable {
    case arcade
    case shop

    var id: String { rawValue }
}

private struct GoobyBackground: View {
    var body: some View {
        LinearGradient(
            colors: [
                GoobyPalette.cream,
                GoobyPalette.apricot.opacity(0.42),
                Color(red: 0.89, green: 0.78, blue: 0.82),
            ],
            startPoint: .topLeading,
            endPoint: .bottomTrailing
        )
        .ignoresSafeArea()
    }
}

private struct GoobyPrimaryButtonStyle: ButtonStyle {
    func makeBody(configuration: Configuration) -> some View {
        configuration.label
            .font(.system(.headline, design: .rounded, weight: .bold))
            .foregroundStyle(.white)
            .padding(.horizontal, 16)
            .frame(maxWidth: .infinity, minHeight: 50)
            .background(
                GoobyPalette.coral.opacity(configuration.isPressed ? 0.72 : 1),
                in: RoundedRectangle(cornerRadius: 16)
            )
            .scaleEffect(configuration.isPressed ? 0.98 : 1)
    }
}

private struct GoobySecondaryButtonStyle: ButtonStyle {
    func makeBody(configuration: Configuration) -> some View {
        configuration.label
            .font(.system(.headline, design: .rounded, weight: .bold))
            .foregroundStyle(GoobyPalette.ink)
            .padding(.horizontal, 16)
            .frame(maxWidth: .infinity, minHeight: 50)
            .background(
                Color.white.opacity(configuration.isPressed ? 0.45 : 0.70),
                in: RoundedRectangle(cornerRadius: 16)
            )
    }
}

private extension View {
    func goobyCard() -> some View {
        padding(16)
            .background(.thinMaterial, in: RoundedRectangle(cornerRadius: 23))
            .overlay {
                RoundedRectangle(cornerRadius: 23)
                    .stroke(.white.opacity(0.45), lineWidth: 1)
            }
    }
}
