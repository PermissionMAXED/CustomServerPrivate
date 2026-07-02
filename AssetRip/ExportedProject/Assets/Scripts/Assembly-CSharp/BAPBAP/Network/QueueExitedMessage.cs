using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class QueueExitedMessage
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
