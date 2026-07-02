using System;
using UnityEngine;

namespace BAPBAP.Network
{
	[Serializable]
	public class SpawnLocationUpdatedMatchmakingMessage
	{
		[Serializable]
		public class Payload
		{
			public string accountId;

			public Vector2 spawnLocation;
		}

		public string @event;

		public Payload payload;
	}
}
