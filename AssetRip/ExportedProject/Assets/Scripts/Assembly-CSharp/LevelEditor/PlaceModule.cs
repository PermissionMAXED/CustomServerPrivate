using BAPBAP.Maps;
using UnityEngine;

namespace LevelEditor
{
	public static class PlaceModule
	{
		public static Mesh moduleCombinedMesh;

		public static string currentModuleName;

		public static string currentModulePath;

		public static bool doCheckForCollision;

		public static bool showPlaceModuleSettings;

		public static Configuration Config => null;

		public static void EnableModulePlacement(string moduleName, string relativePath)
		{
		}

		public static void CreateModuleVisualizer(SerializedLevelHolder level)
		{
		}

		public static void PlaceModuleFromScene()
		{
		}

		public static void DoPlaceModule(SerializedLevelHolder level)
		{
		}

		public static void PlaceSerializedLevelInMap(SerializedLevelHolder level, Vector2Int placeCenterPos, int moduleRotId)
		{
		}

		public static void DrawModulePlacementGUI()
		{
		}
	}
}
