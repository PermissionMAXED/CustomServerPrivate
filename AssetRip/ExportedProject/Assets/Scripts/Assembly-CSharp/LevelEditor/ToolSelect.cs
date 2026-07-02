using System.Collections.Generic;
using BAPBAP.Maps;
using UnityEngine;

namespace LevelEditor
{
	public class ToolSelect : Tool
	{
		public enum SelectState
		{
			None = 0,
			PaintingArea = 1,
			TransformingSelection = 2
		}

		public static SelectState selectState;

		public static Vector3 paintAreaStart;

		public static Vector3 paintAreaEnd;

		public static GameObject areaHolder;

		public static GameObject currentArea;

		public static GameObject gameObjectsHolder;

		public static bool movingSelection;

		public static bool selectionIsCopy;

		public static bool startTransformMove;

		public static Vector2Int selectionCenterPos;

		public static Vector2Int selectionSize;

		public static Vector3 mouseDragOffset;

		public static LevelData activeSelectionData;

		public static bool showSelectionRadialMenu;

		public static Vector2 selectionMenuScreenPos;

		public static LevelData hoveredSelectionData;

		public static bool selectionMenuPopulated;

		public static bool selectionMenuPosSet;

		public static Vector2 selectionMenuOffset;

		public static Dictionary<GUIContent, LevelData> copySelectionDatas;

		public static GameObject selectionVisualizerRoot;

		public static MeshRenderer visualizerMeshRenderer;

		public static Mesh selectionMesh;

		public static bool showSelectToolSettings;

		public static Dictionary<MapLayer, bool> SelectableMapLayers;

		public static bool SplatMapSelectable;

		public static Configuration Config => null;

		public override void OnToolSelected()
		{
		}

		public override void OnToolUnselected()
		{
		}

		public override void OnMousePressed()
		{
		}

		public override void OnMouseHold()
		{
		}

		public override void OnMouseReleased()
		{
		}

		public override void OnInputKeyPressed()
		{
		}

		public override void OnToolInterrupted()
		{
		}

		public override void OnUpdate()
		{
		}

		public override void OnToolGUI()
		{
		}

		public static void StartPaintArea()
		{
		}

		public static void UpdatePaintArea()
		{
		}

		public static void CompletePaintArea()
		{
		}

		public static void GetSelectionArea(int startX, int startY, int endX, int endY)
		{
		}

		public static void CreateSelectionCopy()
		{
		}

		public static void ApplyCurrentSelectionToLevel()
		{
		}

		public static void RemoveLayerArea(Vector2Int tilemapCenterPos, Vector2Int size)
		{
		}

		public static void ClearCurrentSelection()
		{
		}

		public static void StartTransformSelection()
		{
		}

		public static void EndTransformSelection()
		{
		}

		public static void StartTransformMove()
		{
		}

		public static void EndTransformMove()
		{
		}

		public static void UpdateTransformSelectionPosition()
		{
		}

		public static void CreateSelectionVisualizer()
		{
		}

		public static void DestroySelectionVisualizer()
		{
		}

		public static bool MapLayerIsActive(int layerIndex)
		{
			return false;
		}

		public static void DrawSelectSettingsGUI(bool onDock = false)
		{
		}

		public static bool CanCropMapToSelection()
		{
			return false;
		}

		public static bool CanDrawSelectionDataRadialMenu()
		{
			return false;
		}

		public static void DrawSelectionDataRadialMenu()
		{
		}

		public static void ShowSelectionRadialMenu()
		{
		}

		public static void PopulateCopySelectionWheelData(LevelData selectionData)
		{
		}

		public static void OnHideSelectionRadialMenu()
		{
		}
	}
}
