using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class CharListingResponse
	{
		[Serializable]
		public class CharListing
		{
			[Preserve]
			public string listingId;

			[Preserve]
			public int levelRequirement;

			[Preserve]
			public Asset[] costs;

			[Preserve]
			public Asset[] rewards;

			[Preserve]
			public int charId;

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
		public CharListing[] charListings;
	}
}
