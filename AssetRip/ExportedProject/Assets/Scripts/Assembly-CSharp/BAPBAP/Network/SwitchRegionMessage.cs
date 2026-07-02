using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class SwitchRegionMessage
	{
		[Serializable]
		public class Payload
		{
			public string regionId;
		}

		public string @event;

		public Payload payload;
	}
}
