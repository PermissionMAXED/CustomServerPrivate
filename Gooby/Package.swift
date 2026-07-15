// swift-tools-version: 6.0

import PackageDescription

let package = Package(
    name: "Gooby",
    platforms: [
        .iOS(.v17),
        .macOS(.v13),
    ],
    products: [
        .library(name: "GoobyCore", targets: ["GoobyCore"]),
        .library(name: "GoobyPersistence", targets: ["GoobyPersistence"]),
    ],
    targets: [
        .target(name: "GoobyCore"),
        .target(
            name: "GoobyPersistence",
            dependencies: ["GoobyCore"]
        ),
        .testTarget(
            name: "GoobyCoreTests",
            dependencies: ["GoobyCore"]
        ),
        .testTarget(
            name: "GoobyPersistenceTests",
            dependencies: ["GoobyCore", "GoobyPersistence"],
            resources: [.copy("Fixtures")]
        ),
    ]
)
