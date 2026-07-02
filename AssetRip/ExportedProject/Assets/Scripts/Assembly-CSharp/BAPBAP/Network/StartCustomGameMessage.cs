using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class StartCustomGameMessage
	{
		[Serializable]
		public class Payload
		{
			public bool forceStart;
		}

		public string @event;

		public Payload payload;
	}
}
