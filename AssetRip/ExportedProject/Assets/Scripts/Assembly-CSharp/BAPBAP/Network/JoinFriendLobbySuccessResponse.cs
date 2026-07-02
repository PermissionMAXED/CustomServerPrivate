using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class JoinFriendLobbySuccessResponse
	{
		[Serializable]
		public class Payload
		{
			[Preserve]
			public string lobbyId;
		}

		[Preserve]
		public Payload payload;
	}
}
