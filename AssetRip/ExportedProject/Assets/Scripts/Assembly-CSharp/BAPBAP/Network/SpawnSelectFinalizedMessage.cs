using System;

namespace BAPBAP.Network
{
	[Serializable]
	public class SpawnSelectFinalizedMessage
	{
		[Serializable]
		public class Payload
		{
			public PlayerData[] players;

			public int spawnShowMillis;
		}

		public string @event;

		public Payload payload;
	}
}
