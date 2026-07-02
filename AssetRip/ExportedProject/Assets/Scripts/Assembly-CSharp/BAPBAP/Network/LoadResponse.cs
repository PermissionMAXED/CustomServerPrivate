using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class LoadResponse
	{
		[Serializable]
		public class Asset
		{
			[Preserve]
			public int assetId;

			[Preserve]
			public int balance;
		}

		[Serializable]
		public class InviteCode
		{
			[Preserve]
			public string code;

			[Preserve]
			public int usesLeft;

			[Preserve]
			public int usesTotal;
		}

		[Serializable]
		public class Loadout
		{
			[Preserve]
			public int bannerId;

			[Preserve]
			public int[] skins;
		}

		[Preserve]
		public string accountId;

		[Preserve]
		public string username;

		[Preserve]
		public int discriminator;

		[Preserve]
		public bool isGuest;

		[Preserve]
		public int level;

		[Preserve]
		public bool isAdmin;

		[Preserve]
		public bool isCompleted;

		[Preserve]
		public string email;

		[Preserve]
		public Asset[] assets;

		[Preserve]
		public InviteCode inviteCode;

		[Preserve]
		public Loadout loadout;

		[Preserve]
		public int totalGames;

		[Preserve]
		public bool friendRequestsOpen;

		[Preserve]
		public int[] availableCharacters;

		[Preserve]
		public bool blocked;

		[Preserve]
		public string creatorCode;

		[Preserve]
		public string creatorName;
	}
}
