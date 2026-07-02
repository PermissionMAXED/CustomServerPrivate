using System;
using System.Collections.Generic;
using BAPBAP.Utilities;
using Delaunay.Geo;
using LevelEditor;
using UnityEngine;

namespace BAPBAP.Maps
{
	public static class ProceduralLevelGeneration
	{
		[Serializable]
		public class GenerationSettings
		{
			public int mapUnitSize;

			public int biomeTextureMapResolution;

			public float biomeMapDistorsionAmount;

			public int[] selectedBiomeIds;

			public BiomeSettings[] biomeSettings;

			public int playerSpawnNumber;

			public bool clearAllModuleSpawnPoints;

			public AssetPalette assetPalette;

			public Material islandDistortMat;

			public Material biomeDistortMat;
		}

		[Serializable]
		public class GenerationMapData
		{
			public GenerationSettings settings;

			public Vector2Int gridSize;

			public float textureMapToMapUnitFactor;

			public Vector2 randomFlowTextOffset;

			public Vector2[] biomePointsNorm;

			public bool[,] waterHash;

			public int[,] biomeMapNoWater;

			public int[,] biomeMap;

			public bool[,] moduleHash;

			public bool[,] pathCarveHashGrid;

			public bool[,] pathHashGrid;

			public bool[,] obstacleHashGrid;

			public List<ModulePoint> poiModulePoints;

			public List<ModulePoint> normalModulePoints;

			public List<LineSegment> addedPaths;

			public List<Vector2Int> addedPlayerSpawns;

			public LevelData levelData;

			public List<ModulePoint> allModulePoints => null;

			public GenerationMapData(Vector2Int size)
			{
			}

			public GenerationMapData(GenerationMapData mapData)
			{
			}
		}

		[Serializable]
		public class BiomeSettings
		{
			public bool isSelected;

			public ModuleTypeSettings poiModuleSettings;

			public ModuleTypeSettings poiThemedModuleSettings;

			public ModuleTypeSettings landmarkModuleSettings;

			public ModuleTypeSettings reviveModuleSettings;

			public ModuleTypeSettings genericLargeModuleSettings;

			public ModuleTypeSettings genericMediumModuleSettings;

			public ModuleTypeSettings genericSmallModuleSettings;
		}

		[Serializable]
		public class ModuleTypeSettings
		{
			public bool isSelected;

			[NonSerialized]
			public bool[] modsSelected;

			public IntRange distToSelf;

			public IntRange distToOthers;

			public ModuleTypeSettings(bool _isSelected, IntRange _distToSelf, IntRange _distToOthers)
			{
			}
		}

		public struct AreaPoint
		{
			public Vector2Int position;

			public Vector2Int size;
		}

		public struct ModulePoint
		{
			public Vector2Int position;

			public Vector2Int rotatedSize;

			public int rotationId;

			public LevelData levelData;

			public string moduleName;
		}

		public class Generator
		{
			public class GenStep
			{
				public Generator generator;

				public Action<GenerationMapData> action;

				public Action<GenerationMapData> debugVisualizeAction;

				public Action<GenerationMapData> debugClearVisualizeAction;

				public Action GUIAction;

				public Action<Generator> manualStepGUIAction;

				public string name;

				public bool allowRegeneration;

				public GenStep(Generator generator, Action<GenerationMapData> action, Action<GenerationMapData> debugVisualizeAction, Action<GenerationMapData> debugClearVisualizeAction, Action GUIAction, Action<Generator> manualStepGUIAction, string name, bool allowRegeneration = true)
				{
				}

				public void Execute()
				{
				}

				public void ExecuteVisualize()
				{
				}

				public void ExecuteClearVisualize()
				{
				}
			}

			public GenerationSettings settings;

			[NonSerialized]
			public GenStep[] steps;

			[NonSerialized]
			public int currentStep;

			public bool initialized;

			public bool finished;

			public bool revertStepEnabled;

			public GenerationMapData mapData;

			public GenerationMapData[] stepMapDataSnapshots;

			public Generator(GenerationSettings settings, bool revertStepEnabled = true)
			{
			}

			public void Initialize()
			{
			}

			public void RevertStep()
			{
			}

			public void AdvanceNextStep()
			{
			}

			public void ExecuteCurrentStep(bool visualize = false)
			{
			}

			public void RegenerateCurrentStep(bool visualize = false)
			{
			}

			public string GetNextStepName()
			{
				return null;
			}

			public string GetCurrentStepName()
			{
				return null;
			}

			public string GetPreviousStepName()
			{
				return null;
			}

			public Action<Generator> GetCurrentStepManualGUI()
			{
				return null;
			}

			public Action GetCurrentStepGUI()
			{
				return null;
			}

			public bool IsCurrentStepAbleToRegen()
			{
				return false;
			}

			public bool IsCurrentStepAbleToRevert()
			{
				return false;
			}
		}

		public static Generator generator;

		public static LevelData generatedLevel;

		public static ModuleTypeList[] moduleListBySelectedBiome;

		public static BiomeData.BiomeConfig[] biomeConfigsBySelectedBiome;

		public static int[] biomeIdToSelectedBiomeId;

		public static ModuleTypeList[] moduleListByBiome;

		public static Dictionary<string, LevelData> loadedModulesByFilename;

		public static int[] colorHuesByBiome;

		public static GameObject currentTestObj;

		public static List<Mesh> debugSpawnedMeshes;

		public static GameObject[,] obstacleDebugGrid;

		public static bool pathLinesDebugVisible;

		public static string debugStr;

		public static Configuration Config => null;

		public static Generator CurrentGenerator => null;

		public static LevelData GenerateLevelAll(GenerationSettings settings)
		{
			return null;
		}

		public static void StartNewLevelGenerator(GenerationSettings settings)
		{
		}

		public static void InitializeGeneration(Generator generator)
		{
		}

		public static void GetBiomeHuesByBiomeColors(BiomeData biomeData)
		{
		}

		public static void LoadAllModuleLists(GenerationSettings settings)
		{
		}

		public static void FinalizeMapGeneration(Generator generator)
		{
		}

		public static void ExectuteIslandGen(GenerationMapData data)
		{
		}

		public static void VisIslandGen(GenerationMapData data)
		{
		}

		public static void VisClearIslandGen(GenerationMapData data)
		{
		}

		public static void ManualIslandGenExecuteCellularAutomata(GenerationMapData data)
		{
		}

		public static void ManualIslandGenAddTile(GenerationMapData data, Vector2Int tilePos, int newTileId)
		{
		}

		public static void ExectuteBiomeGen(GenerationMapData data)
		{
		}

		public static void VisBiomeGen(GenerationMapData data)
		{
		}

		public static void VisClearBiomeGen(GenerationMapData data)
		{
		}

		public static void ManualBiomeGenAddTile(GenerationMapData data, Vector2Int tilePos, int newTileId)
		{
		}

		public static void ExectutePOIModuleGen(GenerationMapData data)
		{
		}

		public static void ExectuteModuleGen(GenerationMapData data)
		{
		}

		public static void VisModulePoints(GenerationMapData data)
		{
		}

		public static void VisClearModulePoints(GenerationMapData data)
		{
		}

		public static void ManualModuleGenAddModule(GenerationMapData data, List<ModulePoint> modulePointsList, ModulePoint newModule)
		{
		}

		public static void ManualModuleGenRemoveModule(GenerationMapData data, List<ModulePoint> modulePointsList, ModulePoint moduleToRemove)
		{
		}

		public static void ManualModuleGenClearModules(GenerationMapData data, List<ModulePoint> modulePointsList)
		{
		}

		public static void ExectutePathGen(GenerationMapData data)
		{
		}

		public static void CreatePathHashMap(List<LineSegment> pathSegments, bool[,] hashMap, float minDist = 2f, int shapeSize = 4)
		{
		}

		public static void VisPathGen(GenerationMapData data)
		{
		}

		public static void VisClearPathGen(GenerationMapData data)
		{
		}

		public static void ManualPathGenExecuteCleanup(GenerationMapData data)
		{
		}

		public static void ManualPathGenVisualizePathLines(bool isVisible)
		{
		}

		public static void ManualPathGenAddTile(GenerationMapData data, Vector2Int tilePos, int newTileId)
		{
		}

		public static void ManualPathGenVisRefresh(GenerationMapData data)
		{
		}

		public static void ExectuteObstacleGen(GenerationMapData data)
		{
		}

		public static void VisObstacleGen(GenerationMapData data)
		{
		}

		public static GameObject VisCreateObstacleTile(int x, int y, int mapUnitSize, Transform parent)
		{
			return null;
		}

		public static void VisClearObstacleGen(GenerationMapData data)
		{
		}

		public static void ManualObstacleGenExecuteCellularAutomata(GenerationMapData data)
		{
		}

		public static void ManualObstacleGenAddTile(GenerationMapData data, Vector2Int tilePos, int newTileId)
		{
		}

		public static void ExecuteSpawnPointGen(GenerationMapData data)
		{
		}

		public static void VisSpawnPointGen(GenerationMapData data)
		{
		}

		public static void VisClearSpawnPointGen(GenerationMapData data)
		{
		}

		public static void ExecuteGenerateTiles(GenerationMapData data)
		{
		}

		public static List<Vector2> CreateBiomePointsInRadius(int numPoints)
		{
			return null;
		}

		public static List<Vector2> RandomizePointListIndexes(List<Vector2> pointList)
		{
			return null;
		}

		public static Color[] CreateColorsByBiome(BiomeData biomeData, int[] selectedBiomeIds, int biomeNumber)
		{
			return null;
		}

		public static Color[] GetBiomeColorsByProcgenBiomeAsset(BiomeData biomeData, int[] selectedBiomeIds)
		{
			return null;
		}

		public static int[,] CreateBiomeIdGridFromBiomeMapTex(Texture2D biomeColorMap)
		{
			return null;
		}

		public static int GetBiomeIdByBiomeColor(Color biomeColor, int[] colorHuesByBiome)
		{
			return 0;
		}

		public static int SampleBiomeIdMap(int[,] biomeIdGrid, int xTiemapPos, int yTiemapPos)
		{
			return 0;
		}

		public static bool IsAreaCornerFullyInBiome(int[,] biomeIdGrid, Vector2Int position, Vector2Int size)
		{
			return false;
		}

		public static bool IsAreaFullyInBiome(int[,] biomeIdGrid, Vector2Int position, Vector2Int size, int originalBiomeId, Vector2Int tilemapSize)
		{
			return false;
		}

		public static bool IsPointNextToBiome(int[,] biomeIdGrid, Vector2Int position, int biomeId)
		{
			return false;
		}

		public static int GetNextDifferentBiome(int[,] biomeIdGrid, Vector2Int position, int originalBiomeId)
		{
			return 0;
		}

		public static void GetModuleListInSelectedBiomes(GenerationSettings settings)
		{
		}

		public static void GetModuleListInAllBiomes(GenerationSettings settings)
		{
		}

		public static void RemoveUnselectedModulesInAllModuleTypesAndBiomes(GenerationSettings settings)
		{
		}

		public static void RemoveUnselectedModulesInModuleTypes(bool[] selectedModuleIds, List<string> moduleList)
		{
		}

		public static void RandomizeAllPOIModuleLists()
		{
		}

		public static void RandomizeAllModuleLists()
		{
		}

		public static ModulePoint GetModuleDataFromFilename(string moduleName)
		{
			return default(ModulePoint);
		}

		public static LevelData GetModuleByName(string moduleName)
		{
			return null;
		}

		public static void LoadAllSerializedModulesInList(GenerationSettings settings)
		{
		}

		public static void LoadSerializedModulesByNameAndPath(List<string> moduleNames, string path)
		{
		}

		public static string GetNextModuleFromList(List<string> moduleList)
		{
			return null;
		}

		public static void SetModuleChoosenOnList(List<string> moduleList, string choosenModule)
		{
		}

		public static string GetPOIThemedModuleNameByPOIName(int biomeId, string poiModuleName)
		{
			return null;
		}

		public static void SetPOIThemedModuleChoosenByPOIName(int biomeId, string poiModuleName, string choosenModule)
		{
		}

		public static void InitializeSamplingPoints(GenerationMapData data, List<ModulePoint> moduleList, int biomeId, int pointUnitDensity = 20)
		{
		}

		public static void SampleAllPOIModuleDataInBiome(GenerationMapData data, int biomeId, bool[,] spatialHash)
		{
		}

		public static void SampleAllNormalModuleDataInBiome(GenerationMapData data, int biomeId, bool[,] spatialHash)
		{
		}

		public static void SamplePOIModules(GenerationMapData data, int biomeId, bool[,] spatialHash)
		{
		}

		public static void SamplePOIThemedModules(GenerationMapData data, int biomeId, bool[,] spatialHash)
		{
		}

		public static void SampleLandmarkModules(GenerationMapData data, int biomeId, bool[,] spatialHash)
		{
		}

		public static void SampleReviveModules(GenerationMapData data, int biomeId, bool[,] spatialHash)
		{
		}

		public static void SampleGenericModules(GenerationMapData data, int biomeId, bool[,] spatialHash)
		{
		}

		public static void SampleAllModuleDataInType(GenerationMapData data, List<string> moduleTypeList, List<ModulePoint> spawnPointSource, List<ModulePoint> newAddedModules, bool[,] spatialHash, int biomeId, int minDistanceToOthers, int maxDistanceToOthers, int minTypeDistance, int maxTypeDistance, bool sampleInfinetily = true, int sampleIterations = 10)
		{
		}

		public static void SampleAllModuleDataInTypeNumber(GenerationMapData data, List<string> moduleTypeList, List<ModulePoint> spawnPointsSource, List<ModulePoint> newPoints, bool[,] spatialHash, int biomeId, int minDistance, int desiredNumberToSpawn, int sampleIterations = 10)
		{
		}

		public static void SampleModulePointsDensity(GenerationMapData data, List<string> moduleTypeList, List<ModulePoint> spawnPointsSource, List<ModulePoint> newSampledModules, bool[,] spatialHash, int biomeId, int distance, int generalPadding, int desiredNumberToSpawn, int sampleIterations = 10)
		{
		}

		public static List<AreaPoint> GetAreaPointsCopyFromModulePoints(List<ModulePoint> modulePoints)
		{
			return null;
		}

		public static MapSettings.MapNamedModule[] GetAllMapNamedModules(GenerationMapData data)
		{
			return null;
		}

		public static void SpawnModuleOnPosition(GenerationMapData data, LevelData moduleLevelData, Vector2Int position, int modRotId)
		{
		}

		public static List<Vector2Int> ProcessSpawnPoints(GenerationMapData data, bool[,] spatialHash, int desiredPlayerSpawnNumber)
		{
			return null;
		}

		public static void SamplePointsNumber(GenerationMapData data, bool[,] spatialHash, List<AreaPoint> newAddedPoints, int desiredNumberToSpawn)
		{
		}

		public static void SamplePointsNumberDistance(GenerationMapData data, bool[,] spatialHash, List<AreaPoint> newAddedPoints, int distance, int areaPadding, int desiredPoints, int sampleIterations = 10)
		{
		}

		public static void SpawnAllPlayerSpawnPoints(GenerationMapData data)
		{
		}

		public static void RemoveAllSpawnPointsInMap(GenerationMapData data)
		{
		}

		public static void RemoveCloserSpawnPoints(GenerationMapData data, int minSpawnsRequiered = 8, int minDistancePerSpawn = 20)
		{
		}

		public static BiomeData.BiomeConfig[] GetBiomeConfigsByBiomeId(GenerationSettings settings)
		{
			return null;
		}

		public static Dictionary<GameObject, int> GetAllPrefabIdsByPrefab(List<GameObject> assets, GenerationSettings settings)
		{
			return null;
		}

		public static void CreateFloorBiomeTiles(GenerationMapData data)
		{
		}

		public static void CreateFloorPathBiomeTiles(GenerationMapData data)
		{
		}

		public static void CreateObstacleBiomeTiles(GenerationMapData data)
		{
		}

		public static AssetPalette.VariationAsset GetVariationAssetAutotileBiome(int[,] biomeIdGrid, int x, int y, int sampledBiomeId, AssetPalette.AutotileAsset autotileAsset, out int rotationId)
		{
			rotationId = default(int);
			return null;
		}

		public static AssetPalette.VariationAsset GetVariationAssetAutotileHash(int x, int y, bool[,] hash, AssetPalette.AutotileAsset autotileAsset, out int rotationId)
		{
			rotationId = default(int);
			return null;
		}

		public static MapSettings BuildSerializedMapSettings(GenerationMapData data, Vector2[] biomePointsNormalized, MapSettings.MapNamedModule[] namedModules)
		{
			return null;
		}

		public static void CleanUp()
		{
		}

		public static void CleanUpGenerationData()
		{
		}

		public static void ClearCurrentMap()
		{
		}

		public static void VisualizeBiomeCentroidsOnScene(GenerationMapData data, Vector2[] biomeCentroidsNormalized)
		{
		}

		public static void VisualizePointsOnScene(Vector2[] pointsWp, string name = "debugPointsWp")
		{
		}
	}
}
