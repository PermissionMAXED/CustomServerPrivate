using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class LeaderboardAllResponse
	{
		[Serializable]
		public class LeaderboardEntry
		{
			[Preserve]
			public string username;

			[Preserve]
			public int level;

			[Preserve]
			public int bannerId;

			[Preserve]
			public int wins;

			[Preserve]
			public int kills;

			[Preserve]
			public int rank;

			[Preserve]
			public int position;

			[Preserve]
			public bool isSelf;
		}

		[Preserve]
		public LeaderboardEntry[] top;

		[Preserve]
		public bool isEnd;

		[Preserve]
		public int pageOffset;
	}
}
