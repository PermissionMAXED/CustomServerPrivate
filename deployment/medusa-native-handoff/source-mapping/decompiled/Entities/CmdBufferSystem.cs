using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Local;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;

namespace Il2CppBAPBAP.Entities;

public class CmdBufferSystem : Il2CppSystem.Object
{
	private static readonly System.IntPtr NativeFieldInfoPtr_abilities;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_Il2CppReferenceArray_1_Ability_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_TickBuffers_Public_Void_Single_Command_0;

	public unsafe Il2CppReferenceArray<Ability> abilities
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_abilities);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<Ability>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_abilities)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	static CmdBufferSystem()
	{
		Il2CppClassPointerStore<CmdBufferSystem>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Entities", "CmdBufferSystem");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CmdBufferSystem>.NativeClassPtr);
		NativeFieldInfoPtr_abilities = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CmdBufferSystem>.NativeClassPtr, "abilities");
		NativeMethodInfoPtr__ctor_Public_Void_Il2CppReferenceArray_1_Ability_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CmdBufferSystem>.NativeClassPtr, 100678761);
		NativeMethodInfoPtr_TickBuffers_Public_Void_Single_Command_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CmdBufferSystem>.NativeClassPtr, 100678762);
	}

	[CallerCount(224)]
	[CachedScanResults(RefRangeStart = 23334, RefRangeEnd = 23558, XrefRangeStart = 23334, XrefRangeEnd = 23558, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe CmdBufferSystem(Il2CppReferenceArray<Ability> _abilities)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CmdBufferSystem>.NativeClassPtr))
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_abilities);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_Il2CppReferenceArray_1_Ability_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 182857, RefRangeEnd = 182858, XrefRangeStart = 182856, XrefRangeEnd = 182857, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void TickBuffers(float fixedDt, Command cmd)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&fixedDt);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cmd);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_TickBuffers_Public_Void_Single_Command_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public CmdBufferSystem(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
