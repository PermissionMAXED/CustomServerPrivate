using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using UnityEngine;

namespace Il2CppBAPBAP.Content;

public class TombstoneData : ScriptableObject
{
	private static readonly IntPtr NativeFieldInfoPtr_defaultDisplayScale;

	private static readonly IntPtr NativeFieldInfoPtr_contentVisualizer3DPrefab;

	private static readonly IntPtr NativeFieldInfoPtr_vis3DSettings;

	private static readonly IntPtr NativeFieldInfoPtr_thumbVis3DSettings;

	private static readonly IntPtr NativeFieldInfoPtr_TriggerRebuild;

	private static readonly IntPtr NativeFieldInfoPtr_tombstones;

	private static readonly IntPtr NativeFieldInfoPtr_assetTombstoneOffset;

	private static readonly IntPtr NativeMethodInfoPtr_GetTombstoneByTombstoneId_Public_Tombstone_Int32_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetTombstoneIdByTombstone_Public_Int32_Tombstone_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetTombstoneByAssetId_Public_Tombstone_Int32_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetTombstoneAssetIdByTombstone_Public_Static_Int32_Tombstone_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe float defaultDisplayScale
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defaultDisplayScale);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defaultDisplayScale)) = num;
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

	public unsafe Il2CppReferenceArray<TombstoneSO> tombstones
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tombstones);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<TombstoneSO>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tombstones)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe static int assetTombstoneOffset
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_assetTombstoneOffset, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_assetTombstoneOffset, (void*)(&num));
		}
	}

	static TombstoneData()
	{
		Il2CppClassPointerStore<TombstoneData>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Content", "TombstoneData");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<TombstoneData>.NativeClassPtr);
		NativeFieldInfoPtr_defaultDisplayScale = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TombstoneData>.NativeClassPtr, "defaultDisplayScale");
		NativeFieldInfoPtr_contentVisualizer3DPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TombstoneData>.NativeClassPtr, "contentVisualizer3DPrefab");
		NativeFieldInfoPtr_vis3DSettings = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TombstoneData>.NativeClassPtr, "vis3DSettings");
		NativeFieldInfoPtr_thumbVis3DSettings = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TombstoneData>.NativeClassPtr, "thumbVis3DSettings");
		NativeFieldInfoPtr_TriggerRebuild = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TombstoneData>.NativeClassPtr, "TriggerRebuild");
		NativeFieldInfoPtr_tombstones = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TombstoneData>.NativeClassPtr, "tombstones");
		NativeFieldInfoPtr_assetTombstoneOffset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TombstoneData>.NativeClassPtr, "assetTombstoneOffset");
		NativeMethodInfoPtr_GetTombstoneByTombstoneId_Public_Tombstone_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TombstoneData>.NativeClassPtr, 100683006);
		NativeMethodInfoPtr_GetTombstoneIdByTombstone_Public_Int32_Tombstone_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TombstoneData>.NativeClassPtr, 100683007);
		NativeMethodInfoPtr_GetTombstoneByAssetId_Public_Tombstone_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TombstoneData>.NativeClassPtr, 100683008);
		NativeMethodInfoPtr_GetTombstoneAssetIdByTombstone_Public_Static_Int32_Tombstone_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TombstoneData>.NativeClassPtr, 100683009);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TombstoneData>.NativeClassPtr, 100683010);
	}

	[CallerCount(0)]
	public unsafe Tombstone GetTombstoneByTombstoneId(int tombstoneId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&tombstoneId);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetTombstoneByTombstoneId_Public_Tombstone_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Tombstone>(intPtr) : null;
	}

	[CallerCount(0)]
	public unsafe int GetTombstoneIdByTombstone(Tombstone tombstone)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tombstone);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetTombstoneIdByTombstone_Public_Int32_Tombstone_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 217184, RefRangeEnd = 217187, XrefRangeStart = 217183, XrefRangeEnd = 217184, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Tombstone GetTombstoneByAssetId(int assetId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&assetId);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetTombstoneByAssetId_Public_Tombstone_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Tombstone>(intPtr) : null;
	}

	[CallerCount(0)]
	public unsafe static int GetTombstoneAssetIdByTombstone(Tombstone tombstone)
	{
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tombstone);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetTombstoneAssetIdByTombstone_Public_Static_Int32_Tombstone_0, (IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 0, XrefRangeEnd = 0, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe TombstoneData()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<TombstoneData>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public TombstoneData(IntPtr pointer)
		: base(pointer)
	{
	}
}
