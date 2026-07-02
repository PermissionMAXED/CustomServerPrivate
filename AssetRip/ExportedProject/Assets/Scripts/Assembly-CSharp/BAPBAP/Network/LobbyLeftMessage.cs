using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class LobbyLeftMessage
	{
		[Serializable]
		public class Payload
		{
			public string accountId;

			public string username;

			public string leaderAccountId;
		}

		public string @event;

		public Payload payload;
	}
}
