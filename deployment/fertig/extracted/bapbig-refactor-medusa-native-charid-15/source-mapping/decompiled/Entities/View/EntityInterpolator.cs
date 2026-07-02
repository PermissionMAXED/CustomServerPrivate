using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Local;
using Il2CppBAPBAP.Network;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using UnityEngine;

namespace Il2CppBAPBAP.Entities.View;

public class EntityInterpolator : Il2CppSystem.Object
{
	private static readonly System.IntPtr NativeFieldInfoPtr_MAX_GAP_SEARCH;

	private static readonly System.IntPtr NativeFieldInfoPtr_inputManager;

	private static readonly System.IntPtr NativeFieldInfoPtr_timeline;

	private static readonly System.IntPtr NativeFieldInfoPtr_timelineCapacity;

	private static readonly System.IntPtr NativeFieldInfoPtr_snapTicks;

	private static readonly System.IntPtr NativeFieldInfoPtr_playbackBuffer;

	private static readonly System.IntPtr NativeFieldInfoPtr_isLog;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_AddData_Public_Void_TransformLerpData_GameObject_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CalculateLerpedData_Public_TransformLerpData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetTickPair_Private_Boolean_Double_byref_TransformLerpData_byref_TransformLerpData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_AddSnap_Public_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_RemoveSnap_Public_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetAndPruneSnapTicks_Private_Boolean_Int32_0;

	public unsafe static int MAX_GAP_SEARCH
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_MAX_GAP_SEARCH, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_MAX_GAP_SEARCH, (void*)(&num));
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

	public unsafe AdaptivePlaybackBuffer playbackBuffer
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playbackBuffer);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AdaptivePlaybackBuffer>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playbackBuffer)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)adaptivePlaybackBuffer));
		}
	}

	public unsafe bool isLog
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isLog);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isLog)) = flag;
		}
	}

	static EntityInterpolator()
	{
		Il2CppClassPointerStore<EntityInterpolator>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Entities.View", "EntityInterpolator");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<EntityInterpolator>.NativeClassPtr);
		NativeFieldInfoPtr_MAX_GAP_SEARCH = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityInterpolator>.NativeClassPtr, "MAX_GAP_SEARCH");
		NativeFieldInfoPtr_inputManager = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityInterpolator>.NativeClassPtr, "inputManager");
		NativeFieldInfoPtr_timeline = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityInterpolator>.NativeClassPtr, "timeline");
		NativeFieldInfoPtr_timelineCapacity = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityInterpolator>.NativeClassPtr, "timelineCapacity");
		NativeFieldInfoPtr_snapTicks = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityInterpolator>.NativeClassPtr, "snapTicks");
		NativeFieldInfoPtr_playbackBuffer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityInterpolator>.NativeClassPtr, "playbackBuffer");
		NativeFieldInfoPtr_isLog = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityInterpolator>.NativeClassPtr, "isLog");
		NativeMethodInfoPtr__ctor_Public_Void_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EntityInterpolator>.NativeClassPtr, 100682350);
		NativeMethodInfoPtr_AddData_Public_Void_TransformLerpData_GameObject_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EntityInterpolator>.NativeClassPtr, 100682351);
		NativeMethodInfoPtr_CalculateLerpedData_Public_TransformLerpData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EntityInterpolator>.NativeClassPtr, 100682352);
		NativeMethodInfoPtr_GetTickPair_Private_Boolean_Double_byref_TransformLerpData_byref_TransformLerpData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EntityInterpolator>.NativeClassPtr, 100682353);
		NativeMethodInfoPtr_AddSnap_Public_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EntityInterpolator>.NativeClassPtr, 100682354);
		NativeMethodInfoPtr_RemoveSnap_Public_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EntityInterpolator>.NativeClassPtr, 100682355);
		NativeMethodInfoPtr_GetAndPruneSnapTicks_Private_Boolean_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EntityInterpolator>.NativeClassPtr, 100682356);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 210914, RefRangeEnd = 210916, XrefRangeStart = 210902, XrefRangeEnd = 210914, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe EntityInterpolator(int timelineCapacity, int timingStatsWindowSize)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<EntityInterpolator>.NativeClassPtr))
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&timelineCapacity);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &timingStatsWindowSize;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_Int32_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 210927, RefRangeEnd = 210930, XrefRangeStart = 210916, XrefRangeEnd = 210927, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void AddData(TransformLerpData data, GameObject lol, bool isLog = false)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = (nint)(&data);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)lol);
		*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &isLog;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_AddData_Public_Void_TransformLerpData_GameObject_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 210955, RefRangeEnd = 210958, XrefRangeStart = 210930, XrefRangeEnd = 210955, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe TransformLerpData CalculateLerpedData()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CalculateLerpedData_Public_TransformLerpData_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(TransformLerpData*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 210958, XrefRangeEnd = 210959, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
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
	[CachedScanResults(RefRangeStart = 210961, RefRangeEnd = 210962, XrefRangeStart = 210959, XrefRangeEnd = 210961, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
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
	[CachedScanResults(RefRangeStart = 210967, RefRangeEnd = 210968, XrefRangeStart = 210962, XrefRangeEnd = 210967, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void RemoveSnap(int tickNum)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&tickNum);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_RemoveSnap_Public_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 210968, XrefRangeEnd = 210976, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
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

	public EntityInterpolator(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
