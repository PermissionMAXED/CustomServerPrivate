using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Debugging;
using Il2CppBAPBAP.Local;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using UnityEngine;

namespace Il2CppBAPBAP.Entities.View;

public class PredictedInterpolator : Il2CppSystem.Object
{
	private static readonly System.IntPtr NativeFieldInfoPtr_timeline;

	private static readonly System.IntPtr NativeFieldInfoPtr_timelineCapacity;

	private static readonly System.IntPtr NativeFieldInfoPtr_timelineLatestIndex;

	private static readonly System.IntPtr NativeFieldInfoPtr_snapTicks;

	private static readonly System.IntPtr NativeFieldInfoPtr_prevRenderedLerpData;

	private static readonly System.IntPtr NativeFieldInfoPtr_prevPlaybackTickFraction;

	private static readonly System.IntPtr NativeFieldInfoPtr_MAX_ERR_SQ;

	private static readonly System.IntPtr NativeFieldInfoPtr_errorSmoothFactor;

	private static readonly System.IntPtr NativeFieldInfoPtr_inputManager;

	private static readonly System.IntPtr NativeFieldInfoPtr_debugNetManager;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_TransformLerpData_Int32_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ModifyData_Public_Void_TransformLerpData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_AddData_Public_Void_TransformLerpData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_AddSnap_Public_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_RemoveSnap_Public_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetLatestAddedData_Public_TransformLerpData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CalculateLerpedData_Public_TransformLerpData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetTickPair_Private_Boolean_Double_byref_TransformLerpData_byref_TransformLerpData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetReconciliationError_Private_Vector3_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_AdjustReconciliationError_Private_TransformLerpData_Vector3_TransformLerpData_Double_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetAndPruneSnapTicks_Private_Boolean_Int32_0;

	public unsafe Il2CppStructArray<TransformLerpData> timeline
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_timeline);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<TransformLerpData>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_timeline)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe int timelineCapacity
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_timelineCapacity);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_timelineCapacity)) = num;
		}
	}

	public unsafe int timelineLatestIndex
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_timelineLatestIndex);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_timelineLatestIndex)) = num;
		}
	}

	public unsafe List<SnapLerpData> snapTicks
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_snapTicks);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<SnapLerpData>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_snapTicks)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	public unsafe TransformLerpData prevRenderedLerpData
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prevRenderedLerpData);
			return *(TransformLerpData*)num;
		}
		set
		{
			*(TransformLerpData*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prevRenderedLerpData)) = transformLerpData;
		}
	}

	public unsafe double prevPlaybackTickFraction
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prevPlaybackTickFraction);
			return *(double*)num;
		}
		set
		{
			*(double*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prevPlaybackTickFraction)) = num;
		}
	}

	public unsafe static float MAX_ERR_SQ
	{
		get
		{
			Unsafe.SkipInit(out float result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_MAX_ERR_SQ, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_MAX_ERR_SQ, (void*)(&num));
		}
	}

	public unsafe float errorSmoothFactor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_errorSmoothFactor);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_errorSmoothFactor)) = num;
		}
	}

	public unsafe InputManager inputManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inputManager);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<InputManager>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inputManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)inputManager));
		}
	}

	public unsafe DebugNetcodeManager debugNetManager
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_debugNetManager);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<DebugNetcodeManager>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_debugNetManager)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)debugNetcodeManager));
		}
	}

	static PredictedInterpolator()
	{
		Il2CppClassPointerStore<PredictedInterpolator>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Entities.View", "PredictedInterpolator");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<PredictedInterpolator>.NativeClassPtr);
		NativeFieldInfoPtr_timeline = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PredictedInterpolator>.NativeClassPtr, "timeline");
		NativeFieldInfoPtr_timelineCapacity = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PredictedInterpolator>.NativeClassPtr, "timelineCapacity");
		NativeFieldInfoPtr_timelineLatestIndex = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PredictedInterpolator>.NativeClassPtr, "timelineLatestIndex");
		NativeFieldInfoPtr_snapTicks = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PredictedInterpolator>.NativeClassPtr, "snapTicks");
		NativeFieldInfoPtr_prevRenderedLerpData = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PredictedInterpolator>.NativeClassPtr, "prevRenderedLerpData");
		NativeFieldInfoPtr_prevPlaybackTickFraction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PredictedInterpolator>.NativeClassPtr, "prevPlaybackTickFraction");
		NativeFieldInfoPtr_MAX_ERR_SQ = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PredictedInterpolator>.NativeClassPtr, "MAX_ERR_SQ");
		NativeFieldInfoPtr_errorSmoothFactor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PredictedInterpolator>.NativeClassPtr, "errorSmoothFactor");
		NativeFieldInfoPtr_inputManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PredictedInterpolator>.NativeClassPtr, "inputManager");
		NativeFieldInfoPtr_debugNetManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PredictedInterpolator>.NativeClassPtr, "debugNetManager");
		NativeMethodInfoPtr__ctor_Public_Void_TransformLerpData_Int32_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PredictedInterpolator>.NativeClassPtr, 100682372);
		NativeMethodInfoPtr_ModifyData_Public_Void_TransformLerpData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PredictedInterpolator>.NativeClassPtr, 100682373);
		NativeMethodInfoPtr_AddData_Public_Void_TransformLerpData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PredictedInterpolator>.NativeClassPtr, 100682374);
		NativeMethodInfoPtr_AddSnap_Public_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PredictedInterpolator>.NativeClassPtr, 100682375);
		NativeMethodInfoPtr_RemoveSnap_Public_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PredictedInterpolator>.NativeClassPtr, 100682376);
		NativeMethodInfoPtr_GetLatestAddedData_Public_TransformLerpData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PredictedInterpolator>.NativeClassPtr, 100682377);
		NativeMethodInfoPtr_CalculateLerpedData_Public_TransformLerpData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PredictedInterpolator>.NativeClassPtr, 100682378);
		NativeMethodInfoPtr_GetTickPair_Private_Boolean_Double_byref_TransformLerpData_byref_TransformLerpData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PredictedInterpolator>.NativeClassPtr, 100682379);
		NativeMethodInfoPtr_GetReconciliationError_Private_Vector3_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PredictedInterpolator>.NativeClassPtr, 100682380);
		NativeMethodInfoPtr_AdjustReconciliationError_Private_TransformLerpData_Vector3_TransformLerpData_Double_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PredictedInterpolator>.NativeClassPtr, 100682381);
		NativeMethodInfoPtr_GetAndPruneSnapTicks_Private_Boolean_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PredictedInterpolator>.NativeClassPtr, 100682382);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 211043, RefRangeEnd = 211044, XrefRangeStart = 211033, XrefRangeEnd = 211043, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe PredictedInterpolator(TransformLerpData initialData, int timelineCapacity, float errorSmoothFactor)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<PredictedInterpolator>.NativeClassPtr))
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = (nint)(&initialData);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &timelineCapacity;
		*(float**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &errorSmoothFactor;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_TransformLerpData_Int32_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 211044, RefRangeEnd = 211045, XrefRangeStart = 211044, XrefRangeEnd = 211044, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ModifyData(TransformLerpData newData)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&newData);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ModifyData_Public_Void_TransformLerpData_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 211045, RefRangeEnd = 211046, XrefRangeStart = 211045, XrefRangeEnd = 211045, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void AddData(TransformLerpData newData)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&newData);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_AddData_Public_Void_TransformLerpData_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 211048, RefRangeEnd = 211049, XrefRangeStart = 211046, XrefRangeEnd = 211048, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void AddSnap(int tickNum)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&tickNum);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_AddSnap_Public_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 211054, RefRangeEnd = 211055, XrefRangeStart = 211049, XrefRangeEnd = 211054, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void RemoveSnap(int tickNum)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&tickNum);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_RemoveSnap_Public_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 211055, RefRangeEnd = 211056, XrefRangeStart = 211055, XrefRangeEnd = 211055, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe TransformLerpData GetLatestAddedData()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetLatestAddedData_Public_TransformLerpData_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(TransformLerpData*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 211089, RefRangeEnd = 211090, XrefRangeStart = 211056, XrefRangeEnd = 211089, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe TransformLerpData CalculateLerpedData()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CalculateLerpedData_Public_TransformLerpData_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(TransformLerpData*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 211092, RefRangeEnd = 211094, XrefRangeStart = 211090, XrefRangeEnd = 211092, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe bool GetTickPair(double tickFraction, out TransformLerpData startData, out TransformLerpData goalData)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = (nint)(&tickFraction);
		*(void**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = Unsafe.AsPointer(ref startData);
		*(void**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = Unsafe.AsPointer(ref goalData);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetTickPair_Private_Boolean_Double_byref_TransformLerpData_byref_TransformLerpData_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 211101, RefRangeEnd = 211102, XrefRangeStart = 211094, XrefRangeEnd = 211101, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Vector3 GetReconciliationError()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetReconciliationError_Private_Vector3_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(Vector3*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	public unsafe TransformLerpData AdjustReconciliationError(Vector3 posError, TransformLerpData lerpedData, double playbackTickFraction)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = (nint)(&posError);
		*(TransformLerpData**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &lerpedData;
		*(double**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &playbackTickFraction;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_AdjustReconciliationError_Private_TransformLerpData_Vector3_TransformLerpData_Double_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(TransformLerpData*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 211102, XrefRangeEnd = 211110, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe bool GetAndPruneSnapTicks(int playbackTickNum)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&playbackTickNum);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetAndPruneSnapTicks_Private_Boolean_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	public PredictedInterpolator(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
