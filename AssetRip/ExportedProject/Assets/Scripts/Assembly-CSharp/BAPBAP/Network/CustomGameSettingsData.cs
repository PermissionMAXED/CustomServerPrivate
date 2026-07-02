using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class CustomGameSettingsData
	{
		public int gamemode;

		public int mapId;

		public int teamSize;

		public int maxTeams;

		public int botCount;

		public int botDifficulty;
	}
}
