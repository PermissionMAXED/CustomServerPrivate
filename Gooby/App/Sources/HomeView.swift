import GoobyCore
import SwiftUI
import UIKit

enum GoobyBrand {
    static let name = "Gooby"
    static let subtitle = "A little world for a big-hearted bunny."
}

enum GoobyPalette {
    static let inkUIColor = adaptive(light: 0x38_21_26, dark: 0xFF_F5_E8)
    static let creamUIColor = adaptive(light: 0xFF_F3_D5, dark: 0x1B_18_21)
    static let surfaceUIColor = adaptive(light: 0xFF_F8_EA, dark: 0x2A_25_31)
    static let strongSurfaceUIColor = adaptive(light: 0xFF_FF_FF, dark: 0x33_2E_3B)
    static let borderUIColor = adaptive(light: 0x7A_57_51, dark: 0xCD_AF_A4)
    static let actionUIColor = adaptive(light: 0x8B_27_30, dark: 0x70_20_2B)
    static let coralUIColor = adaptive(light: 0xB8_3E_3B, dark: 0xFF_90_88)
    static let mintUIColor = adaptive(light: 0x28_70_53, dark: 0x82_D7_B6)
    static let skyUIColor = adaptive(light: 0x31_5F_93, dark: 0x91_C5_F5)
    static let goldUIColor = adaptive(light: 0x85_58_07, dark: 0xF5_C4_51)

    static let ink = Color(inkUIColor)
    static let cream = Color(creamUIColor)
    static let surface = Color(surfaceUIColor)
    static let strongSurface = Color(strongSurfaceUIColor)
    static let border = Color(borderUIColor)
    static let action = Color(actionUIColor)
    static let apricot = Color(
        adaptive(light: 0xD8_80_42, dark: 0xF2_AB_73)
    )
    static let coral = Color(coralUIColor)
    static let mint = Color(mintUIColor)
    static let sky = Color(skyUIColor)
    static let gold = Color(goldUIColor)

    private static func adaptive(light: Int, dark: Int) -> UIColor {
        UIColor { traits in
            color(traits.userInterfaceStyle == .dark ? dark : light)
        }
    }

    private static func color(_ rgb: Int) -> UIColor {
        UIColor(
            red: CGFloat((rgb >> 16) & 0xFF) / 255,
            green: CGFloat((rgb >> 8) & 0xFF) / 255,
            blue: CGFloat(rgb & 0xFF) / 255,
            alpha: 1
        )
    }
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
            case .recoveryRequired:
                SaveRecoveryView(
                    message: store.errorMessage ?? "Gooby’s save needs recovery.",
                    onReset: { Task { await store.resetDamagedSave() } }
                )
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
        .overlay(alignment: .top) {
            RewardToastHost(store: store)
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

private struct SaveRecoveryView: View {
    let message: String
    let onReset: () -> Void
    @State private var confirmsReset = false

    var body: some View {
        ZStack {
            GoobyBackground()
            VStack(spacing: 18) {
                Image(systemName: "externaldrive.badge.exclamationmark")
                    .font(.system(size: 46, weight: .semibold))
                    .foregroundStyle(GoobyPalette.coral)
                Text("Save recovery required")
                    .font(.system(.title2, design: .rounded, weight: .bold))
                Text(message)
                    .multilineTextAlignment(.center)
                    .foregroundStyle(.secondary)
                Button("Reset damaged save", role: .destructive) {
                    confirmsReset = true
                }
                .buttonStyle(.borderedProminent)
                .accessibilityIdentifier("recovery.reset")
            }
            .padding(28)
        }
        .confirmationDialog(
            "Discard the unreadable save?",
            isPresented: $confirmsReset,
            titleVisibility: .visible
        ) {
            Button("Discard Save and Start Fresh", role: .destructive, action: onReset)
            Button("Keep Save", role: .cancel) {}
        } message: {
            Text("This cannot be undone. Gooby will preserve the files unless you confirm.")
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
            ScrollView {
                VStack(spacing: 24) {
                    Image(systemName: "hare.fill")
                        .font(.system(size: 88, weight: .bold))
                        .foregroundStyle(GoobyPalette.apricot)
                        .padding(28)
                        .goobySurface(in: Circle())
                        .accessibilityHidden(true)
                    VStack(spacing: 10) {
                        Text("Meet Gooby")
                            .font(.system(.largeTitle, design: .rounded, weight: .black))
                        Text("A soft-hearted rabbit who loves snacks, splashes, naps, and time with you.")
                            .font(.system(.body, design: .rounded, weight: .medium))
                            .multilineTextAlignment(.center)
                            .foregroundStyle(.secondary)
                    }
                    Button("Start caring", action: onContinue)
                        .buttonStyle(GoobyPrimaryButtonStyle())
                        .accessibilityHint("Opens Gooby’s home")
                }
                .frame(maxWidth: .infinity, minHeight: 620)
                .padding(30)
            }
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
    @State private var selectedFood = GoobyCatalog.gardenCarrot
    @State private var careConfirmation: String?

    private var columns: [GridItem] {
        dynamicTypeSize.isAccessibilitySize
            ? [GridItem(.flexible(), spacing: 10)]
            : [GridItem(.flexible(), spacing: 10), GridItem(.flexible(), spacing: 10)]
    }

    var body: some View {
        ZStack {
            GoobyBackground()
            ScrollView {
                LazyVStack(spacing: 16) {
                    header
                    roomPicker
                    actionCard
                    hero
                    compactNeeds
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
        .toolbar {
            ToolbarItem(placement: .topBarTrailing) {
                Button {
                    presentedDestination = .settings
                } label: {
                    Label("Settings", systemImage: "gearshape.fill")
                }
                .accessibilityIdentifier("home.settings")
            }
        }
    }

    private var header: some View {
        Group {
            if dynamicTypeSize.isAccessibilitySize {
                VStack(alignment: .leading, spacing: 10) {
                    identitySummary
                    carrotBalance
                }
            } else {
                HStack(alignment: .center, spacing: 12) {
                    identitySummary
                    Spacer()
                    carrotBalance
                }
            }
        }
        .padding(.top, 4)
    }

    private var identitySummary: some View {
        VStack(alignment: .leading, spacing: 3) {
            Text("\(state.preferences.petName) is \(store.mood.lowercased())")
                .font(.system(.title2, design: .rounded, weight: .black))
                .foregroundStyle(GoobyPalette.ink)
            Text("Bond level \(state.bondLevel) of \(BondProgress.maximumLevel)")
                .font(.system(.subheadline, design: .rounded, weight: .semibold))
                .foregroundStyle(.secondary)
                .accessibilityIdentifier("bond.level")
            if let required = BondProgress.progress(for: state.bondPoints).required {
                ProgressView(
                    value: Double(BondProgress.progress(for: state.bondPoints).current),
                    total: Double(required)
                )
                .tint(GoobyPalette.coral)
                .accessibilityLabel("Bond progress")
                .accessibilityValue(
                    "\(BondProgress.progress(for: state.bondPoints).current) of \(required) points"
                )
            } else {
                Text("Best-bunny bond reached")
                    .font(.caption.weight(.bold))
                    .foregroundStyle(GoobyPalette.mint)
            }
            Text(statusSummary)
                .font(.caption)
                .foregroundStyle(.secondary)
                .accessibilityIdentifier("gooby.status")
        }
    }

    private var carrotBalance: some View {
        Label("\(state.carrots)", systemImage: "carrot.fill")
            .font(.system(.headline, design: .rounded, weight: .bold))
            .foregroundStyle(GoobyPalette.ink)
            .padding(.horizontal, 12)
            .frame(minHeight: 44)
            .goobySurface(in: Capsule(), strong: true)
            .accessibilityElement(children: .ignore)
            .accessibilityLabel("Carrots")
            .accessibilityValue("\(state.carrots)")
            .accessibilityIdentifier("home.carrots")
    }

    private var hero: some View {
        ZStack(alignment: .bottomLeading) {
            RoundedRectangle(cornerRadius: 30, style: .continuous)
                .fill(GoobyPalette.strongSurface)
                .overlay {
                    RoundedRectangle(cornerRadius: 30, style: .continuous)
                        .stroke(GoobyPalette.border.opacity(0.55), lineWidth: 1)
                }
            GoobyRealityView(
                state: state,
                events: store.eventBatches.flatMap(\.events),
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
            .goobySurface(in: Capsule(), strong: true)
            .padding(14)
        }
        .frame(height: dynamicTypeSize.isAccessibilitySize ? 310 : 220)
        .shadow(color: GoobyPalette.ink.opacity(0.10), radius: 18, y: 9)
        .accessibilityElement(children: .contain)
        .accessibilityIdentifier("home.gooby-hero")
        .accessibilityLabel("3D Gooby in the \(state.currentRoom.displayName)")
    }

    private var compactNeeds: some View {
        ViewThatFits {
            HStack(spacing: 8) {
                compactNeed(
                    name: "Fullness",
                    symbol: "fork.knife",
                    value: state.needs.fullness.value,
                    tint: GoobyPalette.coral,
                    identifier: "need.fullness"
                )
                compactNeed(
                    name: "Cleanliness",
                    symbol: "sparkles",
                    value: state.needs.cleanliness.value,
                    tint: GoobyPalette.sky,
                    identifier: "need.cleanliness"
                )
                compactNeed(
                    name: "Energy",
                    symbol: "bolt.fill",
                    value: state.needs.energy.value,
                    tint: GoobyPalette.gold,
                    identifier: "need.energy"
                )
                compactNeed(
                    name: "Fun",
                    symbol: "party.popper.fill",
                    value: state.needs.fun.value,
                    tint: GoobyPalette.mint,
                    identifier: "need.fun"
                )
            }
            LazyVGrid(columns: columns, spacing: 8) {
                compactNeed(
                    name: "Fullness",
                    symbol: "fork.knife",
                    value: state.needs.fullness.value,
                    tint: GoobyPalette.coral,
                    identifier: "need.fullness"
                )
                compactNeed(
                    name: "Cleanliness",
                    symbol: "sparkles",
                    value: state.needs.cleanliness.value,
                    tint: GoobyPalette.sky,
                    identifier: "need.cleanliness"
                )
                compactNeed(
                    name: "Energy",
                    symbol: "bolt.fill",
                    value: state.needs.energy.value,
                    tint: GoobyPalette.gold,
                    identifier: "need.energy"
                )
                compactNeed(
                    name: "Fun",
                    symbol: "party.popper.fill",
                    value: state.needs.fun.value,
                    tint: GoobyPalette.mint,
                    identifier: "need.fun"
                )
            }
        }
        .padding(10)
        .goobySurface(in: RoundedRectangle(cornerRadius: 20, style: .continuous))
        .accessibilityIdentifier("needs.compact-summary")
    }

    private func compactNeed(
        name: String,
        symbol: String,
        value: Int,
        tint: Color,
        identifier: String
    ) -> some View {
        VStack(spacing: 2) {
            Image(systemName: symbol)
                .foregroundStyle(tint)
                .accessibilityHidden(true)
            Text("\(value / 10)%")
                .font(.system(.caption, design: .rounded, weight: .black))
                .accessibilityIdentifier("\(identifier).value")
        }
        .frame(maxWidth: .infinity, minHeight: 44)
        .accessibilityElement(children: .contain)
        .accessibilityLabel(name)
        .accessibilityValue("\(value / 10) percent")
    }

    private var roomPicker: some View {
        VStack(alignment: .leading, spacing: 10) {
            Text("Choose a room")
                .font(.system(.headline, design: .rounded, weight: .bold))
            LazyVGrid(columns: columns, spacing: 9) {
                ForEach(RoomID.allCases, id: \.self) { room in
                    Button {
                        careConfirmation = nil
                        Task { await store.dispatch(.move(to: room)) }
                    } label: {
                        HStack(spacing: 7) {
                            Image(systemName: room.symbolName)
                            Text(room.displayName)
                            Spacer(minLength: 2)
                            if room == state.currentRoom {
                                Image(systemName: "checkmark.circle.fill")
                                    .accessibilityHidden(true)
                            }
                        }
                        .font(.system(.subheadline, design: .rounded, weight: .bold))
                        .padding(.horizontal, 13)
                        .frame(maxWidth: .infinity, minHeight: 48)
                        .background(
                            room == state.currentRoom
                                ? GoobyPalette.action
                                : GoobyPalette.strongSurface,
                            in: RoundedRectangle(cornerRadius: 15)
                        )
                        .foregroundStyle(
                            room == state.currentRoom ? Color.white : GoobyPalette.ink
                        )
                        .overlay {
                            RoundedRectangle(cornerRadius: 15)
                                .stroke(
                                    room == state.currentRoom
                                        ? GoobyPalette.gold
                                        : GoobyPalette.border.opacity(0.42),
                                    lineWidth: room == state.currentRoom ? 3 : 1
                                )
                        }
                    }
                    .buttonStyle(.plain)
                    .accessibilityAddTraits(
                        room == state.currentRoom ? .isSelected : []
                    )
                    .accessibilityIdentifier("room.\(room.rawValue)")
                    .accessibilityHint(
                        room == state.currentRoom
                            ? "Current room"
                            : "Moves Gooby to the \(room.displayName.lowercased())"
                    )
                }
            }
        }
        .accessibilityIdentifier("room.picker")
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
                    ForEach(GoobyCatalog.foods.filter { state.foodQuantity($0.id) > 0 }) { food in
                        Text("\(food.name) • \(state.foodQuantity(food.id))")
                            .tag(food.id)
                    }
                }
                .pickerStyle(.menu)
                .frame(minHeight: 44)
                .accessibilityIdentifier("food.picker")
                .accessibilityHint("Selects an owned food to feed Gooby")
            }

            ViewThatFits {
                HStack(spacing: 10) {
                    careButtons
                }
                VStack(spacing: 10) {
                    careButtons
                }
            }

            if let disabledReason {
                Label(disabledReason, systemImage: "info.circle.fill")
                    .font(.caption)
                    .foregroundStyle(.secondary)
                    .accessibilityIdentifier("care.disabled-reason")
            }
            if let careConfirmation {
                Label(careConfirmation, systemImage: "checkmark.circle.fill")
                    .font(.subheadline.weight(.bold))
                    .foregroundStyle(GoobyPalette.mint)
                    .accessibilityIdentifier("care.confirmation")
                    .accessibilityAddTraits(.updatesFrequently)
            }
        }
        .goobyCard()
    }

    @ViewBuilder
    private var careButtons: some View {
        Button(primaryTitle) {
            Task {
                if await store.dispatch(primaryCommand) {
                    careConfirmation = primaryConfirmation
                }
            }
        }
        .buttonStyle(GoobyPrimaryButtonStyle())
        .disabled(primaryDisabled)
        .accessibilityIdentifier("care.primary")
        .accessibilityHint(primaryHint)

        Button {
            Task {
                if await store.dispatch(.pet) {
                    let fun = (store.state ?? state).needs.fun.value / 10
                    careConfirmation = "Pet complete • fun is now \(fun)%."
                }
            }
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

    private var destinations: some View {
        LazyVGrid(columns: columns, spacing: 10) {
            DestinationButton(title: "Daily Gift", symbol: "gift.fill", tint: GoobyPalette.gold) {
                presentedDestination = .daily
            }
            DestinationButton(title: "Shop", symbol: "bag.fill", tint: GoobyPalette.coral) {
                presentedDestination = .shop
            }
            DestinationButton(title: "Wardrobe", symbol: "tshirt.fill", tint: GoobyPalette.sky) {
                presentedDestination = .wardrobe
            }
            DestinationButton(title: "Journal", symbol: "book.closed.fill", tint: GoobyPalette.mint) {
                onOpenJournal()
            }
            DestinationButton(title: "Arcade", symbol: "gamecontroller.fill", tint: GoobyPalette.sky) {
                presentedDestination = .arcade
            }
        }
    }

    @ViewBuilder
    private func destinationView(_ destination: HomeDestination) -> some View {
        switch destination {
        case .daily:
            NavigationStack { DailyGiftView(store: store) }
        case .arcade:
            NavigationStack { ArcadeView(store: store, state: state) }
        case .shop:
            NavigationStack { ShopView(store: store, state: state) }
        case .wardrobe:
            NavigationStack { WardrobeView(store: store, state: state) }
        case .settings:
            NavigationStack { SettingsView(store: store, state: state) }
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
        case .kitchen: .feedFood(itemID: selectedFood)
        case .washroom: .wash
        case .bedroom: state.isSleeping ? .endSleep : .beginSleep
        case .playroom: .play
        }
    }

    private var primaryDisabled: Bool {
        switch state.currentRoom {
        case .kitchen: state.foodQuantity(selectedFood) < 1 || state.isSleeping
        case .washroom: state.isSleeping
        case .bedroom: false
        case .playroom: state.needs.energy.value < 100 || state.isSleeping
        }
    }

    private var disabledReason: String? {
        if state.isSleeping, state.currentRoom != .bedroom {
            return "Gooby is sleeping. Move rooms to wake up."
        }
        if state.currentRoom == .kitchen, state.foodQuantity(selectedFood) < 1 {
            return "This snack is out of stock. The shop has more."
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

    private var primaryConfirmation: String {
        let current = store.state ?? state
        return switch state.currentRoom {
        case .kitchen: "Meal complete • fullness is now \(current.needs.fullness.value / 10)%."
        case .washroom:
            "Wash complete • cleanliness is now \(current.needs.cleanliness.value / 10)%."
        case .bedroom:
            state.isSleeping ? "Gooby is awake and ready." : "Gooby is tucked in and resting."
        case .playroom: "Play complete • fun is now \(current.needs.fun.value / 10)%."
        }
    }

    private var statusSummary: String {
        "\(store.mood), \(state.currentRoom.displayName), "
            + (state.isSleeping ? "sleeping" : "awake")
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
            .goobySurface(in: RoundedRectangle(cornerRadius: 17))
        }
        .buttonStyle(.plain)
        .accessibilityIdentifier(
            "home.destination.\(title.lowercased().replacingOccurrences(of: " ", with: "-"))"
        )
        .accessibilityHint("Opens \(title.lowercased())")
    }
}

private struct JournalView: View {
    let state: GameState

    var body: some View {
        ZStack {
            GoobyBackground()
            List {
                Section("Care journal") {
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
                Section("Achievements") {
                    ForEach(GoobyAchievements.definitions) { achievement in
                        let progress = min(achievement.progress(in: state), achievement.target)
                        let isUnlocked = state.unlockedAchievements.contains(achievement.id)
                        VStack(alignment: .leading, spacing: 7) {
                            HStack {
                                Label(
                                    achievement.title,
                                    systemImage: isUnlocked ? "medal.fill" : "medal"
                                )
                                .font(.headline)
                                Spacer()
                                Text(isUnlocked ? "Unlocked" : "\(progress)/\(achievement.target)")
                                    .font(.subheadline.weight(.bold))
                                    .foregroundStyle(isUnlocked ? GoobyPalette.mint : .secondary)
                            }
                            Text(achievement.detail)
                                .font(.subheadline)
                                .foregroundStyle(.secondary)
                            if let unlockedAt = state.achievementDate(achievement.id) {
                                Text(
                                    "Earned \(Date(timeIntervalSince1970: Double(unlockedAt.secondsSinceEpoch)), style: .date) • +\(achievement.carrotReward) carrots"
                                )
                                .font(.caption.weight(.semibold))
                            } else {
                                ProgressView(value: Double(progress), total: Double(achievement.target))
                                    .tint(GoobyPalette.coral)
                                Text("Reward: \(achievement.carrotReward) carrots")
                                    .font(.caption)
                                    .foregroundStyle(.secondary)
                            }
                        }
                        .padding(.vertical, 5)
                        .accessibilityElement(children: .combine)
                        .accessibilityLabel(achievement.title)
                        .accessibilityValue(
                            isUnlocked
                                ? "Unlocked, reward \(achievement.carrotReward) carrots"
                                : "\(progress) of \(achievement.target), reward \(achievement.carrotReward) carrots"
                        )
                    }
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

private struct ShopView: View {
    @Bindable var store: GameStore
    let state: GameState
    @State private var selectedItemID: ItemID?

    var body: some View {
        List {
            Section("Foods") {
                ForEach(GoobyCatalog.foods) { item in
                    Button {
                        selectedItemID = item.id
                    } label: {
                        ShopItemRow(item: item, state: state)
                    }
                    .accessibilityIdentifier("shop.item.\(item.id.rawValue)")
                }
            }
            Section("Permanent cosmetics") {
                ForEach(GoobyCatalog.cosmetics) { item in
                    Button {
                        selectedItemID = item.id
                    } label: {
                        ShopItemRow(item: item, state: state)
                    }
                    .accessibilityIdentifier("shop.item.\(item.id.rawValue)")
                }
            }
        }
        .navigationTitle("Cozy Shop")
        .safeAreaInset(edge: .bottom) {
            HStack {
                Label("\((store.state ?? state).carrots) carrots", systemImage: "carrot.fill")
                    .font(.headline)
                Spacer()
                Text("Available balance")
                    .font(.caption.weight(.semibold))
                    .foregroundStyle(.secondary)
            }
            .padding(.horizontal, 18)
            .frame(maxWidth: .infinity, minHeight: 58)
            .goobySurface(in: Rectangle(), strong: true)
            .overlay(alignment: .top) { Divider() }
            .accessibilityElement(children: .combine)
            .accessibilityIdentifier("shop.balance")
        }
        .navigationDestination(item: $selectedItemID) { itemID in
            if let item = GoobyCatalog.item(id: itemID) {
                ShopItemDetailView(store: store, state: state, item: item)
            }
        }
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
        Button("Close") { dismiss() }
            .accessibilityIdentifier("sheet.close")
    }
}

private enum HomeDestination: String, Identifiable {
    case daily
    case arcade
    case shop
    case wardrobe
    case settings

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
                GoobyPalette.action.opacity(configuration.isPressed ? 0.78 : 1),
                in: RoundedRectangle(cornerRadius: 16)
            )
            .scaleEffect(configuration.isPressed ? 0.98 : 1)
    }
}

private struct GoobySecondaryButtonStyle: ButtonStyle {
    @Environment(\.accessibilityReduceTransparency) private var reduceTransparency

    func makeBody(configuration: Configuration) -> some View {
        configuration.label
            .font(.system(.headline, design: .rounded, weight: .bold))
            .foregroundStyle(GoobyPalette.ink)
            .padding(.horizontal, 16)
            .frame(maxWidth: .infinity, minHeight: 50)
            .background(
                reduceTransparency
                    ? GoobyPalette.strongSurface
                    : GoobyPalette.surface.opacity(configuration.isPressed ? 0.78 : 0.94),
                in: RoundedRectangle(cornerRadius: 16)
            )
            .overlay {
                RoundedRectangle(cornerRadius: 16)
                    .stroke(GoobyPalette.border.opacity(0.45), lineWidth: 1)
            }
    }
}

struct GoobyAdaptiveSurfaceModifier<S: Shape>: ViewModifier {
    let shape: S
    let strong: Bool
    @Environment(\.accessibilityReduceTransparency) private var reduceTransparency

    func body(content: Content) -> some View {
        content.background {
            if reduceTransparency {
                shape.fill(strong ? GoobyPalette.strongSurface : GoobyPalette.surface)
            } else {
                shape.fill(
                    strong
                        ? GoobyPalette.strongSurface.opacity(0.92)
                        : GoobyPalette.surface.opacity(0.82)
                )
            }
        }
    }
}

extension View {
    func goobySurface<S: Shape>(in shape: S, strong: Bool = false) -> some View {
        modifier(GoobyAdaptiveSurfaceModifier(shape: shape, strong: strong))
    }

    func goobyCard() -> some View {
        padding(16)
            .goobySurface(in: RoundedRectangle(cornerRadius: 23))
            .overlay {
                RoundedRectangle(cornerRadius: 23)
                    .stroke(GoobyPalette.border.opacity(0.38), lineWidth: 1)
            }
    }
}
