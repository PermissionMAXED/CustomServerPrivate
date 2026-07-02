using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using UnityEngine;

namespace Il2CppBAPBAP.Maps;

public static class VoronoiDiagramColor : Il2CppSystem.Object
{
	private static readonly System.IntPtr NativeMethodInfoPtr_GetDiagram_Public_Static_Texture2D_Il2CppStructArray_1_Vector2_Il2CppStructArray_1_Color_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetDiagramByDistance_Public_Static_Texture2D_Il2CppStructArray_1_Vector2_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetClosestCentroidIndex_Private_Static_Int32_Vector2_Il2CppStructArray_1_Vector2_0;

	static VoronoiDiagramColor()
	{
		Il2CppClassPointerStore<VoronoiDiagramColor>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Maps", "VoronoiDiagramColor");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<VoronoiDiagramColor>.NativeClassPtr);
		NativeMethodInfoPtr_GetDiagram_Public_Static_Texture2D_Il2CppStructArray_1_Vector2_Il2CppStructArray_1_Color_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<VoronoiDiagramColor>.NativeClassPtr, 100685954);
		NativeMethodInfoPtr_GetDiagramByDistance_Public_Static_Texture2D_Il2CppStructArray_1_Vector2_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<VoronoiDiagramColor>.NativeClassPtr, 100685955);
		NativeMethodInfoPtr_GetClosestCentroidIndex_Private_Static_Int32_Vector2_Il2CppStructArray_1_Vector2_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<VoronoiDiagramColor>.NativeClassPtr, 100685956);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 244037, RefRangeEnd = 244038, XrefRangeStart = 244026, XrefRangeEnd = 244037, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Texture2D GetDiagram(Il2CppStructArray<Vector2> pointsNorm, Il2CppStructArray<Color> colorPerPoints, int textureResolution)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)pointsNorm);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)colorPerPoints);
		*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &textureResolution;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetDiagram_Public_Static_Texture2D_Il2CppStructArray_1_Vector2_Il2CppStructArray_1_Color_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Texture2D>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 244038, XrefRangeEnd = 244052, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Texture2D GetDiagramByDistance(Il2CppStructArray<Vector2> pointsNorm, int textureResolution)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)pointsNorm);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &textureResolution;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetDiagramByDistance_Public_Static_Texture2D_Il2CppStructArray_1_Vector2_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Texture2D>(intPtr) : null;
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 244053, RefRangeEnd = 244055, XrefRangeStart = 244052, XrefRangeEnd = 244053, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static int GetClosestCentroidIndex(Vector2 pixelPos, Il2CppStructArray<Vector2> centroids)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&pixelPos);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)centroids);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetClosestCentroidIndex_Private_Static_Int32_Vector2_Il2CppStructArray_1_Vector2_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	public VoronoiDiagramColor(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
