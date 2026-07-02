using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class JoinLobbySuccessMessage
	{
		[Serializable]
		public class Payload
		{
			public LobbyData lobby;

			public bool wasFull;

			public bool wasInvalid;

			public bool wasKicked;
		}

		public string @event;

		public Payload payload;
	}
}
