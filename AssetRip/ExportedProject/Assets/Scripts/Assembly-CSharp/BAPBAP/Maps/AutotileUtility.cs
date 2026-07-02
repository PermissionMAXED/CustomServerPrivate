using UnityEngine;

namespace BAPBAP.Maps
{
	public static class AutotileUtility
	{
		public enum TileType
		{
			Center = 0,
			EdgeTop = 1,
			EdgeBottom = 2,
			EdgeLeft = 3,
			EdgeRight = 4,
			InnerTop = 5,
			InnerBottom = 6,
			InnerLeft = 7,
			InnerRight = 8,
			OuterTop = 9,
			OuterBottom = 10,
			OuterLeft = 11,
			OuterRight = 12,
			OuterJoin1 = 13,
			OuterJoin2 = 14
		}

		public const int topDir = 0;

		public const int rightDir = 1;

		public const int bottomDir = 2;

		public const int leftDir = 3;

		public static TileType DoAutotile(bool topNeighbor, bool leftNeighbor, bool rightNeighbor, bool botNeighbor, bool topLeftTileNeighbor, bool topRightTileNeighbor, bool botLeftTileNeighbor, bool botRightTileNeighbor)
		{
			return default(TileType);
		}

		public static int GetRotationIdFromTileType(TileType tileType, AssetPalette.AutotileAsset autotileAsset)
		{
			return 0;
		}

		public static AssetPalette.VariationAsset GetVariationAssetTypeFromAutotileAsset(TileType tileType, AssetPalette.AutotileAsset autotileAsset)
		{
			return null;
		}

		public static GameObject GetPrefabTypeFromAutotileAsset(TileType tileType, AssetPalette.AutotileAsset autotileAsset)
		{
			return null;
		}
	}
}
