using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem;

namespace Il2CppBAPBAP.Network;

[System.Serializable]
public class FriendRequestOpenBody : Il2CppSystem.Object
{
	private static readonly System.IntPtr NativeFieldInfoPtr_friendRequestsOpen;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe bool friendRequestsOpen
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendRequestsOpen);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_friendRequestsOpen)) = flag;
		}
	}

	static FriendRequestOpenBody()
	{
		Il2CppClassPointerStore<FriendRequestOpenBody>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Network", "FriendRequestOpenBody");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<FriendRequestOpenBody>.NativeClassPtr);
		NativeFieldInfoPtr_friendRequestsOpen = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<FriendRequestOpenBody>.NativeClassPtr, "friendRequestsOpen");
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<FriendRequestOpenBody>.NativeClassPtr, 100666480);
	}

	[CallerCount(5410)]
	[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe FriendRequestOpenBody()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<FriendRequestOpenBody>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public FriendRequestOpenBody(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
