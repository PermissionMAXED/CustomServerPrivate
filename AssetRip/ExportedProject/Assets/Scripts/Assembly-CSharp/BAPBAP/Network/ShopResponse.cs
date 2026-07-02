using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class ShopResponse
	{
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
		public string timestamp;

		[Preserve]
		public Listing[] freebieListings;

		[Preserve]
		public Listing[] rotationListings;

		[Preserve]
		public int dropId;

		[Preserve]
		public string dropEndDate;

		[Preserve]
		public Listing[] consumableListings;

		[Preserve]
		public int currentDropRefreshes;

		[Preserve]
		public int maxDropRefreshes;
	}
}
