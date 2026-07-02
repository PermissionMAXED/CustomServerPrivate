using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Local;
using Il2CppBAPBAP.Network;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;

namespace Il2CppBAPBAP.Entities;

public class NpcCastAbilitySubroutine : SimulationSubroutine
{
	private static readonly IntPtr NativeFieldInfoPtr_npcBehaviour;

	private static readonly IntPtr NativeFieldInfoPtr_ability;

	private static readonly IntPtr NativeFieldInfoPtr_trigger;

	private static readonly IntPtr NativeFieldInfoPtr_firstFrame;

	private static readonly IntPtr NativeFieldInfoPtr_aimRotationSpeed;

	private static readonly IntPtr NativeFieldInfoPtr_extraCd;

	private static readonly IntPtr NativeFieldInfoPtr_castFlag;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_NpcBehaviour_AbilityTriggerData_Byte_Single_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_NpcBehaviour_Ability_Byte_Single_Single_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnExit_Public_Virtual_Void_Single_Command_Boolean_0;

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

	public unsafe bool firstFrame
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_firstFrame);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_firstFrame)) = flag;
		}
	}

	public unsafe float aimRotationSpeed
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_aimRotationSpeed);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_aimRotationSpeed)) = num;
		}
	}

	public unsafe float extraCd
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_extraCd);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_extraCd)) = num;
		}
	}

	public unsafe CastFlags castFlag
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castFlag);
			return *(CastFlags*)num;
		}
		set
		{
			*(CastFlags*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castFlag)) = castFlags;
		}
	}

	static NpcCastAbilitySubroutine()
	{
		Il2CppClassPointerStore<NpcCastAbilitySubroutine>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Entities", "NpcCastAbilitySubroutine");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<NpcCastAbilitySubroutine>.NativeClassPtr);
		NativeFieldInfoPtr_npcBehaviour = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcCastAbilitySubroutine>.NativeClassPtr, "npcBehaviour");
		NativeFieldInfoPtr_ability = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcCastAbilitySubroutine>.NativeClassPtr, "ability");
		NativeFieldInfoPtr_trigger = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcCastAbilitySubroutine>.NativeClassPtr, "trigger");
		NativeFieldInfoPtr_firstFrame = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcCastAbilitySubroutine>.NativeClassPtr, "firstFrame");
		NativeFieldInfoPtr_aimRotationSpeed = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcCastAbilitySubroutine>.NativeClassPtr, "aimRotationSpeed");
		NativeFieldInfoPtr_extraCd = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcCastAbilitySubroutine>.NativeClassPtr, "extraCd");
		NativeFieldInfoPtr_castFlag = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcCastAbilitySubroutine>.NativeClassPtr, "castFlag");
		NativeMethodInfoPtr__ctor_Public_Void_NpcBehaviour_AbilityTriggerData_Byte_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcCastAbilitySubroutine>.NativeClassPtr, 100675721);
		NativeMethodInfoPtr__ctor_Public_Void_NpcBehaviour_Ability_Byte_Single_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcCastAbilitySubroutine>.NativeClassPtr, 100675722);
		NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcCastAbilitySubroutine>.NativeClassPtr, 100675723);
		NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcCastAbilitySubroutine>.NativeClassPtr, 100675724);
		NativeMethodInfoPtr_OnExit_Public_Virtual_Void_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcCastAbilitySubroutine>.NativeClassPtr, 100675725);
	}

	[CallerCount(9)]
	[CachedScanResults(RefRangeStart = 164874, RefRangeEnd = 164883, XrefRangeStart = 164873, XrefRangeEnd = 164874, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe NpcCastAbilitySubroutine(NpcBehaviour _npcBehaviour, AbilityTriggerData abilityData, byte _trigger, float _aimRotationSpeed = -2f)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<NpcCastAbilitySubroutine>.NativeClassPtr))
	{
		IntPtr* ptr = stackalloc IntPtr[4];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_npcBehaviour);
		*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)abilityData);
		*(byte**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = &_trigger;
		*(float**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(IntPtr)))) = &_aimRotationSpeed;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_NpcBehaviour_AbilityTriggerData_Byte_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(19)]
	[CachedScanResults(RefRangeStart = 164888, RefRangeEnd = 164907, XrefRangeStart = 164883, XrefRangeEnd = 164888, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe NpcCastAbilitySubroutine(NpcBehaviour _npcBehaviour, Ability _ability, byte _trigger, float _extraCd = 0f, float _aimRotationSpeed = -2f)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<NpcCastAbilitySubroutine>.NativeClassPtr))
	{
		IntPtr* ptr = stackalloc IntPtr[5];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_npcBehaviour);
		*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_ability);
		*(byte**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = &_trigger;
		*(float**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(IntPtr)))) = &_extraCd;
		*(float**)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(IntPtr)))) = &_aimRotationSpeed;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_NpcBehaviour_Ability_Byte_Single_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 164907, XrefRangeEnd = 164908, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
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
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 164908, XrefRangeEnd = 164909, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
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

	[CallerCount(0)]
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

	public NpcCastAbilitySubroutine(IntPtr pointer)
		: base(pointer)
	{
	}
}
