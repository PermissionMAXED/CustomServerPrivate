using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppMirror;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using UnityEngine;

namespace Il2CppBAPBAP.Entities;

public class SpawnHitboxOnDestroy : NetworkBehaviour
{
	private static readonly System.IntPtr NativeFieldInfoPtr_hitboxPrefab;

	private static readonly System.IntPtr NativeFieldInfoPtr_ownerPlayerId;

	private static readonly System.IntPtr NativeFieldInfoPtr_ownerTeamId;

	private static readonly System.IntPtr NativeFieldInfoPtr_onlyAllies;

	private static readonly System.IntPtr NativeFieldInfoPtr_damageAllowedToOwnerPlayer;

	private static readonly System.IntPtr NativeFieldInfoPtr_otherChar;

	private static readonly System.IntPtr NativeFieldInfoPtr_damage;

	private static readonly System.IntPtr NativeFieldInfoPtr_dpsDmgPerTimeRate;

	private static readonly System.IntPtr NativeFieldInfoPtr_damageToPlayersMultiplier;

	private static readonly System.IntPtr NativeFieldInfoPtr_isCriticalDamage;

	private static readonly System.IntPtr NativeFieldInfoPtr_stayOnOwnerDestroyed;

	private static readonly System.IntPtr NativeFieldInfoPtr_destroyOnCharHit;

	private static readonly System.IntPtr NativeFieldInfoPtr_destroyOnStaticCollision;

	private static readonly System.IntPtr NativeFieldInfoPtr_doTtl;

	private static readonly System.IntPtr NativeFieldInfoPtr_ttl;

	private static readonly System.IntPtr NativeFieldInfoPtr_speed;

	private static readonly System.IntPtr NativeFieldInfoPtr_statusEffects;

	private static readonly System.IntPtr NativeFieldInfoPtr_radius;

	private static readonly System.IntPtr NativeFieldInfoPtr_targetScale;

	private static readonly System.IntPtr NativeFieldInfoPtr_expandDuration;

	private static readonly System.IntPtr NativeFieldInfoPtr_alwaysHitInteractables;

	private static readonly System.IntPtr NativeFieldInfoPtr_directional;

	private static readonly System.IntPtr NativeFieldInfoPtr_counterable;

	private static readonly System.IntPtr NativeFieldInfoPtr_secondaryHitbox;

	private static readonly System.IntPtr NativeFieldInfoPtr_checkForSuccessfulHit;

	private static readonly System.IntPtr NativeFieldInfoPtr_OnSpawnAction;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnStopServer_Public_Virtual_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SpawnHitbox_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Weaved_Public_Virtual_Boolean_0;

	public unsafe GameObject hitboxPrefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_hitboxPrefab);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_hitboxPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe int ownerPlayerId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ownerPlayerId);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ownerPlayerId)) = num;
		}
	}

	public unsafe int ownerTeamId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ownerTeamId);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ownerTeamId)) = num;
		}
	}

	public unsafe bool onlyAllies
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_onlyAllies);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_onlyAllies)) = flag;
		}
	}

	public unsafe bool damageAllowedToOwnerPlayer
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_damageAllowedToOwnerPlayer);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_damageAllowedToOwnerPlayer)) = flag;
		}
	}

	public unsafe GameObject otherChar
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_otherChar);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_otherChar)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe int damage
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_damage);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_damage)) = num;
		}
	}

	public unsafe float dpsDmgPerTimeRate
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dpsDmgPerTimeRate);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dpsDmgPerTimeRate)) = num;
		}
	}

	public unsafe float damageToPlayersMultiplier
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_damageToPlayersMultiplier);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_damageToPlayersMultiplier)) = num;
		}
	}

	public unsafe bool isCriticalDamage
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isCriticalDamage);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isCriticalDamage)) = flag;
		}
	}

	public unsafe bool stayOnOwnerDestroyed
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_stayOnOwnerDestroyed);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_stayOnOwnerDestroyed)) = flag;
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

	public unsafe bool doTtl
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_doTtl);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_doTtl)) = flag;
		}
	}

	public unsafe float ttl
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ttl);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ttl)) = num;
		}
	}

	public unsafe float speed
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_speed);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_speed)) = num;
		}
	}

	public unsafe List<StatusEffectInfo> statusEffects
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_statusEffects);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<StatusEffectInfo>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_statusEffects)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
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

	public unsafe float targetScale
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_targetScale);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_targetScale)) = num;
		}
	}

	public unsafe float expandDuration
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_expandDuration);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_expandDuration)) = num;
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

	public unsafe bool secondaryHitbox
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_secondaryHitbox);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_secondaryHitbox)) = flag;
		}
	}

	public unsafe bool checkForSuccessfulHit
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_checkForSuccessfulHit);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_checkForSuccessfulHit)) = flag;
		}
	}

	public unsafe Il2CppSystem.Action<HitboxBase> OnSpawnAction
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_OnSpawnAction);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action<HitboxBase>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_OnSpawnAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
		}
	}

	static SpawnHitboxOnDestroy()
	{
		Il2CppClassPointerStore<SpawnHitboxOnDestroy>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Entities", "SpawnHitboxOnDestroy");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<SpawnHitboxOnDestroy>.NativeClassPtr);
		NativeFieldInfoPtr_hitboxPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SpawnHitboxOnDestroy>.NativeClassPtr, "hitboxPrefab");
		NativeFieldInfoPtr_ownerPlayerId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SpawnHitboxOnDestroy>.NativeClassPtr, "ownerPlayerId");
		NativeFieldInfoPtr_ownerTeamId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SpawnHitboxOnDestroy>.NativeClassPtr, "ownerTeamId");
		NativeFieldInfoPtr_onlyAllies = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SpawnHitboxOnDestroy>.NativeClassPtr, "onlyAllies");
		NativeFieldInfoPtr_damageAllowedToOwnerPlayer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SpawnHitboxOnDestroy>.NativeClassPtr, "damageAllowedToOwnerPlayer");
		NativeFieldInfoPtr_otherChar = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SpawnHitboxOnDestroy>.NativeClassPtr, "otherChar");
		NativeFieldInfoPtr_damage = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SpawnHitboxOnDestroy>.NativeClassPtr, "damage");
		NativeFieldInfoPtr_dpsDmgPerTimeRate = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SpawnHitboxOnDestroy>.NativeClassPtr, "dpsDmgPerTimeRate");
		NativeFieldInfoPtr_damageToPlayersMultiplier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SpawnHitboxOnDestroy>.NativeClassPtr, "damageToPlayersMultiplier");
		NativeFieldInfoPtr_isCriticalDamage = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SpawnHitboxOnDestroy>.NativeClassPtr, "isCriticalDamage");
		NativeFieldInfoPtr_stayOnOwnerDestroyed = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SpawnHitboxOnDestroy>.NativeClassPtr, "stayOnOwnerDestroyed");
		NativeFieldInfoPtr_destroyOnCharHit = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SpawnHitboxOnDestroy>.NativeClassPtr, "destroyOnCharHit");
		NativeFieldInfoPtr_destroyOnStaticCollision = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SpawnHitboxOnDestroy>.NativeClassPtr, "destroyOnStaticCollision");
		NativeFieldInfoPtr_doTtl = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SpawnHitboxOnDestroy>.NativeClassPtr, "doTtl");
		NativeFieldInfoPtr_ttl = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SpawnHitboxOnDestroy>.NativeClassPtr, "ttl");
		NativeFieldInfoPtr_speed = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SpawnHitboxOnDestroy>.NativeClassPtr, "speed");
		NativeFieldInfoPtr_statusEffects = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SpawnHitboxOnDestroy>.NativeClassPtr, "statusEffects");
		NativeFieldInfoPtr_radius = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SpawnHitboxOnDestroy>.NativeClassPtr, "radius");
		NativeFieldInfoPtr_targetScale = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SpawnHitboxOnDestroy>.NativeClassPtr, "targetScale");
		NativeFieldInfoPtr_expandDuration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SpawnHitboxOnDestroy>.NativeClassPtr, "expandDuration");
		NativeFieldInfoPtr_alwaysHitInteractables = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SpawnHitboxOnDestroy>.NativeClassPtr, "alwaysHitInteractables");
		NativeFieldInfoPtr_directional = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SpawnHitboxOnDestroy>.NativeClassPtr, "directional");
		NativeFieldInfoPtr_counterable = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SpawnHitboxOnDestroy>.NativeClassPtr, "counterable");
		NativeFieldInfoPtr_secondaryHitbox = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SpawnHitboxOnDestroy>.NativeClassPtr, "secondaryHitbox");
		NativeFieldInfoPtr_checkForSuccessfulHit = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SpawnHitboxOnDestroy>.NativeClassPtr, "checkForSuccessfulHit");
		NativeFieldInfoPtr_OnSpawnAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SpawnHitboxOnDestroy>.NativeClassPtr, "OnSpawnAction");
		NativeMethodInfoPtr_OnStopServer_Public_Virtual_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SpawnHitboxOnDestroy>.NativeClassPtr, 100679309);
		NativeMethodInfoPtr_SpawnHitbox_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SpawnHitboxOnDestroy>.NativeClassPtr, 100679310);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SpawnHitboxOnDestroy>.NativeClassPtr, 100679311);
		NativeMethodInfoPtr_Weaved_Public_Virtual_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SpawnHitboxOnDestroy>.NativeClassPtr, 100679312);
	}

	[CallerCount(0)]
	public unsafe override void OnStopServer()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnStopServer_Public_Virtual_Void_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 187517, RefRangeEnd = 187518, XrefRangeStart = 187458, XrefRangeEnd = 187517, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SpawnHitbox()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SpawnHitbox_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 187518, XrefRangeEnd = 187523, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe SpawnHitboxOnDestroy()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<SpawnHitboxOnDestroy>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(24)]
	[CachedScanResults(RefRangeStart = 28750, RefRangeEnd = 28774, XrefRangeStart = 28750, XrefRangeEnd = 28774, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override bool Weaved()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_Weaved_Public_Virtual_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	public SpawnHitboxOnDestroy(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
