using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class ChatUpdatedMessage
	{
		[Serializable]
		public class Payload
		{
			public string username;

			public string message;

			public bool isSystem;

			public bool isWhisper;

			public string senderAccountId;

			public string receiverAccountId;
		}

		public string @event;

		public Payload payload;
	}
}
