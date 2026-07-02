using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem.Collections.Generic;
using UnityEngine;

namespace Il2CppBAPBAP.Local;

public class SelectableResponseForce : SelectableResponse
{
	private static readonly IntPtr NativeFieldInfoPtr_multiplier;

	private static readonly IntPtr NativeFieldInfoPtr_upwardsModifier;

	private static readonly IntPtr NativeFieldInfoPtr_radius;

	private static readonly IntPtr NativeFieldInfoPtr_torqueMultiplier;

	private static readonly IntPtr NativeFieldInfoPtr_torqueRange;

	private static readonly IntPtr NativeFieldInfoPtr_hoverAlignmentSpeed;

	private static readonly IntPtr NativeFieldInfoPtr_resetRange;

	private static readonly IntPtr NativeFieldInfoPtr_initialForwards;

	private static readonly IntPtr NativeFieldInfoPtr_initialPositions;

	private static readonly IntPtr NativeFieldInfoPtr_lastClick;

	private static readonly IntPtr NativeFieldInfoPtr_rigidbodies;

	private static readonly IntPtr NativeMethodInfoPtr_Initialize_Public_Virtual_Void_ISelectable_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnSelect_Public_Virtual_Void_ISelectable_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnHoverUpdate_Public_Virtual_Void_ISelectable_Single_0;

	private static readonly IntPtr NativeMethodInfoPtr_GeneralUpdate_Public_Virtual_Void_ISelectable_Single_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe float multiplier
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_multiplier);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_multiplier)) = num;
		}
	}

	public unsafe float upwardsModifier
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_upwardsModifier);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_upwardsModifier)) = num;
		}
	}

	public unsafe float radius
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_radius);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_radius)) = num;
		}
	}

	public unsafe float torqueMultiplier
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_torqueMultiplier);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_torqueMultiplier)) = num;
		}
	}

	public unsafe Vector3 torqueRange
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_torqueRange);
			return *(Vector3*)num;
		}
		set
		{
			*(Vector3*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_torqueRange)) = vector;
		}
	}

	public unsafe float hoverAlignmentSpeed
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_hoverAlignmentSpeed);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_hoverAlignmentSpeed)) = num;
		}
	}

	public unsafe float resetRange
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_resetRange);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_resetRange)) = num;
		}
	}

	public unsafe Dictionary<GameObject, Vector3> initialForwards
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_initialForwards);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Dictionary<GameObject, Vector3>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_initialForwards)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)dictionary));
		}
	}

	public unsafe Dictionary<GameObject, Vector3> initialPositions
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_initialPositions);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Dictionary<GameObject, Vector3>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_initialPositions)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)dictionary));
		}
	}

	public unsafe Dictionary<GameObject, float> lastClick
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lastClick);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Dictionary<GameObject, float>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lastClick)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)dictionary));
		}
	}

	public unsafe Dictionary<GameObject, Rigidbody> rigidbodies
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rigidbodies);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Dictionary<GameObject, Rigidbody>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rigidbodies)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)dictionary));
		}
	}

	static SelectableResponseForce()
	{
		Il2CppClassPointerStore<SelectableResponseForce>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Local", "SelectableResponseForce");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<SelectableResponseForce>.NativeClassPtr);
		NativeFieldInfoPtr_multiplier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SelectableResponseForce>.NativeClassPtr, "multiplier");
		NativeFieldInfoPtr_upwardsModifier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SelectableResponseForce>.NativeClassPtr, "upwardsModifier");
		NativeFieldInfoPtr_radius = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SelectableResponseForce>.NativeClassPtr, "radius");
		NativeFieldInfoPtr_torqueMultiplier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SelectableResponseForce>.NativeClassPtr, "torqueMultiplier");
		NativeFieldInfoPtr_torqueRange = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SelectableResponseForce>.NativeClassPtr, "torqueRange");
		NativeFieldInfoPtr_hoverAlignmentSpeed = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SelectableResponseForce>.NativeClassPtr, "hoverAlignmentSpeed");
		NativeFieldInfoPtr_resetRange = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SelectableResponseForce>.NativeClassPtr, "resetRange");
		NativeFieldInfoPtr_initialForwards = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SelectableResponseForce>.NativeClassPtr, "initialForwards");
		NativeFieldInfoPtr_initialPositions = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SelectableResponseForce>.NativeClassPtr, "initialPositions");
		NativeFieldInfoPtr_lastClick = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SelectableResponseForce>.NativeClassPtr, "lastClick");
		NativeFieldInfoPtr_rigidbodies = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SelectableResponseForce>.NativeClassPtr, "rigidbodies");
		NativeMethodInfoPtr_Initialize_Public_Virtual_Void_ISelectable_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SelectableResponseForce>.NativeClassPtr, 100684748);
		NativeMethodInfoPtr_OnSelect_Public_Virtual_Void_ISelectable_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SelectableResponseForce>.NativeClassPtr, 100684749);
		NativeMethodInfoPtr_OnHoverUpdate_Public_Virtual_Void_ISelectable_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SelectableResponseForce>.NativeClassPtr, 100684750);
		NativeMethodInfoPtr_GeneralUpdate_Public_Virtual_Void_ISelectable_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SelectableResponseForce>.NativeClassPtr, 100684751);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SelectableResponseForce>.NativeClassPtr, 100684752);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 230334, XrefRangeEnd = 230355, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void Initialize(ISelectable selectable)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)selectable);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_Initialize_Public_Virtual_Void_ISelectable_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 230355, XrefRangeEnd = 230384, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void OnSelect(ISelectable selectable)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)selectable);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnSelect_Public_Virtual_Void_ISelectable_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 230384, XrefRangeEnd = 230399, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void OnHoverUpdate(ISelectable selectable, float deltaTime)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)selectable);
		*(float**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &deltaTime;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnHoverUpdate_Public_Virtual_Void_ISelectable_Single_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 230399, XrefRangeEnd = 230434, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void GeneralUpdate(ISelectable selectable, float deltaTime)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)selectable);
		*(float**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &deltaTime;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_GeneralUpdate_Public_Virtual_Void_ISelectable_Single_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 230434, XrefRangeEnd = 230449, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe SelectableResponseForce()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<SelectableResponseForce>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public SelectableResponseForce(IntPtr pointer)
		: base(pointer)
	{
	}
}
