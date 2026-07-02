using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class ChallengeLiveFeedUpdatedMessage
	{
		[Serializable]
		public class Payload
		{
			public Feed[] feed;
		}

		[Serializable]
		public class Feed
		{
			public string username;

			public int discriminator;

			public int action;

			public int value;

			public string timestamp;
		}

		public string @event;

		public Payload payload;
	}
}
