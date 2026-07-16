import GoobyCore
import SwiftUI
import UIKit

enum RewardToastDismissalPolicy {
    static func shouldAutoDismiss(voiceOverEnabled: Bool) -> Bool {
        !voiceOverEnabled
    }
}

struct RewardToastHost: View {
    @Bindable var store: GameStore
    @Environment(\.accessibilityReduceMotion) private var systemReduceMotion
    @Environment(\.accessibilityVoiceOverEnabled) private var voiceOverEnabled
    @AccessibilityFocusState private var toastFocused: Bool

    private var notice: RewardNotice? {
        store.rewardNotices.first
    }

    var body: some View {
        ZStack {
            if let notice {
                HStack(spacing: 12) {
                    Image(systemName: symbol(for: notice.kind))
                        .font(.title2.weight(.bold))
                        .foregroundStyle(GoobyPalette.gold)
                        .accessibilityHidden(true)
                    VStack(alignment: .leading, spacing: 2) {
                        Text(notice.title)
                            .font(.system(.headline, design: .rounded, weight: .bold))
                        Text(notice.detail)
                            .font(.subheadline)
                            .foregroundStyle(.secondary)
                    }
                    Spacer(minLength: 0)
                    Button {
                        withAnimation(reduceMotion ? .easeOut : .spring) {
                            store.dismissFirstRewardNotice()
                        }
                    } label: {
                        Image(systemName: "xmark")
                            .frame(width: 44, height: 44)
                            .contentShape(Rectangle())
                    }
                    .accessibilityLabel("Dismiss reward")
                    .accessibilityIdentifier("reward.close")
                }
                .padding(14)
                .goobySurface(in: RoundedRectangle(cornerRadius: 20), strong: true)
                .overlay {
                    RoundedRectangle(cornerRadius: 20)
                        .stroke(GoobyPalette.border.opacity(0.55), lineWidth: 1)
                }
                .shadow(color: .black.opacity(0.14), radius: 14, y: 6)
                .padding(.horizontal, 16)
                .padding(.top, 8)
                .transition(
                    reduceMotion
                        ? .opacity
                        : .move(edge: .top).combined(with: .opacity)
                )
                .accessibilityElement(children: .contain)
                .accessibilityFocused($toastFocused)
                .accessibilityIdentifier("reward.toast")
            }
        }
        .animation(reduceMotion ? .easeOut : .spring, value: notice?.id)
        .task(id: "\(notice?.id.uuidString ?? "none")-\(voiceOverEnabled)") {
            guard let notice else { return }
            UIAccessibility.post(
                notification: .announcement,
                argument: "\(notice.title). \(notice.detail)"
            )
            toastFocused = true
            guard RewardToastDismissalPolicy.shouldAutoDismiss(
                voiceOverEnabled: voiceOverEnabled
            ) else { return }
            try? await Task.sleep(for: .seconds(2.6))
            guard !Task.isCancelled else { return }
            withAnimation(reduceMotion ? .easeOut : .spring) {
                store.dismissFirstRewardNotice()
            }
        }
    }

    private var reduceMotion: Bool {
        systemReduceMotion || (store.state?.preferences.reduceMotionEnabled ?? false)
    }

    private func symbol(for kind: RewardNotice.Kind) -> String {
        switch kind {
        case .reward: "gift.fill"
        case .achievement: "medal.fill"
        case .level: "heart.fill"
        case .unlock: "sparkles"
        }
    }
}

struct DailyGiftView: View {
    @Bindable var store: GameStore
    @Environment(\.dynamicTypeSize) private var dynamicTypeSize

    private var eligibility: DailyRewardEligibility {
        store.dailyEligibility ?? .eligible(step: 1)
    }

    var body: some View {
        ZStack {
            ProgressionBackground()
            ScrollView {
                VStack(spacing: 18) {
                    Image(systemName: "gift.fill")
                        .font(.system(size: 52, weight: .bold))
                        .foregroundStyle(GoobyPalette.gold)
                        .padding(20)
                        .goobySurface(in: Circle())
                        .accessibilityHidden(true)
                    Text(message)
                        .font(.system(.headline, design: .rounded, weight: .semibold))
                        .multilineTextAlignment(.center)
                        .foregroundStyle(GoobyPalette.ink)

                    LazyVGrid(
                        columns: [
                            GridItem(
                                .adaptive(
                                    minimum: dynamicTypeSize.isAccessibilitySize ? 150 : 78
                                ),
                                spacing: 10
                            ),
                        ],
                        spacing: 10
                    ) {
                        ForEach(
                            Array(GameEngine.dailyCarrotRewards.enumerated()),
                            id: \.offset
                        ) { entry in
                            let step = entry.offset + 1
                            let reward = entry.element
                            VStack(spacing: 6) {
                                Text("Visit \(step)")
                                    .font(.caption.weight(.bold))
                                Image(systemName: step == 7 ? "crown.fill" : "carrot.fill")
                                    .foregroundStyle(step == 7 ? GoobyPalette.gold : GoobyPalette.coral)
                                Text("+\(reward)")
                                    .font(.headline.weight(.black))
                                if stepState(step) == "Today" {
                                    Text("Today")
                                        .font(.caption2.weight(.bold))
                                        .foregroundStyle(GoobyPalette.mint)
                                } else if stepState(step) == "Claimed" {
                                    Image(systemName: "checkmark.circle.fill")
                                        .foregroundStyle(GoobyPalette.mint)
                                        .accessibilityLabel("Claimed")
                                }
                            }
                            .frame(maxWidth: .infinity, minHeight: 100)
                            .padding(8)
                            .background(
                                stepState(step) == "Today"
                                    ? GoobyPalette.gold.opacity(0.22)
                                    : GoobyPalette.surface,
                                in: RoundedRectangle(cornerRadius: 17)
                            )
                            .overlay {
                                RoundedRectangle(cornerRadius: 17)
                                    .stroke(
                                        stepState(step) == "Today"
                                            ? GoobyPalette.gold
                                            : Color.clear,
                                        lineWidth: 2
                                    )
                            }
                            .accessibilityElement(children: .combine)
                            .accessibilityLabel("Visit \(step), \(reward) carrots")
                            .accessibilityValue(stepState(step))
                        }
                    }

                    Label(
                        "Visit seven includes the Moon Crown. If it is already owned, it becomes \(GameEngine.duplicateMoonCrownCarrots) carrots.",
                        systemImage: "moon.stars.fill"
                    )
                    .font(.subheadline)
                    .foregroundStyle(.secondary)
                    .progressionCard()

                    Button(claimTitle) {
                        Task { await store.dispatch(.claimDailyReward) }
                    }
                    .buttonStyle(ProgressionPrimaryButtonStyle())
                    .disabled(!canClaim)
                    .accessibilityIdentifier("daily.claim")
                    .accessibilityHint(canClaim ? "Claims today’s offline gift once" : message)
                }
                .padding(18)
            }
        }
        .navigationTitle("Daily Gift")
        .toolbar { SheetCloseToolbar() }
    }

    private var canClaim: Bool {
        if case .eligible = eligibility { return true }
        return false
    }

    private var claimTitle: String {
        switch eligibility {
        case let .eligible(step): "Claim Visit \(step)"
        case .alreadyClaimed: "Claimed Today"
        case .clockRollback: "Date Check Needed"
        }
    }

    private var message: String {
        switch eligibility {
        case let .eligible(step):
            step == 1
                ? "A fresh seven-visit gift path begins today."
                : "Visit \(step) is ready whenever you are."
        case .alreadyClaimed:
            "Today’s gift is already tucked away."
        case .clockRollback:
            "The device date is earlier than the last claim. Gifts resume when the dates match."
        }
    }

    private func stepState(_ step: Int) -> String {
        switch eligibility {
        case let .eligible(today):
            if step < today { return "Claimed" }
            if step == today { return "Today" }
            return "Upcoming"
        case let .alreadyClaimed(claimed):
            return step <= claimed ? "Claimed" : "Upcoming"
        case .clockRollback:
            return "Waiting for device date"
        }
    }
}

struct ShopItemRow: View {
    let item: CatalogItem
    let state: GameState

    var body: some View {
        HStack(spacing: 12) {
            Image(systemName: itemSymbol)
                .font(.title3)
                .foregroundStyle(GoobyPalette.coral)
                .frame(width: 34)
                .accessibilityHidden(true)
            VStack(alignment: .leading, spacing: 3) {
                Text(item.name)
                    .font(.headline)
                    .foregroundStyle(.primary)
                Text(status)
                    .font(.caption)
                    .foregroundStyle(statusColor)
            }
            Spacer()
            Text(priceLabel)
                .font(.subheadline.weight(.bold))
                .foregroundStyle(.secondary)
            Image(systemName: "chevron.right")
                .font(.caption.weight(.bold))
                .foregroundStyle(.tertiary)
        }
        .frame(minHeight: 50)
        .contentShape(Rectangle())
        .accessibilityElement(children: .combine)
        .accessibilityLabel(item.name)
        .accessibilityValue("\(status), \(priceLabel)")
    }

    private var itemSymbol: String {
        if case .food = item.kind { return "fork.knife" }
        return "sparkles"
    }

    private var priceLabel: String {
        item.acquisition == .shop ? "\(item.price) 🥕" : "Unlock"
    }

    private var status: String {
        if case .food = item.kind {
            if state.bondLevel < item.requiredBondLevel {
                return "Locked • bond level \(item.requiredBondLevel)"
            }
            return "In pantry: \(state.foodQuantity(item.id))"
        }
        if state.ownedItems.contains(item.id) { return "Owned" }
        switch item.acquisition {
        case let .bond(level): return "Locked • bond level \(level)"
        case let .daily(step): return "Locked • daily visit \(step)"
        case .shop, .legacy:
            if state.bondLevel < item.requiredBondLevel {
                return "Locked • bond level \(item.requiredBondLevel)"
            }
            return state.carrots < item.price ? "Not enough carrots" : "Available"
        }
    }

    private var statusColor: Color {
        status == "Owned" ? GoobyPalette.mint : .secondary
    }
}

struct ShopItemDetailView: View {
    @Bindable var store: GameStore
    let state: GameState
    let item: CatalogItem
    @Environment(\.dismiss) private var dismiss

    private var currentState: GameState { store.state ?? state }

    var body: some View {
        ZStack {
            ProgressionBackground()
            ScrollView {
                VStack(spacing: 18) {
                    if case .cosmetic = item.kind {
                        GoobyRealityView(
                            state: previewState,
                            events: [],
                            eventRevision: 0,
                            isPreview: true,
                            onPet: {}
                        )
                        .frame(height: 290)
                        .goobySurface(
                            in: RoundedRectangle(cornerRadius: 25),
                            strong: true
                        )
                        .overlay {
                            RoundedRectangle(cornerRadius: 25)
                                .stroke(GoobyPalette.border.opacity(0.55), lineWidth: 2)
                        }
                        .accessibilityIdentifier("shop.preview.scene")
                        Text("Previewing \(item.name)")
                            .font(.caption.weight(.semibold))
                            .foregroundStyle(.secondary)
                            .accessibilityIdentifier("shop.preview")
                    } else {
                        Image(systemName: "carrot.fill")
                            .font(.system(size: 64))
                            .foregroundStyle(GoobyPalette.coral)
                            .padding(32)
                            .goobySurface(in: Circle())
                    }
                    VStack(spacing: 8) {
                        Text(item.name)
                            .font(.system(.title, design: .rounded, weight: .black))
                        Text(item.description)
                            .multilineTextAlignment(.center)
                            .foregroundStyle(.secondary)
                        Text(detailStatus)
                            .font(.headline)
                            .foregroundStyle(canBuy ? GoobyPalette.ink : .secondary)
                        Text("Balance: \(currentState.carrots) carrots")
                            .font(.subheadline.weight(.semibold))
                            .accessibilityIdentifier("shop.detail.balance")
                    }

                    if item.acquisition == .shop || item.acquisition == .legacy {
                        Button(buyTitle) {
                            Task { await store.dispatch(.purchase(itemID: item.id)) }
                        }
                        .buttonStyle(ProgressionPrimaryButtonStyle())
                        .disabled(!canBuy)
                        .accessibilityIdentifier("shop.buy.\(item.id.rawValue)")
                        .accessibilityHint(detailStatus)
                        if isOwnedCosmetic {
                            Label(
                                "\(item.name) is saved permanently.",
                                systemImage: "checkmark.seal.fill"
                            )
                            .font(.subheadline.weight(.bold))
                            .foregroundStyle(GoobyPalette.mint)
                            .accessibilityIdentifier("shop.purchase.confirmation")
                            .accessibilityAddTraits(.updatesFrequently)
                        }
                    } else {
                        Label(unlockDescription, systemImage: "lock.fill")
                            .font(.subheadline.weight(.semibold))
                            .progressionCard()
                    }
                }
                .padding(18)
            }
        }
        .navigationTitle("Item Details")
        .navigationBarTitleDisplayMode(.inline)
        .navigationBarBackButtonHidden()
        .toolbar {
            ToolbarItem(placement: .topBarLeading) {
                Button {
                    dismiss()
                } label: {
                    Label("Back", systemImage: "chevron.left")
                }
                .accessibilityIdentifier("item-detail.back")
            }
        }
    }

    private var previewState: GameState {
        var preview = currentState
        if case let .cosmetic(slot) = item.kind {
            preview.equippedCosmetics[slot] = item.id
        }
        return preview
    }

    private var isOwnedCosmetic: Bool {
        if case .cosmetic = item.kind {
            return currentState.ownedItems.contains(item.id)
        }
        return false
    }

    private var canBuy: Bool {
        !isOwnedCosmetic
            && currentState.bondLevel >= item.requiredBondLevel
            && currentState.carrots >= item.price
            && (item.acquisition == .shop || item.acquisition == .legacy)
    }

    private var buyTitle: String {
        if isOwnedCosmetic { return "Owned" }
        if case .food = item.kind {
            return "Buy One • \(item.price) carrots"
        }
        return "Buy • \(item.price) carrots"
    }

    private var detailStatus: String {
        if isOwnedCosmetic { return "Owned permanently" }
        if currentState.bondLevel < item.requiredBondLevel {
            return "Unlocks at bond level \(item.requiredBondLevel)"
        }
        if currentState.carrots < item.price {
            return "Needs \(item.price - currentState.carrots) more carrots"
        }
        if case .food = item.kind {
            return "Pantry quantity: \(currentState.foodQuantity(item.id))"
        }
        return "Ready to add permanently"
    }

    private var unlockDescription: String {
        switch item.acquisition {
        case let .bond(level): "Reach bond level \(level) to unlock this keepsake."
        case let .daily(step): "Claim visit \(step) of the daily gift cycle."
        case .shop, .legacy: ""
        }
    }
}

struct WardrobeView: View {
    @Bindable var store: GameStore
    let state: GameState
    @State private var selectedID = GoobyCatalog.sunshineBow
    @Environment(\.dynamicTypeSize) private var dynamicTypeSize

    private var currentState: GameState { store.state ?? state }
    private var selected: CatalogItem {
        GoobyCatalog.item(id: selectedID) ?? GoobyCatalog.cosmetics[0]
    }

    var body: some View {
        ZStack {
            ProgressionBackground()
            ScrollView {
                VStack(spacing: 16) {
                    GoobyRealityView(
                        state: previewState,
                        events: [],
                        eventRevision: 0,
                        isPreview: true,
                        onPet: {}
                    )
                    .frame(height: 300)
                    .goobySurface(
                        in: RoundedRectangle(cornerRadius: 25),
                        strong: true
                    )
                    .overlay {
                        RoundedRectangle(cornerRadius: 25)
                            .stroke(GoobyPalette.border.opacity(0.55), lineWidth: 2)
                    }
                    .accessibilityIdentifier("wardrobe.preview")

                    ScrollView(.horizontal) {
                        HStack(spacing: 10) {
                            ForEach(GoobyCatalog.cosmetics) { item in
                                Button {
                                    selectedID = item.id
                                } label: {
                                    VStack(spacing: 5) {
                                        Image(
                                            systemName: item.id == selectedID
                                                ? "checkmark.circle.fill"
                                                : currentState.ownedItems.contains(item.id)
                                                    ? "sparkles"
                                                    : "lock.fill"
                                        )
                                        Text(item.name)
                                            .font(.caption.weight(.bold))
                                            .multilineTextAlignment(.center)
                                    }
                                    .frame(
                                        width: dynamicTypeSize.isAccessibilitySize ? 180 : 94,
                                        height: dynamicTypeSize.isAccessibilitySize ? 112 : 70
                                    )
                                    .background(
                                        item.id == selectedID
                                            ? GoobyPalette.sky.opacity(0.25)
                                            : GoobyPalette.surface,
                                        in: RoundedRectangle(cornerRadius: 15)
                                    )
                                    .overlay {
                                        RoundedRectangle(cornerRadius: 15)
                                            .stroke(
                                                item.id == selectedID
                                                    ? GoobyPalette.sky
                                                    : GoobyPalette.border.opacity(0.35),
                                                lineWidth: item.id == selectedID ? 3 : 1
                                            )
                                    }
                                }
                                .buttonStyle(.plain)
                                .accessibilityAddTraits(
                                    item.id == selectedID ? .isSelected : []
                                )
                                .accessibilityIdentifier("wardrobe.item.\(item.id.rawValue)")
                                .accessibilityLabel(item.name)
                                .accessibilityValue(itemState(item))
                            }
                        }
                    }
                    .scrollIndicators(.hidden)

                    VStack(spacing: 8) {
                        Text(selected.name)
                            .font(.system(.title2, design: .rounded, weight: .black))
                        Text(selected.description)
                            .multilineTextAlignment(.center)
                            .foregroundStyle(.secondary)
                        Text(itemState(selected))
                            .font(.subheadline.weight(.bold))
                    }
                    .progressionCard()

                    if isSelectedEquipped, case let .cosmetic(slot) = selected.kind {
                        Button("Unequip \(selected.name)") {
                            Task { await store.dispatch(.unequip(slot: slot)) }
                        }
                        .buttonStyle(ProgressionSecondaryButtonStyle())
                        .accessibilityIdentifier("wardrobe.unequip")
                    } else {
                        Button("Equip \(selected.name)") {
                            Task { await store.dispatch(.equip(itemID: selected.id)) }
                        }
                        .buttonStyle(ProgressionPrimaryButtonStyle())
                        .disabled(!currentState.ownedItems.contains(selected.id))
                        .accessibilityIdentifier("wardrobe.equip")
                        .accessibilityHint(itemState(selected))
                    }
                    if isSelectedEquipped {
                        Label(
                            "\(selected.name) is equipped and saved.",
                            systemImage: "checkmark.seal.fill"
                        )
                        .font(.subheadline.weight(.bold))
                        .foregroundStyle(GoobyPalette.mint)
                        .accessibilityIdentifier("wardrobe.confirmation")
                        .accessibilityAddTraits(.updatesFrequently)
                    }
                }
                .padding(18)
            }
        }
        .navigationTitle("Wardrobe")
        .toolbar { SheetCloseToolbar() }
    }

    private var previewState: GameState {
        var preview = currentState
        if case let .cosmetic(slot) = selected.kind {
            preview.equippedCosmetics[slot] = selected.id
        }
        return preview
    }

    private var isSelectedEquipped: Bool {
        guard case let .cosmetic(slot) = selected.kind else { return false }
        return currentState.equippedCosmetics[slot] == selected.id
    }

    private func itemState(_ item: CatalogItem) -> String {
        guard currentState.ownedItems.contains(item.id) else {
            switch item.acquisition {
            case let .bond(level): return "Locked until bond level \(level)"
            case let .daily(step): return "Locked until daily visit \(step)"
            case .shop, .legacy: return "Locked • available in the shop"
            }
        }
        guard case let .cosmetic(slot) = item.kind else { return "Owned" }
        return currentState.equippedCosmetics[slot] == item.id ? "Owned and equipped" : "Owned"
    }
}

struct SettingsView: View {
    @Bindable var store: GameStore
    let state: GameState
    @Environment(\.accessibilityReduceMotion) private var systemReduceMotion
    @Environment(\.dismiss) private var dismiss
    @State private var petName = ""
    @State private var confirmsReset = false

    private var currentState: GameState { store.state ?? state }

    var body: some View {
        Form {
            Section("Gooby’s name") {
                TextField("Pet name", text: $petName)
                    .textInputAutocapitalization(.words)
                    .autocorrectionDisabled()
                    .accessibilityIdentifier("settings.pet-name")
                Text("\(petName.count)/\(GamePreferences.maximumPetNameLength) characters")
                    .font(.caption)
                    .foregroundStyle(.secondary)
                Button("Save Name") {
                    Task {
                        if await store.dispatch(.renamePet(petName)) {
                            petName = currentState.preferences.petName
                        }
                    }
                }
                .disabled(
                    petName.trimmingCharacters(in: .whitespacesAndNewlines).isEmpty
                        || petName.trimmingCharacters(in: .whitespacesAndNewlines).count
                            > GamePreferences.maximumPetNameLength
                )
                .accessibilityIdentifier("settings.save-name")
            }

            Section("Feedback") {
                Toggle(
                    "Sound",
                    isOn: Binding(
                        get: { currentState.preferences.soundEnabled },
                        set: { enabled in
                            Task { await store.dispatch(.setSoundEnabled(enabled)) }
                        }
                    )
                )
                Toggle(
                    "Haptics",
                    isOn: Binding(
                        get: { currentState.preferences.hapticsEnabled },
                        set: { enabled in
                            Task { await store.dispatch(.setHapticsEnabled(enabled)) }
                        }
                    )
                )
                Toggle(
                    "Reduce Motion in Gooby",
                    isOn: Binding(
                        get: { currentState.preferences.reduceMotionEnabled },
                        set: { enabled in
                            Task { await store.dispatch(.setReduceMotionEnabled(enabled)) }
                        }
                    )
                )
                Text(
                    systemReduceMotion
                        ? "iOS Reduce Motion is on. Gooby also uses gentle fades."
                        : "Gooby honors the iOS Reduce Motion setting. This switch can request gentle fades only inside Gooby."
                )
                .font(.caption)
                .foregroundStyle(.secondary)
            }

            Section("Privacy & about") {
                Label("Works fully offline", systemImage: "airplane")
                Label("No tracking or analytics", systemImage: "hand.raised.fill")
                Label("No ads or in-app purchases", systemImage: "heart.fill")
                Text("Gooby stores care progress only on this device.")
                    .font(.caption)
                    .foregroundStyle(.secondary)
            }

            Section {
                Button("Reset All Progress", role: .destructive) {
                    confirmsReset = true
                }
                .accessibilityIdentifier("settings.reset")
            } footer: {
                Text("This deletes local care, carrots, food, rewards, and wardrobe progress.")
            }
        }
        .navigationTitle("Settings")
        .toolbar { SheetCloseToolbar() }
        .onAppear {
            petName = currentState.preferences.petName
        }
        .alert("Reset all progress?", isPresented: $confirmsReset) {
            Button("Cancel", role: .cancel) {}
            Button("Reset", role: .destructive) {
                Task {
                    if await store.resetProgress() {
                        dismiss()
                    }
                }
            }
        } message: {
            Text("This cannot be undone. Gooby will begin again with the starter pantry.")
        }
    }
}

private struct SheetCloseToolbar: ToolbarContent {
    @Environment(\.dismiss) private var dismiss
    let identifier: String

    init(identifier: String = "sheet.close") {
        self.identifier = identifier
    }

    var body: some ToolbarContent {
        ToolbarItem(placement: .confirmationAction) {
            Button("Close") { dismiss() }
                .accessibilityIdentifier(identifier)
        }
    }
}

private struct ProgressionBackground: View {
    var body: some View {
        LinearGradient(
            colors: [
                GoobyPalette.cream,
                GoobyPalette.apricot.opacity(0.38),
                GoobyPalette.sky.opacity(0.24),
            ],
            startPoint: .topLeading,
            endPoint: .bottomTrailing
        )
        .ignoresSafeArea()
    }
}

private struct ProgressionPrimaryButtonStyle: ButtonStyle {
    func makeBody(configuration: Configuration) -> some View {
        configuration.label
            .font(.system(.headline, design: .rounded, weight: .bold))
            .foregroundStyle(.white)
            .padding(.horizontal, 16)
            .frame(maxWidth: .infinity, minHeight: 52)
            .background(
                GoobyPalette.action.opacity(configuration.isPressed ? 0.78 : 1),
                in: RoundedRectangle(cornerRadius: 17)
            )
    }
}

private struct ProgressionSecondaryButtonStyle: ButtonStyle {
    @Environment(\.accessibilityReduceTransparency) private var reduceTransparency

    func makeBody(configuration: Configuration) -> some View {
        configuration.label
            .font(.system(.headline, design: .rounded, weight: .bold))
            .foregroundStyle(GoobyPalette.ink)
            .padding(.horizontal, 16)
            .frame(maxWidth: .infinity, minHeight: 52)
            .background(
                reduceTransparency
                    ? GoobyPalette.strongSurface
                    : GoobyPalette.surface.opacity(configuration.isPressed ? 0.76 : 0.92),
                in: RoundedRectangle(cornerRadius: 17)
            )
            .overlay {
                RoundedRectangle(cornerRadius: 17)
                    .stroke(GoobyPalette.border.opacity(0.45), lineWidth: 1)
            }
    }
}

private extension View {
    func progressionCard() -> some View {
        padding(15)
            .frame(maxWidth: .infinity)
            .goobySurface(in: RoundedRectangle(cornerRadius: 20))
    }
}
