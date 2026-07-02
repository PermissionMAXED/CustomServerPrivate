using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class KickTeammateMessage
	{
		[Serializable]
		public class Payload
		{
			public string accountId;
		}

		public string @event;

		public Payload payload;
	}
}
