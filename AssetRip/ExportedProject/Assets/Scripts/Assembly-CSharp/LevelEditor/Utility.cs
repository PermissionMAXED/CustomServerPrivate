using System.Collections.Generic;
using BAPBAP.Maps;
using UnityEngine;

namespace LevelEditor
{
	public static class Utility
	{
		public static bool showReplaceTool;

		public static GameObject replaceToolSourcePrefab;

		public static GUIContent replaceToolSourceContent;

		public static GameObject replaceToolNewPrefab;

		public static GUIContent replaceToolNewContent;

		public static bool showSnapToFloorTool;

		public static float snapToFloorThreshold;

		public static bool showFindTool;

		public static GameObject findSourcePrefab;

		public static GUIContent findSourceContent;

		public static List<Vector3> foundWpLocations;

		public static int lastLocation;

		public static string lastFoundPrefab;

		public static Configuration Config => null;

		public static GameObject TryGetEditorVersionFromPrefab(GameObject originalPrefab)
		{
			return null;
		}

		public static bool TryGetEditorVersionFromPrefab(GameObject originalPrefab, out GameObject resultPrefab)
		{
			resultPrefab = null;
			return false;
		}

		public static void FocusCameraToLevel(Vector2 levelSize)
		{
		}

		public static void FocusCameraToLevel(Vector2 levelSize, Vector2 center)
		{
		}

		public static void FocusCameraToBounds(Bounds bounds)
		{
		}

		public static void FocusCameraToWorldObj(Vector3 worldPos, GameObject obj)
		{
		}

		public static void DrawReplaceToolGUI(bool onDock = false)
		{
		}

		public static void ExecuteReplaceTool(LevelData level, GameObject sourcePrefab, GameObject newPrefab, bool isLevelOpenedInEditor)
		{
		}

		public static void DrawSnapToFloorToolGUI(bool onDock = false)
		{
		}

		public static void ExecuteSnapToFloorTool(LevelData level, bool isLevelOpenedInEditor)
		{
		}

		public static void DrawFindToolGUI(bool onDock = false)
		{
		}

		public static void ExecuteFindTool(GameObject findPrefab)
		{
		}

		public static ProceduralLevelGeneration.GenerationSettings GetProceduralMapGenerationSettings(ProceduralLevelGeneration.BiomeSettings[] biomeSettings, int[] selectedBiomes, int playerSpawnCount, bool clearAllModuleSpawnPoints)
		{
			return null;
		}

		public static void GenerateProceduralMap(ProceduralLevelGeneration.BiomeSettings[] biomeSettings, int[] selectedBiomes, int playerSpawnCount, bool clearAllModuleSpawnPoints)
		{
		}
	}
}
