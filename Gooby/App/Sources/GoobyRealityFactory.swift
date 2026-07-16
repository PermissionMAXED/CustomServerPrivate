import GoobyCore
import RealityKit
import UIKit

@MainActor
enum GoobyRealityNames {
    static let root = "gooby.root"
    static let rig = "gooby.rig"
    static let torso = "gooby.torso"
    static let belly = "gooby.belly"
    static let head = "gooby.head"
    static let cheekLeft = "gooby.cheek.left"
    static let cheekRight = "gooby.cheek.right"
    static let muzzle = "gooby.muzzle"
    static let earLeft = "gooby.ear.left"
    static let earRight = "gooby.ear.right.folded"
    static let innerEarLeft = "gooby.ear.left.inner"
    static let innerEarRight = "gooby.ear.right.inner"
    static let pawLeft = "gooby.paw.left"
    static let pawRight = "gooby.paw.right"
    static let footLeft = "gooby.foot.left"
    static let footRight = "gooby.foot.right"
    static let tail = "gooby.tail.pom"
    static let eyeLeft = "gooby.eye.left"
    static let eyeRight = "gooby.eye.right"
    static let pupilLeft = "gooby.pupil.left"
    static let pupilRight = "gooby.pupil.right"
    static let catchlightLeft = "gooby.catchlight.left"
    static let catchlightRight = "gooby.catchlight.right"
    static let nose = "gooby.nose"
    static let tooth = "gooby.tooth"
    static let headAnchor = "gooby.anchor.head"
    static let neckAnchor = "gooby.anchor.neck"
    static let faceAnchor = "gooby.anchor.face"
    static let bodyAnchor = "gooby.anchor.body"
    static let pawsAnchor = "gooby.anchor.paws"

    static let requiredHierarchy = [
        root, rig, torso, belly, head, cheekLeft, cheekRight, muzzle,
        earLeft, earRight, innerEarLeft, innerEarRight, pawLeft, pawRight,
        footLeft, footRight, tail, eyeLeft, eyeRight, pupilLeft, pupilRight,
        catchlightLeft, catchlightRight, nose, tooth, headAnchor, neckAnchor,
        faceAnchor, bodyAnchor, pawsAnchor,
    ]
}

@MainActor
enum GoobyFactory {
    private static let cream = clay(red: 0.91, green: 0.75, blue: 0.56)
    private static let apricot = clay(red: 0.82, green: 0.57, blue: 0.39)
    private static let bellyCream = clay(red: 0.98, green: 0.88, blue: 0.70)
    private static let blush = clay(red: 0.94, green: 0.58, blue: 0.57)
    private static let cocoa = clay(red: 0.20, green: 0.12, blue: 0.12)
    private static let white = clay(red: 1.0, green: 0.98, blue: 0.91)

    static func makeGooby() -> Entity {
        let root = Entity()
        root.name = GoobyRealityNames.root

        let rig = Entity()
        rig.name = GoobyRealityNames.rig
        root.addChild(rig)

        let torso = ellipsoid(
            GoobyRealityNames.torso,
            scale: [0.76, 0.92, 0.60],
            position: [0, 0.83, 0],
            material: cream
        )
        if #available(iOS 18.0, *) {
            torso.components.set(InputTargetComponent())
        }
        torso.components.set(
            CollisionComponent(shapes: [.generateSphere(radius: 0.54)])
        )
        rig.addChild(torso)

        torso.addChild(
            ellipsoid(
                GoobyRealityNames.belly,
                scale: [0.49, 0.62, 0.10],
                position: [0, -0.04, 0.54],
                material: bellyCream
            )
        )

        let head = ellipsoid(
            GoobyRealityNames.head,
            scale: [0.82, 0.72, 0.68],
            position: [0, 1.72, 0.04],
            material: apricot
        )
        if #available(iOS 18.0, *) {
            head.components.set(InputTargetComponent())
        }
        head.components.set(
            CollisionComponent(shapes: [.generateSphere(radius: 0.52)])
        )
        rig.addChild(head)

        head.addChild(
            ellipsoid(
                GoobyRealityNames.cheekLeft,
                scale: [0.30, 0.26, 0.18],
                position: [-0.39, -0.10, 0.55],
                material: blush
            )
        )
        head.addChild(
            ellipsoid(
                GoobyRealityNames.cheekRight,
                scale: [0.30, 0.26, 0.18],
                position: [0.39, -0.10, 0.55],
                material: blush
            )
        )
        head.addChild(
            ellipsoid(
                GoobyRealityNames.muzzle,
                scale: [0.39, 0.29, 0.20],
                position: [0, -0.20, 0.61],
                material: bellyCream
            )
        )

        let leftEar = ellipsoid(
            GoobyRealityNames.earLeft,
            scale: [0.25, 0.74, 0.23],
            position: [-0.38, 2.46, -0.02],
            material: apricot
        )
        leftEar.orientation = simd_quatf(angle: -0.15, axis: [0, 0, 1])
        leftEar.addChild(
            ellipsoid(
                GoobyRealityNames.innerEarLeft,
                scale: [0.54, 0.76, 0.12],
                position: [0, 0, 0.48],
                material: blush
            )
        )
        rig.addChild(leftEar)

        let rightEar = Entity()
        rightEar.name = GoobyRealityNames.earRight
        rightEar.position = [0.42, 2.28, 0]
        rightEar.orientation = simd_quatf(angle: 0.52, axis: [0, 0, 1])
        let rightEarBase = ellipsoid(
            "gooby.ear.right.base",
            scale: [0.25, 0.51, 0.23],
            position: [0, 0, 0],
            material: apricot
        )
        let rightEarTip = ellipsoid(
            "gooby.ear.right.tip",
            scale: [0.25, 0.40, 0.23],
            position: [0.22, 0.36, 0],
            material: apricot
        )
        rightEarTip.orientation = simd_quatf(angle: 0.85, axis: [0, 0, 1])
        rightEarBase.addChild(
            ellipsoid(
                GoobyRealityNames.innerEarRight,
                scale: [0.52, 0.72, 0.12],
                position: [0, 0, 0.48],
                material: blush
            )
        )
        rightEar.addChild(rightEarBase)
        rightEar.addChild(rightEarTip)
        rig.addChild(rightEar)

        addFace(to: head)
        addLimbs(to: rig)
        addCosmeticAnchors(to: rig)

        root.position = [0, -0.52, 0]
        return root
    }

    private static func addFace(to head: Entity) {
        for (name, x) in [
            (GoobyRealityNames.eyeLeft, Float(-0.28)),
            (GoobyRealityNames.eyeRight, Float(0.28)),
        ] {
            let eye = ellipsoid(
                name,
                scale: [0.17, 0.22, 0.10],
                position: [x, 0.10, 0.63],
                material: cocoa
            )
            let isLeft = x < 0
            eye.addChild(
                ellipsoid(
                    isLeft ? GoobyRealityNames.pupilLeft : GoobyRealityNames.pupilRight,
                    scale: [0.48, 0.52, 0.18],
                    position: [0, -0.01, 0.47],
                    material: cocoa
                )
            )
            eye.addChild(
                ellipsoid(
                    isLeft ? GoobyRealityNames.catchlightLeft : GoobyRealityNames.catchlightRight,
                    scale: [0.22, 0.22, 0.12],
                    position: [-0.22, 0.24, 0.58],
                    material: white
                )
            )
            head.addChild(eye)
        }

        head.addChild(
            ellipsoid(
                GoobyRealityNames.nose,
                scale: [0.13, 0.09, 0.08],
                position: [0, -0.10, 0.83],
                material: blush
            )
        )
        head.addChild(
            box(
                GoobyRealityNames.tooth,
                size: [0.14, 0.17, 0.06],
                position: [0, -0.36, 0.82],
                material: white,
                cornerRadius: 0.025
            )
        )
    }

    private static func addLimbs(to rig: Entity) {
        rig.addChild(
            ellipsoid(
                GoobyRealityNames.pawLeft,
                scale: [0.25, 0.39, 0.24],
                position: [-0.58, 0.89, 0.36],
                material: apricot
            )
        )
        rig.addChild(
            ellipsoid(
                GoobyRealityNames.pawRight,
                scale: [0.25, 0.39, 0.24],
                position: [0.58, 0.89, 0.36],
                material: apricot
            )
        )
        rig.addChild(
            ellipsoid(
                GoobyRealityNames.footLeft,
                scale: [0.38, 0.23, 0.48],
                position: [-0.40, 0.06, 0.32],
                material: apricot
            )
        )
        rig.addChild(
            ellipsoid(
                GoobyRealityNames.footRight,
                scale: [0.38, 0.23, 0.48],
                position: [0.40, 0.06, 0.32],
                material: apricot
            )
        )
        rig.addChild(
            ellipsoid(
                GoobyRealityNames.tail,
                scale: [0.32, 0.32, 0.32],
                position: [0.72, 0.68, -0.34],
                material: bellyCream
            )
        )
    }

    private static func addCosmeticAnchors(to rig: Entity) {
        let head = Entity()
        head.name = GoobyRealityNames.headAnchor
        head.position = [0, 2.20, 0.35]
        rig.addChild(head)

        let neck = Entity()
        neck.name = GoobyRealityNames.neckAnchor
        neck.position = [0, 1.28, 0.52]
        rig.addChild(neck)

        let face = Entity()
        face.name = GoobyRealityNames.faceAnchor
        face.position = [0, 1.82, 0.70]
        rig.addChild(face)

        let body = Entity()
        body.name = GoobyRealityNames.bodyAnchor
        body.position = [0, 1.02, -0.35]
        rig.addChild(body)

        let paws = Entity()
        paws.name = GoobyRealityNames.pawsAnchor
        paws.position = [0, 0.78, 0.59]
        rig.addChild(paws)
    }

    static func clay(red: CGFloat, green: CGFloat, blue: CGFloat) -> SimpleMaterial {
        SimpleMaterial(
            color: UIColor(red: red, green: green, blue: blue, alpha: 1),
            roughness: 0.72,
            isMetallic: false
        )
    }

    static func ellipsoid(
        _ name: String,
        scale: SIMD3<Float>,
        position: SIMD3<Float>,
        material: SimpleMaterial
    ) -> ModelEntity {
        let entity = ModelEntity(
            mesh: .generateSphere(radius: 0.5),
            materials: [material]
        )
        entity.name = name
        entity.scale = scale
        entity.position = position
        return entity
    }

    static func box(
        _ name: String,
        size: SIMD3<Float>,
        position: SIMD3<Float>,
        material: SimpleMaterial,
        cornerRadius: Float = 0.04
    ) -> ModelEntity {
        let entity = ModelEntity(
            mesh: .generateBox(size: size, cornerRadius: cornerRadius),
            materials: [material]
        )
        entity.name = name
        entity.position = position
        return entity
    }

    static func cylinder(
        _ name: String,
        height: Float,
        radius: Float,
        position: SIMD3<Float>,
        material: SimpleMaterial
    ) -> ModelEntity {
        let mesh: MeshResource
        if #available(iOS 18.0, *) {
            mesh = .generateCylinder(height: height, radius: radius)
        } else {
            mesh = .generateBox(
                size: [radius * 2, height, radius * 2],
                cornerRadius: min(radius * 0.45, height * 0.45)
            )
        }
        let entity = ModelEntity(
            mesh: mesh,
            materials: [material]
        )
        entity.name = name
        entity.position = position
        return entity
    }
}

@MainActor
enum GoobyRoomFactory {
    private static let cocoa = GoobyFactory.clay(red: 0.37, green: 0.22, blue: 0.18)
    private static let coral = GoobyFactory.clay(red: 0.91, green: 0.48, blue: 0.39)
    private static let mint = GoobyFactory.clay(red: 0.47, green: 0.72, blue: 0.63)
    private static let blue = GoobyFactory.clay(red: 0.36, green: 0.58, blue: 0.74)
    private static let yellow = GoobyFactory.clay(red: 0.94, green: 0.72, blue: 0.32)
    private static let cream = GoobyFactory.clay(red: 0.98, green: 0.91, blue: 0.76)

    struct VisualSpec: Equatable {
        let heroName: String
        let backdropName: String
        let floorRGB: SIMD3<Float>
        let wallRGB: SIMD3<Float>
        let accentRGB: SIMD3<Float>
    }

    static func visualSpec(for room: RoomID) -> VisualSpec {
        switch room {
        case .kitchen:
            VisualSpec(
                heroName: "kitchen.hero.carrot-basket",
                backdropName: "kitchen.backdrop.sunrise",
                floorRGB: [0.74, 0.50, 0.33],
                wallRGB: [0.99, 0.82, 0.55],
                accentRGB: [0.88, 0.31, 0.20]
            )
        case .washroom:
            VisualSpec(
                heroName: "washroom.hero.rubber-duck",
                backdropName: "washroom.backdrop.ripple",
                floorRGB: [0.34, 0.66, 0.70],
                wallRGB: [0.73, 0.91, 0.91],
                accentRGB: [0.18, 0.47, 0.67]
            )
        case .bedroom:
            VisualSpec(
                heroName: "bedroom.hero.moon-lamp",
                backdropName: "bedroom.backdrop.night-sky",
                floorRGB: [0.31, 0.30, 0.50],
                wallRGB: [0.53, 0.52, 0.72],
                accentRGB: [0.24, 0.24, 0.47]
            )
        case .playroom:
            VisualSpec(
                heroName: "playroom.hero.star-drum",
                backdropName: "playroom.backdrop.confetti",
                floorRGB: [0.62, 0.47, 0.35],
                wallRGB: [0.91, 0.75, 0.52],
                accentRGB: [0.32, 0.63, 0.52]
            )
        }
    }

    static func makeRoom(_ room: RoomID) -> Entity {
        let root = Entity()
        root.name = "room.\(room.rawValue)"
        addShell(to: root, room: room)
        addCameraAndLights(to: root, room: room)

        switch room {
        case .kitchen: addKitchen(to: root)
        case .washroom: addWashroom(to: root)
        case .bedroom: addBedroom(to: root)
        case .playroom: addPlayroom(to: root)
        }
        return root
    }

    private static func addShell(to root: Entity, room: RoomID) {
        let spec = visualSpec(for: room)
        let floor = material(spec.floorRGB)
        let wall = material(spec.wallRGB)
        let accent = material(spec.accentRGB)
        root.addChild(
            GoobyFactory.box(
                "room.floor",
                size: [4.5, 0.10, 3.2],
                position: [0, -0.06, 0],
                material: floor
            )
        )
        root.addChild(
            GoobyFactory.box(
                "room.wall.back",
                size: [4.5, 3.2, 0.10],
                position: [0, 1.50, -1.55],
                material: wall
            )
        )
        root.addChild(
            GoobyFactory.box(
                "room.wall.side",
                size: [0.10, 3.2, 3.2],
                position: [-2.20, 1.50, 0],
                material: wall
            )
        )
        root.addChild(
            GoobyFactory.box(
                spec.backdropName,
                size: [3.15, 2.35, 0.08],
                position: [0.30, 1.42, -1.47],
                material: accent,
                cornerRadius: 0.20
            )
        )
        let contact = GoobyFactory.ellipsoid(
            "room.contact-shadow",
            scale: [1.05, 0.035, 0.54],
            position: [0, 0.03, 0.18],
            material: GoobyFactory.clay(red: 0.22, green: 0.16, blue: 0.18)
        )
        contact.components.set(OpacityComponent(opacity: 0.16))
        root.addChild(contact)
    }

    private static func addCameraAndLights(to root: Entity, room: RoomID) {
        let spec = visualSpec(for: room)
        let camera = PerspectiveCamera()
        camera.name = "room.camera"
        camera.camera.fieldOfViewInDegrees = 44
        camera.look(
            at: [0, 1.08, 0],
            from: [0, 1.62, 4.55],
            relativeTo: root
        )
        root.addChild(camera)

        let key = DirectionalLight()
        key.name = "room.light.key"
        key.light.intensity = 850
        key.light.color = tint(spec.wallRGB, lift: 0.18)
        key.look(at: [0, 0.7, 0], from: [2.5, 4.0, 3.0], relativeTo: root)
        root.addChild(key)

        let fill = PointLight()
        fill.name = "room.light.fill"
        fill.light.intensity = 720
        fill.light.color = tint(spec.accentRGB, lift: 0.28)
        fill.light.attenuationRadius = 6
        fill.position = [-1.4, 2.4, 2.0]
        root.addChild(fill)

        let softFill = PointLight()
        softFill.name = "room.light.soft-fill"
        softFill.light.intensity = 460
        softFill.light.color = UIColor(red: 0.94, green: 0.89, blue: 0.82, alpha: 1)
        softFill.light.attenuationRadius = 5
        softFill.position = [1.7, 1.5, 2.2]
        root.addChild(softFill)
    }

    private static func addKitchen(to root: Entity) {
        root.addChild(
            GoobyFactory.box(
                "kitchen.counter",
                size: [1.20, 0.90, 0.65],
                position: [-1.45, 0.45, -0.80],
                material: cocoa
            )
        )
        root.addChild(
            GoobyFactory.cylinder(
                "kitchen.bowl",
                height: 0.16,
                radius: 0.34,
                position: [-1.32, 1.00, -0.55],
                material: coral
            )
        )
        let carrot = GoobyFactory.cylinder(
            "kitchen.carrot",
            height: 0.62,
            radius: 0.11,
            position: [1.42, 0.32, -0.80],
            material: coral
        )
        carrot.orientation = simd_quatf(angle: -0.35, axis: [0, 0, 1])
        carrot.addChild(
            GoobyFactory.box(
                "kitchen.carrot.leaves",
                size: [0.28, 0.22, 0.12],
                position: [0, 0.37, 0],
                material: mint
            )
        )
        root.addChild(carrot)

        let basket = Entity()
        basket.name = visualSpec(for: .kitchen).heroName
        basket.addChild(
            GoobyFactory.cylinder(
                "kitchen.hero.basket",
                height: 0.42,
                radius: 0.48,
                position: [0, 0.20, 0],
                material: cocoa
            )
        )
        for (index, x) in [Float(-0.22), 0, 0.22].enumerated() {
            let heroCarrot = GoobyFactory.cylinder(
                "kitchen.hero.carrot.\(index)",
                height: 0.72 - Float(index) * 0.08,
                radius: 0.11,
                position: [x, 0.68 - Float(index) * 0.04, 0],
                material: coral
            )
            heroCarrot.orientation = simd_quatf(
                angle: Float(index - 1) * 0.12,
                axis: [0, 0, 1]
            )
            heroCarrot.addChild(
                GoobyFactory.box(
                    "kitchen.hero.leaves.\(index)",
                    size: [0.25, 0.20, 0.12],
                    position: [0, 0.43, 0],
                    material: mint
                )
            )
            basket.addChild(heroCarrot)
        }
        basket.position = [1.38, 0.02, 0.55]
        root.addChild(basket)
    }

    private static func addWashroom(to root: Entity) {
        root.addChild(
            GoobyFactory.box(
                "washroom.tub",
                size: [1.45, 0.54, 0.86],
                position: [-1.25, 0.28, -0.66],
                material: blue,
                cornerRadius: 0.18
            )
        )
        for index in 0 ..< 5 {
            root.addChild(
                GoobyFactory.ellipsoid(
                    "washroom.bubble.\(index)",
                    scale: [0.15, 0.15, 0.15],
                    position: [
                        -1.70 + Float(index) * 0.23,
                        0.66 + Float(index % 2) * 0.11,
                        -0.28,
                    ],
                    material: cream
                )
            )
        }
        root.addChild(
            GoobyFactory.box(
                "washroom.towel",
                size: [0.72, 0.90, 0.08],
                position: [1.52, 1.38, -1.43],
                material: coral,
                cornerRadius: 0.08
            )
        )

        let duck = Entity()
        duck.name = visualSpec(for: .washroom).heroName
        duck.addChild(
            GoobyFactory.ellipsoid(
                "washroom.hero.duck.body",
                scale: [0.52, 0.40, 0.44],
                position: [0, 0.38, 0],
                material: yellow
            )
        )
        duck.addChild(
            GoobyFactory.ellipsoid(
                "washroom.hero.duck.head",
                scale: [0.34, 0.34, 0.32],
                position: [0.26, 0.78, 0.02],
                material: yellow
            )
        )
        duck.addChild(
            GoobyFactory.box(
                "washroom.hero.duck.beak",
                size: [0.30, 0.13, 0.22],
                position: [0.56, 0.72, 0.08],
                material: coral,
                cornerRadius: 0.06
            )
        )
        duck.position = [1.23, 0.02, 0.58]
        root.addChild(duck)
    }

    private static func addBedroom(to root: Entity) {
        root.addChild(
            GoobyFactory.box(
                "bedroom.bed",
                size: [1.55, 0.36, 1.05],
                position: [-1.25, 0.18, -0.55],
                material: blue,
                cornerRadius: 0.16
            )
        )
        root.addChild(
            GoobyFactory.ellipsoid(
                "bedroom.pillow",
                scale: [0.48, 0.18, 0.35],
                position: [-1.56, 0.48, -0.68],
                material: cream
            )
        )
        let lamp = GoobyFactory.ellipsoid(
            "bedroom.moon-lamp",
            scale: [0.34, 0.34, 0.12],
            position: [1.52, 1.54, -1.37],
            material: yellow
        )
        lamp.addChild(
            GoobyFactory.ellipsoid(
                "bedroom.moon-lamp.cutout",
                scale: [0.68, 0.68, 0.50],
                position: [0.18, 0.08, 0.40],
                material: wall
            )
        )
        root.addChild(lamp)

        let heroLamp = Entity()
        heroLamp.name = visualSpec(for: .bedroom).heroName
        heroLamp.addChild(
            GoobyFactory.cylinder(
                "bedroom.hero.lamp.stand",
                height: 1.15,
                radius: 0.08,
                position: [0, 0.58, 0],
                material: cocoa
            )
        )
        heroLamp.addChild(
            GoobyFactory.ellipsoid(
                "bedroom.hero.lamp.moon",
                scale: [0.48, 0.48, 0.18],
                position: [0, 1.18, 0],
                material: yellow
            )
        )
        heroLamp.addChild(
            GoobyFactory.ellipsoid(
                "bedroom.hero.lamp.cutout",
                scale: [0.37, 0.37, 0.20],
                position: [0.20, 1.27, 0.11],
                material: blue
            )
        )
        heroLamp.addChild(
            GoobyFactory.cylinder(
                "bedroom.hero.lamp.base",
                height: 0.12,
                radius: 0.38,
                position: [0, 0.06, 0],
                material: cocoa
            )
        )
        heroLamp.position = [1.42, 0, 0.50]
        root.addChild(heroLamp)
    }

    private static func addPlayroom(to root: Entity) {
        let colors = [coral, mint, blue]
        for index in 0 ..< 3 {
            root.addChild(
                GoobyFactory.box(
                    "playroom.block.\(index)",
                    size: [0.36, 0.36, 0.36],
                    position: [-1.55 + Float(index) * 0.40, 0.18, -0.72],
                    material: colors[index],
                    cornerRadius: 0.06
                )
            )
        }
        root.addChild(
            GoobyFactory.ellipsoid(
                "playroom.ball",
                scale: [0.34, 0.34, 0.34],
                position: [1.34, 0.35, -0.48],
                material: yellow
            )
        )
        for index in 0 ..< 3 {
            root.addChild(
                GoobyFactory.box(
                    "playroom.arcade-marker.\(index)",
                    size: [0.16, 0.48 + Float(index) * 0.12, 0.12],
                    position: [1.28 + Float(index) * 0.23, 1.00, -1.42],
                    material: colors[index],
                    cornerRadius: 0.05
                )
            )
        }

        let drum = Entity()
        drum.name = visualSpec(for: .playroom).heroName
        drum.addChild(
            GoobyFactory.cylinder(
                "playroom.hero.drum.body",
                height: 0.70,
                radius: 0.46,
                position: [0, 0.40, 0],
                material: coral
            )
        )
        drum.addChild(
            GoobyFactory.cylinder(
                "playroom.hero.drum.top",
                height: 0.10,
                radius: 0.50,
                position: [0, 0.80, 0],
                material: cream
            )
        )
        for (index, x) in [Float(-0.23), 0.23].enumerated() {
            let stick = GoobyFactory.cylinder(
                "playroom.hero.drumstick.\(index)",
                height: 0.82,
                radius: 0.045,
                position: [x, 1.10, 0.02],
                material: cocoa
            )
            stick.orientation = simd_quatf(
                angle: index == 0 ? -0.40 : 0.40,
                axis: [0, 0, 1]
            )
            drum.addChild(stick)
        }
        drum.position = [1.35, 0, 0.54]
        root.addChild(drum)
    }

    private static func material(_ rgb: SIMD3<Float>) -> SimpleMaterial {
        GoobyFactory.clay(
            red: CGFloat(rgb.x),
            green: CGFloat(rgb.y),
            blue: CGFloat(rgb.z)
        )
    }

    private static func tint(_ rgb: SIMD3<Float>, lift: Float) -> UIColor {
        UIColor(
            red: CGFloat(min(1, rgb.x + lift)),
            green: CGFloat(min(1, rgb.y + lift)),
            blue: CGFloat(min(1, rgb.z + lift)),
            alpha: 1
        )
    }
}
