import Foundation

public struct PetID: RawRepresentable, Codable, Hashable, Sendable {
    public let rawValue: String

    public init(rawValue: String) {
        self.rawValue = rawValue
    }

    public static let gooby = PetID(rawValue: "gooby")
}

public struct ItemID: RawRepresentable, Codable, Hashable, Sendable, Comparable {
    public let rawValue: String

    public init(rawValue: String) {
        self.rawValue = rawValue
    }

    public static func < (lhs: ItemID, rhs: ItemID) -> Bool {
        lhs.rawValue < rhs.rawValue
    }
}

public struct AchievementID: RawRepresentable, Codable, Hashable, Sendable, Comparable {
    public let rawValue: String

    public init(rawValue: String) {
        self.rawValue = rawValue
    }

    public static func < (lhs: AchievementID, rhs: AchievementID) -> Bool {
        lhs.rawValue < rhs.rawValue
    }

    public static let firstMeal = AchievementID(rawValue: "first-meal")
    public static let squeakyClean = AchievementID(rawValue: "squeaky-clean")
    public static let playtime = AchievementID(rawValue: "playtime")
    public static let carrotCollector = AchievementID(rawValue: "carrot-collector")
    public static let bestBunny = AchievementID(rawValue: "best-bunny")
}

public struct MinigameRunID: RawRepresentable, Codable, Hashable, Sendable {
    public let rawValue: String

    public init(rawValue: String) {
        self.rawValue = rawValue
    }
}

public struct GameInstant: Codable, Hashable, Sendable, Comparable {
    public let secondsSinceEpoch: Int64

    public init(secondsSinceEpoch: Int64) {
        self.secondsSinceEpoch = secondsSinceEpoch
    }

    public init(date: Date) {
        secondsSinceEpoch = Int64(date.timeIntervalSince1970.rounded(.down))
    }

    public static func < (lhs: GameInstant, rhs: GameInstant) -> Bool {
        lhs.secondsSinceEpoch < rhs.secondsSinceEpoch
    }

    public func adding(seconds: Int64) -> GameInstant {
        let (value, overflowed) = secondsSinceEpoch.addingReportingOverflow(seconds)
        guard overflowed else {
            return GameInstant(secondsSinceEpoch: value)
        }
        return GameInstant(secondsSinceEpoch: seconds >= 0 ? .max : .min)
    }
}

public struct NeedValue: Codable, Hashable, Sendable, Comparable {
    public static let range = 0 ... 1_000

    public private(set) var value: Int

    public init(_ value: Int) {
        self.value = value.clamped(to: Self.range)
    }

    public static func < (lhs: NeedValue, rhs: NeedValue) -> Bool {
        lhs.value < rhs.value
    }

    public mutating func adjust(by amount: Int, floor: Int = 0) {
        let boundedFloor = floor.clamped(to: Self.range)
        let (adjusted, overflowed) = value.addingReportingOverflow(amount)
        if overflowed {
            value = amount >= 0 ? Self.range.upperBound : boundedFloor
        } else {
            value = adjusted.clamped(to: boundedFloor ... Self.range.upperBound)
        }
    }

    public init(from decoder: Decoder) throws {
        let container = try decoder.singleValueContainer()
        self.init(try container.decode(Int.self))
    }

    public func encode(to encoder: Encoder) throws {
        var container = encoder.singleValueContainer()
        try container.encode(value)
    }
}

public struct Needs: Codable, Equatable, Sendable {
    public var fullness: NeedValue
    public var cleanliness: NeedValue
    public var energy: NeedValue
    public var fun: NeedValue

    public init(
        fullness: NeedValue,
        cleanliness: NeedValue,
        energy: NeedValue,
        fun: NeedValue
    ) {
        self.fullness = fullness
        self.cleanliness = cleanliness
        self.energy = energy
        self.fun = fun
    }

    public static let initial = Needs(
        fullness: NeedValue(800),
        cleanliness: NeedValue(800),
        energy: NeedValue(800),
        fun: NeedValue(800)
    )
}

public enum RoomID: String, Codable, CaseIterable, Hashable, Sendable {
    case kitchen
    case washroom
    case bedroom
    case playroom
}

public enum CosmeticSlot: String, Codable, CaseIterable, Sendable {
    case head
    case neck
    case face
    case body
    case paws
}

public enum CatalogItemKind: Codable, Equatable, Sendable {
    case cosmetic(slot: CosmeticSlot)
    case food(fullness: Int)
    case roomDecoration(room: RoomID)
}

public enum CatalogAcquisition: Codable, Equatable, Sendable {
    case shop
    case bond(level: Int)
    case daily(step: Int)
    case legacy
}

public struct CatalogItem: Codable, Equatable, Sendable, Identifiable {
    public let id: ItemID
    public let name: String
    public let description: String
    public let price: Int
    public let requiredBondLevel: Int
    public let kind: CatalogItemKind
    public let acquisition: CatalogAcquisition

    public init(
        id: ItemID,
        name: String,
        description: String = "",
        price: Int,
        requiredBondLevel: Int = 1,
        kind: CatalogItemKind,
        acquisition: CatalogAcquisition = .shop
    ) {
        self.id = id
        self.name = name
        self.description = description
        self.price = price
        self.requiredBondLevel = requiredBondLevel
        self.kind = kind
        self.acquisition = acquisition
    }
}

public enum GoobyCatalog {
    public static let gardenCarrot = ItemID(rawValue: "garden-carrot")
    public static let berryBun = ItemID(rawValue: "berry-bun")
    public static let starlightSoup = ItemID(rawValue: "starlight-soup")

    public static let sunshineBow = ItemID(rawValue: "sunshine-bow")
    public static let cloudCap = ItemID(rawValue: "cloud-cap")
    public static let roundSpecs = ItemID(rawValue: "round-specs")
    public static let starCape = ItemID(rawValue: "star-cape")
    public static let friendshipRibbon = ItemID(rawValue: "friendship-ribbon")
    public static let moonCrown = ItemID(rawValue: "moon-crown")

    // Gate 1 IDs remain valid so an old save never loses a purchased item.
    public static let cozyBow = ItemID(rawValue: "cozy-bow")
    public static let sunnyScarf = ItemID(rawValue: "sunny-scarf")
    public static let moonCap = ItemID(rawValue: "moon-cap")
    public static let cloudSlippers = ItemID(rawValue: "cloud-slippers")
    public static let carrotPlanter = ItemID(rawValue: "carrot-planter")

    public static let foods: [CatalogItem] = [
        CatalogItem(
            id: gardenCarrot,
            name: "Garden Carrot",
            description: "A crisp everyday snack.",
            price: 3,
            kind: .food(fullness: 250)
        ),
        CatalogItem(
            id: berryBun,
            name: "Berry Bun",
            description: "A soft berry swirl for a hungry bunny.",
            price: 8,
            kind: .food(fullness: 400)
        ),
        CatalogItem(
            id: starlightSoup,
            name: "Starlight Soup",
            description: "A warm bowl that fills Gooby right up.",
            price: 14,
            requiredBondLevel: 2,
            kind: .food(fullness: 600)
        ),
    ]

    public static let cosmetics: [CatalogItem] = [
        CatalogItem(
            id: sunshineBow,
            name: "Sunshine Bow",
            description: "A golden bow worn neatly at the neck.",
            price: 20,
            kind: .cosmetic(slot: .neck)
        ),
        CatalogItem(
            id: cloudCap,
            name: "Cloud Cap",
            description: "A soft blue cap with a tiny cloud puff.",
            price: 28,
            kind: .cosmetic(slot: .head)
        ),
        CatalogItem(
            id: roundSpecs,
            name: "Round Specs",
            description: "Sunny round frames for Gooby’s bright eyes.",
            price: 35,
            requiredBondLevel: 2,
            kind: .cosmetic(slot: .face)
        ),
        CatalogItem(
            id: starCape,
            name: "Star Cape",
            description: "A midnight cape with a shining star clasp.",
            price: 50,
            requiredBondLevel: 2,
            kind: .cosmetic(slot: .body)
        ),
        CatalogItem(
            id: friendshipRibbon,
            name: "Friendship Ribbon",
            description: "A keepsake for reaching bond level 3.",
            price: 0,
            requiredBondLevel: 3,
            kind: .cosmetic(slot: .neck),
            acquisition: .bond(level: 3)
        ),
        CatalogItem(
            id: moonCrown,
            name: "Moon Crown",
            description: "A silver crown earned on day seven.",
            price: 0,
            kind: .cosmetic(slot: .head),
            acquisition: .daily(step: 7)
        ),
    ]

    public static let legacyItems: [CatalogItem] = [
        CatalogItem(
            id: cozyBow,
            name: "Cozy Bow",
            description: "A keepsake from Gooby’s first collection.",
            price: 20,
            kind: .cosmetic(slot: .head),
            acquisition: .legacy
        ),
        CatalogItem(
            id: sunnyScarf,
            name: "Sunny Scarf",
            description: "A keepsake from Gooby’s first collection.",
            price: 35,
            requiredBondLevel: 1,
            kind: .cosmetic(slot: .neck),
            acquisition: .legacy
        ),
        CatalogItem(
            id: moonCap,
            name: "Moon Cap",
            description: "A keepsake from Gooby’s first collection.",
            price: 60,
            requiredBondLevel: 2,
            kind: .cosmetic(slot: .head),
            acquisition: .legacy
        ),
        CatalogItem(
            id: cloudSlippers,
            name: "Cloud Slippers",
            description: "A keepsake from Gooby’s first collection.",
            price: 85,
            requiredBondLevel: 3,
            kind: .cosmetic(slot: .paws),
            acquisition: .legacy
        ),
        CatalogItem(
            id: carrotPlanter,
            name: "Carrot Planter",
            description: "A keepsake from Gooby’s first collection.",
            price: 100,
            requiredBondLevel: 4,
            kind: .roomDecoration(room: .kitchen),
            acquisition: .legacy
        ),
    ]

    public static let shopItems = foods + cosmetics.filter { $0.acquisition == .shop }
    public static let items = foods + cosmetics + legacyItems

    public static func item(id: ItemID) -> CatalogItem? {
        items.first { $0.id == id }
    }
}

public struct EquippedCosmetics: Codable, Equatable, Sendable {
    public var head: ItemID?
    public var neck: ItemID?
    public var face: ItemID?
    public var body: ItemID?
    public var paws: ItemID?

    public init(
        head: ItemID? = nil,
        neck: ItemID? = nil,
        face: ItemID? = nil,
        body: ItemID? = nil,
        paws: ItemID? = nil
    ) {
        self.head = head
        self.neck = neck
        self.face = face
        self.body = body
        self.paws = paws
    }

    public subscript(slot: CosmeticSlot) -> ItemID? {
        get {
            switch slot {
            case .head: head
            case .neck: neck
            case .face: face
            case .body: body
            case .paws: paws
            }
        }
        set {
            switch slot {
            case .head: head = newValue
            case .neck: neck = newValue
            case .face: face = newValue
            case .body: body = newValue
            case .paws: paws = newValue
            }
        }
    }

    private enum CodingKeys: String, CodingKey {
        case head
        case neck
        case face
        case body
        case paws
    }

    public init(from decoder: Decoder) throws {
        let container = try decoder.container(keyedBy: CodingKeys.self)
        head = try container.decodeIfPresent(ItemID.self, forKey: .head)
        neck = try container.decodeIfPresent(ItemID.self, forKey: .neck)
        face = try container.decodeIfPresent(ItemID.self, forKey: .face)
        body = try container.decodeIfPresent(ItemID.self, forKey: .body)
        paws = try container.decodeIfPresent(ItemID.self, forKey: .paws)
    }
}

public struct LocalDayKey: RawRepresentable, Codable, Hashable, Sendable, Comparable {
    public let rawValue: String

    public init(rawValue: String) {
        self.rawValue = rawValue
    }

    public static func < (lhs: LocalDayKey, rhs: LocalDayKey) -> Bool {
        lhs.rawValue < rhs.rawValue
    }
}

public struct DailyRewardState: Codable, Equatable, Sendable {
    /// Retained for schema 1/2 compatibility. New claims use `claimedLocalDays`.
    public var lastClaimedDay: Int64?
    /// The next reward is based on completed visits, not consecutive-day streaks.
    public var visitStep: Int
    public var claimedLocalDays: [LocalDayKey]

    public init(
        lastClaimedDay: Int64? = nil,
        streakStep: Int = 0,
        claimedLocalDays: [LocalDayKey] = []
    ) {
        self.lastClaimedDay = lastClaimedDay
        visitStep = streakStep
        self.claimedLocalDays = claimedLocalDays
    }

    public var streakStep: Int {
        get { visitStep }
        set { visitStep = newValue }
    }

    private enum CodingKeys: String, CodingKey {
        case lastClaimedDay
        case visitStep
        case streakStep
        case claimedLocalDays
    }

    public init(from decoder: Decoder) throws {
        let container = try decoder.container(keyedBy: CodingKeys.self)
        lastClaimedDay = try container.decodeIfPresent(Int64.self, forKey: .lastClaimedDay)
        visitStep = try container.decodeIfPresent(Int.self, forKey: .visitStep)
            ?? container.decodeIfPresent(Int.self, forKey: .streakStep)
            ?? 0
        claimedLocalDays = try container.decodeIfPresent(
            [LocalDayKey].self,
            forKey: .claimedLocalDays
        ) ?? []
    }

    public func encode(to encoder: Encoder) throws {
        var container = encoder.container(keyedBy: CodingKeys.self)
        try container.encodeIfPresent(lastClaimedDay, forKey: .lastClaimedDay)
        try container.encode(visitStep, forKey: .visitStep)
        try container.encode(claimedLocalDays, forKey: .claimedLocalDays)
    }
}

public enum DailyRewardEligibility: Equatable, Sendable {
    case eligible(step: Int)
    case alreadyClaimed(step: Int)
    case clockRollback
}

public enum DailyRewardSchedule {
    public static let secondsPerDay: Int64 = 86_400

    public static func eligibility(
        for reward: DailyRewardState,
        at now: GameInstant,
        localDay: LocalDayKey? = nil,
        cycleCount: Int = 7
    ) -> DailyRewardEligibility {
        let boundedCycleCount = max(1, cycleCount)
        let dayKey = localDay ?? utcDayKey(for: now)
        if reward.claimedLocalDays.contains(dayKey) {
            return .alreadyClaimed(step: max(1, min(reward.visitStep, boundedCycleCount)))
        }

        // Schema 1/2 saves only knew an integer UTC day. Preserve same-day
        // duplicate protection until migration materializes a local-day ledger.
        let utcDay = floorDividing(now.secondsSinceEpoch, by: secondsPerDay)
        if reward.claimedLocalDays.isEmpty, reward.lastClaimedDay == utcDay {
            return .alreadyClaimed(step: max(1, min(reward.visitStep, boundedCycleCount)))
        }

        let normalizedStep = max(0, reward.visitStep)
        return .eligible(step: (normalizedStep % boundedCycleCount) + 1)
    }

    public static func localDayKey(
        for instant: GameInstant,
        timeZone: TimeZone,
        calendar: Calendar = Calendar(identifier: .gregorian)
    ) -> LocalDayKey {
        var localCalendar = calendar
        localCalendar.timeZone = timeZone
        let date = Date(timeIntervalSince1970: TimeInterval(instant.secondsSinceEpoch))
        let components = localCalendar.dateComponents([.year, .month, .day], from: date)
        let year = components.year ?? 1970
        let month = components.month ?? 1
        let day = components.day ?? 1
        return LocalDayKey(
            rawValue: String(format: "%04d-%02d-%02d", year, month, day)
        )
    }

    public static func isValid(_ day: LocalDayKey) -> Bool {
        let parts = day.rawValue.split(separator: "-", omittingEmptySubsequences: false)
        guard parts.count == 3,
              parts[0].count == 4,
              parts[1].count == 2,
              parts[2].count == 2,
              let year = Int(parts[0]),
              let month = Int(parts[1]),
              let dayValue = Int(parts[2])
        else {
            return false
        }
        var calendar = Calendar(identifier: .gregorian)
        calendar.timeZone = TimeZone(secondsFromGMT: 0) ?? .gmt
        let components = DateComponents(
            calendar: calendar,
            timeZone: calendar.timeZone,
            year: year,
            month: month,
            day: dayValue
        )
        guard let date = calendar.date(from: components) else { return false }
        let roundTrip = calendar.dateComponents([.year, .month, .day], from: date)
        return roundTrip.year == year && roundTrip.month == month && roundTrip.day == dayValue
    }

    public static func utcDayKey(for instant: GameInstant) -> LocalDayKey {
        localDayKey(
            for: instant,
            timeZone: TimeZone(secondsFromGMT: 0) ?? .gmt
        )
    }

    public static func legacyUTCKey(day: Int64) -> LocalDayKey {
        let (seconds, overflowed) = day.multipliedReportingOverflow(by: secondsPerDay)
        return utcDayKey(
            for: GameInstant(secondsSinceEpoch: overflowed ? (day >= 0 ? .max : .min) : seconds)
        )
    }

    private static func floorDividing(_ value: Int64, by divisor: Int64) -> Int64 {
        let quotient = value / divisor
        let remainder = value % divisor
        return remainder < 0 ? quotient - 1 : quotient
    }
}

public struct CareStatistics: Codable, Equatable, Sendable {
    public var meals: Int
    public var baths: Int
    public var playSessions: Int

    public init(meals: Int = 0, baths: Int = 0, playSessions: Int = 0) {
        self.meals = meals
        self.baths = baths
        self.playSessions = playSessions
    }
}

public struct GamePreferences: Codable, Equatable, Sendable {
    public static let maximumPetNameLength = 20

    public var petName: String
    public var soundEnabled: Bool
    public var hapticsEnabled: Bool
    public var reduceMotionEnabled: Bool

    public init(
        petName: String = "Gooby",
        soundEnabled: Bool = true,
        hapticsEnabled: Bool = true,
        reduceMotionEnabled: Bool = false
    ) {
        self.petName = petName
        self.soundEnabled = soundEnabled
        self.hapticsEnabled = hapticsEnabled
        self.reduceMotionEnabled = reduceMotionEnabled
    }

    public static func validatedPetName(_ name: String) throws -> String {
        let trimmed = name.trimmingCharacters(in: .whitespacesAndNewlines)
        guard !trimmed.isEmpty else {
            throw GameRuleError.invalidPetName
        }
        guard trimmed.count <= maximumPetNameLength else {
            throw GameRuleError.petNameTooLong(maximum: maximumPetNameLength)
        }
        return trimmed
    }
}

public enum AchievementMetric: Codable, Equatable, Sendable {
    case meals
    case baths
    case playSessions
    case carrots
    case bondLevel
}

public struct AchievementDefinition: Codable, Equatable, Sendable, Identifiable {
    public let id: AchievementID
    public let title: String
    public let detail: String
    public let metric: AchievementMetric
    public let target: Int
    public let carrotReward: Int

    public init(
        id: AchievementID,
        title: String,
        detail: String,
        metric: AchievementMetric,
        target: Int,
        carrotReward: Int
    ) {
        self.id = id
        self.title = title
        self.detail = detail
        self.metric = metric
        self.target = target
        self.carrotReward = carrotReward
    }

    public func progress(in state: GameState) -> Int {
        switch metric {
        case .meals: state.careStatistics.meals
        case .baths: state.careStatistics.baths
        case .playSessions: state.careStatistics.playSessions
        case .carrots: state.carrots
        case .bondLevel: state.bondLevel
        }
    }
}

public enum GoobyAchievements {
    public static let definitions = [
        AchievementDefinition(
            id: .firstMeal,
            title: "First Meal",
            detail: "Share a snack with Gooby.",
            metric: .meals,
            target: 1,
            carrotReward: 5
        ),
        AchievementDefinition(
            id: .squeakyClean,
            title: "Squeaky Clean",
            detail: "Give Gooby a bubbly wash.",
            metric: .baths,
            target: 1,
            carrotReward: 5
        ),
        AchievementDefinition(
            id: .playtime,
            title: "Playtime",
            detail: "Play together once.",
            metric: .playSessions,
            target: 1,
            carrotReward: 8
        ),
        AchievementDefinition(
            id: .carrotCollector,
            title: "Carrot Collector",
            detail: "Hold 100 carrots at once.",
            metric: .carrots,
            target: 100,
            carrotReward: 15
        ),
        AchievementDefinition(
            id: .bestBunny,
            title: "Best Bunny",
            detail: "Reach bond level 4.",
            metric: .bondLevel,
            target: 4,
            carrotReward: 30
        ),
    ]

    public static func definition(id: AchievementID) -> AchievementDefinition? {
        definitions.first { $0.id == id }
    }
}

public struct GameState: Codable, Equatable, Sendable {
    public var petID: PetID
    public var createdAt: GameInstant
    public var lastSimulatedAt: GameInstant
    public var needs: Needs
    public var currentRoom: RoomID
    public var isSleeping: Bool
    public var carrots: Int
    public var bondPoints: Int
    public var ownedItems: [ItemID]
    public var foodInventory: [ItemID: Int]
    public var equippedCosmetics: EquippedCosmetics
    public var unlockedAchievements: [AchievementID]
    public var achievementUnlockDates: [AchievementID: GameInstant]
    public var dailyReward: DailyRewardState
    public var careStatistics: CareStatistics
    public var preferences: GamePreferences
    public var randomState: UInt64
    public var activeMinigame: ActiveMinigameRun?
    public var rewardedMinigameRuns: [MinigameRunID]
    public var bestMinigameScores: [MinigameKind: Int]

    public init(
        petID: PetID,
        createdAt: GameInstant,
        lastSimulatedAt: GameInstant,
        needs: Needs,
        currentRoom: RoomID,
        isSleeping: Bool,
        carrots: Int,
        bondPoints: Int,
        ownedItems: [ItemID],
        foodInventory: [ItemID: Int],
        equippedCosmetics: EquippedCosmetics,
        unlockedAchievements: [AchievementID],
        achievementUnlockDates: [AchievementID: GameInstant],
        dailyReward: DailyRewardState,
        careStatistics: CareStatistics,
        preferences: GamePreferences,
        randomState: UInt64,
        activeMinigame: ActiveMinigameRun?,
        rewardedMinigameRuns: [MinigameRunID],
        bestMinigameScores: [MinigameKind: Int]
    ) {
        self.petID = petID
        self.createdAt = createdAt
        self.lastSimulatedAt = lastSimulatedAt
        self.needs = needs
        self.currentRoom = currentRoom
        self.isSleeping = isSleeping
        self.carrots = carrots
        self.bondPoints = bondPoints
        self.ownedItems = ownedItems
        self.foodInventory = foodInventory
        self.equippedCosmetics = equippedCosmetics
        self.unlockedAchievements = unlockedAchievements
        self.achievementUnlockDates = achievementUnlockDates
        self.dailyReward = dailyReward
        self.careStatistics = careStatistics
        self.preferences = preferences
        self.randomState = randomState
        self.activeMinigame = activeMinigame
        self.rewardedMinigameRuns = rewardedMinigameRuns
        self.bestMinigameScores = bestMinigameScores
    }

    public static func new(now: GameInstant) -> GameState {
        GameState(
            petID: .gooby,
            createdAt: now,
            lastSimulatedAt: now,
            needs: .initial,
            currentRoom: .playroom,
            isSleeping: false,
            carrots: 30,
            bondPoints: 0,
            ownedItems: [],
            foodInventory: [GoobyCatalog.gardenCarrot: 3],
            equippedCosmetics: EquippedCosmetics(),
            unlockedAchievements: [],
            achievementUnlockDates: [:],
            dailyReward: DailyRewardState(),
            careStatistics: CareStatistics(),
            preferences: GamePreferences(),
            randomState: 0x474F_4F42_595F_5345,
            activeMinigame: nil,
            rewardedMinigameRuns: [],
            bestMinigameScores: [:]
        )
    }

    public var bondLevel: Int {
        BondProgress.level(for: bondPoints)
    }

    public func foodQuantity(_ itemID: ItemID) -> Int {
        max(0, foodInventory[itemID] ?? 0)
    }

    public func achievementDate(_ id: AchievementID) -> GameInstant? {
        achievementUnlockDates[id]
    }

    private enum CodingKeys: String, CodingKey {
        case petID
        case createdAt
        case lastSimulatedAt
        case needs
        case currentRoom
        case isSleeping
        case carrots
        case bondPoints
        case ownedItems
        case foodInventory
        case equippedCosmetics
        case unlockedAchievements
        case achievementUnlockDates
        case dailyReward
        case careStatistics
        case preferences
        case randomState
        case activeMinigame
        case rewardedMinigameRuns
        case bestMinigameScores
    }

    public init(from decoder: Decoder) throws {
        let container = try decoder.container(keyedBy: CodingKeys.self)
        petID = try container.decode(PetID.self, forKey: .petID)
        let decodedCreatedAt = try container.decode(GameInstant.self, forKey: .createdAt)
        createdAt = decodedCreatedAt
        lastSimulatedAt = try container.decode(GameInstant.self, forKey: .lastSimulatedAt)
        needs = try container.decode(Needs.self, forKey: .needs)
        currentRoom = try container.decode(RoomID.self, forKey: .currentRoom)
        isSleeping = try container.decode(Bool.self, forKey: .isSleeping)
        carrots = try container.decode(Int.self, forKey: .carrots)
        bondPoints = try container.decode(Int.self, forKey: .bondPoints)
        ownedItems = try container.decode([ItemID].self, forKey: .ownedItems)
        foodInventory = try container.decodeIfPresent(
            [ItemID: Int].self,
            forKey: .foodInventory
        ) ?? [GoobyCatalog.gardenCarrot: 3]
        equippedCosmetics = try container.decode(
            EquippedCosmetics.self,
            forKey: .equippedCosmetics
        )
        let decodedAchievements = try container.decode(
            [AchievementID].self,
            forKey: .unlockedAchievements
        )
        unlockedAchievements = decodedAchievements
        achievementUnlockDates = try container.decodeIfPresent(
            [AchievementID: GameInstant].self,
            forKey: .achievementUnlockDates
        ) ?? Dictionary(
            uniqueKeysWithValues: decodedAchievements.map { ($0, decodedCreatedAt) }
        )
        dailyReward = try container.decode(DailyRewardState.self, forKey: .dailyReward)
        careStatistics = try container.decode(CareStatistics.self, forKey: .careStatistics)
        preferences = try container.decodeIfPresent(
            GamePreferences.self,
            forKey: .preferences
        ) ?? GamePreferences()
        randomState = try container.decode(UInt64.self, forKey: .randomState)
        activeMinigame = try container.decodeIfPresent(
            ActiveMinigameRun.self,
            forKey: .activeMinigame
        )
        rewardedMinigameRuns = try container.decodeIfPresent(
            [MinigameRunID].self,
            forKey: .rewardedMinigameRuns
        ) ?? []
        bestMinigameScores = try container.decodeIfPresent(
            [MinigameKind: Int].self,
            forKey: .bestMinigameScores
        ) ?? [:]
    }
}

public enum BondProgress {
    public static let thresholds = [0, 25, 75, 150, 250, 400, 600, 850, 1_150, 1_500]
    public static let maximumLevel = thresholds.count

    public static func level(for points: Int) -> Int {
        (thresholds.lastIndex(where: { points >= $0 }) ?? 0) + 1
    }

    public static func progress(for points: Int) -> (current: Int, required: Int?) {
        let level = level(for: points)
        guard level < maximumLevel else {
            return (max(0, points - thresholds[maximumLevel - 1]), nil)
        }
        let floor = thresholds[level - 1]
        return (max(0, points - floor), thresholds[level] - floor)
    }

    public static func unlockedFeatures(at level: Int) -> [String] {
        let unlocks = [
            "care-basics",
            "garden-echo",
            "friendship-ribbon",
            "carrot-catch-plus",
            "moonlit-cosmetics",
            "cozy-garden",
            "sparkle-trails",
            "storybook-room",
            "golden-arcade",
            "best-bunny",
        ]
        return Array(unlocks.prefix(level.clamped(to: 1 ... unlocks.count)))
    }
}

public enum GameCommand: Codable, Equatable, Sendable {
    case move(to: RoomID)
    case feed
    case feedFood(itemID: ItemID)
    case wash
    case pet
    case play
    case beginSleep
    case endSleep
    case claimDailyReward
    case purchase(itemID: ItemID)
    case equip(itemID: ItemID)
    case unequip(slot: CosmeticSlot)
    case renamePet(String)
    case setSoundEnabled(Bool)
    case setHapticsEnabled(Bool)
    case setReduceMotionEnabled(Bool)
    case startMinigame(kind: MinigameKind)
    case pauseMinigame(runID: MinigameRunID)
    case resumeMinigame(runID: MinigameRunID)
    case cancelMinigame(runID: MinigameRunID)
    case setCarrotCatchTiming(runID: MinigameRunID, mode: CarrotCatchTimingMode)
    case advanceCarrotCatchCountdown(runID: MinigameRunID)
    case carrotCatchInput(runID: MinigameRunID, lane: Int?)
    case carrotCatchTimeout(runID: MinigameRunID)
    case gardenEchoBeginInput(runID: MinigameRunID)
    case gardenEchoInput(runID: MinigameRunID, symbol: Int)
    case gardenEchoReplay(runID: MinigameRunID)
    case finishMinigame(runID: MinigameRunID)
}

public enum GameEvent: Codable, Equatable, Sendable {
    case simulated(minutes: Int)
    case moved(RoomID)
    case fed
    case washed
    case petted
    case played
    case sleepChanged(Bool)
    case carrotsChanged(delta: Int, balance: Int)
    case bondLevelChanged(level: Int)
    case featureUnlocked(String)
    case achievementUnlocked(AchievementID, carrots: Int)
    case dailyRewardClaimed(step: Int, carrots: Int)
    case itemUnlocked(ItemID)
    case duplicateItemConverted(ItemID, carrots: Int)
    case purchased(ItemID)
    case purchaseAlreadyOwned(ItemID)
    case inventoryChanged(itemID: ItemID, quantity: Int)
    case foodConsumed(itemID: ItemID, quantity: Int)
    case equipped(ItemID, slot: CosmeticSlot)
    case unequipped(slot: CosmeticSlot)
    case petRenamed(String)
    case preferencesChanged
    case minigameStarted(ActiveMinigameRun)
    case minigamePauseChanged(runID: MinigameRunID, paused: Bool)
    case minigameProgressed(runID: MinigameRunID)
    case minigameCancelled(MinigameRunID)
    case minigameFinished(runID: MinigameRunID, score: Int, carrots: Int)
    case minigameRewardAlreadyGranted(MinigameRunID)
}

public enum GameRuleError: Error, Equatable, Sendable {
    case wrongRoom(required: RoomID)
    case petIsSleeping
    case insufficientCarrots(required: Int, available: Int)
    case insufficientEnergy(required: Int, available: Int)
    case unknownItem(ItemID)
    case itemLocked(requiredBondLevel: Int)
    case itemNotPurchasable(ItemID)
    case featureLocked(requiredBondLevel: Int)
    case itemNotOwned(ItemID)
    case itemNotEquippable(ItemID)
    case foodNotOwned(ItemID)
    case invalidPetName
    case petNameTooLong(maximum: Int)
    case dailyRewardAlreadyClaimed
    case clockRollback
    case minigameAlreadyActive
    case noActiveMinigame
    case invalidMinigameRun
    case invalidMinigameSubmission
    case minigameExpired
    case invalidSleepTransition
    case inventoryFull(ItemID)
}

extension Comparable {
    fileprivate func clamped(to range: ClosedRange<Self>) -> Self {
        min(max(self, range.lowerBound), range.upperBound)
    }
}
