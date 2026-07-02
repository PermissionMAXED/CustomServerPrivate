using System;
using BAPBAP.Entities;
using BAPBAP.Localisation;
using BAPBAP.Pooling;
using BAPBAP.Steam;
using UnityEngine;

namespace BAPBAP.Local
{
	public class LocalManager : MonoBehaviour
	{
		[NonSerialized]
		public LocalSavedData localSavedData;

		[NonSerialized]
		public InputSystem inputSystem;

		[NonSerialized]
		public InputManager inputManager;

		[NonSerialized]
		public AudioManager audioManager;

		[NonSerialized]
		public FMODManager fmodManager;

		[NonSerialized]
		public VoiceManager voiceManager;

		[NonSerialized]
		public ItemManager itemManager;

		[NonSerialized]
		public VfxManager vfxManager;

		[NonSerialized]
		public PostCameraMouse postCamMouse;

		[NonSerialized]
		public NetworkCache networkCache;

		[NonSerialized]
		public BushManager bushManager;

		[NonSerialized]
		public RngManager rngManager;

		[NonSerialized]
		public EmoteManager emoteManager;

		[NonSerialized]
		public TombstoneManager tombstoneManager;

		[NonSerialized]
		public ContentManager contentManager;

		[NonSerialized]
		public PingManager pingManager;

		[NonSerialized]
		public ItemCurrencyManager itemCurrencyManager;

		[NonSerialized]
		public PassiveManager passiveManager;

		[NonSerialized]
		public StatusEffectManager statusEffectManager;

		[NonSerialized]
		public GameModifierManager gameModifierManager;

		[NonSerialized]
		public AnalyticsManager analyticsManager;

		[NonSerialized]
		public SteamManager steamManager;

		[NonSerialized]
		public EntityAssetsManager entityAssetsManager;

		[NonSerialized]
		public AugmentManager augmentManager;

		[NonSerialized]
		public DimensionManager dimensionManager;

		[NonSerialized]
		public ModelSwapManager modelSwapManager;

		[SerializeField]
		public LocalPrefabLibrary prefabLibrary;

		[SerializeField]
		public CharVoicelineGlobalConfig voicelineGlobalConfig;

		public static readonly int LocalCharWorldPos_ShaderProperty;

		public static readonly int LocalCharWorldPos_0_ShaderProperty;

		public static readonly int LocalCharWorldPos_1_ShaderProperty;

		public static readonly int LocalMousePos_ShaderProperty;

		public static readonly int LocalCharRendWorldPos_ShaderProperty;

		public static readonly int LocalCharRendWorldPos_0_ShaderProperty;

		public static readonly int LocalCharRendWorldPos_1_ShaderProperty;

		public static readonly int CharBushMoveDirection_ShaderProperty;

		public static readonly int CharBushMoveDirection_0_ShaderProperty;

		public static readonly int CharBushMoveDirection_1_ShaderProperty;

		public static readonly int MapWorldSize_ShaderProperty;

		public static readonly int MapEdgeWidthMultiplier_ShaderProperty;

		public static readonly int BRZonePosition_ShaderProperty;

		public static readonly int BRZoneRadius_ShaderProperty;

		public static readonly int BRZonePreviewWorldPos_ShaderProperty;

		public static readonly int BRZonePreviewWorldRadius_ShaderProperty;

		public static readonly int BRRingClosing_ShaderProperty;

		public static readonly int BRZoneColor_ShaderProperty;

		public static readonly int BRZoneEdgeColor_ShaderProperty;

		public static readonly int BRZoneGlowColor_ShaderProperty;

		public static readonly int BRZonePreviewRingColor_ShaderProperty;

		public static readonly int BRZonePreviewRingWidth_ShaderProperty;

		public static readonly int BRZoneGlowSize_ShaderProperty;

		public static readonly int BRZoneEdgeWidth_ShaderProperty;

		public static readonly int BRZoneSharpness_ShaderProperty;

		public static readonly int FoWRadiusMin_ShaderProperty;

		public static readonly int FoWRadiusMax_ShaderProperty;

		public static readonly int FoWFadeRadiusMin_ShaderProperty;

		public static readonly int FoWFadeRadiusMax_ShaderProperty;

		public static readonly int FoWScale_ShaderProperty;

		public static readonly int FoWTex_ShaderProperty;

		public static readonly int FowWorldPos_ShaderProperty;

		public static readonly int FowWorldPosRounded_ShaderProperty;

		public static readonly int FoWShadowColor_ShaderProperty;

		public static readonly int FoWAlpha_ShaderProperty;

		public static readonly int WorldLightColor_ShaderProperty;

		public static readonly int WorldLightDir_ShaderProperty;

		public static readonly int UnscaledTime_ShaderProperty;

		public static readonly int EntityHitBlinkAmount_ShaderProperty;

		public static readonly int EntityHitBlinkColor_ShaderProperty;

		public static readonly int Color_ShaderProperty;

		public static readonly int RingFrac_ShaderProperty;

		public static readonly int RingEdgeSize_ShaderProperty;

		public static readonly int RingOffset_ShaderProperty;

		public static readonly int ItemOutlineColor_ShaderProperty;

		public static readonly int ItemOutlineSize_ShaderProperty;

		public static readonly int ItemFresnelColor_ShaderProperty;

		public static readonly int Amount_ShaderProperty;

		public static readonly int ItemTier_ShaderProperty;

		public static readonly int PlaneEffectTex_ShaderProperty;

		public static readonly int PlaneEffectCamSize_ShaderProperty;

		public static readonly int OverlayColorChannel_ShaderProperty;

		public static readonly int PerRendererColor_ShaderProperty;

		public static readonly int OverlayBackAmount_ShaderProperty;

		public static readonly int OverlayFrontAmount_ShaderProperty;

		public static readonly int DimensionEntity_ShaderProperty;

		public static readonly int DimensionCharacter_ShaderProperty;

		public const string OverlayFoWOcclude = "FOW_OCCLUDE_OVERLAY";

		public const string OverlayPass = "DepthMaskOverlay";

		public const string OverlayOverrideChannel = "_DEPTHMASKOVERLAY_OVERRIDECHANNEL";

		public const string ReflectionsQuality = "_REFLECTIONS_QUALITY";

		public const string EnvironmentEffects = "_ENVIRONMENTEFFECTS_ON";

		public static int Ground_Layer;

		public static int LowObstacles_Layer;

		public static int Obstacles_Layer;

		public static int ObstaclesNoFoW_Layer;

		public static int FoWOcclusion_Layer;

		public static int EntityDetect_Layer;

		public static int Ping_Layer;

		public static int Entity_Layer;

		public static int Dimension_Layer;

		public static int MouseGround_LayerMask;

		public static int Ping_LayerMask;

		public static int EntityKinematic_LayerMask;

		public static int Entity_LayerMask;

		public static int Hitbox_LayerMask;

		public static int Ground_LayerMask;

		public static int LowObstacles_LayerMask;

		public static int Obstacles_LayerMask;

		public static int ObstaclesNoFoW_LayerMask;

		public static int FoWOcclusion_LayerMask;

		public static int Char_OverlayOff_LayerMask;

		public static int Char_OverlayOn_LayerMask;

		public static int EntityMask;

		public const int EnemyOverlayColorChannel = 3;

		public const int AllyOverlayColorChannel = 2;

		public const int GenericOverlayColorChannel = 10;

		public static LocalManager Instance;

		public static void InitializeLayers()
		{
		}

		public void PreAwake()
		{
		}

		public void Localise(Translator translator)
		{
		}
	}
}
