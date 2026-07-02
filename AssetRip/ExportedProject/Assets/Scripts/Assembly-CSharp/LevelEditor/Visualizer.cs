using System.Collections.Generic;
using BAPBAP.Maps;
using RuntimeGizmos;
using UnityEngine;

namespace LevelEditor
{
	public static class Visualizer
	{
		public static TransformGizmo transformGizmo;

		public static bool isUsingGizmo;

		public static bool allowGizmo;

		public static bool autoEraseGrabbedWithGizmo;

		public static Transform visualizerObject;

		public static Transform visualizerObjectHolder;

		public static GameObject visualizerMeshObject;

		public static Transform areaVisualizerObject;

		public static Transform brushSizeVisObject;

		public static Renderer[] visualizerRenderer;

		public static Material[][] visualizerOriginalMaterialArray;

		public static GameObject objToVisualize;

		public static bool swapScenePrefabEnabled;

		public static bool prevSwapScenePrefabEnabled;

		public static float rotationLerpSpeed;

		public static int grabSearchRadius;

		public static bool removeGrabSearchVars;

		public static Vector3 worldPos;

		public static Transform visualizerRotation;

		public static float currentYPos;

		public static Material visualizerMaterial;

		public static Color visualizerNormalColor;

		public static Color visualizerBaseColor;

		public static bool visualizerAxisLockEnabled;

		public static Vector2 visualizerAxisLockStart;

		public static Vector2 visualizerAxisLockValue;

		public static Vector3 prevWorldPos;

		public static bool visualizerPosChanged;

		public static Vector2 prevMousePos;

		public static Camera cam;

		public static Vector2Int prevGrabPos;

		public static bool useVisualizerMaterial;

		public static bool showGrabWheel;

		public static Vector2 grabMenuScreenPos;

		public static GameObject hoveredGrabPrefab;

		public static bool grabMenuPopulated;

		public static bool grabMenuPosSet;

		public static Vector2 grabMenuOffset;

		public static Dictionary<GUIContent, GameObject> grabbableObjs;

		public static bool showVisualizerSettings;

		public static bool IsUsingGizmo
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public static Configuration Config => null;

		public static LevelEditorMonoController LvlEditorMono => null;

		public static void Initialize()
		{
		}

		public static void CreateEraserVisualizer()
		{
		}

		public static void CreateVisualizer(GameObject visObject)
		{
		}

		public static void AddVisualizerToGizmoTarget()
		{
		}

		public static void SetVisualizerMaterials(bool isEraser)
		{
		}

		public static void DestroyVisualizer()
		{
		}

		public static List<GameObject> VisualizersToDestroy()
		{
			return null;
		}

		public static void SetVisualizerSceneVisibility(bool visible)
		{
		}

		public static void SetVisualizerVisibility(bool visible)
		{
		}

		public static void SetVisualizerColor(Color color)
		{
		}

		public static void UpdateVisualizer()
		{
		}

		public static void UpdateVisualizerPosition()
		{
		}

		public static void SetVisualizerPosition()
		{
		}

		public static void UpdateVisualizerBrushSize()
		{
		}

		public static void SetVisualizerBrushSizeEnabled(bool isEnabled)
		{
		}

		public static Ray GetMouseRay()
		{
			return default(Ray);
		}

		public static Ray GetScreenRay(Vector2 point)
		{
			return default(Ray);
		}

		public static Vector3 GetWorldPosOnGridClosestToMouse()
		{
			return default(Vector3);
		}

		public static float RoundToNearestGridCenter(float positionOnAxis)
		{
			return 0f;
		}

		public static float OffGridStepRound(float positionOnAxis, float step)
		{
			return 0f;
		}

		public static void RotateVisualizer(Vector3 angleAmount, bool doLerp = true)
		{
		}

		public static void SetVisualizerAngle(Vector3 angle, bool doLerp = true)
		{
		}

		public static void EnableAxisLock()
		{
		}

		public static void DisableAxisLock()
		{
		}

		public static void ToggleVisualizerObjFromScene(bool isEnabled)
		{
		}

		public static void SetVisualizerObjFromScene()
		{
		}

		public static void SetVisualizerObjFromScenePos(Vector3 worldPos, MapLayer mapLayer)
		{
		}

		public static void TryGrabSceneAsset()
		{
		}

		public static void ShowGrabRadialMenu()
		{
		}

		public static void PopulateGrabRadialMenu()
		{
		}

		public static void UpdateGrabRadialMenuVisualizer()
		{
		}

		public static bool OnCompleteGrabWheel()
		{
			return false;
		}

		public static string ShowVisualizerHelpGUI()
		{
			return null;
		}

		public static void DrawVisualizerSettingsGUI(bool onDock = false)
		{
		}

		public static void PlayPlaceAnimOnVisualizer()
		{
		}

		public static void PlayPlaceVfxOnVisualizer()
		{
		}
	}
}
