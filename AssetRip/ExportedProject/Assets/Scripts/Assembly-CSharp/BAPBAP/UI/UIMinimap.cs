using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Maps;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIMinimap : MonoBehaviour
	{
		[Serializable]
		public class LeyendElement
		{
			public TMP_Text titleText;

			public string translationKey;
		}

		[NonSerialized]
		public UIManager uiManager;

		[NonSerialized]
		public UIGameMode uiGameMode;

		[NonSerialized]
		public UIChat uiChat;

		[NonSerialized]
		public PingManager pingManager;

		[NonSerialized]
		public EntityAssetsManager entityAssetsManager;

		[NonSerialized]
		public InputSystem inputSystem;

		[NonSerialized]
		public InputBinding minimapDisplayHold;

		[NonSerialized]
		public InputBinding minimapDisplayToggle;

		[Header("UI References")]
		[SerializeField]
		public GameObject minimapBg;

		[SerializeField]
		public GameObject minimapOutline;

		[SerializeField]
		public Image minimapMaskImage;

		[SerializeField]
		public Mask minimapMask;

		[SerializeField]
		public RawImage minimapDisplayImage;

		[SerializeField]
		public RawImage minimapDisplayDimensionMaskImage;

		[SerializeField]
		public RawImage minimapDisplayZoneImage;

		[SerializeField]
		public RectTransform minimapDisplayRect;

		[SerializeField]
		public Image previewRingLineImage;

		[SerializeField]
		public GameObject fullMapDisplayObj;

		[SerializeField]
		public RectTransform mapFullDisplayRect;

		[SerializeField]
		public LeyendElement[] leyendElements;

		[SerializeField]
		public RectTransform worldElementsHolder;

		[SerializeField]
		public Transform iconsParent;

		[SerializeField]
		public GraphicRaycaster iconsGraphicRaycaster;

		[SerializeField]
		public Transform dimensionParent;

		[Header("General Settings")]
		[Tooltip("When updating closest revives, it will perform it every X frames")]
		[SerializeField]
		[Min(1f)]
		public int updateClosestReviveAltarFrameRate;

		[SerializeField]
		[Min(0f)]
		[Tooltip("Small world unit radius margin for allowing selecting revives that are a bit inside the zone")]
		public float reviveInsideZoneMaxDistAllowed;

		[Header("Minimap Units/Scale")]
		[Tooltip("The scale of the map within the minimap circle, in world units")]
		[SerializeField]
		public float minimapUnitRadius;

		[Tooltip("The pixel size of the fully opened map")]
		[SerializeField]
		public float fullMapScale;

		[SerializeField]
		[Header("Settings")]
		public Color charIconAllyColor;

		[SerializeField]
		public Color charIconEnemyColor;

		[Header("Prefabs")]
		[SerializeField]
		public GameObject defaultMinimapPrefab;

		[SerializeField]
		public GameObject charIconPrefab;

		[SerializeField]
		public GameObject charNpcIconPrefab;

		[SerializeField]
		public GameObject charKilledIconPrefab;

		[SerializeField]
		public GameObject mapNameTextPrefab;

		[NonSerialized]
		public Transform target;

		[NonSerialized]
		public bool doFollowTarget;

		[NonSerialized]
		public float minimapMaskSize;

		[NonSerialized]
		public float minimapRadius;

		[NonSerialized]
		public float minimapRadiusSqr;

		[NonSerialized]
		public float originalMinimapDisplaySize;

		[NonSerialized]
		public bool togglePressed;

		[NonSerialized]
		public bool minimapIsFullDisplay;

		[NonSerialized]
		public int mapUnitSize;

		[NonSerialized]
		public Texture2D generatedMinimapTex;

		[NonSerialized]
		public float minimapSizeToTextureFactor;

		[NonSerialized]
		public float fullMapScaleFactor;

		[NonSerialized]
		public float ringPreviewLineOriginalWidth;

		[NonSerialized]
		public Vector2 ringEndPointWorld;

		[NonSerialized]
		public float previewRingRadius;

		[NonSerialized]
		public bool updateForClosestRespawnAltar;

		[NonSerialized]
		public UIMinimapReviveIcon closestReviveIcon;

		[NonSerialized]
		public UIMinimapIcon currentSelectedMinimapIcon;

		[NonSerialized]
		public Dictionary<int, UIMinimapCharacterIcon> characterIconsByInstId;

		[NonSerialized]
		public List<UIMinimapDirIcon> teammateIcons;

		[NonSerialized]
		public Dictionary<uint, UIMinimapReviveIcon> reviveIconsByNetId;

		[NonSerialized]
		public Dictionary<uint, UIMinimapIcon> iconsByNetId;

		[NonSerialized]
		public Dictionary<uint, UIMinimapDimension> dimensionsByNetId;

		public RawImage MinimapDisplayImage => null;

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void EnableMinimap(LevelRuntimeManager levelRuntimeManager, string levelName)
		{
		}

		public void DisableMinimap()
		{
		}

		public void SetTarget(Transform followTarget)
		{
		}

		public void FixedUpdate()
		{
		}

		public void Update()
		{
		}

		public void LateUpdate()
		{
		}

		public void UpdateMinimapPosition()
		{
		}

		public void EnableUpdateForClosestReviveAltar()
		{
		}

		public void DisableUpdateForClosestReviveAltar()
		{
		}

		public void GetClosestReviveAltar()
		{
		}

		public void UpdateClosestReviveAltar()
		{
		}

		public void UpdateCurrentBiomeTitle(string currentBiomeName)
		{
		}

		public void ToggleFullMapDisplay()
		{
		}

		public void ToggleMinimapDisplay()
		{
		}

		public void SetMinimapDisplay(bool isEnabled)
		{
		}

		public void SetMinimapVisibilityEnabled(bool isEnabled)
		{
		}

		public void SetMinimapSize(float size)
		{
		}

		public void DestroyAllIcons()
		{
		}

		public UIMinimapIcon CreateIconOnWorldPos(GameObject iconPrefab, Vector2 worldPos, float ttl = 0f)
		{
			return null;
		}

		public UIMinimapIcon CreateTeammateKilledIconOnWorldPos(Vector2 worldPos, Color teammateColor)
		{
			return null;
		}

		public void UpdateAllIconsSize()
		{
		}

		public void SetElementSize(Transform icon, float scale)
		{
		}

		public Vector2 GetWorldPositionFromMinimapIcon(UIMinimapIcon icon)
		{
			return default(Vector2);
		}

		public UIMinimapIcon AddIconOnPosByNetId(uint netId, int prefabId, Vector2 worldPos, int teamId = -1)
		{
			return null;
		}

		public void RemoveIconByNetId(uint netId)
		{
		}

		public UIMinimapIcon GetIconByNetId(uint id)
		{
			return null;
		}

		public UIMinimapReviveIcon GetReviveIconById(uint netId)
		{
			return null;
		}

		public bool InstanceIdHasCharIcon(int instanceId)
		{
			return false;
		}

		public UIMinimapCharacterIcon AddCharacterIcon(int instanceId, int charId)
		{
			return null;
		}

		public UIMinimapCharacterIcon AddNpcIcon(int instanceId)
		{
			return null;
		}

		public void RemoveCharacterIcon(int instanceId)
		{
		}

		public void UpdateCharacterIconPos(int instanceId, Vector2 worldPos)
		{
		}

		public void SetCharacterIconVisible(int instanceId, bool isVisible)
		{
		}

		public void SetCharacterDowned(int instanceId, bool isDowned)
		{
		}

		public void SetCharacterIconHidden(int instanceId, bool isHidden)
		{
		}

		public void SetCharacterIconTeamBasedColor(int instanceId, bool isAlly)
		{
		}

		public void SetCharacterIconSprite(int instanceId, Sprite sprite)
		{
		}

		public Vector2 GetCharIconWorldPos(int instanceId)
		{
			return default(Vector2);
		}

		public void AddPrimaryTeammateCharacterIcon(int instanceId, int teammateId, int teammateCharId)
		{
		}

		public void AddSecondaryTeammateCharacterIcon(int instanceId, int teammateId)
		{
		}

		public void RemoveTeammateIcon(int instanceId)
		{
		}

		public void RemoveAllTeammateIcon()
		{
		}

		public void UpdateTeammateCharIconPos(int instanceId, Vector2 worldPos)
		{
		}

		public void UpdateIconDirection(UIMinimapDirIcon icon)
		{
		}

		public void UpdateAllTeammateDirectionIcons()
		{
		}

		public void SetCurrentSelectedMinimapIcon(UIMinimapIcon icon)
		{
		}

		public void OnIconPinged(UIMinimapIcon icon)
		{
		}

		public UIMinimapIcon AddPingIconOnPos(int pingPosType, Vector2 worldPos, int teammateId = -1)
		{
			return null;
		}

		public UIMinimapIcon AddPingIconOnChar(int instanceId, bool isEnemy)
		{
			return null;
		}

		public GameObject AddPingItemIcon(GameObject prefab, Vector2 worldPos, Sprite itemIcon, Color itemTierColor, int teammateId)
		{
			return null;
		}

		public UIMinimapIcon AddPingEntityIcon(Vector2 worldPos, int entityPrefabId)
		{
			return null;
		}

		public void SetRespawnAltarIconActive(uint netId, bool isActive)
		{
		}

		public uint GetReviveAltarNetIdInRadius(Vector2 worldPos, float maxScreenRadius, bool requireActive)
		{
			return 0u;
		}

		public void SetSupplyDropIconLanded(uint netId, bool isLanded)
		{
		}

		public void CreateAllModuleNameText(MapSettings.MapNamedModule[] mapNamedModules, Vector2Int mapSize)
		{
		}

		public void CreateModuleNameText(MapSettings.MapNamedModule mapNamedModule, Vector2Int mapSize)
		{
		}

		public void SetPreviewRingClosing(bool isClosing)
		{
		}

		public void OnPreviewRingUpdate()
		{
		}

		public void UpdatePreviewRingLine()
		{
		}

		public void AddDimension(uint dimensionNetId, int dimensionId)
		{
		}

		public void RemoveDimension(uint dimensionNetId)
		{
		}

		public UIMinimapDimension CreateUIDimension(int dimensionId)
		{
			return null;
		}

		public void UpdateDimension(uint dimensionNetId, Vector2 worldPos, float size)
		{
		}
	}
}
