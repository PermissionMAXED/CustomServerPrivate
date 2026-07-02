using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Local;
using Il2CppBAPBAP.Network;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;

namespace Il2CppBAPBAP.Entities;

public class NpcSearchTargetSubroutine : SimulationSubroutine
{
	private static readonly IntPtr NativeFieldInfoPtr_behaviour;

	private static readonly IntPtr NativeFieldInfoPtr_triggerFound;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_NpcBehaviour_Byte_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0;

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

	public unsafe byte triggerFound
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_triggerFound);
			return *(byte*)num;
		}
		set
		{
			*(byte*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_triggerFound)) = b;
		}
	}

	static NpcSearchTargetSubroutine()
	{
		Il2CppClassPointerStore<NpcSearchTargetSubroutine>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Entities", "NpcSearchTargetSubroutine");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<NpcSearchTargetSubroutine>.NativeClassPtr);
		NativeFieldInfoPtr_behaviour = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcSearchTargetSubroutine>.NativeClassPtr, "behaviour");
		NativeFieldInfoPtr_triggerFound = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcSearchTargetSubroutine>.NativeClassPtr, "triggerFound");
		NativeMethodInfoPtr__ctor_Public_Void_NpcBehaviour_Byte_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcSearchTargetSubroutine>.NativeClassPtr, 100675755);
		NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcSearchTargetSubroutine>.NativeClassPtr, 100675756);
	}

	[CallerCount(35)]
	[CachedScanResults(RefRangeStart = 123824, RefRangeEnd = 123859, XrefRangeStart = 123824, XrefRangeEnd = 123859, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe NpcSearchTargetSubroutine(NpcBehaviour _behaviour, byte _triggerFound)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<NpcSearchTargetSubroutine>.NativeClassPtr))
	{
		IntPtr* ptr = stackalloc IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_behaviour);
		*(byte**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &_triggerFound;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_NpcBehaviour_Byte_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 165089, XrefRangeEnd = 165095, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
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

	public NpcSearchTargetSubroutine(IntPtr pointer)
		: base(pointer)
	{
	}
}
