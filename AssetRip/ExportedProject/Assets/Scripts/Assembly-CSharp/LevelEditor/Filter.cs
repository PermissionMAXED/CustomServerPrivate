using System.Collections.Generic;
using UnityEngine;

namespace LevelEditor
{
	public static class Filter
	{
		public static bool showFilterField;

		public static string filterTerm;

		public static string[] splitFilterTerm;

		public static string[] separatingStrings;

		public static bool filtering;

		public static bool filterFocused;

		public static bool filterAssetLayer;

		public static string[] assetLayerOptions;

		public static int selectedAssetLayer;

		public static Dictionary<GUIContent[], GUIContent[]> checkedGUIContents;

		public static bool MatchesFilter(string query)
		{
			return false;
		}

		public static GUIContent[] FilterGUIContents(GUIContent[] content, int assetLayer)
		{
			return null;
		}

		public static GUIContent[] FilterGUIContents(GUIContent[] content)
		{
			return null;
		}

		public static void DrawAssetFilterGUI(bool showToggleToggle = true, bool isGUIEnabled = true)
		{
		}

		public static void ClearCheckedContents()
		{
		}

		public static int GetOriginalIndex(string tooltipString)
		{
			return 0;
		}

		public static int GetFilterIndexFromOriginal(GUIContent[] content, int originalIndex)
		{
			return 0;
		}
	}
}
