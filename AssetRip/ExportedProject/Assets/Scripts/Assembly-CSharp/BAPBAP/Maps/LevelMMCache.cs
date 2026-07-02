using System;
using UnityEngine;

namespace BAPBAP.Maps
{
	[Serializable]
	public class LevelMMCache
	{
		public MapSettings mapSettings;

		public Vector2[] spawnPoints;

		public Vector2[] dimensionSpawnPoints;

		public LevelMMCache(MapSettings mapSettings, Vector2[] spawnPoints, Vector2[] dimensionSpawnPoints)
		{
		}
	}
}
