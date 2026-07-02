using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppSystem;

namespace Il2CppBAPBAP.Entities.View;

[StructLayout(LayoutKind.Explicit)]
public struct SnapLerpData
{
	private static readonly System.IntPtr NativeFieldInfoPtr_tickNum;

	private static readonly System.IntPtr NativeFieldInfoPtr_snapped;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_Int32_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ToString_Public_Virtual_String_0;

	[FieldOffset(0)]
	public int tickNum;

	[FieldOffset(4)]
	[MarshalAs(UnmanagedType.U1)]
	public bool snapped;

	static SnapLerpData()
	{
		Il2CppClassPointerStore<SnapLerpData>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Entities.View", "SnapLerpData");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<SnapLerpData>.NativeClassPtr);
		NativeFieldInfoPtr_tickNum = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SnapLerpData>.NativeClassPtr, "tickNum");
		NativeFieldInfoPtr_snapped = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SnapLerpData>.NativeClassPtr, "snapped");
		NativeMethodInfoPtr__ctor_Public_Void_Int32_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SnapLerpData>.NativeClassPtr, 100682383);
		NativeMethodInfoPtr_ToString_Public_Virtual_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SnapLerpData>.NativeClassPtr, 100682384);
	}

	[CallerCount(28)]
	[CachedScanResults(RefRangeStart = 211110, RefRangeEnd = 211138, XrefRangeStart = 211110, XrefRangeEnd = 211110, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe SnapLerpData(int tickNum, bool snapped)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&tickNum);
		*(bool**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &snapped;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_Int32_Boolean_0, (System.IntPtr)(nint)Unsafe.AsPointer(ref this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 211138, XrefRangeEnd = 211144, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override string ToString()
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ToString_Public_Virtual_String_0, (System.IntPtr)(nint)Unsafe.AsPointer(ref this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	public unsafe Il2CppSystem.Object BoxIl2CppObject()
	{
		return new Il2CppSystem.Object(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<SnapLerpData>.NativeClassPtr, (System.IntPtr)(nint)Unsafe.AsPointer(ref this)));
	}
}
