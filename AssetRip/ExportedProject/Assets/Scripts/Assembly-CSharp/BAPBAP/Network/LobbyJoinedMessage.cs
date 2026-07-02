using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class LobbyJoinedMessage
	{
		[Serializable]
		public class Payload
		{
			public PlayerData player;
		}

		public string @event;

		public Payload payload;
	}
}
