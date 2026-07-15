import GoobyCore
import GoobyPersistence
import RealityKit
import SwiftUI

@main
struct GoobyApp: App {
    var body: some Scene {
        WindowGroup {
            HomePlaceholderView()
        }
    }
}

enum GoobyBrand {
    static let name = "Gooby"
    static let subtitle = "A little world for a big-hearted bunny."
}
