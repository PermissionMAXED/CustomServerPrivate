using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Entities;
using Il2CppBAPBAP.Localisation;
using Il2CppBAPBAP.Pooling;
using Il2CppBAPBAP.Steam;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using UnityEngine;

namespace Il2CppBAPBAP.Local;

public class LocalManager : MonoBehaviour
{
	private static readonly IntPtr NativeFieldInfoPtr_localSavedData;

	private static readonly IntPtr NativeFieldInfoPtr_inputSystem;

	private static readonly IntPtr NativeFieldInfoPtr_inputManager;

	private static readonly IntPtr NativeFieldInfoPtr_audioManager;

	private static readonly IntPtr NativeFieldInfoPtr_fmodManager;

	private static readonly IntPtr NativeFieldInfoPtr_voiceManager;

	private static readonly IntPtr NativeFieldInfoPtr_itemManager;

	private static readonly IntPtr NativeFieldInfoPtr_vfxManager;

	private static readonly IntPtr NativeFieldInfoPtr_postCamMouse;

	private static readonly IntPtr NativeFieldInfoPtr_networkCache;

	private static readonly IntPtr NativeFieldInfoPtr_bushManager;

	private static readonly IntPtr NativeFieldInfoPtr_rngManager;

	private static readonly IntPtr NativeFieldInfoPtr_emoteManager;

	private static readonly IntPtr NativeFieldInfoPtr_tombstoneManager;

	private static readonly IntPtr NativeFieldInfoPtr_contentManager;

	private static readonly IntPtr NativeFieldInfoPtr_pingManager;

	private static readonly IntPtr NativeFieldInfoPtr_itemCurrencyManager;

	private static readonly IntPtr NativeFieldInfoPtr_passiveManager;

	private static readonly IntPtr NativeFieldInfoPtr_statusEffectManager;

	private static readonly IntPtr NativeFieldInfoPtr_gameModifierManager;

	private static readonly IntPtr NativeFieldInfoPtr_analyticsManager;

	private static readonly IntPtr NativeFieldInfoPtr_steamManager;

	private static readonly IntPtr NativeFieldInfoPtr_entityAssetsManager;

	private static readonly IntPtr NativeFieldInfoPtr_augmentManager;

	private static readonly IntPtr NativeFieldInfoPtr_dimensionManager;

	private static readonly IntPtr NativeFieldInfoPtr_modelSwapManager;

	private static readonly IntPtr NativeFieldInfoPtr_prefabLibrary;

	private static readonly IntPtr NativeFieldInfoPtr_voicelineGlobalConfig;

	private static readonly IntPtr NativeFieldInfoPtr_LocalCharWorldPos_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_LocalCharWorldPos_0_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_LocalCharWorldPos_1_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_LocalMousePos_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_LocalCharRendWorldPos_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_LocalCharRendWorldPos_0_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_LocalCharRendWorldPos_1_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_CharBushMoveDirection_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_CharBushMoveDirection_0_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_CharBushMoveDirection_1_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_MapWorldSize_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_MapEdgeWidthMultiplier_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_BRZonePosition_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_BRZoneRadius_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_BRZonePreviewWorldPos_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_BRZonePreviewWorldRadius_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_BRRingClosing_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_BRZoneColor_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_BRZoneEdgeColor_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_BRZoneGlowColor_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_BRZonePreviewRingColor_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_BRZonePreviewRingWidth_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_BRZoneGlowSize_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_BRZoneEdgeWidth_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_BRZoneSharpness_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_FoWRadiusMin_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_FoWRadiusMax_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_FoWFadeRadiusMin_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_FoWFadeRadiusMax_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_FoWScale_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_FoWTex_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_FowWorldPos_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_FowWorldPosRounded_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_FoWShadowColor_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_FoWAlpha_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_WorldLightColor_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_WorldLightDir_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_UnscaledTime_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_EntityHitBlinkAmount_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_EntityHitBlinkColor_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_Color_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_RingFrac_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_RingEdgeSize_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_RingOffset_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_ItemOutlineColor_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_ItemOutlineSize_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_ItemFresnelColor_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_Amount_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_ItemTier_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_PlaneEffectTex_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_PlaneEffectCamSize_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_OverlayColorChannel_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_PerRendererColor_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_OverlayBackAmount_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_OverlayFrontAmount_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_DimensionEntity_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_DimensionCharacter_ShaderProperty;

	private static readonly IntPtr NativeFieldInfoPtr_OverlayFoWOcclude;

	private static readonly IntPtr NativeFieldInfoPtr_OverlayPass;

	private static readonly IntPtr NativeFieldInfoPtr_OverlayOverrideChannel;

	private static readonly IntPtr NativeFieldInfoPtr_ReflectionsQuality;

	private static readonly IntPtr NativeFieldInfoPtr_EnvironmentEffects;

	private static readonly IntPtr NativeFieldInfoPtr_Ground_Layer;

	private static readonly IntPtr NativeFieldInfoPtr_LowObstacles_Layer;

	private static readonly IntPtr NativeFieldInfoPtr_Obstacles_Layer;

	private static readonly IntPtr NativeFieldInfoPtr_ObstaclesNoFoW_Layer;

	private static readonly IntPtr NativeFieldInfoPtr_FoWOcclusion_Layer;

	private static readonly IntPtr NativeFieldInfoPtr_EntityDetect_Layer;

	private static readonly IntPtr NativeFieldInfoPtr_Ping_Layer;

	private static readonly IntPtr NativeFieldInfoPtr_Entity_Layer;

	private static readonly IntPtr NativeFieldInfoPtr_Dimension_Layer;

	private static readonly IntPtr NativeFieldInfoPtr_MouseGround_LayerMask;

	private static readonly IntPtr NativeFieldInfoPtr_Ping_LayerMask;

	private static readonly IntPtr NativeFieldInfoPtr_EntityKinematic_LayerMask;

	private static readonly IntPtr NativeFieldInfoPtr_Entity_LayerMask;

	private static readonly IntPtr NativeFieldInfoPtr_Hitbox_LayerMask;

	private static readonly IntPtr NativeFieldInfoPtr_Ground_LayerMask;

	private static readonly IntPtr NativeFieldInfoPtr_LowObstacles_LayerMask;

	private static readonly IntPtr NativeFieldInfoPtr_Obstacles_LayerMask;

	private static readonly IntPtr NativeFieldInfoPtr_ObstaclesNoFoW_LayerMask;

	private static readonly IntPtr NativeFieldInfoPtr_FoWOcclusion_LayerMask;

	private static readonly IntPtr NativeFieldInfoPtr_Char_OverlayOff_LayerMask;

	private static readonly IntPtr NativeFieldInfoPtr_Char_OverlayOn_LayerMask;

	private static readonly IntPtr NativeFieldInfoPtr_EntityMask;

	private static readonly IntPtr NativeFieldInfoPtr_EnemyOverlayColorChannel;

	private static readonly IntPtr NativeFieldInfoPtr_AllyOverlayColorChannel;

	private static readonly IntPtr NativeFieldInfoPtr_GenericOverlayColorChannel;

	private static readonly IntPtr NativeFieldInfoPtr_Instance;

	private static readonly IntPtr NativeMethodInfoPtr_InitializeLayers_Public_Static_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_PreAwake_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_Localise_Public_Void_Translator_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe LocalSavedData localSavedData
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_localSavedData);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<LocalSavedData>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_localSavedData)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)localSavedData));
		}
	}

	public unsafe InputSystem inputSystem
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inputSystem);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<InputSystem>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inputSystem)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)inputSystem));
		}
	}

	public unsafe InputManager inputManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inputManager);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<InputManager>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inputManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)inputManager));
		}
	}

	public unsafe AudioManager audioManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_audioManager);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<AudioManager>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_audioManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)audioManager));
		}
	}

	public unsafe FMODManager fmodManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fmodManager);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<FMODManager>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fmodManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)fMODManager));
		}
	}

	public unsafe VoiceManager voiceManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_voiceManager);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<VoiceManager>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_voiceManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)voiceManager));
		}
	}

	public unsafe ItemManager itemManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_itemManager);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<ItemManager>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_itemManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)itemManager));
		}
	}

	public unsafe VfxManager vfxManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vfxManager);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<VfxManager>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vfxManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)vfxManager));
		}
	}

	public unsafe PostCameraMouse postCamMouse
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_postCamMouse);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<PostCameraMouse>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_postCamMouse)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)postCameraMouse));
		}
	}

	public unsafe NetworkCache networkCache
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_networkCache);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<NetworkCache>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_networkCache)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)networkCache));
		}
	}

	public unsafe BushManager bushManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bushManager);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<BushManager>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bushManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)bushManager));
		}
	}

	public unsafe RngManager rngManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rngManager);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<RngManager>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rngManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)rngManager));
		}
	}

	public unsafe EmoteManager emoteManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_emoteManager);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<EmoteManager>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_emoteManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)emoteManager));
		}
	}

	public unsafe TombstoneManager tombstoneManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tombstoneManager);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<TombstoneManager>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tombstoneManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tombstoneManager));
		}
	}

	public unsafe ContentManager contentManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_contentManager);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<ContentManager>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_contentManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)contentManager));
		}
	}

	public unsafe PingManager pingManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pingManager);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<PingManager>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pingManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)pingManager));
		}
	}

	public unsafe ItemCurrencyManager itemCurrencyManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_itemCurrencyManager);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<ItemCurrencyManager>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_itemCurrencyManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)itemCurrencyManager));
		}
	}

	public unsafe PassiveManager passiveManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_passiveManager);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<PassiveManager>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_passiveManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)passiveManager));
		}
	}

	public unsafe StatusEffectManager statusEffectManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_statusEffectManager);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<StatusEffectManager>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_statusEffectManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)statusEffectManager));
		}
	}

	public unsafe GameModifierManager gameModifierManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameModifierManager);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<GameModifierManager>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gameModifierManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameModifierManager));
		}
	}

	public unsafe AnalyticsManager analyticsManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_analyticsManager);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<AnalyticsManager>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_analyticsManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)analyticsManager));
		}
	}

	public unsafe SteamManager steamManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_steamManager);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<SteamManager>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_steamManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)steamManager));
		}
	}

	public unsafe EntityAssetsManager entityAssetsManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_entityAssetsManager);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<EntityAssetsManager>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_entityAssetsManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entityAssetsManager));
		}
	}

	public unsafe AugmentManager augmentManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_augmentManager);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<AugmentManager>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_augmentManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)augmentManager));
		}
	}

	public unsafe DimensionManager dimensionManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dimensionManager);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<DimensionManager>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dimensionManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)dimensionManager));
		}
	}

	public unsafe ModelSwapManager modelSwapManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_modelSwapManager);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<ModelSwapManager>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_modelSwapManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)modelSwapManager));
		}
	}

	public unsafe LocalPrefabLibrary prefabLibrary
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prefabLibrary);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<LocalPrefabLibrary>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prefabLibrary)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)localPrefabLibrary));
		}
	}

	public unsafe CharVoicelineGlobalConfig voicelineGlobalConfig
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_voicelineGlobalConfig);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<CharVoicelineGlobalConfig>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_voicelineGlobalConfig)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)charVoicelineGlobalConfig));
		}
	}

	public unsafe static int LocalCharWorldPos_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_LocalCharWorldPos_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_LocalCharWorldPos_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int LocalCharWorldPos_0_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_LocalCharWorldPos_0_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_LocalCharWorldPos_0_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int LocalCharWorldPos_1_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_LocalCharWorldPos_1_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_LocalCharWorldPos_1_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int LocalMousePos_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_LocalMousePos_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_LocalMousePos_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int LocalCharRendWorldPos_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_LocalCharRendWorldPos_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_LocalCharRendWorldPos_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int LocalCharRendWorldPos_0_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_LocalCharRendWorldPos_0_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_LocalCharRendWorldPos_0_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int LocalCharRendWorldPos_1_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_LocalCharRendWorldPos_1_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_LocalCharRendWorldPos_1_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int CharBushMoveDirection_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_CharBushMoveDirection_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_CharBushMoveDirection_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int CharBushMoveDirection_0_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_CharBushMoveDirection_0_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_CharBushMoveDirection_0_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int CharBushMoveDirection_1_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_CharBushMoveDirection_1_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_CharBushMoveDirection_1_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int MapWorldSize_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_MapWorldSize_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_MapWorldSize_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int MapEdgeWidthMultiplier_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_MapEdgeWidthMultiplier_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_MapEdgeWidthMultiplier_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int BRZonePosition_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_BRZonePosition_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_BRZonePosition_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int BRZoneRadius_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_BRZoneRadius_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_BRZoneRadius_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int BRZonePreviewWorldPos_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_BRZonePreviewWorldPos_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_BRZonePreviewWorldPos_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int BRZonePreviewWorldRadius_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_BRZonePreviewWorldRadius_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_BRZonePreviewWorldRadius_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int BRRingClosing_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_BRRingClosing_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_BRRingClosing_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int BRZoneColor_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_BRZoneColor_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_BRZoneColor_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int BRZoneEdgeColor_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_BRZoneEdgeColor_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_BRZoneEdgeColor_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int BRZoneGlowColor_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_BRZoneGlowColor_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_BRZoneGlowColor_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int BRZonePreviewRingColor_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_BRZonePreviewRingColor_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_BRZonePreviewRingColor_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int BRZonePreviewRingWidth_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_BRZonePreviewRingWidth_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_BRZonePreviewRingWidth_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int BRZoneGlowSize_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_BRZoneGlowSize_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_BRZoneGlowSize_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int BRZoneEdgeWidth_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_BRZoneEdgeWidth_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_BRZoneEdgeWidth_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int BRZoneSharpness_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_BRZoneSharpness_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_BRZoneSharpness_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int FoWRadiusMin_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_FoWRadiusMin_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_FoWRadiusMin_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int FoWRadiusMax_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_FoWRadiusMax_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_FoWRadiusMax_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int FoWFadeRadiusMin_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_FoWFadeRadiusMin_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_FoWFadeRadiusMin_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int FoWFadeRadiusMax_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_FoWFadeRadiusMax_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_FoWFadeRadiusMax_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int FoWScale_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_FoWScale_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_FoWScale_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int FoWTex_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_FoWTex_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_FoWTex_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int FowWorldPos_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_FowWorldPos_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_FowWorldPos_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int FowWorldPosRounded_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_FowWorldPosRounded_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_FowWorldPosRounded_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int FoWShadowColor_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_FoWShadowColor_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_FoWShadowColor_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int FoWAlpha_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_FoWAlpha_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_FoWAlpha_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int WorldLightColor_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_WorldLightColor_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_WorldLightColor_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int WorldLightDir_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_WorldLightDir_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_WorldLightDir_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int UnscaledTime_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_UnscaledTime_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_UnscaledTime_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int EntityHitBlinkAmount_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_EntityHitBlinkAmount_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_EntityHitBlinkAmount_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int EntityHitBlinkColor_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_EntityHitBlinkColor_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_EntityHitBlinkColor_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int Color_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_Color_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_Color_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int RingFrac_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_RingFrac_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_RingFrac_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int RingEdgeSize_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_RingEdgeSize_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_RingEdgeSize_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int RingOffset_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_RingOffset_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_RingOffset_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int ItemOutlineColor_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_ItemOutlineColor_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_ItemOutlineColor_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int ItemOutlineSize_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_ItemOutlineSize_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_ItemOutlineSize_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int ItemFresnelColor_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_ItemFresnelColor_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_ItemFresnelColor_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int Amount_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_Amount_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_Amount_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int ItemTier_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_ItemTier_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_ItemTier_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int PlaneEffectTex_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_PlaneEffectTex_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_PlaneEffectTex_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int PlaneEffectCamSize_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_PlaneEffectCamSize_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_PlaneEffectCamSize_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int OverlayColorChannel_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_OverlayColorChannel_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_OverlayColorChannel_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int PerRendererColor_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_PerRendererColor_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_PerRendererColor_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int OverlayBackAmount_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_OverlayBackAmount_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_OverlayBackAmount_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int OverlayFrontAmount_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_OverlayFrontAmount_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_OverlayFrontAmount_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int DimensionEntity_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_DimensionEntity_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_DimensionEntity_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static int DimensionCharacter_ShaderProperty
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_DimensionCharacter_ShaderProperty, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_DimensionCharacter_ShaderProperty, (void*)(&num));
		}
	}

	public unsafe static string OverlayFoWOcclude
	{
		get
		{
			Unsafe.SkipInit(out IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_OverlayFoWOcclude, (void*)(&intPtr));
			return IL2CPP.Il2CppStringToManaged(intPtr);
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_OverlayFoWOcclude, (void*)IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe static string OverlayPass
	{
		get
		{
			Unsafe.SkipInit(out IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_OverlayPass, (void*)(&intPtr));
			return IL2CPP.Il2CppStringToManaged(intPtr);
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_OverlayPass, (void*)IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe static string OverlayOverrideChannel
	{
		get
		{
			Unsafe.SkipInit(out IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_OverlayOverrideChannel, (void*)(&intPtr));
			return IL2CPP.Il2CppStringToManaged(intPtr);
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_OverlayOverrideChannel, (void*)IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe static string ReflectionsQuality
	{
		get
		{
			Unsafe.SkipInit(out IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_ReflectionsQuality, (void*)(&intPtr));
			return IL2CPP.Il2CppStringToManaged(intPtr);
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_ReflectionsQuality, (void*)IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe static string EnvironmentEffects
	{
		get
		{
			Unsafe.SkipInit(out IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_EnvironmentEffects, (void*)(&intPtr));
			return IL2CPP.Il2CppStringToManaged(intPtr);
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_EnvironmentEffects, (void*)IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe static int Ground_Layer
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_Ground_Layer, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_Ground_Layer, (void*)(&num));
		}
	}

	public unsafe static int LowObstacles_Layer
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_LowObstacles_Layer, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_LowObstacles_Layer, (void*)(&num));
		}
	}

	public unsafe static int Obstacles_Layer
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_Obstacles_Layer, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_Obstacles_Layer, (void*)(&num));
		}
	}

	public unsafe static int ObstaclesNoFoW_Layer
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_ObstaclesNoFoW_Layer, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_ObstaclesNoFoW_Layer, (void*)(&num));
		}
	}

	public unsafe static int FoWOcclusion_Layer
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_FoWOcclusion_Layer, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_FoWOcclusion_Layer, (void*)(&num));
		}
	}

	public unsafe static int EntityDetect_Layer
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_EntityDetect_Layer, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_EntityDetect_Layer, (void*)(&num));
		}
	}

	public unsafe static int Ping_Layer
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_Ping_Layer, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_Ping_Layer, (void*)(&num));
		}
	}

	public unsafe static int Entity_Layer
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_Entity_Layer, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_Entity_Layer, (void*)(&num));
		}
	}

	public unsafe static int Dimension_Layer
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_Dimension_Layer, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_Dimension_Layer, (void*)(&num));
		}
	}

	public unsafe static int MouseGround_LayerMask
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_MouseGround_LayerMask, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_MouseGround_LayerMask, (void*)(&num));
		}
	}

	public unsafe static int Ping_LayerMask
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_Ping_LayerMask, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_Ping_LayerMask, (void*)(&num));
		}
	}

	public unsafe static int EntityKinematic_LayerMask
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_EntityKinematic_LayerMask, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_EntityKinematic_LayerMask, (void*)(&num));
		}
	}

	public unsafe static int Entity_LayerMask
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_Entity_LayerMask, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_Entity_LayerMask, (void*)(&num));
		}
	}

	public unsafe static int Hitbox_LayerMask
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_Hitbox_LayerMask, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_Hitbox_LayerMask, (void*)(&num));
		}
	}

	public unsafe static int Ground_LayerMask
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_Ground_LayerMask, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_Ground_LayerMask, (void*)(&num));
		}
	}

	public unsafe static int LowObstacles_LayerMask
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_LowObstacles_LayerMask, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_LowObstacles_LayerMask, (void*)(&num));
		}
	}

	public unsafe static int Obstacles_LayerMask
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_Obstacles_LayerMask, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_Obstacles_LayerMask, (void*)(&num));
		}
	}

	public unsafe static int ObstaclesNoFoW_LayerMask
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_ObstaclesNoFoW_LayerMask, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_ObstaclesNoFoW_LayerMask, (void*)(&num));
		}
	}

	public unsafe static int FoWOcclusion_LayerMask
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_FoWOcclusion_LayerMask, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_FoWOcclusion_LayerMask, (void*)(&num));
		}
	}

	public unsafe static int Char_OverlayOff_LayerMask
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_Char_OverlayOff_LayerMask, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_Char_OverlayOff_LayerMask, (void*)(&num));
		}
	}

	public unsafe static int Char_OverlayOn_LayerMask
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_Char_OverlayOn_LayerMask, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_Char_OverlayOn_LayerMask, (void*)(&num));
		}
	}

	public unsafe static int EntityMask
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_EntityMask, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_EntityMask, (void*)(&num));
		}
	}

	public unsafe static int EnemyOverlayColorChannel
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_EnemyOverlayColorChannel, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_EnemyOverlayColorChannel, (void*)(&num));
		}
	}

	public unsafe static int AllyOverlayColorChannel
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_AllyOverlayColorChannel, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_AllyOverlayColorChannel, (void*)(&num));
		}
	}

	public unsafe static int GenericOverlayColorChannel
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_GenericOverlayColorChannel, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_GenericOverlayColorChannel, (void*)(&num));
		}
	}

	public unsafe static LocalManager Instance
	{
		get
		{
			Unsafe.SkipInit(out IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_Instance, (void*)(&intPtr));
			IntPtr intPtr2 = intPtr;
			return (intPtr2 != (IntPtr)0) ? Il2CppObjectPool.Get<LocalManager>(intPtr2) : null;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_Instance, (void*)IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)localManager));
		}
	}

	static LocalManager()
	{
		Il2CppClassPointerStore<LocalManager>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Local", "LocalManager");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<LocalManager>.NativeClassPtr);
		NativeFieldInfoPtr_localSavedData = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "localSavedData");
		NativeFieldInfoPtr_inputSystem = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "inputSystem");
		NativeFieldInfoPtr_inputManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "inputManager");
		NativeFieldInfoPtr_audioManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "audioManager");
		NativeFieldInfoPtr_fmodManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "fmodManager");
		NativeFieldInfoPtr_voiceManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "voiceManager");
		NativeFieldInfoPtr_itemManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "itemManager");
		NativeFieldInfoPtr_vfxManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "vfxManager");
		NativeFieldInfoPtr_postCamMouse = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "postCamMouse");
		NativeFieldInfoPtr_networkCache = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "networkCache");
		NativeFieldInfoPtr_bushManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "bushManager");
		NativeFieldInfoPtr_rngManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "rngManager");
		NativeFieldInfoPtr_emoteManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "emoteManager");
		NativeFieldInfoPtr_tombstoneManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "tombstoneManager");
		NativeFieldInfoPtr_contentManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "contentManager");
		NativeFieldInfoPtr_pingManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "pingManager");
		NativeFieldInfoPtr_itemCurrencyManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "itemCurrencyManager");
		NativeFieldInfoPtr_passiveManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "passiveManager");
		NativeFieldInfoPtr_statusEffectManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "statusEffectManager");
		NativeFieldInfoPtr_gameModifierManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "gameModifierManager");
		NativeFieldInfoPtr_analyticsManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "analyticsManager");
		NativeFieldInfoPtr_steamManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "steamManager");
		NativeFieldInfoPtr_entityAssetsManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "entityAssetsManager");
		NativeFieldInfoPtr_augmentManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "augmentManager");
		NativeFieldInfoPtr_dimensionManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "dimensionManager");
		NativeFieldInfoPtr_modelSwapManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "modelSwapManager");
		NativeFieldInfoPtr_prefabLibrary = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "prefabLibrary");
		NativeFieldInfoPtr_voicelineGlobalConfig = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "voicelineGlobalConfig");
		NativeFieldInfoPtr_LocalCharWorldPos_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "LocalCharWorldPos_ShaderProperty");
		NativeFieldInfoPtr_LocalCharWorldPos_0_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "LocalCharWorldPos_0_ShaderProperty");
		NativeFieldInfoPtr_LocalCharWorldPos_1_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "LocalCharWorldPos_1_ShaderProperty");
		NativeFieldInfoPtr_LocalMousePos_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "LocalMousePos_ShaderProperty");
		NativeFieldInfoPtr_LocalCharRendWorldPos_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "LocalCharRendWorldPos_ShaderProperty");
		NativeFieldInfoPtr_LocalCharRendWorldPos_0_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "LocalCharRendWorldPos_0_ShaderProperty");
		NativeFieldInfoPtr_LocalCharRendWorldPos_1_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "LocalCharRendWorldPos_1_ShaderProperty");
		NativeFieldInfoPtr_CharBushMoveDirection_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "CharBushMoveDirection_ShaderProperty");
		NativeFieldInfoPtr_CharBushMoveDirection_0_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "CharBushMoveDirection_0_ShaderProperty");
		NativeFieldInfoPtr_CharBushMoveDirection_1_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "CharBushMoveDirection_1_ShaderProperty");
		NativeFieldInfoPtr_MapWorldSize_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "MapWorldSize_ShaderProperty");
		NativeFieldInfoPtr_MapEdgeWidthMultiplier_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "MapEdgeWidthMultiplier_ShaderProperty");
		NativeFieldInfoPtr_BRZonePosition_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "BRZonePosition_ShaderProperty");
		NativeFieldInfoPtr_BRZoneRadius_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "BRZoneRadius_ShaderProperty");
		NativeFieldInfoPtr_BRZonePreviewWorldPos_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "BRZonePreviewWorldPos_ShaderProperty");
		NativeFieldInfoPtr_BRZonePreviewWorldRadius_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "BRZonePreviewWorldRadius_ShaderProperty");
		NativeFieldInfoPtr_BRRingClosing_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "BRRingClosing_ShaderProperty");
		NativeFieldInfoPtr_BRZoneColor_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "BRZoneColor_ShaderProperty");
		NativeFieldInfoPtr_BRZoneEdgeColor_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "BRZoneEdgeColor_ShaderProperty");
		NativeFieldInfoPtr_BRZoneGlowColor_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "BRZoneGlowColor_ShaderProperty");
		NativeFieldInfoPtr_BRZonePreviewRingColor_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "BRZonePreviewRingColor_ShaderProperty");
		NativeFieldInfoPtr_BRZonePreviewRingWidth_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "BRZonePreviewRingWidth_ShaderProperty");
		NativeFieldInfoPtr_BRZoneGlowSize_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "BRZoneGlowSize_ShaderProperty");
		NativeFieldInfoPtr_BRZoneEdgeWidth_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "BRZoneEdgeWidth_ShaderProperty");
		NativeFieldInfoPtr_BRZoneSharpness_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "BRZoneSharpness_ShaderProperty");
		NativeFieldInfoPtr_FoWRadiusMin_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "FoWRadiusMin_ShaderProperty");
		NativeFieldInfoPtr_FoWRadiusMax_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "FoWRadiusMax_ShaderProperty");
		NativeFieldInfoPtr_FoWFadeRadiusMin_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "FoWFadeRadiusMin_ShaderProperty");
		NativeFieldInfoPtr_FoWFadeRadiusMax_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "FoWFadeRadiusMax_ShaderProperty");
		NativeFieldInfoPtr_FoWScale_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "FoWScale_ShaderProperty");
		NativeFieldInfoPtr_FoWTex_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "FoWTex_ShaderProperty");
		NativeFieldInfoPtr_FowWorldPos_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "FowWorldPos_ShaderProperty");
		NativeFieldInfoPtr_FowWorldPosRounded_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "FowWorldPosRounded_ShaderProperty");
		NativeFieldInfoPtr_FoWShadowColor_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "FoWShadowColor_ShaderProperty");
		NativeFieldInfoPtr_FoWAlpha_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "FoWAlpha_ShaderProperty");
		NativeFieldInfoPtr_WorldLightColor_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "WorldLightColor_ShaderProperty");
		NativeFieldInfoPtr_WorldLightDir_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "WorldLightDir_ShaderProperty");
		NativeFieldInfoPtr_UnscaledTime_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "UnscaledTime_ShaderProperty");
		NativeFieldInfoPtr_EntityHitBlinkAmount_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "EntityHitBlinkAmount_ShaderProperty");
		NativeFieldInfoPtr_EntityHitBlinkColor_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "EntityHitBlinkColor_ShaderProperty");
		NativeFieldInfoPtr_Color_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "Color_ShaderProperty");
		NativeFieldInfoPtr_RingFrac_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "RingFrac_ShaderProperty");
		NativeFieldInfoPtr_RingEdgeSize_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "RingEdgeSize_ShaderProperty");
		NativeFieldInfoPtr_RingOffset_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "RingOffset_ShaderProperty");
		NativeFieldInfoPtr_ItemOutlineColor_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "ItemOutlineColor_ShaderProperty");
		NativeFieldInfoPtr_ItemOutlineSize_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "ItemOutlineSize_ShaderProperty");
		NativeFieldInfoPtr_ItemFresnelColor_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "ItemFresnelColor_ShaderProperty");
		NativeFieldInfoPtr_Amount_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "Amount_ShaderProperty");
		NativeFieldInfoPtr_ItemTier_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "ItemTier_ShaderProperty");
		NativeFieldInfoPtr_PlaneEffectTex_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "PlaneEffectTex_ShaderProperty");
		NativeFieldInfoPtr_PlaneEffectCamSize_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "PlaneEffectCamSize_ShaderProperty");
		NativeFieldInfoPtr_OverlayColorChannel_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "OverlayColorChannel_ShaderProperty");
		NativeFieldInfoPtr_PerRendererColor_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "PerRendererColor_ShaderProperty");
		NativeFieldInfoPtr_OverlayBackAmount_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "OverlayBackAmount_ShaderProperty");
		NativeFieldInfoPtr_OverlayFrontAmount_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "OverlayFrontAmount_ShaderProperty");
		NativeFieldInfoPtr_DimensionEntity_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "DimensionEntity_ShaderProperty");
		NativeFieldInfoPtr_DimensionCharacter_ShaderProperty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "DimensionCharacter_ShaderProperty");
		NativeFieldInfoPtr_OverlayFoWOcclude = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "OverlayFoWOcclude");
		NativeFieldInfoPtr_OverlayPass = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "OverlayPass");
		NativeFieldInfoPtr_OverlayOverrideChannel = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "OverlayOverrideChannel");
		NativeFieldInfoPtr_ReflectionsQuality = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "ReflectionsQuality");
		NativeFieldInfoPtr_EnvironmentEffects = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "EnvironmentEffects");
		NativeFieldInfoPtr_Ground_Layer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "Ground_Layer");
		NativeFieldInfoPtr_LowObstacles_Layer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "LowObstacles_Layer");
		NativeFieldInfoPtr_Obstacles_Layer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "Obstacles_Layer");
		NativeFieldInfoPtr_ObstaclesNoFoW_Layer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "ObstaclesNoFoW_Layer");
		NativeFieldInfoPtr_FoWOcclusion_Layer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "FoWOcclusion_Layer");
		NativeFieldInfoPtr_EntityDetect_Layer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "EntityDetect_Layer");
		NativeFieldInfoPtr_Ping_Layer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "Ping_Layer");
		NativeFieldInfoPtr_Entity_Layer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "Entity_Layer");
		NativeFieldInfoPtr_Dimension_Layer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "Dimension_Layer");
		NativeFieldInfoPtr_MouseGround_LayerMask = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "MouseGround_LayerMask");
		NativeFieldInfoPtr_Ping_LayerMask = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "Ping_LayerMask");
		NativeFieldInfoPtr_EntityKinematic_LayerMask = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "EntityKinematic_LayerMask");
		NativeFieldInfoPtr_Entity_LayerMask = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "Entity_LayerMask");
		NativeFieldInfoPtr_Hitbox_LayerMask = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "Hitbox_LayerMask");
		NativeFieldInfoPtr_Ground_LayerMask = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "Ground_LayerMask");
		NativeFieldInfoPtr_LowObstacles_LayerMask = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "LowObstacles_LayerMask");
		NativeFieldInfoPtr_Obstacles_LayerMask = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "Obstacles_LayerMask");
		NativeFieldInfoPtr_ObstaclesNoFoW_LayerMask = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "ObstaclesNoFoW_LayerMask");
		NativeFieldInfoPtr_FoWOcclusion_LayerMask = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "FoWOcclusion_LayerMask");
		NativeFieldInfoPtr_Char_OverlayOff_LayerMask = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "Char_OverlayOff_LayerMask");
		NativeFieldInfoPtr_Char_OverlayOn_LayerMask = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "Char_OverlayOn_LayerMask");
		NativeFieldInfoPtr_EntityMask = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "EntityMask");
		NativeFieldInfoPtr_EnemyOverlayColorChannel = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "EnemyOverlayColorChannel");
		NativeFieldInfoPtr_AllyOverlayColorChannel = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "AllyOverlayColorChannel");
		NativeFieldInfoPtr_GenericOverlayColorChannel = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "GenericOverlayColorChannel");
		NativeFieldInfoPtr_Instance = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, "Instance");
		NativeMethodInfoPtr_InitializeLayers_Public_Static_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, 100684352);
		NativeMethodInfoPtr_PreAwake_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, 100684353);
		NativeMethodInfoPtr_Localise_Public_Void_Translator_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, 100684354);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LocalManager>.NativeClassPtr, 100684355);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 227120, RefRangeEnd = 227123, XrefRangeStart = 227072, XrefRangeEnd = 227120, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void InitializeLayers()
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_InitializeLayers_Public_Static_Void_0, (IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 227193, RefRangeEnd = 227194, XrefRangeStart = 227123, XrefRangeEnd = 227193, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void PreAwake()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_PreAwake_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 227199, RefRangeEnd = 227200, XrefRangeStart = 227194, XrefRangeEnd = 227199, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Localise(Translator translator)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)translator);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Localise_Public_Void_Translator_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(72)]
	[CachedScanResults(RefRangeStart = 5521, RefRangeEnd = 5593, XrefRangeStart = 5521, XrefRangeEnd = 5593, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe LocalManager()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<LocalManager>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public LocalManager(IntPtr pointer)
		: base(pointer)
	{
	}
}
