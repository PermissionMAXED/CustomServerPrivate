using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class SendChatMessage
	{
		[Serializable]
		public class Payload
		{
			public string message;
		}

		public string @event;

		public Payload payload;
	}
}
