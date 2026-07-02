using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppLevelEditor;
using Il2CppSystem;
using Il2CppSystem.Diagnostics;
using Il2CppSystem.Text;
using UnityEngine;

namespace Il2CppBAPBAP.Maps;

public static class LevelTextureMapUtility : Il2CppSystem.Object
{
	private static readonly System.IntPtr NativeFieldInfoPtr_stopwatch;

	private static readonly System.IntPtr NativeFieldInfoPtr_debugData;

	private static readonly System.IntPtr NativeFieldInfoPtr_showLogs;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Config_Private_Static_get_Configuration_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CreateAndSetBiomeMapTexOnShader_Public_Static_Texture2D_BiomeData_Il2CppObjectBase_Vector2Int_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ForceSquare2DGrid_Private_Static_Il2CppObjectBase_Il2CppObjectBase_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetMapSplatMapOnShader_Public_Static_Void_Texture2D_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GenerateBiomeMapTexSquare_Public_Static_Texture2D_Il2CppObjectBase_Int32_BiomeData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetBiomeMapFromGroundTexMap_Public_Static_Il2CppObjectBase_Texture2D_BiomeData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GenerateBiomeTextureMapFromBiomePoints_Public_Static_Texture2D_Material_Il2CppStructArray_1_Vector2_Il2CppStructArray_1_Color_Vector2_Single_Single_Int32_BiomeData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GenerateIslandTextureMap_Public_Static_Void_Texture2D_AssetPalette_Material_Vector2_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_InvertSpatialHash_Public_Static_Void_byref_Il2CppObjectBase_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_AddSpatialHashes_Public_Static_Void_byref_Il2CppObjectBase_Il2CppObjectBase_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SubstractSpatialHashes_Public_Static_Void_byref_Il2CppObjectBase_Il2CppObjectBase_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ExpandHashByAmount_Public_Static_Void_Il2CppObjectBase_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ContractHashByAmount_Public_Static_Void_Il2CppObjectBase_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_TextureMapIntoSpatialHash_Public_Static_Il2CppObjectBase_Texture2D_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SpatialHashIntoTextureMap_Public_Static_Texture2D_Il2CppObjectBase_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SpatialHashIntoTextureMap_Public_Static_Texture2D_Il2CppObjectBase_Color_Color_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GridIntIntoTextureMap_Public_Static_Texture2D_Il2CppObjectBase_Il2CppStructArray_1_Color_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_DebugGridIntOnScene_Public_Static_GameObject_Int32_Il2CppObjectBase_String_GameObject_Il2CppStructArray_1_Color_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_DebugGridByteOnScene_Public_Static_GameObject_Int32_Il2CppObjectBase_String_GameObject_Il2CppStructArray_1_Color_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_DebugSpatialHashOnScene_Public_Static_GameObject_Int32_Il2CppObjectBase_String_GameObject_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_DebugSpatialHashColorOnScene_Public_Static_GameObject_Int32_Il2CppObjectBase_Color_Color_String_GameObject_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_DebugTextureMapOnScene_Public_Static_GameObject_Int32_Texture2D_String_GameObject_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_IsAreaOnHash_Public_Static_Boolean_AreaPoint_Vector2Int_Il2CppObjectBase_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ApplyDistortionPass_Public_Static_Void_Il2CppObjectBase_Texture2D_Single_Single_Vector2_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_RepairIsolatedPixels_Private_Static_Void_Texture2D_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_RepairIsolatedGridIds_Public_Static_Void_Il2CppObjectBase_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_RepairIsolatedHashCells_Public_Static_Void_Il2CppObjectBase_Vector2Int_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CreateWaterEdges_Private_Static_Void_Texture2D_Int32_Color_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetEdgePixels_Private_Static_Void_Il2CppStructArray_1_Color_Color_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetFalloffEdgePixels_Private_Static_Void_Il2CppStructArray_1_Color_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_BlitShaderToTexture_Public_Static_Void_Texture2D_Material_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetDistortMaterialSettings_Public_Static_Void_Material_Vector2_Single_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetBiomeGroundShaderSettings_Public_Static_Void_Texture2D_BiomeData_Int32_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetBiomeGroundColorMapValuesToShader_Private_Static_Void_Int32_ColorMapValues_0;

	public unsafe static Stopwatch stopwatch
	{
		get
		{
			Unsafe.SkipInit(out System.IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_stopwatch, (void*)(&intPtr));
			System.IntPtr intPtr2 = intPtr;
			return (intPtr2 != (System.IntPtr)0) ? Il2CppObjectPool.Get<Stopwatch>(intPtr2) : null;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_stopwatch, (void*)IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)stopwatch));
		}
	}

	public unsafe static StringBuilder debugData
	{
		get
		{
			Unsafe.SkipInit(out System.IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_debugData, (void*)(&intPtr));
			System.IntPtr intPtr2 = intPtr;
			return (intPtr2 != (System.IntPtr)0) ? Il2CppObjectPool.Get<StringBuilder>(intPtr2) : null;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_debugData, (void*)IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)stringBuilder));
		}
	}

	public unsafe static bool showLogs
	{
		get
		{
			Unsafe.SkipInit(out bool result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_showLogs, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_showLogs, (void*)(&flag));
		}
	}

	public unsafe static Configuration Config
	{
		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 242092, XrefRangeEnd = 242094, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Config_Private_Static_get_Configuration_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Configuration>(intPtr) : null;
		}
	}

	static LevelTextureMapUtility()
	{
		Il2CppClassPointerStore<LevelTextureMapUtility>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Maps", "LevelTextureMapUtility");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<LevelTextureMapUtility>.NativeClassPtr);
		NativeFieldInfoPtr_stopwatch = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelTextureMapUtility>.NativeClassPtr, "stopwatch");
		NativeFieldInfoPtr_debugData = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelTextureMapUtility>.NativeClassPtr, "debugData");
		NativeFieldInfoPtr_showLogs = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelTextureMapUtility>.NativeClassPtr, "showLogs");
		NativeMethodInfoPtr_get_Config_Private_Static_get_Configuration_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelTextureMapUtility>.NativeClassPtr, 100685775);
		NativeMethodInfoPtr_CreateAndSetBiomeMapTexOnShader_Public_Static_Texture2D_BiomeData_Il2CppObjectBase_Vector2Int_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelTextureMapUtility>.NativeClassPtr, 100685776);
		NativeMethodInfoPtr_ForceSquare2DGrid_Private_Static_Il2CppObjectBase_Il2CppObjectBase_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelTextureMapUtility>.NativeClassPtr, 100685777);
		NativeMethodInfoPtr_SetMapSplatMapOnShader_Public_Static_Void_Texture2D_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelTextureMapUtility>.NativeClassPtr, 100685778);
		NativeMethodInfoPtr_GenerateBiomeMapTexSquare_Public_Static_Texture2D_Il2CppObjectBase_Int32_BiomeData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelTextureMapUtility>.NativeClassPtr, 100685779);
		NativeMethodInfoPtr_GetBiomeMapFromGroundTexMap_Public_Static_Il2CppObjectBase_Texture2D_BiomeData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelTextureMapUtility>.NativeClassPtr, 100685780);
		NativeMethodInfoPtr_GenerateBiomeTextureMapFromBiomePoints_Public_Static_Texture2D_Material_Il2CppStructArray_1_Vector2_Il2CppStructArray_1_Color_Vector2_Single_Single_Int32_BiomeData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelTextureMapUtility>.NativeClassPtr, 100685781);
		NativeMethodInfoPtr_GenerateIslandTextureMap_Public_Static_Void_Texture2D_AssetPalette_Material_Vector2_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelTextureMapUtility>.NativeClassPtr, 100685782);
		NativeMethodInfoPtr_InvertSpatialHash_Public_Static_Void_byref_Il2CppObjectBase_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelTextureMapUtility>.NativeClassPtr, 100685783);
		NativeMethodInfoPtr_AddSpatialHashes_Public_Static_Void_byref_Il2CppObjectBase_Il2CppObjectBase_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelTextureMapUtility>.NativeClassPtr, 100685784);
		NativeMethodInfoPtr_SubstractSpatialHashes_Public_Static_Void_byref_Il2CppObjectBase_Il2CppObjectBase_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelTextureMapUtility>.NativeClassPtr, 100685785);
		NativeMethodInfoPtr_ExpandHashByAmount_Public_Static_Void_Il2CppObjectBase_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelTextureMapUtility>.NativeClassPtr, 100685786);
		NativeMethodInfoPtr_ContractHashByAmount_Public_Static_Void_Il2CppObjectBase_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelTextureMapUtility>.NativeClassPtr, 100685787);
		NativeMethodInfoPtr_TextureMapIntoSpatialHash_Public_Static_Il2CppObjectBase_Texture2D_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelTextureMapUtility>.NativeClassPtr, 100685788);
		NativeMethodInfoPtr_SpatialHashIntoTextureMap_Public_Static_Texture2D_Il2CppObjectBase_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelTextureMapUtility>.NativeClassPtr, 100685789);
		NativeMethodInfoPtr_SpatialHashIntoTextureMap_Public_Static_Texture2D_Il2CppObjectBase_Color_Color_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelTextureMapUtility>.NativeClassPtr, 100685790);
		NativeMethodInfoPtr_GridIntIntoTextureMap_Public_Static_Texture2D_Il2CppObjectBase_Il2CppStructArray_1_Color_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelTextureMapUtility>.NativeClassPtr, 100685791);
		NativeMethodInfoPtr_DebugGridIntOnScene_Public_Static_GameObject_Int32_Il2CppObjectBase_String_GameObject_Il2CppStructArray_1_Color_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelTextureMapUtility>.NativeClassPtr, 100685792);
		NativeMethodInfoPtr_DebugGridByteOnScene_Public_Static_GameObject_Int32_Il2CppObjectBase_String_GameObject_Il2CppStructArray_1_Color_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelTextureMapUtility>.NativeClassPtr, 100685793);
		NativeMethodInfoPtr_DebugSpatialHashOnScene_Public_Static_GameObject_Int32_Il2CppObjectBase_String_GameObject_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelTextureMapUtility>.NativeClassPtr, 100685794);
		NativeMethodInfoPtr_DebugSpatialHashColorOnScene_Public_Static_GameObject_Int32_Il2CppObjectBase_Color_Color_String_GameObject_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelTextureMapUtility>.NativeClassPtr, 100685795);
		NativeMethodInfoPtr_DebugTextureMapOnScene_Public_Static_GameObject_Int32_Texture2D_String_GameObject_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelTextureMapUtility>.NativeClassPtr, 100685796);
		NativeMethodInfoPtr_IsAreaOnHash_Public_Static_Boolean_AreaPoint_Vector2Int_Il2CppObjectBase_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelTextureMapUtility>.NativeClassPtr, 100685797);
		NativeMethodInfoPtr_ApplyDistortionPass_Public_Static_Void_Il2CppObjectBase_Texture2D_Single_Single_Vector2_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelTextureMapUtility>.NativeClassPtr, 100685798);
		NativeMethodInfoPtr_RepairIsolatedPixels_Private_Static_Void_Texture2D_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelTextureMapUtility>.NativeClassPtr, 100685799);
		NativeMethodInfoPtr_RepairIsolatedGridIds_Public_Static_Void_Il2CppObjectBase_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelTextureMapUtility>.NativeClassPtr, 100685800);
		NativeMethodInfoPtr_RepairIsolatedHashCells_Public_Static_Void_Il2CppObjectBase_Vector2Int_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelTextureMapUtility>.NativeClassPtr, 100685801);
		NativeMethodInfoPtr_CreateWaterEdges_Private_Static_Void_Texture2D_Int32_Color_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelTextureMapUtility>.NativeClassPtr, 100685802);
		NativeMethodInfoPtr_GetEdgePixels_Private_Static_Void_Il2CppStructArray_1_Color_Color_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelTextureMapUtility>.NativeClassPtr, 100685803);
		NativeMethodInfoPtr_GetFalloffEdgePixels_Private_Static_Void_Il2CppStructArray_1_Color_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelTextureMapUtility>.NativeClassPtr, 100685804);
		NativeMethodInfoPtr_BlitShaderToTexture_Public_Static_Void_Texture2D_Material_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelTextureMapUtility>.NativeClassPtr, 100685805);
		NativeMethodInfoPtr_SetDistortMaterialSettings_Public_Static_Void_Material_Vector2_Single_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelTextureMapUtility>.NativeClassPtr, 100685806);
		NativeMethodInfoPtr_SetBiomeGroundShaderSettings_Public_Static_Void_Texture2D_BiomeData_Int32_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelTextureMapUtility>.NativeClassPtr, 100685807);
		NativeMethodInfoPtr_SetBiomeGroundColorMapValuesToShader_Private_Static_Void_Int32_ColorMapValues_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelTextureMapUtility>.NativeClassPtr, 100685808);
	}

	[CallerCount(7)]
	[CachedScanResults(RefRangeStart = 242120, RefRangeEnd = 242127, XrefRangeStart = 242094, XrefRangeEnd = 242120, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Texture2D CreateAndSetBiomeMapTexOnShader(BiomeData biomeData, Il2CppObjectBase biomeMap, Vector2Int mapSize)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)biomeData);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr(biomeMap);
		*(Vector2Int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &mapSize;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CreateAndSetBiomeMapTexOnShader_Public_Static_Texture2D_BiomeData_Il2CppObjectBase_Vector2Int_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Texture2D>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 242127, XrefRangeEnd = 242133, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Il2CppObjectBase ForceSquare2DGrid(Il2CppObjectBase gridArray, int size)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr(gridArray);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &size;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ForceSquare2DGrid_Private_Static_Il2CppObjectBase_Il2CppObjectBase_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppObjectBase>(intPtr) : null;
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 242147, RefRangeEnd = 242149, XrefRangeStart = 242133, XrefRangeEnd = 242147, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void SetMapSplatMapOnShader(Texture2D splatMap)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)splatMap);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetMapSplatMapOnShader_Public_Static_Void_Texture2D_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 242169, RefRangeEnd = 242171, XrefRangeStart = 242149, XrefRangeEnd = 242169, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Texture2D GenerateBiomeMapTexSquare(Il2CppObjectBase biomeMap, int texMapSize, BiomeData biomeData)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr(biomeMap);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &texMapSize;
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)biomeData);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GenerateBiomeMapTexSquare_Public_Static_Texture2D_Il2CppObjectBase_Int32_BiomeData_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Texture2D>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 242171, XrefRangeEnd = 242179, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Il2CppObjectBase GetBiomeMapFromGroundTexMap(Texture2D groundTex, BiomeData biomeData)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)groundTex);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)biomeData);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetBiomeMapFromGroundTexMap_Public_Static_Il2CppObjectBase_Texture2D_BiomeData_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppObjectBase>(intPtr) : null;
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 242207, RefRangeEnd = 242208, XrefRangeStart = 242179, XrefRangeEnd = 242207, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Texture2D GenerateBiomeTextureMapFromBiomePoints(Material distortMat, Il2CppStructArray<Vector2> biomePointsNorm, Il2CppStructArray<Color> colorsByBiome, Vector2 flowMapOffset, float flowMapIntensity, float flowMapScale, int texResolution, BiomeData biomeData)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[8];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)distortMat);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)biomePointsNorm);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)colorsByBiome);
		*(Vector2**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &flowMapOffset;
		*(float**)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(System.IntPtr)))) = &flowMapIntensity;
		*(float**)((byte*)ptr + checked((nuint)5u * unchecked((nuint)sizeof(System.IntPtr)))) = &flowMapScale;
		*(int**)((byte*)ptr + checked((nuint)6u * unchecked((nuint)sizeof(System.IntPtr)))) = &texResolution;
		*(System.IntPtr*)((byte*)ptr + checked((nuint)7u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)biomeData);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GenerateBiomeTextureMapFromBiomePoints_Public_Static_Texture2D_Material_Il2CppStructArray_1_Vector2_Il2CppStructArray_1_Color_Vector2_Single_Single_Int32_BiomeData_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Texture2D>(intPtr) : null;
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 242224, RefRangeEnd = 242225, XrefRangeStart = 242208, XrefRangeEnd = 242224, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void GenerateIslandTextureMap(Texture2D textureMap, AssetPalette assetPalette, Material distortMat, Vector2 flowMapOffset, int texResolution)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[5];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)textureMap);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)assetPalette);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)distortMat);
		*(Vector2**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &flowMapOffset;
		*(int**)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(System.IntPtr)))) = &texResolution;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GenerateIslandTextureMap_Public_Static_Void_Texture2D_AssetPalette_Material_Vector2_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(7)]
	[CachedScanResults(RefRangeStart = 242229, RefRangeEnd = 242236, XrefRangeStart = 242225, XrefRangeEnd = 242229, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void InvertSpatialHash(ref Il2CppObjectBase spatialHash)
	{
		//IL_0033: Unknown result type (might be due to invalid IL or missing references)
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		System.IntPtr intPtr = IL2CPP.Il2CppObjectBaseToPtr(spatialHash);
		*ptr = (nint)(&intPtr);
		Unsafe.SkipInit(out System.IntPtr intPtr3);
		System.IntPtr intPtr2 = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_InvertSpatialHash_Public_Static_Void_byref_Il2CppObjectBase_0, (System.IntPtr)0, (void**)ptr, ref intPtr3);
		Il2CppException.RaiseExceptionIfNecessary(intPtr3);
		System.IntPtr intPtr4 = intPtr;
		spatialHash = ((intPtr4 == (System.IntPtr)0) ? ((Il2CppObjectBase)null) : new Il2CppObjectBase(intPtr4));
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 242240, RefRangeEnd = 242244, XrefRangeStart = 242236, XrefRangeEnd = 242240, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void AddSpatialHashes(ref Il2CppObjectBase hashA, Il2CppObjectBase hashB)
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		System.IntPtr intPtr = IL2CPP.Il2CppObjectBaseToPtr(hashA);
		*ptr = (nint)(&intPtr);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr(hashB);
		Unsafe.SkipInit(out System.IntPtr intPtr3);
		System.IntPtr intPtr2 = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_AddSpatialHashes_Public_Static_Void_byref_Il2CppObjectBase_Il2CppObjectBase_0, (System.IntPtr)0, (void**)ptr, ref intPtr3);
		Il2CppException.RaiseExceptionIfNecessary(intPtr3);
		System.IntPtr intPtr4 = intPtr;
		hashA = ((intPtr4 == (System.IntPtr)0) ? ((Il2CppObjectBase)null) : new Il2CppObjectBase(intPtr4));
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 242248, RefRangeEnd = 242252, XrefRangeStart = 242244, XrefRangeEnd = 242248, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void SubstractSpatialHashes(ref Il2CppObjectBase hashA, Il2CppObjectBase hashB)
	{
		//IL_0045: Unknown result type (might be due to invalid IL or missing references)
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		System.IntPtr intPtr = IL2CPP.Il2CppObjectBaseToPtr(hashA);
		*ptr = (nint)(&intPtr);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr(hashB);
		Unsafe.SkipInit(out System.IntPtr intPtr3);
		System.IntPtr intPtr2 = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SubstractSpatialHashes_Public_Static_Void_byref_Il2CppObjectBase_Il2CppObjectBase_0, (System.IntPtr)0, (void**)ptr, ref intPtr3);
		Il2CppException.RaiseExceptionIfNecessary(intPtr3);
		System.IntPtr intPtr4 = intPtr;
		hashA = ((intPtr4 == (System.IntPtr)0) ? ((Il2CppObjectBase)null) : new Il2CppObjectBase(intPtr4));
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 242260, RefRangeEnd = 242262, XrefRangeStart = 242252, XrefRangeEnd = 242260, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void ExpandHashByAmount(Il2CppObjectBase spatialHash, int amount)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr(spatialHash);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &amount;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ExpandHashByAmount_Public_Static_Void_Il2CppObjectBase_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 242262, XrefRangeEnd = 242270, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void ContractHashByAmount(Il2CppObjectBase spatialHash, int amount)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr(spatialHash);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &amount;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ContractHashByAmount_Public_Static_Void_Il2CppObjectBase_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 242277, RefRangeEnd = 242278, XrefRangeStart = 242270, XrefRangeEnd = 242277, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Il2CppObjectBase TextureMapIntoSpatialHash(Texture2D textureMap, float threshold = 0.5f)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)textureMap);
		*(float**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &threshold;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_TextureMapIntoSpatialHash_Public_Static_Il2CppObjectBase_Texture2D_Single_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppObjectBase>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 242278, XrefRangeEnd = 242281, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Texture2D SpatialHashIntoTextureMap(Il2CppObjectBase spatialHash)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr(spatialHash);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SpatialHashIntoTextureMap_Public_Static_Texture2D_Il2CppObjectBase_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Texture2D>(intPtr) : null;
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 242294, RefRangeEnd = 242297, XrefRangeStart = 242281, XrefRangeEnd = 242294, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Texture2D SpatialHashIntoTextureMap(Il2CppObjectBase spatialHash, Color emptyColor, Color fillColor)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr(spatialHash);
		*(Color**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &emptyColor;
		*(Color**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &fillColor;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SpatialHashIntoTextureMap_Public_Static_Texture2D_Il2CppObjectBase_Color_Color_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Texture2D>(intPtr) : null;
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 242327, RefRangeEnd = 242329, XrefRangeStart = 242297, XrefRangeEnd = 242327, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Texture2D GridIntIntoTextureMap(Il2CppObjectBase grid, Il2CppStructArray<Color> colorsByIndex = null)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr(grid);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)colorsByIndex);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GridIntIntoTextureMap_Public_Static_Texture2D_Il2CppObjectBase_Il2CppStructArray_1_Color_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Texture2D>(intPtr) : null;
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 242333, RefRangeEnd = 242334, XrefRangeStart = 242329, XrefRangeEnd = 242333, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static GameObject DebugGridIntOnScene(int unitSize, Il2CppObjectBase grid, string name = "debug_tex", GameObject testObj = null, Il2CppStructArray<Color> colorsByIndex = null)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[5];
		*ptr = (nint)(&unitSize);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr(grid);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(name);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)testObj);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)colorsByIndex);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_DebugGridIntOnScene_Public_Static_GameObject_Int32_Il2CppObjectBase_String_GameObject_Il2CppStructArray_1_Color_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 242344, RefRangeEnd = 242345, XrefRangeStart = 242334, XrefRangeEnd = 242344, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static GameObject DebugGridByteOnScene(int unitSize, Il2CppObjectBase grid, string name = "debug_tex", GameObject testObj = null, Il2CppStructArray<Color> colorsByIndex = null)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[5];
		*ptr = (nint)(&unitSize);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr(grid);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(name);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)testObj);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)colorsByIndex);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_DebugGridByteOnScene_Public_Static_GameObject_Int32_Il2CppObjectBase_String_GameObject_Il2CppStructArray_1_Color_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 242351, RefRangeEnd = 242353, XrefRangeStart = 242345, XrefRangeEnd = 242351, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static GameObject DebugSpatialHashOnScene(int unitSize, Il2CppObjectBase hash, string name = "debug_tex", GameObject testObj = null)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[4];
		*ptr = (nint)(&unitSize);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr(hash);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(name);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)testObj);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_DebugSpatialHashOnScene_Public_Static_GameObject_Int32_Il2CppObjectBase_String_GameObject_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 242353, XrefRangeEnd = 242357, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static GameObject DebugSpatialHashColorOnScene(int unitSize, Il2CppObjectBase hash, Color emptyColor, Color filledColor, string name = "debug_tex", GameObject testObj = null)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[6];
		*ptr = (nint)(&unitSize);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr(hash);
		*(Color**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &emptyColor;
		*(Color**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &filledColor;
		*(System.IntPtr*)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(name);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)5u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)testObj);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_DebugSpatialHashColorOnScene_Public_Static_GameObject_Int32_Il2CppObjectBase_Color_Color_String_GameObject_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
	}

	[CallerCount(9)]
	[CachedScanResults(RefRangeStart = 242389, RefRangeEnd = 242398, XrefRangeStart = 242357, XrefRangeEnd = 242389, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static GameObject DebugTextureMapOnScene(int unitSize, Texture2D tex, string name = "debug_tex", GameObject testObj = null)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[4];
		*ptr = (nint)(&unitSize);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tex);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(name);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)testObj);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_DebugTextureMapOnScene_Public_Static_GameObject_Int32_Texture2D_String_GameObject_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 242410, RefRangeEnd = 242411, XrefRangeStart = 242398, XrefRangeEnd = 242410, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static bool IsAreaOnHash(ProceduralLevelGeneration.AreaPoint candidate, Vector2Int hashSize, Il2CppObjectBase spatialHash)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = (nint)(&candidate);
		*(Vector2Int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &hashSize;
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr(spatialHash);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_IsAreaOnHash_Public_Static_Boolean_AreaPoint_Vector2Int_Il2CppObjectBase_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 242424, RefRangeEnd = 242427, XrefRangeStart = 242411, XrefRangeEnd = 242424, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void ApplyDistortionPass(Il2CppObjectBase grid, Texture2D flowMapTex, float flowMapFrequency, float flowMapAmplitude, Vector2 flowTexOffset)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[5];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr(grid);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)flowMapTex);
		*(float**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &flowMapFrequency;
		*(float**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &flowMapAmplitude;
		*(Vector2**)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(System.IntPtr)))) = &flowTexOffset;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ApplyDistortionPass_Public_Static_Void_Il2CppObjectBase_Texture2D_Single_Single_Vector2_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 242427, XrefRangeEnd = 242436, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void RepairIsolatedPixels(Texture2D biomeMap, int texResolution)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)biomeMap);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &texResolution;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_RepairIsolatedPixels_Private_Static_Void_Texture2D_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 242436, XrefRangeEnd = 242445, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void RepairIsolatedGridIds(Il2CppObjectBase idMap)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr(idMap);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_RepairIsolatedGridIds_Public_Static_Void_Il2CppObjectBase_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 242459, RefRangeEnd = 242461, XrefRangeStart = 242445, XrefRangeEnd = 242459, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void RepairIsolatedHashCells(Il2CppObjectBase hashMap, Vector2Int size)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr(hashMap);
		*(Vector2Int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &size;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_RepairIsolatedHashCells_Public_Static_Void_Il2CppObjectBase_Vector2Int_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 242461, XrefRangeEnd = 242476, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void CreateWaterEdges(Texture2D tex, int unitSize, Color colorMaskValue)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tex);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &unitSize;
		*(Color**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &colorMaskValue;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CreateWaterEdges_Private_Static_Void_Texture2D_Int32_Color_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 242476, XrefRangeEnd = 242480, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void GetEdgePixels(Il2CppStructArray<Color> pixels, Color edgeColor, int edgeWidth, int unitSize)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[4];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)pixels);
		*(Color**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &edgeColor;
		*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &edgeWidth;
		*(int**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &unitSize;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetEdgePixels_Private_Static_Void_Il2CppStructArray_1_Color_Color_Int32_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 242480, XrefRangeEnd = 242485, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void GetFalloffEdgePixels(Il2CppStructArray<Color> pixels, int edgeWidth, int unitSize)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)pixels);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &edgeWidth;
		*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &unitSize;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetFalloffEdgePixels_Private_Static_Void_Il2CppStructArray_1_Color_Int32_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 242493, RefRangeEnd = 242496, XrefRangeStart = 242485, XrefRangeEnd = 242493, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void BlitShaderToTexture(Texture2D tex, Material mat, int pass = 0)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tex);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)mat);
		*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &pass;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_BlitShaderToTexture_Public_Static_Void_Texture2D_Material_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 242504, RefRangeEnd = 242506, XrefRangeStart = 242496, XrefRangeEnd = 242504, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void SetDistortMaterialSettings(Material distortMat, Vector2 flowMapOffset, float flowMapIntensity = -1f, float flowMapScale = -1f)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[4];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)distortMat);
		*(Vector2**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &flowMapOffset;
		*(float**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &flowMapIntensity;
		*(float**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &flowMapScale;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetDistortMaterialSettings_Public_Static_Void_Material_Vector2_Single_Single_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 242519, RefRangeEnd = 242520, XrefRangeStart = 242506, XrefRangeEnd = 242519, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void SetBiomeGroundShaderSettings(Texture2D biomeColorMaskMap, BiomeData biomeData, int mapSize, bool doTransition)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[4];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)biomeColorMaskMap);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)biomeData);
		*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &mapSize;
		*(bool**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &doTransition;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetBiomeGroundShaderSettings_Public_Static_Void_Texture2D_BiomeData_Int32_Boolean_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 242557, RefRangeEnd = 242559, XrefRangeStart = 242520, XrefRangeEnd = 242557, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void SetBiomeGroundColorMapValuesToShader(int valueId, BiomeData.ColorMapValues colorMapValues)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&valueId);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)colorMapValues));
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetBiomeGroundColorMapValuesToShader_Private_Static_Void_Int32_ColorMapValues_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public LevelTextureMapUtility(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
