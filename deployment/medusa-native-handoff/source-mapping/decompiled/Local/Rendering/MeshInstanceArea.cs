using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppSystem;
using UnityEngine;

namespace Il2CppBAPBAP.Local.Rendering;

[System.Serializable]
[StructLayout(LayoutKind.Explicit)]
public struct MeshInstanceArea
{
	private static readonly System.IntPtr NativeFieldInfoPtr_position;

	private static readonly System.IntPtr NativeFieldInfoPtr_instanceCount;

	private static readonly System.IntPtr NativeFieldInfoPtr_shapeType;

	private static readonly System.IntPtr NativeFieldInfoPtr_mergeType;

	private static readonly System.IntPtr NativeFieldInfoPtr_rotation;

	private static readonly System.IntPtr NativeFieldInfoPtr_scale;

	private static readonly System.IntPtr NativeFieldInfoPtr_falloffStrength;

	private static readonly System.IntPtr NativeFieldInfoPtr_splatChannelMask;

	private static readonly System.IntPtr NativeFieldInfoPtr_splatChannelMaskThreshold;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_Vector3_Int32_Int32_Single_Single_Int32_Single_0;

	[FieldOffset(0)]
	public Vector3 position;

	[FieldOffset(12)]
	public int instanceCount;

	[FieldOffset(16)]
	public int shapeType;

	[FieldOffset(20)]
	public int mergeType;

	[FieldOffset(24)]
	public float rotation;

	[FieldOffset(28)]
	public float scale;

	[FieldOffset(32)]
	public float falloffStrength;

	[FieldOffset(36)]
	public int splatChannelMask;

	[FieldOffset(40)]
	public float splatChannelMaskThreshold;

	static MeshInstanceArea()
	{
		Il2CppClassPointerStore<MeshInstanceArea>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Local.Rendering", "MeshInstanceArea");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<MeshInstanceArea>.NativeClassPtr);
		NativeFieldInfoPtr_position = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MeshInstanceArea>.NativeClassPtr, "position");
		NativeFieldInfoPtr_instanceCount = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MeshInstanceArea>.NativeClassPtr, "instanceCount");
		NativeFieldInfoPtr_shapeType = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MeshInstanceArea>.NativeClassPtr, "shapeType");
		NativeFieldInfoPtr_mergeType = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MeshInstanceArea>.NativeClassPtr, "mergeType");
		NativeFieldInfoPtr_rotation = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MeshInstanceArea>.NativeClassPtr, "rotation");
		NativeFieldInfoPtr_scale = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MeshInstanceArea>.NativeClassPtr, "scale");
		NativeFieldInfoPtr_falloffStrength = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MeshInstanceArea>.NativeClassPtr, "falloffStrength");
		NativeFieldInfoPtr_splatChannelMask = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MeshInstanceArea>.NativeClassPtr, "splatChannelMask");
		NativeFieldInfoPtr_splatChannelMaskThreshold = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MeshInstanceArea>.NativeClassPtr, "splatChannelMaskThreshold");
		NativeMethodInfoPtr__ctor_Public_Void_Vector3_Int32_Int32_Single_Single_Int32_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MeshInstanceArea>.NativeClassPtr, 100685065);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 232206, XrefRangeEnd = 232209, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe MeshInstanceArea(Vector3 position, int instanceCount, int shapeType, float scale, float falloffStrength, int splatChannelMask, float splatChannelMaskThreshold)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[7];
		*ptr = (nint)(&position);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &instanceCount;
		*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &shapeType;
		*(float**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &scale;
		*(float**)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(System.IntPtr)))) = &falloffStrength;
		*(int**)((byte*)ptr + checked((nuint)5u * unchecked((nuint)sizeof(System.IntPtr)))) = &splatChannelMask;
		*(float**)((byte*)ptr + checked((nuint)6u * unchecked((nuint)sizeof(System.IntPtr)))) = &splatChannelMaskThreshold;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_Vector3_Int32_Int32_Single_Single_Int32_Single_0, (System.IntPtr)(nint)Unsafe.AsPointer(ref this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public unsafe Il2CppSystem.Object BoxIl2CppObject()
	{
		return new Il2CppSystem.Object(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<MeshInstanceArea>.NativeClassPtr, (System.IntPtr)(nint)Unsafe.AsPointer(ref this)));
	}
}
