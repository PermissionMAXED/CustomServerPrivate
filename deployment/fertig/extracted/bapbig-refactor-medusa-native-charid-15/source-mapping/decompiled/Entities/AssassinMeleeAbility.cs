using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Local;
using Il2CppBAPBAP.Network;
using Il2CppBAPBAP.Network.EventData;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using UnityEngine;

namespace Il2CppBAPBAP.Entities;

public class AssassinMeleeAbility : Ability
{
	public class CustomVfxSubroutine : SimulationSubroutine
	{
		private static readonly IntPtr NativeFieldInfoPtr_ability;

		private static readonly IntPtr NativeFieldInfoPtr_vfxTarget;

		private static readonly IntPtr NativeFieldInfoPtr_vfxAction;

		private static readonly IntPtr NativeFieldInfoPtr_vfxIdNormal;

		private static readonly IntPtr NativeFieldInfoPtr_vfxIdRed;

		private static readonly IntPtr NativeFieldInfoPtr_netId;

		private static readonly IntPtr NativeFieldInfoPtr_position;

		private static readonly IntPtr NativeFieldInfoPtr_rotation;

		private static readonly IntPtr NativeFieldInfoPtr_attachableId;

		private static readonly IntPtr NativeFieldInfoPtr_rotateDelay;

		private static readonly IntPtr NativeFieldInfoPtr_applyAtkSpeedMultiplier;

		private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_AssassinMeleeAbility_VfxEventAction_VfxTarget_GameObject_GameObject_Vector3_Quaternion_Byte_Single_Boolean_0;

		private static readonly IntPtr NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0;

		private static readonly IntPtr NativeMethodInfoPtr_GetAdjustedCastingTime_Private_Single_0;

		public unsafe AssassinMeleeAbility ability
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ability);
				IntPtr intPtr = *(IntPtr*)num;
				return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<AssassinMeleeAbility>(intPtr) : null;
			}
			set
			{
				IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ability)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)assassinMeleeAbility));
			}
		}

		public unsafe VfxTarget vfxTarget
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vfxTarget);
				return *(VfxTarget*)num;
			}
			set
			{
				*(VfxTarget*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vfxTarget)) = vfxTarget;
			}
		}

		public unsafe VfxEventAction vfxAction
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vfxAction);
				return *(VfxEventAction*)num;
			}
			set
			{
				*(VfxEventAction*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vfxAction)) = vfxEventAction;
			}
		}

		public unsafe int vfxIdNormal
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vfxIdNormal);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vfxIdNormal)) = num;
			}
		}

		public unsafe int vfxIdRed
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vfxIdRed);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vfxIdRed)) = num;
			}
		}

		public unsafe uint netId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_netId);
				return *(uint*)num;
			}
			set
			{
				*(uint*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_netId)) = num;
			}
		}

		public unsafe Vector3 position
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_position);
				return *(Vector3*)num;
			}
			set
			{
				*(Vector3*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_position)) = vector;
			}
		}

		public unsafe Quaternion rotation
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rotation);
				return *(Quaternion*)num;
			}
			set
			{
				*(Quaternion*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rotation)) = quaternion;
			}
		}

		public unsafe byte attachableId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_attachableId);
				return *(byte*)num;
			}
			set
			{
				*(byte*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_attachableId)) = b;
			}
		}

		public unsafe float rotateDelay
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rotateDelay);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rotateDelay)) = num;
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

		static CustomVfxSubroutine()
		{
			Il2CppClassPointerStore<CustomVfxSubroutine>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<AssassinMeleeAbility>.NativeClassPtr, "CustomVfxSubroutine");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CustomVfxSubroutine>.NativeClassPtr);
			NativeFieldInfoPtr_ability = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomVfxSubroutine>.NativeClassPtr, "ability");
			NativeFieldInfoPtr_vfxTarget = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomVfxSubroutine>.NativeClassPtr, "vfxTarget");
			NativeFieldInfoPtr_vfxAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomVfxSubroutine>.NativeClassPtr, "vfxAction");
			NativeFieldInfoPtr_vfxIdNormal = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomVfxSubroutine>.NativeClassPtr, "vfxIdNormal");
			NativeFieldInfoPtr_vfxIdRed = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomVfxSubroutine>.NativeClassPtr, "vfxIdRed");
			NativeFieldInfoPtr_netId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomVfxSubroutine>.NativeClassPtr, "netId");
			NativeFieldInfoPtr_position = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomVfxSubroutine>.NativeClassPtr, "position");
			NativeFieldInfoPtr_rotation = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomVfxSubroutine>.NativeClassPtr, "rotation");
			NativeFieldInfoPtr_attachableId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomVfxSubroutine>.NativeClassPtr, "attachableId");
			NativeFieldInfoPtr_rotateDelay = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomVfxSubroutine>.NativeClassPtr, "rotateDelay");
			NativeFieldInfoPtr_applyAtkSpeedMultiplier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomVfxSubroutine>.NativeClassPtr, "applyAtkSpeedMultiplier");
			NativeMethodInfoPtr__ctor_Public_Void_AssassinMeleeAbility_VfxEventAction_VfxTarget_GameObject_GameObject_Vector3_Quaternion_Byte_Single_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomVfxSubroutine>.NativeClassPtr, 100674416);
			NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomVfxSubroutine>.NativeClassPtr, 100674417);
			NativeMethodInfoPtr_GetAdjustedCastingTime_Private_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomVfxSubroutine>.NativeClassPtr, 100674418);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 146614, XrefRangeEnd = 146617, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe CustomVfxSubroutine(AssassinMeleeAbility ability, VfxEventAction vfxAction, VfxTarget vfxTarget, GameObject vfxPrefabNormal, GameObject vfxPrefabRed, Vector3 position, Quaternion rotation, byte attachableId = 0, float rotateDelay = 0f, bool applyAtkSpeedMultiplier = false)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CustomVfxSubroutine>.NativeClassPtr))
		{
			IntPtr* ptr = stackalloc IntPtr[10];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)ability);
			*(VfxEventAction**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &vfxAction;
			*(VfxTarget**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = &vfxTarget;
			*(IntPtr*)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)vfxPrefabNormal);
			*(IntPtr*)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)vfxPrefabRed);
			*(Vector3**)((byte*)ptr + checked((nuint)5u * unchecked((nuint)sizeof(IntPtr)))) = &position;
			*(Quaternion**)((byte*)ptr + checked((nuint)6u * unchecked((nuint)sizeof(IntPtr)))) = &rotation;
			*(byte**)((byte*)ptr + checked((nuint)7u * unchecked((nuint)sizeof(IntPtr)))) = &attachableId;
			*(float**)((byte*)ptr + checked((nuint)8u * unchecked((nuint)sizeof(IntPtr)))) = &rotateDelay;
			*(bool**)((byte*)ptr + checked((nuint)9u * unchecked((nuint)sizeof(IntPtr)))) = &applyAtkSpeedMultiplier;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_AssassinMeleeAbility_VfxEventAction_VfxTarget_GameObject_GameObject_Vector3_Quaternion_Byte_Single_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 146617, XrefRangeEnd = 146627, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
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

		[CallerCount(0)]
		public unsafe float GetAdjustedCastingTime()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetAdjustedCastingTime_Private_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(float*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		public CustomVfxSubroutine(IntPtr pointer)
			: base(pointer)
		{
		}
	}

	public class CustomAttackSubroutine : SimulationSubroutine
	{
		private static readonly IntPtr NativeFieldInfoPtr_ability;

		private static readonly IntPtr NativeFieldInfoPtr_attackId;

		private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_AssassinMeleeAbility_Int32_0;

		private static readonly IntPtr NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0;

		public unsafe AssassinMeleeAbility ability
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ability);
				IntPtr intPtr = *(IntPtr*)num;
				return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<AssassinMeleeAbility>(intPtr) : null;
			}
			set
			{
				IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ability)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)assassinMeleeAbility));
			}
		}

		public unsafe int attackId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_attackId);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_attackId)) = num;
			}
		}

		static CustomAttackSubroutine()
		{
			Il2CppClassPointerStore<CustomAttackSubroutine>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<AssassinMeleeAbility>.NativeClassPtr, "CustomAttackSubroutine");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CustomAttackSubroutine>.NativeClassPtr);
			NativeFieldInfoPtr_ability = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomAttackSubroutine>.NativeClassPtr, "ability");
			NativeFieldInfoPtr_attackId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomAttackSubroutine>.NativeClassPtr, "attackId");
			NativeMethodInfoPtr__ctor_Public_Void_AssassinMeleeAbility_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomAttackSubroutine>.NativeClassPtr, 100674419);
			NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomAttackSubroutine>.NativeClassPtr, 100674420);
		}

		[CallerCount(110)]
		[CachedScanResults(RefRangeStart = 129576, RefRangeEnd = 129686, XrefRangeStart = 129576, XrefRangeEnd = 129686, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe CustomAttackSubroutine(AssassinMeleeAbility _ability, int _attackId)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CustomAttackSubroutine>.NativeClassPtr))
		{
			IntPtr* ptr = stackalloc IntPtr[2];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_ability);
			*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &_attackId;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_AssassinMeleeAbility_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 146627, XrefRangeEnd = 146635, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
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

		public CustomAttackSubroutine(IntPtr pointer)
			: base(pointer)
		{
		}
	}

	public class CustomBonusApplySubroutine : SimulationSubroutine
	{
		private static readonly IntPtr NativeFieldInfoPtr_ability;

		private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_AssassinMeleeAbility_0;

		private static readonly IntPtr NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0;

		public unsafe AssassinMeleeAbility ability
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ability);
				IntPtr intPtr = *(IntPtr*)num;
				return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<AssassinMeleeAbility>(intPtr) : null;
			}
			set
			{
				IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ability)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)assassinMeleeAbility));
			}
		}

		static CustomBonusApplySubroutine()
		{
			Il2CppClassPointerStore<CustomBonusApplySubroutine>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<AssassinMeleeAbility>.NativeClassPtr, "CustomBonusApplySubroutine");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CustomBonusApplySubroutine>.NativeClassPtr);
			NativeFieldInfoPtr_ability = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomBonusApplySubroutine>.NativeClassPtr, "ability");
			NativeMethodInfoPtr__ctor_Public_Void_AssassinMeleeAbility_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomBonusApplySubroutine>.NativeClassPtr, 100674421);
			NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomBonusApplySubroutine>.NativeClassPtr, 100674422);
		}

		[CallerCount(534)]
		[CachedScanResults(RefRangeStart = 124041, RefRangeEnd = 124575, XrefRangeStart = 124041, XrefRangeEnd = 124575, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe CustomBonusApplySubroutine(AssassinMeleeAbility _ability)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CustomBonusApplySubroutine>.NativeClassPtr))
		{
			IntPtr* ptr = stackalloc IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_ability);
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_AssassinMeleeAbility_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
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

		public CustomBonusApplySubroutine(IntPtr pointer)
			: base(pointer)
		{
		}
	}

	public class CustomBonusResetSubroutine : SimulationSubroutine
	{
		private static readonly IntPtr NativeFieldInfoPtr_ability;

		private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_AssassinMeleeAbility_0;

		private static readonly IntPtr NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0;

		public unsafe AssassinMeleeAbility ability
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ability);
				IntPtr intPtr = *(IntPtr*)num;
				return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<AssassinMeleeAbility>(intPtr) : null;
			}
			set
			{
				IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ability)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)assassinMeleeAbility));
			}
		}

		static CustomBonusResetSubroutine()
		{
			Il2CppClassPointerStore<CustomBonusResetSubroutine>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<AssassinMeleeAbility>.NativeClassPtr, "CustomBonusResetSubroutine");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CustomBonusResetSubroutine>.NativeClassPtr);
			NativeFieldInfoPtr_ability = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomBonusResetSubroutine>.NativeClassPtr, "ability");
			NativeMethodInfoPtr__ctor_Public_Void_AssassinMeleeAbility_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomBonusResetSubroutine>.NativeClassPtr, 100674423);
			NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomBonusResetSubroutine>.NativeClassPtr, 100674424);
		}

		[CallerCount(534)]
		[CachedScanResults(RefRangeStart = 124041, RefRangeEnd = 124575, XrefRangeStart = 124041, XrefRangeEnd = 124575, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe CustomBonusResetSubroutine(AssassinMeleeAbility _ability)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CustomBonusResetSubroutine>.NativeClassPtr))
		{
			IntPtr* ptr = stackalloc IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_ability);
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_AssassinMeleeAbility_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 146635, XrefRangeEnd = 146637, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
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

		public CustomBonusResetSubroutine(IntPtr pointer)
			: base(pointer)
		{
		}
	}

	private static readonly IntPtr NativeFieldInfoPtr_spellAttack1Prefab;

	private static readonly IntPtr NativeFieldInfoPtr_spellAttack2Prefab;

	private static readonly IntPtr NativeFieldInfoPtr_firingPoint;

	private static readonly IntPtr NativeFieldInfoPtr_castMotionLockType;

	private static readonly IntPtr NativeFieldInfoPtr_applyAtkSpeedMultiplier;

	private static readonly IntPtr NativeFieldInfoPtr_applyCooldownMultiplier;

	private static readonly IntPtr NativeFieldInfoPtr_inputType;

	private static readonly IntPtr NativeFieldInfoPtr_ttl;

	private static readonly IntPtr NativeFieldInfoPtr_damage1;

	private static readonly IntPtr NativeFieldInfoPtr_damage1Scaling;

	private static readonly IntPtr NativeFieldInfoPtr_damage2;

	private static readonly IntPtr NativeFieldInfoPtr_damage2Scaling;

	private static readonly IntPtr NativeFieldInfoPtr_BaseInvisibleBonusDamage;

	private static readonly IntPtr NativeFieldInfoPtr_castingTime1;

	private static readonly IntPtr NativeFieldInfoPtr_recoveryTime1;

	private static readonly IntPtr NativeFieldInfoPtr_cooldownTime1;

	private static readonly IntPtr NativeFieldInfoPtr_castingTime2;

	private static readonly IntPtr NativeFieldInfoPtr_recoveryTime2;

	private static readonly IntPtr NativeFieldInfoPtr_comboCooldownTime;

	private static readonly IntPtr NativeFieldInfoPtr_comboResetTime;

	private static readonly IntPtr NativeFieldInfoPtr_vfxCast1Prefab;

	private static readonly IntPtr NativeFieldInfoPtr_vfxCast2Prefab;

	private static readonly IntPtr NativeFieldInfoPtr_vfxCast1RedPrefab;

	private static readonly IntPtr NativeFieldInfoPtr_vfxCast2RedPrefab;

	private static readonly IntPtr NativeFieldInfoPtr_sfxCast1;

	private static readonly IntPtr NativeFieldInfoPtr_sfxCast2;

	private static readonly IntPtr NativeFieldInfoPtr_animLayer;

	private static readonly IntPtr NativeFieldInfoPtr_invisibleEscapeAbility;

	private static readonly IntPtr NativeMethodInfoPtr_PreAwake_Public_Virtual_Void_EntityManager_0;

	private static readonly IntPtr NativeMethodInfoPtr_DoAttack_Private_Void_Vector3_GameObject_Int32_Single_Int32_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetTooltipDescription_Public_Virtual_String_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetTooltipExpandedDescription_Public_Virtual_String_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_Weaved_Public_Virtual_Boolean_0;

	public unsafe GameObject spellAttack1Prefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spellAttack1Prefab);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spellAttack1Prefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe GameObject spellAttack2Prefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spellAttack2Prefab);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spellAttack2Prefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
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

	public unsafe int damage1
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_damage1);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_damage1)) = num;
		}
	}

	public unsafe float damage1Scaling
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_damage1Scaling);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_damage1Scaling)) = num;
		}
	}

	public unsafe int damage2
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_damage2);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_damage2)) = num;
		}
	}

	public unsafe float damage2Scaling
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_damage2Scaling);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_damage2Scaling)) = num;
		}
	}

	public unsafe int BaseInvisibleBonusDamage
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_BaseInvisibleBonusDamage);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_BaseInvisibleBonusDamage)) = num;
		}
	}

	public unsafe float castingTime1
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castingTime1);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castingTime1)) = num;
		}
	}

	public unsafe float recoveryTime1
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_recoveryTime1);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_recoveryTime1)) = num;
		}
	}

	public unsafe float cooldownTime1
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_cooldownTime1);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_cooldownTime1)) = num;
		}
	}

	public unsafe float castingTime2
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castingTime2);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castingTime2)) = num;
		}
	}

	public unsafe float recoveryTime2
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_recoveryTime2);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_recoveryTime2)) = num;
		}
	}

	public unsafe float comboCooldownTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_comboCooldownTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_comboCooldownTime)) = num;
		}
	}

	public unsafe float comboResetTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_comboResetTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_comboResetTime)) = num;
		}
	}

	public unsafe GameObject vfxCast1Prefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vfxCast1Prefab);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vfxCast1Prefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe GameObject vfxCast2Prefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vfxCast2Prefab);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vfxCast2Prefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe GameObject vfxCast1RedPrefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vfxCast1RedPrefab);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vfxCast1RedPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe GameObject vfxCast2RedPrefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vfxCast2RedPrefab);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vfxCast2RedPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe AudioClipData sfxCast1
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sfxCast1);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<AudioClipData>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sfxCast1)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)audioClipData));
		}
	}

	public unsafe AudioClipData sfxCast2
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sfxCast2);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<AudioClipData>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sfxCast2)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)audioClipData));
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

	public unsafe InvisibleEscapeAbility invisibleEscapeAbility
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_invisibleEscapeAbility);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<InvisibleEscapeAbility>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_invisibleEscapeAbility)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)invisibleEscapeAbility));
		}
	}

	static AssassinMeleeAbility()
	{
		Il2CppClassPointerStore<AssassinMeleeAbility>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Entities", "AssassinMeleeAbility");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<AssassinMeleeAbility>.NativeClassPtr);
		NativeFieldInfoPtr_spellAttack1Prefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AssassinMeleeAbility>.NativeClassPtr, "spellAttack1Prefab");
		NativeFieldInfoPtr_spellAttack2Prefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AssassinMeleeAbility>.NativeClassPtr, "spellAttack2Prefab");
		NativeFieldInfoPtr_firingPoint = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AssassinMeleeAbility>.NativeClassPtr, "firingPoint");
		NativeFieldInfoPtr_castMotionLockType = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AssassinMeleeAbility>.NativeClassPtr, "castMotionLockType");
		NativeFieldInfoPtr_applyAtkSpeedMultiplier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AssassinMeleeAbility>.NativeClassPtr, "applyAtkSpeedMultiplier");
		NativeFieldInfoPtr_applyCooldownMultiplier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AssassinMeleeAbility>.NativeClassPtr, "applyCooldownMultiplier");
		NativeFieldInfoPtr_inputType = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AssassinMeleeAbility>.NativeClassPtr, "inputType");
		NativeFieldInfoPtr_ttl = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AssassinMeleeAbility>.NativeClassPtr, "ttl");
		NativeFieldInfoPtr_damage1 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AssassinMeleeAbility>.NativeClassPtr, "damage1");
		NativeFieldInfoPtr_damage1Scaling = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AssassinMeleeAbility>.NativeClassPtr, "damage1Scaling");
		NativeFieldInfoPtr_damage2 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AssassinMeleeAbility>.NativeClassPtr, "damage2");
		NativeFieldInfoPtr_damage2Scaling = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AssassinMeleeAbility>.NativeClassPtr, "damage2Scaling");
		NativeFieldInfoPtr_BaseInvisibleBonusDamage = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AssassinMeleeAbility>.NativeClassPtr, "BaseInvisibleBonusDamage");
		NativeFieldInfoPtr_castingTime1 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AssassinMeleeAbility>.NativeClassPtr, "castingTime1");
		NativeFieldInfoPtr_recoveryTime1 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AssassinMeleeAbility>.NativeClassPtr, "recoveryTime1");
		NativeFieldInfoPtr_cooldownTime1 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AssassinMeleeAbility>.NativeClassPtr, "cooldownTime1");
		NativeFieldInfoPtr_castingTime2 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AssassinMeleeAbility>.NativeClassPtr, "castingTime2");
		NativeFieldInfoPtr_recoveryTime2 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AssassinMeleeAbility>.NativeClassPtr, "recoveryTime2");
		NativeFieldInfoPtr_comboCooldownTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AssassinMeleeAbility>.NativeClassPtr, "comboCooldownTime");
		NativeFieldInfoPtr_comboResetTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AssassinMeleeAbility>.NativeClassPtr, "comboResetTime");
		NativeFieldInfoPtr_vfxCast1Prefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AssassinMeleeAbility>.NativeClassPtr, "vfxCast1Prefab");
		NativeFieldInfoPtr_vfxCast2Prefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AssassinMeleeAbility>.NativeClassPtr, "vfxCast2Prefab");
		NativeFieldInfoPtr_vfxCast1RedPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AssassinMeleeAbility>.NativeClassPtr, "vfxCast1RedPrefab");
		NativeFieldInfoPtr_vfxCast2RedPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AssassinMeleeAbility>.NativeClassPtr, "vfxCast2RedPrefab");
		NativeFieldInfoPtr_sfxCast1 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AssassinMeleeAbility>.NativeClassPtr, "sfxCast1");
		NativeFieldInfoPtr_sfxCast2 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AssassinMeleeAbility>.NativeClassPtr, "sfxCast2");
		NativeFieldInfoPtr_animLayer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AssassinMeleeAbility>.NativeClassPtr, "animLayer");
		NativeFieldInfoPtr_invisibleEscapeAbility = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AssassinMeleeAbility>.NativeClassPtr, "invisibleEscapeAbility");
		NativeMethodInfoPtr_PreAwake_Public_Virtual_Void_EntityManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<AssassinMeleeAbility>.NativeClassPtr, 100674410);
		NativeMethodInfoPtr_DoAttack_Private_Void_Vector3_GameObject_Int32_Single_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<AssassinMeleeAbility>.NativeClassPtr, 100674411);
		NativeMethodInfoPtr_GetTooltipDescription_Public_Virtual_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<AssassinMeleeAbility>.NativeClassPtr, 100674412);
		NativeMethodInfoPtr_GetTooltipExpandedDescription_Public_Virtual_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<AssassinMeleeAbility>.NativeClassPtr, 100674413);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<AssassinMeleeAbility>.NativeClassPtr, 100674414);
		NativeMethodInfoPtr_Weaved_Public_Virtual_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<AssassinMeleeAbility>.NativeClassPtr, 100674415);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 146637, XrefRangeEnd = 146918, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
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
	[CachedScanResults(RefRangeStart = 146950, RefRangeEnd = 146951, XrefRangeStart = 146918, XrefRangeEnd = 146950, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void DoAttack(Vector3 lookDir, GameObject spellPrefab, int damage, float damageScaling, int predTickNum)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[5];
		*ptr = (nint)(&lookDir);
		*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)spellPrefab);
		*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = &damage;
		*(float**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(IntPtr)))) = &damageScaling;
		*(int**)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(IntPtr)))) = &predTickNum;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_DoAttack_Private_Void_Vector3_GameObject_Int32_Single_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 146951, XrefRangeEnd = 146956, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
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
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 146956, XrefRangeEnd = 146960, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override string GetTooltipExpandedDescription()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_GetTooltipExpandedDescription_Public_Virtual_String_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 0, XrefRangeEnd = 0, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe AssassinMeleeAbility()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<AssassinMeleeAbility>.NativeClassPtr))
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

	public AssassinMeleeAbility(IntPtr pointer)
		: base(pointer)
	{
	}
}
