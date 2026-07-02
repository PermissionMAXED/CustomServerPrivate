using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class LobbyOpenMessage
	{
		[Serializable]
		public class Payload
		{
			public bool lobbyOpen;
		}

		public string @event;

		public Payload payload;
	}
}
