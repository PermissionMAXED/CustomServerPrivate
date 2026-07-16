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
        defer { app.terminate() }

        XCTAssertTrue(app.staticTexts["gooby.status"].waitForExistence(timeout: 12))
        XCTAssertEqual(app.staticTexts["room.current"].label, "Playroom")
        XCTAssertEqual(app.staticTexts["need.fullness.value"].label, "80%")
        XCTAssertTrue(app.buttons["room.playroom"].isHittable)
        XCTAssertTrue(app.buttons["room.playroom"].isSelected)
        XCTAssertTrue(app.buttons["care.primary"].isHittable)
        attachHomeScreenshot(named: "Gooby Home — Playroom")

        tap(app.buttons["room.kitchen"], in: app)
        waitForLabel("Kitchen", identifier: "room.current", in: app)
        tap(app.buttons["care.primary"], in: app)
        waitForLabel("100%", identifier: "need.fullness.value", in: app)
        XCTAssertTrue(app.staticTexts["care.confirmation"].waitForExistence(timeout: 5))

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
            "--fixed-time",
            "1728000000",
        ]
        app.launch()
        defer { app.terminate() }
        XCTAssertTrue(app.staticTexts["gooby.status"].waitForExistence(timeout: 12))

        tap(app.buttons["home.destination.daily-gift"], in: app)
        tap(app.buttons["daily.claim"], in: app)
        XCTAssertTrue(app.buttons["Claimed Today"].waitForExistence(timeout: 8))
        let rewardClose = app.buttons["reward.close"]
        XCTAssertTrue(rewardClose.waitForExistence(timeout: 2))
        XCTAssertGreaterThanOrEqual(rewardClose.frame.height, 44)
        tap(app.buttons["sheet.close"], in: app)

        tap(app.buttons["home.destination.shop"], in: app)
        tap(app.buttons["shop.item.sunshine-bow"], in: app)
        XCTAssertTrue(app.staticTexts["shop.preview"].waitForExistence(timeout: 8))
        XCTAssertTrue(app.descendants(matching: .any)["shop.preview.scene"].exists)
        sleep(2)
        attachHomeScreenshot(named: "Gooby Wave 2 — Shop Sunshine Bow Preview")
        tap(app.buttons["shop.buy.sunshine-bow"], in: app)
        XCTAssertTrue(app.staticTexts["Owned permanently"].waitForExistence(timeout: 8))
        XCTAssertTrue(app.staticTexts["shop.detail.balance"].label.contains("15"))
        XCTAssertTrue(
            app.staticTexts["shop.purchase.confirmation"].waitForExistence(timeout: 5)
        )
        tap(app.buttons["item-detail.back"], in: app)
        tap(app.buttons["sheet.close"], in: app)

        tap(app.buttons["home.destination.wardrobe"], in: app)
        tap(app.buttons["wardrobe.item.sunshine-bow"], in: app)
        XCTAssertTrue(app.buttons["wardrobe.item.sunshine-bow"].isSelected)
        tap(app.buttons["wardrobe.equip"], in: app)
        XCTAssertTrue(app.buttons["wardrobe.unequip"].waitForExistence(timeout: 8))
        XCTAssertTrue(app.staticTexts["wardrobe.confirmation"].waitForExistence(timeout: 5))
        sleep(2)
        attachHomeScreenshot(named: "Gooby Gate 3 — Equipped Sunshine Bow")

        tap(app.buttons["sheet.close"], in: app)
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
        sleep(2)
        attachHomeScreenshot(named: "Gooby Wave 2 — Wardrobe Sunshine Bow Preview")
        tap(app.buttons["sheet.close"], in: app)
        XCTAssertTrue(app.staticTexts["gooby.status"].waitForExistence(timeout: 8))
        for _ in 0 ..< 4 {
            app.swipeDown()
        }
        XCTAssertTrue(app.staticTexts["room.current"].waitForExistence(timeout: 8))
        attachHomeScreenshot(named: "Gooby Gate 4 — Home with Equipped Bow")
    }

    @MainActor
    func testCarrotCatchCompletesDeterministicShortRunAndShowsReward() {
        let app = launchFreshApp(shortMinigames: true)
        defer { app.terminate() }

        tap(app.buttons["home.destination.arcade"], in: app)
        tap(app.buttons["arcade.play.carrotCatch"], in: app)
        tap(app.buttons["carrot.start"], in: app)
        let target = app.descendants(matching: .any)["carrot.target"]
        XCTAssertTrue(target.waitForExistence(timeout: 10))

        for lane in CarrotCatchUITest.lanes {
            app.buttons["carrot.lane.\(lane)"].tap()
        }

        waitForLabel("200 points", identifier: "carrot.result.score", in: app, timeout: 10)
        waitForLabelContaining("+20 carrots", identifier: "carrot.result.reward", in: app)
        waitForLabel("Best score: 200", identifier: "carrot.result.best", in: app)
        attachHomeScreenshot(named: "Gooby Gate 4 — Carrot Catch Result")
    }

    @MainActor
    func testGardenEchoCompletesDeterministicShortRunAndShowsReward() {
        let app = launchFreshApp(shortMinigames: true)
        defer { app.terminate() }
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
            for (inputIndex, pad) in sequence.enumerated() {
                waitForEchoInput(
                    round: roundIndex + 1,
                    input: inputIndex + 1,
                    count: sequence.count,
                    in: app
                )
                app.buttons["echo.pad.\(pad)"].tap()
            }
        }

        waitForLabel("125 points", identifier: "echo.result.score", in: app, timeout: 10)
        waitForLabelContaining("+12 carrots", identifier: "echo.result.reward", in: app)
        waitForLabel("Best score: 125", identifier: "echo.result.best", in: app)
        attachHomeScreenshot(named: "Gooby Gate 4 — Garden Echo Result")
    }

    @MainActor
    func testAccessibilityLayoutOnArcadeLandingAtLargestType() {
        let app = launchFreshApp(
            shortMinigames: false,
            contentSizeCategory: "UICTContentSizeCategoryAccessibilityXXXL"
        )
        defer { app.terminate() }
        tap(app.buttons["home.destination.arcade"], in: app)

        XCTAssertTrue(app.buttons["arcade.play.carrotCatch"].waitForExistence(timeout: 8))
        XCTAssertTrue(app.buttons["arcade.play.carrotCatch"].frame.height >= 44)
        XCTAssertFalse(app.staticTexts["arcade.best.carrotCatch"].label.isEmpty)
        let wrappedSubtitle = app.staticTexts[
            "Catch a seeded garden parade in three clear lanes."
        ]
        XCTAssertTrue(wrappedSubtitle.waitForExistence(timeout: 8))
        XCTAssertGreaterThan(wrappedSubtitle.frame.height, 50)
    }

    @MainActor
    func testAccessibilityLayoutOnHomeAtLargestType() {
        let app = launchFreshApp(
            shortMinigames: false,
            contentSizeCategory: "UICTContentSizeCategoryAccessibilityXXXL"
        )
        defer { app.terminate() }
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
    }

    @MainActor
    func testShopFinalRowRemainsAboveReservedBalance() {
        let app = launchFreshApp(shortMinigames: false)
        defer { app.terminate() }

        tap(app.buttons["home.destination.shop"], in: app)
        let finalRow = app.buttons["shop.item.moon-crown"]
        for _ in 0 ..< 8 where !finalRow.isHittable {
            app.swipeUp()
        }
        XCTAssertTrue(finalRow.isHittable)
        let balance = app.descendants(matching: .any)["shop.balance"]
        XCTAssertTrue(balance.exists)
        XCTAssertFalse(finalRow.frame.intersects(balance.frame))
        XCTAssertLessThanOrEqual(finalRow.frame.maxY, balance.frame.minY)
    }

    @MainActor
    func testCarrotStartIsPinnedAndDiscoverableAtAccessibilityXXXL() {
        let app = launchFreshApp(
            shortMinigames: false,
            contentSizeCategory: "UICTContentSizeCategoryAccessibilityXXXL"
        )
        defer { app.terminate() }

        tap(app.buttons["home.destination.arcade"], in: app)
        tap(app.buttons["arcade.play.carrotCatch"], in: app)
        let start = app.buttons["carrot.start"]
        XCTAssertTrue(start.waitForExistence(timeout: 8))
        XCTAssertTrue(start.isHittable)
        XCTAssertGreaterThanOrEqual(start.frame.height, 44)
        XCTAssertTrue(app.windows.firstMatch.frame.contains(start.frame))
    }

    @MainActor
    func testConsistentModalLabelsAndSelectedNoncolorTraits() {
        let app = launchFreshApp(shortMinigames: false)
        defer { app.terminate() }

        XCTAssertTrue(app.buttons["room.playroom"].isSelected)
        tap(app.buttons["home.destination.shop"], in: app)
        XCTAssertEqual(app.buttons["sheet.close"].label, "Close")
        tap(app.buttons["shop.item.sunshine-bow"], in: app)
        XCTAssertEqual(app.buttons["item-detail.back"].label, "Back")
        tap(app.buttons["item-detail.back"], in: app)
        tap(app.buttons["sheet.close"], in: app)

        tap(app.buttons["home.destination.wardrobe"], in: app)
        let bow = app.buttons["wardrobe.item.sunshine-bow"]
        XCTAssertTrue(bow.waitForExistence(timeout: 5))
        XCTAssertTrue(bow.isSelected)
        XCTAssertTrue(bow.label.contains("Sunshine Bow"))
        tap(app.buttons["sheet.close"], in: app)

        tap(app.buttons["home.destination.arcade"], in: app)
        XCTAssertEqual(app.buttons["arcade.close"].label, "Close")
        tap(app.buttons["arcade.play.carrotCatch"], in: app)
        XCTAssertEqual(app.buttons["carrot.back"].label, "Back to Arcade")
    }

    @MainActor
    func testReduceTransparencyKeepsCustomSurfacesUsable() {
        let app = launchFreshApp(
            shortMinigames: false,
            extraArguments: ["-UIAccessibilityReduceTransparencyEnabled", "YES"]
        )
        defer { app.terminate() }

        XCTAssertTrue(app.descendants(matching: .any)["needs.compact-summary"].exists)
        XCTAssertTrue(app.buttons["care.primary"].isHittable)
        tap(app.buttons["home.destination.wardrobe"], in: app)
        XCTAssertTrue(
            app.descendants(matching: .any)["wardrobe.preview"]
                .waitForExistence(timeout: 8)
        )
        XCTAssertTrue(app.buttons["wardrobe.item.sunshine-bow"].isSelected)
    }

    @MainActor
    func testZAccessibilityAuditOnArcadeLandingInLightAndDark() throws {
        for style in ["Light", "Dark"] {
            let app = launchFreshApp(
                shortMinigames: false,
                extraArguments: ["-AppleInterfaceStyle", style]
            )
            tap(app.buttons["home.destination.arcade"], in: app)
            XCTAssertTrue(app.buttons["arcade.play.carrotCatch"].waitForExistence(timeout: 8))

            if #available(iOS 17.0, *) {
                try app.performAccessibilityAudit(
                    for: [
                        .contrast,
                        .hitRegion,
                        .sufficientElementDescription,
                        .textClipped,
                    ]
                )
            }
            attachHomeScreenshot(named: "Gooby Wave 2 — \(style) Theme")
            app.terminate()
        }
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
    private func waitForLabelContaining(
        _ fragment: String,
        identifier: String,
        in app: XCUIApplication,
        timeout: TimeInterval = 8
    ) {
        let predicate = NSPredicate(format: "label CONTAINS %@", fragment)
        let element = app.staticTexts
            .matching(identifier: identifier)
            .matching(predicate)
            .firstMatch
        XCTAssertTrue(
            element.waitForExistence(timeout: timeout),
            "Expected \(identifier) to contain \(fragment)"
        )
    }

    @MainActor
    private func launchFreshApp(
        shortMinigames: Bool,
        contentSizeCategory: String? = nil,
        extraArguments: [String] = []
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
        app.launchArguments.append(contentsOf: extraArguments)
        app.launch()
        XCTAssertTrue(app.staticTexts["gooby.status"].waitForExistence(timeout: 12))
        return app
    }

    @MainActor
    private func waitForEchoInput(
        round: Int,
        input: Int,
        count: Int,
        in app: XCUIApplication
    ) {
        let predicate = NSPredicate(
            format: "identifier == %@ AND label CONTAINS %@",
            "echo.status",
            "input \(input) of \(count)"
        )
        XCTAssertTrue(
            app.staticTexts.matching(predicate).firstMatch.waitForExistence(timeout: 10),
            "Garden Echo round \(round) never entered input \(input) of \(count)"
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
