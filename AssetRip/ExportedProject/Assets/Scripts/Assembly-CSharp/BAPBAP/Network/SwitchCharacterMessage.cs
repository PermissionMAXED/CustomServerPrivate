using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class SwitchCharacterMessage
	{
		[Serializable]
		public class Payload
		{
			public int charId;
		}

		public string @event;

		public Payload payload;
	}
}
