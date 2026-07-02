using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class JoinLobbyMessage
	{
		[Serializable]
		public class Payload
		{
			public string lobbyId;

			public int charId;

			public string version;

			public string regionId;

			public int gameModeId;

			public bool isAutoFill;

			public bool isInvite;

			public bool wasKicked;
		}

		public string @event;

		public Payload payload;
	}
}
