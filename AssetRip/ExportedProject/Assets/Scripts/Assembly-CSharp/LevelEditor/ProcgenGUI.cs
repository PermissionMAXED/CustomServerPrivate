using System.Collections.Generic;
using BAPBAP.Maps;
using UnityEngine;

namespace LevelEditor
{
	public static class ProcgenGUI
	{
		public static bool stepByStepInProgress;

		public static bool showProcGen;

		public static bool showProcGenSettings;

		public static bool showProcGenBiomeSettings;

		public static bool[][] modTypeSettings;

		public static int playerSpawnCount;

		public static bool clearAllModuleSpawnPoints;

		public static bool manualStepEnabled;

		public static GUIContent[] islandGenBrushPalette;

		public static GUIContent[] biomeGenBrushPalette;

		public static bool modulePlacementEnabled;

		public static GUIContent[] pathGenBrushPalette;

		public static GUIContent[] obstacleGenBrushPalette;

		public static LevelData currentModule;

		public static string currentModuleName;

		public static Mesh moduleCombinedMesh;

		public static bool moduleEraserEnabled;

		public static Configuration Config => null;

		public static void Initialize()
		{
		}

		public static void ProcgenMenuGUI()
		{
		}

		public static void DrawAllProcgenSettings()
		{
		}

		public static void DrawProcgenBiomeSettings()
		{
		}

		public static bool ShowModuleTypeSettings(bool modTypeSelected, bool display, ProceduralLevelGeneration.ModuleTypeSettings modSettings, string modTypeName, float maxWidth, GUIContent[] moduleTypeContent)
		{
			return false;
		}

		public static void DrawModuleTypeModuleSelect(GUIContent[] modTypeContent, ProceduralLevelGeneration.ModuleTypeSettings moduleSettings, float width)
		{
		}

		public static void GUIIslandGen()
		{
		}

		public static void IslandGenManualGUI(ProceduralLevelGeneration.Generator generator)
		{
		}

		public static void GUIBiomeGen()
		{
		}

		public static void BiomeGenManualGUI(ProceduralLevelGeneration.Generator generator)
		{
		}

		public static void GUIPOIModuleGen()
		{
		}

		public static void POIModuleGenManual(ProceduralLevelGeneration.Generator generator)
		{
		}

		public static void GUIModuleGen()
		{
		}

		public static void ModuleGenManual(ProceduralLevelGeneration.Generator generator)
		{
		}

		public static void DrawModuleManualGUI(ProceduralLevelGeneration.Generator generator, bool onlyPOIs = false)
		{
		}

		public static void GUIPathGen()
		{
		}

		public static void PathGenManualGUI(ProceduralLevelGeneration.Generator generator)
		{
		}

		public static void GUIObstacleGen()
		{
		}

		public static void ObstacleGenManualGUI(ProceduralLevelGeneration.Generator generator)
		{
		}

		public static void GUISpawnPointGen()
		{
		}

		public static void OnExitManualStep()
		{
		}

		public static void OnSelectModule(string moduleName, string path)
		{
		}

		public static void EnableModulePlacement(string moduleName, string path)
		{
		}

		public static void CreateModuleVisualizer()
		{
		}

		public static void PlaceModuleFromScene(ProceduralLevelGeneration.Generator generator, List<ProceduralLevelGeneration.ModulePoint> modulePointsList)
		{
		}

		public static void RemoveModuleFromScene(ProceduralLevelGeneration.Generator generator, List<ProceduralLevelGeneration.ModulePoint> modulePointsList)
		{
		}
	}
}
