using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class LiveFeedInitializedMessage
	{
		[Serializable]
		public class Payload
		{
			public WinnerLiveFeedElement[] feed;
		}

		public string @event;

		public Payload payload;
	}
}
