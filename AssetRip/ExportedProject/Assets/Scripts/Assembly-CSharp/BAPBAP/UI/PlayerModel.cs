using UnityEngine;

namespace BAPBAP.UI
{
	public class PlayerModel : Model
	{
		public string accountId;

		public string username;

		public int discriminator;

		public int level;

		public int status;

		public int lobbyCharId;

		public int selectedCharId;

		public bool isInQueue;

		public bool isLeader;

		public bool isReady;

		public bool isCustomReady;

		public bool isCharLocked;

		public bool isSpawnLeader;

		public Vector2 selectedSpawn;

		public LoadoutModel loadout;
	}
}
