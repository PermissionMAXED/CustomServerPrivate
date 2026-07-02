using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using UnityEngine.Events;

namespace Il2CppBAPBAP.UI;

[Serializable]
public class SDFSOEvent : UnityEvent<UberSDFSO>
{
	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	static SDFSOEvent()
	{
		Il2CppClassPointerStore<SDFSOEvent>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.UI", "SDFSOEvent");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<SDFSOEvent>.NativeClassPtr);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SDFSOEvent>.NativeClassPtr, 100671124);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 107635, XrefRangeEnd = 107637, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe SDFSOEvent()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<SDFSOEvent>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public SDFSOEvent(IntPtr pointer)
		: base(pointer)
	{
	}
}
