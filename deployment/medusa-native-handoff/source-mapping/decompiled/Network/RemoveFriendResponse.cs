using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem;

namespace Il2CppBAPBAP.Network;

[System.Serializable]
public class RemoveFriendResponse : Il2CppSystem.Object
{
	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	static RemoveFriendResponse()
	{
		Il2CppClassPointerStore<RemoveFriendResponse>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Network", "RemoveFriendResponse");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<RemoveFriendResponse>.NativeClassPtr);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<RemoveFriendResponse>.NativeClassPtr, 100666587);
	}

	[CallerCount(5410)]
	[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe RemoveFriendResponse()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<RemoveFriendResponse>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public RemoveFriendResponse(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
