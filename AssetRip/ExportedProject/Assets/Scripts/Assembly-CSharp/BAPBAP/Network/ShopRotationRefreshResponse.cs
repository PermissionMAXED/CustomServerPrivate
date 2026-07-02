using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class ShopRotationRefreshResponse
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
		public ShopResponse.Listing[] rotationListings;

		[Preserve]
		public ShopResponse.Listing[] freebieListings;

		[Preserve]
		public int currentDropRefreshes;

		[Preserve]
		public Asset cost;
	}
}
