import XCTest

final class GoobyUITests: XCTestCase {
    override func setUpWithError() throws {
        continueAfterFailure = false
    }

    @MainActor
    func testDeterministicCareJourneyPersistsVisibleState() {
        let app = XCUIApplication()
        app.launchArguments = [
            "--ui-testing",
            "--reset-save",
            "--skip-welcome",
            "--fixed-time",
            "1728000000",
        ]
        app.launch()

        XCTAssertTrue(app.staticTexts["gooby.status"].waitForExistence(timeout: 12))
        XCTAssertEqual(app.staticTexts["room.current"].label, "Playroom")
        XCTAssertEqual(app.staticTexts["need.fullness.value"].label, "80%")
        attachHomeScreenshot(named: "Gooby Home — Playroom")

        tap(app.buttons["room.kitchen"], in: app)
        waitForLabel("Kitchen", on: app.staticTexts["room.current"])
        tap(app.buttons["care.primary"], in: app)
        waitForLabel("100%", on: app.staticTexts["need.fullness.value"])

        tap(app.buttons["room.washroom"], in: app)
        waitForLabel("Washroom", on: app.staticTexts["room.current"])
        tap(app.buttons["care.primary"], in: app)
        waitForLabel("100%", on: app.staticTexts["need.cleanliness.value"])

        tap(app.buttons["care.pet"], in: app)
        waitForLabel("95%", on: app.staticTexts["need.fun.value"])

        tap(app.buttons["room.bedroom"], in: app)
        waitForLabel("Bedroom", on: app.staticTexts["room.current"])
        tap(app.buttons["care.primary"], in: app)
        waitForLabel("Sleeping softly", on: app.staticTexts["gooby.activity"])
        XCTAssertTrue(app.buttons["care.pet"].isEnabled == false)
    }

    @MainActor
    private func tap(_ element: XCUIElement, in app: XCUIApplication) {
        XCTAssertTrue(element.waitForExistence(timeout: 8))
        var attempts = 0
        while !element.isHittable, attempts < 6 {
            app.swipeUp()
            attempts += 1
        }
        XCTAssertTrue(element.isHittable)
        element.tap()
    }

    @MainActor
    private func waitForLabel(
        _ label: String,
        on element: XCUIElement,
        timeout: TimeInterval = 8
    ) {
        let predicate = NSPredicate(format: "label == %@", label)
        expectation(for: predicate, evaluatedWith: element)
        waitForExpectations(timeout: timeout)
    }

    @MainActor
    private func attachHomeScreenshot(named name: String) {
        let attachment = XCTAttachment(screenshot: XCUIScreen.main.screenshot())
        attachment.name = name
        attachment.lifetime = .keepAlways
        add(attachment)
    }
}
