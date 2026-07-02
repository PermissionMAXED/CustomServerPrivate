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
using UnityEngine.SceneManagement;

namespace Il2CppBAPBAP.Maps;

public static class MapUtility : Il2CppSystem.Object
{
	[ObfuscatedName("BAPBAP.Maps.MapUtility+<>c__DisplayClass36_0")]
	public sealed class __c__DisplayClass36_0 : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_targetLevelData;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__PlaceLevelOnLevelOnPos_b__0_Internal_Void_Vector2Int_MapLayer_Int32_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__PlaceLevelOnLevelOnPos_b__1_Internal_Void_Vector2Int_Int32_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__PlaceLevelOnLevelOnPos_b__2_Internal_Void_Vector2Int_Byte_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__PlaceLevelOnLevelOnPos_b__3_Internal_Void_Vector2Int_Color_0;

		public unsafe LevelData targetLevelData
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_targetLevelData);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<LevelData>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_targetLevelData)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)levelData));
			}
		}

		static __c__DisplayClass36_0()
		{
			Il2CppClassPointerStore<__c__DisplayClass36_0>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, "<>c__DisplayClass36_0");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c__DisplayClass36_0>.NativeClassPtr);
			NativeFieldInfoPtr_targetLevelData = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass36_0>.NativeClassPtr, "targetLevelData");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass36_0>.NativeClassPtr, 100685946);
			NativeMethodInfoPtr__PlaceLevelOnLevelOnPos_b__0_Internal_Void_Vector2Int_MapLayer_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass36_0>.NativeClassPtr, 100685947);
			NativeMethodInfoPtr__PlaceLevelOnLevelOnPos_b__1_Internal_Void_Vector2Int_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass36_0>.NativeClassPtr, 100685948);
			NativeMethodInfoPtr__PlaceLevelOnLevelOnPos_b__2_Internal_Void_Vector2Int_Byte_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass36_0>.NativeClassPtr, 100685949);
			NativeMethodInfoPtr__PlaceLevelOnLevelOnPos_b__3_Internal_Void_Vector2Int_Color_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass36_0>.NativeClassPtr, 100685950);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe __c__DisplayClass36_0()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<__c__DisplayClass36_0>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 243520, XrefRangeEnd = 243521, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _PlaceLevelOnLevelOnPos_b__0(Vector2Int pos, MapLayer layer, int rotPrefabId)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[3];
			*ptr = (nint)(&pos);
			*(MapLayer**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &layer;
			*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &rotPrefabId;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__PlaceLevelOnLevelOnPos_b__0_Internal_Void_Vector2Int_MapLayer_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		public unsafe void _PlaceLevelOnLevelOnPos_b__1(Vector2Int index, int biomeId)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[2];
			*ptr = (nint)(&index);
			*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &biomeId;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__PlaceLevelOnLevelOnPos_b__1_Internal_Void_Vector2Int_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		public unsafe void _PlaceLevelOnLevelOnPos_b__2(Vector2Int index, byte ambienceId)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[2];
			*ptr = (nint)(&index);
			*(byte**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &ambienceId;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__PlaceLevelOnLevelOnPos_b__2_Internal_Void_Vector2Int_Byte_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		public unsafe void _PlaceLevelOnLevelOnPos_b__3(Vector2Int index, Color splatPixel)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[2];
			*ptr = (nint)(&index);
			*(Color**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &splatPixel;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__PlaceLevelOnLevelOnPos_b__3_Internal_Void_Vector2Int_Color_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public __c__DisplayClass36_0(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[ObfuscatedName("BAPBAP.Maps.MapUtility+<>c__DisplayClass39_0")]
	public sealed class __c__DisplayClass39_0 : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_levelSize;

		private static readonly System.IntPtr NativeFieldInfoPtr_levelRotId;

		private static readonly System.IntPtr NativeFieldInfoPtr_assetPalette;

		private static readonly System.IntPtr NativeFieldInfoPtr_rotId;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe Vector2Int levelSize
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_levelSize);
				return *(Vector2Int*)num;
			}
			set
			{
				*(Vector2Int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_levelSize)) = vector2Int;
			}
		}

		public unsafe int levelRotId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_levelRotId);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_levelRotId)) = num;
			}
		}

		public unsafe AssetPalette assetPalette
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_assetPalette);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AssetPalette>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_assetPalette)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)assetPalette));
			}
		}

		public unsafe int rotId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rotId);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rotId)) = num;
			}
		}

		static __c__DisplayClass39_0()
		{
			Il2CppClassPointerStore<__c__DisplayClass39_0>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, "<>c__DisplayClass39_0");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c__DisplayClass39_0>.NativeClassPtr);
			NativeFieldInfoPtr_levelSize = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass39_0>.NativeClassPtr, "levelSize");
			NativeFieldInfoPtr_levelRotId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass39_0>.NativeClassPtr, "levelRotId");
			NativeFieldInfoPtr_assetPalette = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass39_0>.NativeClassPtr, "assetPalette");
			NativeFieldInfoPtr_rotId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass39_0>.NativeClassPtr, "rotId");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass39_0>.NativeClassPtr, 100685951);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe __c__DisplayClass39_0()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<__c__DisplayClass39_0>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public __c__DisplayClass39_0(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[ObfuscatedName("BAPBAP.Maps.MapUtility+<>c__DisplayClass39_1")]
	public sealed class __c__DisplayClass39_1 : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_newLayer;

		private static readonly System.IntPtr NativeFieldInfoPtr_field_Public___c__DisplayClass39_0_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__RotateLevelData_b__0_Internal_Void_MapTile_Vector2Int_0;

		public unsafe LevelData.Layer newLayer
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_newLayer);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<LevelData.Layer>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_newLayer)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)layer));
			}
		}

		public unsafe __c__DisplayClass39_0 field_Public___c__DisplayClass39_0_0
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_field_Public___c__DisplayClass39_0_0);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<__c__DisplayClass39_0>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_field_Public___c__DisplayClass39_0_0)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_c__DisplayClass39_));
			}
		}

		static __c__DisplayClass39_1()
		{
			Il2CppClassPointerStore<__c__DisplayClass39_1>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, "<>c__DisplayClass39_1");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c__DisplayClass39_1>.NativeClassPtr);
			NativeFieldInfoPtr_newLayer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass39_1>.NativeClassPtr, "newLayer");
			NativeFieldInfoPtr_field_Public___c__DisplayClass39_0_0 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass39_1>.NativeClassPtr, "CS$<>8__locals1");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass39_1>.NativeClassPtr, 100685952);
			NativeMethodInfoPtr__RotateLevelData_b__0_Internal_Void_MapTile_Vector2Int_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass39_1>.NativeClassPtr, 100685953);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe __c__DisplayClass39_1()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<__c__DisplayClass39_1>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 243521, XrefRangeEnd = 243527, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void _RotateLevelData_b__0(MapTile tile, Vector2Int pos)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[2];
			*ptr = (nint)(&tile);
			*(Vector2Int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &pos;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__RotateLevelData_b__0_Internal_Void_MapTile_Vector2Int_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public __c__DisplayClass39_1(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	private static readonly System.IntPtr NativeFieldInfoPtr__layerLength;

	private static readonly System.IntPtr NativeFieldInfoPtr_layers;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_layerLength_Public_Static_get_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetTilemapLayerFromPrefabId_Public_Static_MapLayer_Int32_AssetPalette_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetTilemapPosFromWorldPos_Public_Static_Vector2Int_Single_Single_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetTilemapPosFromWorldPos_Public_Static_Vector2Int_Vector3_Vector2Int_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetTilemapPosFromWorldPosRound_Public_Static_Vector2Int_Vector3_Vector2Int_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetTilemapPosFromWorldPosRound_Public_Static_Vector2Int_Single_Single_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetWorldPosFromTilemapPos_Public_Static_Vector2_Vector2Int_Vector2Int_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetWorldPosFromTilemapPos_Public_Static_Vector2_Int32_Int32_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetWorldPositionFromGridIndex_Public_Static_Vector2_Int32_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetTilemapPosFromGridIndex_Public_Static_Vector2Int_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetGridIndexFromTilemapPos_Public_Static_Int32_Vector2Int_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ClampArrayCoord_Public_Static_Int32_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetPrefabIdFromPrefabObj_Public_Static_Int32_GameObject_AssetPalette_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetPrefabObjFromRotatedPrefabId_Public_Static_GameObject_Int32_AssetPalette_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetPrefabObjFromPrefabId_Public_Static_GameObject_Int32_AssetPalette_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetRotatedPrefabId_Public_Static_Int32_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetPrefabIdFromRotatedPrefabId_Public_Static_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetPrefabDataFromPrefabId_Public_Static_PrefabData_Int32_AssetPalette_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetPrefabDataFromPrefab_Public_Static_PrefabData_GameObject_AssetPalette_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetRotIdFromPrefabRotatedId_Public_Static_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetAngleFromPrefabRotatedId_Public_Static_Single_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetAngleFromRotationId_Public_Static_Single_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetRotIdFromAngle_Public_Static_Int32_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SelectPrefabFromVariationAsset_Public_Static_GameObject_VariationAsset_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetRandomRotationIdFromVariationAsset_Public_Static_Int32_VariationAsset_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetMapObjectsSelection_Public_Static_List_1_GameObject_Vector2Int_Vector2Int_Vector2Int_MapLayer_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetMapObjectsSelection_Public_Static_List_1_GameObject_Vector2Int_Vector2Int_Vector2Int_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetMapObjectSelection_Public_Static_GameObject_Vector2Int_Vector2Int_Vector2Int_MapLayer_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetClosestObjectSelection_Public_Static_GameObject_Vector2_MapLayer_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetAllMapGameObjects_Public_Static_Il2CppReferenceArray_1_GameObject_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetAllMapGameObjects_Public_Static_Il2CppReferenceArray_1_GameObject_Scene_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_IsInvalidGameObjectToSelect_Private_Static_Boolean_GameObject_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_IsPrefab_Public_Static_Boolean_GameObject_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetPrefabFromMapObjInstance_Public_Static_GameObject_GameObject_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_PlaceLevelOnLevelOnPos_Public_Static_Void_Vector2Int_LevelData_LevelData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetLevelDataToLevelOnPos_Public_Static_Void_Vector2Int_LevelData_Vector2Int_Action_3_Vector2Int_MapLayer_Int32_Action_2_Vector2Int_Int32_Action_2_Vector2Int_Byte_Action_2_Vector2Int_Color_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetRotatedLevelOffsetAndSize_Public_Static_Void_Vector2Int_Int32_byref_Vector2Int_byref_Vector2Int_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_RotateLevelData_Public_Static_Void_LevelData_Int32_AssetPalette_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetRotatedGrid_Public_Static_Il2CppObjectBase_Il2CppObjectBase_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetRotatedGrid_Public_Static_Il2CppObjectBase_Il2CppObjectBase_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetRotatedPixelRect_Public_Static_Il2CppObjectBase_Il2CppObjectBase_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetRotatedTilePosition_Public_Static_Vector2Int_Vector2Int_Vector2Int_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetRotatedWorldPosition_Public_Static_Vector2_Vector2_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_RotatePrefabRotatedId_Public_Static_Int32_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_RotateAngleByRotationId_Public_Static_Int32_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Layers_Public_Static_get_IEnumerable_1_MapLayer_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_IterateThroughLayers_Public_Static_Void_Action_1_MapLayer_0;

	public unsafe static int _layerLength
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr__layerLength, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr__layerLength, (void*)(&num));
		}
	}

	public unsafe static IEnumerable<MapLayer> layers
	{
		get
		{
			Unsafe.SkipInit(out System.IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_layers, (void*)(&intPtr));
			System.IntPtr intPtr2 = intPtr;
			return (intPtr2 != (System.IntPtr)0) ? Il2CppObjectPool.Get<IEnumerable<MapLayer>>(intPtr2) : null;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_layers, (void*)IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)enumerable));
		}
	}

	public unsafe static int layerLength
	{
		[CallerCount(3)]
		[CachedScanResults(RefRangeStart = 243539, RefRangeEnd = 243542, XrefRangeStart = 243527, XrefRangeEnd = 243539, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_layerLength_Public_Static_get_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	public unsafe static IEnumerable<MapLayer> Layers
	{
		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 243992, RefRangeEnd = 243993, XrefRangeStart = 243980, XrefRangeEnd = 243992, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Layers_Public_Static_get_IEnumerable_1_MapLayer_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<IEnumerable<MapLayer>>(intPtr) : null;
		}
	}

	static MapUtility()
	{
		Il2CppClassPointerStore<MapUtility>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Maps", "MapUtility");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<MapUtility>.NativeClassPtr);
		NativeFieldInfoPtr__layerLength = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, "_layerLength");
		NativeFieldInfoPtr_layers = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, "layers");
		NativeMethodInfoPtr_get_layerLength_Public_Static_get_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685898);
		NativeMethodInfoPtr_GetTilemapLayerFromPrefabId_Public_Static_MapLayer_Int32_AssetPalette_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685899);
		NativeMethodInfoPtr_GetTilemapPosFromWorldPos_Public_Static_Vector2Int_Single_Single_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685900);
		NativeMethodInfoPtr_GetTilemapPosFromWorldPos_Public_Static_Vector2Int_Vector3_Vector2Int_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685901);
		NativeMethodInfoPtr_GetTilemapPosFromWorldPosRound_Public_Static_Vector2Int_Vector3_Vector2Int_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685902);
		NativeMethodInfoPtr_GetTilemapPosFromWorldPosRound_Public_Static_Vector2Int_Single_Single_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685903);
		NativeMethodInfoPtr_GetWorldPosFromTilemapPos_Public_Static_Vector2_Vector2Int_Vector2Int_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685904);
		NativeMethodInfoPtr_GetWorldPosFromTilemapPos_Public_Static_Vector2_Int32_Int32_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685905);
		NativeMethodInfoPtr_GetWorldPositionFromGridIndex_Public_Static_Vector2_Int32_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685906);
		NativeMethodInfoPtr_GetTilemapPosFromGridIndex_Public_Static_Vector2Int_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685907);
		NativeMethodInfoPtr_GetGridIndexFromTilemapPos_Public_Static_Int32_Vector2Int_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685908);
		NativeMethodInfoPtr_ClampArrayCoord_Public_Static_Int32_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685909);
		NativeMethodInfoPtr_GetPrefabIdFromPrefabObj_Public_Static_Int32_GameObject_AssetPalette_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685910);
		NativeMethodInfoPtr_GetPrefabObjFromRotatedPrefabId_Public_Static_GameObject_Int32_AssetPalette_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685911);
		NativeMethodInfoPtr_GetPrefabObjFromPrefabId_Public_Static_GameObject_Int32_AssetPalette_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685912);
		NativeMethodInfoPtr_GetRotatedPrefabId_Public_Static_Int32_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685913);
		NativeMethodInfoPtr_GetPrefabIdFromRotatedPrefabId_Public_Static_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685914);
		NativeMethodInfoPtr_GetPrefabDataFromPrefabId_Public_Static_PrefabData_Int32_AssetPalette_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685915);
		NativeMethodInfoPtr_GetPrefabDataFromPrefab_Public_Static_PrefabData_GameObject_AssetPalette_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685916);
		NativeMethodInfoPtr_GetRotIdFromPrefabRotatedId_Public_Static_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685917);
		NativeMethodInfoPtr_GetAngleFromPrefabRotatedId_Public_Static_Single_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685918);
		NativeMethodInfoPtr_GetAngleFromRotationId_Public_Static_Single_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685919);
		NativeMethodInfoPtr_GetRotIdFromAngle_Public_Static_Int32_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685920);
		NativeMethodInfoPtr_SelectPrefabFromVariationAsset_Public_Static_GameObject_VariationAsset_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685921);
		NativeMethodInfoPtr_GetRandomRotationIdFromVariationAsset_Public_Static_Int32_VariationAsset_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685922);
		NativeMethodInfoPtr_GetMapObjectsSelection_Public_Static_List_1_GameObject_Vector2Int_Vector2Int_Vector2Int_MapLayer_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685923);
		NativeMethodInfoPtr_GetMapObjectsSelection_Public_Static_List_1_GameObject_Vector2Int_Vector2Int_Vector2Int_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685924);
		NativeMethodInfoPtr_GetMapObjectSelection_Public_Static_GameObject_Vector2Int_Vector2Int_Vector2Int_MapLayer_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685925);
		NativeMethodInfoPtr_GetClosestObjectSelection_Public_Static_GameObject_Vector2_MapLayer_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685926);
		NativeMethodInfoPtr_GetAllMapGameObjects_Public_Static_Il2CppReferenceArray_1_GameObject_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685927);
		NativeMethodInfoPtr_GetAllMapGameObjects_Public_Static_Il2CppReferenceArray_1_GameObject_Scene_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685928);
		NativeMethodInfoPtr_IsInvalidGameObjectToSelect_Private_Static_Boolean_GameObject_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685929);
		NativeMethodInfoPtr_IsPrefab_Public_Static_Boolean_GameObject_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685930);
		NativeMethodInfoPtr_GetPrefabFromMapObjInstance_Public_Static_GameObject_GameObject_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685931);
		NativeMethodInfoPtr_PlaceLevelOnLevelOnPos_Public_Static_Void_Vector2Int_LevelData_LevelData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685932);
		NativeMethodInfoPtr_SetLevelDataToLevelOnPos_Public_Static_Void_Vector2Int_LevelData_Vector2Int_Action_3_Vector2Int_MapLayer_Int32_Action_2_Vector2Int_Int32_Action_2_Vector2Int_Byte_Action_2_Vector2Int_Color_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685933);
		NativeMethodInfoPtr_GetRotatedLevelOffsetAndSize_Public_Static_Void_Vector2Int_Int32_byref_Vector2Int_byref_Vector2Int_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685934);
		NativeMethodInfoPtr_RotateLevelData_Public_Static_Void_LevelData_Int32_AssetPalette_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685935);
		MapUtility.NativeMethodInfoPtr_GetRotatedGrid_Public_Static_Il2CppObjectBase_Il2CppObjectBase_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685936);
		MapUtility.NativeMethodInfoPtr_GetRotatedGrid_Public_Static_Il2CppObjectBase_Il2CppObjectBase_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685937);
		NativeMethodInfoPtr_GetRotatedPixelRect_Public_Static_Il2CppObjectBase_Il2CppObjectBase_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685938);
		NativeMethodInfoPtr_GetRotatedTilePosition_Public_Static_Vector2Int_Vector2Int_Vector2Int_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685939);
		NativeMethodInfoPtr_GetRotatedWorldPosition_Public_Static_Vector2_Vector2_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685940);
		NativeMethodInfoPtr_RotatePrefabRotatedId_Public_Static_Int32_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685941);
		NativeMethodInfoPtr_RotateAngleByRotationId_Public_Static_Int32_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685942);
		NativeMethodInfoPtr_get_Layers_Public_Static_get_IEnumerable_1_MapLayer_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685943);
		NativeMethodInfoPtr_IterateThroughLayers_Public_Static_Void_Action_1_MapLayer_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapUtility>.NativeClassPtr, 100685944);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 243542, RefRangeEnd = 243545, XrefRangeStart = 243542, XrefRangeEnd = 243542, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static MapLayer GetTilemapLayerFromPrefabId(int prefabId, AssetPalette assetPalette)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&prefabId);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)assetPalette);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetTilemapLayerFromPrefabId_Public_Static_MapLayer_Int32_AssetPalette_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(MapLayer*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(21)]
	[CachedScanResults(RefRangeStart = 243554, RefRangeEnd = 243575, XrefRangeStart = 243545, XrefRangeEnd = 243554, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Vector2Int GetTilemapPosFromWorldPos(float xWorldPos, float yWorldPos, int mapSizeX, int mapSizeY)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[4];
		*ptr = (nint)(&xWorldPos);
		*(float**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &yWorldPos;
		*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &mapSizeX;
		*(int**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &mapSizeY;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetTilemapPosFromWorldPos_Public_Static_Vector2Int_Single_Single_Int32_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(Vector2Int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 243575, XrefRangeEnd = 243586, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Vector2Int GetTilemapPosFromWorldPos(Vector3 worldPos, Vector2Int mapSize)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&worldPos);
		*(Vector2Int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &mapSize;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetTilemapPosFromWorldPos_Public_Static_Vector2Int_Vector3_Vector2Int_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(Vector2Int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 243593, RefRangeEnd = 243594, XrefRangeStart = 243586, XrefRangeEnd = 243593, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Vector2Int GetTilemapPosFromWorldPosRound(Vector3 worldPos, Vector2Int mapSize)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&worldPos);
		*(Vector2Int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &mapSize;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetTilemapPosFromWorldPosRound_Public_Static_Vector2Int_Vector3_Vector2Int_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(Vector2Int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(10)]
	[CachedScanResults(RefRangeStart = 243599, RefRangeEnd = 243609, XrefRangeStart = 243594, XrefRangeEnd = 243599, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Vector2Int GetTilemapPosFromWorldPosRound(float xWorldPos, float yWorldPos, int mapSizeX, int mapSizeY)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[4];
		*ptr = (nint)(&xWorldPos);
		*(float**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &yWorldPos;
		*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &mapSizeX;
		*(int**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &mapSizeY;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetTilemapPosFromWorldPosRound_Public_Static_Vector2Int_Single_Single_Int32_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(Vector2Int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 243611, RefRangeEnd = 243613, XrefRangeStart = 243609, XrefRangeEnd = 243611, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Vector2 GetWorldPosFromTilemapPos(Vector2Int tilemapPos, Vector2Int mapSize)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&tilemapPos);
		*(Vector2Int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &mapSize;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetWorldPosFromTilemapPos_Public_Static_Vector2_Vector2Int_Vector2Int_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(Vector2*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(13)]
	[CachedScanResults(RefRangeStart = 243613, RefRangeEnd = 243626, XrefRangeStart = 243613, XrefRangeEnd = 243613, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Vector2 GetWorldPosFromTilemapPos(int tilemapXPos, int tilemapYPos, int mapSizeX, int mapSizeY)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[4];
		*ptr = (nint)(&tilemapXPos);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &tilemapYPos;
		*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &mapSizeX;
		*(int**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &mapSizeY;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetWorldPosFromTilemapPos_Public_Static_Vector2_Int32_Int32_Int32_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(Vector2*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 243628, RefRangeEnd = 243630, XrefRangeStart = 243626, XrefRangeEnd = 243628, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Vector2 GetWorldPositionFromGridIndex(int gridIndex, int gridWidth, int gridHeight)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = (nint)(&gridIndex);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &gridWidth;
		*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &gridHeight;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetWorldPositionFromGridIndex_Public_Static_Vector2_Int32_Int32_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(Vector2*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(10)]
	[CachedScanResults(RefRangeStart = 243630, RefRangeEnd = 243640, XrefRangeStart = 243630, XrefRangeEnd = 243630, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Vector2Int GetTilemapPosFromGridIndex(int gridIndex, int gridWidth)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&gridIndex);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &gridWidth;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetTilemapPosFromGridIndex_Public_Static_Vector2Int_Int32_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(Vector2Int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 243640, RefRangeEnd = 243641, XrefRangeStart = 243640, XrefRangeEnd = 243640, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static int GetGridIndexFromTilemapPos(Vector2Int tilePos, int tilemapWidth)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&tilePos);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &tilemapWidth;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetGridIndexFromTilemapPos_Public_Static_Int32_Vector2Int_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 243641, RefRangeEnd = 243645, XrefRangeStart = 243641, XrefRangeEnd = 243641, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static int ClampArrayCoord(int coord, int arrayDimensionSize)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&coord);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &arrayDimensionSize;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ClampArrayCoord_Public_Static_Int32_Int32_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(20)]
	[CachedScanResults(RefRangeStart = 243647, RefRangeEnd = 243667, XrefRangeStart = 243645, XrefRangeEnd = 243647, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static int GetPrefabIdFromPrefabObj(GameObject sourcePrefab, AssetPalette assetPalette)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)sourcePrefab);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)assetPalette);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetPrefabIdFromPrefabObj_Public_Static_Int32_GameObject_AssetPalette_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(10)]
	[CachedScanResults(RefRangeStart = 243669, RefRangeEnd = 243679, XrefRangeStart = 243667, XrefRangeEnd = 243669, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static GameObject GetPrefabObjFromRotatedPrefabId(int rotatedPrefabId, AssetPalette assetPalette)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&rotatedPrefabId);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)assetPalette);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetPrefabObjFromRotatedPrefabId_Public_Static_GameObject_Int32_AssetPalette_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
	}

	[CallerCount(13)]
	[CachedScanResults(RefRangeStart = 243679, RefRangeEnd = 243692, XrefRangeStart = 243679, XrefRangeEnd = 243679, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static GameObject GetPrefabObjFromPrefabId(int prefabId, AssetPalette assetPalette)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&prefabId);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)assetPalette);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetPrefabObjFromPrefabId_Public_Static_GameObject_Int32_AssetPalette_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
	}

	[CallerCount(14)]
	[CachedScanResults(RefRangeStart = 243692, RefRangeEnd = 243706, XrefRangeStart = 243692, XrefRangeEnd = 243692, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static int GetRotatedPrefabId(int prefabId, int rotationId)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&prefabId);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &rotationId;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetRotatedPrefabId_Public_Static_Int32_Int32_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(27)]
	[CachedScanResults(RefRangeStart = 243706, RefRangeEnd = 243733, XrefRangeStart = 243706, XrefRangeEnd = 243706, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static int GetPrefabIdFromRotatedPrefabId(int prefabId)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&prefabId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetPrefabIdFromRotatedPrefabId_Public_Static_Int32_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(21)]
	[CachedScanResults(RefRangeStart = 243733, RefRangeEnd = 243754, XrefRangeStart = 243733, XrefRangeEnd = 243733, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static AssetPalette.PrefabData GetPrefabDataFromPrefabId(int prefabId, AssetPalette assetPalette)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&prefabId);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)assetPalette);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetPrefabDataFromPrefabId_Public_Static_PrefabData_Int32_AssetPalette_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AssetPalette.PrefabData>(intPtr) : null;
	}

	[CallerCount(7)]
	[CachedScanResults(RefRangeStart = 243758, RefRangeEnd = 243765, XrefRangeStart = 243754, XrefRangeEnd = 243758, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static AssetPalette.PrefabData GetPrefabDataFromPrefab(GameObject prefab, AssetPalette assetPalette)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)prefab);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)assetPalette);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetPrefabDataFromPrefab_Public_Static_PrefabData_GameObject_AssetPalette_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AssetPalette.PrefabData>(intPtr) : null;
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 243765, RefRangeEnd = 243769, XrefRangeStart = 243765, XrefRangeEnd = 243765, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static int GetRotIdFromPrefabRotatedId(int prefabRotatedId)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&prefabRotatedId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetRotIdFromPrefabRotatedId_Public_Static_Int32_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(10)]
	[CachedScanResults(RefRangeStart = 243771, RefRangeEnd = 243781, XrefRangeStart = 243769, XrefRangeEnd = 243771, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static float GetAngleFromPrefabRotatedId(int prefabRotatedId)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&prefabRotatedId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetAngleFromPrefabRotatedId_Public_Static_Single_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(float*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 243781, RefRangeEnd = 243782, XrefRangeStart = 243781, XrefRangeEnd = 243781, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static float GetAngleFromRotationId(int rotationId)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&rotationId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetAngleFromRotationId_Public_Static_Single_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(float*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(6)]
	[CachedScanResults(RefRangeStart = 243783, RefRangeEnd = 243789, XrefRangeStart = 243782, XrefRangeEnd = 243783, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static int GetRotIdFromAngle(float yRotation)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&yRotation);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetRotIdFromAngle_Public_Static_Int32_Single_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(9)]
	[CachedScanResults(RefRangeStart = 243791, RefRangeEnd = 243800, XrefRangeStart = 243789, XrefRangeEnd = 243791, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static GameObject SelectPrefabFromVariationAsset(AssetPalette.VariationAsset variationAsset)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)variationAsset);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SelectPrefabFromVariationAsset_Public_Static_GameObject_VariationAsset_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 243800, RefRangeEnd = 243802, XrefRangeStart = 243800, XrefRangeEnd = 243800, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static int GetRandomRotationIdFromVariationAsset(AssetPalette.VariationAsset variationAsset)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)variationAsset);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetRandomRotationIdFromVariationAsset_Public_Static_Int32_VariationAsset_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 243811, RefRangeEnd = 243813, XrefRangeStart = 243802, XrefRangeEnd = 243811, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static List<GameObject> GetMapObjectsSelection(Vector2Int mapSize, Vector2Int tileStartPos, Vector2Int tileEndPos, MapLayer mapLayer)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[4];
		*ptr = (nint)(&mapSize);
		*(Vector2Int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &tileStartPos;
		*(Vector2Int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &tileEndPos;
		*(MapLayer**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &mapLayer;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetMapObjectsSelection_Public_Static_List_1_GameObject_Vector2Int_Vector2Int_Vector2Int_MapLayer_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<GameObject>>(intPtr) : null;
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 243821, RefRangeEnd = 243824, XrefRangeStart = 243813, XrefRangeEnd = 243821, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static List<GameObject> GetMapObjectsSelection(Vector2Int mapSize, Vector2Int tileStartPos, Vector2Int tileEndPos)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = (nint)(&mapSize);
		*(Vector2Int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &tileStartPos;
		*(Vector2Int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &tileEndPos;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetMapObjectsSelection_Public_Static_List_1_GameObject_Vector2Int_Vector2Int_Vector2Int_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<GameObject>>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 243824, XrefRangeEnd = 243828, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static GameObject GetMapObjectSelection(Vector2Int mapSize, Vector2Int tileStartPos, Vector2Int tileEndPos, MapLayer mapLayer)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[4];
		*ptr = (nint)(&mapSize);
		*(Vector2Int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &tileStartPos;
		*(Vector2Int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &tileEndPos;
		*(MapLayer**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &mapLayer;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetMapObjectSelection_Public_Static_GameObject_Vector2Int_Vector2Int_Vector2Int_MapLayer_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 243833, RefRangeEnd = 243836, XrefRangeStart = 243828, XrefRangeEnd = 243833, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static GameObject GetClosestObjectSelection(Vector2 worldPos, MapLayer mapLayer, float searchRadius = 2f)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = (nint)(&worldPos);
		*(MapLayer**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &mapLayer;
		*(float**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &searchRadius;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetClosestObjectSelection_Public_Static_GameObject_Vector2_MapLayer_Single_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
	}

	[CallerCount(87)]
	[CachedScanResults(RefRangeStart = 32491, RefRangeEnd = 32578, XrefRangeStart = 32491, XrefRangeEnd = 32578, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Il2CppReferenceArray<GameObject> GetAllMapGameObjects()
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetAllMapGameObjects_Public_Static_Il2CppReferenceArray_1_GameObject_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<GameObject>>(intPtr) : null;
	}

	[CallerCount(87)]
	[CachedScanResults(RefRangeStart = 32491, RefRangeEnd = 32578, XrefRangeStart = 32491, XrefRangeEnd = 32578, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Il2CppReferenceArray<GameObject> GetAllMapGameObjects(Scene scene)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&scene);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetAllMapGameObjects_Public_Static_Il2CppReferenceArray_1_GameObject_Scene_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<GameObject>>(intPtr) : null;
	}

	[CallerCount(214)]
	[CachedScanResults(RefRangeStart = 28822, RefRangeEnd = 29036, XrefRangeStart = 28822, XrefRangeEnd = 29036, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static bool IsInvalidGameObjectToSelect(GameObject obj, bool onlyPrefabs = false)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)obj);
		*(bool**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &onlyPrefabs;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_IsInvalidGameObjectToSelect_Private_Static_Boolean_GameObject_Boolean_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(214)]
	[CachedScanResults(RefRangeStart = 28822, RefRangeEnd = 29036, XrefRangeStart = 28822, XrefRangeEnd = 29036, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static bool IsPrefab(GameObject instanceObj)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)instanceObj);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_IsPrefab_Public_Static_Boolean_GameObject_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(87)]
	[CachedScanResults(RefRangeStart = 32491, RefRangeEnd = 32578, XrefRangeStart = 32491, XrefRangeEnd = 32578, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static GameObject GetPrefabFromMapObjInstance(GameObject instanceObj)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)instanceObj);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetPrefabFromMapObjInstance_Public_Static_GameObject_GameObject_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 243859, RefRangeEnd = 243861, XrefRangeStart = 243836, XrefRangeEnd = 243859, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void PlaceLevelOnLevelOnPos(Vector2Int centerTilemapPos, LevelData levelDataToAdd, LevelData targetLevelData)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = (nint)(&centerTilemapPos);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)levelDataToAdd);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)targetLevelData);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_PlaceLevelOnLevelOnPos_Public_Static_Void_Vector2Int_LevelData_LevelData_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 243873, RefRangeEnd = 243876, XrefRangeStart = 243861, XrefRangeEnd = 243873, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void SetLevelDataToLevelOnPos(Vector2Int centerTilemapPos, LevelData levelDataToAdd, Vector2Int targetLevelSize, Il2CppSystem.Action<Vector2Int, MapLayer, int> addTileAction, Il2CppSystem.Action<Vector2Int, int> addBiomeMapAction, Il2CppSystem.Action<Vector2Int, byte> addAmbienceMapAction, Il2CppSystem.Action<Vector2Int, Color> addSplatMapAction)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[7];
		*ptr = (nint)(&centerTilemapPos);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)levelDataToAdd);
		*(Vector2Int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &targetLevelSize;
		*(System.IntPtr*)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)addTileAction);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)addBiomeMapAction);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)5u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)addAmbienceMapAction);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)6u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)addSplatMapAction);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetLevelDataToLevelOnPos_Public_Static_Void_Vector2Int_LevelData_Vector2Int_Action_3_Vector2Int_MapLayer_Int32_Action_2_Vector2Int_Int32_Action_2_Vector2Int_Byte_Action_2_Vector2Int_Color_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 243878, RefRangeEnd = 243881, XrefRangeStart = 243876, XrefRangeEnd = 243878, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void GetRotatedLevelOffsetAndSize(Vector2Int levelSize, int levelRotId, out Vector2Int tilemapRotOffset, out Vector2Int rotSize)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[4];
		*ptr = (nint)(&levelSize);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &levelRotId;
		*(void**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = Unsafe.AsPointer(ref tilemapRotOffset);
		*(void**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = Unsafe.AsPointer(ref rotSize);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetRotatedLevelOffsetAndSize_Public_Static_Void_Vector2Int_Int32_byref_Vector2Int_byref_Vector2Int_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 243937, RefRangeEnd = 243941, XrefRangeStart = 243881, XrefRangeEnd = 243937, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void RotateLevelData(LevelData levelData, int levelRotId, AssetPalette assetPalette)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)levelData);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &levelRotId;
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)assetPalette);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_RotateLevelData_Public_Static_Void_LevelData_Int32_AssetPalette_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 243941, XrefRangeEnd = 243951, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Il2CppObjectBase GetRotatedGrid(Il2CppObjectBase areaGrid, int levelRotId)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr(areaGrid);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &levelRotId;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(MapUtility.NativeMethodInfoPtr_GetRotatedGrid_Public_Static_Il2CppObjectBase_Il2CppObjectBase_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppObjectBase>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 243951, XrefRangeEnd = 243961, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Il2CppObjectBase GetRotatedGrid(Il2CppObjectBase areaGrid, int levelRotId)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr(areaGrid);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &levelRotId;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(MapUtility.NativeMethodInfoPtr_GetRotatedGrid_Public_Static_Il2CppObjectBase_Il2CppObjectBase_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppObjectBase>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 243961, XrefRangeEnd = 243971, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Il2CppObjectBase GetRotatedPixelRect(Il2CppObjectBase areaPixels, int levelRotId)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr(areaPixels);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &levelRotId;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetRotatedPixelRect_Public_Static_Il2CppObjectBase_Il2CppObjectBase_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppObjectBase>(intPtr) : null;
	}

	[CallerCount(6)]
	[CachedScanResults(RefRangeStart = 243971, RefRangeEnd = 243977, XrefRangeStart = 243971, XrefRangeEnd = 243971, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Vector2Int GetRotatedTilePosition(Vector2Int originalPosition, Vector2Int tilemapSize, int rotationId90)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = (nint)(&originalPosition);
		*(Vector2Int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &tilemapSize;
		*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &rotationId90;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetRotatedTilePosition_Public_Static_Vector2Int_Vector2Int_Vector2Int_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(Vector2Int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	public unsafe static Vector2 GetRotatedWorldPosition(Vector2 originalPosition, int rotationId90)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&originalPosition);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &rotationId90;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetRotatedWorldPosition_Public_Static_Vector2_Vector2_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(Vector2*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 243977, XrefRangeEnd = 243980, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static int RotatePrefabRotatedId(int originalRotatedPrefabId, int rotationId)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&originalRotatedPrefabId);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &rotationId;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_RotatePrefabRotatedId_Public_Static_Int32_Int32_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	public unsafe static int RotateAngleByRotationId(int angle, int rotationId)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&angle);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &rotationId;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_RotateAngleByRotationId_Public_Static_Int32_Int32_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(9)]
	[CachedScanResults(RefRangeStart = 244017, RefRangeEnd = 244026, XrefRangeStart = 243993, XrefRangeEnd = 244017, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void IterateThroughLayers(Il2CppSystem.Action<MapLayer> layerAction)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)layerAction);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_IterateThroughLayers_Public_Static_Void_Action_1_MapLayer_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public MapUtility(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
