using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using UnityEngine;

namespace Il2CppBAPBAP;

public class CharSimpleControls : MonoBehaviour
{
	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	static CharSimpleControls()
	{
		Il2CppClassPointerStore<CharSimpleControls>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP", "CharSimpleControls");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CharSimpleControls>.NativeClassPtr);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharSimpleControls>.NativeClassPtr, 100665164);
	}

	[CallerCount(72)]
	[CachedScanResults(RefRangeStart = 5521, RefRangeEnd = 5593, XrefRangeStart = 5521, XrefRangeEnd = 5593, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe CharSimpleControls()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CharSimpleControls>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public CharSimpleControls(IntPtr pointer)
		: base(pointer)
	{
	}
}
