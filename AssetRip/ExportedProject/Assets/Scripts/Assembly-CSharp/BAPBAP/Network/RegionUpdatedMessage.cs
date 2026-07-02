using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class RegionUpdatedMessage
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
