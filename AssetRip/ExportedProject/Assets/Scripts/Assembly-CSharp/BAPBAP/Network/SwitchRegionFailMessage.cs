using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class SwitchRegionFailMessage
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
