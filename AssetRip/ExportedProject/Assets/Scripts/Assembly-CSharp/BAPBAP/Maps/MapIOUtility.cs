using System.Collections.Generic;
using BAPBAP.Local.Rendering;
using UnityEngine;
using UnityEngine.AI;

namespace BAPBAP.Maps
{
	public static class MapIOUtility
	{
		public const string PATH_TO_LEVELS = "Levels";

		public const string PATH_TO_LEVELS_MAPS = "Levels/Maps";

		public const string PATH_TO_LEVELS_MODULES = "Levels/Modules";

		public const string RELATIVE_PATH_TO_POI = "/POI";

		public const string RELATIVE_PATH_TO_LANDMARK = "/Landmark";

		public const string RELATIVE_PATH_TO_REVIVE = "/Revive";

		public const string RELATIVE_PATH_TO_GENERIC = "/Generic";

		public static char _Char;

		public static string GetModulePathByModuleType(ModuleCategory moduleCategory)
		{
			return null;
		}

		public static ModuleTypeList[] GetAllModulesInAllBiomes(BiomeData biomeData)
		{
			return null;
		}

		public static ModuleTypeList[] GetAllModulesInBiomes(string[] biomeNames)
		{
			return null;
		}

		public static ModuleTypeList GetAllModuleTypesInBiome(string biomeName)
		{
			return default(ModuleTypeList);
		}

		public static string GetModuleNameFromModuleFilename(string filename)
		{
			return null;
		}

		public static string BuildModuleFilenameString(Vector2Int size, string selectedBiome, string modName)
		{
			return null;
		}

		public static string BuildMapFilenameString(Vector2Int size, string mapName)
		{
			return null;
		}

		public static string[] GetAllModulesInPath(string path)
		{
			return null;
		}

		public static string[] GetAllMapNamesInPath(string path, bool isModulePath = false)
		{
			return null;
		}

		public static string[] GetAllPrefabLevelPathsInPath(string path, string extension)
		{
			return null;
		}

		public static string[] GetAllPrebakedLevelNamesInPath(string path)
		{
			return null;
		}

		public static Dictionary<string, List<string>>[] GetAllModulesByPathInAllBiomes(BiomeData biomeData)
		{
			return null;
		}

		public static List<string[]> GetAllModuleNamesByPathInAllBiomesCombined(BiomeData biomeData)
		{
			return null;
		}

		public static Dictionary<string, List<string>> GetAllModulesByPathInBiome(string biomeName, ModuleTypeList moduleList)
		{
			return null;
		}

		public static void DeleteLevelFile(string path)
		{
		}

		public static GameObject LoadLevelSvDataPrefab(string levelFileName)
		{
			return null;
		}

		public static void SaveLevelSvDataPrefab(GameObject gameObject, string levelFileName)
		{
		}

		public static GameObject LoadLevelClDataPrefab(string levelFileName)
		{
			return null;
		}

		public static void SaveLevelClDataPrefab(GameObject gameObject, string levelFileName)
		{
		}

		public static LevelMMCacheData LoadLevelMMCache(string levelFileName)
		{
			return null;
		}

		public static void SaveLevelMMCache(LevelMMCache levelMMCache, string levelFileName)
		{
		}

		public static NavMeshData LoadNavData(string levelFileName)
		{
			return null;
		}

		public static void SaveNavData(NavMeshData navData, string levelFileName)
		{
		}

		public static MeshInstanceData LoadInstanceData(string levelFileName)
		{
			return null;
		}

		public static MeshInstanceData SaveInstanceData(List<MeshInstanceRenderer.DefinitionPositions> definitionDatas, string levelFileName)
		{
			return null;
		}

		public static MeshInstanceData SaveInstanceData(MeshInstanceData instanceData, string levelFileName)
		{
			return null;
		}

		public static SplatMapData LoadSplatMapData(string levelFileName)
		{
			return null;
		}

		public static SplatMapData SaveSplatMapData(Texture2D splatMap, string levelFileName)
		{
			return null;
		}

		public static Sprite LoadMapScreenshot(string levelFileName)
		{
			return null;
		}

		public static void SaveMapScreenshot(Texture2D screenshot, string levelFileName)
		{
		}
	}
}
