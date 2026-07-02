using System;
using System.Runtime.CompilerServices;
using Il2CppAYellowpaper.SerializedCollections;
using Il2CppBAPBAP.AssetContainer;
using Il2CppDreamteck.Splines;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem.Collections.Generic;
using UnityEngine;

namespace Il2CppBAPBAP.Geometry;

public class SplineShapeCreator : MeshShapeCreator
{
	private static readonly IntPtr NativeFieldInfoPtr_splineType;

	private static readonly IntPtr NativeFieldInfoPtr_sampleMode;

	private static readonly IntPtr NativeFieldInfoPtr_sampleRate;

	private static readonly IntPtr NativeFieldInfoPtr_autoCount;

	private static readonly IntPtr NativeFieldInfoPtr_count;

	private static readonly IntPtr NativeFieldInfoPtr_autoUpdateSplines;

	private static readonly IntPtr NativeFieldInfoPtr_instantiatedSplines;

	private static readonly IntPtr NativeMethodInfoPtr_get_IsBaked_Public_Virtual_get_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_Unbake_Public_Virtual_Void_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnRequestBakeProcesses_Protected_Virtual_Void_Dictionary_2_MeshAssetContainer_List_1_MeshFilter_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetSplineMeshFilters_Private_List_1_MeshFilter_0;

	private static readonly IntPtr NativeMethodInfoPtr_UpdateShapeDisplay_Public_Virtual_Void_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr__get_IsBaked_b__8_0_Private_Boolean_MeshFilter_0;

	public unsafe Spline.Type splineType
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_splineType);
			return *(Spline.Type*)num;
		}
		set
		{
			*(Spline.Type*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_splineType)) = type;
		}
	}

	public unsafe SplineComputer.SampleMode sampleMode
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sampleMode);
			return *(SplineComputer.SampleMode*)num;
		}
		set
		{
			*(SplineComputer.SampleMode*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sampleMode)) = sampleMode;
		}
	}

	public unsafe int sampleRate
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sampleRate);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sampleRate)) = num;
		}
	}

	public unsafe bool autoCount
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_autoCount);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_autoCount)) = flag;
		}
	}

	public unsafe int count
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_count);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_count)) = num;
		}
	}

	public unsafe bool autoUpdateSplines
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_autoUpdateSplines);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_autoUpdateSplines)) = flag;
		}
	}

	public unsafe SerializedDictionary<GameObject, string> instantiatedSplines
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_instantiatedSplines);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<SerializedDictionary<GameObject, string>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_instantiatedSplines)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)serializedDictionary));
		}
	}

	public unsafe override bool IsBaked
	{
		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 234689, XrefRangeEnd = 234710, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_get_IsBaked_Public_Virtual_get_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	static SplineShapeCreator()
	{
		Il2CppClassPointerStore<SplineShapeCreator>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Geometry", "SplineShapeCreator");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<SplineShapeCreator>.NativeClassPtr);
		NativeFieldInfoPtr_splineType = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SplineShapeCreator>.NativeClassPtr, "splineType");
		NativeFieldInfoPtr_sampleMode = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SplineShapeCreator>.NativeClassPtr, "sampleMode");
		NativeFieldInfoPtr_sampleRate = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SplineShapeCreator>.NativeClassPtr, "sampleRate");
		NativeFieldInfoPtr_autoCount = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SplineShapeCreator>.NativeClassPtr, "autoCount");
		NativeFieldInfoPtr_count = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SplineShapeCreator>.NativeClassPtr, "count");
		NativeFieldInfoPtr_autoUpdateSplines = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SplineShapeCreator>.NativeClassPtr, "autoUpdateSplines");
		NativeFieldInfoPtr_instantiatedSplines = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SplineShapeCreator>.NativeClassPtr, "instantiatedSplines");
		NativeMethodInfoPtr_get_IsBaked_Public_Virtual_get_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SplineShapeCreator>.NativeClassPtr, 100685252);
		NativeMethodInfoPtr_Unbake_Public_Virtual_Void_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SplineShapeCreator>.NativeClassPtr, 100685253);
		NativeMethodInfoPtr_OnRequestBakeProcesses_Protected_Virtual_Void_Dictionary_2_MeshAssetContainer_List_1_MeshFilter_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SplineShapeCreator>.NativeClassPtr, 100685254);
		NativeMethodInfoPtr_GetSplineMeshFilters_Private_List_1_MeshFilter_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SplineShapeCreator>.NativeClassPtr, 100685255);
		NativeMethodInfoPtr_UpdateShapeDisplay_Public_Virtual_Void_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SplineShapeCreator>.NativeClassPtr, 100685256);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SplineShapeCreator>.NativeClassPtr, 100685257);
		NativeMethodInfoPtr__get_IsBaked_b__8_0_Private_Boolean_MeshFilter_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SplineShapeCreator>.NativeClassPtr, 100685258);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 234710, XrefRangeEnd = 234731, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void Unbake(bool deleteAsset = true)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&deleteAsset);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_Unbake_Public_Virtual_Void_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 234731, XrefRangeEnd = 234749, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void OnRequestBakeProcesses(Dictionary<MeshAssetContainer, List<MeshFilter>> bakeProcesses)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)bakeProcesses);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnRequestBakeProcesses_Protected_Virtual_Void_Dictionary_2_MeshAssetContainer_List_1_MeshFilter_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 234810, RefRangeEnd = 234813, XrefRangeStart = 234749, XrefRangeEnd = 234810, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe List<MeshFilter> GetSplineMeshFilters()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetSplineMeshFilters_Private_List_1_MeshFilter_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<List<MeshFilter>>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 234813, XrefRangeEnd = 234814, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void UpdateShapeDisplay(bool fullRefresh = true)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&fullRefresh);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_UpdateShapeDisplay_Public_Virtual_Void_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 234814, XrefRangeEnd = 234819, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe SplineShapeCreator()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<SplineShapeCreator>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 234819, XrefRangeEnd = 234824, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe bool _get_IsBaked_b__8_0(MeshFilter mf)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)mf);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__get_IsBaked_b__8_0_Private_Boolean_MeshFilter_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	public SplineShapeCreator(IntPtr pointer)
		: base(pointer)
	{
	}
}
