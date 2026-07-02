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
using UnityEngine;

namespace Il2CppBAPBAP.Entities;

public class NpcContinuousShotAbility : Ability
{
	public class CustomCastVfxSubroutine : SimulationSubroutine
	{
		private static readonly IntPtr NativeFieldInfoPtr_ability;

		private static readonly IntPtr NativeFieldInfoPtr_setEnabled;

		private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_NpcContinuousShotAbility_Boolean_0;

		private static readonly IntPtr NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0;

		public unsafe NpcContinuousShotAbility ability
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ability);
				IntPtr intPtr = *(IntPtr*)num;
				return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<NpcContinuousShotAbility>(intPtr) : null;
			}
			set
			{
				IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ability)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)npcContinuousShotAbility));
			}
		}

		public unsafe bool setEnabled
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_setEnabled);
				return *(bool*)num;
			}
			set
			{
				*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_setEnabled)) = flag;
			}
		}

		static CustomCastVfxSubroutine()
		{
			Il2CppClassPointerStore<CustomCastVfxSubroutine>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, "CustomCastVfxSubroutine");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CustomCastVfxSubroutine>.NativeClassPtr);
			NativeFieldInfoPtr_ability = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomCastVfxSubroutine>.NativeClassPtr, "ability");
			NativeFieldInfoPtr_setEnabled = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomCastVfxSubroutine>.NativeClassPtr, "setEnabled");
			NativeMethodInfoPtr__ctor_Public_Void_NpcContinuousShotAbility_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomCastVfxSubroutine>.NativeClassPtr, 100673819);
			NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomCastVfxSubroutine>.NativeClassPtr, 100673820);
		}

		[CallerCount(35)]
		[CachedScanResults(RefRangeStart = 123824, RefRangeEnd = 123859, XrefRangeStart = 123824, XrefRangeEnd = 123859, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe CustomCastVfxSubroutine(NpcContinuousShotAbility _ability, bool _setEnabled)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CustomCastVfxSubroutine>.NativeClassPtr))
		{
			IntPtr* ptr = stackalloc IntPtr[2];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_ability);
			*(bool**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &_setEnabled;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_NpcContinuousShotAbility_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 137102, XrefRangeEnd = 137104, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
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

		public CustomCastVfxSubroutine(IntPtr pointer)
			: base(pointer)
		{
		}
	}

	public class CustomVisibleIndicatorSubroutine : SimulationSubroutine
	{
		private static readonly IntPtr NativeFieldInfoPtr_ability;

		private static readonly IntPtr NativeFieldInfoPtr_setEnabled;

		private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_NpcContinuousShotAbility_Boolean_0;

		private static readonly IntPtr NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0;

		public unsafe NpcContinuousShotAbility ability
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ability);
				IntPtr intPtr = *(IntPtr*)num;
				return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<NpcContinuousShotAbility>(intPtr) : null;
			}
			set
			{
				IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ability)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)npcContinuousShotAbility));
			}
		}

		public unsafe bool setEnabled
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_setEnabled);
				return *(bool*)num;
			}
			set
			{
				*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_setEnabled)) = flag;
			}
		}

		static CustomVisibleIndicatorSubroutine()
		{
			Il2CppClassPointerStore<CustomVisibleIndicatorSubroutine>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, "CustomVisibleIndicatorSubroutine");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CustomVisibleIndicatorSubroutine>.NativeClassPtr);
			NativeFieldInfoPtr_ability = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomVisibleIndicatorSubroutine>.NativeClassPtr, "ability");
			NativeFieldInfoPtr_setEnabled = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomVisibleIndicatorSubroutine>.NativeClassPtr, "setEnabled");
			NativeMethodInfoPtr__ctor_Public_Void_NpcContinuousShotAbility_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomVisibleIndicatorSubroutine>.NativeClassPtr, 100673821);
			NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomVisibleIndicatorSubroutine>.NativeClassPtr, 100673822);
		}

		[CallerCount(35)]
		[CachedScanResults(RefRangeStart = 123824, RefRangeEnd = 123859, XrefRangeStart = 123824, XrefRangeEnd = 123859, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe CustomVisibleIndicatorSubroutine(NpcContinuousShotAbility _ability, bool _setEnabled)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CustomVisibleIndicatorSubroutine>.NativeClassPtr))
		{
			IntPtr* ptr = stackalloc IntPtr[2];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_ability);
			*(bool**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &_setEnabled;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_NpcContinuousShotAbility_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 137104, XrefRangeEnd = 137106, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
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

		public CustomVisibleIndicatorSubroutine(IntPtr pointer)
			: base(pointer)
		{
		}
	}

	public class CustomShootSubroutine : SimulationSubroutine
	{
		private static readonly IntPtr NativeFieldInfoPtr_ability;

		private static readonly IntPtr NativeFieldInfoPtr_finishTrigger;

		private static readonly IntPtr NativeFieldInfoPtr_silenceTrigger;

		private static readonly IntPtr NativeFieldInfoPtr_shootDurationTime;

		private static readonly IntPtr NativeFieldInfoPtr_animLayer;

		private static readonly IntPtr NativeFieldInfoPtr_timeElapsed;

		private static readonly IntPtr NativeFieldInfoPtr_fireRate;

		private static readonly IntPtr NativeFieldInfoPtr_fireRateTimer;

		private static readonly IntPtr NativeFieldInfoPtr_amountToRotate;

		private static readonly IntPtr NativeFieldInfoPtr_rot;

		private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_NpcContinuousShotAbility_Byte_Byte_Single_AnimLayerIndices_0;

		private static readonly IntPtr NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0;

		private static readonly IntPtr NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0;

		public unsafe NpcContinuousShotAbility ability
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ability);
				IntPtr intPtr = *(IntPtr*)num;
				return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<NpcContinuousShotAbility>(intPtr) : null;
			}
			set
			{
				IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ability)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)npcContinuousShotAbility));
			}
		}

		public unsafe byte finishTrigger
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_finishTrigger);
				return *(byte*)num;
			}
			set
			{
				*(byte*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_finishTrigger)) = b;
			}
		}

		public unsafe byte silenceTrigger
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_silenceTrigger);
				return *(byte*)num;
			}
			set
			{
				*(byte*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_silenceTrigger)) = b;
			}
		}

		public unsafe float shootDurationTime
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_shootDurationTime);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_shootDurationTime)) = num;
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

		public unsafe float timeElapsed
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_timeElapsed);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_timeElapsed)) = num;
			}
		}

		public unsafe float fireRate
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fireRate);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fireRate)) = num;
			}
		}

		public unsafe float fireRateTimer
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fireRateTimer);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fireRateTimer)) = num;
			}
		}

		public unsafe float amountToRotate
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_amountToRotate);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_amountToRotate)) = num;
			}
		}

		public unsafe Quaternion rot
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rot);
				return *(Quaternion*)num;
			}
			set
			{
				*(Quaternion*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rot)) = quaternion;
			}
		}

		static CustomShootSubroutine()
		{
			Il2CppClassPointerStore<CustomShootSubroutine>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, "CustomShootSubroutine");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CustomShootSubroutine>.NativeClassPtr);
			NativeFieldInfoPtr_ability = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomShootSubroutine>.NativeClassPtr, "ability");
			NativeFieldInfoPtr_finishTrigger = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomShootSubroutine>.NativeClassPtr, "finishTrigger");
			NativeFieldInfoPtr_silenceTrigger = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomShootSubroutine>.NativeClassPtr, "silenceTrigger");
			NativeFieldInfoPtr_shootDurationTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomShootSubroutine>.NativeClassPtr, "shootDurationTime");
			NativeFieldInfoPtr_animLayer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomShootSubroutine>.NativeClassPtr, "animLayer");
			NativeFieldInfoPtr_timeElapsed = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomShootSubroutine>.NativeClassPtr, "timeElapsed");
			NativeFieldInfoPtr_fireRate = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomShootSubroutine>.NativeClassPtr, "fireRate");
			NativeFieldInfoPtr_fireRateTimer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomShootSubroutine>.NativeClassPtr, "fireRateTimer");
			NativeFieldInfoPtr_amountToRotate = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomShootSubroutine>.NativeClassPtr, "amountToRotate");
			NativeFieldInfoPtr_rot = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomShootSubroutine>.NativeClassPtr, "rot");
			NativeMethodInfoPtr__ctor_Public_Void_NpcContinuousShotAbility_Byte_Byte_Single_AnimLayerIndices_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomShootSubroutine>.NativeClassPtr, 100673823);
			NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomShootSubroutine>.NativeClassPtr, 100673824);
			NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomShootSubroutine>.NativeClassPtr, 100673825);
		}

		[CallerCount(136)]
		[CachedScanResults(RefRangeStart = 137107, RefRangeEnd = 137243, XrefRangeStart = 137106, XrefRangeEnd = 137107, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe CustomShootSubroutine(NpcContinuousShotAbility _ability, byte _finishTrigger, byte _silenceTrigger, float _shootDurationTime, AnimLayerIndices _animLayer)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CustomShootSubroutine>.NativeClassPtr))
		{
			IntPtr* ptr = stackalloc IntPtr[5];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_ability);
			*(byte**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &_finishTrigger;
			*(byte**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = &_silenceTrigger;
			*(float**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(IntPtr)))) = &_shootDurationTime;
			*(AnimLayerIndices**)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(IntPtr)))) = &_animLayer;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_NpcContinuousShotAbility_Byte_Byte_Single_AnimLayerIndices_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 137243, XrefRangeEnd = 137250, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
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
		public unsafe override byte OnTick(float fixedDt, Command cmd, bool isResim)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = stackalloc IntPtr[3];
			*ptr = (nint)(&fixedDt);
			*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cmd);
			*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = &isResim;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(byte*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		public CustomShootSubroutine(IntPtr pointer)
			: base(pointer)
		{
		}
	}

	private static readonly IntPtr NativeFieldInfoPtr_spellPrefab;

	private static readonly IntPtr NativeFieldInfoPtr_firingPoint;

	private static readonly IntPtr NativeFieldInfoPtr_numProjectiles;

	private static readonly IntPtr NativeFieldInfoPtr_rotationAmount;

	private static readonly IntPtr NativeFieldInfoPtr_castMotionLockType;

	private static readonly IntPtr NativeFieldInfoPtr_castRotationLockType;

	private static readonly IntPtr NativeFieldInfoPtr_applyAtkSpeedMultiplier;

	private static readonly IntPtr NativeFieldInfoPtr_applyCooldownMultiplier;

	private static readonly IntPtr NativeFieldInfoPtr_damage;

	private static readonly IntPtr NativeFieldInfoPtr_damageScaling;

	private static readonly IntPtr NativeFieldInfoPtr_speed;

	private static readonly IntPtr NativeFieldInfoPtr_enableSpeedCurve;

	private static readonly IntPtr NativeFieldInfoPtr_speedCurve;

	private static readonly IntPtr NativeFieldInfoPtr_ttl;

	private static readonly IntPtr NativeFieldInfoPtr_statusEffects;

	private static readonly IntPtr NativeFieldInfoPtr_castingTime;

	private static readonly IntPtr NativeFieldInfoPtr_shootDurationTime;

	private static readonly IntPtr NativeFieldInfoPtr_recoveryTime;

	private static readonly IntPtr NativeFieldInfoPtr_baseCooldownTime;

	private static readonly IntPtr NativeFieldInfoPtr_visibleIndicatorPrefab;

	private static readonly IntPtr NativeFieldInfoPtr_indicatorRadius;

	private static readonly IntPtr NativeFieldInfoPtr_indicatorHalfAngle;

	private static readonly IntPtr NativeFieldInfoPtr_sfxCast;

	private static readonly IntPtr NativeFieldInfoPtr_vfxRight;

	private static readonly IntPtr NativeFieldInfoPtr_vfxLeft;

	private static readonly IntPtr NativeFieldInfoPtr_castVfxRight;

	private static readonly IntPtr NativeFieldInfoPtr_castVfxLeft;

	private static readonly IntPtr NativeFieldInfoPtr_animLayer;

	private static readonly IntPtr NativeFieldInfoPtr_currentIndicator;

	private static readonly IntPtr NativeMethodInfoPtr_PreAwake_Public_Virtual_Void_EntityManager_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnDestroy_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_ShootProjectile_Private_Void_Vector3_Int32_0;

	private static readonly IntPtr NativeMethodInfoPtr_ClDestroyVisibleIndicator_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_RpcSpawnVisibleIndicator_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_RpcDestroyVisibleIndicator_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_RpcPlayCastVFX_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_RpcStopCastVFX_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_RpcPlayShootVFX_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_Weaved_Public_Virtual_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_UserCode_RpcSpawnVisibleIndicator_Protected_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_InvokeUserCode_RpcSpawnVisibleIndicator_Protected_Static_Void_NetworkBehaviour_NetworkReader_NetworkConnectionToClient_0;

	private static readonly IntPtr NativeMethodInfoPtr_UserCode_RpcDestroyVisibleIndicator_Protected_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_InvokeUserCode_RpcDestroyVisibleIndicator_Protected_Static_Void_NetworkBehaviour_NetworkReader_NetworkConnectionToClient_0;

	private static readonly IntPtr NativeMethodInfoPtr_UserCode_RpcPlayCastVFX_Protected_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_InvokeUserCode_RpcPlayCastVFX_Protected_Static_Void_NetworkBehaviour_NetworkReader_NetworkConnectionToClient_0;

	private static readonly IntPtr NativeMethodInfoPtr_UserCode_RpcStopCastVFX_Protected_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_InvokeUserCode_RpcStopCastVFX_Protected_Static_Void_NetworkBehaviour_NetworkReader_NetworkConnectionToClient_0;

	private static readonly IntPtr NativeMethodInfoPtr_UserCode_RpcPlayShootVFX_Protected_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_InvokeUserCode_RpcPlayShootVFX_Protected_Static_Void_NetworkBehaviour_NetworkReader_NetworkConnectionToClient_0;

	public unsafe GameObject spellPrefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spellPrefab);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spellPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
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

	public unsafe int numProjectiles
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_numProjectiles);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_numProjectiles)) = num;
		}
	}

	public unsafe float rotationAmount
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rotationAmount);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rotationAmount)) = num;
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

	public unsafe float damageScaling
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_damageScaling);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_damageScaling)) = num;
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

	public unsafe bool enableSpeedCurve
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_enableSpeedCurve);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_enableSpeedCurve)) = flag;
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

	public unsafe float shootDurationTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_shootDurationTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_shootDurationTime)) = num;
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

	public unsafe GameObject visibleIndicatorPrefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_visibleIndicatorPrefab);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_visibleIndicatorPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe float indicatorRadius
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_indicatorRadius);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_indicatorRadius)) = num;
		}
	}

	public unsafe float indicatorHalfAngle
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_indicatorHalfAngle);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_indicatorHalfAngle)) = num;
		}
	}

	public unsafe AudioClipData sfxCast
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sfxCast);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<AudioClipData>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sfxCast)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)audioClipData));
		}
	}

	public unsafe ParticleSystem vfxRight
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vfxRight);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<ParticleSystem>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vfxRight)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)particleSystem));
		}
	}

	public unsafe ParticleSystem vfxLeft
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vfxLeft);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<ParticleSystem>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vfxLeft)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)particleSystem));
		}
	}

	public unsafe ParticleSystem castVfxRight
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castVfxRight);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<ParticleSystem>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castVfxRight)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)particleSystem));
		}
	}

	public unsafe ParticleSystem castVfxLeft
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castVfxLeft);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<ParticleSystem>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castVfxLeft)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)particleSystem));
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

	public unsafe GameObject currentIndicator
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentIndicator);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentIndicator)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	static NpcContinuousShotAbility()
	{
		Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Entities", "NpcContinuousShotAbility");
		NativeFieldInfoPtr_spellPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, "spellPrefab");
		NativeFieldInfoPtr_firingPoint = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, "firingPoint");
		NativeFieldInfoPtr_numProjectiles = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, "numProjectiles");
		NativeFieldInfoPtr_rotationAmount = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, "rotationAmount");
		NativeFieldInfoPtr_castMotionLockType = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, "castMotionLockType");
		NativeFieldInfoPtr_castRotationLockType = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, "castRotationLockType");
		NativeFieldInfoPtr_applyAtkSpeedMultiplier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, "applyAtkSpeedMultiplier");
		NativeFieldInfoPtr_applyCooldownMultiplier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, "applyCooldownMultiplier");
		NativeFieldInfoPtr_damage = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, "damage");
		NativeFieldInfoPtr_damageScaling = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, "damageScaling");
		NativeFieldInfoPtr_speed = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, "speed");
		NativeFieldInfoPtr_enableSpeedCurve = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, "enableSpeedCurve");
		NativeFieldInfoPtr_speedCurve = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, "speedCurve");
		NativeFieldInfoPtr_ttl = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, "ttl");
		NativeFieldInfoPtr_statusEffects = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, "statusEffects");
		NativeFieldInfoPtr_castingTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, "castingTime");
		NativeFieldInfoPtr_shootDurationTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, "shootDurationTime");
		NativeFieldInfoPtr_recoveryTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, "recoveryTime");
		NativeFieldInfoPtr_baseCooldownTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, "baseCooldownTime");
		NativeFieldInfoPtr_visibleIndicatorPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, "visibleIndicatorPrefab");
		NativeFieldInfoPtr_indicatorRadius = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, "indicatorRadius");
		NativeFieldInfoPtr_indicatorHalfAngle = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, "indicatorHalfAngle");
		NativeFieldInfoPtr_sfxCast = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, "sfxCast");
		NativeFieldInfoPtr_vfxRight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, "vfxRight");
		NativeFieldInfoPtr_vfxLeft = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, "vfxLeft");
		NativeFieldInfoPtr_castVfxRight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, "castVfxRight");
		NativeFieldInfoPtr_castVfxLeft = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, "castVfxLeft");
		NativeFieldInfoPtr_animLayer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, "animLayer");
		NativeFieldInfoPtr_currentIndicator = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, "currentIndicator");
		NativeMethodInfoPtr_PreAwake_Public_Virtual_Void_EntityManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, 100673797);
		NativeMethodInfoPtr_OnDestroy_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, 100673798);
		NativeMethodInfoPtr_ShootProjectile_Private_Void_Vector3_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, 100673799);
		NativeMethodInfoPtr_ClDestroyVisibleIndicator_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, 100673800);
		NativeMethodInfoPtr_RpcSpawnVisibleIndicator_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, 100673801);
		NativeMethodInfoPtr_RpcDestroyVisibleIndicator_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, 100673802);
		NativeMethodInfoPtr_RpcPlayCastVFX_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, 100673803);
		NativeMethodInfoPtr_RpcStopCastVFX_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, 100673804);
		NativeMethodInfoPtr_RpcPlayShootVFX_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, 100673805);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, 100673806);
		NativeMethodInfoPtr_Weaved_Public_Virtual_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, 100673807);
		NativeMethodInfoPtr_UserCode_RpcSpawnVisibleIndicator_Protected_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, 100673808);
		NativeMethodInfoPtr_InvokeUserCode_RpcSpawnVisibleIndicator_Protected_Static_Void_NetworkBehaviour_NetworkReader_NetworkConnectionToClient_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, 100673809);
		NativeMethodInfoPtr_UserCode_RpcDestroyVisibleIndicator_Protected_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, 100673810);
		NativeMethodInfoPtr_InvokeUserCode_RpcDestroyVisibleIndicator_Protected_Static_Void_NetworkBehaviour_NetworkReader_NetworkConnectionToClient_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, 100673811);
		NativeMethodInfoPtr_UserCode_RpcPlayCastVFX_Protected_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, 100673812);
		NativeMethodInfoPtr_InvokeUserCode_RpcPlayCastVFX_Protected_Static_Void_NetworkBehaviour_NetworkReader_NetworkConnectionToClient_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, 100673813);
		NativeMethodInfoPtr_UserCode_RpcStopCastVFX_Protected_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, 100673814);
		NativeMethodInfoPtr_InvokeUserCode_RpcStopCastVFX_Protected_Static_Void_NetworkBehaviour_NetworkReader_NetworkConnectionToClient_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, 100673815);
		NativeMethodInfoPtr_UserCode_RpcPlayShootVFX_Protected_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, 100673816);
		NativeMethodInfoPtr_InvokeUserCode_RpcPlayShootVFX_Protected_Static_Void_NetworkBehaviour_NetworkReader_NetworkConnectionToClient_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr, 100673817);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 137250, XrefRangeEnd = 137418, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void PreAwake(EntityManager _entityManager)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_entityManager);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_PreAwake_Public_Virtual_Void_EntityManager_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 137418, XrefRangeEnd = 137420, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnDestroy()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnDestroy_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 137420, XrefRangeEnd = 137453, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ShootProjectile(Vector3 lookDir, int predTickNum)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[2];
		*ptr = (nint)(&lookDir);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &predTickNum;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ShootProjectile_Private_Void_Vector3_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 137458, RefRangeEnd = 137461, XrefRangeStart = 137453, XrefRangeEnd = 137458, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ClDestroyVisibleIndicator()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ClDestroyVisibleIndicator_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 137461, XrefRangeEnd = 137470, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void RpcSpawnVisibleIndicator()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_RpcSpawnVisibleIndicator_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 137479, RefRangeEnd = 137480, XrefRangeStart = 137470, XrefRangeEnd = 137479, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void RpcDestroyVisibleIndicator()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_RpcDestroyVisibleIndicator_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 137480, XrefRangeEnd = 137489, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void RpcPlayCastVFX()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_RpcPlayCastVFX_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 137498, RefRangeEnd = 137499, XrefRangeStart = 137489, XrefRangeEnd = 137498, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void RpcStopCastVFX()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_RpcStopCastVFX_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 137508, RefRangeEnd = 137509, XrefRangeStart = 137499, XrefRangeEnd = 137508, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void RpcPlayShootVFX()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_RpcPlayShootVFX_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 137509, XrefRangeEnd = 137514, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe NpcContinuousShotAbility()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<NpcContinuousShotAbility>.NativeClassPtr))
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

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 137549, RefRangeEnd = 137550, XrefRangeStart = 137514, XrefRangeEnd = 137549, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UserCode_RpcSpawnVisibleIndicator()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UserCode_RpcSpawnVisibleIndicator_Protected_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 137550, XrefRangeEnd = 137557, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void InvokeUserCode_RpcSpawnVisibleIndicator(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		IntPtr* ptr = stackalloc IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)obj);
		*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)reader);
		*(IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)senderConnection);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_InvokeUserCode_RpcSpawnVisibleIndicator_Protected_Static_Void_NetworkBehaviour_NetworkReader_NetworkConnectionToClient_0, (IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 137557, XrefRangeEnd = 137558, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UserCode_RpcDestroyVisibleIndicator()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UserCode_RpcDestroyVisibleIndicator_Protected_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 137558, XrefRangeEnd = 137565, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void InvokeUserCode_RpcDestroyVisibleIndicator(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		IntPtr* ptr = stackalloc IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)obj);
		*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)reader);
		*(IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)senderConnection);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_InvokeUserCode_RpcDestroyVisibleIndicator_Protected_Static_Void_NetworkBehaviour_NetworkReader_NetworkConnectionToClient_0, (IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 137565, XrefRangeEnd = 137572, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UserCode_RpcPlayCastVFX()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UserCode_RpcPlayCastVFX_Protected_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 137572, XrefRangeEnd = 137585, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void InvokeUserCode_RpcPlayCastVFX(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		IntPtr* ptr = stackalloc IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)obj);
		*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)reader);
		*(IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)senderConnection);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_InvokeUserCode_RpcPlayCastVFX_Protected_Static_Void_NetworkBehaviour_NetworkReader_NetworkConnectionToClient_0, (IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 137585, XrefRangeEnd = 137594, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UserCode_RpcStopCastVFX()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UserCode_RpcStopCastVFX_Protected_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 137594, XrefRangeEnd = 137609, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void InvokeUserCode_RpcStopCastVFX(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		IntPtr* ptr = stackalloc IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)obj);
		*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)reader);
		*(IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)senderConnection);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_InvokeUserCode_RpcStopCastVFX_Protected_Static_Void_NetworkBehaviour_NetworkReader_NetworkConnectionToClient_0, (IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 137609, XrefRangeEnd = 137611, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UserCode_RpcPlayShootVFX()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UserCode_RpcPlayShootVFX_Protected_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 137611, XrefRangeEnd = 137619, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void InvokeUserCode_RpcPlayShootVFX(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		IntPtr* ptr = stackalloc IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)obj);
		*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)reader);
		*(IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)senderConnection);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_InvokeUserCode_RpcPlayShootVFX_Protected_Static_Void_NetworkBehaviour_NetworkReader_NetworkConnectionToClient_0, (IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public NpcContinuousShotAbility(IntPtr pointer)
		: base(pointer)
	{
	}
}
