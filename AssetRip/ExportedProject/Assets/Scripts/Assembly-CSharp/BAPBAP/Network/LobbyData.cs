using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class LobbyData
	{
		public string lobbyId;

		public string leaderAccountId;

		public bool lobbyOpen;

		public PlayerData[] players;

		public SettingsData settings;
	}
}
