using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class JoinLobbyFailMessage
	{
		[Serializable]
		public class Payload
		{
			public string errorCode;
		}

		public string @event;

		public Payload payload;
	}
}
