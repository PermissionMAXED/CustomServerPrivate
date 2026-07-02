using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class IapListingResponse
	{
		[Serializable]
		public class Listing
		{
			[Preserve]
			public string iapListingId;

			[Preserve]
			public string sku;

			[Preserve]
			public float usd;

			[Preserve]
			public Asset[] rewards;

			[Preserve]
			public Asset[] requirements;
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
		public Listing[] iapListings;
	}
}
