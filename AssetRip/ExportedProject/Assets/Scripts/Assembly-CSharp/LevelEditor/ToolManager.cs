using UnityEngine;

namespace LevelEditor
{
	public static class ToolManager
	{
		public enum ToolEnum
		{
			Single = 0,
			Continuous = 1,
			FillArea = 2,
			Select = 3,
			EntityData = 4,
			SplatPaint = 5
		}

		public static int toolLength;

		public static GUIContent[] guiContentDrawTool;

		public static GUIContent guiContentEraserMod;

		public static GUIContent guiContentReplaceMod;

		public static GUIContent guiContentOffGridMod;

		public static ToolDrawSingle toolDrawSingle;

		public static ToolDrawContinuous toolDrawContinuous;

		public static ToolFillArea toolFillArea;

		public static ToolSelect toolSelect;

		public static ToolEntityData toolEntityData;

		public static ToolSplatPaint toolSplatPaint;

		public static int selectedToolIndex;

		public static Tool currentSelectedTool;

		public static Configuration Config => null;

		public static void Initialize()
		{
		}

		public static void SelectToolAndDisableEraser(ToolEnum tool)
		{
		}

		public static void SelectTool(ToolEnum tool)
		{
		}

		public static void UnselectTool()
		{
		}

		public static Tool GetTool(ToolEnum tool)
		{
			return null;
		}

		public static void SetTool()
		{
		}

		public static void SetEraser(bool isEnabled)
		{
		}

		public static void SetReplaceMod(bool isEnabled)
		{
		}

		public static void SetOffGridMod(bool isEnabled)
		{
		}

		public static void ToolbarGUI()
		{
		}
	}
}
