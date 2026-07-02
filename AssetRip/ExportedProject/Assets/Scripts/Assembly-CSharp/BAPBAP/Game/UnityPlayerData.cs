using System;
using System.Collections.Generic;

namespace BAPBAP.Game
{
	[Serializable]
	public class UnityPlayerData
	{
		public string accountId;

		public string username;

		public int discriminator;

		public string lobbyCode;

		public int points;

		public int charId;

		public int skinId;

		public int teamId;

		public int kills;

		public int deaths;

		public int assists;

		public int damageDealt;

		public int damageReceived;

		public int healingReceived;

		public int placement;

		public int lootableAbilityId;

		public long lostAt;

		public bool didConnect;

		public bool leavePenalty;

		public List<int> fpses;

		public List<int> pings;

		public List<int> items;

		public List<int> augments;

		public override string ToString()
		{
			return null;
		}
	}
}
