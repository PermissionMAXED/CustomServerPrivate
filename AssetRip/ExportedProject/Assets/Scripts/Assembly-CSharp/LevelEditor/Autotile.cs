using BAPBAP.Maps;
using UnityEngine;

namespace LevelEditor
{
	public static class Autotile
	{
		public static GameObject currentTargetPrefab;

		public static Vector2 centerPosition;

		public static Vector2 worldPos;

		public static AssetPalette.AutotileAsset autotileAsset;

		public static bool extendOutOfBounds;

		public static bool executeAutotile;

		public const float topDir = 0f;

		public const float rightDir = 90f;

		public const float bottomDir = 180f;

		public const float leftDir = 270f;

		public static MapLayer mapLayer;

		public static bool showAutotileSettings;

		public static Configuration Config => null;

		public static void ExecuteAutotile(Vector2 worldPos, AssetPalette.AutotileAsset autotileAsset, MapLayer mapLayer, bool placedCenterTile = false)
		{
		}

		public static void SetAutotileAsset(AssetPalette.AutotileAsset _autotileAsset, MapLayer _mapLayer)
		{
		}

		public static void DoAutotile(Vector2 dirPos, bool isCenterTile = false)
		{
		}

		public static void PlaceTile(AssetPalette.VariationAsset variationAsset, float rotationId = 0f)
		{
		}

		public static bool TileExists(Vector2 worldPos, AssetPalette.AutotileAsset autotileAsset)
		{
			return false;
		}

		public static bool TileObjExists(GameObject tileToCheck, AssetPalette.AutotileAsset autotileAsset, bool includeCompatibleAssets = true)
		{
			return false;
		}

		public static GameObject FindTile(Vector2 worldPosition)
		{
			return null;
		}

		public static AssetPalette.AutotileAsset GetAutotileAsset(GameObject sourceObj, bool includeExtraValid = true)
		{
			return null;
		}

		public static void DrawAutotileGUI()
		{
		}
	}
}
