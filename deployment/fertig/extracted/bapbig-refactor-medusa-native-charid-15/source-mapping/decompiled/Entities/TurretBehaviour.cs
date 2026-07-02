using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Local;
using Il2CppBAPBAP.Network;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using UnityEngine;

namespace Il2CppBAPBAP.Entities;

public class TurretBehaviour : NpcBehaviour
{
	public class CustomAlertStateSubroutine : SimulationSubroutine
	{
		private static readonly IntPtr NativeFieldInfoPtr_npcBehaviour;

		private static readonly IntPtr NativeFieldInfoPtr_targetLostTrigger;

		private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_TurretBehaviour_Byte_0;

		private static readonly IntPtr NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0;

		public unsafe TurretBehaviour npcBehaviour
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_npcBehaviour);
				IntPtr intPtr = *(IntPtr*)num;
				return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<TurretBehaviour>(intPtr) : null;
			}
			set
			{
				IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_npcBehaviour)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)turretBehaviour));
			}
		}

		public unsafe byte targetLostTrigger
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_targetLostTrigger);
				return *(byte*)num;
			}
			set
			{
				*(byte*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_targetLostTrigger)) = b;
			}
		}

		static CustomAlertStateSubroutine()
		{
			Il2CppClassPointerStore<CustomAlertStateSubroutine>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<TurretBehaviour>.NativeClassPtr, "CustomAlertStateSubroutine");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CustomAlertStateSubroutine>.NativeClassPtr);
			NativeFieldInfoPtr_npcBehaviour = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomAlertStateSubroutine>.NativeClassPtr, "npcBehaviour");
			NativeFieldInfoPtr_targetLostTrigger = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomAlertStateSubroutine>.NativeClassPtr, "targetLostTrigger");
			NativeMethodInfoPtr__ctor_Public_Void_TurretBehaviour_Byte_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomAlertStateSubroutine>.NativeClassPtr, 100675687);
			NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomAlertStateSubroutine>.NativeClassPtr, 100675688);
		}

		[CallerCount(35)]
		[CachedScanResults(RefRangeStart = 123824, RefRangeEnd = 123859, XrefRangeStart = 123824, XrefRangeEnd = 123859, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe CustomAlertStateSubroutine(TurretBehaviour _turretBehaviour, byte _targetLostTrigger)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CustomAlertStateSubroutine>.NativeClassPtr))
		{
			IntPtr* ptr = stackalloc IntPtr[2];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_turretBehaviour);
			*(byte**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &_targetLostTrigger;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_TurretBehaviour_Byte_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 164611, XrefRangeEnd = 164623, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
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

		public CustomAlertStateSubroutine(IntPtr pointer)
			: base(pointer)
		{
		}
	}

	private static readonly IntPtr NativeFieldInfoPtr_turretAim;

	private static readonly IntPtr NativeFieldInfoPtr_shotAbility;

	private static readonly IntPtr NativeFieldInfoPtr_chargedShotAbility;

	private static readonly IntPtr NativeFieldInfoPtr_animLayer;

	private static readonly IntPtr NativeMethodInfoPtr_PreAwake_Public_Virtual_Void_EntityManager_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_Weaved_Public_Virtual_Boolean_0;

	public unsafe Transform turretAim
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_turretAim);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Transform>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_turretAim)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)transform));
		}
	}

	public unsafe AbilityTriggerData shotAbility
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_shotAbility);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<AbilityTriggerData>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_shotAbility)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)abilityTriggerData));
		}
	}

	public unsafe AbilityTriggerData chargedShotAbility
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_chargedShotAbility);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<AbilityTriggerData>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_chargedShotAbility)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)abilityTriggerData));
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

	static TurretBehaviour()
	{
		Il2CppClassPointerStore<TurretBehaviour>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Entities", "TurretBehaviour");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<TurretBehaviour>.NativeClassPtr);
		NativeFieldInfoPtr_turretAim = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TurretBehaviour>.NativeClassPtr, "turretAim");
		NativeFieldInfoPtr_shotAbility = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TurretBehaviour>.NativeClassPtr, "shotAbility");
		NativeFieldInfoPtr_chargedShotAbility = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TurretBehaviour>.NativeClassPtr, "chargedShotAbility");
		NativeFieldInfoPtr_animLayer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TurretBehaviour>.NativeClassPtr, "animLayer");
		NativeMethodInfoPtr_PreAwake_Public_Virtual_Void_EntityManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TurretBehaviour>.NativeClassPtr, 100675684);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TurretBehaviour>.NativeClassPtr, 100675685);
		NativeMethodInfoPtr_Weaved_Public_Virtual_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TurretBehaviour>.NativeClassPtr, 100675686);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 164623, XrefRangeEnd = 164675, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void PreAwake(EntityManager e)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)e);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_PreAwake_Public_Virtual_Void_EntityManager_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 164675, XrefRangeEnd = 164678, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe TurretBehaviour()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<TurretBehaviour>.NativeClassPtr))
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

	public TurretBehaviour(IntPtr pointer)
		: base(pointer)
	{
	}
}
