using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class SendChatFailMessage
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
