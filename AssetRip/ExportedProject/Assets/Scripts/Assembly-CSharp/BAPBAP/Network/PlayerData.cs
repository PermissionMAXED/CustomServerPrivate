using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class PlayerData
	{
		public string accountId;

		public string username;

		public int discriminator;

		public int level;

		public int charId;

		public int bannerId;

		public int[] skins;

		public int playerStatus;

		public bool isLeader;

		public bool isReady;

		public int teamId;

		public int spawnPosition;
	}
}
