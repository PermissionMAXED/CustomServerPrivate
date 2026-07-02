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
public struct MeshInstanceBool
{
	private static readonly System.IntPtr NativeFieldInfoPtr_position;

	private static readonly System.IntPtr NativeFieldInfoPtr_radius;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_Vector3_Single_0;

	[FieldOffset(0)]
	public Vector3 position;

	[FieldOffset(12)]
	public float radius;

	static MeshInstanceBool()
	{
		Il2CppClassPointerStore<MeshInstanceBool>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Local.Rendering", "MeshInstanceBool");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<MeshInstanceBool>.NativeClassPtr);
		NativeFieldInfoPtr_position = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MeshInstanceBool>.NativeClassPtr, "position");
		NativeFieldInfoPtr_radius = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MeshInstanceBool>.NativeClassPtr, "radius");
		NativeMethodInfoPtr__ctor_Public_Void_Vector3_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MeshInstanceBool>.NativeClassPtr, 100685085);
	}

	[CallerCount(0)]
	public unsafe MeshInstanceBool(Vector3 position, float radius)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&position);
		*(float**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &radius;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_Vector3_Single_0, (System.IntPtr)(nint)Unsafe.AsPointer(ref this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public unsafe Il2CppSystem.Object BoxIl2CppObject()
	{
		return new Il2CppSystem.Object(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<MeshInstanceBool>.NativeClassPtr, (System.IntPtr)(nint)Unsafe.AsPointer(ref this)));
	}
}
