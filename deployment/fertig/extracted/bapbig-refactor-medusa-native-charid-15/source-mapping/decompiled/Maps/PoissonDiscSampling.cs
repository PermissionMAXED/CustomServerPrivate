using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using UnityEngine;

namespace Il2CppBAPBAP.Maps;

public static class PoissonDiscSampling : Il2CppSystem.Object
{
	private static readonly System.IntPtr NativeMethodInfoPtr_GeneratePoints_Public_Static_List_1_Vector2_Single_Vector2_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_IsValid_Private_Static_Boolean_Vector2_Vector2_Single_Single_List_1_Vector2_Il2CppObjectBase_0;

	static PoissonDiscSampling()
	{
		Il2CppClassPointerStore<PoissonDiscSampling>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Maps", "PoissonDiscSampling");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<PoissonDiscSampling>.NativeClassPtr);
		NativeMethodInfoPtr_GeneratePoints_Public_Static_List_1_Vector2_Single_Vector2_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PoissonDiscSampling>.NativeClassPtr, 100685760);
		NativeMethodInfoPtr_IsValid_Private_Static_Boolean_Vector2_Vector2_Single_Single_List_1_Vector2_Il2CppObjectBase_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PoissonDiscSampling>.NativeClassPtr, 100685761);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 241944, RefRangeEnd = 241945, XrefRangeStart = 241909, XrefRangeEnd = 241944, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static List<Vector2> GeneratePoints(float radius, Vector2 sampleRegionSize, int numSamplesBeforeRejection = 30)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = (nint)(&radius);
		*(Vector2**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &sampleRegionSize;
		*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &numSamplesBeforeRejection;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GeneratePoints_Public_Static_List_1_Vector2_Single_Vector2_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<Vector2>>(intPtr) : null;
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 241951, RefRangeEnd = 241952, XrefRangeStart = 241945, XrefRangeEnd = 241951, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static bool IsValid(Vector2 candidate, Vector2 sampleRegionSize, float cellSize, float radius, List<Vector2> points, Il2CppObjectBase grid)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[6];
		*ptr = (nint)(&candidate);
		*(Vector2**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &sampleRegionSize;
		*(float**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &cellSize;
		*(float**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &radius;
		*(System.IntPtr*)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)points);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)5u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr(grid);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_IsValid_Private_Static_Boolean_Vector2_Vector2_Single_Single_List_1_Vector2_Il2CppObjectBase_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	public PoissonDiscSampling(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
