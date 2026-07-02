using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class LiveFeedUpdatedMessage
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
