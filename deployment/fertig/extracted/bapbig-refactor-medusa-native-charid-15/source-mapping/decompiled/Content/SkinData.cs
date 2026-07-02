using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using UnityEngine;

namespace Il2CppBAPBAP.Content;

public class SkinData : ScriptableObject
{
	private static readonly IntPtr NativeFieldInfoPtr_defaultSkinDisplayScale;

	private static readonly IntPtr NativeFieldInfoPtr_contentVisualizer3DPrefab;

	private static readonly IntPtr NativeFieldInfoPtr_vis3DSettings;

	private static readonly IntPtr NativeFieldInfoPtr_thumbVis3DSettings;

	private static readonly IntPtr NativeFieldInfoPtr_TriggerRebuild;

	private static readonly IntPtr NativeFieldInfoPtr_skins;

	private static readonly IntPtr NativeFieldInfoPtr_assetSkinOffset;

	private static readonly IntPtr NativeMethodInfoPtr_GetSkinBySkinId_Public_Skin_Int32_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetSkinIdBySkin_Public_Int32_Skin_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetSkinByAssetId_Public_Skin_Int32_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetSkinIdBySkinAssetId_Public_Static_Int32_Int32_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetSkinAssetIdBySkin_Public_Static_Int32_Skin_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe float defaultSkinDisplayScale
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defaultSkinDisplayScale);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defaultSkinDisplayScale)) = num;
		}
	}

	public unsafe ContentVisualizer3D contentVisualizer3DPrefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_contentVisualizer3DPrefab);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<ContentVisualizer3D>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_contentVisualizer3DPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)contentVisualizer3D));
		}
	}

	public unsafe ContentVisualizer3D.VisualizerSettings vis3DSettings
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vis3DSettings);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<ContentVisualizer3D.VisualizerSettings>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vis3DSettings)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)visualizerSettings));
		}
	}

	public unsafe ContentVisualizer3D.VisualizerSettings thumbVis3DSettings
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_thumbVis3DSettings);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<ContentVisualizer3D.VisualizerSettings>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_thumbVis3DSettings)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)visualizerSettings));
		}
	}

	public unsafe bool TriggerRebuild
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_TriggerRebuild);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_TriggerRebuild)) = flag;
		}
	}

	public unsafe Il2CppReferenceArray<SkinSO> skins
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_skins);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<SkinSO>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_skins)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe static int assetSkinOffset
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_assetSkinOffset, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_assetSkinOffset, (void*)(&num));
		}
	}

	static SkinData()
	{
		Il2CppClassPointerStore<SkinData>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Content", "SkinData");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<SkinData>.NativeClassPtr);
		NativeFieldInfoPtr_defaultSkinDisplayScale = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SkinData>.NativeClassPtr, "defaultSkinDisplayScale");
		NativeFieldInfoPtr_contentVisualizer3DPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SkinData>.NativeClassPtr, "contentVisualizer3DPrefab");
		NativeFieldInfoPtr_vis3DSettings = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SkinData>.NativeClassPtr, "vis3DSettings");
		NativeFieldInfoPtr_thumbVis3DSettings = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SkinData>.NativeClassPtr, "thumbVis3DSettings");
		NativeFieldInfoPtr_TriggerRebuild = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SkinData>.NativeClassPtr, "TriggerRebuild");
		NativeFieldInfoPtr_skins = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SkinData>.NativeClassPtr, "skins");
		NativeFieldInfoPtr_assetSkinOffset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SkinData>.NativeClassPtr, "assetSkinOffset");
		NativeMethodInfoPtr_GetSkinBySkinId_Public_Skin_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SkinData>.NativeClassPtr, 100682989);
		NativeMethodInfoPtr_GetSkinIdBySkin_Public_Int32_Skin_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SkinData>.NativeClassPtr, 100682990);
		NativeMethodInfoPtr_GetSkinByAssetId_Public_Skin_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SkinData>.NativeClassPtr, 100682991);
		NativeMethodInfoPtr_GetSkinIdBySkinAssetId_Public_Static_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SkinData>.NativeClassPtr, 100682992);
		NativeMethodInfoPtr_GetSkinAssetIdBySkin_Public_Static_Int32_Skin_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SkinData>.NativeClassPtr, 100682993);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SkinData>.NativeClassPtr, 100682994);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 217167, XrefRangeEnd = 217170, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Skin GetSkinBySkinId(int skinId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&skinId);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetSkinBySkinId_Public_Skin_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Skin>(intPtr) : null;
	}

	[CallerCount(0)]
	public unsafe int GetSkinIdBySkin(Skin skin)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)skin);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetSkinIdBySkin_Public_Int32_Skin_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(8)]
	[CachedScanResults(RefRangeStart = 217171, RefRangeEnd = 217179, XrefRangeStart = 217170, XrefRangeEnd = 217171, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Skin GetSkinByAssetId(int assetId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&assetId);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetSkinByAssetId_Public_Skin_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Skin>(intPtr) : null;
	}

	[CallerCount(0)]
	public unsafe static int GetSkinIdBySkinAssetId(int skinAssetId)
	{
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&skinAssetId);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetSkinIdBySkinAssetId_Public_Static_Int32_Int32_0, (IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	public unsafe static int GetSkinAssetIdBySkin(Skin skin)
	{
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)skin);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetSkinAssetIdBySkin_Public_Static_Int32_Skin_0, (IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 0, XrefRangeEnd = 0, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe SkinData()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<SkinData>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public SkinData(IntPtr pointer)
		: base(pointer)
	{
	}
}
