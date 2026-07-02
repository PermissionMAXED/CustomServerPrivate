using System;
using System.Collections.Generic;
using UnityEngine;

namespace BAPBAP.Maps
{
	public class LevelData
	{
		public class Layer
		{
			public MapTile[,] tilemap;

			public List<GameObject> rootGameObjects;

			public void ForEachTile(Action<MapTile, Vector2Int> action)
			{
			}

			public void Clear(Vector2Int size)
			{
			}
		}

		public Layer layerGround;

		public Layer layerObstacles;

		public Layer layerDecoration;

		public Layer layerHideAreas;

		public Layer layerMapEntities;

		public Layer layerCeiling;

		public MapSettings mapSettings;

		public int LayerLength => 0;

		public void SetTile(MapLayer mapLayer, Vector2Int tilemapPos, int rotPrefabId)
		{
		}

		public Layer layer(int layerIndex)
		{
			return null;
		}

		public Layer layer(MapLayer mapLayer)
		{
			return null;
		}

		public LevelData(Vector2Int size)
		{
		}

		public LevelData(LevelData levelData, bool deepCopy = false)
		{
		}

		public Vector2Int GetLevelSize()
		{
			return default(Vector2Int);
		}
	}
}
