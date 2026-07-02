using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem;

namespace Il2CppBAPBAP.Network;

[System.Serializable]
public class SetCreatorCodeRequest : Il2CppSystem.Object
{
	private static readonly System.IntPtr NativeFieldInfoPtr_creatorCode;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe string creatorCode
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_creatorCode);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_creatorCode)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	static SetCreatorCodeRequest()
	{
		Il2CppClassPointerStore<SetCreatorCodeRequest>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Network", "SetCreatorCodeRequest");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<SetCreatorCodeRequest>.NativeClassPtr);
		NativeFieldInfoPtr_creatorCode = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SetCreatorCodeRequest>.NativeClassPtr, "creatorCode");
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SetCreatorCodeRequest>.NativeClassPtr, 100666486);
	}

	[CallerCount(5410)]
	[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe SetCreatorCodeRequest()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<SetCreatorCodeRequest>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public SetCreatorCodeRequest(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
