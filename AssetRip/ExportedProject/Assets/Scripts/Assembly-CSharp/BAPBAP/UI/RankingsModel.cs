namespace BAPBAP.UI
{
	public class RankingsModel : Model
	{
		public class GameModeEntry
		{
			public int gameModeId;

			public bool showRanks;

			public bool showPoints;

			public bool showCharacters;
		}

		public GameModeEntry[] gameModes;

		public bool isEnd;

		public int pageOffset;

		public LeaderboardEntryModel[] leaderboard;

		public LeaderboardEntryModel leaderboardSelf;
	}
}
