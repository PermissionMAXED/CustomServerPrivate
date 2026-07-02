using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppMirror;
using Il2CppSystem;

namespace Il2CppBAPBAP.Utilities;

public static class BinaryUtility : Il2CppSystem.Object
{
	private static readonly System.IntPtr NativeMethodInfoPtr_ByteArrayToString_Public_Static_String_Il2CppStructArray_1_Byte_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ByteArraySegmentToString_Public_Static_String_ArraySegment_1_Byte_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_XOR_Public_Static_Void_NetworkWriter_NetworkWriter_NetworkWriter_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ZRLE_Public_Static_Void_NetworkWriter_NetworkWriter_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UnZRLE_Public_Static_Void_ArraySegment_1_Byte_NetworkWriter_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_IsEmpty_Public_Static_Boolean_NetworkWriter_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_UnsafeCompare_Public_Static_Boolean_Il2CppStructArray_1_Byte_Il2CppStructArray_1_Byte_0;

	static BinaryUtility()
	{
		Il2CppClassPointerStore<BinaryUtility>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Utilities", "BinaryUtility");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<BinaryUtility>.NativeClassPtr);
		NativeMethodInfoPtr_ByteArrayToString_Public_Static_String_Il2CppStructArray_1_Byte_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BinaryUtility>.NativeClassPtr, 100665212);
		NativeMethodInfoPtr_ByteArraySegmentToString_Public_Static_String_ArraySegment_1_Byte_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BinaryUtility>.NativeClassPtr, 100665213);
		NativeMethodInfoPtr_XOR_Public_Static_Void_NetworkWriter_NetworkWriter_NetworkWriter_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BinaryUtility>.NativeClassPtr, 100665214);
		NativeMethodInfoPtr_ZRLE_Public_Static_Void_NetworkWriter_NetworkWriter_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BinaryUtility>.NativeClassPtr, 100665215);
		NativeMethodInfoPtr_UnZRLE_Public_Static_Void_ArraySegment_1_Byte_NetworkWriter_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BinaryUtility>.NativeClassPtr, 100665216);
		NativeMethodInfoPtr_IsEmpty_Public_Static_Boolean_NetworkWriter_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BinaryUtility>.NativeClassPtr, 100665217);
		NativeMethodInfoPtr_UnsafeCompare_Public_Static_Boolean_Il2CppStructArray_1_Byte_Il2CppStructArray_1_Byte_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BinaryUtility>.NativeClassPtr, 100665218);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 51312, XrefRangeEnd = 51321, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static string ByteArrayToString(Il2CppStructArray<byte> ba, int maxBytes = -1)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)ba);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &maxBytes;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ByteArrayToString_Public_Static_String_Il2CppStructArray_1_Byte_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 51321, XrefRangeEnd = 51338, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static string ByteArraySegmentToString(Il2CppSystem.ArraySegment<byte> ba)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)ba));
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ByteArraySegmentToString_Public_Static_String_ArraySegment_1_Byte_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 51344, RefRangeEnd = 51346, XrefRangeStart = 51338, XrefRangeEnd = 51344, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void XOR(NetworkWriter previous, NetworkWriter current, NetworkWriter delta)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)previous);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)current);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)delta);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_XOR_Public_Static_Void_NetworkWriter_NetworkWriter_NetworkWriter_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 51346, XrefRangeEnd = 51348, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void ZRLE(NetworkWriter uncompressedInput, NetworkWriter compressedResult)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uncompressedInput);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)compressedResult);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ZRLE_Public_Static_Void_NetworkWriter_NetworkWriter_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 51348, XrefRangeEnd = 51356, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void UnZRLE(Il2CppSystem.ArraySegment<byte> compressedInput, NetworkWriter uncompressedResult)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)compressedInput));
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)uncompressedResult);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UnZRLE_Public_Static_Void_ArraySegment_1_Byte_NetworkWriter_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 51356, RefRangeEnd = 51358, XrefRangeStart = 51356, XrefRangeEnd = 51356, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static bool IsEmpty(NetworkWriter writer, int byteOffset = 0)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)writer);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &byteOffset;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_IsEmpty_Public_Static_Boolean_NetworkWriter_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 51358, XrefRangeEnd = 51362, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static bool UnsafeCompare(Il2CppStructArray<byte> a1, Il2CppStructArray<byte> a2)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)a1);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)a2);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UnsafeCompare_Public_Static_Boolean_Il2CppStructArray_1_Byte_Il2CppStructArray_1_Byte_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	public BinaryUtility(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
