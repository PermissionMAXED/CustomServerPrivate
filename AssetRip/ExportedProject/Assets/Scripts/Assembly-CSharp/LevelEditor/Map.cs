using System.Collections.Generic;
using BAPBAP.Maps;
using UnityEngine;

namespace LevelEditor
{
	public static class Map
	{
		public static LevelData levelData;

		public static int tilemapSizeX;

		public static int tilemapSizeY;

		public static Configuration Config => null;

		public static void ResizeMap(Vector2Int newSize, Vector2Int offset = default(Vector2Int))
		{
		}

		public static void SetMapTilemapSizeAndClear(Vector2Int size)
		{
		}

		public static void ClearCurrentLevel()
		{
		}

		public static void AddLevelDataOnPos(Vector2Int centerTilemapPos, LevelData levelDataToSet)
		{
		}

		public static void RemoveLevelArea(Vector2Int tilemapCenterPos, Vector2Int areaSize, MapLayer[] activeLayers = null)
		{
		}

		public static void SetAndUpdateTextureMaps()
		{
		}

		public static void SetAndUpdateBiomeMap()
		{
		}

		public static GameObject FindObjOnScene(Vector3 worldPos, MapLayer mapLayer, float mapObjRadius = 2f)
		{
			return null;
		}

		public static GameObject FindTilePrefabOnScene(Vector2 worldPos, MapLayer mapLayer)
		{
			return null;
		}

		public static GameObject FindTilePrefabOnTilemap(Vector2Int tilemapPos, MapLayer mapLayer)
		{
			return null;
		}

		public static GameObject FindMapObject(Vector3 worldPos, float mapObjRadius = 2f)
		{
			return null;
		}

		public static GameObject FindMapObject(Vector3 worldPos, MapLayer mapLayer, float mapObjRadius = 2f)
		{
			return null;
		}

		public static List<GameObject> FindMapObjectsInArea(Vector2Int tilePos, Vector2Int areaSize, MapLayer layer)
		{
			return null;
		}

		public static int GetTileId(int xGridPos, int yGridPos, MapLayer mapLayer)
		{
			return 0;
		}

		public static void SetTileId(int rotatedPrefabId, int xGridPos, int yGridPos, MapLayer mapLayer, bool loadIntoVisualizer = true, bool doPlaceAnim = true)
		{
		}

		public static void SetMapObject(int prefabId, Vector3 worldPos, Vector3 rot, Vector3 scale, MapLayer mapLayer, bool loadIntoVisualizer = true, bool doPlaceAnim = true)
		{
		}

		public static void DeleteMapObject(GameObject objInstance, bool loadIntoVisualizer = true)
		{
		}
	}
}
