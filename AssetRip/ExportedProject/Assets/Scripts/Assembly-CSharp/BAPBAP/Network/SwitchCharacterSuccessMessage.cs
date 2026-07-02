using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class SwitchCharacterSuccessMessage
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
