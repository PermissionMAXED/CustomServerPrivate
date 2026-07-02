using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem;

namespace Il2CppBAPBAP.Network;

[System.Serializable]
public class ErrorResponse : Il2CppSystem.Object
{
	private static readonly System.IntPtr NativeFieldInfoPtr_responseCode;

	private static readonly System.IntPtr NativeFieldInfoPtr_errorCode;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe long responseCode
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_responseCode);
			return *(long*)num;
		}
		set
		{
			*(long*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_responseCode)) = num;
		}
	}

	public unsafe string errorCode
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_errorCode);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_errorCode)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	static ErrorResponse()
	{
		Il2CppClassPointerStore<ErrorResponse>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Network", "ErrorResponse");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<ErrorResponse>.NativeClassPtr);
		NativeFieldInfoPtr_responseCode = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ErrorResponse>.NativeClassPtr, "responseCode");
		NativeFieldInfoPtr_errorCode = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ErrorResponse>.NativeClassPtr, "errorCode");
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ErrorResponse>.NativeClassPtr, 100666537);
	}

	[CallerCount(5410)]
	[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe ErrorResponse()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<ErrorResponse>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public ErrorResponse(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
