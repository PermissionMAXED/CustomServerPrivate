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

public class LevelData : Il2CppSystem.Object
{
	public class Layer : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_tilemap;

		private static readonly System.IntPtr NativeFieldInfoPtr_rootGameObjects;

		private static readonly System.IntPtr NativeMethodInfoPtr_ForEachTile_Public_Void_Action_2_MapTile_Vector2Int_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_Clear_Public_Void_Vector2Int_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe Il2CppObjectBase tilemap
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tilemap);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppObjectBase>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tilemap)), IL2CPP.Il2CppObjectBaseToPtr(val));
			}
		}

		public unsafe List<GameObject> rootGameObjects
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rootGameObjects);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<GameObject>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rootGameObjects)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
			}
		}

		static Layer()
		{
			Il2CppClassPointerStore<Layer>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<LevelData>.NativeClassPtr, "Layer");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<Layer>.NativeClassPtr);
			NativeFieldInfoPtr_tilemap = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Layer>.NativeClassPtr, "tilemap");
			NativeFieldInfoPtr_rootGameObjects = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Layer>.NativeClassPtr, "rootGameObjects");
			NativeMethodInfoPtr_ForEachTile_Public_Void_Action_2_MapTile_Vector2Int_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Layer>.NativeClassPtr, 100685890);
			NativeMethodInfoPtr_Clear_Public_Void_Vector2Int_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Layer>.NativeClassPtr, 100685891);
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Layer>.NativeClassPtr, 100685892);
		}

		[CallerCount(7)]
		[CachedScanResults(RefRangeStart = 243227, RefRangeEnd = 243234, XrefRangeStart = 243224, XrefRangeEnd = 243227, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void ForEachTile(Il2CppSystem.Action<MapTile, Vector2Int> action)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ForEachTile_Public_Void_Action_2_MapTile_Vector2Int_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 243234, XrefRangeEnd = 243241, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void Clear(Vector2Int size)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = (nint)(&size);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Clear_Public_Void_Vector2Int_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe Layer()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<Layer>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public Layer(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	private static readonly System.IntPtr NativeFieldInfoPtr_layerGround;

	private static readonly System.IntPtr NativeFieldInfoPtr_layerObstacles;

	private static readonly System.IntPtr NativeFieldInfoPtr_layerDecoration;

	private static readonly System.IntPtr NativeFieldInfoPtr_layerHideAreas;

	private static readonly System.IntPtr NativeFieldInfoPtr_layerMapEntities;

	private static readonly System.IntPtr NativeFieldInfoPtr_layerCeiling;

	private static readonly System.IntPtr NativeFieldInfoPtr_mapSettings;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetTile_Public_Void_MapLayer_Vector2Int_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_layer_Public_Layer_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_layer_Public_Layer_MapLayer_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_LayerLength_Public_get_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_Vector2Int_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_LevelData_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetLevelSize_Public_Vector2Int_0;

	public unsafe Layer layerGround
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_layerGround);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Layer>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_layerGround)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)layer));
		}
	}

	public unsafe Layer layerObstacles
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_layerObstacles);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Layer>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_layerObstacles)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)layer));
		}
	}

	public unsafe Layer layerDecoration
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_layerDecoration);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Layer>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_layerDecoration)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)layer));
		}
	}

	public unsafe Layer layerHideAreas
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_layerHideAreas);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Layer>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_layerHideAreas)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)layer));
		}
	}

	public unsafe Layer layerMapEntities
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_layerMapEntities);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Layer>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_layerMapEntities)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)layer));
		}
	}

	public unsafe Layer layerCeiling
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_layerCeiling);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Layer>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_layerCeiling)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)layer));
		}
	}

	public unsafe MapSettings mapSettings
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_mapSettings);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<MapSettings>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_mapSettings)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)mapSettings));
		}
	}

	public unsafe int LayerLength
	{
		[CallerCount(15)]
		[CachedScanResults(RefRangeStart = 243293, RefRangeEnd = 243308, XrefRangeStart = 243279, XrefRangeEnd = 243293, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_LayerLength_Public_get_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	static LevelData()
	{
		Il2CppClassPointerStore<LevelData>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Maps", "LevelData");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<LevelData>.NativeClassPtr);
		NativeFieldInfoPtr_layerGround = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelData>.NativeClassPtr, "layerGround");
		NativeFieldInfoPtr_layerObstacles = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelData>.NativeClassPtr, "layerObstacles");
		NativeFieldInfoPtr_layerDecoration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelData>.NativeClassPtr, "layerDecoration");
		NativeFieldInfoPtr_layerHideAreas = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelData>.NativeClassPtr, "layerHideAreas");
		NativeFieldInfoPtr_layerMapEntities = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelData>.NativeClassPtr, "layerMapEntities");
		NativeFieldInfoPtr_layerCeiling = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelData>.NativeClassPtr, "layerCeiling");
		NativeFieldInfoPtr_mapSettings = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelData>.NativeClassPtr, "mapSettings");
		NativeMethodInfoPtr_SetTile_Public_Void_MapLayer_Vector2Int_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelData>.NativeClassPtr, 100685883);
		NativeMethodInfoPtr_layer_Public_Layer_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelData>.NativeClassPtr, 100685884);
		NativeMethodInfoPtr_layer_Public_Layer_MapLayer_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelData>.NativeClassPtr, 100685885);
		NativeMethodInfoPtr_get_LayerLength_Public_get_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelData>.NativeClassPtr, 100685886);
		NativeMethodInfoPtr__ctor_Public_Void_Vector2Int_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelData>.NativeClassPtr, 100685887);
		NativeMethodInfoPtr__ctor_Public_Void_LevelData_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelData>.NativeClassPtr, 100685888);
		NativeMethodInfoPtr_GetLevelSize_Public_Vector2Int_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelData>.NativeClassPtr, 100685889);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 243242, RefRangeEnd = 243243, XrefRangeStart = 243241, XrefRangeEnd = 243242, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetTile(MapLayer mapLayer, Vector2Int tilemapPos, int rotPrefabId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = (nint)(&mapLayer);
		*(Vector2Int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &tilemapPos;
		*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &rotPrefabId;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetTile_Public_Void_MapLayer_Vector2Int_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(16)]
	[CachedScanResults(RefRangeStart = 243248, RefRangeEnd = 243264, XrefRangeStart = 243243, XrefRangeEnd = 243248, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Layer layer(int layerIndex)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&layerIndex);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_layer_Public_Layer_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Layer>(intPtr) : null;
	}

	[CallerCount(15)]
	[CachedScanResults(RefRangeStart = 243264, RefRangeEnd = 243279, XrefRangeStart = 243264, XrefRangeEnd = 243264, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Layer layer(MapLayer mapLayer)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&mapLayer);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_layer_Public_Layer_MapLayer_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Layer>(intPtr) : null;
	}

	[CallerCount(8)]
	[CachedScanResults(RefRangeStart = 243349, RefRangeEnd = 243357, XrefRangeStart = 243308, XrefRangeEnd = 243349, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe LevelData(Vector2Int size)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<LevelData>.NativeClassPtr))
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&size);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_Vector2Int_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(7)]
	[CachedScanResults(RefRangeStart = 243392, RefRangeEnd = 243399, XrefRangeStart = 243357, XrefRangeEnd = 243392, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe LevelData(LevelData levelData, bool deepCopy = false)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<LevelData>.NativeClassPtr))
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)levelData);
		*(bool**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &deepCopy;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_LevelData_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(35)]
	[CachedScanResults(RefRangeStart = 243404, RefRangeEnd = 243439, XrefRangeStart = 243399, XrefRangeEnd = 243404, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Vector2Int GetLevelSize()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetLevelSize_Public_Vector2Int_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(Vector2Int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	public LevelData(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
