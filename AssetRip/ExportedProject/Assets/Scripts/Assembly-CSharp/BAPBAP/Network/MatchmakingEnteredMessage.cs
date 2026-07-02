using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class MatchmakingEnteredMessage
	{
		[Serializable]
		public class Payload
		{
			public PlayerData[] players;
		}

		public string @event;

		public Payload payload;
	}
}
