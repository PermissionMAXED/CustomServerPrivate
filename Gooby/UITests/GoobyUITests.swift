import XCTest

final class GoobyUITests: XCTestCase {
    override func setUpWithError() throws {
        continueAfterFailure = false
    }

    func testLaunchShowsOriginalGoobyBrand() {
        let app = XCUIApplication()
        app.launch()

        XCTAssertTrue(app.staticTexts["Gooby"].waitForExistence(timeout: 5))
        XCTAssertTrue(app.staticTexts["Made for quiet, offline moments"].exists)
    }
}
