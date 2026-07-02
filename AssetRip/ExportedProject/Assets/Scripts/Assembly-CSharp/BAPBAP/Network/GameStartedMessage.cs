using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class GameStartedMessage
	{
		[Serializable]
		public class Payload
		{
			public string gameAuthId;

			public string gameDns;

			public int wsPort;

			public int kcpPort;

			public int tcpPort;
		}

		public string @event;

		public Payload payload;
	}
}
