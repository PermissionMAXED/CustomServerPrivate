using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem;

namespace Il2CppBAPBAP.Network;

[System.Serializable]
public class InternalServerData : Il2CppSystem.Object
{
	private static readonly System.IntPtr NativeFieldInfoPtr_hostname;

	private static readonly System.IntPtr NativeFieldInfoPtr_kcpPort;

	private static readonly System.IntPtr NativeFieldInfoPtr_tcpPort;

	private static readonly System.IntPtr NativeFieldInfoPtr_wsPort;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe string hostname
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_hostname);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_hostname)), IL2CPP.ManagedStringToIl2Cpp(text));
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

	static InternalServerData()
	{
		Il2CppClassPointerStore<InternalServerData>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Network", "InternalServerData");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<InternalServerData>.NativeClassPtr);
		NativeFieldInfoPtr_hostname = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InternalServerData>.NativeClassPtr, "hostname");
		NativeFieldInfoPtr_kcpPort = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InternalServerData>.NativeClassPtr, "kcpPort");
		NativeFieldInfoPtr_tcpPort = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InternalServerData>.NativeClassPtr, "tcpPort");
		NativeFieldInfoPtr_wsPort = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InternalServerData>.NativeClassPtr, "wsPort");
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InternalServerData>.NativeClassPtr, 100666554);
	}

	[CallerCount(5410)]
	[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe InternalServerData()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<InternalServerData>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public InternalServerData(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
