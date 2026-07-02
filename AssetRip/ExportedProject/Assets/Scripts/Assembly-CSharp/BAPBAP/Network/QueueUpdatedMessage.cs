using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class QueueUpdatedMessage
	{
		[Serializable]
		public class Payload
		{
			public int currentPlayerCount;

			public int maxPlayerCount;
		}

		public string @event;

		public Payload payload;
	}
}
