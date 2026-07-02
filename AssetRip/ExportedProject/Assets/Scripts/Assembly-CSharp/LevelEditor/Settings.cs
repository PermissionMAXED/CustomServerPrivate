using System.Collections.Generic;
using BAPBAP.Maps;
using UnityEngine;

namespace LevelEditor
{
	public static class Settings
	{
		public const string rootFolderPath = "Assets/LevelEditor";

		public const string imagePath = "/Images";

		public const string prefabsPath = "/Prefabs";

		public const string materialsPath = "/Materials";

		public const string thumbnailPath = "/Thumbnails";

		public const string GUISkinsPath = "/GUISkins";

		public const string referenceImagePath = "/References";

		public const string configPath = "/LevelEditorConfig.asset";

		public static int prevTilemapSizeX;

		public static int prevTilemapSizeY;

		public static int maxTilemapSize;

		public static bool resizingLevel;

		public static int resizeLevelSelectedPivot;

		public static int levelResizeOffsetX;

		public static int levelResizeOffsetY;

		public static GameObject levelResizeGizmo;

		public static GUIContent[] pivotPointGridContent;

		public static float tilemapUnitSize;

		public static float[] offGridSteps;

		public static int offGridStepIndex;

		public static bool showInterfaceSettings;

		public static bool showDebugSettings;

		public static bool showStatisticsSettings;

		public static bool showMapToolsSettings;

		public static bool showToolSettings;

		public static bool showPlaymodeSettings;

		public static bool showCameraSettings;

		public static bool autoThumbRebuildEnabled;

		public static string debugEntityStatsStr;

		public static string debugWalkableAreaStr;

		public static bool showNamedModSettings;

		public static Vector2 settingsScrollPos;

		public static List<MeshRenderer> namedModuleVisualizers;

		public static bool biomeMapPaintEnabled;

		public static float mapPaintVisAlpha;

		public static Color[] biomeColorsByIndex;

		public static GameObject biomePreviewObj;

		public static bool ambienceMapPaintEnabled;

		public static Color[] ambienceColorsByIndex;

		public static GameObject ambiencePreviewObj;

		public static Configuration Config => null;

		public static LevelEditorMonoController LvlEditorMono => null;

		public static void Initialize(bool loadEmptyLevel = true)
		{
		}

		public static void Reset()
		{
		}

		public static void SettingsGUI()
		{
		}

		public static void DrawSaveSettings()
		{
		}

		public static void DrawInterfaceSettingsGUI()
		{
		}

		public static void DrawMapToolsGUI()
		{
		}

		public static void DrawToolSettingsGUI()
		{
		}

		public static void DrawStatisticsSettingsGUI()
		{
		}

		public static string GetEntitiesStats()
		{
			return null;
		}

		public static void DrawDebugSettingsGUI()
		{
		}

		public static void DrawPlaymodeSettingsGUI()
		{
		}

		public static void DrawCameraSettingsGUI(bool onDock = false)
		{
		}

		public static void SetLevelResizing(bool isEnabled)
		{
		}

		public static void DrawResizeLevelGUI()
		{
		}

		public static Vector2 GetPivotPointVector()
		{
			return default(Vector2);
		}

		public static void NamedModuleSettingsGUI()
		{
		}

		public static void InitializeNamedModuleVis(MapSettings settings)
		{
		}

		public static void EnablePickingOnNamedModGizmos()
		{
		}

		public static void BiomeMapGUI()
		{
		}

		public static void FillBiomeMap(int biomeId)
		{
		}

		public static void SetBiomeMapTile(Vector2Int tilePos, int id)
		{
		}

		public static void VisualizeBiomeMap()
		{
		}

		public static void AmbienceMapGUI()
		{
		}

		public static void SetAmbienceMapTile(Vector2Int tilePos, int id)
		{
		}

		public static void VisualizeAmbienceMap()
		{
		}

		public static Texture2D GetImage(string fileName)
		{
			return null;
		}

		public static Texture2D GetThumbnail(string fileName)
		{
			return null;
		}

		public static List<Sprite> GetAllReferenceImages()
		{
			return null;
		}

		public static Configuration LoadConfig()
		{
			return null;
		}

		public static List<T> GetAllAssetsOfType<T>(string folderPath) where T : Object
		{
			return null;
		}

		public static void ResetSettings()
		{
		}

		public static string GetWalkableArea()
		{
			return null;
		}

		public static float CalculateTriangleArea(Vector3 vertex1, Vector3 vertex2, Vector3 vertex3)
		{
			return 0f;
		}
	}
}
