using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppSystem;

namespace Il2CppBAPBAP.Utilities;

[System.Serializable]
[StructLayout(LayoutKind.Explicit)]
public struct ByteRange
{
	private static readonly System.IntPtr NativeFieldInfoPtr_min;

	private static readonly System.IntPtr NativeFieldInfoPtr_max;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_Byte_Byte_0;

	[FieldOffset(0)]
	public byte min;

	[FieldOffset(1)]
	public byte max;

	static ByteRange()
	{
		Il2CppClassPointerStore<ByteRange>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Utilities", "ByteRange");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<ByteRange>.NativeClassPtr);
		NativeFieldInfoPtr_min = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ByteRange>.NativeClassPtr, "min");
		NativeFieldInfoPtr_max = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ByteRange>.NativeClassPtr, "max");
		NativeMethodInfoPtr__ctor_Public_Void_Byte_Byte_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ByteRange>.NativeClassPtr, 100665249);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 54364, RefRangeEnd = 54366, XrefRangeStart = 54364, XrefRangeEnd = 54364, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe ByteRange(byte min = 0, byte max = 1)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&min);
		*(byte**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &max;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_Byte_Byte_0, (System.IntPtr)(nint)Unsafe.AsPointer(ref this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public unsafe Il2CppSystem.Object BoxIl2CppObject()
	{
		return new Il2CppSystem.Object(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<ByteRange>.NativeClassPtr, (System.IntPtr)(nint)Unsafe.AsPointer(ref this)));
	}
}
