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

public class NpcWanderingPosSubroutine : SimulationSubroutine
{
	private static readonly IntPtr NativeFieldInfoPtr_behaviour;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_NpcBehaviour_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetWanderingPositionToMove_Internal_Virtual_New_Void_Single_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetRandomWanderPositionInBRZone_Protected_Vector3_Single_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetRandomWanderPosition_Protected_Vector3_Single_0;

	public unsafe NpcBehaviour behaviour
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_behaviour);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<NpcBehaviour>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_behaviour)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)npcBehaviour));
		}
	}

	static NpcWanderingPosSubroutine()
	{
		Il2CppClassPointerStore<NpcWanderingPosSubroutine>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Entities", "NpcWanderingPosSubroutine");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<NpcWanderingPosSubroutine>.NativeClassPtr);
		NativeFieldInfoPtr_behaviour = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcWanderingPosSubroutine>.NativeClassPtr, "behaviour");
		NativeMethodInfoPtr__ctor_Public_Void_NpcBehaviour_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcWanderingPosSubroutine>.NativeClassPtr, 100675774);
		NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcWanderingPosSubroutine>.NativeClassPtr, 100675775);
		NativeMethodInfoPtr_GetWanderingPositionToMove_Internal_Virtual_New_Void_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcWanderingPosSubroutine>.NativeClassPtr, 100675776);
		NativeMethodInfoPtr_GetRandomWanderPositionInBRZone_Protected_Vector3_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcWanderingPosSubroutine>.NativeClassPtr, 100675777);
		NativeMethodInfoPtr_GetRandomWanderPosition_Protected_Vector3_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcWanderingPosSubroutine>.NativeClassPtr, 100675778);
	}

	[CallerCount(534)]
	[CachedScanResults(RefRangeStart = 124041, RefRangeEnd = 124575, XrefRangeStart = 124041, XrefRangeEnd = 124575, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe NpcWanderingPosSubroutine(NpcBehaviour _behaviour)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<NpcWanderingPosSubroutine>.NativeClassPtr))
	{
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_behaviour);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_NpcBehaviour_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
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

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 165149, XrefRangeEnd = 165168, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe virtual void GetWanderingPositionToMove(float maxDistFromCurrentPos = 50f)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&maxDistFromCurrentPos);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_GetWanderingPositionToMove_Internal_Virtual_New_Void_Single_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 165184, RefRangeEnd = 165186, XrefRangeStart = 165168, XrefRangeEnd = 165184, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Vector3 GetRandomWanderPositionInBRZone(float maxDistFromCurrentPos = 50f)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&maxDistFromCurrentPos);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetRandomWanderPositionInBRZone_Protected_Vector3_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(Vector3*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 165198, RefRangeEnd = 165200, XrefRangeStart = 165186, XrefRangeEnd = 165198, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Vector3 GetRandomWanderPosition(float maxDistFromCurrentPos = 50f)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&maxDistFromCurrentPos);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetRandomWanderPosition_Protected_Vector3_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(Vector3*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	public NpcWanderingPosSubroutine(IntPtr pointer)
		: base(pointer)
	{
	}
}
