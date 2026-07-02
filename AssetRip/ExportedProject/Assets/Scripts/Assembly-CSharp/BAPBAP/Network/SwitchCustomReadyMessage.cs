using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class SwitchCustomReadyMessage
	{
		[Serializable]
		public class Payload
		{
			public bool isReady;
		}

		public string @event;

		public Payload payload;
	}
}
