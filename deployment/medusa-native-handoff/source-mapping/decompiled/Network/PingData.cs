using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem;

namespace Il2CppBAPBAP.Network;

[System.Serializable]
public sealed class PingData : Il2CppSystem.ValueType
{
	private static readonly System.IntPtr NativeFieldInfoPtr_subdomain;

	private static readonly System.IntPtr NativeFieldInfoPtr_httpPort;

	private static readonly System.IntPtr NativeFieldInfoPtr_wsPort;

	private static readonly System.IntPtr NativeFieldInfoPtr_kcpPort;

	private static readonly System.IntPtr NativeFieldInfoPtr_tcpPort;

	private static readonly System.IntPtr NativeFieldInfoPtr_version;

	private static readonly System.IntPtr NativeFieldInfoPtr_status;

	private static readonly System.IntPtr NativeMethodInfoPtr_ToString_Public_Virtual_String_0;

	public unsafe string subdomain
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_subdomain);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_subdomain)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe int httpPort
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_httpPort);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_httpPort)) = num;
		}
	}

	public unsafe int wsPort
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wsPort);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wsPort)) = num;
		}
	}

	public unsafe int kcpPort
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_kcpPort);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_kcpPort)) = num;
		}
	}

	public unsafe int tcpPort
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tcpPort);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tcpPort)) = num;
		}
	}

	public unsafe string version
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_version);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_version)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe PingStatus status
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_status);
			return *(PingStatus*)num;
		}
		set
		{
			*(PingStatus*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_status)) = pingStatus;
		}
	}

	static PingData()
	{
		Il2CppClassPointerStore<PingData>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Network", "PingData");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<PingData>.NativeClassPtr);
		NativeFieldInfoPtr_subdomain = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PingData>.NativeClassPtr, "subdomain");
		NativeFieldInfoPtr_httpPort = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PingData>.NativeClassPtr, "httpPort");
		NativeFieldInfoPtr_wsPort = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PingData>.NativeClassPtr, "wsPort");
		NativeFieldInfoPtr_kcpPort = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PingData>.NativeClassPtr, "kcpPort");
		NativeFieldInfoPtr_tcpPort = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PingData>.NativeClassPtr, "tcpPort");
		NativeFieldInfoPtr_version = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PingData>.NativeClassPtr, "version");
		NativeFieldInfoPtr_status = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PingData>.NativeClassPtr, "status");
		NativeMethodInfoPtr_ToString_Public_Virtual_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PingData>.NativeClassPtr, 100666640);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 65167, XrefRangeEnd = 65203, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override string ToString()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ToString_Public_Virtual_String_0, IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this)), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	public PingData(System.IntPtr pointer)
		: base(pointer)
	{
	}

	public PingData()
		: base(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<PingData>.NativeClassPtr))
	{
	}
}
