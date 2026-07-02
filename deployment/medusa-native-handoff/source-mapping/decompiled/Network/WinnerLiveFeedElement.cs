using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;

namespace Il2CppBAPBAP.Network;

[System.Serializable]
public class WinnerLiveFeedElement : Il2CppSystem.Object
{
	private static readonly System.IntPtr NativeFieldInfoPtr_squadKills;

	private static readonly System.IntPtr NativeFieldInfoPtr_endedAt;

	private static readonly System.IntPtr NativeFieldInfoPtr_usernames;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe int squadKills
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_squadKills);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_squadKills)) = num;
		}
	}

	public unsafe long endedAt
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_endedAt);
			return *(long*)num;
		}
		set
		{
			*(long*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_endedAt)) = num;
		}
	}

	public unsafe Il2CppStringArray usernames
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_usernames);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStringArray>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_usernames)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	static WinnerLiveFeedElement()
	{
		Il2CppClassPointerStore<WinnerLiveFeedElement>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Network", "WinnerLiveFeedElement");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<WinnerLiveFeedElement>.NativeClassPtr);
		NativeFieldInfoPtr_squadKills = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WinnerLiveFeedElement>.NativeClassPtr, "squadKills");
		NativeFieldInfoPtr_endedAt = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WinnerLiveFeedElement>.NativeClassPtr, "endedAt");
		NativeFieldInfoPtr_usernames = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<WinnerLiveFeedElement>.NativeClassPtr, "usernames");
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<WinnerLiveFeedElement>.NativeClassPtr, 100666445);
	}

	[CallerCount(5410)]
	[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe WinnerLiveFeedElement()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<WinnerLiveFeedElement>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public WinnerLiveFeedElement(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
