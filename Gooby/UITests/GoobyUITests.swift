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
        app.terminate()
    }

    @MainActor
    func testDailyShopWardrobePurchaseEquipAndRelaunch() {
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

        tap(app.buttons["home.destination.daily-gift"], in: app)
        tap(app.buttons["daily.claim"], in: app)
        XCTAssertTrue(app.buttons["Claimed Today"].waitForExistence(timeout: 8))
        tap(app.buttons["sheet.done"], in: app)

        tap(app.buttons["home.destination.shop"], in: app)
        tap(app.buttons["shop.item.sunshine-bow"], in: app)
        XCTAssertTrue(app.staticTexts["shop.preview"].waitForExistence(timeout: 8))
        tap(app.buttons["shop.buy.sunshine-bow"], in: app)
        XCTAssertTrue(app.staticTexts["Owned permanently"].waitForExistence(timeout: 8))
        XCTAssertTrue(app.staticTexts["shop.detail.balance"].label.contains("15"))
        tap(app.buttons["item-detail.done"], in: app)
        tap(app.buttons["sheet.done"], in: app)

        tap(app.buttons["home.destination.wardrobe"], in: app)
        tap(app.buttons["wardrobe.item.sunshine-bow"], in: app)
        tap(app.buttons["wardrobe.equip"], in: app)
        XCTAssertTrue(app.buttons["wardrobe.unequip"].waitForExistence(timeout: 8))
        attachHomeScreenshot(named: "Gooby Gate 3 — Equipped Sunshine Bow")

        tap(app.buttons["sheet.done"], in: app)
        app.terminate()
        app.launchArguments = [
            "--ui-testing",
            "--skip-welcome",
            "--fixed-time",
            "1728000000",
        ]
        app.launch()
        XCTAssertTrue(app.staticTexts["gooby.status"].waitForExistence(timeout: 12))
        tap(app.buttons["home.destination.wardrobe"], in: app)
        tap(app.buttons["wardrobe.item.sunshine-bow"], in: app)
        XCTAssertTrue(app.buttons["wardrobe.unequip"].waitForExistence(timeout: 8))
        tap(app.buttons["sheet.done"], in: app)
        XCTAssertTrue(app.staticTexts["gooby.status"].waitForExistence(timeout: 8))
        for _ in 0 ..< 4 {
            app.swipeDown()
        }
        XCTAssertTrue(app.staticTexts["room.current"].waitForExistence(timeout: 8))
        attachHomeScreenshot(named: "Gooby Gate 4 — Home with Equipped Bow")
        app.terminate()
    }

    @MainActor
    func testCarrotCatchCompletesDeterministicShortRunAndShowsReward() {
        let app = launchFreshApp(shortMinigames: true)

        tap(app.buttons["home.destination.arcade"], in: app)
        tap(app.buttons["arcade.play.carrotCatch"], in: app)
        tap(app.buttons["carrot.start"], in: app)
        let target = app.descendants(matching: .any)["carrot.target"]
        XCTAssertTrue(target.waitForExistence(timeout: 10))

        for carrot in 1 ... CarrotCatchUITest.maximumMoves {
            waitForCarrotTarget(carrot, in: app)
            let lane = CarrotCatchUITest.lanes[carrot - 1]
            tap(app.buttons["carrot.lane.\(lane)"], in: app)
        }

        XCTAssertTrue(app.staticTexts["carrot.result.score"].waitForExistence(timeout: 10))
        XCTAssertEqual(app.staticTexts["carrot.result.score"].label, "200 points")
        XCTAssertTrue(app.staticTexts["carrot.result.reward"].label.contains("+20 carrots"))
        XCTAssertEqual(app.staticTexts["carrot.result.best"].label, "Best score: 200")
        attachHomeScreenshot(named: "Gooby Gate 4 — Carrot Catch Result")
        app.terminate()
    }

    @MainActor
    func testGardenEchoCompletesDeterministicShortRunAndShowsReward() {
        let app = launchFreshApp(shortMinigames: true)
        let pet = app.buttons["care.pet"]
        tap(pet, in: app)
        for _ in 1 ..< 9 {
            usleep(180_000)
            pet.tap()
        }
        waitForLabel("Bond level 2 of 10", identifier: "bond.level", in: app, timeout: 10)

        tap(app.buttons["home.destination.arcade"], in: app)
        XCTAssertTrue(app.buttons["arcade.play.gardenEcho"].isEnabled)
        tap(app.buttons["arcade.play.gardenEcho"], in: app)
        tap(app.buttons["echo.start"], in: app)

        for (roundIndex, sequence) in GardenEchoUITest.rounds.enumerated() {
            waitForEchoInput(round: roundIndex + 1, in: app)
            for pad in sequence {
                tap(app.buttons["echo.pad.\(pad)"], in: app)
            }
        }

        XCTAssertTrue(app.staticTexts["echo.result.score"].waitForExistence(timeout: 10))
        XCTAssertEqual(app.staticTexts["echo.result.score"].label, "125 points")
        XCTAssertTrue(app.staticTexts["echo.result.reward"].label.contains("+12 carrots"))
        XCTAssertEqual(app.staticTexts["echo.result.best"].label, "Best score: 125")
        attachHomeScreenshot(named: "Gooby Gate 4 — Garden Echo Result")
        app.terminate()
    }

    @MainActor
    func testAccessibilityLayoutOnArcadeLandingAtLargestType() {
        let app = launchFreshApp(
            shortMinigames: false,
            contentSizeCategory: "UICTContentSizeCategoryAccessibilityXXXL"
        )
        tap(app.buttons["home.destination.arcade"], in: app)

        XCTAssertTrue(app.buttons["arcade.play.carrotCatch"].waitForExistence(timeout: 8))
        XCTAssertTrue(app.buttons["arcade.play.carrotCatch"].frame.height >= 44)
        XCTAssertFalse(app.staticTexts["arcade.best.carrotCatch"].label.isEmpty)
        let wrappedSubtitle = app.staticTexts[
            "Catch a seeded garden parade in three clear lanes."
        ]
        XCTAssertTrue(wrappedSubtitle.waitForExistence(timeout: 8))
        XCTAssertGreaterThan(wrappedSubtitle.frame.height, 50)
        app.terminate()
    }

    @MainActor
    func testAccessibilityLayoutOnHomeAtLargestType() {
        let app = launchFreshApp(
            shortMinigames: false,
            contentSizeCategory: "UICTContentSizeCategoryAccessibilityXXXL"
        )
        let window = app.windows.firstMatch
        let status = app.staticTexts["gooby.status"]
        let balanceMatches = app.descendants(matching: .any)
            .matching(identifier: "home.carrots")
        let balance = balanceMatches.firstMatch

        XCTAssertTrue(status.waitForExistence(timeout: 8))
        XCTAssertTrue(balance.waitForExistence(timeout: 8))
        XCTAssertEqual(balanceMatches.count, 1)
        XCTAssertTrue(window.frame.contains(status.frame))
        XCTAssertTrue(window.frame.contains(balance.frame))
        XCTAssertGreaterThanOrEqual(balance.frame.height, 44)
        app.terminate()
    }

    @MainActor
    func testZAccessibilityAuditOnArcadeLanding() throws {
        let app = launchFreshApp(shortMinigames: false)
        tap(app.buttons["home.destination.arcade"], in: app)
        XCTAssertTrue(app.buttons["arcade.play.carrotCatch"].waitForExistence(timeout: 8))

        if #available(iOS 17.0, *) {
            try app.performAccessibilityAudit(
                for: [.hitRegion, .sufficientElementDescription, .textClipped]
            )
        }
        app.terminate()
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
    private func launchFreshApp(
        shortMinigames: Bool,
        contentSizeCategory: String? = nil
    ) -> XCUIApplication {
        let app = XCUIApplication()
        app.launchArguments = [
            "--ui-testing",
            "--reset-save",
            "--skip-welcome",
            "--fixed-time",
            "1728000000",
        ]
        if shortMinigames {
            app.launchArguments.append("--short-minigames")
        }
        if let contentSizeCategory {
            app.launchArguments.append(contentsOf: [
                "-UIPreferredContentSizeCategoryName",
                contentSizeCategory,
            ])
        }
        app.launch()
        XCTAssertTrue(app.staticTexts["gooby.status"].waitForExistence(timeout: 12))
        return app
    }

    @MainActor
    private func waitForEchoInput(round: Int, in app: XCUIApplication) {
        let predicate = NSPredicate(
            format: "identifier == %@ AND label CONTAINS %@",
            "echo.status",
            "Your turn"
        )
        XCTAssertTrue(
            app.staticTexts.matching(predicate).firstMatch.waitForExistence(timeout: 10),
            "Garden Echo round \(round) never entered input"
        )
    }

    @MainActor
    private func waitForCarrotTarget(_ carrot: Int, in app: XCUIApplication) {
        let expected = "Carrot \(carrot) of \(CarrotCatchUITest.maximumMoves)"
        let predicate = NSPredicate(
            format: "identifier == %@ AND value CONTAINS %@",
            "carrot.target",
            expected
        )
        XCTAssertTrue(
            app.descendants(matching: .any)
                .matching(predicate)
                .firstMatch
                .waitForExistence(timeout: 5),
            "Expected \(expected)"
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

private enum CarrotCatchUITest {
    static let maximumMoves = 20
    static let lanes = [
        "left", "center", "center", "right", "center",
        "right", "right", "right", "center", "right",
        "left", "right", "right", "left", "right",
        "left", "center", "left", "right", "right",
    ]
}

private enum GardenEchoUITest {
    static let rounds = [
        ["berry", "star", "berry"],
        ["berry", "star", "berry", "star"],
        ["berry", "star", "berry", "star", "moon"],
        ["berry", "star", "berry", "star", "moon", "moon"],
        ["berry", "star", "berry", "star", "moon", "moon", "berry"],
    ]
}
