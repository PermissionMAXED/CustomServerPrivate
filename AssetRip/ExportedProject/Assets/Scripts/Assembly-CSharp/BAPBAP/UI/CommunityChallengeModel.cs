using System;

namespace BAPBAP.UI
{
	[Serializable]
	public class CommunityChallengeModel : Model
	{
		public class ClaimLiveEntry
		{
			public string ListingId;

			public string EntitlementId;

			public int Tier;

			public int NumLives;

			public bool Unlocked;

			public bool Claimed;

			public bool IsUnavailable;
		}

		public int PrizePool;

		public int NumSignUps;

		public int NumSignUpsNeeded;

		public int SignUpRate;

		public string Deadline;

		public string RefCode;

		public string TwitchUsername;

		public int NumReferrals;

		public int NumGames;

		public int CurrentLives;

		public ClaimLiveEntry[] EarnReferrals;

		public ClaimLiveEntry[] EarnTwitchDrops;

		public ClaimLiveEntry[] EarnGames;

		public float[] PrizePoolSplit;
	}
}
