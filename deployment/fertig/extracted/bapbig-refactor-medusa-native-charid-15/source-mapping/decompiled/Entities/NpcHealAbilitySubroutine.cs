using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Local;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;

namespace Il2CppBAPBAP.Entities;

public class NpcHealAbilitySubroutine : NpcCastAbilitySubroutine
{
	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_NpcBehaviour_AbilityTriggerData_Byte_Single_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0;

	static NpcHealAbilitySubroutine()
	{
		Il2CppClassPointerStore<NpcHealAbilitySubroutine>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Entities", "NpcHealAbilitySubroutine");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<NpcHealAbilitySubroutine>.NativeClassPtr);
		NativeMethodInfoPtr__ctor_Public_Void_NpcBehaviour_AbilityTriggerData_Byte_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcHealAbilitySubroutine>.NativeClassPtr, 100675745);
		NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcHealAbilitySubroutine>.NativeClassPtr, 100675746);
	}

	[CallerCount(9)]
	[CachedScanResults(RefRangeStart = 164874, RefRangeEnd = 164883, XrefRangeStart = 164874, XrefRangeEnd = 164883, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe NpcHealAbilitySubroutine(NpcBehaviour _npcBehaviour, AbilityTriggerData abilityData, byte _trigger, float _aimRotationSpeed = -2f)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<NpcHealAbilitySubroutine>.NativeClassPtr))
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

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 165037, XrefRangeEnd = 165042, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
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

	public NpcHealAbilitySubroutine(IntPtr pointer)
		: base(pointer)
	{
	}
}
