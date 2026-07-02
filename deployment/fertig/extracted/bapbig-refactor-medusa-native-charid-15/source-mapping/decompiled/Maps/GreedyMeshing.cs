using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using UnityEngine;

namespace Il2CppBAPBAP.Maps;

public static class GreedyMeshing : Il2CppSystem.Object
{
	private static readonly System.IntPtr NativeMethodInfoPtr_GetSimplifiedBoundsFromWorldTilesV2_Public_Static_Il2CppStructArray_1_BoundsData_List_1_Vector2_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ExecuteGreedyMeshingV2_Private_Static_Il2CppStructArray_1_BoundsData_Int32_Int32_Il2CppObjectBase_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetSimplifiedBoundsFromWorldTiles_Public_Static_Il2CppStructArray_1_BoundsData_List_1_Vector2_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ExecuteGreedyMeshing_Private_Static_Il2CppStructArray_1_BoundsData_List_1_Vector2Int_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SearchTile_Private_Static_Boolean_Vector2Int_List_1_Vector2Int_0;

	static GreedyMeshing()
	{
		Il2CppClassPointerStore<GreedyMeshing>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Maps", "GreedyMeshing");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<GreedyMeshing>.NativeClassPtr);
		NativeMethodInfoPtr_GetSimplifiedBoundsFromWorldTilesV2_Public_Static_Il2CppStructArray_1_BoundsData_List_1_Vector2_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<GreedyMeshing>.NativeClassPtr, 100685770);
		NativeMethodInfoPtr_ExecuteGreedyMeshingV2_Private_Static_Il2CppStructArray_1_BoundsData_Int32_Int32_Il2CppObjectBase_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<GreedyMeshing>.NativeClassPtr, 100685771);
		NativeMethodInfoPtr_GetSimplifiedBoundsFromWorldTiles_Public_Static_Il2CppStructArray_1_BoundsData_List_1_Vector2_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<GreedyMeshing>.NativeClassPtr, 100685772);
		NativeMethodInfoPtr_ExecuteGreedyMeshing_Private_Static_Il2CppStructArray_1_BoundsData_List_1_Vector2Int_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<GreedyMeshing>.NativeClassPtr, 100685773);
		NativeMethodInfoPtr_SearchTile_Private_Static_Boolean_Vector2Int_List_1_Vector2Int_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<GreedyMeshing>.NativeClassPtr, 100685774);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 242011, RefRangeEnd = 242012, XrefRangeStart = 241995, XrefRangeEnd = 242011, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Il2CppStructArray<BoundsData> GetSimplifiedBoundsFromWorldTilesV2(List<Vector2> tilesWorldPositions)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tilesWorldPositions);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetSimplifiedBoundsFromWorldTilesV2_Public_Static_Il2CppStructArray_1_BoundsData_List_1_Vector2_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<BoundsData>>(intPtr) : null;
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 242035, RefRangeEnd = 242036, XrefRangeStart = 242012, XrefRangeEnd = 242035, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Il2CppStructArray<BoundsData> ExecuteGreedyMeshingV2(int xMin, int yMin, Il2CppObjectBase colliderMap)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = (nint)(&xMin);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &yMin;
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr(colliderMap);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ExecuteGreedyMeshingV2_Private_Static_Il2CppStructArray_1_BoundsData_Int32_Int32_Il2CppObjectBase_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<BoundsData>>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 242036, XrefRangeEnd = 242054, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Il2CppStructArray<BoundsData> GetSimplifiedBoundsFromWorldTiles(List<Vector2> tilesWorldPositions, int maxSearchIterations = 16)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tilesWorldPositions);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &maxSearchIterations;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetSimplifiedBoundsFromWorldTiles_Public_Static_Il2CppStructArray_1_BoundsData_List_1_Vector2_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<BoundsData>>(intPtr) : null;
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 242085, RefRangeEnd = 242086, XrefRangeStart = 242054, XrefRangeEnd = 242085, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Il2CppStructArray<BoundsData> ExecuteGreedyMeshing(List<Vector2Int> tilesPositions, int maxSearchIterations)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tilesPositions);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &maxSearchIterations;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ExecuteGreedyMeshing_Private_Static_Il2CppStructArray_1_BoundsData_List_1_Vector2Int_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<BoundsData>>(intPtr) : null;
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 242088, RefRangeEnd = 242092, XrefRangeStart = 242086, XrefRangeEnd = 242088, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static bool SearchTile(Vector2Int coords, List<Vector2Int> tileBoundsGrid)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&coords);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tileBoundsGrid);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SearchTile_Private_Static_Boolean_Vector2Int_List_1_Vector2Int_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	public GreedyMeshing(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
