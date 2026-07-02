using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class ProfileResponse
	{
		[Serializable]
		public class StatsData
		{
			[Preserve]
			public int gameModeId;

			[Preserve]
			public int totalAssists;

			[Preserve]
			public int totalDeaths;

			[Preserve]
			public int totalKills;

			[Preserve]
			public int totalLosses;

			[Preserve]
			public int totalWins;

			[Preserve]
			public int totalGames;
		}

		[Serializable]
		public class RankData
		{
			[Preserve]
			public int gameModeId;

			[Preserve]
			public int points;
		}

		[Serializable]
		public class HistoryData
		{
			[Serializable]
			public class TeammateData
			{
				public string accountId;

				public string name;

				public int charId;

				public bool isMvp;

				public int damageDealt;

				public int damageReceived;

				public int kills;

				public int deaths;

				public int assists;

				public int[] items;
			}

			[Preserve]
			public string gameId;

			[Preserve]
			public int charId;

			[Preserve]
			public int kills;

			[Preserve]
			public int deaths;

			[Preserve]
			public int assists;

			[Preserve]
			public int damageDealt;

			[Preserve]
			public int damageReceived;

			[Preserve]
			public int healingReceived;

			[Preserve]
			public int placement;

			[Preserve]
			public bool isMvp;

			[Preserve]
			public int rankedPointsDelta;

			[Preserve]
			public int[] items;

			[Preserve]
			public int gameModeId;

			[Preserve]
			public int totalPlacements;

			[Preserve]
			public string startedAt;

			[Preserve]
			public TeammateData[] teammates;
		}

		[Preserve]
		public RankData[] rankStats;

		[Preserve]
		public StatsData[] stats;

		[Preserve]
		public HistoryData[] history;
	}
}
