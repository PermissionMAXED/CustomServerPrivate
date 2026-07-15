import GoobyCore
import RealityKit
import SwiftUI
import UIKit

@MainActor
final class GoobySceneCoordinator {
    let stage = Entity()

    private(set) var gooby = Entity()
    private var roomRoot: Entity?
    private var currentRoom: RoomID?
    private var idleTask: Task<Void, Never>?
    private var reactionTask: Task<Void, Never>?
    private var lastEventRevision = -1
    private var reduceMotion = false
    private var idleStep = 0

    func prepare(room: RoomID, reduceMotion: Bool) {
        guard gooby.parent == nil else { return }
        stage.name = "gooby.stage"
        gooby = GoobyFactory.makeGooby()
        self.reduceMotion = reduceMotion
        switchRoom(to: room)
        stage.addChild(gooby)
        startIdleLoop()
    }

    func apply(
        state: GameState,
        events: [GameEvent],
        eventRevision: Int,
        reduceMotion: Bool
    ) {
        self.reduceMotion = reduceMotion
        if currentRoom != state.currentRoom {
            switchRoom(to: state.currentRoom)
        }
        applyPose(state)
        applyCosmetics(state.equippedCosmetics)

        guard eventRevision != lastEventRevision else { return }
        lastEventRevision = eventRevision
        guard !reduceMotion, let reaction = events.reversed().first(where: Self.isReaction) else {
            return
        }
        runReaction(reaction)
    }

    func stop() {
        idleTask?.cancel()
        reactionTask?.cancel()
        idleTask = nil
        reactionTask = nil
    }

    private func switchRoom(to room: RoomID) {
        roomRoot?.removeFromParent()
        let builtRoom = GoobyRoomFactory.makeRoom(room)
        roomRoot = builtRoom
        currentRoom = room
        stage.addChild(builtRoom)
    }

    private func applyPose(_ state: GameState) {
        guard let rig = gooby.findEntity(named: GoobyRealityNames.rig) else { return }
        var transform = Transform.identity
        if state.isSleeping {
            transform.rotation = simd_quatf(angle: -0.16, axis: [0, 0, 1])
            transform.translation = [0, -0.18, 0]
            transform.scale = [1.04, 0.94, 1.04]
        } else {
            let average = Float(
                state.needs.fullness.value
                    + state.needs.cleanliness.value
                    + state.needs.energy.value
                    + state.needs.fun.value
            ) / 4_000
            transform.translation.y = average < 0.45 ? -0.08 : 0
            transform.rotation = simd_quatf(
                angle: average < 0.45 ? 0.05 : 0,
                axis: [0, 0, 1]
            )
        }
        rig.transform = transform
    }

    private func applyCosmetics(_ cosmetics: EquippedCosmetics) {
        let head = gooby.findEntity(named: GoobyRealityNames.headAnchor)
        let neck = gooby.findEntity(named: GoobyRealityNames.neckAnchor)
        let paws = gooby.findEntity(named: GoobyRealityNames.pawsAnchor)
        [head, neck, paws].compactMap { $0 }.forEach { anchor in
            for child in anchor.children {
                child.removeFromParent()
            }
        }

        if cosmetics.head == GoobyCatalog.cozyBow, let head {
            let bow = Entity()
            bow.name = "cosmetic.cozy-bow"
            let material = GoobyFactory.clay(red: 0.72, green: 0.27, blue: 0.31)
            bow.addChild(
                GoobyFactory.ellipsoid(
                    "cosmetic.cozy-bow.left",
                    scale: [0.22, 0.16, 0.10],
                    position: [-0.18, 0, 0],
                    material: material
                )
            )
            bow.addChild(
                GoobyFactory.ellipsoid(
                    "cosmetic.cozy-bow.right",
                    scale: [0.22, 0.16, 0.10],
                    position: [0.18, 0, 0],
                    material: material
                )
            )
            bow.addChild(
                GoobyFactory.ellipsoid(
                    "cosmetic.cozy-bow.knot",
                    scale: [0.13, 0.13, 0.10],
                    position: [0, 0, 0.03],
                    material: material
                )
            )
            head.addChild(bow)
        } else if cosmetics.head == GoobyCatalog.moonCap, let head {
            let cap = GoobyFactory.ellipsoid(
                "cosmetic.moon-cap",
                scale: [0.48, 0.18, 0.40],
                position: [0, 0, 0],
                material: GoobyFactory.clay(red: 0.25, green: 0.33, blue: 0.55)
            )
            head.addChild(cap)
        }

        if cosmetics.neck == GoobyCatalog.sunnyScarf, let neck {
            neck.addChild(
                GoobyFactory.cylinder(
                    "cosmetic.sunny-scarf",
                    height: 0.12,
                    radius: 0.48,
                    position: [0, 0, 0],
                    material: GoobyFactory.clay(red: 0.95, green: 0.68, blue: 0.24)
                )
            )
        }

        if cosmetics.paws == GoobyCatalog.cloudSlippers, let paws {
            let material = GoobyFactory.clay(red: 0.67, green: 0.82, blue: 0.88)
            paws.addChild(
                GoobyFactory.ellipsoid(
                    "cosmetic.cloud-slippers.left",
                    scale: [0.28, 0.14, 0.27],
                    position: [-0.40, -0.71, 0],
                    material: material
                )
            )
            paws.addChild(
                GoobyFactory.ellipsoid(
                    "cosmetic.cloud-slippers.right",
                    scale: [0.28, 0.14, 0.27],
                    position: [0.40, -0.71, 0],
                    material: material
                )
            )
        }
    }

    private func startIdleLoop() {
        guard idleTask == nil else { return }
        idleTask = Task { [weak self] in
            while !Task.isCancelled {
                try? await Task.sleep(for: .seconds(3.2))
                guard !Task.isCancelled, let self else { return }
                self.runIdleBeat()
            }
        }
    }

    private func runIdleBeat() {
        guard !reduceMotion else { return }
        idleStep = (idleStep + 1) % 4
        switch idleStep {
        case 0: breathe()
        case 1: blink()
        case 2: earFlick()
        default: blink()
        }
    }

    private func breathe() {
        guard let torso = gooby.findEntity(named: GoobyRealityNames.torso) else { return }
        let original = torso.transform
        var expanded = original
        expanded.scale *= [1.025, 1.018, 1.025]
        torso.move(to: expanded, relativeTo: torso.parent, duration: 0.55, timingFunction: .easeInOut)
        Task { @MainActor [weak torso] in
            try? await Task.sleep(for: .milliseconds(560))
            torso?.move(
                to: original,
                relativeTo: torso?.parent,
                duration: 0.55,
                timingFunction: .easeInOut
            )
        }
    }

    private func blink() {
        let eyes = [
            gooby.findEntity(named: GoobyRealityNames.eyeLeft),
            gooby.findEntity(named: GoobyRealityNames.eyeRight),
        ].compactMap { $0 }
        let originals = eyes.map(\.transform)
        for (eye, original) in zip(eyes, originals) {
            var closed = original
            closed.scale.y = max(0.02, original.scale.y * 0.08)
            eye.move(to: closed, relativeTo: eye.parent, duration: 0.08, timingFunction: .easeInOut)
        }
        Task { @MainActor in
            try? await Task.sleep(for: .milliseconds(100))
            for (eye, original) in zip(eyes, originals) {
                eye.move(
                    to: original,
                    relativeTo: eye.parent,
                    duration: 0.10,
                    timingFunction: .easeInOut
                )
            }
        }
    }

    private func earFlick() {
        guard let ear = gooby.findEntity(named: GoobyRealityNames.earLeft) else { return }
        let original = ear.transform
        var flicked = original
        flicked.rotation *= simd_quatf(angle: -0.11, axis: [0, 0, 1])
        ear.move(to: flicked, relativeTo: ear.parent, duration: 0.16, timingFunction: .easeInOut)
        Task { @MainActor [weak ear] in
            try? await Task.sleep(for: .milliseconds(180))
            ear?.move(
                to: original,
                relativeTo: ear?.parent,
                duration: 0.20,
                timingFunction: .easeInOut
            )
        }
    }

    private func runReaction(_ event: GameEvent) {
        guard let rig = gooby.findEntity(named: GoobyRealityNames.rig) else { return }
        reactionTask?.cancel()
        let original = rig.transform
        var target = original
        let duration: Double

        switch event {
        case .fed:
            target.rotation *= simd_quatf(angle: 0.13, axis: [1, 0, 0])
            target.translation.z += 0.10
            duration = 0.22
        case .washed:
            target.rotation *= simd_quatf(angle: 0.20, axis: [0, 1, 0])
            duration = 0.12
        case .petted:
            target.rotation *= simd_quatf(angle: 0.14, axis: [0, 0, 1])
            target.translation.x += 0.07
            duration = 0.25
        case .played:
            target.translation.y += 0.32
            target.scale = [0.96, 1.05, 0.96]
            duration = 0.24
        case .sleepChanged:
            target.scale *= [1.02, 0.96, 1.02]
            duration = 0.30
        default:
            return
        }

        rig.move(to: target, relativeTo: rig.parent, duration: duration, timingFunction: .easeInOut)
        reactionTask = Task { @MainActor [weak rig] in
            try? await Task.sleep(for: .seconds(duration + 0.04))
            guard !Task.isCancelled else { return }
            rig?.move(
                to: original,
                relativeTo: rig?.parent,
                duration: duration,
                timingFunction: .easeInOut
            )
        }
    }

    private static func isReaction(_ event: GameEvent) -> Bool {
        switch event {
        case .fed, .washed, .petted, .played, .sleepChanged: true
        default: false
        }
    }
}

struct GoobyRealityView: View {
    let state: GameState
    let events: [GameEvent]
    let eventRevision: Int
    let onPet: () -> Void

    @Environment(\.accessibilityReduceMotion) private var reduceMotion
    @State private var coordinator = GoobySceneCoordinator()

    var body: some View {
        Group {
            if #available(iOS 18.0, *) {
                modernRealityView
            } else {
                GoobyLegacyRealityView(
                    state: state,
                    events: events,
                    eventRevision: eventRevision,
                    reduceMotion: reduceMotion,
                    coordinator: coordinator,
                    onPet: onPet
                )
            }
        }
        .onDisappear {
            coordinator.stop()
        }
        .accessibilityHidden(true)
    }

    @available(iOS 18.0, *)
    private var modernRealityView: some View {
        RealityView { content in
            coordinator.prepare(room: state.currentRoom, reduceMotion: reduceMotion)
            content.add(coordinator.stage)
        } update: { _ in
            coordinator.apply(
                state: state,
                events: events,
                eventRevision: eventRevision,
                reduceMotion: reduceMotion
            )
        }
        .gesture(
            SpatialTapGesture()
                .targetedToAnyEntity()
                .onEnded { _ in onPet() }
        )
    }
}

private struct GoobyLegacyRealityView: UIViewRepresentable {
    let state: GameState
    let events: [GameEvent]
    let eventRevision: Int
    let reduceMotion: Bool
    let coordinator: GoobySceneCoordinator
    let onPet: () -> Void

    func makeCoordinator() -> TapCoordinator {
        TapCoordinator(onPet: onPet)
    }

    func makeUIView(context: Context) -> ARView {
        let view = ARView(
            frame: .zero,
            cameraMode: .nonAR,
            automaticallyConfigureSession: false
        )
        view.environment.background = .color(.clear)
        view.cameraTransform = Transform(translation: [0, 1.65, 4.35])
        coordinator.prepare(room: state.currentRoom, reduceMotion: reduceMotion)

        let anchor = AnchorEntity(world: .zero)
        anchor.name = "gooby.legacy-anchor"
        anchor.addChild(coordinator.stage)
        view.scene.addAnchor(anchor)

        let tap = UITapGestureRecognizer(
            target: context.coordinator,
            action: #selector(TapCoordinator.didTap)
        )
        view.addGestureRecognizer(tap)
        return view
    }

    func updateUIView(_: ARView, context: Context) {
        context.coordinator.onPet = onPet
        coordinator.apply(
            state: state,
            events: events,
            eventRevision: eventRevision,
            reduceMotion: reduceMotion
        )
    }

    final class TapCoordinator: NSObject {
        var onPet: () -> Void

        init(onPet: @escaping () -> Void) {
            self.onPet = onPet
        }

        @objc func didTap() {
            onPet()
        }
    }
}
