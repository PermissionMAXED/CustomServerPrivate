using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class CharacterUpdatedMessage
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
