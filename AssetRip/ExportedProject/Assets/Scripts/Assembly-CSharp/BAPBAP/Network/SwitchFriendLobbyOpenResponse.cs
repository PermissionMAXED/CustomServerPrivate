using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class SwitchFriendLobbyOpenResponse
	{
		[Serializable]
		public class Payload
		{
			[Preserve]
			public string accountId;

			[Preserve]
			public bool lobbyOpen;
		}

		[Preserve]
		public Payload payload;
	}
}
