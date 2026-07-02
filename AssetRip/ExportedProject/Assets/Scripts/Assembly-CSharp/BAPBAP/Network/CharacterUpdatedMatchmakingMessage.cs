using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class CharacterUpdatedMatchmakingMessage
	{
		[Serializable]
		public class Payload
		{
			public string accountId;

			public int charId;
		}

		public string @event;

		public Payload payload;
	}
}
