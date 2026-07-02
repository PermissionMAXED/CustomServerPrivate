using System;
using System.Collections.Generic;
using BAPBAP.Maps;
using UnityEngine;

namespace LevelEditor
{
	public static class CustomGroup
	{
		public class CustomGroupAssetWrapper
		{
			public List<CustomGroupAsset> customGroups;

			public CustomGroupAssetWrapper(List<CustomGroupAsset> customGroups)
			{
			}
		}

		[Serializable]
		public class CustomGroupAsset
		{
			public GUIContent guiContent;

			public int assetId;

			public int assetLayerId;

			public AssetPalette.AssetType assetType;

			public int groupId;

			public int assetGroupId;

			public int modType;

			public int modSub;

			public bool isModule;

			public CustomGroupAsset(GUIContent guiContent, int assetId, int assetLayerId, AssetPalette.AssetType assetType, int groupId, int assetGroupId)
			{
			}

			public CustomGroupAsset(GUIContent guiContent, int assetId, int groupId, int modType, int modSub)
			{
			}

			public bool IsSelected()
			{
				return false;
			}
		}

		public static bool showCustomGroup;

		public static bool showUtilities;

		public static int saveSlots;

		public static List<CustomGroupAsset> customGroupAssets;

		public static GUIContent[] customGroupContent;

		public static bool showGroupRadialMenu;

		public static Vector2 groupMenuScreenPos;

		public static int hoveredGroupAsset;

		public static bool groupMenuPopulated;

		public static bool groupMenuPosSet;

		public static Vector2 groupMenuOffset;

		public static Dictionary<GUIContent, int> groupObjects;

		public static void AddCurrentSelectedToCustomGroup()
		{
		}

		public static void AddAssetToCustomGroup(GUIContent asset, int assetId, int assetLayerId, AssetPalette.AssetType assetType, int groupId, int assetGroupId)
		{
		}

		public static void AddAssetToCustomGroup(GUIContent asset, int assetId, int groupId, int modType, int modSub)
		{
		}

		public static void AddAssetToCustomGroup(CustomGroupAsset customGroupAsset)
		{
		}

		public static void RemoveAssetFromCustomGroup(CustomGroupAsset asset)
		{
		}

		public static void ClearCustomGroup()
		{
		}

		public static void SetGroupGUIContent()
		{
		}

		public static void DrawCustomGroupGUI()
		{
		}

		public static void DrawCustomGroupRadialMenu()
		{
		}

		public static void ShowGroupRadialMenu()
		{
		}

		public static void PopulateGroupRadialMenu()
		{
		}

		public static void OnHideGroupWheel()
		{
		}

		public static void SetSelectedGroupAsset(int newSelectedAssetId)
		{
		}

		public static void SaveCustomGroup(int saveSlot)
		{
		}

		public static void LoadCustomGroup(int saveSlot)
		{
		}

		public static void DeleteCustomGroup(int saveSlot)
		{
		}
	}
}
