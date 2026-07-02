using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class ChallengeClaimReferralLiveResponse
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
		public Asset[] rewards;
	}
}
