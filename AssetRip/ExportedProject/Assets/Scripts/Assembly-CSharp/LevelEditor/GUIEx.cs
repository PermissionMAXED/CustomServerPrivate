using System;
using System.Collections.Generic;
using UnityEngine;

namespace LevelEditor
{
	public static class GUIEx
	{
		public static int activeFloatField;

		public static float activeFloatFieldLastValue;

		public static string activeFloatFieldString;

		public static Texture2D lineTexture;

		public static Color OriginalCol { get; set; }

		public static Color OriginalBgCol { get; set; }

		public static bool IsInitialized { get; set; }

		public static void Initialize()
		{
		}

		public static void BeginVertical()
		{
		}

		public static void EndVertical()
		{
		}

		public static void SetGUIColor(Color color)
		{
		}

		public static void ResetGUIColor()
		{
		}

		public static void SetGUIBGColor(Color color)
		{
		}

		public static void ResetGUIBGColor()
		{
		}

		public static void GUIIntProperty(ref int property, string propertyName, float labelWidth = 200f, float maxWidth = 400f)
		{
		}

		public static void GUIFloatProperty(ref float property, string propertyName, float labelWidth = 200f, float maxWidth = 400f, float increment = 0f, float min = -1f, float max = -1f)
		{
		}

		public static float FloatField(float value, float maxWidth)
		{
			return 0f;
		}

		public static float ForceParse(this string str)
		{
			return 0f;
		}

		public static void DrawRadialMenu<T>(bool menuPopulated, ref bool initialPosSet, ref Vector2 initialPos, ref Vector2 radialOffset, Dictionary<GUIContent, T> radialContent, Action<T> onHoverAction, float customBoxSize = -1f, float customBaseRadius = -1f)
		{
		}

		public static void DrawLine(Vector2 start, Vector2 end, int width, Texture2D tex)
		{
		}

		public static void DrawHorizontalLine(Color color, string label = null)
		{
		}

		public static bool LayoutSelectableButton(GUIContent content, bool active = true, bool selected = false, bool lightMode = false, params GUILayoutOption[] options)
		{
			return false;
		}

		public static bool LayoutSelectableToggle(GUIContent content, bool boolean, params GUILayoutOption[] options)
		{
			return false;
		}
	}
}
