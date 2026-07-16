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
        ]
        app.launch()
        defer { app.terminate() }

        XCTAssertTrue(app.staticTexts["gooby.status"].waitForExistence(timeout: 12))
        let hero = app.descendants(matching: .any)["home.gooby-hero"]
        XCTAssertTrue(hero.waitForExistence(timeout: 8))
        XCTAssertTrue(app.buttons["room.playroom"].isHittable)
        XCTAssertTrue(app.buttons["care.primary"].isHittable)
        waitForLabel("Playroom", identifier: "room.current", in: app)
        sleep(2)
        app.swipeUp()
        attachScreenshot(named: "Gooby Wave 2 — Playroom")
        scrollHomeToTop(in: app)
        tap(app.buttons["care.primary"], in: app)
        usleep(320_000)
        attachScreenshot(named: "Gooby Wave 2 — Play Animation")

        showRoom(.kitchen, in: app)
        tap(app.buttons["care.primary"], in: app)
        usleep(320_000)
        attachScreenshot(named: "Gooby Wave 2 — Feed Animation")
        XCTAssertTrue(app.staticTexts["care.confirmation"].waitForExistence(timeout: 5))

        showRoom(.washroom, in: app)
        tap(app.buttons["care.primary"], in: app)
        usleep(320_000)
        attachScreenshot(named: "Gooby Wave 2 — Wash Animation")

        let pet = app.buttons["care.pet"]
        tap(pet, in: app)
        usleep(320_000)
        attachScreenshot(named: "Gooby Wave 2 — Nuzzle Animation")
        for _ in 1 ..< 10 {
            usleep(240_000)
            tap(pet, in: app)
        }
        waitForLabel("Bond level 2 of 10", identifier: "bond.level", in: app)

        showRoom(.bedroom, in: app)
        tap(app.buttons["care.primary"], in: app)
        usleep(380_000)
        attachScreenshot(named: "Gooby Wave 2 — Sleep Animation")
        waitForLabel("Sleeping softly", identifier: "gooby.activity", in: app)
        tap(app.buttons["care.primary"], in: app)
        waitForLabel("Tap Gooby to pet", identifier: "gooby.activity", in: app)

        showRoom(.playroom, in: app)
        tap(app.buttons["home.destination.shop"], in: app)
        tap(app.buttons["shop.item.sunshine-bow"], in: app)
        XCTAssertTrue(
            app.descendants(matching: .any)["shop.preview.scene"]
                .waitForExistence(timeout: 8)
        )
        sleep(4)
        attachScreenshot(named: "Gooby Wave 2 — Shop Preview")
        tap(app.buttons["shop.buy.sunshine-bow"], in: app)
        XCTAssertTrue(app.staticTexts["Owned permanently"].waitForExistence(timeout: 8))
        tap(app.buttons["item-detail.back"], in: app)
        tap(app.buttons["sheet.close"], in: app)
        tap(app.buttons["home.destination.wardrobe"], in: app)
        tap(app.buttons["wardrobe.item.sunshine-bow"], in: app)
        XCTAssertTrue(
            app.descendants(matching: .any)["wardrobe.preview"]
                .waitForExistence(timeout: 8)
        )
        sleep(4)
        attachScreenshot(named: "Gooby Wave 2 — Wardrobe Preview")
        tap(app.buttons["wardrobe.equip"], in: app)
        XCTAssertTrue(app.buttons["wardrobe.unequip"].waitForExistence(timeout: 8))
        sleep(3)
        attachScreenshot(named: "Gooby Wave 2 — Sunshine Bow Equipped")
        tap(app.buttons["sheet.close"], in: app)
        scrollHomeToTop(in: app)
        sleep(3)
        attachScreenshot(named: "Gooby Wave 2 — Equipped Home")

        app.terminate()
        app.launchArguments = [
            "--ui-testing",
            "--skip-welcome",
            "--fixed-time",
            "1728000000",
        ]
        app.launch()
        XCTAssertTrue(app.staticTexts["gooby.status"].waitForExistence(timeout: 12))
        sleep(3)
        attachScreenshot(named: "Gooby Wave 2 — Equipped Home Relaunch")

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
        waitForLabel("200 points", identifier: "carrot.result.score", in: app)
        sleep(3)
        attachScreenshot(named: "Gooby Wave 2 — Carrot Catch Result")
        tap(app.buttons["carrot.done"], in: app)

        tap(app.buttons["arcade.play.gardenEcho"], in: app)
        tap(app.buttons["echo.start"], in: app)
        waitForLabelContaining(
            "Note 2 of 3",
            identifier: "echo.sequence-progress",
            in: app,
            timeout: 12
        )
        attachScreenshot(named: "Gooby Wave 2 — Garden Playback")
        for (roundIndex, sequence) in DemoSequence.echoRounds.enumerated() {
            for (inputIndex, pad) in sequence.enumerated() {
                waitForEchoInput(
                    round: roundIndex + 1,
                    input: inputIndex + 1,
                    count: sequence.count,
                    in: app
                )
                pressEchoPad(pad, in: app)
            }
        }
        waitForLabel("125 points", identifier: "echo.result.score", in: app)
        sleep(3)
        attachScreenshot(named: "Gooby Wave 2 — Garden Echo Result")
        tap(app.buttons["echo.done"], in: app)
        tap(app.buttons["arcade.close"], in: app)

        XCTAssertTrue(app.staticTexts["gooby.status"].waitForExistence(timeout: 8))
        scrollHomeToTop(in: app)
        waitForLabel("Playroom", identifier: "room.current", in: app)
        sleep(3)
        attachScreenshot(named: "Gooby Wave 2 — Natural Journey Complete")
    }

    @MainActor
    private func tap(_ element: XCUIElement, in app: XCUIApplication) {
        XCTAssertTrue(element.waitForExistence(timeout: 5))
        for _ in 0 ..< 6 {
            if element.isHittable {
                element.tap()
                return
            }
            app.swipeUp()
        }
        XCTFail("Element \(element) never became hittable")
    }

    @MainActor
    private func showRoom(_ room: DemoRoom, in app: XCUIApplication) {
        scrollHomeToTop(in: app)
        tap(app.buttons["room.\(room.rawValue)"], in: app)
        waitForLabel(room.displayName, identifier: "room.current", in: app)
        sleep(2)
        app.swipeUp()
        attachScreenshot(named: "Gooby Wave 2 — \(room.displayName)")
        scrollHomeToTop(in: app)
    }

    @MainActor
    private func scrollHomeToTop(in app: XCUIApplication) {
        for _ in 0 ..< 5 {
            app.swipeDown()
        }
        XCTAssertTrue(app.buttons["room.playroom"].waitForExistence(timeout: 5))
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
    private func waitForLabelContaining(
        _ fragment: String,
        identifier: String,
        in app: XCUIApplication,
        timeout: TimeInterval
    ) {
        let predicate = NSPredicate(
            format: "identifier == %@ AND label CONTAINS %@",
            identifier,
            fragment
        )
        XCTAssertTrue(
            app.staticTexts.matching(predicate).firstMatch.waitForExistence(timeout: timeout)
        )
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
            app.staticTexts.matching(predicate).firstMatch.waitForExistence(timeout: 16),
            "Garden Echo round \(round) never reached input \(input) of \(count)"
        )
    }

    @MainActor
    private func pressCarrotLane(_ lane: String, in app: XCUIApplication) {
        let button = app.buttons["carrot.lane.\(lane)"]
        for _ in 0 ..< 4 where !button.isHittable {
            app.swipeUp()
        }
        XCTAssertTrue(button.isHittable)
        button.tap()
    }

    @MainActor
    private func pressEchoPad(_ pad: String, in app: XCUIApplication) {
        let button = app.buttons["echo.pad.\(pad)"]
        for _ in 0 ..< 4 where !button.isHittable {
            app.swipeUp()
        }
        XCTAssertTrue(button.isHittable)
        button.tap()
    }

    @MainActor
    private func attachScreenshot(named name: String) {
        let attachment = XCTAttachment(screenshot: XCUIScreen.main.screenshot())
        attachment.name = name
        attachment.lifetime = .keepAlways
        add(attachment)
    }
}

private enum DemoRoom: String {
    case kitchen
    case washroom
    case bedroom
    case playroom

    var displayName: String {
        rawValue.prefix(1).uppercased() + String(rawValue.dropFirst())
    }
}

private enum DemoSequence {
    static let carrotLanes = [
        "left", "center", "center", "right", "center",
        "right", "right", "right", "center", "right",
        "left", "right", "right", "left", "right",
        "left", "center", "left", "right", "right",
    ]

    static let echoRounds = [
        ["leaf", "star", "leaf"],
        ["leaf", "star", "leaf", "leaf"],
        ["leaf", "star", "leaf", "leaf", "berry"],
        ["leaf", "star", "leaf", "leaf", "berry", "berry"],
        ["leaf", "star", "leaf", "leaf", "berry", "berry", "leaf"],
    ]
}
