using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Local;
using Il2CppBAPBAP.Network;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppMirror;
using Il2CppSystem.Collections.Generic;
using Il2CppSystem.Text;
using UnityEngine;

namespace Il2CppBAPBAP.Entities;

public class RageAbility : Ability
{
	public class CustomRageStartSubroutine : SimulationSubroutine
	{
		private static readonly IntPtr NativeFieldInfoPtr_ability;

		private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_RageAbility_0;

		private static readonly IntPtr NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0;

		public unsafe RageAbility ability
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ability);
				IntPtr intPtr = *(IntPtr*)num;
				return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<RageAbility>(intPtr) : null;
			}
			set
			{
				IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ability)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)rageAbility));
			}
		}

		static CustomRageStartSubroutine()
		{
			Il2CppClassPointerStore<CustomRageStartSubroutine>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, "CustomRageStartSubroutine");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CustomRageStartSubroutine>.NativeClassPtr);
			NativeFieldInfoPtr_ability = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomRageStartSubroutine>.NativeClassPtr, "ability");
			NativeMethodInfoPtr__ctor_Public_Void_RageAbility_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomRageStartSubroutine>.NativeClassPtr, 100673457);
			NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomRageStartSubroutine>.NativeClassPtr, 100673458);
		}

		[CallerCount(534)]
		[CachedScanResults(RefRangeStart = 124041, RefRangeEnd = 124575, XrefRangeStart = 124041, XrefRangeEnd = 124575, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe CustomRageStartSubroutine(RageAbility _ability)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CustomRageStartSubroutine>.NativeClassPtr))
		{
			IntPtr* ptr = stackalloc IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_ability);
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_RageAbility_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 130076, XrefRangeEnd = 130103, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = stackalloc IntPtr[3];
			*ptr = (nint)(&fixedDt);
			*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cmd);
			*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = &isResim;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public CustomRageStartSubroutine(IntPtr pointer)
			: base(pointer)
		{
		}
	}

	public class CustomCastStartSubroutine : SimulationSubroutine
	{
		private static readonly IntPtr NativeFieldInfoPtr_ability;

		private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_RageAbility_0;

		private static readonly IntPtr NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0;

		public unsafe RageAbility ability
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ability);
				IntPtr intPtr = *(IntPtr*)num;
				return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<RageAbility>(intPtr) : null;
			}
			set
			{
				IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ability)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)rageAbility));
			}
		}

		static CustomCastStartSubroutine()
		{
			Il2CppClassPointerStore<CustomCastStartSubroutine>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, "CustomCastStartSubroutine");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CustomCastStartSubroutine>.NativeClassPtr);
			NativeFieldInfoPtr_ability = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomCastStartSubroutine>.NativeClassPtr, "ability");
			NativeMethodInfoPtr__ctor_Public_Void_RageAbility_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomCastStartSubroutine>.NativeClassPtr, 100673459);
			NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomCastStartSubroutine>.NativeClassPtr, 100673460);
		}

		[CallerCount(534)]
		[CachedScanResults(RefRangeStart = 124041, RefRangeEnd = 124575, XrefRangeStart = 124041, XrefRangeEnd = 124575, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe CustomCastStartSubroutine(RageAbility _ability)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CustomCastStartSubroutine>.NativeClassPtr))
		{
			IntPtr* ptr = stackalloc IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_ability);
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_RageAbility_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(17738)]
		[CachedScanResults(RefRangeStart = 5595, RefRangeEnd = 23333, XrefRangeStart = 5595, XrefRangeEnd = 23333, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = stackalloc IntPtr[3];
			*ptr = (nint)(&fixedDt);
			*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cmd);
			*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = &isResim;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public CustomCastStartSubroutine(IntPtr pointer)
			: base(pointer)
		{
		}
	}

	public class CustomRageEndSubroutine : SimulationSubroutine
	{
		private static readonly IntPtr NativeFieldInfoPtr_ability;

		private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_RageAbility_0;

		private static readonly IntPtr NativeMethodInfoPtr_OnExit_Public_Virtual_Void_Single_Command_Boolean_0;

		public unsafe RageAbility ability
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ability);
				IntPtr intPtr = *(IntPtr*)num;
				return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<RageAbility>(intPtr) : null;
			}
			set
			{
				IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ability)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)rageAbility));
			}
		}

		static CustomRageEndSubroutine()
		{
			Il2CppClassPointerStore<CustomRageEndSubroutine>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, "CustomRageEndSubroutine");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CustomRageEndSubroutine>.NativeClassPtr);
			NativeFieldInfoPtr_ability = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomRageEndSubroutine>.NativeClassPtr, "ability");
			NativeMethodInfoPtr__ctor_Public_Void_RageAbility_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomRageEndSubroutine>.NativeClassPtr, 100673461);
			NativeMethodInfoPtr_OnExit_Public_Virtual_Void_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomRageEndSubroutine>.NativeClassPtr, 100673462);
		}

		[CallerCount(534)]
		[CachedScanResults(RefRangeStart = 124041, RefRangeEnd = 124575, XrefRangeStart = 124041, XrefRangeEnd = 124575, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe CustomRageEndSubroutine(RageAbility _ability)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CustomRageEndSubroutine>.NativeClassPtr))
		{
			IntPtr* ptr = stackalloc IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_ability);
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_RageAbility_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 130103, XrefRangeEnd = 130111, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe override void OnExit(float fixedDt, Command cmd, bool isResim)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = stackalloc IntPtr[3];
			*ptr = (nint)(&fixedDt);
			*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cmd);
			*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = &isResim;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnExit_Public_Virtual_Void_Single_Command_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public CustomRageEndSubroutine(IntPtr pointer)
			: base(pointer)
		{
		}
	}

	private static readonly IntPtr NativeFieldInfoPtr_rageSpeedIncrease;

	private static readonly IntPtr NativeFieldInfoPtr_rageDmgPercentIncrease;

	private static readonly IntPtr NativeFieldInfoPtr_rageHpRegenPercent;

	private static readonly IntPtr NativeFieldInfoPtr_rageDmgReduction;

	private static readonly IntPtr NativeFieldInfoPtr_castMotionLockType;

	private static readonly IntPtr NativeFieldInfoPtr_castRotationLockType;

	private static readonly IntPtr NativeFieldInfoPtr_applyAtkSpeedMultiplier;

	private static readonly IntPtr NativeFieldInfoPtr_applyCooldownMultiplier;

	private static readonly IntPtr NativeFieldInfoPtr_inputType;

	private static readonly IntPtr NativeFieldInfoPtr_spellPushHitbox;

	private static readonly IntPtr NativeFieldInfoPtr_pushRadius;

	private static readonly IntPtr NativeFieldInfoPtr_ttl;

	private static readonly IntPtr NativeFieldInfoPtr_statusEffects;

	private static readonly IntPtr NativeFieldInfoPtr_castingTime;

	private static readonly IntPtr NativeFieldInfoPtr_rageTime;

	private static readonly IntPtr NativeFieldInfoPtr_recoveryTime;

	private static readonly IntPtr NativeFieldInfoPtr_baseCooldownTime;

	private static readonly IntPtr NativeFieldInfoPtr_startCooldownTime;

	private static readonly IntPtr NativeFieldInfoPtr_camShakeTrauma;

	private static readonly IntPtr NativeFieldInfoPtr_rageMaterialTintColor;

	private static readonly IntPtr NativeFieldInfoPtr_vfxCastPrefab;

	private static readonly IntPtr NativeFieldInfoPtr_vfxRageLoopPrefab;

	private static readonly IntPtr NativeFieldInfoPtr_vfxRageLoopAttachTransform;

	private static readonly IntPtr NativeFieldInfoPtr_sfxStart;

	private static readonly IntPtr NativeFieldInfoPtr_sfxEnd;

	private static readonly IntPtr NativeFieldInfoPtr_sfxRageLoopData;

	private static readonly IntPtr NativeFieldInfoPtr_animLayer;

	private static readonly IntPtr NativeFieldInfoPtr_isRaged;

	private static readonly IntPtr NativeFieldInfoPtr_hpRegenAmount;

	private static readonly IntPtr NativeMethodInfoPtr_PreAwake_Public_Virtual_Void_EntityManager_0;

	private static readonly IntPtr NativeMethodInfoPtr_Shoot_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetTooltipDescription_Public_Virtual_String_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetTooltipExpandedDescription_Public_Virtual_String_0;

	private static readonly IntPtr NativeMethodInfoPtr_ClSetRageEnabled_Private_Void_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnNetDeserialize_Public_Virtual_Void_NetworkReader_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnNetSerialize_Public_Virtual_Void_NetworkWriter_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnNetDebugCompare_Public_Virtual_Boolean_NetworkReader_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnNetDebugLog_Public_Virtual_Void_StringBuilder_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_Weaved_Public_Virtual_Boolean_0;

	public unsafe float rageSpeedIncrease
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rageSpeedIncrease);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rageSpeedIncrease)) = num;
		}
	}

	public unsafe float rageDmgPercentIncrease
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rageDmgPercentIncrease);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rageDmgPercentIncrease)) = num;
		}
	}

	public unsafe float rageHpRegenPercent
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rageHpRegenPercent);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rageHpRegenPercent)) = num;
		}
	}

	public unsafe float rageDmgReduction
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rageDmgReduction);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rageDmgReduction)) = num;
		}
	}

	public unsafe MotionLockType castMotionLockType
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castMotionLockType);
			return *(MotionLockType*)num;
		}
		set
		{
			*(MotionLockType*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castMotionLockType)) = motionLockType;
		}
	}

	public unsafe RotationLockType castRotationLockType
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castRotationLockType);
			return *(RotationLockType*)num;
		}
		set
		{
			*(RotationLockType*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castRotationLockType)) = rotationLockType;
		}
	}

	public unsafe bool applyAtkSpeedMultiplier
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_applyAtkSpeedMultiplier);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_applyAtkSpeedMultiplier)) = flag;
		}
	}

	public unsafe bool applyCooldownMultiplier
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_applyCooldownMultiplier);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_applyCooldownMultiplier)) = flag;
		}
	}

	public unsafe InputType inputType
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inputType);
			return *(InputType*)num;
		}
		set
		{
			*(InputType*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inputType)) = inputType;
		}
	}

	public unsafe GameObject spellPushHitbox
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spellPushHitbox);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spellPushHitbox)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe float pushRadius
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pushRadius);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pushRadius)) = num;
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

	public unsafe float castingTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castingTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castingTime)) = num;
		}
	}

	public unsafe float rageTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rageTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rageTime)) = num;
		}
	}

	public unsafe float recoveryTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_recoveryTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_recoveryTime)) = num;
		}
	}

	public unsafe float baseCooldownTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_baseCooldownTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_baseCooldownTime)) = num;
		}
	}

	public unsafe float startCooldownTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_startCooldownTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_startCooldownTime)) = num;
		}
	}

	public unsafe float camShakeTrauma
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_camShakeTrauma);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_camShakeTrauma)) = num;
		}
	}

	public unsafe Color rageMaterialTintColor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rageMaterialTintColor);
			return *(Color*)num;
		}
		set
		{
			*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rageMaterialTintColor)) = color;
		}
	}

	public unsafe GameObject vfxCastPrefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vfxCastPrefab);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vfxCastPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe GameObject vfxRageLoopPrefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vfxRageLoopPrefab);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vfxRageLoopPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe Transform vfxRageLoopAttachTransform
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vfxRageLoopAttachTransform);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Transform>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vfxRageLoopAttachTransform)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)transform));
		}
	}

	public unsafe AudioClipData sfxStart
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sfxStart);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<AudioClipData>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sfxStart)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)audioClipData));
		}
	}

	public unsafe AudioClipData sfxEnd
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sfxEnd);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<AudioClipData>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sfxEnd)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)audioClipData));
		}
	}

	public unsafe AudioClipData sfxRageLoopData
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sfxRageLoopData);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<AudioClipData>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sfxRageLoopData)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)audioClipData));
		}
	}

	public unsafe AnimLayerIndices animLayer
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_animLayer);
			return *(AnimLayerIndices*)num;
		}
		set
		{
			*(AnimLayerIndices*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_animLayer)) = animLayerIndices;
		}
	}

	public unsafe bool isRaged
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isRaged);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isRaged)) = flag;
		}
	}

	public unsafe int hpRegenAmount
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_hpRegenAmount);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_hpRegenAmount)) = num;
		}
	}

	static RageAbility()
	{
		Il2CppClassPointerStore<RageAbility>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Entities", "RageAbility");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<RageAbility>.NativeClassPtr);
		NativeFieldInfoPtr_rageSpeedIncrease = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, "rageSpeedIncrease");
		NativeFieldInfoPtr_rageDmgPercentIncrease = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, "rageDmgPercentIncrease");
		NativeFieldInfoPtr_rageHpRegenPercent = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, "rageHpRegenPercent");
		NativeFieldInfoPtr_rageDmgReduction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, "rageDmgReduction");
		NativeFieldInfoPtr_castMotionLockType = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, "castMotionLockType");
		NativeFieldInfoPtr_castRotationLockType = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, "castRotationLockType");
		NativeFieldInfoPtr_applyAtkSpeedMultiplier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, "applyAtkSpeedMultiplier");
		NativeFieldInfoPtr_applyCooldownMultiplier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, "applyCooldownMultiplier");
		NativeFieldInfoPtr_inputType = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, "inputType");
		NativeFieldInfoPtr_spellPushHitbox = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, "spellPushHitbox");
		NativeFieldInfoPtr_pushRadius = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, "pushRadius");
		NativeFieldInfoPtr_ttl = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, "ttl");
		NativeFieldInfoPtr_statusEffects = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, "statusEffects");
		NativeFieldInfoPtr_castingTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, "castingTime");
		NativeFieldInfoPtr_rageTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, "rageTime");
		NativeFieldInfoPtr_recoveryTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, "recoveryTime");
		NativeFieldInfoPtr_baseCooldownTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, "baseCooldownTime");
		NativeFieldInfoPtr_startCooldownTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, "startCooldownTime");
		NativeFieldInfoPtr_camShakeTrauma = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, "camShakeTrauma");
		NativeFieldInfoPtr_rageMaterialTintColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, "rageMaterialTintColor");
		NativeFieldInfoPtr_vfxCastPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, "vfxCastPrefab");
		NativeFieldInfoPtr_vfxRageLoopPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, "vfxRageLoopPrefab");
		NativeFieldInfoPtr_vfxRageLoopAttachTransform = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, "vfxRageLoopAttachTransform");
		NativeFieldInfoPtr_sfxStart = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, "sfxStart");
		NativeFieldInfoPtr_sfxEnd = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, "sfxEnd");
		NativeFieldInfoPtr_sfxRageLoopData = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, "sfxRageLoopData");
		NativeFieldInfoPtr_animLayer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, "animLayer");
		NativeFieldInfoPtr_isRaged = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, "isRaged");
		NativeFieldInfoPtr_hpRegenAmount = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, "hpRegenAmount");
		NativeMethodInfoPtr_PreAwake_Public_Virtual_Void_EntityManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, 100673446);
		NativeMethodInfoPtr_Shoot_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, 100673447);
		NativeMethodInfoPtr_GetTooltipDescription_Public_Virtual_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, 100673448);
		NativeMethodInfoPtr_GetTooltipExpandedDescription_Public_Virtual_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, 100673449);
		NativeMethodInfoPtr_ClSetRageEnabled_Private_Void_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, 100673450);
		NativeMethodInfoPtr_OnNetDeserialize_Public_Virtual_Void_NetworkReader_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, 100673451);
		NativeMethodInfoPtr_OnNetSerialize_Public_Virtual_Void_NetworkWriter_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, 100673452);
		NativeMethodInfoPtr_OnNetDebugCompare_Public_Virtual_Boolean_NetworkReader_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, 100673453);
		NativeMethodInfoPtr_OnNetDebugLog_Public_Virtual_Void_StringBuilder_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, 100673454);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, 100673455);
		NativeMethodInfoPtr_Weaved_Public_Virtual_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<RageAbility>.NativeClassPtr, 100673456);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 130111, XrefRangeEnd = 130318, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void PreAwake(EntityManager _entityManager)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_entityManager);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_PreAwake_Public_Virtual_Void_EntityManager_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 130340, RefRangeEnd = 130341, XrefRangeStart = 130318, XrefRangeEnd = 130340, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Shoot()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Shoot_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 130341, XrefRangeEnd = 130358, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override string GetTooltipDescription()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_GetTooltipDescription_Public_Virtual_String_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 130358, XrefRangeEnd = 130362, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override string GetTooltipExpandedDescription()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_GetTooltipExpandedDescription_Public_Virtual_String_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 130366, RefRangeEnd = 130367, XrefRangeStart = 130362, XrefRangeEnd = 130366, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ClSetRageEnabled(bool isEnabled)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&isEnabled);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ClSetRageEnabled_Private_Void_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 130367, XrefRangeEnd = 130370, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void OnNetDeserialize(NetworkReader netReader)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)netReader);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnNetDeserialize_Public_Virtual_Void_NetworkReader_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 130370, XrefRangeEnd = 130372, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void OnNetSerialize(NetworkWriter netWriter)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)netWriter);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnNetSerialize_Public_Virtual_Void_NetworkWriter_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 130372, XrefRangeEnd = 130373, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override bool OnNetDebugCompare(NetworkReader netReader)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)netReader);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnNetDebugCompare_Public_Virtual_Boolean_NetworkReader_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 130373, XrefRangeEnd = 130379, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void OnNetDebugLog(StringBuilder sb)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)sb);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnNetDebugLog_Public_Virtual_Void_StringBuilder_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 130379, XrefRangeEnd = 130384, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe RageAbility()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<RageAbility>.NativeClassPtr))
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

	public RageAbility(IntPtr pointer)
		: base(pointer)
	{
	}
}
