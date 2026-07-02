using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace LevelEditor
{
	public static class Keybinds
	{
		[Serializable]
		public class MappedBinding
		{
			public KeyCode key;

			public string inputName;

			public bool inputIsAxis;

			public bool axisIsPositive;

			[NonSerialized]
			public bool axisInUse;

			[NonSerialized]
			public bool editorHeld;

			public MappedBinding(KeyCode key, string inputName = "", bool inputIsAxis = false, bool axisIsPositive = false)
			{
			}
		}

		[Header("Mouse Functions")]
		public static MappedBinding LeftMouseClick;

		public static MappedBinding RightMouseClick;

		public static MappedBinding MiddleMouseClick;

		[Header("Modifier Keys")]
		public static MappedBinding RightMouseHold;

		public static MappedBinding CamLookHold;

		public static MappedBinding CtrlKeyHold;

		public static MappedBinding ShiftKeyHold;

		[Header("Mode")]
		public static MappedBinding ToggleMode;

		[Header("Tools")]
		public static MappedBinding PaintBrush;

		public static MappedBinding Selection;

		public static MappedBinding Fill;

		public static MappedBinding Eraser;

		public static MappedBinding GrabAsset;

		public static MappedBinding EntityData;

		[Header("History")]
		public static MappedBinding Undo;

		public static MappedBinding Redo;

		[Header("Brush Size")]
		public static MappedBinding BrushSizeUp;

		public static MappedBinding BrushSizeDown;

		[Header("Asset To Place")]
		public static MappedBinding CycleVariationAsset;

		public static MappedBinding ToggleVariationSubPalette;

		[Header("Rotation")]
		public static MappedBinding Rotate;

		public static MappedBinding RotateYLeft;

		public static MappedBinding RotateYRight;

		public static MappedBinding RotateXAdd;

		public static MappedBinding RotateXSub;

		public static MappedBinding RotateZAdd;

		public static MappedBinding RotateZSub;

		public static MappedBinding ResetVisualizerAngle;

		[Header("Off Grid")]
		public static MappedBinding ToggleOffGrid;

		public static MappedBinding OffGridSnapDown;

		public static MappedBinding OffGridSnapUp;

		public static MappedBinding yPosReset;

		public static MappedBinding allowOverlappingMapObject;

		[Header("Visualizations")]
		public static MappedBinding ToggleDetailedView;

		public static MappedBinding VisualizePivots;

		public static MappedBinding ToggleInterfaceGui;

		public static MappedBinding ToggleUseVisualizerMaterial;

		public static MappedBinding ToggleDrawAssetNames;

		[Header("Load/Save")]
		public static MappedBinding SaveWindow;

		[Header("Playmode")]
		public static MappedBinding ZoomOut;

		public static MappedBinding ZoomIn;

		public static MappedBinding ToggleCharCollisions;

		public static MappedBinding NextPlaymodeChar;

		public static MappedBinding RotateCameraFollowLeft;

		public static MappedBinding RotateCameraFollowRight;

		[Header("Custom Group")]
		public static MappedBinding AddSelected;

		public static MappedBinding RemoveSelected;

		public static MappedBinding NextCustomGroupAsset;

		public static MappedBinding PreviousCustomGroupAsset;

		public static MappedBinding CustomGroupRadialMenu;

		[Header("Selection Tool")]
		public static MappedBinding CopySelection;

		public static MappedBinding ApplySelection;

		public static MappedBinding ClearSelection;

		public static MappedBinding SelectionDataRadialMenu;

		[Header("Transform Gizmo")]
		public static MappedBinding EnableGizmo;

		public static MappedBinding SetMoveType;

		public static MappedBinding SetRotateType;

		public static MappedBinding SetScaleType;

		public static MappedBinding SetAllTransformType;

		public static MappedBinding SetSpaceToggle;

		public static MappedBinding SetPivotModeToggle;

		public static MappedBinding SetCenterTypeToggle;

		public static MappedBinding SetScaleTypeToggle;

		public static MappedBinding translationSnapping;

		public static MappedBinding PlaceGizmoObject;

		public static readonly Dictionary<string, MappedBinding> DefaultBindings;

		public static FieldInfo[] bindingFields;

		public static FieldInfo[] BindingFields => null;

		public static void LoadSavedKeybinds()
		{
		}

		public static void SaveKeyCode(string key, KeyCode keycode)
		{
		}

		public static void SaveInputName(string key, string inputName, bool isAxis, bool axisIsPositive)
		{
		}

		public static bool Held(this MappedBinding binding)
		{
			return false;
		}

		public static bool Down(this MappedBinding binding)
		{
			return false;
		}

		public static bool Up(this MappedBinding binding)
		{
			return false;
		}

		public static bool InputGetKey(KeyCode key)
		{
			return false;
		}

		public static bool InputGetKeyDown(KeyCode key)
		{
			return false;
		}

		public static bool InputGetKeyUp(KeyCode key)
		{
			return false;
		}

		public static bool EditorHeld(this MappedBinding bind)
		{
			return false;
		}

		public static int MouseButtonIdByKeyCode(KeyCode key)
		{
			return 0;
		}

		public static bool ControllerInputAllowed()
		{
			return false;
		}
	}
}
