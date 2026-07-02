using System;
using System.Collections.Generic;

namespace BAPBAP.UI
{
	public class LobbyDataModel : Model
	{
		[Serializable]
		public class AccountPass
		{
			[Serializable]
			public class PassLevel
			{
				public int level;

				public int xpNeeded;
			}

			public PassLevel[] passLevels;
		}

		public class InviteCode
		{
			public string Code;

			public int UsesLeft;

			public int UsesTotal;
		}

		public class DailyReward
		{
			public string timestamp;

			public int progress;

			public int max;
		}

		public class FriendList
		{
			public List<Friend> friends;
		}

		public class Friend
		{
			public int avatarId;

			public string accountId;

			public string username;

			public int discriminator;

			public bool isOnline;

			public bool isLobbyOpen;

			public bool isInQueue;

			public bool isInGame;

			public PlayerStatus status;

			public int timestampStart;

			public int lobbyCount;

			public int maxLobbyCount;
		}

		public string lobbyId;

		public bool isInvited;

		public string LocalAccountId;

		public bool isOpenLobby;

		public GameModeModel[] gameModes;

		public FriendList friendsList;

		public FriendList friendRequests;

		public int gameModeId;

		public bool isAutoFill;

		public string regionId;

		public string leaderAccountId;

		public PlayerModel player;

		public List<PlayerModel> lobbyTeammates;

		public List<PlayerModel> mmTeammates;

		public int queueSize;

		public int queuePlayerCount;

		public bool mmIsCounting;

		public double mmStartingTime;

		public bool queueIsCounting;

		public int queueStartingDelay;

		public double queueStartingTime;

		public bool isMatchmaking;

		public bool isInQueue;

		public bool isInGame;

		public bool isAdmin;

		public bool isGuest;

		public bool isCompleted;

		public int gold;

		public int fractals;

		public int charTokens;

		public AccountPass accountPass;

		public int accountXp;

		public InviteCode inviteCode;

		public DailyReward dailyReward;

		public HashSet<int> ownedAssetIdData;

		public bool iapEnabled;

		public string creatorCode;

		public string creatorName;
	}
}
