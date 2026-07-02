using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace BAPBAP.Maps
{
	public static class MapUtility
	{
		public static int _layerLength;

		public static IEnumerable<MapLayer> layers;

		public static int layerLength => 0;

		public static IEnumerable<MapLayer> Layers => null;

		public static MapLayer GetTilemapLayerFromPrefabId(int prefabId, AssetPalette assetPalette)
		{
			return default(MapLayer);
		}

		public static Vector2Int GetTilemapPosFromWorldPos(float xWorldPos, float yWorldPos, int mapSizeX, int mapSizeY)
		{
			return default(Vector2Int);
		}

		public static Vector2Int GetTilemapPosFromWorldPos(Vector3 worldPos, Vector2Int mapSize)
		{
			return default(Vector2Int);
		}

		public static Vector2Int GetTilemapPosFromWorldPosRound(Vector3 worldPos, Vector2Int mapSize)
		{
			return default(Vector2Int);
		}

		public static Vector2Int GetTilemapPosFromWorldPosRound(float xWorldPos, float yWorldPos, int mapSizeX, int mapSizeY)
		{
			return default(Vector2Int);
		}

		public static Vector2 GetWorldPosFromTilemapPos(Vector2Int tilemapPos, Vector2Int mapSize)
		{
			return default(Vector2);
		}

		public static Vector2 GetWorldPosFromTilemapPos(int tilemapXPos, int tilemapYPos, int mapSizeX, int mapSizeY)
		{
			return default(Vector2);
		}

		public static Vector2 GetWorldPositionFromGridIndex(int gridIndex, int gridWidth, int gridHeight)
		{
			return default(Vector2);
		}

		public static Vector2Int GetTilemapPosFromGridIndex(int gridIndex, int gridWidth)
		{
			return default(Vector2Int);
		}

		public static int GetGridIndexFromTilemapPos(Vector2Int tilePos, int tilemapWidth)
		{
			return 0;
		}

		public static int ClampArrayCoord(int coord, int arrayDimensionSize)
		{
			return 0;
		}

		public static int GetPrefabIdFromPrefabObj(GameObject sourcePrefab, AssetPalette assetPalette)
		{
			return 0;
		}

		public static GameObject GetPrefabObjFromRotatedPrefabId(int rotatedPrefabId, AssetPalette assetPalette)
		{
			return null;
		}

		public static GameObject GetPrefabObjFromPrefabId(int prefabId, AssetPalette assetPalette)
		{
			return null;
		}

		public static int GetRotatedPrefabId(int prefabId, int rotationId)
		{
			return 0;
		}

		public static int GetPrefabIdFromRotatedPrefabId(int prefabId)
		{
			return 0;
		}

		public static AssetPalette.PrefabData GetPrefabDataFromPrefabId(int prefabId, AssetPalette assetPalette)
		{
			return null;
		}

		public static AssetPalette.PrefabData GetPrefabDataFromPrefab(GameObject prefab, AssetPalette assetPalette)
		{
			return null;
		}

		public static int GetRotIdFromPrefabRotatedId(int prefabRotatedId)
		{
			return 0;
		}

		public static float GetAngleFromPrefabRotatedId(int prefabRotatedId)
		{
			return 0f;
		}

		public static float GetAngleFromRotationId(int rotationId)
		{
			return 0f;
		}

		public static int GetRotIdFromAngle(float yRotation)
		{
			return 0;
		}

		public static GameObject SelectPrefabFromVariationAsset(AssetPalette.VariationAsset variationAsset)
		{
			return null;
		}

		public static int GetRandomRotationIdFromVariationAsset(AssetPalette.VariationAsset variationAsset)
		{
			return 0;
		}

		public static List<GameObject> GetMapObjectsSelection(Vector2Int mapSize, Vector2Int tileStartPos, Vector2Int tileEndPos, MapLayer mapLayer)
		{
			return null;
		}

		public static List<GameObject> GetMapObjectsSelection(Vector2Int mapSize, Vector2Int tileStartPos, Vector2Int tileEndPos)
		{
			return null;
		}

		public static GameObject GetMapObjectSelection(Vector2Int mapSize, Vector2Int tileStartPos, Vector2Int tileEndPos, MapLayer mapLayer)
		{
			return null;
		}

		public static GameObject GetClosestObjectSelection(Vector2 worldPos, MapLayer mapLayer, float searchRadius = 2f)
		{
			return null;
		}

		public static GameObject[] GetAllMapGameObjects()
		{
			return null;
		}

		public static GameObject[] GetAllMapGameObjects(Scene scene)
		{
			return null;
		}

		public static bool IsInvalidGameObjectToSelect(GameObject obj, bool onlyPrefabs = false)
		{
			return false;
		}

		public static bool IsPrefab(GameObject instanceObj)
		{
			return false;
		}

		public static GameObject GetPrefabFromMapObjInstance(GameObject instanceObj)
		{
			return null;
		}

		public static void PlaceLevelOnLevelOnPos(Vector2Int centerTilemapPos, LevelData levelDataToAdd, LevelData targetLevelData)
		{
		}

		public static void SetLevelDataToLevelOnPos(Vector2Int centerTilemapPos, LevelData levelDataToAdd, Vector2Int targetLevelSize, Action<Vector2Int, MapLayer, int> addTileAction, Action<Vector2Int, int> addBiomeMapAction, Action<Vector2Int, byte> addAmbienceMapAction, Action<Vector2Int, Color> addSplatMapAction)
		{
		}

		public static void GetRotatedLevelOffsetAndSize(Vector2Int levelSize, int levelRotId, out Vector2Int tilemapRotOffset, out Vector2Int rotSize)
		{
			tilemapRotOffset = default(Vector2Int);
			rotSize = default(Vector2Int);
		}

		public static void RotateLevelData(LevelData levelData, int levelRotId, AssetPalette assetPalette)
		{
		}

		public static int[,] GetRotatedGrid(int[,] areaGrid, int levelRotId)
		{
			return null;
		}

		public static byte[,] GetRotatedGrid(byte[,] areaGrid, int levelRotId)
		{
			return null;
		}

		public static Color[,] GetRotatedPixelRect(Color[,] areaPixels, int levelRotId)
		{
			return null;
		}

		public static Vector2Int GetRotatedTilePosition(Vector2Int originalPosition, Vector2Int tilemapSize, int rotationId90)
		{
			return default(Vector2Int);
		}

		public static Vector2 GetRotatedWorldPosition(Vector2 originalPosition, int rotationId90)
		{
			return default(Vector2);
		}

		public static int RotatePrefabRotatedId(int originalRotatedPrefabId, int rotationId)
		{
			return 0;
		}

		public static int RotateAngleByRotationId(int angle, int rotationId)
		{
			return 0;
		}

		public static void IterateThroughLayers(Action<MapLayer> layerAction)
		{
		}
	}
}
