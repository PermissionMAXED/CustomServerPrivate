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
        GameInstant(secondsSinceEpoch: secondsSinceEpoch + seconds)
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

public enum RoomID: String, Codable, CaseIterable, Sendable {
    case kitchen
    case washroom
    case bedroom
    case playroom
}

public enum CosmeticSlot: String, Codable, CaseIterable, Sendable {
    case head
    case neck
    case paws
}

public enum CatalogItemKind: Codable, Equatable, Sendable {
    case cosmetic(slot: CosmeticSlot)
    case roomDecoration(room: RoomID)
}

public struct CatalogItem: Codable, Equatable, Sendable, Identifiable {
    public let id: ItemID
    public let name: String
    public let price: Int
    public let requiredBondLevel: Int
    public let kind: CatalogItemKind

    public init(
        id: ItemID,
        name: String,
        price: Int,
        requiredBondLevel: Int,
        kind: CatalogItemKind
    ) {
        self.id = id
        self.name = name
        self.price = price
        self.requiredBondLevel = requiredBondLevel
        self.kind = kind
    }
}

public enum GoobyCatalog {
    public static let cozyBow = ItemID(rawValue: "cozy-bow")
    public static let sunnyScarf = ItemID(rawValue: "sunny-scarf")
    public static let moonCap = ItemID(rawValue: "moon-cap")
    public static let cloudSlippers = ItemID(rawValue: "cloud-slippers")
    public static let carrotPlanter = ItemID(rawValue: "carrot-planter")

    public static let items: [CatalogItem] = [
        CatalogItem(
            id: cozyBow,
            name: "Cozy Bow",
            price: 20,
            requiredBondLevel: 0,
            kind: .cosmetic(slot: .head)
        ),
        CatalogItem(
            id: sunnyScarf,
            name: "Sunny Scarf",
            price: 35,
            requiredBondLevel: 1,
            kind: .cosmetic(slot: .neck)
        ),
        CatalogItem(
            id: moonCap,
            name: "Moon Cap",
            price: 60,
            requiredBondLevel: 2,
            kind: .cosmetic(slot: .head)
        ),
        CatalogItem(
            id: cloudSlippers,
            name: "Cloud Slippers",
            price: 85,
            requiredBondLevel: 3,
            kind: .cosmetic(slot: .paws)
        ),
        CatalogItem(
            id: carrotPlanter,
            name: "Carrot Planter",
            price: 100,
            requiredBondLevel: 4,
            kind: .roomDecoration(room: .kitchen)
        ),
    ]

    public static func item(id: ItemID) -> CatalogItem? {
        items.first { $0.id == id }
    }
}

public struct EquippedCosmetics: Codable, Equatable, Sendable {
    public var head: ItemID?
    public var neck: ItemID?
    public var paws: ItemID?

    public init(head: ItemID? = nil, neck: ItemID? = nil, paws: ItemID? = nil) {
        self.head = head
        self.neck = neck
        self.paws = paws
    }

    public subscript(slot: CosmeticSlot) -> ItemID? {
        get {
            switch slot {
            case .head: head
            case .neck: neck
            case .paws: paws
            }
        }
        set {
            switch slot {
            case .head: head = newValue
            case .neck: neck = newValue
            case .paws: paws = newValue
            }
        }
    }
}

public struct DailyRewardState: Codable, Equatable, Sendable {
    public var lastClaimedDay: Int64?
    public var streakStep: Int

    public init(lastClaimedDay: Int64? = nil, streakStep: Int = 0) {
        self.lastClaimedDay = lastClaimedDay
        self.streakStep = streakStep
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
    public var equippedCosmetics: EquippedCosmetics
    public var unlockedAchievements: [AchievementID]
    public var dailyReward: DailyRewardState
    public var careStatistics: CareStatistics
    public var randomState: UInt64
    public var activeMinigame: ActiveMinigameRun?
    public var rewardedMinigameRuns: [MinigameRunID]

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
            equippedCosmetics: EquippedCosmetics(),
            unlockedAchievements: [],
            dailyReward: DailyRewardState(),
            careStatistics: CareStatistics(),
            randomState: 0x474F_4F42_595F_5345,
            activeMinigame: nil,
            rewardedMinigameRuns: []
        )
    }

    public var bondLevel: Int {
        BondProgress.level(for: bondPoints)
    }
}

public enum BondProgress {
    public static let thresholds = [0, 25, 75, 150, 300]

    public static func level(for points: Int) -> Int {
        thresholds.lastIndex(where: { points >= $0 }) ?? 0
    }

    public static func unlockedFeatures(at level: Int) -> [String] {
        let unlocks = [
            "care-basics",
            "garden-echo",
            "sunny-scarf",
            "carrot-catch-plus",
            "moonlit-cosmetics",
        ]
        return Array(unlocks.prefix((level + 1).clamped(to: 1 ... unlocks.count)))
    }
}

public enum GameCommand: Codable, Equatable, Sendable {
    case move(to: RoomID)
    case feed
    case wash
    case play
    case beginSleep
    case endSleep
    case claimDailyReward
    case purchase(itemID: ItemID)
    case equip(itemID: ItemID)
    case startMinigame(kind: MinigameKind)
    case finishMinigame(runID: MinigameRunID, submission: MinigameSubmission)
}

public enum GameEvent: Codable, Equatable, Sendable {
    case simulated(minutes: Int)
    case moved(RoomID)
    case fed
    case washed
    case played
    case sleepChanged(Bool)
    case carrotsChanged(delta: Int, balance: Int)
    case bondLevelChanged(level: Int)
    case featureUnlocked(String)
    case achievementUnlocked(AchievementID)
    case dailyRewardClaimed(step: Int, carrots: Int)
    case purchased(ItemID)
    case purchaseAlreadyOwned(ItemID)
    case equipped(ItemID, slot: CosmeticSlot)
    case minigameStarted(ActiveMinigameRun)
    case minigameFinished(runID: MinigameRunID, score: Int, carrots: Int)
    case minigameRewardAlreadyGranted(MinigameRunID)
}

public enum GameRuleError: Error, Equatable, Sendable {
    case wrongRoom(required: RoomID)
    case insufficientCarrots(required: Int, available: Int)
    case insufficientEnergy(required: Int, available: Int)
    case unknownItem(ItemID)
    case itemLocked(requiredBondLevel: Int)
    case featureLocked(requiredBondLevel: Int)
    case itemNotOwned(ItemID)
    case itemNotEquippable(ItemID)
    case dailyRewardAlreadyClaimed
    case clockRollback
    case minigameAlreadyActive
    case noActiveMinigame
    case invalidMinigameRun
    case invalidMinigameSubmission
    case minigameExpired
}

extension Comparable {
    fileprivate func clamped(to range: ClosedRange<Self>) -> Self {
        min(max(self, range.lowerBound), range.upperBound)
    }
}
