using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using UnityEngine;

namespace Il2CppBAPBAP.Local;

public class SetGlobalShaderSettings : MonoBehaviour
{
	private static readonly IntPtr NativeFieldInfoPtr_zoneColor;

	private static readonly IntPtr NativeFieldInfoPtr_zoneEdgeColor;

	private static readonly IntPtr NativeFieldInfoPtr_zoneGlowColor;

	private static readonly IntPtr NativeFieldInfoPtr_zonePreviewRingColor;

	private static readonly IntPtr NativeFieldInfoPtr_zonePreviewRingWidth;

	private static readonly IntPtr NativeFieldInfoPtr_zoneGlowSize;

	private static readonly IntPtr NativeFieldInfoPtr_zoneEdgeWidth;

	private static readonly IntPtr NativeFieldInfoPtr_zoneSharpness;

	private static readonly IntPtr NativeFieldInfoPtr_fowShadowColor;

	private static readonly IntPtr NativeFieldInfoPtr_worldLight;

	private static readonly IntPtr NativeFieldInfoPtr_nightWorldLightIntensity;

	private static readonly IntPtr NativeFieldInfoPtr_nightShadowStrength;

	private static readonly IntPtr NativeFieldInfoPtr_nightLightColor;

	private static readonly IntPtr NativeFieldInfoPtr_nightFowShadowColor;

	private static readonly IntPtr NativeFieldInfoPtr_dayWorldLightIntensity;

	private static readonly IntPtr NativeFieldInfoPtr_dayShadowStrength;

	private static readonly IntPtr NativeFieldInfoPtr_dayLightColor;

	private static readonly IntPtr NativeFieldInfoPtr_curentFowShadowColor;

	private static readonly IntPtr NativeFieldInfoPtr_currentWorldLightIntensity;

	private static readonly IntPtr NativeFieldInfoPtr_currentShadowStrength;

	private static readonly IntPtr NativeFieldInfoPtr__WorldLight_k__BackingField;

	private static readonly IntPtr NativeMethodInfoPtr_get_WorldLight_Public_Static_get_Light_0;

	private static readonly IntPtr NativeMethodInfoPtr_set_WorldLight_Private_Static_set_Void_Light_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnValidate_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_Awake_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnEnable_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_SetNightTimeEnabled_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_SetNightTimeDisabled_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_SetShaderSettings_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_SetFoWShaderSettings_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_SetLightShaderSettings_Public_Static_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe Color zoneColor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_zoneColor);
			return *(Color*)num;
		}
		set
		{
			*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_zoneColor)) = color;
		}
	}

	public unsafe Color zoneEdgeColor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_zoneEdgeColor);
			return *(Color*)num;
		}
		set
		{
			*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_zoneEdgeColor)) = color;
		}
	}

	public unsafe Color zoneGlowColor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_zoneGlowColor);
			return *(Color*)num;
		}
		set
		{
			*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_zoneGlowColor)) = color;
		}
	}

	public unsafe Color zonePreviewRingColor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_zonePreviewRingColor);
			return *(Color*)num;
		}
		set
		{
			*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_zonePreviewRingColor)) = color;
		}
	}

	public unsafe float zonePreviewRingWidth
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_zonePreviewRingWidth);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_zonePreviewRingWidth)) = num;
		}
	}

	public unsafe float zoneGlowSize
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_zoneGlowSize);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_zoneGlowSize)) = num;
		}
	}

	public unsafe float zoneEdgeWidth
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_zoneEdgeWidth);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_zoneEdgeWidth)) = num;
		}
	}

	public unsafe float zoneSharpness
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_zoneSharpness);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_zoneSharpness)) = num;
		}
	}

	public unsafe Color fowShadowColor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fowShadowColor);
			return *(Color*)num;
		}
		set
		{
			*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fowShadowColor)) = color;
		}
	}

	public unsafe Light worldLight
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_worldLight);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Light>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_worldLight)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)light));
		}
	}

	public unsafe float nightWorldLightIntensity
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_nightWorldLightIntensity);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_nightWorldLightIntensity)) = num;
		}
	}

	public unsafe float nightShadowStrength
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_nightShadowStrength);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_nightShadowStrength)) = num;
		}
	}

	public unsafe Color nightLightColor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_nightLightColor);
			return *(Color*)num;
		}
		set
		{
			*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_nightLightColor)) = color;
		}
	}

	public unsafe Color nightFowShadowColor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_nightFowShadowColor);
			return *(Color*)num;
		}
		set
		{
			*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_nightFowShadowColor)) = color;
		}
	}

	public unsafe float dayWorldLightIntensity
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dayWorldLightIntensity);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dayWorldLightIntensity)) = num;
		}
	}

	public unsafe float dayShadowStrength
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dayShadowStrength);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dayShadowStrength)) = num;
		}
	}

	public unsafe Color dayLightColor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dayLightColor);
			return *(Color*)num;
		}
		set
		{
			*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dayLightColor)) = color;
		}
	}

	public unsafe Color curentFowShadowColor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_curentFowShadowColor);
			return *(Color*)num;
		}
		set
		{
			*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_curentFowShadowColor)) = color;
		}
	}

	public unsafe float currentWorldLightIntensity
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentWorldLightIntensity);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentWorldLightIntensity)) = num;
		}
	}

	public unsafe float currentShadowStrength
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentShadowStrength);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentShadowStrength)) = num;
		}
	}

	public unsafe static Light _WorldLight_k__BackingField
	{
		get
		{
			Unsafe.SkipInit(out IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr__WorldLight_k__BackingField, (void*)(&intPtr));
			IntPtr intPtr2 = intPtr;
			return (intPtr2 != (IntPtr)0) ? Il2CppObjectPool.Get<Light>(intPtr2) : null;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr__WorldLight_k__BackingField, (void*)IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)light));
		}
	}

	public unsafe static Light WorldLight
	{
		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 229989, XrefRangeEnd = 229990, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_WorldLight_Public_Static_get_Light_0, (IntPtr)0, (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Light>(intPtr) : null;
		}
		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 229990, XrefRangeEnd = 229991, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		set
		{
			IntPtr* ptr = stackalloc IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)value);
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_set_WorldLight_Private_Static_set_Void_Light_0, (IntPtr)0, (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}
	}

	static SetGlobalShaderSettings()
	{
		Il2CppClassPointerStore<SetGlobalShaderSettings>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Local", "SetGlobalShaderSettings");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<SetGlobalShaderSettings>.NativeClassPtr);
		NativeFieldInfoPtr_zoneColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SetGlobalShaderSettings>.NativeClassPtr, "zoneColor");
		NativeFieldInfoPtr_zoneEdgeColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SetGlobalShaderSettings>.NativeClassPtr, "zoneEdgeColor");
		NativeFieldInfoPtr_zoneGlowColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SetGlobalShaderSettings>.NativeClassPtr, "zoneGlowColor");
		NativeFieldInfoPtr_zonePreviewRingColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SetGlobalShaderSettings>.NativeClassPtr, "zonePreviewRingColor");
		NativeFieldInfoPtr_zonePreviewRingWidth = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SetGlobalShaderSettings>.NativeClassPtr, "zonePreviewRingWidth");
		NativeFieldInfoPtr_zoneGlowSize = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SetGlobalShaderSettings>.NativeClassPtr, "zoneGlowSize");
		NativeFieldInfoPtr_zoneEdgeWidth = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SetGlobalShaderSettings>.NativeClassPtr, "zoneEdgeWidth");
		NativeFieldInfoPtr_zoneSharpness = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SetGlobalShaderSettings>.NativeClassPtr, "zoneSharpness");
		NativeFieldInfoPtr_fowShadowColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SetGlobalShaderSettings>.NativeClassPtr, "fowShadowColor");
		NativeFieldInfoPtr_worldLight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SetGlobalShaderSettings>.NativeClassPtr, "worldLight");
		NativeFieldInfoPtr_nightWorldLightIntensity = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SetGlobalShaderSettings>.NativeClassPtr, "nightWorldLightIntensity");
		NativeFieldInfoPtr_nightShadowStrength = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SetGlobalShaderSettings>.NativeClassPtr, "nightShadowStrength");
		NativeFieldInfoPtr_nightLightColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SetGlobalShaderSettings>.NativeClassPtr, "nightLightColor");
		NativeFieldInfoPtr_nightFowShadowColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SetGlobalShaderSettings>.NativeClassPtr, "nightFowShadowColor");
		NativeFieldInfoPtr_dayWorldLightIntensity = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SetGlobalShaderSettings>.NativeClassPtr, "dayWorldLightIntensity");
		NativeFieldInfoPtr_dayShadowStrength = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SetGlobalShaderSettings>.NativeClassPtr, "dayShadowStrength");
		NativeFieldInfoPtr_dayLightColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SetGlobalShaderSettings>.NativeClassPtr, "dayLightColor");
		NativeFieldInfoPtr_curentFowShadowColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SetGlobalShaderSettings>.NativeClassPtr, "curentFowShadowColor");
		NativeFieldInfoPtr_currentWorldLightIntensity = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SetGlobalShaderSettings>.NativeClassPtr, "currentWorldLightIntensity");
		NativeFieldInfoPtr_currentShadowStrength = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SetGlobalShaderSettings>.NativeClassPtr, "currentShadowStrength");
		NativeFieldInfoPtr__WorldLight_k__BackingField = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SetGlobalShaderSettings>.NativeClassPtr, "<WorldLight>k__BackingField");
		NativeMethodInfoPtr_get_WorldLight_Public_Static_get_Light_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SetGlobalShaderSettings>.NativeClassPtr, 100684672);
		NativeMethodInfoPtr_set_WorldLight_Private_Static_set_Void_Light_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SetGlobalShaderSettings>.NativeClassPtr, 100684673);
		NativeMethodInfoPtr_OnValidate_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SetGlobalShaderSettings>.NativeClassPtr, 100684674);
		NativeMethodInfoPtr_Awake_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SetGlobalShaderSettings>.NativeClassPtr, 100684675);
		NativeMethodInfoPtr_OnEnable_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SetGlobalShaderSettings>.NativeClassPtr, 100684676);
		NativeMethodInfoPtr_SetNightTimeEnabled_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SetGlobalShaderSettings>.NativeClassPtr, 100684677);
		NativeMethodInfoPtr_SetNightTimeDisabled_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SetGlobalShaderSettings>.NativeClassPtr, 100684678);
		NativeMethodInfoPtr_SetShaderSettings_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SetGlobalShaderSettings>.NativeClassPtr, 100684679);
		NativeMethodInfoPtr_SetFoWShaderSettings_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SetGlobalShaderSettings>.NativeClassPtr, 100684680);
		NativeMethodInfoPtr_SetLightShaderSettings_Public_Static_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SetGlobalShaderSettings>.NativeClassPtr, 100684681);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SetGlobalShaderSettings>.NativeClassPtr, 100684682);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 229991, XrefRangeEnd = 229995, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnValidate()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnValidate_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 229995, XrefRangeEnd = 230002, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Awake()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Awake_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 230002, XrefRangeEnd = 230003, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnEnable()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnEnable_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 230010, RefRangeEnd = 230011, XrefRangeStart = 230003, XrefRangeEnd = 230010, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetNightTimeEnabled()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetNightTimeEnabled_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 230018, RefRangeEnd = 230019, XrefRangeStart = 230011, XrefRangeEnd = 230018, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetNightTimeDisabled()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetNightTimeDisabled_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 230033, RefRangeEnd = 230037, XrefRangeStart = 230019, XrefRangeEnd = 230033, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetShaderSettings()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetShaderSettings_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 230037, XrefRangeEnd = 230040, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetFoWShaderSettings()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetFoWShaderSettings_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 230055, RefRangeEnd = 230057, XrefRangeStart = 230040, XrefRangeEnd = 230055, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void SetLightShaderSettings()
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetLightShaderSettings_Public_Static_Void_0, (IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 230057, XrefRangeEnd = 230058, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe SetGlobalShaderSettings()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<SetGlobalShaderSettings>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public SetGlobalShaderSettings(IntPtr pointer)
		: base(pointer)
	{
	}
}
