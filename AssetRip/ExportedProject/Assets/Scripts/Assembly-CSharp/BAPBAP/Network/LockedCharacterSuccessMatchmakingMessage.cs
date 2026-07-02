using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class LockedCharacterSuccessMatchmakingMessage
	{
		[Serializable]
		public class Payload
		{
			public bool locked;
		}

		public string @event;

		public Payload payload;
	}
}
