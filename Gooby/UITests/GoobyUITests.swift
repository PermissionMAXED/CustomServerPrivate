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
            "--reduce-motion",
            "--fixed-time",
            "1728000000",
        ]
        app.launch()

        XCTAssertTrue(app.staticTexts["gooby.status"].waitForExistence(timeout: 12))
        XCTAssertEqual(app.staticTexts["room.current"].label, "Playroom")
        XCTAssertEqual(app.staticTexts["need.fullness.value"].label, "80%")
        attachHomeScreenshot(named: "Gooby Home — Playroom")

        tap(app.buttons["room.kitchen"], in: app)
        waitForLabel("Kitchen", identifier: "room.current", in: app)
        tap(app.buttons["care.primary"], in: app)
        waitForLabel("100%", identifier: "need.fullness.value", in: app)

        tap(app.buttons["room.washroom"], in: app)
        waitForLabel("Washroom", identifier: "room.current", in: app)
        tap(app.buttons["care.primary"], in: app)
        waitForLabel("100%", identifier: "need.cleanliness.value", in: app)

        tap(app.buttons["care.pet"], in: app)
        waitForLabel("95%", identifier: "need.fun.value", in: app)

        tap(app.buttons["room.bedroom"], in: app)
        waitForLabel("Bedroom", identifier: "room.current", in: app)
        tap(app.buttons["care.primary"], in: app)
        waitForLabel("Sleeping softly", identifier: "gooby.activity", in: app)
        XCTAssertTrue(app.buttons["care.pet"].isEnabled == false)
    }

    @MainActor
    func testDailyShopWardrobePurchaseEquipAndRelaunch() {
        let app = XCUIApplication()
        app.launchArguments = [
            "--ui-testing",
            "--reset-save",
            "--skip-welcome",
            "--reduce-motion",
            "--fixed-time",
            "1728000000",
        ]
        app.launch()
        XCTAssertTrue(app.staticTexts["gooby.status"].waitForExistence(timeout: 12))

        tap(app.buttons["home.destination.daily-gift"], in: app)
        tap(app.buttons["daily.claim"], in: app)
        XCTAssertTrue(app.buttons["Claimed Today"].waitForExistence(timeout: 8))
        tap(app.buttons["Done"], in: app)

        tap(app.buttons["home.destination.shop"], in: app)
        tap(app.buttons["shop.item.sunshine-bow"], in: app)
        XCTAssertTrue(app.staticTexts["shop.preview"].waitForExistence(timeout: 8))
        tap(app.buttons["shop.buy.sunshine-bow"], in: app)
        XCTAssertTrue(app.staticTexts["Owned permanently"].waitForExistence(timeout: 8))
        XCTAssertTrue(app.staticTexts["shop.detail.balance"].label.contains("15"))
        tap(app.buttons["Done"], in: app)
        tap(app.buttons["Done"], in: app)

        tap(app.buttons["home.destination.wardrobe"], in: app)
        tap(app.buttons["wardrobe.item.sunshine-bow"], in: app)
        tap(app.buttons["wardrobe.equip"], in: app)
        XCTAssertTrue(app.buttons["wardrobe.unequip"].waitForExistence(timeout: 8))
        attachHomeScreenshot(named: "Gooby Gate 3 — Equipped Sunshine Bow")

        tap(app.buttons["Done"], in: app)
        app.terminate()
        app.launchArguments = [
            "--ui-testing",
            "--skip-welcome",
            "--reduce-motion",
            "--fixed-time",
            "1728000000",
        ]
        app.launch()
        XCTAssertTrue(app.staticTexts["gooby.status"].waitForExistence(timeout: 12))
        tap(app.buttons["home.destination.wardrobe"], in: app)
        tap(app.buttons["wardrobe.item.sunshine-bow"], in: app)
        XCTAssertTrue(app.buttons["wardrobe.unequip"].waitForExistence(timeout: 8))
    }

    @MainActor
    private func tap(_ element: XCUIElement, in app: XCUIApplication) {
        var attempts = 0
        while !element.exists, attempts < 8 {
            app.swipeUp()
            attempts += 1
        }
        XCTAssertTrue(element.waitForExistence(timeout: 3))
        attempts = 0
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
        identifier: String,
        in app: XCUIApplication,
        timeout: TimeInterval = 8
    ) {
        let predicate = NSPredicate(format: "label == %@", label)
        let element = app.staticTexts
            .matching(identifier: identifier)
            .matching(predicate)
            .firstMatch
        XCTAssertTrue(
            element.waitForExistence(timeout: timeout),
            "Expected \(identifier) to show \(label)"
        )
    }

    @MainActor
    private func attachHomeScreenshot(named name: String) {
        let attachment = XCTAttachment(screenshot: XCUIScreen.main.screenshot())
        attachment.name = name
        attachment.lifetime = .keepAlways
        add(attachment)
    }
}
