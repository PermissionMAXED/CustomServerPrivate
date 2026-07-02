using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using UnityEngine;

namespace Il2CppBAPBAP.Utilities;

public static class CircleSectorMeshGenerator : Il2CppSystem.Object
{
	private static readonly System.IntPtr NativeMethodInfoPtr_Generate_Public_Static_Mesh_Single_Single_Single_0;

	static CircleSectorMeshGenerator()
	{
		Il2CppClassPointerStore<CircleSectorMeshGenerator>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Utilities", "CircleSectorMeshGenerator");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CircleSectorMeshGenerator>.NativeClassPtr);
		NativeMethodInfoPtr_Generate_Public_Static_Mesh_Single_Single_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CircleSectorMeshGenerator>.NativeClassPtr, 100665219);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 51388, RefRangeEnd = 51389, XrefRangeStart = 51362, XrefRangeEnd = 51388, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Mesh Generate(float viewAngle = 45f, float radius = 1f, float meshResolution = 0.5f)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = (nint)(&viewAngle);
		*(float**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &radius;
		*(float**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &meshResolution;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Generate_Public_Static_Mesh_Single_Single_Single_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Mesh>(intPtr) : null;
	}

	public CircleSectorMeshGenerator(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
