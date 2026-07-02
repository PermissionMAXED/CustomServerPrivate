using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace LevelEditor
{
	public static class Colors
	{
		public static Color Base;

		public static Color White;

		public static Color TilesetAsset;

		public static Color VariationAsset;

		public static Color Continue;

		public static Color Yield;

		public static Color Critical;

		public static Color Confirm;

		public static Color Button;

		public static readonly Dictionary<string, Color> DefaultColors;

		public static FieldInfo[] colorFields;

		public static float BaseAlpha
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public static FieldInfo[] ColorFields => null;

		public static void LoadSavedColors()
		{
		}

		public static void SaveColor(string key, Color color)
		{
		}
	}
}
