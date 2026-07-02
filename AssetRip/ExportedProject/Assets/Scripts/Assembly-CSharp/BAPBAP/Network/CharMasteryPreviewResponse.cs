using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class CharMasteryPreviewResponse
	{
		[Serializable]
		public class CharPass
		{
			[Preserve]
			public int passId;

			[Preserve]
			public PassLevel[] passLevels;
		}

		[Serializable]
		public class PassLevel
		{
			[Preserve]
			public int level;

			[Preserve]
			public int xpNeeded;

			[Preserve]
			public Listing[] listings;
		}

		[Serializable]
		public class Listing
		{
			[Preserve]
			public string listingId;

			[Preserve]
			public Asset[] costs;

			[Preserve]
			public Asset[] rewards;

			[Preserve]
			public int purchases;
		}

		[Serializable]
		public class Asset
		{
			[Preserve]
			public int assetId;

			[Preserve]
			public int amount;
		}

		[Preserve]
		public CharPass[] passes;
	}
}
