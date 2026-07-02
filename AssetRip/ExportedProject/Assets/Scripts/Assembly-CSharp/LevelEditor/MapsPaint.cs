using System;
using UnityEngine;

namespace LevelEditor
{
	public static class MapsPaint
	{
		public static bool paintEnabled;

		public static bool consumedInputThisFrame;

		public static Vector2Int prevPlacePos;

		public static int currentBrushId;

		public static GUIContent[] brushPalette;

		public static void OnStart(GUIContent[] palette, int brushSizeId = 2)
		{
		}

		public static void MapPaintBrushGUI(Action<Vector2Int, int> paintAction, Action visualizeAction = null)
		{
		}

		public static void OnSelectBrushTool()
		{
		}

		public static void EnableBrushEdit()
		{
		}

		public static void PlaceBrushTileFromScene(Action<Vector2Int, int> paintAction, Action visualizeAction = null)
		{
		}
	}
}
