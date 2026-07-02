using System;
using System.Collections.Generic;
using BAPBAP.Maps;
using UnityEngine;

namespace LevelEditor
{
	public static class SelectionHistory
	{
		[Serializable]
		public class SelectionHistoryAsset
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

			public SelectionHistoryAsset(GUIContent guiContent, int assetId, int assetLayerId, AssetPalette.AssetType assetType, int groupId, int assetGroupId)
			{
			}

			public SelectionHistoryAsset(GUIContent guiContent, int assetId, int groupId, int modType, int modSub)
			{
			}

			public bool IsSelected()
			{
				return false;
			}
		}

		public static bool showSelectionHistory;

		public static List<SelectionHistoryAsset> selectionHistoryAssets;

		public static GUIContent[] selectionHistoryContent;

		public static int maxSelectionHistory;

		public static void AddCurrentSelectedToHistory()
		{
		}

		public static void AddAssetToSelectionHistory(GUIContent asset, int assetId, int assetLayerId, AssetPalette.AssetType assetType, int groupId, int assetGroupId)
		{
		}

		public static void AddAssetToSelectionHistory(GUIContent asset, int assetId, int groupId, int modType, int modSub)
		{
		}

		public static void ClearSelectionHistory()
		{
		}

		public static void SetGroupGUIContent()
		{
		}

		public static void DrawSelectionHistoryGUI()
		{
		}

		public static void SetSelectedGroupAsset(int newSelectedAssetId)
		{
		}
	}
}
