using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class JoinFriendLobbyMessage
	{
		[Serializable]
		public class Payload
		{
			public string accountId;
		}

		public string @event;

		public Payload payload;
	}
}
