import XCTest

final class GoobyDemoUITests: XCTestCase {
    override func setUpWithError() throws {
        continueAfterFailure = false
    }

    @MainActor
    func testRecordedDemoJourney() {
        let app = XCUIApplication()
        app.launchArguments = [
            "--ui-testing",
            "--reset-save",
            "--skip-welcome",
            "--fixed-time",
            "1728000000",
            "--short-minigames",
            "--recorded-demo",
        ]
        app.launch()
        defer { app.terminate() }

        XCTAssertTrue(app.staticTexts["gooby.status"].waitForExistence(timeout: 12))
        XCTAssertTrue(
            app.descendants(matching: .any)["home.gooby-hero"]
                .waitForExistence(timeout: 8)
        )
        XCTAssertEqual(app.staticTexts["room.current"].label, "Playroom")
        attachScreenshot(named: "Gooby Demo — 3D Home")

        tap(app.buttons["room.kitchen"], in: app)
        waitForLabel("Kitchen", identifier: "room.current", in: app)
        tap(app.buttons["care.primary"], in: app)
        waitForLabel("100%", identifier: "need.fullness.value", in: app)
        let pet = app.buttons["care.pet"]
        tap(pet, in: app)
        for _ in 1 ..< 7 {
            usleep(200_000)
            pet.tap()
        }
        waitForLabel("Bond level 2 of 10", identifier: "bond.level", in: app)

        tap(app.buttons["home.destination.shop"], in: app)
        tap(app.buttons["shop.item.sunshine-bow"], in: app)
        tap(app.buttons["shop.buy.sunshine-bow"], in: app)
        XCTAssertTrue(app.staticTexts["Owned permanently"].waitForExistence(timeout: 8))
        tap(app.buttons["item-detail.done"], in: app)
        tap(app.buttons["sheet.done"], in: app)
        tap(app.buttons["home.destination.wardrobe"], in: app)
        tap(app.buttons["wardrobe.item.sunshine-bow"], in: app)
        tap(app.buttons["wardrobe.equip"], in: app)
        XCTAssertTrue(app.buttons["wardrobe.unequip"].waitForExistence(timeout: 8))
        attachScreenshot(named: "Gooby Demo — Sunshine Bow Equipped")
        tap(app.buttons["sheet.done"], in: app)

        tap(app.buttons["home.destination.arcade"], in: app)
        tap(app.buttons["arcade.play.carrotCatch"], in: app)
        tap(app.buttons["carrot.start"], in: app)
        XCTAssertTrue(
            app.descendants(matching: .any)["carrot.target"]
                .waitForExistence(timeout: 10)
        )
        for lane in DemoSequence.carrotLanes {
            pressCarrotLane(lane, in: app)
        }
        XCTAssertTrue(app.staticTexts["carrot.result.score"].waitForExistence(timeout: 10))
        XCTAssertEqual(app.staticTexts["carrot.result.score"].label, "30 points")
        attachScreenshot(named: "Gooby Demo — Carrot Catch Result")
        tap(app.buttons["carrot.done"], in: app)

        tap(app.buttons["arcade.play.gardenEcho"], in: app)
        tap(app.buttons["echo.start"], in: app)
        for sequence in DemoSequence.echoRounds {
            waitForEchoInput(in: app)
            for pad in sequence {
                pressEchoPad(pad, in: app)
            }
        }
        XCTAssertTrue(app.staticTexts["echo.result.score"].waitForExistence(timeout: 10))
        XCTAssertEqual(app.staticTexts["echo.result.score"].label, "25 points")
        attachScreenshot(named: "Gooby Demo — Garden Echo Result")
        tap(app.buttons["echo.done"], in: app)
        tap(app.buttons["arcade.home"], in: app)

        XCTAssertTrue(app.staticTexts["gooby.status"].waitForExistence(timeout: 8))
        XCTAssertEqual(app.staticTexts["room.current"].label, "Kitchen")
        attachScreenshot(named: "Gooby Demo — Returned Home")
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
        in app: XCUIApplication
    ) {
        let element = app.staticTexts
            .matching(identifier: identifier)
            .matching(NSPredicate(format: "label == %@", label))
            .firstMatch
        XCTAssertTrue(element.waitForExistence(timeout: 10))
    }

    @MainActor
    private func waitForEchoInput(in app: XCUIApplication) {
        let predicate = NSPredicate(
            format: "identifier == %@ AND label CONTAINS %@",
            "echo.status",
            "Your turn"
        )
        XCTAssertTrue(
            app.staticTexts.matching(predicate).firstMatch.waitForExistence(timeout: 10)
        )
    }

    @MainActor
    private func pressCarrotLane(_ lane: String, in app: XCUIApplication) {
        app.buttons["carrot.lane.\(lane)"].tap()
    }

    @MainActor
    private func pressEchoPad(_ pad: String, in app: XCUIApplication) {
        app.buttons["echo.pad.\(pad)"].tap()
    }

    @MainActor
    private func attachScreenshot(named name: String) {
        let attachment = XCTAttachment(screenshot: XCUIScreen.main.screenshot())
        attachment.name = name
        attachment.lifetime = .keepAlways
        add(attachment)
    }
}

private enum DemoSequence {
    static let carrotLanes = ["left", "center", "center"]

    static let echoRounds = [
        ["berry", "star", "berry"],
    ]
}
