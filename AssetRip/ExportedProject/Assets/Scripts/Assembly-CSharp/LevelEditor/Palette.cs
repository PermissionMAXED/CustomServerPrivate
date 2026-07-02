using System;
using System.Collections.Generic;
using BAPBAP.Maps;
using UnityEngine;

namespace LevelEditor
{
	public static class Palette
	{
		public class AssetContent
		{
			public bool display;

			public AssetGroupContent[] groups;
		}

		public class AssetGroupContent
		{
			public bool display;

			public AssetLayerContent[] layers;

			public AssetGroupContent(int layerLength)
			{
			}
		}

		public class AssetLayerContent
		{
			public bool display;

			public GUIContent[] assetsContent;

			public GUIContent[] variationAssetsContent;

			public GUIContent[] tilesetAssetsContent;
		}

		public class ModuleContent
		{
			public GUIContent[] poiModules;

			public GUIContent[][] poiThemedModules;

			public GUIContent[] landmarkModules;

			public GUIContent[] reviveModules;

			public GUIContent[][] genericModules;
		}

		public class ElementContent
		{
			public bool display;

			public GUIContent[] assetsContent;

			public GUIContent[] variationAssetsContent;
		}

		public static Vector2 paletteScrollPos;

		public static GUIContent selectedAssetGUIContent;

		public static int selectedAssetId;

		public static int selectedAssetLayerId;

		public static AssetPalette.AssetType selectedAssetType;

		public static int selectedGroupId;

		public static int selectedAssetGroupId;

		public static int selectedModType;

		public static int selectedModSub;

		public static ModuleContent[] modContentList;

		public static ElementContent[] guiContentElements;

		public static AssetContent[] paletteContent;

		public static bool showElements;

		public static bool showAllModules;

		public static bool[] showModules;

		public static bool drawAssetNames;

		public static bool drawVariationAssetSubPalette;

		public static bool showToggles;

		public static bool doContentSnap;

		public static bool paletteIsEnabled;

		public static Material overrideMaterial;

		public static bool useOverrideMaterial;

		public static int overrideMaterialEnumIndex;

		public static bool overrideMaterialAlphaOccluded;

		public static Configuration Config => null;

		public static void GetSelectedModuleAsset()
		{
		}

		public static void GetSelectedLayerAsset()
		{
		}

		public static void SetSelectedObjectAsset(GameObject obj)
		{
		}

		public static void SetSelectedVariationAsset(AssetPalette.VariationAsset variationAsset)
		{
		}

		public static void SetSelectedModule(string moduleName, string path)
		{
		}

		public static void SetSelectedTilesetAsset(AssetPalette.AutotileAsset autotileAsset)
		{
		}

		public static void SetPrefabPaletteSelection(GameObject prefab)
		{
		}

		public static GUIContent GetPrefabPaletteGUIContent(GameObject prefab)
		{
			return null;
		}

		public static void OnModuleSelected(int assetId, int assetGroupId, int modType, int modSub)
		{
		}

		public static void OnAssetSelected(int assetId, int assetLayerId, AssetPalette.AssetType assetType, int groupId, int assetGroupId, GUIContent guiContent = null)
		{
		}

		public static void SetPaletteEnabled(bool isEnabled)
		{
		}

		public static void PaletteGUI()
		{
		}

		public static void DrawTilesetAssetPalette(GUIContent[] content, int assetLayerId, AssetPalette.AssetType assetType, int groupId, int assetGroupId)
		{
		}

		public static void DrawVariationAssetPalette(GUIContent[] content, int assetLayerId, AssetPalette.AssetType assetType, int groupId, int assetGroupId)
		{
		}

		public static void DrawObjectAssetPalette(GUIContent[] content, int assetLayerId, AssetPalette.AssetType assetType, int groupId, int assetGroupId)
		{
		}

		public static void DrawModulePalette(GUIContent[] content, int assetGroupId, int modType, int modSubSelected = -1)
		{
		}

		public static void DrawAllBiomesModulePalette(ModuleContent[] modContentList, bool drawPOIs = true, bool drawNormalMods = true)
		{
		}

		public static void DrawAllBiomesModulePalette(ModuleContent[] modContentList, Action<GUIContent[], int, int, int> onDrawAction, bool drawPOIs = true, bool drawNormalMods = true)
		{
		}

		public static void DrawAllCurrentVariationAssets()
		{
		}

		public static void LoadPalette()
		{
		}

		public static void LoadMaps(AssetPalette assetPalette)
		{
		}

		public static GUIContent[] CreateAssetPaletteContent(GameObject[] objAssetsArray = null, AssetPalette.AutotileAsset[] tilesetAsset = null, AssetPalette.VariationAsset[] variationAsset = null, string groupName = "")
		{
			return null;
		}

		public static GUIContent[] GetGUIContentFromMapFilenames(List<string> mapFiles)
		{
			return null;
		}

		public static int DrawSelectionGrid(int selected, GUIContent[] content, int? columns = null, GUILayoutOption[] layoutOptions = null)
		{
			return 0;
		}
	}
}
