using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem.Collections.Generic;
using UnityEngine;

namespace Il2CppBAPBAP.Entities;

public class EntityActivateProjectile : EntityActivateBase
{
	private static readonly IntPtr NativeFieldInfoPtr_projectileHitboxPrefab;

	private static readonly IntPtr NativeFieldInfoPtr_firingPoint;

	private static readonly IntPtr NativeFieldInfoPtr_projDamage;

	private static readonly IntPtr NativeFieldInfoPtr_percentHpDamage;

	private static readonly IntPtr NativeFieldInfoPtr_projSpeed;

	private static readonly IntPtr NativeFieldInfoPtr_projTTL;

	private static readonly IntPtr NativeFieldInfoPtr_projBullets;

	private static readonly IntPtr NativeFieldInfoPtr_projAngleSpread;

	private static readonly IntPtr NativeFieldInfoPtr_useSpeedCurve;

	private static readonly IntPtr NativeFieldInfoPtr_speedCurve;

	private static readonly IntPtr NativeFieldInfoPtr_statusEffects;

	private static readonly IntPtr NativeFieldInfoPtr_directional;

	private static readonly IntPtr NativeFieldInfoPtr_destroyOnCharHit;

	private static readonly IntPtr NativeFieldInfoPtr_destroyOnStaticCollision;

	private static readonly IntPtr NativeFieldInfoPtr_playImpactOnChar;

	private static readonly IntPtr NativeFieldInfoPtr_allowLifesteal;

	private static readonly IntPtr NativeFieldInfoPtr_allowThorns;

	private static readonly IntPtr NativeFieldInfoPtr_applyDamageHpPercentageToNpcs;

	private static readonly IntPtr NativeFieldInfoPtr_alwaysHitInteractables;

	private static readonly IntPtr NativeFieldInfoPtr_counterable;

	private static readonly IntPtr NativeFieldInfoPtr_collidesWithLowWalls;

	private static readonly IntPtr NativeFieldInfoPtr_onlyHitCharacterOnce;

	private static readonly IntPtr NativeFieldInfoPtr_hittedChars;

	private static readonly IntPtr NativeMethodInfoPtr_Activate_Public_Virtual_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_SpawnProjectile_Private_Void_Single_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnHitSuccess_Private_Void_EntityManager_HitboxBase_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_Weaved_Public_Virtual_Boolean_0;

	public unsafe GameObject projectileHitboxPrefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_projectileHitboxPrefab);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_projectileHitboxPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe Transform firingPoint
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_firingPoint);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Transform>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_firingPoint)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)transform));
		}
	}

	public unsafe int projDamage
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_projDamage);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_projDamage)) = num;
		}
	}

	public unsafe float percentHpDamage
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_percentHpDamage);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_percentHpDamage)) = num;
		}
	}

	public unsafe float projSpeed
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_projSpeed);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_projSpeed)) = num;
		}
	}

	public unsafe float projTTL
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_projTTL);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_projTTL)) = num;
		}
	}

	public unsafe float projBullets
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_projBullets);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_projBullets)) = num;
		}
	}

	public unsafe float projAngleSpread
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_projAngleSpread);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_projAngleSpread)) = num;
		}
	}

	public unsafe bool useSpeedCurve
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_useSpeedCurve);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_useSpeedCurve)) = flag;
		}
	}

	public unsafe AnimationCurve speedCurve
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_speedCurve);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<AnimationCurve>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_speedCurve)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)animationCurve));
		}
	}

	public unsafe List<StatusEffectInfo> statusEffects
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_statusEffects);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<List<StatusEffectInfo>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_statusEffects)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	public unsafe bool directional
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_directional);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_directional)) = flag;
		}
	}

	public unsafe bool destroyOnCharHit
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_destroyOnCharHit);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_destroyOnCharHit)) = flag;
		}
	}

	public unsafe bool destroyOnStaticCollision
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_destroyOnStaticCollision);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_destroyOnStaticCollision)) = flag;
		}
	}

	public unsafe bool playImpactOnChar
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playImpactOnChar);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playImpactOnChar)) = flag;
		}
	}

	public unsafe bool allowLifesteal
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_allowLifesteal);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_allowLifesteal)) = flag;
		}
	}

	public unsafe bool allowThorns
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_allowThorns);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_allowThorns)) = flag;
		}
	}

	public unsafe bool applyDamageHpPercentageToNpcs
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_applyDamageHpPercentageToNpcs);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_applyDamageHpPercentageToNpcs)) = flag;
		}
	}

	public unsafe bool alwaysHitInteractables
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_alwaysHitInteractables);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_alwaysHitInteractables)) = flag;
		}
	}

	public unsafe bool counterable
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_counterable);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_counterable)) = flag;
		}
	}

	public unsafe bool collidesWithLowWalls
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_collidesWithLowWalls);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_collidesWithLowWalls)) = flag;
		}
	}

	public unsafe bool onlyHitCharacterOnce
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_onlyHitCharacterOnce);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_onlyHitCharacterOnce)) = flag;
		}
	}

	public unsafe List<CharHurtbox> hittedChars
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_hittedChars);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<List<CharHurtbox>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_hittedChars)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	static EntityActivateProjectile()
	{
		Il2CppClassPointerStore<EntityActivateProjectile>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Entities", "EntityActivateProjectile");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<EntityActivateProjectile>.NativeClassPtr);
		NativeFieldInfoPtr_projectileHitboxPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityActivateProjectile>.NativeClassPtr, "projectileHitboxPrefab");
		NativeFieldInfoPtr_firingPoint = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityActivateProjectile>.NativeClassPtr, "firingPoint");
		NativeFieldInfoPtr_projDamage = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityActivateProjectile>.NativeClassPtr, "projDamage");
		NativeFieldInfoPtr_percentHpDamage = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityActivateProjectile>.NativeClassPtr, "percentHpDamage");
		NativeFieldInfoPtr_projSpeed = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityActivateProjectile>.NativeClassPtr, "projSpeed");
		NativeFieldInfoPtr_projTTL = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityActivateProjectile>.NativeClassPtr, "projTTL");
		NativeFieldInfoPtr_projBullets = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityActivateProjectile>.NativeClassPtr, "projBullets");
		NativeFieldInfoPtr_projAngleSpread = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityActivateProjectile>.NativeClassPtr, "projAngleSpread");
		NativeFieldInfoPtr_useSpeedCurve = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityActivateProjectile>.NativeClassPtr, "useSpeedCurve");
		NativeFieldInfoPtr_speedCurve = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityActivateProjectile>.NativeClassPtr, "speedCurve");
		NativeFieldInfoPtr_statusEffects = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityActivateProjectile>.NativeClassPtr, "statusEffects");
		NativeFieldInfoPtr_directional = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityActivateProjectile>.NativeClassPtr, "directional");
		NativeFieldInfoPtr_destroyOnCharHit = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityActivateProjectile>.NativeClassPtr, "destroyOnCharHit");
		NativeFieldInfoPtr_destroyOnStaticCollision = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityActivateProjectile>.NativeClassPtr, "destroyOnStaticCollision");
		NativeFieldInfoPtr_playImpactOnChar = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityActivateProjectile>.NativeClassPtr, "playImpactOnChar");
		NativeFieldInfoPtr_allowLifesteal = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityActivateProjectile>.NativeClassPtr, "allowLifesteal");
		NativeFieldInfoPtr_allowThorns = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityActivateProjectile>.NativeClassPtr, "allowThorns");
		NativeFieldInfoPtr_applyDamageHpPercentageToNpcs = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityActivateProjectile>.NativeClassPtr, "applyDamageHpPercentageToNpcs");
		NativeFieldInfoPtr_alwaysHitInteractables = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityActivateProjectile>.NativeClassPtr, "alwaysHitInteractables");
		NativeFieldInfoPtr_counterable = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityActivateProjectile>.NativeClassPtr, "counterable");
		NativeFieldInfoPtr_collidesWithLowWalls = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityActivateProjectile>.NativeClassPtr, "collidesWithLowWalls");
		NativeFieldInfoPtr_onlyHitCharacterOnce = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityActivateProjectile>.NativeClassPtr, "onlyHitCharacterOnce");
		NativeFieldInfoPtr_hittedChars = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<EntityActivateProjectile>.NativeClassPtr, "hittedChars");
		NativeMethodInfoPtr_Activate_Public_Virtual_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EntityActivateProjectile>.NativeClassPtr, 100681794);
		NativeMethodInfoPtr_SpawnProjectile_Private_Void_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EntityActivateProjectile>.NativeClassPtr, 100681795);
		NativeMethodInfoPtr_OnHitSuccess_Private_Void_EntityManager_HitboxBase_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EntityActivateProjectile>.NativeClassPtr, 100681796);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EntityActivateProjectile>.NativeClassPtr, 100681797);
		NativeMethodInfoPtr_Weaved_Public_Virtual_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<EntityActivateProjectile>.NativeClassPtr, 100681798);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 206975, XrefRangeEnd = 206976, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void Activate()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_Activate_Public_Virtual_Void_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 207027, RefRangeEnd = 207028, XrefRangeStart = 206976, XrefRangeEnd = 207027, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SpawnProjectile(float angle)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&angle);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SpawnProjectile_Private_Void_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 207028, XrefRangeEnd = 207045, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnHitSuccess(EntityManager entity, HitboxBase hitbox)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)entity);
		*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)hitbox);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnHitSuccess_Private_Void_EntityManager_HitboxBase_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 207045, XrefRangeEnd = 207050, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe EntityActivateProjectile()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<EntityActivateProjectile>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(24)]
	[CachedScanResults(RefRangeStart = 28750, RefRangeEnd = 28774, XrefRangeStart = 28750, XrefRangeEnd = 28774, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override bool Weaved()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_Weaved_Public_Virtual_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	public EntityActivateProjectile(IntPtr pointer)
		: base(pointer)
	{
	}
}
