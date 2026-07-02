using System;
using System.Collections.Generic;

namespace BAPBAP.UI
{
	[Serializable]
	public class CharacterPageModel : Model
	{
		[Serializable]
		public class CharListings
		{
			public CharListing[] charListings;
		}

		[Serializable]
		public class CharListing
		{
			public string listingId;

			public int charId;

			public int levelRequirement;

			public AssetModel[] costs;

			public int purchases;
		}

		[Serializable]
		public class CharTokenPass
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

				public int expiresAt;

				public int purchases;
			}

			public PassLevel[] passLevels;
		}

		public CharListings charListings;

		public int[] availableCharacters;

		public int[] charIdsInRotation;

		public HashSet<int> unlockedCharacters;

		public CharTokenPass tokenPass;

		public int charTokenCurrentLevel;

		public int charTokenXp;

		public int charTokenCurrentXp;

		public int charTokenXpNeeded;

		public int prevCharTokenCurrentLevel;

		public int prevCharTokenCurrentXp;

		public int charTokenMaxLevel;
	}
}
