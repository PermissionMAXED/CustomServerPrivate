using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppSystem;
using UnityEngine;

namespace Il2CppBAPBAP.Maps;

[StructLayout(LayoutKind.Explicit)]
public struct BoundsData
{
	private static readonly System.IntPtr NativeFieldInfoPtr_center;

	private static readonly System.IntPtr NativeFieldInfoPtr_size;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_Vector3_Vector3_0;

	[FieldOffset(0)]
	public Vector3 center;

	[FieldOffset(12)]
	public Vector3 size;

	static BoundsData()
	{
		Il2CppClassPointerStore<BoundsData>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Maps", "BoundsData");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<BoundsData>.NativeClassPtr);
		NativeFieldInfoPtr_center = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoundsData>.NativeClassPtr, "center");
		NativeFieldInfoPtr_size = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BoundsData>.NativeClassPtr, "size");
		NativeMethodInfoPtr__ctor_Public_Void_Vector3_Vector3_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BoundsData>.NativeClassPtr, 100685769);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 223888, RefRangeEnd = 223889, XrefRangeStart = 223888, XrefRangeEnd = 223889, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe BoundsData(Vector3 center, Vector3 size)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&center);
		*(Vector3**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &size;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_Vector3_Vector3_0, (System.IntPtr)(nint)Unsafe.AsPointer(ref this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public unsafe Il2CppSystem.Object BoxIl2CppObject()
	{
		return new Il2CppSystem.Object(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<BoundsData>.NativeClassPtr, (System.IntPtr)(nint)Unsafe.AsPointer(ref this)));
	}
}
