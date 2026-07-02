using System;
using System.Collections.Generic;

namespace BAPBAP.UI
{
	public class CharacterMasteryModel : Model
	{
		public class CharacterMastery
		{
			public MasteryPass masteryPass;

			public int xp;

			public readonly HashSet<int> claimedLevels;

			public readonly List<int> unlockedBadgeAssetIds;

			public int currentLevel;

			public int currentXp;

			public int currentXpNeeded;

			public int prevCurrentLevel;

			public int prevCurrentXp;
		}

		[Serializable]
		public class MasteryPass
		{
			[Serializable]
			public class PassLevel
			{
				public int level;

				public int xpNeeded;

				public Listing[] listings;
			}

			[Serializable]
			public class Listing
			{
				public string listingId;

				public int globalStock;

				public int accountStock;

				public AssetModel[] costs;

				public AssetModel[] rewards;

				public AssetModel[] requirements;

				public int expiresAt;

				public int purchases;
			}

			public int passId;

			public PassLevel[] passLevels;
		}

		public readonly Dictionary<int, CharacterMastery> charMasteries;
	}
}
