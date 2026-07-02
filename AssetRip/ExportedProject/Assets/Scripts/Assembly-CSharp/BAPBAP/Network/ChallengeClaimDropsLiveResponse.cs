using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class ChallengeClaimDropsLiveResponse
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
		public string entitlementId;

		[Preserve]
		public int purchases;

		[Preserve]
		public Asset[] rewards;
	}
}
