using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class ChallengeUpdatedMessage
	{
		[Serializable]
		public class Payload
		{
			public int prizePool;

			public int numSignUps;
		}

		public string @event;

		public Payload payload;
	}
}
