using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppMirror;
using Il2CppSystem.Collections.Generic;
using UnityEngine;

namespace Il2CppBAPBAP.Network;

public class CustomSpatialHashInterestManagement : InterestManagement
{
	private static readonly IntPtr NativeFieldInfoPtr_visHalfRange;

	private static readonly IntPtr NativeFieldInfoPtr_visRangeSqrMag;

	private static readonly IntPtr NativeFieldInfoPtr_resolution;

	private static readonly IntPtr NativeFieldInfoPtr_fullRebuildInterval;

	private static readonly IntPtr NativeFieldInfoPtr_rebuildGroups;

	private static readonly IntPtr NativeFieldInfoPtr_partialRebuildInterval;

	private static readonly IntPtr NativeFieldInfoPtr_lastRebuildTime;

	private static readonly IntPtr NativeFieldInfoPtr_rebuildGroupId;

	private static readonly IntPtr NativeFieldInfoPtr_shouldRepopulateSpatialHash;

	private static readonly IntPtr NativeFieldInfoPtr_grid;

	private static readonly IntPtr NativeMethodInfoPtr_Awake_Protected_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_SetHostVisibility_Public_Virtual_Void_NetworkIdentity_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnCheckObserver_Public_Virtual_Boolean_NetworkIdentity_NetworkConnectionToClient_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnRebuildObservers_Public_Virtual_Void_NetworkIdentity_HashSet_1_NetworkConnectionToClient_0;

	private static readonly IntPtr NativeMethodInfoPtr_ResetState_Public_Virtual_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_FixedUpdate_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_Update_Internal_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_RepopulateSpatialHash_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_RebuildPartial_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_ForceRefresh_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe Vector3 visHalfRange
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_visHalfRange);
			return *(Vector3*)num;
		}
		set
		{
			*(Vector3*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_visHalfRange)) = vector;
		}
	}

	public unsafe float visRangeSqrMag
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_visRangeSqrMag);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_visRangeSqrMag)) = num;
		}
	}

	public unsafe int resolution
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_resolution);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_resolution)) = num;
		}
	}

	public unsafe float fullRebuildInterval
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fullRebuildInterval);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fullRebuildInterval)) = num;
		}
	}

	public unsafe int rebuildGroups
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rebuildGroups);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rebuildGroups)) = num;
		}
	}

	public unsafe double partialRebuildInterval
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_partialRebuildInterval);
			return *(double*)num;
		}
		set
		{
			*(double*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_partialRebuildInterval)) = num;
		}
	}

	public unsafe double lastRebuildTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lastRebuildTime);
			return *(double*)num;
		}
		set
		{
			*(double*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lastRebuildTime)) = num;
		}
	}

	public unsafe int rebuildGroupId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rebuildGroupId);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rebuildGroupId)) = num;
		}
	}

	public unsafe bool shouldRepopulateSpatialHash
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_shouldRepopulateSpatialHash);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_shouldRepopulateSpatialHash)) = flag;
		}
	}

	public unsafe CustomGrid2D<NetworkConnectionToClient> grid
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_grid);
			return new CustomGrid2D<NetworkConnectionToClient>(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<CustomGrid2D<NetworkConnectionToClient>>.NativeClassPtr, (IntPtr)num));
		}
		set
		{
			// IL cpblk instruction
			Unsafe.CopyBlock((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_grid), IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)customGrid2D)), IL2CPP.il2cpp_class_value_size(Il2CppClassPointerStore<CustomGrid2D<NetworkConnectionToClient>>.NativeClassPtr, ref *(uint*)null));
		}
	}

	static CustomSpatialHashInterestManagement()
	{
		Il2CppClassPointerStore<CustomSpatialHashInterestManagement>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Network", "CustomSpatialHashInterestManagement");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CustomSpatialHashInterestManagement>.NativeClassPtr);
		NativeFieldInfoPtr_visHalfRange = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomSpatialHashInterestManagement>.NativeClassPtr, "visHalfRange");
		NativeFieldInfoPtr_visRangeSqrMag = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomSpatialHashInterestManagement>.NativeClassPtr, "visRangeSqrMag");
		NativeFieldInfoPtr_resolution = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomSpatialHashInterestManagement>.NativeClassPtr, "resolution");
		NativeFieldInfoPtr_fullRebuildInterval = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomSpatialHashInterestManagement>.NativeClassPtr, "fullRebuildInterval");
		NativeFieldInfoPtr_rebuildGroups = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomSpatialHashInterestManagement>.NativeClassPtr, "rebuildGroups");
		NativeFieldInfoPtr_partialRebuildInterval = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomSpatialHashInterestManagement>.NativeClassPtr, "partialRebuildInterval");
		NativeFieldInfoPtr_lastRebuildTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomSpatialHashInterestManagement>.NativeClassPtr, "lastRebuildTime");
		NativeFieldInfoPtr_rebuildGroupId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomSpatialHashInterestManagement>.NativeClassPtr, "rebuildGroupId");
		NativeFieldInfoPtr_shouldRepopulateSpatialHash = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomSpatialHashInterestManagement>.NativeClassPtr, "shouldRepopulateSpatialHash");
		NativeFieldInfoPtr_grid = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomSpatialHashInterestManagement>.NativeClassPtr, "grid");
		NativeMethodInfoPtr_Awake_Protected_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomSpatialHashInterestManagement>.NativeClassPtr, 100666772);
		NativeMethodInfoPtr_SetHostVisibility_Public_Virtual_Void_NetworkIdentity_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomSpatialHashInterestManagement>.NativeClassPtr, 100666773);
		NativeMethodInfoPtr_OnCheckObserver_Public_Virtual_Boolean_NetworkIdentity_NetworkConnectionToClient_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomSpatialHashInterestManagement>.NativeClassPtr, 100666774);
		NativeMethodInfoPtr_OnRebuildObservers_Public_Virtual_Void_NetworkIdentity_HashSet_1_NetworkConnectionToClient_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomSpatialHashInterestManagement>.NativeClassPtr, 100666775);
		NativeMethodInfoPtr_ResetState_Public_Virtual_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomSpatialHashInterestManagement>.NativeClassPtr, 100666776);
		NativeMethodInfoPtr_FixedUpdate_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomSpatialHashInterestManagement>.NativeClassPtr, 100666777);
		NativeMethodInfoPtr_Update_Internal_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomSpatialHashInterestManagement>.NativeClassPtr, 100666778);
		NativeMethodInfoPtr_RepopulateSpatialHash_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomSpatialHashInterestManagement>.NativeClassPtr, 100666779);
		NativeMethodInfoPtr_RebuildPartial_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomSpatialHashInterestManagement>.NativeClassPtr, 100666780);
		NativeMethodInfoPtr_ForceRefresh_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomSpatialHashInterestManagement>.NativeClassPtr, 100666781);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomSpatialHashInterestManagement>.NativeClassPtr, 100666782);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 75792, XrefRangeEnd = 75804, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Awake()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Awake_Protected_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(17738)]
	[CachedScanResults(RefRangeStart = 5595, RefRangeEnd = 23333, XrefRangeStart = 5595, XrefRangeEnd = 23333, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void SetHostVisibility(NetworkIdentity identity, bool visible)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)identity);
		*(bool**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &visible;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_SetHostVisibility_Public_Virtual_Void_NetworkIdentity_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 75804, XrefRangeEnd = 75811, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override bool OnCheckObserver(NetworkIdentity identity, NetworkConnectionToClient newObserver)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)identity);
		*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)newObserver);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnCheckObserver_Public_Virtual_Boolean_NetworkIdentity_NetworkConnectionToClient_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 75811, XrefRangeEnd = 75815, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void OnRebuildObservers(NetworkIdentity identity, HashSet<NetworkConnectionToClient> newObservers)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)identity);
		*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)newObservers);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnRebuildObservers_Public_Virtual_Void_NetworkIdentity_HashSet_1_NetworkConnectionToClient_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 75815, XrefRangeEnd = 75819, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void ResetState()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_ResetState_Public_Virtual_Void_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 75819, XrefRangeEnd = 75823, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void FixedUpdate()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_FixedUpdate_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 75823, XrefRangeEnd = 75831, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Update()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Update_Internal_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 75855, RefRangeEnd = 75857, XrefRangeStart = 75831, XrefRangeEnd = 75855, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void RepopulateSpatialHash()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_RepopulateSpatialHash_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 75876, RefRangeEnd = 75877, XrefRangeStart = 75857, XrefRangeEnd = 75876, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void RebuildPartial()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_RebuildPartial_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 75879, RefRangeEnd = 75882, XrefRangeStart = 75877, XrefRangeEnd = 75879, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ForceRefresh()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ForceRefresh_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 75882, XrefRangeEnd = 75883, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe CustomSpatialHashInterestManagement()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CustomSpatialHashInterestManagement>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public CustomSpatialHashInterestManagement(IntPtr pointer)
		: base(pointer)
	{
	}
}
