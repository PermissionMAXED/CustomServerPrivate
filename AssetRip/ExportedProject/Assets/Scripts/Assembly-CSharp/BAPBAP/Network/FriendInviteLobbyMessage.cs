using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class FriendInviteLobbyMessage
	{
		[Serializable]
		public class Payload
		{
			public string accountId;

			public string lobbyId;
		}

		public string @event;

		public Payload payload;
	}
}
