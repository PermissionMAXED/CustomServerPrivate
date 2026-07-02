using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class SendWhisperMessage
	{
		[Serializable]
		public class Payload
		{
			public string accountId;

			public string message;
		}

		public string @event;

		public Payload payload;
	}
}
