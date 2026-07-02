using System.Collections.Generic;

namespace BAPBAP.UI
{
	public class CustomGameSettingsModel : Model
	{
		public int GameMode;

		public int MapId;

		public int TeamSize;

		public int MaxTeams;

		public int BotCount;

		public int BotDifficulty;

		public Dictionary<int, int[]> MapMappings;
	}
}
