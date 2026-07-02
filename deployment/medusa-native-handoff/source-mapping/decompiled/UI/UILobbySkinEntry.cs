using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;

namespace Il2CppBAPBAP.UI;

public class UILobbySkinEntry : UILobbyContentEntry
{
	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	static UILobbySkinEntry()
	{
		Il2CppClassPointerStore<UILobbySkinEntry>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.UI", "UILobbySkinEntry");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<UILobbySkinEntry>.NativeClassPtr);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<UILobbySkinEntry>.NativeClassPtr, 100668612);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 31858, RefRangeEnd = 31860, XrefRangeStart = 31858, XrefRangeEnd = 31860, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe UILobbySkinEntry()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<UILobbySkinEntry>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public UILobbySkinEntry(IntPtr pointer)
		: base(pointer)
	{
	}
}
