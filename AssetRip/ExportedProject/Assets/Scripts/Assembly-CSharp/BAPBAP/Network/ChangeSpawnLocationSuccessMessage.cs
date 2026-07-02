using System;
using UnityEngine;

namespace BAPBAP.Network
{
	[Serializable]
	public class ChangeSpawnLocationSuccessMessage
	{
		[Serializable]
		public class Payload
		{
			public Vector2 spawnLocation;
		}

		public string @event;

		public Payload payload;
	}
}
