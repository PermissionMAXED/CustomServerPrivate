using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class SwitchCharacterFailMessage
	{
		[Serializable]
		public class Payload
		{
			public string errorCode;
		}

		public string @event;

		public Payload payload;
	}
}
