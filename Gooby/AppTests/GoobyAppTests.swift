@testable import Gooby
import XCTest

final class GoobyAppTests: XCTestCase {
    func testBrandNameIsStable() {
        XCTAssertEqual(GoobyBrand.name, "Gooby")
        XCTAssertFalse(GoobyBrand.subtitle.isEmpty)
    }
}
