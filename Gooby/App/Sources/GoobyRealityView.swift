import Combine
import Foundation
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
    private var consumedEventCount = 0
    private var reactionQueue: [GameEvent] = []
    private var reduceMotion = false
    private var idleStep = 0

    func prepare(room: RoomID, reduceMotion: Bool) {
        self.reduceMotion = reduceMotion
        guard gooby.parent == nil else {
            startIdleLoop()
            return
        }
        stage.name = "gooby.stage"
        gooby = GoobyFactory.makeGooby()
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
        if events.count < consumedEventCount {
            consumedEventCount = 0
        }
        let newEvents = events.dropFirst(consumedEventCount)
        consumedEventCount = events.count
        guard !reduceMotion else { return }
        reactionQueue.append(contentsOf: newEvents.filter(Self.isReaction))
        startNextReactionIfNeeded()
    }

    func stop() {
        idleTask?.cancel()
        reactionTask?.cancel()
        idleTask = nil
        reactionTask = nil
        reactionQueue = []
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
        let face = gooby.findEntity(named: GoobyRealityNames.faceAnchor)
        let body = gooby.findEntity(named: GoobyRealityNames.bodyAnchor)
        let paws = gooby.findEntity(named: GoobyRealityNames.pawsAnchor)
        [head, neck, face, body, paws].compactMap { $0 }.forEach { anchor in
            for child in anchor.children {
                child.removeFromParent()
            }
        }

        if cosmetics.head == GoobyCatalog.cloudCap, let head {
            let cap = Entity()
            cap.name = "cosmetic.cloud-cap"
            cap.addChild(
                GoobyFactory.ellipsoid(
                    "cosmetic.cloud-cap.crown",
                    scale: [0.52, 0.22, 0.44],
                    position: [0, 0.20, 0],
                    material: GoobyFactory.clay(red: 0.48, green: 0.72, blue: 0.86)
                )
            )
            cap.addChild(
                GoobyFactory.ellipsoid(
                    "cosmetic.cloud-cap.puff",
                    scale: [0.16, 0.13, 0.13],
                    position: [0.28, 0.34, 0.02],
                    material: GoobyFactory.clay(red: 0.95, green: 0.96, blue: 0.92)
                )
            )
            head.addChild(cap)
        } else if cosmetics.head == GoobyCatalog.moonCrown, let head {
            let crown = Entity()
            crown.name = "cosmetic.moon-crown"
            let silver = GoobyFactory.clay(red: 0.82, green: 0.86, blue: 0.93)
            crown.addChild(
                GoobyFactory.cylinder(
                    "cosmetic.moon-crown.band",
                    height: 0.12,
                    radius: 0.38,
                    position: [0, 0.28, 0],
                    material: silver
                )
            )
            for (index, x) in [-0.25, 0.0, 0.25].enumerated() {
                crown.addChild(
                    GoobyFactory.box(
                        "cosmetic.moon-crown.point.\(index)",
                        size: [0.14, index == 1 ? 0.38 : 0.29, 0.12],
                        position: [Float(x), index == 1 ? 0.51 : 0.47, 0.05],
                        material: silver,
                        cornerRadius: 0.035
                    )
                )
            }
            crown.addChild(
                GoobyFactory.ellipsoid(
                    "cosmetic.moon-crown.gem",
                    scale: [0.09, 0.09, 0.06],
                    position: [0, 0.56, 0.11],
                    material: GoobyFactory.clay(red: 0.98, green: 0.76, blue: 0.25)
                )
            )
            head.addChild(crown)
        } else if cosmetics.head == GoobyCatalog.cozyBow, let head {
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

        if cosmetics.neck == GoobyCatalog.sunshineBow, let neck {
            neck.addChild(
                makeBow(
                    name: "cosmetic.sunshine-bow",
                    color: (0.97, 0.70, 0.20)
                )
            )
        } else if cosmetics.neck == GoobyCatalog.friendshipRibbon, let neck {
            let ribbon = makeBow(
                name: "cosmetic.friendship-ribbon",
                color: (0.88, 0.34, 0.48)
            )
            ribbon.addChild(
                GoobyFactory.box(
                    "cosmetic.friendship-ribbon.tail.left",
                    size: [0.12, 0.34, 0.06],
                    position: [-0.10, -0.22, 0],
                    material: GoobyFactory.clay(red: 0.88, green: 0.34, blue: 0.48),
                    cornerRadius: 0.03
                )
            )
            ribbon.addChild(
                GoobyFactory.box(
                    "cosmetic.friendship-ribbon.tail.right",
                    size: [0.12, 0.34, 0.06],
                    position: [0.10, -0.22, 0],
                    material: GoobyFactory.clay(red: 0.88, green: 0.34, blue: 0.48),
                    cornerRadius: 0.03
                )
            )
            neck.addChild(ribbon)
        } else if cosmetics.neck == GoobyCatalog.sunnyScarf, let neck {
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

        if cosmetics.face == GoobyCatalog.roundSpecs, let face {
            let specs = Entity()
            specs.name = "cosmetic.round-specs"
            let frame = GoobyFactory.clay(red: 0.36, green: 0.25, blue: 0.19)
            let lens = GoobyFactory.clay(red: 0.72, green: 0.88, blue: 0.92)
            for (index, x) in [Float(-0.28), Float(0.28)].enumerated() {
                specs.addChild(
                    GoobyFactory.ellipsoid(
                        "cosmetic.round-specs.frame.\(index)",
                        scale: [0.22, 0.22, 0.045],
                        position: [x, 0, 0],
                        material: frame
                    )
                )
                specs.addChild(
                    GoobyFactory.ellipsoid(
                        "cosmetic.round-specs.lens.\(index)",
                        scale: [0.17, 0.17, 0.052],
                        position: [x, 0, 0.03],
                        material: lens
                    )
                )
            }
            specs.addChild(
                GoobyFactory.box(
                    "cosmetic.round-specs.bridge",
                    size: [0.18, 0.055, 0.055],
                    position: [0, 0, 0],
                    material: frame,
                    cornerRadius: 0.02
                )
            )
            face.addChild(specs)
        }

        if cosmetics.body == GoobyCatalog.starCape, let body {
            let cape = Entity()
            cape.name = "cosmetic.star-cape"
            cape.addChild(
                GoobyFactory.box(
                    "cosmetic.star-cape.cloth",
                    size: [1.22, 1.20, 0.12],
                    position: [0, -0.12, 0],
                    material: GoobyFactory.clay(red: 0.20, green: 0.25, blue: 0.52),
                    cornerRadius: 0.14
                )
            )
            let star = GoobyFactory.clay(red: 0.98, green: 0.76, blue: 0.24)
            cape.addChild(
                GoobyFactory.ellipsoid(
                    "cosmetic.star-cape.star",
                    scale: [0.17, 0.17, 0.08],
                    position: [0, 0.22, 0.10],
                    material: star
                )
            )
            body.addChild(cape)
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

    private func makeBow(
        name: String,
        color: (CGFloat, CGFloat, CGFloat)
    ) -> Entity {
        let bow = Entity()
        bow.name = name
        let material = GoobyFactory.clay(red: color.0, green: color.1, blue: color.2)
        bow.addChild(
            GoobyFactory.ellipsoid(
                "\(name).left",
                scale: [0.25, 0.18, 0.09],
                position: [-0.21, 0, 0],
                material: material
            )
        )
        bow.addChild(
            GoobyFactory.ellipsoid(
                "\(name).right",
                scale: [0.25, 0.18, 0.09],
                position: [0.21, 0, 0],
                material: material
            )
        )
        bow.addChild(
            GoobyFactory.ellipsoid(
                "\(name).knot",
                scale: [0.14, 0.14, 0.10],
                position: [0, 0, 0.04],
                material: material
            )
        )
        return bow
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

    private func startNextReactionIfNeeded() {
        guard reactionTask == nil, !reactionQueue.isEmpty else { return }
        let event = reactionQueue.removeFirst()
        guard let rig = gooby.findEntity(named: GoobyRealityNames.rig) else { return }
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
        reactionTask = Task { @MainActor [weak self, weak rig] in
            try? await Task.sleep(for: .seconds(duration + 0.04))
            guard !Task.isCancelled else { return }
            rig?.move(
                to: original,
                relativeTo: rig?.parent,
                duration: duration,
                timingFunction: .easeInOut
            )
            try? await Task.sleep(for: .seconds(duration))
            guard !Task.isCancelled else { return }
            self?.reactionTask = nil
            self?.startNextReactionIfNeeded()
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
    @State private var isLowPowerModeEnabled = ProcessInfo.processInfo.isLowPowerModeEnabled

    var body: some View {
        Group {
            if #available(iOS 18.0, *) {
                modernRealityView
            } else {
                GoobyLegacyRealityView(
                    state: state,
                    events: events,
                    eventRevision: eventRevision,
                    reduceMotion: shouldReduceMotion,
                    coordinator: coordinator,
                    onPet: onPet
                )
            }
        }
        .onDisappear {
            coordinator.stop()
        }
        .onReceive(
            NotificationCenter.default.publisher(
                for: .NSProcessInfoPowerStateDidChange
            )
        ) { _ in
            isLowPowerModeEnabled = ProcessInfo.processInfo.isLowPowerModeEnabled
        }
        .accessibilityHidden(true)
    }

    @available(iOS 18.0, *)
    private var modernRealityView: some View {
        RealityView { content in
            coordinator.prepare(room: state.currentRoom, reduceMotion: shouldReduceMotion)
            content.add(coordinator.stage)
        } update: { _ in
            coordinator.apply(
                state: state,
                events: events,
                eventRevision: eventRevision,
                reduceMotion: shouldReduceMotion
            )
        }
        .gesture(
            SpatialTapGesture()
                .targetedToAnyEntity()
                .onEnded { _ in onPet() }
        )
    }

    private var shouldReduceMotion: Bool {
        reduceMotion
            || state.preferences.reduceMotionEnabled
            || isLowPowerModeEnabled
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
