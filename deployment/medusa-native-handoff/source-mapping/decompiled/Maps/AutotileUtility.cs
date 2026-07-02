using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using UnityEngine;

namespace Il2CppBAPBAP.Maps;

public static class AutotileUtility : Il2CppSystem.Object
{
	[OriginalName("Assembly-CSharp.dll", "", "TileType")]
	public enum TileType
	{
		Center,
		EdgeTop,
		EdgeBottom,
		EdgeLeft,
		EdgeRight,
		InnerTop,
		InnerBottom,
		InnerLeft,
		InnerRight,
		OuterTop,
		OuterBottom,
		OuterLeft,
		OuterRight,
		OuterJoin1,
		OuterJoin2
	}

	private static readonly System.IntPtr NativeFieldInfoPtr_topDir;

	private static readonly System.IntPtr NativeFieldInfoPtr_rightDir;

	private static readonly System.IntPtr NativeFieldInfoPtr_bottomDir;

	private static readonly System.IntPtr NativeFieldInfoPtr_leftDir;

	private static readonly System.IntPtr NativeMethodInfoPtr_DoAutotile_Public_Static_TileType_Boolean_Boolean_Boolean_Boolean_Boolean_Boolean_Boolean_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetRotationIdFromTileType_Public_Static_Int32_TileType_AutotileAsset_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetVariationAssetTypeFromAutotileAsset_Public_Static_VariationAsset_TileType_AutotileAsset_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetPrefabTypeFromAutotileAsset_Public_Static_GameObject_TileType_AutotileAsset_0;

	public unsafe static int topDir
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_topDir, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_topDir, (void*)(&num));
		}
	}

	public unsafe static int rightDir
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_rightDir, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_rightDir, (void*)(&num));
		}
	}

	public unsafe static int bottomDir
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_bottomDir, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_bottomDir, (void*)(&num));
		}
	}

	public unsafe static int leftDir
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_leftDir, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_leftDir, (void*)(&num));
		}
	}

	static AutotileUtility()
	{
		Il2CppClassPointerStore<AutotileUtility>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Maps", "AutotileUtility");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<AutotileUtility>.NativeClassPtr);
		NativeFieldInfoPtr_topDir = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AutotileUtility>.NativeClassPtr, "topDir");
		NativeFieldInfoPtr_rightDir = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AutotileUtility>.NativeClassPtr, "rightDir");
		NativeFieldInfoPtr_bottomDir = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AutotileUtility>.NativeClassPtr, "bottomDir");
		NativeFieldInfoPtr_leftDir = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AutotileUtility>.NativeClassPtr, "leftDir");
		NativeMethodInfoPtr_DoAutotile_Public_Static_TileType_Boolean_Boolean_Boolean_Boolean_Boolean_Boolean_Boolean_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<AutotileUtility>.NativeClassPtr, 100685765);
		NativeMethodInfoPtr_GetRotationIdFromTileType_Public_Static_Int32_TileType_AutotileAsset_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<AutotileUtility>.NativeClassPtr, 100685766);
		NativeMethodInfoPtr_GetVariationAssetTypeFromAutotileAsset_Public_Static_VariationAsset_TileType_AutotileAsset_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<AutotileUtility>.NativeClassPtr, 100685767);
		NativeMethodInfoPtr_GetPrefabTypeFromAutotileAsset_Public_Static_GameObject_TileType_AutotileAsset_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<AutotileUtility>.NativeClassPtr, 100685768);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 241972, RefRangeEnd = 241975, XrefRangeStart = 241972, XrefRangeEnd = 241972, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static TileType DoAutotile(bool topNeighbor, bool leftNeighbor, bool rightNeighbor, bool botNeighbor, bool topLeftTileNeighbor, bool topRightTileNeighbor, bool botLeftTileNeighbor, bool botRightTileNeighbor)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[8];
		*ptr = (nint)(&topNeighbor);
		*(bool**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &leftNeighbor;
		*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &rightNeighbor;
		*(bool**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &botNeighbor;
		*(bool**)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(System.IntPtr)))) = &topLeftTileNeighbor;
		*(bool**)((byte*)ptr + checked((nuint)5u * unchecked((nuint)sizeof(System.IntPtr)))) = &topRightTileNeighbor;
		*(bool**)((byte*)ptr + checked((nuint)6u * unchecked((nuint)sizeof(System.IntPtr)))) = &botLeftTileNeighbor;
		*(bool**)((byte*)ptr + checked((nuint)7u * unchecked((nuint)sizeof(System.IntPtr)))) = &botRightTileNeighbor;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_DoAutotile_Public_Static_TileType_Boolean_Boolean_Boolean_Boolean_Boolean_Boolean_Boolean_Boolean_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(TileType*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 241975, RefRangeEnd = 241976, XrefRangeStart = 241975, XrefRangeEnd = 241975, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static int GetRotationIdFromTileType(TileType tileType, AssetPalette.AutotileAsset autotileAsset)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&tileType);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)autotileAsset);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetRotationIdFromTileType_Public_Static_Int32_TileType_AutotileAsset_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 241976, RefRangeEnd = 241977, XrefRangeStart = 241976, XrefRangeEnd = 241976, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static AssetPalette.VariationAsset GetVariationAssetTypeFromAutotileAsset(TileType tileType, AssetPalette.AutotileAsset autotileAsset)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&tileType);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)autotileAsset);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetVariationAssetTypeFromAutotileAsset_Public_Static_VariationAsset_TileType_AutotileAsset_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AssetPalette.VariationAsset>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 241977, XrefRangeEnd = 241995, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static GameObject GetPrefabTypeFromAutotileAsset(TileType tileType, AssetPalette.AutotileAsset autotileAsset)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&tileType);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)autotileAsset);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetPrefabTypeFromAutotileAsset_Public_Static_GameObject_TileType_AutotileAsset_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
	}

	public AutotileUtility(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
