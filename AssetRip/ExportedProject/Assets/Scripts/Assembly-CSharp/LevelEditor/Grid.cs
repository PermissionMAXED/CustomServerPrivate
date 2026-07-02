using UnityEngine;

namespace LevelEditor
{
	public static class Grid
	{
		public static LayerMask gridLayer;

		public static GameObject gridPrefab;

		public static GameObject gridObject;

		public static GameObject axisLockIndicatorObj;

		public static bool snapToGrid;

		public static bool showChunkSettings;

		public static GameObject chunkGridObj;

		public static int chunkSize;

		public static Configuration Config => null;

		public static void LoadReferences()
		{
		}

		public static void CreateGridObject()
		{
		}

		public static void DestroyGridObject()
		{
		}

		public static void UpdateGridSize()
		{
		}

		public static void Show()
		{
		}

		public static void Hide()
		{
		}

		public static void ChunksGUI()
		{
		}

		public static void UpdateChunkGridMaterial()
		{
		}

		public static void CreateChunkGridObject()
		{
		}

		public static void DestroyChunkGridObject()
		{
		}

		public static void DrawAxisLock()
		{
		}

		public static void SetGridSnapUnitSize(float size = 1f)
		{
		}

		public static void SetGridSnapDisabled()
		{
		}
	}
}
