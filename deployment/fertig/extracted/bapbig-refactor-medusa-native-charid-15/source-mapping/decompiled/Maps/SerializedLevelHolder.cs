using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using UnityEngine;

namespace Il2CppBAPBAP.Maps;

public class SerializedLevelHolder : MonoBehaviour
{
	[System.Serializable]
	public class SerializedLevel : Il2CppSystem.Object
	{
		[System.Serializable]
		public class TilemapLayer : Il2CppSystem.Object
		{
			[System.Serializable]
			[StructLayout(LayoutKind.Explicit)]
			public struct SerializedTile
			{
				private static readonly System.IntPtr NativeFieldInfoPtr_gridIndex;

				private static readonly System.IntPtr NativeFieldInfoPtr_rotPrefabId;

				[FieldOffset(0)]
				public int gridIndex;

				[FieldOffset(4)]
				public int rotPrefabId;

				static SerializedTile()
				{
					Il2CppClassPointerStore<SerializedTile>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<TilemapLayer>.NativeClassPtr, "SerializedTile");
					IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<SerializedTile>.NativeClassPtr);
					NativeFieldInfoPtr_gridIndex = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SerializedTile>.NativeClassPtr, "gridIndex");
					NativeFieldInfoPtr_rotPrefabId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SerializedTile>.NativeClassPtr, "rotPrefabId");
				}

				public unsafe Il2CppSystem.Object BoxIl2CppObject()
				{
					return new Il2CppSystem.Object(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<SerializedTile>.NativeClassPtr, (System.IntPtr)(nint)Unsafe.AsPointer(ref this)));
				}
			}

			private static readonly System.IntPtr NativeFieldInfoPtr_tiles;

			private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

			public unsafe List<SerializedTile> tiles
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tiles);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<SerializedTile>>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tiles)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
				}
			}

			static TilemapLayer()
			{
				Il2CppClassPointerStore<TilemapLayer>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<SerializedLevel>.NativeClassPtr, "TilemapLayer");
				IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<TilemapLayer>.NativeClassPtr);
				NativeFieldInfoPtr_tiles = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TilemapLayer>.NativeClassPtr, "tiles");
				NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TilemapLayer>.NativeClassPtr, 100685466);
			}

			[CallerCount(0)]
			[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 236757, XrefRangeEnd = 236762, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
			public unsafe TilemapLayer()
				: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<TilemapLayer>.NativeClassPtr))
			{
				System.IntPtr* ptr = null;
				Unsafe.SkipInit(out System.IntPtr intPtr2);
				System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
				Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			}

			public TilemapLayer(System.IntPtr pointer)
				: base(pointer)
			{
			}
		}

		private static readonly System.IntPtr NativeFieldInfoPtr_mapSettings;

		private static readonly System.IntPtr NativeFieldInfoPtr_serializedMapTiles;

		private static readonly System.IntPtr NativeFieldInfoPtr_hideAreaTileGroups;

		private static readonly System.IntPtr NativeFieldInfoPtr_ceilingTileGroups;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_Reset_Public_Void_0;

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

		public unsafe TilemapLayer serializedMapTiles
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_serializedMapTiles);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TilemapLayer>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_serializedMapTiles)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)tilemapLayer));
			}
		}

		public unsafe Il2CppReferenceArray<TilemapLayer> hideAreaTileGroups
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_hideAreaTileGroups);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<TilemapLayer>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_hideAreaTileGroups)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
			}
		}

		public unsafe Il2CppReferenceArray<TilemapLayer> ceilingTileGroups
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ceilingTileGroups);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<TilemapLayer>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ceilingTileGroups)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
			}
		}

		static SerializedLevel()
		{
			Il2CppClassPointerStore<SerializedLevel>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<SerializedLevelHolder>.NativeClassPtr, "SerializedLevel");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<SerializedLevel>.NativeClassPtr);
			NativeFieldInfoPtr_mapSettings = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SerializedLevel>.NativeClassPtr, "mapSettings");
			NativeFieldInfoPtr_serializedMapTiles = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SerializedLevel>.NativeClassPtr, "serializedMapTiles");
			NativeFieldInfoPtr_hideAreaTileGroups = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SerializedLevel>.NativeClassPtr, "hideAreaTileGroups");
			NativeFieldInfoPtr_ceilingTileGroups = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SerializedLevel>.NativeClassPtr, "ceilingTileGroups");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SerializedLevel>.NativeClassPtr, 100685464);
			NativeMethodInfoPtr_Reset_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SerializedLevel>.NativeClassPtr, 100685465);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 236762, XrefRangeEnd = 236773, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe SerializedLevel()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<SerializedLevel>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 236773, XrefRangeEnd = 236783, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void Reset()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Reset_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public SerializedLevel(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public sealed class PrefabToId : Il2CppSystem.ValueType
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_prefabId;

		private static readonly System.IntPtr NativeFieldInfoPtr_prefab;

		public unsafe int prefabId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prefabId);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prefabId)) = num;
			}
		}

		public unsafe GameObject prefab
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prefab);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
			}
		}

		static PrefabToId()
		{
			Il2CppClassPointerStore<PrefabToId>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<SerializedLevelHolder>.NativeClassPtr, "PrefabToId");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<PrefabToId>.NativeClassPtr);
			NativeFieldInfoPtr_prefabId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PrefabToId>.NativeClassPtr, "prefabId");
			NativeFieldInfoPtr_prefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PrefabToId>.NativeClassPtr, "prefab");
		}

		public PrefabToId(System.IntPtr pointer)
			: base(pointer)
		{
		}

		public PrefabToId()
			: base(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<PrefabToId>.NativeClassPtr))
		{
		}
	}

	private static readonly System.IntPtr NativeFieldInfoPtr__serializedLevel;

	private static readonly System.IntPtr NativeFieldInfoPtr_spawnPoints;

	private static readonly System.IntPtr NativeFieldInfoPtr_dimensionSpawnPoints;

	private static readonly System.IntPtr NativeFieldInfoPtr_entityHolder;

	private static readonly System.IntPtr NativeFieldInfoPtr_bakedCollidersHolder;

	private static readonly System.IntPtr NativeFieldInfoPtr_objectHolder;

	private static readonly System.IntPtr NativeFieldInfoPtr_hideAreaHolders;

	private static readonly System.IntPtr NativeFieldInfoPtr_ceilingGroupObjHolders;

	private static readonly System.IntPtr NativeFieldInfoPtr_prefabIdLibrary;

	private static readonly System.IntPtr NativeMethodInfoPtr_NewSerializedLevel_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_serializedLevel_Public_get_SerializedLevel_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Serialize_Public_Void_LevelData_AssetPalette_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_MapTileToSerializedTile_Private_SerializedTile_MapTile_Vector2Int_Int32_AssetPalette_Dictionary_2_Int32_GameObject_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetSerializedTile_Private_SerializedTile_SerializedTile_AssetPalette_Dictionary_2_Int32_GameObject_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Deserialize_Public_Void_byref_LevelData_AssetPalette_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe SerializedLevel _serializedLevel
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__serializedLevel);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<SerializedLevel>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__serializedLevel)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)serializedLevel));
		}
	}

	public unsafe Il2CppReferenceArray<GameObject> spawnPoints
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spawnPoints);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<GameObject>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spawnPoints)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppReferenceArray<GameObject> dimensionSpawnPoints
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dimensionSpawnPoints);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<GameObject>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dimensionSpawnPoints)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Transform entityHolder
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_entityHolder);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Transform>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_entityHolder)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)transform));
		}
	}

	public unsafe Transform bakedCollidersHolder
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bakedCollidersHolder);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Transform>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bakedCollidersHolder)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)transform));
		}
	}

	public unsafe Transform objectHolder
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_objectHolder);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Transform>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_objectHolder)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)transform));
		}
	}

	public unsafe Il2CppReferenceArray<LevelHideAreaHolder> hideAreaHolders
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_hideAreaHolders);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<LevelHideAreaHolder>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_hideAreaHolders)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppReferenceArray<Transform> ceilingGroupObjHolders
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ceilingGroupObjHolders);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<Transform>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ceilingGroupObjHolders)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppReferenceArray<PrefabToId> prefabIdLibrary
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prefabIdLibrary);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<PrefabToId>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_prefabIdLibrary)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe SerializedLevel serializedLevel
	{
		[CallerCount(35)]
		[CachedScanResults(RefRangeStart = 30135, RefRangeEnd = 30170, XrefRangeStart = 30135, XrefRangeEnd = 30170, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_serializedLevel_Public_get_SerializedLevel_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<SerializedLevel>(intPtr) : null;
		}
	}

	static SerializedLevelHolder()
	{
		Il2CppClassPointerStore<SerializedLevelHolder>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Maps", "SerializedLevelHolder");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<SerializedLevelHolder>.NativeClassPtr);
		NativeFieldInfoPtr__serializedLevel = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SerializedLevelHolder>.NativeClassPtr, "_serializedLevel");
		NativeFieldInfoPtr_spawnPoints = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SerializedLevelHolder>.NativeClassPtr, "spawnPoints");
		NativeFieldInfoPtr_dimensionSpawnPoints = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SerializedLevelHolder>.NativeClassPtr, "dimensionSpawnPoints");
		NativeFieldInfoPtr_entityHolder = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SerializedLevelHolder>.NativeClassPtr, "entityHolder");
		NativeFieldInfoPtr_bakedCollidersHolder = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SerializedLevelHolder>.NativeClassPtr, "bakedCollidersHolder");
		NativeFieldInfoPtr_objectHolder = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SerializedLevelHolder>.NativeClassPtr, "objectHolder");
		NativeFieldInfoPtr_hideAreaHolders = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SerializedLevelHolder>.NativeClassPtr, "hideAreaHolders");
		NativeFieldInfoPtr_ceilingGroupObjHolders = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SerializedLevelHolder>.NativeClassPtr, "ceilingGroupObjHolders");
		NativeFieldInfoPtr_prefabIdLibrary = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SerializedLevelHolder>.NativeClassPtr, "prefabIdLibrary");
		NativeMethodInfoPtr_NewSerializedLevel_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SerializedLevelHolder>.NativeClassPtr, 100685457);
		NativeMethodInfoPtr_get_serializedLevel_Public_get_SerializedLevel_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SerializedLevelHolder>.NativeClassPtr, 100685458);
		NativeMethodInfoPtr_Serialize_Public_Void_LevelData_AssetPalette_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SerializedLevelHolder>.NativeClassPtr, 100685459);
		NativeMethodInfoPtr_MapTileToSerializedTile_Private_SerializedTile_MapTile_Vector2Int_Int32_AssetPalette_Dictionary_2_Int32_GameObject_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SerializedLevelHolder>.NativeClassPtr, 100685460);
		NativeMethodInfoPtr_SetSerializedTile_Private_SerializedTile_SerializedTile_AssetPalette_Dictionary_2_Int32_GameObject_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SerializedLevelHolder>.NativeClassPtr, 100685461);
		NativeMethodInfoPtr_Deserialize_Public_Void_byref_LevelData_AssetPalette_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SerializedLevelHolder>.NativeClassPtr, 100685462);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SerializedLevelHolder>.NativeClassPtr, 100685463);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 236783, XrefRangeEnd = 236796, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void NewSerializedLevel()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_NewSerializedLevel_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(17738)]
	[CachedScanResults(RefRangeStart = 5595, RefRangeEnd = 23333, XrefRangeStart = 5595, XrefRangeEnd = 23333, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Serialize(LevelData levelData, AssetPalette assetPalette)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)levelData);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)assetPalette);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Serialize_Public_Void_LevelData_AssetPalette_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 236796, XrefRangeEnd = 236807, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe SerializedLevel.TilemapLayer.SerializedTile MapTileToSerializedTile(MapTile tile, Vector2Int pos, int width, AssetPalette assetPalette, Dictionary<int, GameObject> library)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[5];
		*ptr = (nint)(&tile);
		*(Vector2Int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &pos;
		*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &width;
		*(System.IntPtr*)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)assetPalette);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)library);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_MapTileToSerializedTile_Private_SerializedTile_MapTile_Vector2Int_Int32_AssetPalette_Dictionary_2_Int32_GameObject_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(SerializedLevel.TilemapLayer.SerializedTile*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 236807, XrefRangeEnd = 236816, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe SerializedLevel.TilemapLayer.SerializedTile SetSerializedTile(SerializedLevel.TilemapLayer.SerializedTile tile, AssetPalette assetPalette, Dictionary<int, GameObject> library)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = (nint)(&tile);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)assetPalette);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)library);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetSerializedTile_Private_SerializedTile_SerializedTile_AssetPalette_Dictionary_2_Int32_GameObject_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(SerializedLevel.TilemapLayer.SerializedTile*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 236868, RefRangeEnd = 236870, XrefRangeStart = 236816, XrefRangeEnd = 236868, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Deserialize(out LevelData levelTilemap, AssetPalette assetPalette)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		nint num = 0;
		*ptr = (nint)(&num);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)assetPalette);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Deserialize_Public_Void_byref_LevelData_AssetPalette_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		nint num2 = num;
		levelTilemap = ((num2 == 0) ? null : new LevelData(num2));
	}

	[CallerCount(72)]
	[CachedScanResults(RefRangeStart = 5521, RefRangeEnd = 5593, XrefRangeStart = 5521, XrefRangeEnd = 5593, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe SerializedLevelHolder()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<SerializedLevelHolder>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public SerializedLevelHolder(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
