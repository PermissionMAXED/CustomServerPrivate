using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class MatchmakingPlayerData
	{
		public string username;

		public int discriminator;

		public string accountId;

		public string gameAuthId;

		public string lobbyCode;

		public int points;

		public int charId;

		public int skinAssetId;

		public int teamId;

		public int bannerId;

		public int level;

		public int playerId;

		public override string ToString()
		{
			return null;
		}
	}
}
