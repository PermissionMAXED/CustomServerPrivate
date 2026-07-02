using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class SpawnSelectTransitionedMessage
	{
		[Serializable]
		public class Payload
		{
			public int spawnSelectMillis;
		}

		public string @event;

		public Payload payload;
	}
}
