using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class LockedCharacterUpdatedMatchmakingMessage
	{
		[Serializable]
		public class Payload
		{
			public string accountId;

			public bool locked;
		}

		public string @event;

		public Payload payload;
	}
}
