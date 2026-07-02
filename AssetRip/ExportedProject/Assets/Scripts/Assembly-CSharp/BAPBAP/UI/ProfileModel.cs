using System.Collections.Generic;

namespace BAPBAP.UI
{
	public class ProfileModel : Model
	{
		public class Rank
		{
			public int gameModeId;

			public int rankPoints;
		}

		public class Stats
		{
			public int gameModeId;

			public int totalAssists;

			public int totalDeaths;

			public int totalKills;

			public int totalLosses;

			public int totalWins;
		}

		public class History
		{
			public int charId;

			public int assists;

			public int damageDealt;

			public int damageReceived;

			public int deaths;

			public string gameId;

			public int gameModeId;

			public int healingReceived;

			public int[] items;

			public int kills;

			public int placement;

			public bool isMvp;

			public int rankedPointsDelta;

			public string startedAt;

			public int totalPlacements;

			public List<TeammateHistory> teammates;
		}

		public class TeammateHistory
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

		public string profileName;

		public int profileDiscriminator;

		public int level;

		public readonly LoadoutModel loadout;

		public Rank[] ranks;

		public History[] history;

		public Stats[] stats;
	}
}
