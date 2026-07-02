using System;
using UnityEngine;

namespace BAPBAP.Network
{
	[Serializable]
	public class MatchmakingDimensionData
	{
		public int dimensionId;

		public Vector2 spawnPoint;

		public float radius;

		public override string ToString()
		{
			return null;
		}
	}
}
