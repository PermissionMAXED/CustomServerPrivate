using BAPBAP.Game;
using UnityEngine;

namespace LevelEditor
{
	public static class LoadSaveGUI
	{
		public static int selectedLevel;

		public static int selectedModBiomeId;

		public static bool selectedModIsSelected;

		public static bool includeInBuild;

		public static bool createFloorForNavMesh;

		public static bool generateWaterEdges;

		public static bool selectedModRotationAllowed;

		public static int selectedModCategory;

		public static int selectedSubModule;

		public static string levelName;

		public static string levelFilename;

		public static Texture selectedLevelThumb;

		public static string windowField;

		public static string displayNameField;

		public static int selectedNamedModColorId;

		public static int selectedLoadTab;

		public static int prevSelectedLoadTab;

		public static int selectedSaveTab;

		public static bool saveAlreadyExists;

		public static bool showLoadWindow;

		public static bool showSaveWindow;

		public static bool showDeleteMapModalWindow;

		public static int windowWidth;

		public static int windowHeight;

		public static Vector2 mapWindowScrollPos;

		public static Vector2 moduleThemedPOIScrollPos;

		public static bool[] showBiomeModules;

		public static string[] _moduleCategoryNames;

		public static string[] mapToolBar;

		public static string[] orderOptions;

		public static int selectedOrderOption;

		public static Vector2 zoneRoundsScrollPos;

		public static string[] moduleCategoryNames => null;

		public static Configuration Config => null;

		public static void OnLoadLevel(bool isMap)
		{
		}

		public static void LoadLevel(bool isMap)
		{
		}

		public static void OnSaveLevel(bool isMap, bool doQuickSave)
		{
		}

		public static void SaveLevel(bool isMap, bool doQuickSave)
		{
		}

		public static void DeleteCurrentLevel(bool isMap)
		{
		}

		public static void DeleteLvlDataMap(string mapFileName)
		{
		}

		public static void DeleteSerializedMap(string mapFileName)
		{
		}

		public static void DeleteLvlDataModule(string moduleFileName, string modPath)
		{
		}

		public static void DeleteSerializedModule(string moduleFileName, string modPath)
		{
		}

		public static void OpenLoadWindow()
		{
		}

		public static void OpenSaveWindow()
		{
		}

		public static void DrawLoadWindow()
		{
		}

		public static void DrawSaveWindow()
		{
		}

		public static void DrawDeleteMapWindow()
		{
		}

		public static void DrawLevelList(GUIContent[] content, int biomeId, int moduleCategoryId, int subModuleSelect)
		{
		}

		public static void DrawModuleSettigs()
		{
		}

		public static void DrawSerializedMapZoneRoundSettings(float windowWidth, float windowHeight)
		{
		}

		public static void DrawZoneRoundProperty(string label, ref int zoneProperty)
		{
		}

		public static void DrawZoneRoundPropertyPercentage(string label, ref int zoneProperty, int minPerc = 0, int maxPerc = 100)
		{
		}

		public static string GetZoneMoveSpeedMsg(GameModeBattleRoyale.SerializedZoneRound zoneRound, float prevZoneClosePercentage)
		{
			return null;
		}

		public static float GetZoneMoveSpeed(GameModeBattleRoyale.SerializedZoneRound zoneRound, float prevZoneClosePercentage)
		{
			return 0f;
		}

		public static bool DoesLevelAlreadyExist()
		{
			return false;
		}

		public static string GetLevelModuleName(string tempFileName)
		{
			return null;
		}

		public static string GetLevelModulePath()
		{
			return null;
		}
	}
}
