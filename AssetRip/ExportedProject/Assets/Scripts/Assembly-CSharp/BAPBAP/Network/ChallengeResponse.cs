using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class ChallengeResponse
	{
		[Serializable]
		public class EarnLive
		{
			public string listingId;

			public string entitlementId;

			public int tier;

			public int numLives;

			public bool unlocked;

			public bool claimed;
		}

		[Preserve]
		public int prizePool;

		[Preserve]
		public int numSignUps;

		[Preserve]
		public int numSignUpsNeeded;

		[Preserve]
		public int signUpRate;

		[Preserve]
		public string deadline;

		[Preserve]
		public string refCode;

		[Preserve]
		public string twitchUsername;

		[Preserve]
		public int numReferrals;

		[Preserve]
		public int numGames;

		[Preserve]
		public EarnLive[] earnReferrals;

		[Preserve]
		public EarnLive[] earnTwitchDrops;

		[Preserve]
		public EarnLive[] earnGames;

		[Preserve]
		public float[] prizePoolSplit;
	}
}
