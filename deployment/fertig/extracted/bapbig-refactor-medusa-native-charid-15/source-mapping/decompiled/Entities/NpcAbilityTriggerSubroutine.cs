using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Local;
using Il2CppBAPBAP.Network;
using Il2CppBAPBAP.Utilities;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;

namespace Il2CppBAPBAP.Entities;

public class NpcAbilityTriggerSubroutine : SimulationSubroutine
{
	private static readonly IntPtr NativeFieldInfoPtr_npcBehaviour;

	private static readonly IntPtr NativeFieldInfoPtr_trigger;

	private static readonly IntPtr NativeFieldInfoPtr_ability;

	private static readonly IntPtr NativeFieldInfoPtr_updateRate;

	private static readonly IntPtr NativeFieldInfoPtr_triggerDistRangeSqr;

	private static readonly IntPtr NativeFieldInfoPtr_minAngleDifference;

	private static readonly IntPtr NativeFieldInfoPtr_needsLineOfSight;

	private static readonly IntPtr NativeFieldInfoPtr_randomChanceNorm;

	private static readonly IntPtr NativeFieldInfoPtr_randomChanceRate;

	private static readonly IntPtr NativeFieldInfoPtr_updateTimer;

	private static readonly IntPtr NativeFieldInfoPtr_randomChanceTimer;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_NpcBehaviour_Byte_AbilityTriggerData_Single_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_NpcBehaviour_Ability_Byte_RangeFloat_Single_Boolean_Single_Single_Single_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0;

	public unsafe NpcBehaviour npcBehaviour
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_npcBehaviour);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<NpcBehaviour>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_npcBehaviour)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)npcBehaviour));
		}
	}

	public unsafe byte trigger
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_trigger);
			return *(byte*)num;
		}
		set
		{
			*(byte*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_trigger)) = b;
		}
	}

	public unsafe Ability ability
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ability);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Ability>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ability)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)ability));
		}
	}

	public unsafe float updateRate
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_updateRate);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_updateRate)) = num;
		}
	}

	public unsafe RangeFloat triggerDistRangeSqr
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_triggerDistRangeSqr);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<RangeFloat>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_triggerDistRangeSqr)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)rangeFloat));
		}
	}

	public unsafe float minAngleDifference
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minAngleDifference);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minAngleDifference)) = num;
		}
	}

	public unsafe bool needsLineOfSight
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_needsLineOfSight);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_needsLineOfSight)) = flag;
		}
	}

	public unsafe float randomChanceNorm
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_randomChanceNorm);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_randomChanceNorm)) = num;
		}
	}

	public unsafe float randomChanceRate
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_randomChanceRate);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_randomChanceRate)) = num;
		}
	}

	public unsafe float updateTimer
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_updateTimer);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_updateTimer)) = num;
		}
	}

	public unsafe float randomChanceTimer
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_randomChanceTimer);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_randomChanceTimer)) = num;
		}
	}

	static NpcAbilityTriggerSubroutine()
	{
		Il2CppClassPointerStore<NpcAbilityTriggerSubroutine>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Entities", "NpcAbilityTriggerSubroutine");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<NpcAbilityTriggerSubroutine>.NativeClassPtr);
		NativeFieldInfoPtr_npcBehaviour = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcAbilityTriggerSubroutine>.NativeClassPtr, "npcBehaviour");
		NativeFieldInfoPtr_trigger = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcAbilityTriggerSubroutine>.NativeClassPtr, "trigger");
		NativeFieldInfoPtr_ability = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcAbilityTriggerSubroutine>.NativeClassPtr, "ability");
		NativeFieldInfoPtr_updateRate = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcAbilityTriggerSubroutine>.NativeClassPtr, "updateRate");
		NativeFieldInfoPtr_triggerDistRangeSqr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcAbilityTriggerSubroutine>.NativeClassPtr, "triggerDistRangeSqr");
		NativeFieldInfoPtr_minAngleDifference = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcAbilityTriggerSubroutine>.NativeClassPtr, "minAngleDifference");
		NativeFieldInfoPtr_needsLineOfSight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcAbilityTriggerSubroutine>.NativeClassPtr, "needsLineOfSight");
		NativeFieldInfoPtr_randomChanceNorm = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcAbilityTriggerSubroutine>.NativeClassPtr, "randomChanceNorm");
		NativeFieldInfoPtr_randomChanceRate = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcAbilityTriggerSubroutine>.NativeClassPtr, "randomChanceRate");
		NativeFieldInfoPtr_updateTimer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcAbilityTriggerSubroutine>.NativeClassPtr, "updateTimer");
		NativeFieldInfoPtr_randomChanceTimer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcAbilityTriggerSubroutine>.NativeClassPtr, "randomChanceTimer");
		NativeMethodInfoPtr__ctor_Public_Void_NpcBehaviour_Byte_AbilityTriggerData_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcAbilityTriggerSubroutine>.NativeClassPtr, 100675712);
		NativeMethodInfoPtr__ctor_Public_Void_NpcBehaviour_Ability_Byte_RangeFloat_Single_Boolean_Single_Single_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcAbilityTriggerSubroutine>.NativeClassPtr, 100675713);
		NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcAbilityTriggerSubroutine>.NativeClassPtr, 100675714);
	}

	[CallerCount(23)]
	[CachedScanResults(RefRangeStart = 164784, RefRangeEnd = 164807, XrefRangeStart = 164780, XrefRangeEnd = 164784, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe NpcAbilityTriggerSubroutine(NpcBehaviour _npcBehaviour, byte _trigger, AbilityTriggerData abData, float updateRateAdded = 0f)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<NpcAbilityTriggerSubroutine>.NativeClassPtr))
	{
		IntPtr* ptr = stackalloc IntPtr[4];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_npcBehaviour);
		*(byte**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &_trigger;
		*(IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)abData);
		*(float**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(IntPtr)))) = &updateRateAdded;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_NpcBehaviour_Byte_AbilityTriggerData_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 164807, XrefRangeEnd = 164811, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe NpcAbilityTriggerSubroutine(NpcBehaviour _npcBehaviour, Ability _ability, byte _trigger, RangeFloat _triggerDistRange, float _minAngleDifference, bool _needsLineOfSight = true, float _randomChanceNorm = 0f, float _randomChanceRate = 0f, float _updateRate = 0f)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<NpcAbilityTriggerSubroutine>.NativeClassPtr))
	{
		IntPtr* ptr = stackalloc IntPtr[9];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_npcBehaviour);
		*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_ability);
		*(byte**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = &_trigger;
		*(IntPtr*)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_triggerDistRange);
		*(float**)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(IntPtr)))) = &_minAngleDifference;
		*(bool**)((byte*)ptr + checked((nuint)5u * unchecked((nuint)sizeof(IntPtr)))) = &_needsLineOfSight;
		*(float**)((byte*)ptr + checked((nuint)6u * unchecked((nuint)sizeof(IntPtr)))) = &_randomChanceNorm;
		*(float**)((byte*)ptr + checked((nuint)7u * unchecked((nuint)sizeof(IntPtr)))) = &_randomChanceRate;
		*(float**)((byte*)ptr + checked((nuint)8u * unchecked((nuint)sizeof(IntPtr)))) = &_updateRate;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_NpcBehaviour_Ability_Byte_RangeFloat_Single_Boolean_Single_Single_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 164811, XrefRangeEnd = 164827, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
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

	public NpcAbilityTriggerSubroutine(IntPtr pointer)
		: base(pointer)
	{
	}
}
