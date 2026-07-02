using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem;

namespace Il2CppBAPBAP.Network;

[System.Serializable]
public class SteamPurchaseBody : Il2CppSystem.Object
{
	private static readonly System.IntPtr NativeFieldInfoPtr_listingId;

	private static readonly System.IntPtr NativeFieldInfoPtr_recipientId;

	private static readonly System.IntPtr NativeFieldInfoPtr_costIndex;

	private static readonly System.IntPtr NativeFieldInfoPtr_steamId;

	private static readonly System.IntPtr NativeFieldInfoPtr_appId;

	private static readonly System.IntPtr NativeFieldInfoPtr_steamLanguage;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe string listingId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_listingId);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_listingId)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string recipientId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_recipientId);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_recipientId)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe int costIndex
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_costIndex);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_costIndex)) = num;
		}
	}

	public unsafe string steamId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_steamId);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_steamId)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string appId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_appId);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_appId)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe string steamLanguage
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_steamLanguage);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_steamLanguage)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	static SteamPurchaseBody()
	{
		Il2CppClassPointerStore<SteamPurchaseBody>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Network", "SteamPurchaseBody");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<SteamPurchaseBody>.NativeClassPtr);
		NativeFieldInfoPtr_listingId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SteamPurchaseBody>.NativeClassPtr, "listingId");
		NativeFieldInfoPtr_recipientId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SteamPurchaseBody>.NativeClassPtr, "recipientId");
		NativeFieldInfoPtr_costIndex = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SteamPurchaseBody>.NativeClassPtr, "costIndex");
		NativeFieldInfoPtr_steamId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SteamPurchaseBody>.NativeClassPtr, "steamId");
		NativeFieldInfoPtr_appId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SteamPurchaseBody>.NativeClassPtr, "appId");
		NativeFieldInfoPtr_steamLanguage = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SteamPurchaseBody>.NativeClassPtr, "steamLanguage");
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SteamPurchaseBody>.NativeClassPtr, 100666487);
	}

	[CallerCount(5410)]
	[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe SteamPurchaseBody()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<SteamPurchaseBody>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public SteamPurchaseBody(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
