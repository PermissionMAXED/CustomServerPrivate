using System;
using UnityEngine;

namespace BAPBAP.Network
{
	[Serializable]
	public class MatchmakingGameDataResponse
	{
		public MatchmakingGameDataResponseStatus status;

		public Vector2[] spawnPoints;

		public Vector2[] dimensionSpawnPoints;

		public override string ToString()
		{
			return null;
		}
	}
}
