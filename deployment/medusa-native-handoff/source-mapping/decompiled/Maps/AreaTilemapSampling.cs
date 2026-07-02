using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using UnityEngine;

namespace Il2CppBAPBAP.Maps;

public static class AreaTilemapSampling : Il2CppSystem.Object
{
	private static readonly System.IntPtr NativeMethodInfoPtr_SamplePoint_Public_Static_Boolean_byref_Vector2Int_AreaPoint_AreaPoint_Int32_Int32_Il2CppObjectBase_Vector2Int_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_IsValid_Public_Static_Boolean_AreaPoint_Vector2Int_Il2CppObjectBase_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_BuildHashAllModulePoints_Public_Static_Void_List_1_ModulePoint_Il2CppObjectBase_Int32_Vector2Int_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_BuildHashAllPoints_Public_Static_Void_List_1_AreaPoint_Il2CppObjectBase_Int32_Vector2Int_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_BuildAreaHash_Public_Static_Void_Vector2Int_Vector2Int_Int32_Il2CppObjectBase_Vector2Int_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_BuildHashIsolateBiomeFill_Public_Static_Void_Il2CppObjectBase_Il2CppObjectBase_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_BuildHashBiomeFill_Public_Static_Void_Il2CppObjectBase_Il2CppObjectBase_Int32_Int32_0;

	static AreaTilemapSampling()
	{
		Il2CppClassPointerStore<AreaTilemapSampling>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Maps", "AreaTilemapSampling");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<AreaTilemapSampling>.NativeClassPtr);
		NativeMethodInfoPtr_SamplePoint_Public_Static_Boolean_byref_Vector2Int_AreaPoint_AreaPoint_Int32_Int32_Il2CppObjectBase_Vector2Int_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<AreaTilemapSampling>.NativeClassPtr, 100685627);
		NativeMethodInfoPtr_IsValid_Public_Static_Boolean_AreaPoint_Vector2Int_Il2CppObjectBase_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<AreaTilemapSampling>.NativeClassPtr, 100685628);
		NativeMethodInfoPtr_BuildHashAllModulePoints_Public_Static_Void_List_1_ModulePoint_Il2CppObjectBase_Int32_Vector2Int_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<AreaTilemapSampling>.NativeClassPtr, 100685629);
		NativeMethodInfoPtr_BuildHashAllPoints_Public_Static_Void_List_1_AreaPoint_Il2CppObjectBase_Int32_Vector2Int_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<AreaTilemapSampling>.NativeClassPtr, 100685630);
		NativeMethodInfoPtr_BuildAreaHash_Public_Static_Void_Vector2Int_Vector2Int_Int32_Il2CppObjectBase_Vector2Int_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<AreaTilemapSampling>.NativeClassPtr, 100685631);
		NativeMethodInfoPtr_BuildHashIsolateBiomeFill_Public_Static_Void_Il2CppObjectBase_Il2CppObjectBase_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<AreaTilemapSampling>.NativeClassPtr, 100685632);
		NativeMethodInfoPtr_BuildHashBiomeFill_Public_Static_Void_Il2CppObjectBase_Il2CppObjectBase_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<AreaTilemapSampling>.NativeClassPtr, 100685633);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 239250, RefRangeEnd = 239253, XrefRangeStart = 239238, XrefRangeEnd = 239250, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static bool SamplePoint(out Vector2Int sampledPos, ProceduralLevelGeneration.AreaPoint spawnPoint, ProceduralLevelGeneration.AreaPoint candidate, int minDensity, int maxDensity, Il2CppObjectBase spatialHash, Vector2Int hashSize, int iterations = 10)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[8];
		*ptr = (nint)Unsafe.AsPointer(ref sampledPos);
		*(ProceduralLevelGeneration.AreaPoint**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &spawnPoint;
		*(ProceduralLevelGeneration.AreaPoint**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &candidate;
		*(int**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &minDensity;
		*(int**)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(System.IntPtr)))) = &maxDensity;
		*(System.IntPtr*)((byte*)ptr + checked((nuint)5u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr(spatialHash);
		*(Vector2Int**)((byte*)ptr + checked((nuint)6u * unchecked((nuint)sizeof(System.IntPtr)))) = &hashSize;
		*(int**)((byte*)ptr + checked((nuint)7u * unchecked((nuint)sizeof(System.IntPtr)))) = &iterations;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SamplePoint_Public_Static_Boolean_byref_Vector2Int_AreaPoint_AreaPoint_Int32_Int32_Il2CppObjectBase_Vector2Int_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 239265, RefRangeEnd = 239267, XrefRangeStart = 239253, XrefRangeEnd = 239265, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static bool IsValid(ProceduralLevelGeneration.AreaPoint candidate, Vector2Int hashSize, Il2CppObjectBase spatialHash)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = (nint)(&candidate);
		*(Vector2Int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &hashSize;
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr(spatialHash);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_IsValid_Public_Static_Boolean_AreaPoint_Vector2Int_Il2CppObjectBase_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(5)]
	[CachedScanResults(RefRangeStart = 239273, RefRangeEnd = 239278, XrefRangeStart = 239267, XrefRangeEnd = 239273, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void BuildHashAllModulePoints(List<ProceduralLevelGeneration.ModulePoint> modulePoints, Il2CppObjectBase spatialHash, int paddingAmount, Vector2Int tilemapSize)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[4];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)modulePoints);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr(spatialHash);
		*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &paddingAmount;
		*(Vector2Int**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &tilemapSize;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_BuildHashAllModulePoints_Public_Static_Void_List_1_ModulePoint_Il2CppObjectBase_Int32_Vector2Int_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 239284, RefRangeEnd = 239287, XrefRangeStart = 239278, XrefRangeEnd = 239284, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void BuildHashAllPoints(List<ProceduralLevelGeneration.AreaPoint> points, Il2CppObjectBase spatialHash, int paddingAmount, Vector2Int tilemapSize)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[4];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)points);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr(spatialHash);
		*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &paddingAmount;
		*(Vector2Int**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &tilemapSize;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_BuildHashAllPoints_Public_Static_Void_List_1_AreaPoint_Il2CppObjectBase_Int32_Vector2Int_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(5)]
	[CachedScanResults(RefRangeStart = 239294, RefRangeEnd = 239299, XrefRangeStart = 239287, XrefRangeEnd = 239294, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void BuildAreaHash(Vector2Int pointPos, Vector2Int pointSize, int paddingAmount, Il2CppObjectBase spatialHash, Vector2Int tilemapSize)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[5];
		*ptr = (nint)(&pointPos);
		*(Vector2Int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &pointSize;
		*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &paddingAmount;
		*(System.IntPtr*)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr(spatialHash);
		*(Vector2Int**)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(System.IntPtr)))) = &tilemapSize;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_BuildAreaHash_Public_Static_Void_Vector2Int_Vector2Int_Int32_Il2CppObjectBase_Vector2Int_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 239315, RefRangeEnd = 239318, XrefRangeStart = 239299, XrefRangeEnd = 239315, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void BuildHashIsolateBiomeFill(Il2CppObjectBase biomeIdGrid, Il2CppObjectBase spatialHash, int biomeIdToIsolate, int paddingAmount = 0)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[4];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr(biomeIdGrid);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr(spatialHash);
		*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &biomeIdToIsolate;
		*(int**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &paddingAmount;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_BuildHashIsolateBiomeFill_Public_Static_Void_Il2CppObjectBase_Il2CppObjectBase_Int32_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 239318, XrefRangeEnd = 239334, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void BuildHashBiomeFill(Il2CppObjectBase biomeIdGrid, Il2CppObjectBase spatialHash, int biomeIdToFill, int paddingAmount = 0)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[4];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr(biomeIdGrid);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr(spatialHash);
		*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &biomeIdToFill;
		*(int**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &paddingAmount;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_BuildHashBiomeFill_Public_Static_Void_Il2CppObjectBase_Il2CppObjectBase_Int32_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public AreaTilemapSampling(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
