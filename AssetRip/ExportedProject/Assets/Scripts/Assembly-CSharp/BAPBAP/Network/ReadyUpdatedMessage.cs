using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class ReadyUpdatedMessage
	{
		[Serializable]
		public class Payload
		{
			public string accountId;

			public bool isReady;
		}

		public string @event;

		public Payload payload;
	}
}
