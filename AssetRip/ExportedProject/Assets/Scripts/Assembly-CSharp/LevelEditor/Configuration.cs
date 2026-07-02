using BAPBAP.Game;
using BAPBAP.Local;
using BAPBAP.Maps;
using BAPBAP.Utilities;
using UnityEngine;

namespace LevelEditor
{
	public class Configuration : ScriptableObject
	{
		public GameObject loaderPrefab;

		public GameObject controllerPrefab;

		public GameObject envBasePrefab;

		[Min(0.2f)]
		public float uiScale;

		[Range(0f, 1f)]
		public float interfaceWidthPercent;

		[Range(0f, 1f)]
		public float dockPercentWidth;

		[Range(0f, 1f)]
		public float dockPercentHeight;

		[Range(1f, 10f)]
		public int paletteColumnCount;

		[Header("Settings")]
		[Min(0f)]
		public Vector2Int targetResolution;

		public int targetFramerate;

		public int vSyncCount;

		[Header("Resources")]
		public AssetPalette assetPalette;

		public GUISkin levelEditorGuiSkin;

		public GUISkin guiContentDisplaySkin;

		public GUISkin colorPickSkin;

		public Texture2D pixel;

		[Header("Prefabs")]
		public GameObject splatBrushObjectPrefab;

		public GameObject visualizerObjectPrefab;

		public GameObject gridPrefab;

		public GameObject eraserVisualizerPrefab;

		public GameObject areaPrefab;

		public GameObject visualizePivotLayerPrefab;

		[NamedArray(typeof(MapLayer), 0)]
		public Material[] visualizePivotLayerMats;

		public GameObject visualizeWalkableLayerPrefab;

		[Header("Renderer Prefabs")]
		public GameObject thumbnailCameraPrefab;

		public GameObject minimapCameraRendererPrefab;

		[Tooltip("How many pixels per map unit. i.e: a 100x100 map with 4 pixels per unit will result in a 400x400 texture size.")]
		[Header("Minimap renderer Settings")]
		public float minimapTexResPerUnit;

		[Tooltip("The min and max texture size allowed for the map.")]
		public IntRange minimapTexResRange;

		[Header("Object Data References")]
		public GameObject entityLinkedIconPrefab;

		public GameObject entityLinkMissingIconPrefab;

		public GameObject entityLinkLinePrefab;

		public GameObject entityWorldPosPrefab;

		public LineRenderer entityWPLineRendererPrefab;

		[Header("Playmode Characters")]
		public GameObject[] playModeChars;

		[Header("Materials")]
		public Material[] detailedViewMaterials;

		public Material[] waterMaterials;

		public Material waterMaskMaterial;

		public Color visualizerColor;

		public Color visualizerRedColor;

		public Material visualizerMaterial;

		public Material visualizerRedMaterial;

		public Material visualizerABMaterial;

		public Material areaWhiteMaterial;

		public Material areaBlueMaterial;

		public Material areaRedMaterial;

		public Material islandDistortMaterial;

		public Material biomeDistortMat;

		public Material bushMaterial;

		public Material textureMapDebugMaterial;

		public Material pathDebugMaterial;

		public Material obstacleDebugMaterial;

		public Material blueDebugMaterial;

		public MapVisualizer.VisConfiguration visConfig;

		[Header("SFX")]
		public AudioClipData[] selectClipData;

		public AudioClipData[] placeClipData;

		public AudioClipData[] eraseClipData;

		[Header("Battle Royale Settings")]
		public GameModeBattleRoyale.SerializedMapZones brZoneRoundDefaultLarge;

		[Header("Debug Settings")]
		public bool autoThumbRebuildEnabled;

		[HideInInspector]
		public Vector3 camPos;
	}
}
