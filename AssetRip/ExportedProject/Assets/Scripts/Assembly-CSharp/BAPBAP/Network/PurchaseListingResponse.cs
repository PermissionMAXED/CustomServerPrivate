using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class PurchaseListingResponse
	{
		[Serializable]
		public class Asset
		{
			[Preserve]
			public int assetId;

			[Preserve]
			public int amount;

			[Preserve]
			public int balance;
		}

		[Preserve]
		public string listingId;

		[Preserve]
		public int purchases;

		[Preserve]
		public Asset cost;

		[Preserve]
		public Asset[] rewards;
	}
}
