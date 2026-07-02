using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using UnityEngine;

namespace Il2CppBAPBAP.Entities;

public class TriggerPhysicsForceAreaHitbox : MonoBehaviour
{
	private static readonly IntPtr NativeFieldInfoPtr_hitboxBase;

	private static readonly IntPtr NativeFieldInfoPtr_applyOnHitEntities;

	private static readonly IntPtr NativeFieldInfoPtr_checkForStaticCollision;

	private static readonly IntPtr NativeFieldInfoPtr_forceIntensity;

	private static readonly IntPtr NativeFieldInfoPtr_forceDecel;

	private static readonly IntPtr NativeFieldInfoPtr_obstaclesMask;

	private static readonly IntPtr NativeMethodInfoPtr_Awake_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnTriggerEnter_Private_Void_Collider_0;

	private static readonly IntPtr NativeMethodInfoPtr_ApplyForce_Private_Void_Collider_0;

	private static readonly IntPtr NativeMethodInfoPtr_ApplyForceEntity_Private_Void_EntityManager_HitboxBase_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetForceVel_Private_Vector3_Transform_0;

	private static readonly IntPtr NativeMethodInfoPtr_IsLineOfSightBlocked_Private_Boolean_Vector3_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe HitboxBase hitboxBase
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_hitboxBase);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<HitboxBase>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_hitboxBase)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)hitboxBase));
		}
	}

	public unsafe bool applyOnHitEntities
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_applyOnHitEntities);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_applyOnHitEntities)) = flag;
		}
	}

	public unsafe bool checkForStaticCollision
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_checkForStaticCollision);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_checkForStaticCollision)) = flag;
		}
	}

	public unsafe float forceIntensity
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_forceIntensity);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_forceIntensity)) = num;
		}
	}

	public unsafe float forceDecel
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_forceDecel);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_forceDecel)) = num;
		}
	}

	public unsafe int obstaclesMask
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_obstaclesMask);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_obstaclesMask)) = num;
		}
	}

	static TriggerPhysicsForceAreaHitbox()
	{
		Il2CppClassPointerStore<TriggerPhysicsForceAreaHitbox>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Entities", "TriggerPhysicsForceAreaHitbox");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<TriggerPhysicsForceAreaHitbox>.NativeClassPtr);
		NativeFieldInfoPtr_hitboxBase = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TriggerPhysicsForceAreaHitbox>.NativeClassPtr, "hitboxBase");
		NativeFieldInfoPtr_applyOnHitEntities = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TriggerPhysicsForceAreaHitbox>.NativeClassPtr, "applyOnHitEntities");
		NativeFieldInfoPtr_checkForStaticCollision = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TriggerPhysicsForceAreaHitbox>.NativeClassPtr, "checkForStaticCollision");
		NativeFieldInfoPtr_forceIntensity = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TriggerPhysicsForceAreaHitbox>.NativeClassPtr, "forceIntensity");
		NativeFieldInfoPtr_forceDecel = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TriggerPhysicsForceAreaHitbox>.NativeClassPtr, "forceDecel");
		NativeFieldInfoPtr_obstaclesMask = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TriggerPhysicsForceAreaHitbox>.NativeClassPtr, "obstaclesMask");
		NativeMethodInfoPtr_Awake_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TriggerPhysicsForceAreaHitbox>.NativeClassPtr, 100679302);
		NativeMethodInfoPtr_OnTriggerEnter_Private_Void_Collider_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TriggerPhysicsForceAreaHitbox>.NativeClassPtr, 100679303);
		NativeMethodInfoPtr_ApplyForce_Private_Void_Collider_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TriggerPhysicsForceAreaHitbox>.NativeClassPtr, 100679304);
		NativeMethodInfoPtr_ApplyForceEntity_Private_Void_EntityManager_HitboxBase_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TriggerPhysicsForceAreaHitbox>.NativeClassPtr, 100679305);
		NativeMethodInfoPtr_GetForceVel_Private_Vector3_Transform_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TriggerPhysicsForceAreaHitbox>.NativeClassPtr, 100679306);
		NativeMethodInfoPtr_IsLineOfSightBlocked_Private_Boolean_Vector3_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TriggerPhysicsForceAreaHitbox>.NativeClassPtr, 100679307);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TriggerPhysicsForceAreaHitbox>.NativeClassPtr, 100679308);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 187395, XrefRangeEnd = 187410, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Awake()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Awake_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 187410, XrefRangeEnd = 187414, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnTriggerEnter(Collider col)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)col);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnTriggerEnter_Private_Void_Collider_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 187431, RefRangeEnd = 187432, XrefRangeStart = 187414, XrefRangeEnd = 187431, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ApplyForce(Collider col)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)col);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ApplyForce_Private_Void_Collider_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 187432, XrefRangeEnd = 187440, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ApplyForceEntity(EntityManager entity, HitboxBase hitboxBase)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entity);
		*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)hitboxBase);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ApplyForceEntity_Private_Void_EntityManager_HitboxBase_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 187450, RefRangeEnd = 187452, XrefRangeStart = 187440, XrefRangeEnd = 187450, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Vector3 GetForceVel(Transform _transform)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_transform);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetForceVel_Private_Vector3_Transform_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(Vector3*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 187452, XrefRangeEnd = 187457, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe bool IsLineOfSightBlocked(Vector3 targetPosition)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&targetPosition);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_IsLineOfSightBlocked_Private_Boolean_Vector3_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 187457, XrefRangeEnd = 187458, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe TriggerPhysicsForceAreaHitbox()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<TriggerPhysicsForceAreaHitbox>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public TriggerPhysicsForceAreaHitbox(IntPtr pointer)
		: base(pointer)
	{
	}
}
