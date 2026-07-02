using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem;

namespace Il2CppBAPBAP.Network;

[System.Serializable]
public class XsollaPurchaseResponse : Il2CppSystem.Object
{
	private static readonly System.IntPtr NativeFieldInfoPtr_token;

	private static readonly System.IntPtr NativeFieldInfoPtr_url;

	private static readonly System.IntPtr NativeFieldInfoPtr_sandbox;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe string token
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_token);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_token)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string url
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_url);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_url)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe bool sandbox
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sandbox);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sandbox)) = flag;
		}
	}

	static XsollaPurchaseResponse()
	{
		Il2CppClassPointerStore<XsollaPurchaseResponse>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Network", "XsollaPurchaseResponse");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<XsollaPurchaseResponse>.NativeClassPtr);
		NativeFieldInfoPtr_token = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<XsollaPurchaseResponse>.NativeClassPtr, "token");
		NativeFieldInfoPtr_url = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<XsollaPurchaseResponse>.NativeClassPtr, "url");
		NativeFieldInfoPtr_sandbox = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<XsollaPurchaseResponse>.NativeClassPtr, "sandbox");
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<XsollaPurchaseResponse>.NativeClassPtr, 100666612);
	}

	[CallerCount(5410)]
	[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe XsollaPurchaseResponse()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<XsollaPurchaseResponse>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public XsollaPurchaseResponse(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
