using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class SetFriendsResponse
	{
		[Serializable]
		public class Payload
		{
			[Preserve]
			public string accountId;

			[Preserve]
			public int avatarId;

			[Preserve]
			public string username;

			[Preserve]
			public int discriminator;

			[Preserve]
			public bool lobbyOpen;

			[Preserve]
			public int status;

			[Preserve]
			public int timestampStart;

			[Preserve]
			public int playerCount;

			[Preserve]
			public int maxPlayers;
		}

		[Preserve]
		public Payload payload;
	}
}
