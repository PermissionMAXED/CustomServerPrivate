using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Utilities;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using UnityEngine;

namespace Il2CppBAPBAP.Network;

public class AdaptivePlaybackBuffer : Il2CppSystem.Object
{
	private static readonly System.IntPtr NativeFieldInfoPtr_ERR_THRESOLD;

	private static readonly System.IntPtr NativeFieldInfoPtr_CONFIDENCE_INTERVAL_MULTIPLIER;

	private static readonly System.IntPtr NativeFieldInfoPtr_delayMA;

	private static readonly System.IntPtr NativeFieldInfoPtr_initialized;

	private static readonly System.IntPtr NativeFieldInfoPtr_playbackTime;

	private static readonly System.IntPtr NativeFieldInfoPtr_timeSinceLastSnapshotReceived;

	private static readonly System.IntPtr NativeFieldInfoPtr_latestSnapshotServerTime;

	private static readonly System.IntPtr NativeFieldInfoPtr_targetDelay;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UpdateAdaptiveDelay_Public_Void_Int32_Double_GameObject_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CalculatePlaybackTime_Public_Double_Single_Boolean_0;

	public unsafe static double ERR_THRESOLD
	{
		get
		{
			Unsafe.SkipInit(out double result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_ERR_THRESOLD, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_ERR_THRESOLD, (void*)(&num));
		}
	}

	public unsafe static double CONFIDENCE_INTERVAL_MULTIPLIER
	{
		get
		{
			Unsafe.SkipInit(out double result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_CONFIDENCE_INTERVAL_MULTIPLIER, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_CONFIDENCE_INTERVAL_MULTIPLIER, (void*)(&num));
		}
	}

	public unsafe ExpMovingAverageDouble delayMA
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_delayMA);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ExpMovingAverageDouble>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_delayMA)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)expMovingAverageDouble));
		}
	}

	public unsafe bool initialized
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_initialized);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_initialized)) = flag;
		}
	}

	public unsafe double playbackTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playbackTime);
			return *(double*)num;
		}
		set
		{
			*(double*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playbackTime)) = num;
		}
	}

	public unsafe double timeSinceLastSnapshotReceived
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_timeSinceLastSnapshotReceived);
			return *(double*)num;
		}
		set
		{
			*(double*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_timeSinceLastSnapshotReceived)) = num;
		}
	}

	public unsafe double latestSnapshotServerTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_latestSnapshotServerTime);
			return *(double*)num;
		}
		set
		{
			*(double*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_latestSnapshotServerTime)) = num;
		}
	}

	public unsafe double targetDelay
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_targetDelay);
			return *(double*)num;
		}
		set
		{
			*(double*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_targetDelay)) = num;
		}
	}

	static AdaptivePlaybackBuffer()
	{
		Il2CppClassPointerStore<AdaptivePlaybackBuffer>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Network", "AdaptivePlaybackBuffer");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<AdaptivePlaybackBuffer>.NativeClassPtr);
		NativeFieldInfoPtr_ERR_THRESOLD = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AdaptivePlaybackBuffer>.NativeClassPtr, "ERR_THRESOLD");
		NativeFieldInfoPtr_CONFIDENCE_INTERVAL_MULTIPLIER = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AdaptivePlaybackBuffer>.NativeClassPtr, "CONFIDENCE_INTERVAL_MULTIPLIER");
		NativeFieldInfoPtr_delayMA = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AdaptivePlaybackBuffer>.NativeClassPtr, "delayMA");
		NativeFieldInfoPtr_initialized = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AdaptivePlaybackBuffer>.NativeClassPtr, "initialized");
		NativeFieldInfoPtr_playbackTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AdaptivePlaybackBuffer>.NativeClassPtr, "playbackTime");
		NativeFieldInfoPtr_timeSinceLastSnapshotReceived = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AdaptivePlaybackBuffer>.NativeClassPtr, "timeSinceLastSnapshotReceived");
		NativeFieldInfoPtr_latestSnapshotServerTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AdaptivePlaybackBuffer>.NativeClassPtr, "latestSnapshotServerTime");
		NativeFieldInfoPtr_targetDelay = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AdaptivePlaybackBuffer>.NativeClassPtr, "targetDelay");
		NativeMethodInfoPtr__ctor_Public_Void_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<AdaptivePlaybackBuffer>.NativeClassPtr, 100666681);
		NativeMethodInfoPtr_UpdateAdaptiveDelay_Public_Void_Int32_Double_GameObject_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<AdaptivePlaybackBuffer>.NativeClassPtr, 100666682);
		NativeMethodInfoPtr_CalculatePlaybackTime_Public_Double_Single_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<AdaptivePlaybackBuffer>.NativeClassPtr, 100666683);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 75035, RefRangeEnd = 75036, XrefRangeStart = 75031, XrefRangeEnd = 75035, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe AdaptivePlaybackBuffer(int timingStatsWindowSize)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<AdaptivePlaybackBuffer>.NativeClassPtr))
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&timingStatsWindowSize);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 75067, RefRangeEnd = 75068, XrefRangeStart = 75036, XrefRangeEnd = 75067, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UpdateAdaptiveDelay(int tickNum, double simFixedDt, GameObject lol, bool isLog)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[4];
		*ptr = (nint)(&tickNum);
		*(double**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &simFixedDt;
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)lol);
		*(bool**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &isLog;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UpdateAdaptiveDelay_Public_Void_Int32_Double_GameObject_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 75091, RefRangeEnd = 75092, XrefRangeStart = 75068, XrefRangeEnd = 75091, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe double CalculatePlaybackTime(float deltaTime, bool isLog)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&deltaTime);
		*(bool**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &isLog;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CalculatePlaybackTime_Public_Double_Single_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(double*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	public AdaptivePlaybackBuffer(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
