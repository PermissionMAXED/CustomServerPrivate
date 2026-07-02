using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Il2CppBAPBAP.Utilities;
using Il2CppDelaunay.Geo;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppLevelEditor;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using UnityEngine;

namespace Il2CppBAPBAP.Maps;

public static class ProceduralLevelGeneration : Il2CppSystem.Object
{
	[System.Serializable]
	public class GenerationSettings : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_mapUnitSize;

		private static readonly System.IntPtr NativeFieldInfoPtr_biomeTextureMapResolution;

		private static readonly System.IntPtr NativeFieldInfoPtr_biomeMapDistorsionAmount;

		private static readonly System.IntPtr NativeFieldInfoPtr_selectedBiomeIds;

		private static readonly System.IntPtr NativeFieldInfoPtr_biomeSettings;

		private static readonly System.IntPtr NativeFieldInfoPtr_playerSpawnNumber;

		private static readonly System.IntPtr NativeFieldInfoPtr_clearAllModuleSpawnPoints;

		private static readonly System.IntPtr NativeFieldInfoPtr_assetPalette;

		private static readonly System.IntPtr NativeFieldInfoPtr_islandDistortMat;

		private static readonly System.IntPtr NativeFieldInfoPtr_biomeDistortMat;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe int mapUnitSize
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_mapUnitSize);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_mapUnitSize)) = num;
			}
		}

		public unsafe int biomeTextureMapResolution
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_biomeTextureMapResolution);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_biomeTextureMapResolution)) = num;
			}
		}

		public unsafe float biomeMapDistorsionAmount
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_biomeMapDistorsionAmount);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_biomeMapDistorsionAmount)) = num;
			}
		}

		public unsafe Il2CppStructArray<int> selectedBiomeIds
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_selectedBiomeIds);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<int>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_selectedBiomeIds)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
			}
		}

		public unsafe Il2CppReferenceArray<BiomeSettings> biomeSettings
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_biomeSettings);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<BiomeSettings>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_biomeSettings)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
			}
		}

		public unsafe int playerSpawnNumber
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerSpawnNumber);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerSpawnNumber)) = num;
			}
		}

		public unsafe bool clearAllModuleSpawnPoints
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_clearAllModuleSpawnPoints);
				return *(bool*)num;
			}
			set
			{
				*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_clearAllModuleSpawnPoints)) = flag;
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

		public unsafe Material islandDistortMat
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_islandDistortMat);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Material>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_islandDistortMat)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)material));
			}
		}

		public unsafe Material biomeDistortMat
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_biomeDistortMat);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Material>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_biomeDistortMat)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)material));
			}
		}

		static GenerationSettings()
		{
			Il2CppClassPointerStore<GenerationSettings>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, "GenerationSettings");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<GenerationSettings>.NativeClassPtr);
			NativeFieldInfoPtr_mapUnitSize = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GenerationSettings>.NativeClassPtr, "mapUnitSize");
			NativeFieldInfoPtr_biomeTextureMapResolution = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GenerationSettings>.NativeClassPtr, "biomeTextureMapResolution");
			NativeFieldInfoPtr_biomeMapDistorsionAmount = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GenerationSettings>.NativeClassPtr, "biomeMapDistorsionAmount");
			NativeFieldInfoPtr_selectedBiomeIds = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GenerationSettings>.NativeClassPtr, "selectedBiomeIds");
			NativeFieldInfoPtr_biomeSettings = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GenerationSettings>.NativeClassPtr, "biomeSettings");
			NativeFieldInfoPtr_playerSpawnNumber = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GenerationSettings>.NativeClassPtr, "playerSpawnNumber");
			NativeFieldInfoPtr_clearAllModuleSpawnPoints = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GenerationSettings>.NativeClassPtr, "clearAllModuleSpawnPoints");
			NativeFieldInfoPtr_assetPalette = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GenerationSettings>.NativeClassPtr, "assetPalette");
			NativeFieldInfoPtr_islandDistortMat = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GenerationSettings>.NativeClassPtr, "islandDistortMat");
			NativeFieldInfoPtr_biomeDistortMat = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GenerationSettings>.NativeClassPtr, "biomeDistortMat");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<GenerationSettings>.NativeClassPtr, 100685735);
		}

		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 239335, RefRangeEnd = 239336, XrefRangeStart = 239334, XrefRangeEnd = 239335, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe GenerationSettings()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<GenerationSettings>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public GenerationSettings(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public class GenerationMapData : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_settings;

		private static readonly System.IntPtr NativeFieldInfoPtr_gridSize;

		private static readonly System.IntPtr NativeFieldInfoPtr_textureMapToMapUnitFactor;

		private static readonly System.IntPtr NativeFieldInfoPtr_randomFlowTextOffset;

		private static readonly System.IntPtr NativeFieldInfoPtr_biomePointsNorm;

		private static readonly System.IntPtr NativeFieldInfoPtr_waterHash;

		private static readonly System.IntPtr NativeFieldInfoPtr_biomeMapNoWater;

		private static readonly System.IntPtr NativeFieldInfoPtr_biomeMap;

		private static readonly System.IntPtr NativeFieldInfoPtr_moduleHash;

		private static readonly System.IntPtr NativeFieldInfoPtr_pathCarveHashGrid;

		private static readonly System.IntPtr NativeFieldInfoPtr_pathHashGrid;

		private static readonly System.IntPtr NativeFieldInfoPtr_obstacleHashGrid;

		private static readonly System.IntPtr NativeFieldInfoPtr_poiModulePoints;

		private static readonly System.IntPtr NativeFieldInfoPtr_normalModulePoints;

		private static readonly System.IntPtr NativeFieldInfoPtr_addedPaths;

		private static readonly System.IntPtr NativeFieldInfoPtr_addedPlayerSpawns;

		private static readonly System.IntPtr NativeFieldInfoPtr_levelData;

		private static readonly System.IntPtr NativeMethodInfoPtr_get_allModulePoints_Public_get_List_1_ModulePoint_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_Vector2Int_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_GenerationMapData_0;

		public unsafe GenerationSettings settings
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_settings);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GenerationSettings>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_settings)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)generationSettings));
			}
		}

		public unsafe Vector2Int gridSize
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gridSize);
				return *(Vector2Int*)num;
			}
			set
			{
				*(Vector2Int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_gridSize)) = vector2Int;
			}
		}

		public unsafe float textureMapToMapUnitFactor
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_textureMapToMapUnitFactor);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_textureMapToMapUnitFactor)) = num;
			}
		}

		public unsafe Vector2 randomFlowTextOffset
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_randomFlowTextOffset);
				return *(Vector2*)num;
			}
			set
			{
				*(Vector2*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_randomFlowTextOffset)) = vector;
			}
		}

		public unsafe Il2CppStructArray<Vector2> biomePointsNorm
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_biomePointsNorm);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<Vector2>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_biomePointsNorm)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
			}
		}

		public unsafe Il2CppObjectBase waterHash
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_waterHash);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppObjectBase>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_waterHash)), IL2CPP.Il2CppObjectBaseToPtr(val));
			}
		}

		public unsafe Il2CppObjectBase biomeMapNoWater
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_biomeMapNoWater);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppObjectBase>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_biomeMapNoWater)), IL2CPP.Il2CppObjectBaseToPtr(val));
			}
		}

		public unsafe Il2CppObjectBase biomeMap
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_biomeMap);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppObjectBase>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_biomeMap)), IL2CPP.Il2CppObjectBaseToPtr(val));
			}
		}

		public unsafe Il2CppObjectBase moduleHash
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_moduleHash);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppObjectBase>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_moduleHash)), IL2CPP.Il2CppObjectBaseToPtr(val));
			}
		}

		public unsafe Il2CppObjectBase pathCarveHashGrid
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pathCarveHashGrid);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppObjectBase>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pathCarveHashGrid)), IL2CPP.Il2CppObjectBaseToPtr(val));
			}
		}

		public unsafe Il2CppObjectBase pathHashGrid
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pathHashGrid);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppObjectBase>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pathHashGrid)), IL2CPP.Il2CppObjectBaseToPtr(val));
			}
		}

		public unsafe Il2CppObjectBase obstacleHashGrid
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_obstacleHashGrid);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppObjectBase>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_obstacleHashGrid)), IL2CPP.Il2CppObjectBaseToPtr(val));
			}
		}

		public unsafe List<ModulePoint> poiModulePoints
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_poiModulePoints);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<ModulePoint>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_poiModulePoints)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
			}
		}

		public unsafe List<ModulePoint> normalModulePoints
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_normalModulePoints);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<ModulePoint>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_normalModulePoints)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
			}
		}

		public unsafe List<LineSegment> addedPaths
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_addedPaths);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<LineSegment>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_addedPaths)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
			}
		}

		public unsafe List<Vector2Int> addedPlayerSpawns
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_addedPlayerSpawns);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<Vector2Int>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_addedPlayerSpawns)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
			}
		}

		public unsafe LevelData levelData
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_levelData);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<LevelData>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_levelData)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)levelData));
			}
		}

		public unsafe List<ModulePoint> allModulePoints
		{
			[CallerCount(16)]
			[CachedScanResults(RefRangeStart = 239343, RefRangeEnd = 239359, XrefRangeStart = 239336, XrefRangeEnd = 239343, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
			get
			{
				IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				System.IntPtr* ptr = null;
				Unsafe.SkipInit(out System.IntPtr intPtr2);
				System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_allModulePoints_Public_get_List_1_ModulePoint_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
				Il2CppException.RaiseExceptionIfNecessary(intPtr2);
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<ModulePoint>>(intPtr) : null;
			}
		}

		static GenerationMapData()
		{
			Il2CppClassPointerStore<GenerationMapData>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, "GenerationMapData");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<GenerationMapData>.NativeClassPtr);
			NativeFieldInfoPtr_settings = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GenerationMapData>.NativeClassPtr, "settings");
			NativeFieldInfoPtr_gridSize = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GenerationMapData>.NativeClassPtr, "gridSize");
			NativeFieldInfoPtr_textureMapToMapUnitFactor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GenerationMapData>.NativeClassPtr, "textureMapToMapUnitFactor");
			NativeFieldInfoPtr_randomFlowTextOffset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GenerationMapData>.NativeClassPtr, "randomFlowTextOffset");
			NativeFieldInfoPtr_biomePointsNorm = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GenerationMapData>.NativeClassPtr, "biomePointsNorm");
			NativeFieldInfoPtr_waterHash = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GenerationMapData>.NativeClassPtr, "waterHash");
			NativeFieldInfoPtr_biomeMapNoWater = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GenerationMapData>.NativeClassPtr, "biomeMapNoWater");
			NativeFieldInfoPtr_biomeMap = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GenerationMapData>.NativeClassPtr, "biomeMap");
			NativeFieldInfoPtr_moduleHash = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GenerationMapData>.NativeClassPtr, "moduleHash");
			NativeFieldInfoPtr_pathCarveHashGrid = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GenerationMapData>.NativeClassPtr, "pathCarveHashGrid");
			NativeFieldInfoPtr_pathHashGrid = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GenerationMapData>.NativeClassPtr, "pathHashGrid");
			NativeFieldInfoPtr_obstacleHashGrid = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GenerationMapData>.NativeClassPtr, "obstacleHashGrid");
			NativeFieldInfoPtr_poiModulePoints = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GenerationMapData>.NativeClassPtr, "poiModulePoints");
			NativeFieldInfoPtr_normalModulePoints = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GenerationMapData>.NativeClassPtr, "normalModulePoints");
			NativeFieldInfoPtr_addedPaths = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GenerationMapData>.NativeClassPtr, "addedPaths");
			NativeFieldInfoPtr_addedPlayerSpawns = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GenerationMapData>.NativeClassPtr, "addedPlayerSpawns");
			NativeFieldInfoPtr_levelData = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GenerationMapData>.NativeClassPtr, "levelData");
			NativeMethodInfoPtr_get_allModulePoints_Public_get_List_1_ModulePoint_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<GenerationMapData>.NativeClassPtr, 100685736);
			NativeMethodInfoPtr__ctor_Public_Void_Vector2Int_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<GenerationMapData>.NativeClassPtr, 100685737);
			NativeMethodInfoPtr__ctor_Public_Void_GenerationMapData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<GenerationMapData>.NativeClassPtr, 100685738);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 239359, XrefRangeEnd = 239377, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe GenerationMapData(Vector2Int size)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<GenerationMapData>.NativeClassPtr))
		{
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = (nint)(&size);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_Vector2Int_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(2)]
		[CachedScanResults(RefRangeStart = 239430, RefRangeEnd = 239432, XrefRangeStart = 239377, XrefRangeEnd = 239430, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe GenerationMapData(GenerationMapData mapData)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<GenerationMapData>.NativeClassPtr))
		{
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)mapData);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_GenerationMapData_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public GenerationMapData(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public class BiomeSettings : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_isSelected;

		private static readonly System.IntPtr NativeFieldInfoPtr_poiModuleSettings;

		private static readonly System.IntPtr NativeFieldInfoPtr_poiThemedModuleSettings;

		private static readonly System.IntPtr NativeFieldInfoPtr_landmarkModuleSettings;

		private static readonly System.IntPtr NativeFieldInfoPtr_reviveModuleSettings;

		private static readonly System.IntPtr NativeFieldInfoPtr_genericLargeModuleSettings;

		private static readonly System.IntPtr NativeFieldInfoPtr_genericMediumModuleSettings;

		private static readonly System.IntPtr NativeFieldInfoPtr_genericSmallModuleSettings;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe bool isSelected
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isSelected);
				return *(bool*)num;
			}
			set
			{
				*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isSelected)) = flag;
			}
		}

		public unsafe ModuleTypeSettings poiModuleSettings
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_poiModuleSettings);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ModuleTypeSettings>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_poiModuleSettings)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)moduleTypeSettings));
			}
		}

		public unsafe ModuleTypeSettings poiThemedModuleSettings
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_poiThemedModuleSettings);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ModuleTypeSettings>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_poiThemedModuleSettings)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)moduleTypeSettings));
			}
		}

		public unsafe ModuleTypeSettings landmarkModuleSettings
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_landmarkModuleSettings);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ModuleTypeSettings>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_landmarkModuleSettings)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)moduleTypeSettings));
			}
		}

		public unsafe ModuleTypeSettings reviveModuleSettings
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_reviveModuleSettings);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ModuleTypeSettings>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_reviveModuleSettings)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)moduleTypeSettings));
			}
		}

		public unsafe ModuleTypeSettings genericLargeModuleSettings
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_genericLargeModuleSettings);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ModuleTypeSettings>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_genericLargeModuleSettings)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)moduleTypeSettings));
			}
		}

		public unsafe ModuleTypeSettings genericMediumModuleSettings
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_genericMediumModuleSettings);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ModuleTypeSettings>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_genericMediumModuleSettings)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)moduleTypeSettings));
			}
		}

		public unsafe ModuleTypeSettings genericSmallModuleSettings
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_genericSmallModuleSettings);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ModuleTypeSettings>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_genericSmallModuleSettings)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)moduleTypeSettings));
			}
		}

		static BiomeSettings()
		{
			Il2CppClassPointerStore<BiomeSettings>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, "BiomeSettings");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<BiomeSettings>.NativeClassPtr);
			NativeFieldInfoPtr_isSelected = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BiomeSettings>.NativeClassPtr, "isSelected");
			NativeFieldInfoPtr_poiModuleSettings = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BiomeSettings>.NativeClassPtr, "poiModuleSettings");
			NativeFieldInfoPtr_poiThemedModuleSettings = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BiomeSettings>.NativeClassPtr, "poiThemedModuleSettings");
			NativeFieldInfoPtr_landmarkModuleSettings = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BiomeSettings>.NativeClassPtr, "landmarkModuleSettings");
			NativeFieldInfoPtr_reviveModuleSettings = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BiomeSettings>.NativeClassPtr, "reviveModuleSettings");
			NativeFieldInfoPtr_genericLargeModuleSettings = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BiomeSettings>.NativeClassPtr, "genericLargeModuleSettings");
			NativeFieldInfoPtr_genericMediumModuleSettings = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BiomeSettings>.NativeClassPtr, "genericMediumModuleSettings");
			NativeFieldInfoPtr_genericSmallModuleSettings = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BiomeSettings>.NativeClassPtr, "genericSmallModuleSettings");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BiomeSettings>.NativeClassPtr, 100685739);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 239432, XrefRangeEnd = 239462, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe BiomeSettings()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<BiomeSettings>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public BiomeSettings(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public class ModuleTypeSettings : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_isSelected;

		private static readonly System.IntPtr NativeFieldInfoPtr_modsSelected;

		private static readonly System.IntPtr NativeFieldInfoPtr_distToSelf;

		private static readonly System.IntPtr NativeFieldInfoPtr_distToOthers;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_Boolean_IntRange_IntRange_0;

		public unsafe bool isSelected
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isSelected);
				return *(bool*)num;
			}
			set
			{
				*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isSelected)) = flag;
			}
		}

		public unsafe Il2CppStructArray<bool> modsSelected
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_modsSelected);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<bool>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_modsSelected)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
			}
		}

		public unsafe IntRange distToSelf
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_distToSelf);
				return *(IntRange*)num;
			}
			set
			{
				*(IntRange*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_distToSelf)) = intRange;
			}
		}

		public unsafe IntRange distToOthers
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_distToOthers);
				return *(IntRange*)num;
			}
			set
			{
				*(IntRange*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_distToOthers)) = intRange;
			}
		}

		static ModuleTypeSettings()
		{
			Il2CppClassPointerStore<ModuleTypeSettings>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, "ModuleTypeSettings");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<ModuleTypeSettings>.NativeClassPtr);
			NativeFieldInfoPtr_isSelected = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ModuleTypeSettings>.NativeClassPtr, "isSelected");
			NativeFieldInfoPtr_modsSelected = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ModuleTypeSettings>.NativeClassPtr, "modsSelected");
			NativeFieldInfoPtr_distToSelf = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ModuleTypeSettings>.NativeClassPtr, "distToSelf");
			NativeFieldInfoPtr_distToOthers = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ModuleTypeSettings>.NativeClassPtr, "distToOthers");
			NativeMethodInfoPtr__ctor_Public_Void_Boolean_IntRange_IntRange_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ModuleTypeSettings>.NativeClassPtr, 100685740);
		}

		[CallerCount(7)]
		[CachedScanResults(RefRangeStart = 239467, RefRangeEnd = 239474, XrefRangeStart = 239462, XrefRangeEnd = 239467, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe ModuleTypeSettings(bool _isSelected, IntRange _distToSelf, IntRange _distToOthers)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<ModuleTypeSettings>.NativeClassPtr))
		{
			System.IntPtr* ptr = stackalloc System.IntPtr[3];
			*ptr = (nint)(&_isSelected);
			*(IntRange**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &_distToSelf;
			*(IntRange**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &_distToOthers;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_Boolean_IntRange_IntRange_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public ModuleTypeSettings(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[StructLayout(LayoutKind.Explicit)]
	public struct AreaPoint
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_position;

		private static readonly System.IntPtr NativeFieldInfoPtr_size;

		[FieldOffset(0)]
		public Vector2Int position;

		[FieldOffset(8)]
		public Vector2Int size;

		static AreaPoint()
		{
			Il2CppClassPointerStore<AreaPoint>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, "AreaPoint");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<AreaPoint>.NativeClassPtr);
			NativeFieldInfoPtr_position = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AreaPoint>.NativeClassPtr, "position");
			NativeFieldInfoPtr_size = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AreaPoint>.NativeClassPtr, "size");
		}

		public unsafe Il2CppSystem.Object BoxIl2CppObject()
		{
			return new Il2CppSystem.Object(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<AreaPoint>.NativeClassPtr, (System.IntPtr)(nint)Unsafe.AsPointer(ref this)));
		}
	}

	public sealed class ModulePoint : Il2CppSystem.ValueType
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_position;

		private static readonly System.IntPtr NativeFieldInfoPtr_rotatedSize;

		private static readonly System.IntPtr NativeFieldInfoPtr_rotationId;

		private static readonly System.IntPtr NativeFieldInfoPtr_levelData;

		private static readonly System.IntPtr NativeFieldInfoPtr_moduleName;

		public unsafe Vector2Int position
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_position);
				return *(Vector2Int*)num;
			}
			set
			{
				*(Vector2Int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_position)) = vector2Int;
			}
		}

		public unsafe Vector2Int rotatedSize
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rotatedSize);
				return *(Vector2Int*)num;
			}
			set
			{
				*(Vector2Int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rotatedSize)) = vector2Int;
			}
		}

		public unsafe int rotationId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rotationId);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rotationId)) = num;
			}
		}

		public unsafe LevelData levelData
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_levelData);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<LevelData>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_levelData)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)levelData));
			}
		}

		public unsafe string moduleName
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_moduleName);
				return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_moduleName)), IL2CPP.ManagedStringToIl2Cpp(text));
			}
		}

		static ModulePoint()
		{
			Il2CppClassPointerStore<ModulePoint>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, "ModulePoint");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<ModulePoint>.NativeClassPtr);
			NativeFieldInfoPtr_position = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ModulePoint>.NativeClassPtr, "position");
			NativeFieldInfoPtr_rotatedSize = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ModulePoint>.NativeClassPtr, "rotatedSize");
			NativeFieldInfoPtr_rotationId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ModulePoint>.NativeClassPtr, "rotationId");
			NativeFieldInfoPtr_levelData = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ModulePoint>.NativeClassPtr, "levelData");
			NativeFieldInfoPtr_moduleName = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ModulePoint>.NativeClassPtr, "moduleName");
		}

		public ModulePoint(System.IntPtr pointer)
			: base(pointer)
		{
		}

		public ModulePoint()
			: base(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<ModulePoint>.NativeClassPtr))
		{
		}
	}

	public class Generator : Il2CppSystem.Object
	{
		public class GenStep : Il2CppSystem.Object
		{
			private static readonly System.IntPtr NativeFieldInfoPtr_generator;

			private static readonly System.IntPtr NativeFieldInfoPtr_action;

			private static readonly System.IntPtr NativeFieldInfoPtr_debugVisualizeAction;

			private static readonly System.IntPtr NativeFieldInfoPtr_debugClearVisualizeAction;

			private static readonly System.IntPtr NativeFieldInfoPtr_GUIAction;

			private static readonly System.IntPtr NativeFieldInfoPtr_manualStepGUIAction;

			private static readonly System.IntPtr NativeFieldInfoPtr_name;

			private static readonly System.IntPtr NativeFieldInfoPtr_allowRegeneration;

			private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_Generator_Action_1_GenerationMapData_Action_1_GenerationMapData_Action_1_GenerationMapData_Action_Action_1_Generator_String_Boolean_0;

			private static readonly System.IntPtr NativeMethodInfoPtr_Execute_Public_Void_0;

			private static readonly System.IntPtr NativeMethodInfoPtr_ExecuteVisualize_Public_Void_0;

			private static readonly System.IntPtr NativeMethodInfoPtr_ExecuteClearVisualize_Public_Void_0;

			public unsafe Generator generator
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_generator);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Generator>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_generator)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)generator));
				}
			}

			public unsafe Il2CppSystem.Action<GenerationMapData> action
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_action);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action<GenerationMapData>>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_action)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
				}
			}

			public unsafe Il2CppSystem.Action<GenerationMapData> debugVisualizeAction
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_debugVisualizeAction);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action<GenerationMapData>>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_debugVisualizeAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
				}
			}

			public unsafe Il2CppSystem.Action<GenerationMapData> debugClearVisualizeAction
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_debugClearVisualizeAction);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action<GenerationMapData>>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_debugClearVisualizeAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
				}
			}

			public unsafe Il2CppSystem.Action GUIAction
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_GUIAction);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_GUIAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
				}
			}

			public unsafe Il2CppSystem.Action<Generator> manualStepGUIAction
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_manualStepGUIAction);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action<Generator>>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_manualStepGUIAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action));
				}
			}

			public unsafe string name
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_name);
					return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_name)), IL2CPP.ManagedStringToIl2Cpp(text));
				}
			}

			public unsafe bool allowRegeneration
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_allowRegeneration);
					return *(bool*)num;
				}
				set
				{
					*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_allowRegeneration)) = flag;
				}
			}

			static GenStep()
			{
				Il2CppClassPointerStore<GenStep>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<Generator>.NativeClassPtr, "GenStep");
				IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<GenStep>.NativeClassPtr);
				NativeFieldInfoPtr_generator = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GenStep>.NativeClassPtr, "generator");
				NativeFieldInfoPtr_action = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GenStep>.NativeClassPtr, "action");
				NativeFieldInfoPtr_debugVisualizeAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GenStep>.NativeClassPtr, "debugVisualizeAction");
				NativeFieldInfoPtr_debugClearVisualizeAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GenStep>.NativeClassPtr, "debugClearVisualizeAction");
				NativeFieldInfoPtr_GUIAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GenStep>.NativeClassPtr, "GUIAction");
				NativeFieldInfoPtr_manualStepGUIAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GenStep>.NativeClassPtr, "manualStepGUIAction");
				NativeFieldInfoPtr_name = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GenStep>.NativeClassPtr, "name");
				NativeFieldInfoPtr_allowRegeneration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<GenStep>.NativeClassPtr, "allowRegeneration");
				NativeMethodInfoPtr__ctor_Public_Void_Generator_Action_1_GenerationMapData_Action_1_GenerationMapData_Action_1_GenerationMapData_Action_Action_1_Generator_String_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<GenStep>.NativeClassPtr, 100685754);
				NativeMethodInfoPtr_Execute_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<GenStep>.NativeClassPtr, 100685755);
				NativeMethodInfoPtr_ExecuteVisualize_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<GenStep>.NativeClassPtr, 100685756);
				NativeMethodInfoPtr_ExecuteClearVisualize_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<GenStep>.NativeClassPtr, 100685757);
			}

			[CallerCount(0)]
			[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 239474, XrefRangeEnd = 239475, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
			public unsafe GenStep(Generator generator, Il2CppSystem.Action<GenerationMapData> action, Il2CppSystem.Action<GenerationMapData> debugVisualizeAction, Il2CppSystem.Action<GenerationMapData> debugClearVisualizeAction, Il2CppSystem.Action GUIAction, Il2CppSystem.Action<Generator> manualStepGUIAction, string name, bool allowRegeneration = true)
				: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<GenStep>.NativeClassPtr))
			{
				System.IntPtr* ptr = stackalloc System.IntPtr[8];
				*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)generator);
				*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)action);
				*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)debugVisualizeAction);
				*(System.IntPtr*)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)debugClearVisualizeAction);
				*(System.IntPtr*)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)GUIAction);
				*(System.IntPtr*)((byte*)ptr + checked((nuint)5u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)manualStepGUIAction);
				*(System.IntPtr*)((byte*)ptr + checked((nuint)6u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(name);
				*(bool**)((byte*)ptr + checked((nuint)7u * unchecked((nuint)sizeof(System.IntPtr)))) = &allowRegeneration;
				Unsafe.SkipInit(out System.IntPtr intPtr2);
				System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_Generator_Action_1_GenerationMapData_Action_1_GenerationMapData_Action_1_GenerationMapData_Action_Action_1_Generator_String_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
				Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			}

			[CallerCount(0)]
			public unsafe void Execute()
			{
				IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				System.IntPtr* ptr = null;
				Unsafe.SkipInit(out System.IntPtr intPtr2);
				System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Execute_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
				Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			}

			[CallerCount(0)]
			public unsafe void ExecuteVisualize()
			{
				IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				System.IntPtr* ptr = null;
				Unsafe.SkipInit(out System.IntPtr intPtr2);
				System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ExecuteVisualize_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
				Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			}

			[CallerCount(0)]
			public unsafe void ExecuteClearVisualize()
			{
				IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				System.IntPtr* ptr = null;
				Unsafe.SkipInit(out System.IntPtr intPtr2);
				System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ExecuteClearVisualize_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
				Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			}

			public GenStep(System.IntPtr pointer)
				: base(pointer)
			{
			}
		}

		private static readonly System.IntPtr NativeFieldInfoPtr_settings;

		private static readonly System.IntPtr NativeFieldInfoPtr_steps;

		private static readonly System.IntPtr NativeFieldInfoPtr_currentStep;

		private static readonly System.IntPtr NativeFieldInfoPtr_initialized;

		private static readonly System.IntPtr NativeFieldInfoPtr_finished;

		private static readonly System.IntPtr NativeFieldInfoPtr_revertStepEnabled;

		private static readonly System.IntPtr NativeFieldInfoPtr_mapData;

		private static readonly System.IntPtr NativeFieldInfoPtr_stepMapDataSnapshots;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_GenerationSettings_Boolean_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_Initialize_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_RevertStep_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_AdvanceNextStep_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_ExecuteCurrentStep_Public_Void_Boolean_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_RegenerateCurrentStep_Public_Void_Boolean_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_GetNextStepName_Public_String_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_GetCurrentStepName_Public_String_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_GetPreviousStepName_Public_String_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_GetCurrentStepManualGUI_Public_Action_1_Generator_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_GetCurrentStepGUI_Public_Action_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_IsCurrentStepAbleToRegen_Public_Boolean_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_IsCurrentStepAbleToRevert_Public_Boolean_0;

		public unsafe GenerationSettings settings
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_settings);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GenerationSettings>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_settings)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)generationSettings));
			}
		}

		public unsafe Il2CppReferenceArray<GenStep> steps
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_steps);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<GenStep>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_steps)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
			}
		}

		public unsafe int currentStep
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentStep);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentStep)) = num;
			}
		}

		public unsafe bool initialized
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_initialized);
				return *(bool*)num;
			}
			set
			{
				*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_initialized)) = flag;
			}
		}

		public unsafe bool finished
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_finished);
				return *(bool*)num;
			}
			set
			{
				*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_finished)) = flag;
			}
		}

		public unsafe bool revertStepEnabled
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_revertStepEnabled);
				return *(bool*)num;
			}
			set
			{
				*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_revertStepEnabled)) = flag;
			}
		}

		public unsafe GenerationMapData mapData
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_mapData);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GenerationMapData>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_mapData)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)generationMapData));
			}
		}

		public unsafe Il2CppReferenceArray<GenerationMapData> stepMapDataSnapshots
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_stepMapDataSnapshots);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<GenerationMapData>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_stepMapDataSnapshots)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
			}
		}

		static Generator()
		{
			Il2CppClassPointerStore<Generator>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, "Generator");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<Generator>.NativeClassPtr);
			NativeFieldInfoPtr_settings = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Generator>.NativeClassPtr, "settings");
			NativeFieldInfoPtr_steps = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Generator>.NativeClassPtr, "steps");
			NativeFieldInfoPtr_currentStep = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Generator>.NativeClassPtr, "currentStep");
			NativeFieldInfoPtr_initialized = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Generator>.NativeClassPtr, "initialized");
			NativeFieldInfoPtr_finished = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Generator>.NativeClassPtr, "finished");
			NativeFieldInfoPtr_revertStepEnabled = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Generator>.NativeClassPtr, "revertStepEnabled");
			NativeFieldInfoPtr_mapData = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Generator>.NativeClassPtr, "mapData");
			NativeFieldInfoPtr_stepMapDataSnapshots = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Generator>.NativeClassPtr, "stepMapDataSnapshots");
			NativeMethodInfoPtr__ctor_Public_Void_GenerationSettings_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Generator>.NativeClassPtr, 100685741);
			NativeMethodInfoPtr_Initialize_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Generator>.NativeClassPtr, 100685742);
			NativeMethodInfoPtr_RevertStep_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Generator>.NativeClassPtr, 100685743);
			NativeMethodInfoPtr_AdvanceNextStep_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Generator>.NativeClassPtr, 100685744);
			NativeMethodInfoPtr_ExecuteCurrentStep_Public_Void_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Generator>.NativeClassPtr, 100685745);
			NativeMethodInfoPtr_RegenerateCurrentStep_Public_Void_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Generator>.NativeClassPtr, 100685746);
			NativeMethodInfoPtr_GetNextStepName_Public_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Generator>.NativeClassPtr, 100685747);
			NativeMethodInfoPtr_GetCurrentStepName_Public_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Generator>.NativeClassPtr, 100685748);
			NativeMethodInfoPtr_GetPreviousStepName_Public_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Generator>.NativeClassPtr, 100685749);
			NativeMethodInfoPtr_GetCurrentStepManualGUI_Public_Action_1_Generator_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Generator>.NativeClassPtr, 100685750);
			NativeMethodInfoPtr_GetCurrentStepGUI_Public_Action_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Generator>.NativeClassPtr, 100685751);
			NativeMethodInfoPtr_IsCurrentStepAbleToRegen_Public_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Generator>.NativeClassPtr, 100685752);
			NativeMethodInfoPtr_IsCurrentStepAbleToRevert_Public_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Generator>.NativeClassPtr, 100685753);
		}

		[CallerCount(2)]
		[CachedScanResults(RefRangeStart = 239619, RefRangeEnd = 239621, XrefRangeStart = 239475, XrefRangeEnd = 239619, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe Generator(GenerationSettings settings, bool revertStepEnabled = true)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<Generator>.NativeClassPtr))
		{
			System.IntPtr* ptr = stackalloc System.IntPtr[2];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)settings);
			*(bool**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &revertStepEnabled;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_GenerationSettings_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(2)]
		[CachedScanResults(RefRangeStart = 239624, RefRangeEnd = 239626, XrefRangeStart = 239621, XrefRangeEnd = 239624, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void Initialize()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Initialize_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		public unsafe void RevertStep()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_RevertStep_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(3)]
		[CachedScanResults(RefRangeStart = 239632, RefRangeEnd = 239635, XrefRangeStart = 239626, XrefRangeEnd = 239632, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void AdvanceNextStep()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_AdvanceNextStep_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(4)]
		[CachedScanResults(RefRangeStart = 239637, RefRangeEnd = 239641, XrefRangeStart = 239635, XrefRangeEnd = 239637, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void ExecuteCurrentStep(bool visualize = false)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = (nint)(&visualize);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ExecuteCurrentStep_Public_Void_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 239643, RefRangeEnd = 239644, XrefRangeStart = 239641, XrefRangeEnd = 239643, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe void RegenerateCurrentStep(bool visualize = false)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = (nint)(&visualize);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_RegenerateCurrentStep_Public_Void_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(2)]
		[CachedScanResults(RefRangeStart = 239645, RefRangeEnd = 239647, XrefRangeStart = 239644, XrefRangeEnd = 239645, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe string GetNextStepName()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetNextStepName_Public_String_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return IL2CPP.Il2CppStringToManaged(intPtr);
		}

		[CallerCount(8)]
		[CachedScanResults(RefRangeStart = 239650, RefRangeEnd = 239658, XrefRangeStart = 239647, XrefRangeEnd = 239650, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe string GetCurrentStepName()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetCurrentStepName_Public_String_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return IL2CPP.Il2CppStringToManaged(intPtr);
		}

		[CallerCount(2)]
		[CachedScanResults(RefRangeStart = 239661, RefRangeEnd = 239663, XrefRangeStart = 239658, XrefRangeEnd = 239661, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe string GetPreviousStepName()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetPreviousStepName_Public_String_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return IL2CPP.Il2CppStringToManaged(intPtr);
		}

		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 239663, RefRangeEnd = 239664, XrefRangeStart = 239663, XrefRangeEnd = 239663, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe Il2CppSystem.Action<Generator> GetCurrentStepManualGUI()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetCurrentStepManualGUI_Public_Action_1_Generator_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action<Generator>>(intPtr) : null;
		}

		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 239664, RefRangeEnd = 239665, XrefRangeStart = 239664, XrefRangeEnd = 239664, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe Il2CppSystem.Action GetCurrentStepGUI()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetCurrentStepGUI_Public_Action_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppSystem.Action>(intPtr) : null;
		}

		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 239665, RefRangeEnd = 239666, XrefRangeStart = 239665, XrefRangeEnd = 239665, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe bool IsCurrentStepAbleToRegen()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_IsCurrentStepAbleToRegen_Public_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 239666, RefRangeEnd = 239667, XrefRangeStart = 239666, XrefRangeEnd = 239666, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe bool IsCurrentStepAbleToRevert()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_IsCurrentStepAbleToRevert_Public_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		public Generator(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[ObfuscatedName("BAPBAP.Maps.ProceduralLevelGeneration+<>c__DisplayClass46_0")]
	public sealed class __c__DisplayClass46_0 : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_spanningTree;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr__ExectutePathGen_b__0_Internal_Boolean_LineSegment_0;

		public unsafe List<LineSegment> spanningTree
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spanningTree);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<LineSegment>>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spanningTree)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
			}
		}

		static __c__DisplayClass46_0()
		{
			Il2CppClassPointerStore<__c__DisplayClass46_0>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, "<>c__DisplayClass46_0");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c__DisplayClass46_0>.NativeClassPtr);
			NativeFieldInfoPtr_spanningTree = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass46_0>.NativeClassPtr, "spanningTree");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass46_0>.NativeClassPtr, 100685758);
			NativeMethodInfoPtr__ExectutePathGen_b__0_Internal_Boolean_LineSegment_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<__c__DisplayClass46_0>.NativeClassPtr, 100685759);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe __c__DisplayClass46_0()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<__c__DisplayClass46_0>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 239667, XrefRangeEnd = 239669, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe bool _ExectutePathGen_b__0(LineSegment x)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)x);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ExectutePathGen_b__0_Internal_Boolean_LineSegment_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		public __c__DisplayClass46_0(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	private static readonly System.IntPtr NativeFieldInfoPtr_generator;

	private static readonly System.IntPtr NativeFieldInfoPtr_generatedLevel;

	private static readonly System.IntPtr NativeFieldInfoPtr_moduleListBySelectedBiome;

	private static readonly System.IntPtr NativeFieldInfoPtr_biomeConfigsBySelectedBiome;

	private static readonly System.IntPtr NativeFieldInfoPtr_biomeIdToSelectedBiomeId;

	private static readonly System.IntPtr NativeFieldInfoPtr_moduleListByBiome;

	private static readonly System.IntPtr NativeFieldInfoPtr_loadedModulesByFilename;

	private static readonly System.IntPtr NativeFieldInfoPtr_colorHuesByBiome;

	private static readonly System.IntPtr NativeFieldInfoPtr_currentTestObj;

	private static readonly System.IntPtr NativeFieldInfoPtr_debugSpawnedMeshes;

	private static readonly System.IntPtr NativeFieldInfoPtr_obstacleDebugGrid;

	private static readonly System.IntPtr NativeFieldInfoPtr_pathLinesDebugVisible;

	private static readonly System.IntPtr NativeFieldInfoPtr_debugStr;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Config_Private_Static_get_Configuration_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_CurrentGenerator_Public_Static_get_Generator_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GenerateLevelAll_Public_Static_LevelData_GenerationSettings_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_StartNewLevelGenerator_Public_Static_Void_GenerationSettings_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_InitializeGeneration_Private_Static_Void_Generator_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetBiomeHuesByBiomeColors_Public_Static_Void_BiomeData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_LoadAllModuleLists_Private_Static_Void_GenerationSettings_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_FinalizeMapGeneration_Public_Static_Void_Generator_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ExectuteIslandGen_Private_Static_Void_GenerationMapData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_VisIslandGen_Public_Static_Void_GenerationMapData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_VisClearIslandGen_Private_Static_Void_GenerationMapData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ManualIslandGenExecuteCellularAutomata_Public_Static_Void_GenerationMapData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ManualIslandGenAddTile_Public_Static_Void_GenerationMapData_Vector2Int_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ExectuteBiomeGen_Private_Static_Void_GenerationMapData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_VisBiomeGen_Public_Static_Void_GenerationMapData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_VisClearBiomeGen_Private_Static_Void_GenerationMapData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ManualBiomeGenAddTile_Public_Static_Void_GenerationMapData_Vector2Int_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ExectutePOIModuleGen_Private_Static_Void_GenerationMapData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ExectuteModuleGen_Private_Static_Void_GenerationMapData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_VisModulePoints_Private_Static_Void_GenerationMapData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_VisClearModulePoints_Private_Static_Void_GenerationMapData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ManualModuleGenAddModule_Public_Static_Void_GenerationMapData_List_1_ModulePoint_ModulePoint_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ManualModuleGenRemoveModule_Public_Static_Void_GenerationMapData_List_1_ModulePoint_ModulePoint_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ManualModuleGenClearModules_Public_Static_Void_GenerationMapData_List_1_ModulePoint_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ExectutePathGen_Public_Static_Void_GenerationMapData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CreatePathHashMap_Private_Static_Void_List_1_LineSegment_Il2CppObjectBase_Single_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_VisPathGen_Public_Static_Void_GenerationMapData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_VisClearPathGen_Private_Static_Void_GenerationMapData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ManualPathGenExecuteCleanup_Public_Static_Void_GenerationMapData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ManualPathGenVisualizePathLines_Public_Static_Void_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ManualPathGenAddTile_Public_Static_Void_GenerationMapData_Vector2Int_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ManualPathGenVisRefresh_Public_Static_Void_GenerationMapData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ExectuteObstacleGen_Public_Static_Void_GenerationMapData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_VisObstacleGen_Private_Static_Void_GenerationMapData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_VisCreateObstacleTile_Private_Static_GameObject_Int32_Int32_Int32_Transform_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_VisClearObstacleGen_Private_Static_Void_GenerationMapData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ManualObstacleGenExecuteCellularAutomata_Public_Static_Void_GenerationMapData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ManualObstacleGenAddTile_Public_Static_Void_GenerationMapData_Vector2Int_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ExecuteSpawnPointGen_Private_Static_Void_GenerationMapData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_VisSpawnPointGen_Private_Static_Void_GenerationMapData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_VisClearSpawnPointGen_Private_Static_Void_GenerationMapData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ExecuteGenerateTiles_Public_Static_Void_GenerationMapData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CreateBiomePointsInRadius_Private_Static_List_1_Vector2_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_RandomizePointListIndexes_Private_Static_List_1_Vector2_List_1_Vector2_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CreateColorsByBiome_Public_Static_Il2CppStructArray_1_Color_BiomeData_Il2CppStructArray_1_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetBiomeColorsByProcgenBiomeAsset_Public_Static_Il2CppStructArray_1_Color_BiomeData_Il2CppStructArray_1_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CreateBiomeIdGridFromBiomeMapTex_Public_Static_Il2CppObjectBase_Texture2D_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetBiomeIdByBiomeColor_Private_Static_Int32_Color_Il2CppStructArray_1_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SampleBiomeIdMap_Public_Static_Int32_Il2CppObjectBase_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_IsAreaCornerFullyInBiome_Public_Static_Boolean_Il2CppObjectBase_Vector2Int_Vector2Int_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_IsAreaFullyInBiome_Public_Static_Boolean_Il2CppObjectBase_Vector2Int_Vector2Int_Int32_Vector2Int_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_IsPointNextToBiome_Public_Static_Boolean_Il2CppObjectBase_Vector2Int_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetNextDifferentBiome_Public_Static_Int32_Il2CppObjectBase_Vector2Int_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetModuleListInSelectedBiomes_Private_Static_Void_GenerationSettings_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetModuleListInAllBiomes_Private_Static_Void_GenerationSettings_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_RemoveUnselectedModulesInAllModuleTypesAndBiomes_Private_Static_Void_GenerationSettings_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_RemoveUnselectedModulesInModuleTypes_Private_Static_Void_Il2CppStructArray_1_Boolean_List_1_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_RandomizeAllPOIModuleLists_Private_Static_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_RandomizeAllModuleLists_Private_Static_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetModuleDataFromFilename_Private_Static_ModulePoint_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetModuleByName_Private_Static_LevelData_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_LoadAllSerializedModulesInList_Private_Static_Void_GenerationSettings_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_LoadSerializedModulesByNameAndPath_Private_Static_Void_List_1_String_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetNextModuleFromList_Private_Static_String_List_1_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetModuleChoosenOnList_Private_Static_Void_List_1_String_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetPOIThemedModuleNameByPOIName_Private_Static_String_Int32_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetPOIThemedModuleChoosenByPOIName_Private_Static_Void_Int32_String_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_InitializeSamplingPoints_Private_Static_Void_GenerationMapData_List_1_ModulePoint_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SampleAllPOIModuleDataInBiome_Private_Static_Void_GenerationMapData_Int32_Il2CppObjectBase_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SampleAllNormalModuleDataInBiome_Private_Static_Void_GenerationMapData_Int32_Il2CppObjectBase_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SamplePOIModules_Private_Static_Void_GenerationMapData_Int32_Il2CppObjectBase_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SamplePOIThemedModules_Private_Static_Void_GenerationMapData_Int32_Il2CppObjectBase_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SampleLandmarkModules_Private_Static_Void_GenerationMapData_Int32_Il2CppObjectBase_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SampleReviveModules_Private_Static_Void_GenerationMapData_Int32_Il2CppObjectBase_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SampleGenericModules_Private_Static_Void_GenerationMapData_Int32_Il2CppObjectBase_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SampleAllModuleDataInType_Private_Static_Void_GenerationMapData_List_1_String_List_1_ModulePoint_List_1_ModulePoint_Il2CppObjectBase_Int32_Int32_Int32_Int32_Int32_Boolean_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SampleAllModuleDataInTypeNumber_Private_Static_Void_GenerationMapData_List_1_String_List_1_ModulePoint_List_1_ModulePoint_Il2CppObjectBase_Int32_Int32_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SampleModulePointsDensity_Private_Static_Void_GenerationMapData_List_1_String_List_1_ModulePoint_List_1_ModulePoint_Il2CppObjectBase_Int32_Int32_Int32_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetAreaPointsCopyFromModulePoints_Private_Static_List_1_AreaPoint_List_1_ModulePoint_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetAllMapNamedModules_Private_Static_Il2CppReferenceArray_1_MapNamedModule_GenerationMapData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SpawnModuleOnPosition_Private_Static_Void_GenerationMapData_LevelData_Vector2Int_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ProcessSpawnPoints_Private_Static_List_1_Vector2Int_GenerationMapData_Il2CppObjectBase_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SamplePointsNumber_Private_Static_Void_GenerationMapData_Il2CppObjectBase_List_1_AreaPoint_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SamplePointsNumberDistance_Private_Static_Void_GenerationMapData_Il2CppObjectBase_List_1_AreaPoint_Int32_Int32_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SpawnAllPlayerSpawnPoints_Private_Static_Void_GenerationMapData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_RemoveAllSpawnPointsInMap_Private_Static_Void_GenerationMapData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_RemoveCloserSpawnPoints_Private_Static_Void_GenerationMapData_Int32_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetBiomeConfigsByBiomeId_Private_Static_Il2CppReferenceArray_1_BiomeConfig_GenerationSettings_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetAllPrefabIdsByPrefab_Private_Static_Dictionary_2_GameObject_Int32_List_1_GameObject_GenerationSettings_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CreateFloorBiomeTiles_Private_Static_Void_GenerationMapData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CreateFloorPathBiomeTiles_Private_Static_Void_GenerationMapData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CreateObstacleBiomeTiles_Private_Static_Void_GenerationMapData_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetVariationAssetAutotileBiome_Private_Static_VariationAsset_Il2CppObjectBase_Int32_Int32_Int32_AutotileAsset_byref_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetVariationAssetAutotileHash_Private_Static_VariationAsset_Int32_Int32_Il2CppObjectBase_AutotileAsset_byref_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_BuildSerializedMapSettings_Private_Static_MapSettings_GenerationMapData_Il2CppStructArray_1_Vector2_Il2CppReferenceArray_1_MapNamedModule_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CleanUp_Private_Static_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CleanUpGenerationData_Private_Static_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ClearCurrentMap_Public_Static_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_VisualizeBiomeCentroidsOnScene_Private_Static_Void_GenerationMapData_Il2CppStructArray_1_Vector2_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_VisualizePointsOnScene_Private_Static_Void_Il2CppStructArray_1_Vector2_String_0;

	public unsafe static Generator generator
	{
		get
		{
			Unsafe.SkipInit(out System.IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_generator, (void*)(&intPtr));
			System.IntPtr intPtr2 = intPtr;
			return (intPtr2 != (System.IntPtr)0) ? Il2CppObjectPool.Get<Generator>(intPtr2) : null;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_generator, (void*)IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)generator));
		}
	}

	public unsafe static LevelData generatedLevel
	{
		get
		{
			Unsafe.SkipInit(out System.IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_generatedLevel, (void*)(&intPtr));
			System.IntPtr intPtr2 = intPtr;
			return (intPtr2 != (System.IntPtr)0) ? Il2CppObjectPool.Get<LevelData>(intPtr2) : null;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_generatedLevel, (void*)IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)levelData));
		}
	}

	public unsafe static Il2CppReferenceArray<ModuleTypeList> moduleListBySelectedBiome
	{
		get
		{
			Unsafe.SkipInit(out System.IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_moduleListBySelectedBiome, (void*)(&intPtr));
			System.IntPtr intPtr2 = intPtr;
			return (intPtr2 != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<ModuleTypeList>>(intPtr2) : null;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_moduleListBySelectedBiome, (void*)IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe static Il2CppReferenceArray<BiomeData.BiomeConfig> biomeConfigsBySelectedBiome
	{
		get
		{
			Unsafe.SkipInit(out System.IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_biomeConfigsBySelectedBiome, (void*)(&intPtr));
			System.IntPtr intPtr2 = intPtr;
			return (intPtr2 != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<BiomeData.BiomeConfig>>(intPtr2) : null;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_biomeConfigsBySelectedBiome, (void*)IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe static Il2CppStructArray<int> biomeIdToSelectedBiomeId
	{
		get
		{
			Unsafe.SkipInit(out System.IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_biomeIdToSelectedBiomeId, (void*)(&intPtr));
			System.IntPtr intPtr2 = intPtr;
			return (intPtr2 != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<int>>(intPtr2) : null;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_biomeIdToSelectedBiomeId, (void*)IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe static Il2CppReferenceArray<ModuleTypeList> moduleListByBiome
	{
		get
		{
			Unsafe.SkipInit(out System.IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_moduleListByBiome, (void*)(&intPtr));
			System.IntPtr intPtr2 = intPtr;
			return (intPtr2 != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<ModuleTypeList>>(intPtr2) : null;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_moduleListByBiome, (void*)IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe static Dictionary<string, LevelData> loadedModulesByFilename
	{
		get
		{
			Unsafe.SkipInit(out System.IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_loadedModulesByFilename, (void*)(&intPtr));
			System.IntPtr intPtr2 = intPtr;
			return (intPtr2 != (System.IntPtr)0) ? Il2CppObjectPool.Get<Dictionary<string, LevelData>>(intPtr2) : null;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_loadedModulesByFilename, (void*)IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)dictionary));
		}
	}

	public unsafe static Il2CppStructArray<int> colorHuesByBiome
	{
		get
		{
			Unsafe.SkipInit(out System.IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_colorHuesByBiome, (void*)(&intPtr));
			System.IntPtr intPtr2 = intPtr;
			return (intPtr2 != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<int>>(intPtr2) : null;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_colorHuesByBiome, (void*)IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe static GameObject currentTestObj
	{
		get
		{
			Unsafe.SkipInit(out System.IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_currentTestObj, (void*)(&intPtr));
			System.IntPtr intPtr2 = intPtr;
			return (intPtr2 != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr2) : null;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_currentTestObj, (void*)IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe static List<Mesh> debugSpawnedMeshes
	{
		get
		{
			Unsafe.SkipInit(out System.IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_debugSpawnedMeshes, (void*)(&intPtr));
			System.IntPtr intPtr2 = intPtr;
			return (intPtr2 != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<Mesh>>(intPtr2) : null;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_debugSpawnedMeshes, (void*)IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	public unsafe static Il2CppObjectBase obstacleDebugGrid
	{
		get
		{
			Unsafe.SkipInit(out System.IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_obstacleDebugGrid, (void*)(&intPtr));
			System.IntPtr intPtr2 = intPtr;
			return (intPtr2 != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppObjectBase>(intPtr2) : null;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_obstacleDebugGrid, (void*)IL2CPP.Il2CppObjectBaseToPtr(val));
		}
	}

	public unsafe static bool pathLinesDebugVisible
	{
		get
		{
			Unsafe.SkipInit(out bool result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_pathLinesDebugVisible, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_pathLinesDebugVisible, (void*)(&flag));
		}
	}

	public unsafe static string debugStr
	{
		get
		{
			Unsafe.SkipInit(out System.IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_debugStr, (void*)(&intPtr));
			return IL2CPP.Il2CppStringToManaged(intPtr);
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_debugStr, (void*)IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe static Configuration Config
	{
		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 239669, XrefRangeEnd = 239671, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Config_Private_Static_get_Configuration_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Configuration>(intPtr) : null;
		}
	}

	public unsafe static Generator CurrentGenerator
	{
		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 239671, XrefRangeEnd = 239673, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_CurrentGenerator_Public_Static_get_Generator_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Generator>(intPtr) : null;
		}
	}

	static ProceduralLevelGeneration()
	{
		Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Maps", "ProceduralLevelGeneration");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr);
		NativeFieldInfoPtr_generator = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, "generator");
		NativeFieldInfoPtr_generatedLevel = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, "generatedLevel");
		NativeFieldInfoPtr_moduleListBySelectedBiome = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, "moduleListBySelectedBiome");
		NativeFieldInfoPtr_biomeConfigsBySelectedBiome = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, "biomeConfigsBySelectedBiome");
		NativeFieldInfoPtr_biomeIdToSelectedBiomeId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, "biomeIdToSelectedBiomeId");
		NativeFieldInfoPtr_moduleListByBiome = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, "moduleListByBiome");
		NativeFieldInfoPtr_loadedModulesByFilename = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, "loadedModulesByFilename");
		NativeFieldInfoPtr_colorHuesByBiome = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, "colorHuesByBiome");
		NativeFieldInfoPtr_currentTestObj = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, "currentTestObj");
		NativeFieldInfoPtr_debugSpawnedMeshes = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, "debugSpawnedMeshes");
		NativeFieldInfoPtr_obstacleDebugGrid = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, "obstacleDebugGrid");
		NativeFieldInfoPtr_pathLinesDebugVisible = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, "pathLinesDebugVisible");
		NativeFieldInfoPtr_debugStr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, "debugStr");
		NativeMethodInfoPtr_get_Config_Private_Static_get_Configuration_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685634);
		NativeMethodInfoPtr_get_CurrentGenerator_Public_Static_get_Generator_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685635);
		NativeMethodInfoPtr_GenerateLevelAll_Public_Static_LevelData_GenerationSettings_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685636);
		NativeMethodInfoPtr_StartNewLevelGenerator_Public_Static_Void_GenerationSettings_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685637);
		NativeMethodInfoPtr_InitializeGeneration_Private_Static_Void_Generator_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685638);
		NativeMethodInfoPtr_GetBiomeHuesByBiomeColors_Public_Static_Void_BiomeData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685639);
		NativeMethodInfoPtr_LoadAllModuleLists_Private_Static_Void_GenerationSettings_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685640);
		NativeMethodInfoPtr_FinalizeMapGeneration_Public_Static_Void_Generator_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685641);
		NativeMethodInfoPtr_ExectuteIslandGen_Private_Static_Void_GenerationMapData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685642);
		NativeMethodInfoPtr_VisIslandGen_Public_Static_Void_GenerationMapData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685643);
		NativeMethodInfoPtr_VisClearIslandGen_Private_Static_Void_GenerationMapData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685644);
		NativeMethodInfoPtr_ManualIslandGenExecuteCellularAutomata_Public_Static_Void_GenerationMapData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685645);
		NativeMethodInfoPtr_ManualIslandGenAddTile_Public_Static_Void_GenerationMapData_Vector2Int_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685646);
		NativeMethodInfoPtr_ExectuteBiomeGen_Private_Static_Void_GenerationMapData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685647);
		NativeMethodInfoPtr_VisBiomeGen_Public_Static_Void_GenerationMapData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685648);
		NativeMethodInfoPtr_VisClearBiomeGen_Private_Static_Void_GenerationMapData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685649);
		NativeMethodInfoPtr_ManualBiomeGenAddTile_Public_Static_Void_GenerationMapData_Vector2Int_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685650);
		NativeMethodInfoPtr_ExectutePOIModuleGen_Private_Static_Void_GenerationMapData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685651);
		NativeMethodInfoPtr_ExectuteModuleGen_Private_Static_Void_GenerationMapData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685652);
		NativeMethodInfoPtr_VisModulePoints_Private_Static_Void_GenerationMapData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685653);
		NativeMethodInfoPtr_VisClearModulePoints_Private_Static_Void_GenerationMapData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685654);
		NativeMethodInfoPtr_ManualModuleGenAddModule_Public_Static_Void_GenerationMapData_List_1_ModulePoint_ModulePoint_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685655);
		NativeMethodInfoPtr_ManualModuleGenRemoveModule_Public_Static_Void_GenerationMapData_List_1_ModulePoint_ModulePoint_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685656);
		NativeMethodInfoPtr_ManualModuleGenClearModules_Public_Static_Void_GenerationMapData_List_1_ModulePoint_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685657);
		NativeMethodInfoPtr_ExectutePathGen_Public_Static_Void_GenerationMapData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685658);
		NativeMethodInfoPtr_CreatePathHashMap_Private_Static_Void_List_1_LineSegment_Il2CppObjectBase_Single_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685659);
		NativeMethodInfoPtr_VisPathGen_Public_Static_Void_GenerationMapData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685660);
		NativeMethodInfoPtr_VisClearPathGen_Private_Static_Void_GenerationMapData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685661);
		NativeMethodInfoPtr_ManualPathGenExecuteCleanup_Public_Static_Void_GenerationMapData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685662);
		NativeMethodInfoPtr_ManualPathGenVisualizePathLines_Public_Static_Void_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685663);
		NativeMethodInfoPtr_ManualPathGenAddTile_Public_Static_Void_GenerationMapData_Vector2Int_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685664);
		NativeMethodInfoPtr_ManualPathGenVisRefresh_Public_Static_Void_GenerationMapData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685665);
		NativeMethodInfoPtr_ExectuteObstacleGen_Public_Static_Void_GenerationMapData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685666);
		NativeMethodInfoPtr_VisObstacleGen_Private_Static_Void_GenerationMapData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685667);
		NativeMethodInfoPtr_VisCreateObstacleTile_Private_Static_GameObject_Int32_Int32_Int32_Transform_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685668);
		NativeMethodInfoPtr_VisClearObstacleGen_Private_Static_Void_GenerationMapData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685669);
		NativeMethodInfoPtr_ManualObstacleGenExecuteCellularAutomata_Public_Static_Void_GenerationMapData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685670);
		NativeMethodInfoPtr_ManualObstacleGenAddTile_Public_Static_Void_GenerationMapData_Vector2Int_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685671);
		NativeMethodInfoPtr_ExecuteSpawnPointGen_Private_Static_Void_GenerationMapData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685672);
		NativeMethodInfoPtr_VisSpawnPointGen_Private_Static_Void_GenerationMapData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685673);
		NativeMethodInfoPtr_VisClearSpawnPointGen_Private_Static_Void_GenerationMapData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685674);
		NativeMethodInfoPtr_ExecuteGenerateTiles_Public_Static_Void_GenerationMapData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685675);
		NativeMethodInfoPtr_CreateBiomePointsInRadius_Private_Static_List_1_Vector2_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685676);
		NativeMethodInfoPtr_RandomizePointListIndexes_Private_Static_List_1_Vector2_List_1_Vector2_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685677);
		NativeMethodInfoPtr_CreateColorsByBiome_Public_Static_Il2CppStructArray_1_Color_BiomeData_Il2CppStructArray_1_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685678);
		NativeMethodInfoPtr_GetBiomeColorsByProcgenBiomeAsset_Public_Static_Il2CppStructArray_1_Color_BiomeData_Il2CppStructArray_1_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685679);
		NativeMethodInfoPtr_CreateBiomeIdGridFromBiomeMapTex_Public_Static_Il2CppObjectBase_Texture2D_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685680);
		NativeMethodInfoPtr_GetBiomeIdByBiomeColor_Private_Static_Int32_Color_Il2CppStructArray_1_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685681);
		NativeMethodInfoPtr_SampleBiomeIdMap_Public_Static_Int32_Il2CppObjectBase_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685682);
		NativeMethodInfoPtr_IsAreaCornerFullyInBiome_Public_Static_Boolean_Il2CppObjectBase_Vector2Int_Vector2Int_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685683);
		NativeMethodInfoPtr_IsAreaFullyInBiome_Public_Static_Boolean_Il2CppObjectBase_Vector2Int_Vector2Int_Int32_Vector2Int_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685684);
		NativeMethodInfoPtr_IsPointNextToBiome_Public_Static_Boolean_Il2CppObjectBase_Vector2Int_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685685);
		NativeMethodInfoPtr_GetNextDifferentBiome_Public_Static_Int32_Il2CppObjectBase_Vector2Int_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685686);
		NativeMethodInfoPtr_GetModuleListInSelectedBiomes_Private_Static_Void_GenerationSettings_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685687);
		NativeMethodInfoPtr_GetModuleListInAllBiomes_Private_Static_Void_GenerationSettings_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685688);
		NativeMethodInfoPtr_RemoveUnselectedModulesInAllModuleTypesAndBiomes_Private_Static_Void_GenerationSettings_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685689);
		NativeMethodInfoPtr_RemoveUnselectedModulesInModuleTypes_Private_Static_Void_Il2CppStructArray_1_Boolean_List_1_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685690);
		NativeMethodInfoPtr_RandomizeAllPOIModuleLists_Private_Static_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685691);
		NativeMethodInfoPtr_RandomizeAllModuleLists_Private_Static_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685692);
		NativeMethodInfoPtr_GetModuleDataFromFilename_Private_Static_ModulePoint_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685693);
		NativeMethodInfoPtr_GetModuleByName_Private_Static_LevelData_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685694);
		NativeMethodInfoPtr_LoadAllSerializedModulesInList_Private_Static_Void_GenerationSettings_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685695);
		NativeMethodInfoPtr_LoadSerializedModulesByNameAndPath_Private_Static_Void_List_1_String_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685696);
		NativeMethodInfoPtr_GetNextModuleFromList_Private_Static_String_List_1_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685697);
		NativeMethodInfoPtr_SetModuleChoosenOnList_Private_Static_Void_List_1_String_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685698);
		NativeMethodInfoPtr_GetPOIThemedModuleNameByPOIName_Private_Static_String_Int32_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685699);
		NativeMethodInfoPtr_SetPOIThemedModuleChoosenByPOIName_Private_Static_Void_Int32_String_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685700);
		NativeMethodInfoPtr_InitializeSamplingPoints_Private_Static_Void_GenerationMapData_List_1_ModulePoint_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685701);
		NativeMethodInfoPtr_SampleAllPOIModuleDataInBiome_Private_Static_Void_GenerationMapData_Int32_Il2CppObjectBase_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685702);
		NativeMethodInfoPtr_SampleAllNormalModuleDataInBiome_Private_Static_Void_GenerationMapData_Int32_Il2CppObjectBase_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685703);
		NativeMethodInfoPtr_SamplePOIModules_Private_Static_Void_GenerationMapData_Int32_Il2CppObjectBase_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685704);
		NativeMethodInfoPtr_SamplePOIThemedModules_Private_Static_Void_GenerationMapData_Int32_Il2CppObjectBase_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685705);
		NativeMethodInfoPtr_SampleLandmarkModules_Private_Static_Void_GenerationMapData_Int32_Il2CppObjectBase_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685706);
		NativeMethodInfoPtr_SampleReviveModules_Private_Static_Void_GenerationMapData_Int32_Il2CppObjectBase_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685707);
		NativeMethodInfoPtr_SampleGenericModules_Private_Static_Void_GenerationMapData_Int32_Il2CppObjectBase_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685708);
		NativeMethodInfoPtr_SampleAllModuleDataInType_Private_Static_Void_GenerationMapData_List_1_String_List_1_ModulePoint_List_1_ModulePoint_Il2CppObjectBase_Int32_Int32_Int32_Int32_Int32_Boolean_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685709);
		NativeMethodInfoPtr_SampleAllModuleDataInTypeNumber_Private_Static_Void_GenerationMapData_List_1_String_List_1_ModulePoint_List_1_ModulePoint_Il2CppObjectBase_Int32_Int32_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685710);
		NativeMethodInfoPtr_SampleModulePointsDensity_Private_Static_Void_GenerationMapData_List_1_String_List_1_ModulePoint_List_1_ModulePoint_Il2CppObjectBase_Int32_Int32_Int32_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685711);
		NativeMethodInfoPtr_GetAreaPointsCopyFromModulePoints_Private_Static_List_1_AreaPoint_List_1_ModulePoint_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685712);
		NativeMethodInfoPtr_GetAllMapNamedModules_Private_Static_Il2CppReferenceArray_1_MapNamedModule_GenerationMapData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685713);
		NativeMethodInfoPtr_SpawnModuleOnPosition_Private_Static_Void_GenerationMapData_LevelData_Vector2Int_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685714);
		NativeMethodInfoPtr_ProcessSpawnPoints_Private_Static_List_1_Vector2Int_GenerationMapData_Il2CppObjectBase_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685715);
		NativeMethodInfoPtr_SamplePointsNumber_Private_Static_Void_GenerationMapData_Il2CppObjectBase_List_1_AreaPoint_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685716);
		NativeMethodInfoPtr_SamplePointsNumberDistance_Private_Static_Void_GenerationMapData_Il2CppObjectBase_List_1_AreaPoint_Int32_Int32_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685717);
		NativeMethodInfoPtr_SpawnAllPlayerSpawnPoints_Private_Static_Void_GenerationMapData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685718);
		NativeMethodInfoPtr_RemoveAllSpawnPointsInMap_Private_Static_Void_GenerationMapData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685719);
		NativeMethodInfoPtr_RemoveCloserSpawnPoints_Private_Static_Void_GenerationMapData_Int32_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685720);
		NativeMethodInfoPtr_GetBiomeConfigsByBiomeId_Private_Static_Il2CppReferenceArray_1_BiomeConfig_GenerationSettings_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685721);
		NativeMethodInfoPtr_GetAllPrefabIdsByPrefab_Private_Static_Dictionary_2_GameObject_Int32_List_1_GameObject_GenerationSettings_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685722);
		NativeMethodInfoPtr_CreateFloorBiomeTiles_Private_Static_Void_GenerationMapData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685723);
		NativeMethodInfoPtr_CreateFloorPathBiomeTiles_Private_Static_Void_GenerationMapData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685724);
		NativeMethodInfoPtr_CreateObstacleBiomeTiles_Private_Static_Void_GenerationMapData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685725);
		NativeMethodInfoPtr_GetVariationAssetAutotileBiome_Private_Static_VariationAsset_Il2CppObjectBase_Int32_Int32_Int32_AutotileAsset_byref_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685726);
		NativeMethodInfoPtr_GetVariationAssetAutotileHash_Private_Static_VariationAsset_Int32_Int32_Il2CppObjectBase_AutotileAsset_byref_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685727);
		NativeMethodInfoPtr_BuildSerializedMapSettings_Private_Static_MapSettings_GenerationMapData_Il2CppStructArray_1_Vector2_Il2CppReferenceArray_1_MapNamedModule_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685728);
		NativeMethodInfoPtr_CleanUp_Private_Static_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685729);
		NativeMethodInfoPtr_CleanUpGenerationData_Private_Static_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685730);
		NativeMethodInfoPtr_ClearCurrentMap_Public_Static_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685731);
		NativeMethodInfoPtr_VisualizeBiomeCentroidsOnScene_Private_Static_Void_GenerationMapData_Il2CppStructArray_1_Vector2_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685732);
		NativeMethodInfoPtr_VisualizePointsOnScene_Private_Static_Void_Il2CppStructArray_1_Vector2_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProceduralLevelGeneration>.NativeClassPtr, 100685733);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 239673, XrefRangeEnd = 239714, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static LevelData GenerateLevelAll(GenerationSettings settings)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)settings);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GenerateLevelAll_Public_Static_LevelData_GenerationSettings_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<LevelData>(intPtr) : null;
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 239719, RefRangeEnd = 239720, XrefRangeStart = 239714, XrefRangeEnd = 239719, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void StartNewLevelGenerator(GenerationSettings settings)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)settings);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_StartNewLevelGenerator_Public_Static_Void_GenerationSettings_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 239810, RefRangeEnd = 239812, XrefRangeStart = 239720, XrefRangeEnd = 239810, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void InitializeGeneration(Generator generator)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)generator);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_InitializeGeneration_Private_Static_Void_Generator_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 239830, RefRangeEnd = 239831, XrefRangeStart = 239812, XrefRangeEnd = 239830, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void GetBiomeHuesByBiomeColors(BiomeData biomeData)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)biomeData);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetBiomeHuesByBiomeColors_Public_Static_Void_BiomeData_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 239872, RefRangeEnd = 239873, XrefRangeStart = 239831, XrefRangeEnd = 239872, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void LoadAllModuleLists(GenerationSettings settings)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)settings);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_LoadAllModuleLists_Private_Static_Void_GenerationSettings_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 239901, RefRangeEnd = 239904, XrefRangeStart = 239873, XrefRangeEnd = 239901, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void FinalizeMapGeneration(Generator generator)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)generator);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_FinalizeMapGeneration_Public_Static_Void_Generator_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 239904, XrefRangeEnd = 239933, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void ExectuteIslandGen(GenerationMapData data)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ExectuteIslandGen_Private_Static_Void_GenerationMapData_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 239943, RefRangeEnd = 239944, XrefRangeStart = 239933, XrefRangeEnd = 239943, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void VisIslandGen(GenerationMapData data)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_VisIslandGen_Public_Static_Void_GenerationMapData_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 239944, XrefRangeEnd = 239950, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void VisClearIslandGen(GenerationMapData data)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_VisClearIslandGen_Private_Static_Void_GenerationMapData_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 239967, RefRangeEnd = 239968, XrefRangeStart = 239950, XrefRangeEnd = 239967, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void ManualIslandGenExecuteCellularAutomata(GenerationMapData data)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ManualIslandGenExecuteCellularAutomata_Public_Static_Void_GenerationMapData_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 239969, RefRangeEnd = 239970, XrefRangeStart = 239968, XrefRangeEnd = 239969, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void ManualIslandGenAddTile(GenerationMapData data, Vector2Int tilePos, int newTileId)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		*(Vector2Int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &tilePos;
		*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &newTileId;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ManualIslandGenAddTile_Public_Static_Void_GenerationMapData_Vector2Int_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 239970, XrefRangeEnd = 240039, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void ExectuteBiomeGen(GenerationMapData data)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ExectuteBiomeGen_Private_Static_Void_GenerationMapData_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 240058, RefRangeEnd = 240059, XrefRangeStart = 240039, XrefRangeEnd = 240058, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void VisBiomeGen(GenerationMapData data)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_VisBiomeGen_Public_Static_Void_GenerationMapData_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 240059, XrefRangeEnd = 240065, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void VisClearBiomeGen(GenerationMapData data)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_VisClearBiomeGen_Private_Static_Void_GenerationMapData_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 240068, RefRangeEnd = 240069, XrefRangeStart = 240065, XrefRangeEnd = 240068, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void ManualBiomeGenAddTile(GenerationMapData data, Vector2Int tilePos, int newTileId)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		*(Vector2Int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &tilePos;
		*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &newTileId;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ManualBiomeGenAddTile_Public_Static_Void_GenerationMapData_Vector2Int_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 240069, XrefRangeEnd = 240124, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void ExectutePOIModuleGen(GenerationMapData data)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ExectutePOIModuleGen_Private_Static_Void_GenerationMapData_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 240124, XrefRangeEnd = 240171, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void ExectuteModuleGen(GenerationMapData data)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ExectuteModuleGen_Private_Static_Void_GenerationMapData_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 240201, RefRangeEnd = 240204, XrefRangeStart = 240171, XrefRangeEnd = 240201, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void VisModulePoints(GenerationMapData data)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_VisModulePoints_Private_Static_Void_GenerationMapData_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 240204, XrefRangeEnd = 240234, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void VisClearModulePoints(GenerationMapData data)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_VisClearModulePoints_Private_Static_Void_GenerationMapData_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 240243, RefRangeEnd = 240244, XrefRangeStart = 240234, XrefRangeEnd = 240243, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void ManualModuleGenAddModule(GenerationMapData data, List<ModulePoint> modulePointsList, ModulePoint newModule)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)modulePointsList);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)newModule));
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ManualModuleGenAddModule_Public_Static_Void_GenerationMapData_List_1_ModulePoint_ModulePoint_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 240257, RefRangeEnd = 240258, XrefRangeStart = 240244, XrefRangeEnd = 240257, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void ManualModuleGenRemoveModule(GenerationMapData data, List<ModulePoint> modulePointsList, ModulePoint moduleToRemove)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)modulePointsList);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)moduleToRemove));
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ManualModuleGenRemoveModule_Public_Static_Void_GenerationMapData_List_1_ModulePoint_ModulePoint_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 240267, RefRangeEnd = 240268, XrefRangeStart = 240258, XrefRangeEnd = 240267, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void ManualModuleGenClearModules(GenerationMapData data, List<ModulePoint> modulePointsList)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)modulePointsList);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ManualModuleGenClearModules_Public_Static_Void_GenerationMapData_List_1_ModulePoint_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 240268, XrefRangeEnd = 240351, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void ExectutePathGen(GenerationMapData data)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ExectutePathGen_Public_Static_Void_GenerationMapData_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 240374, RefRangeEnd = 240376, XrefRangeStart = 240351, XrefRangeEnd = 240374, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void CreatePathHashMap(List<LineSegment> pathSegments, Il2CppObjectBase hashMap, float minDist = 2f, int shapeSize = 4)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[4];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)pathSegments);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr(hashMap);
		*(float**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &minDist;
		*(int**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &shapeSize;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CreatePathHashMap_Private_Static_Void_List_1_LineSegment_Il2CppObjectBase_Single_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 240410, RefRangeEnd = 240412, XrefRangeStart = 240376, XrefRangeEnd = 240410, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void VisPathGen(GenerationMapData data)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_VisPathGen_Public_Static_Void_GenerationMapData_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 240439, RefRangeEnd = 240440, XrefRangeStart = 240412, XrefRangeEnd = 240439, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void VisClearPathGen(GenerationMapData data)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_VisClearPathGen_Private_Static_Void_GenerationMapData_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 240446, RefRangeEnd = 240447, XrefRangeStart = 240440, XrefRangeEnd = 240446, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void ManualPathGenExecuteCleanup(GenerationMapData data)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ManualPathGenExecuteCleanup_Public_Static_Void_GenerationMapData_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 240466, RefRangeEnd = 240467, XrefRangeStart = 240447, XrefRangeEnd = 240466, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void ManualPathGenVisualizePathLines(bool isVisible)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&isVisible);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ManualPathGenVisualizePathLines_Public_Static_Void_Boolean_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 240477, RefRangeEnd = 240478, XrefRangeStart = 240467, XrefRangeEnd = 240477, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void ManualPathGenAddTile(GenerationMapData data, Vector2Int tilePos, int newTileId)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		*(Vector2Int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &tilePos;
		*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &newTileId;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ManualPathGenAddTile_Public_Static_Void_GenerationMapData_Vector2Int_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 240481, RefRangeEnd = 240482, XrefRangeStart = 240478, XrefRangeEnd = 240481, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void ManualPathGenVisRefresh(GenerationMapData data)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ManualPathGenVisRefresh_Public_Static_Void_GenerationMapData_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 240482, XrefRangeEnd = 240515, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void ExectuteObstacleGen(GenerationMapData data)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ExectuteObstacleGen_Public_Static_Void_GenerationMapData_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 240533, RefRangeEnd = 240534, XrefRangeStart = 240515, XrefRangeEnd = 240533, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void VisObstacleGen(GenerationMapData data)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_VisObstacleGen_Private_Static_Void_GenerationMapData_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 240548, RefRangeEnd = 240550, XrefRangeStart = 240534, XrefRangeEnd = 240548, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static GameObject VisCreateObstacleTile(int x, int y, int mapUnitSize, Transform parent)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[4];
		*ptr = (nint)(&x);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &y;
		*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &mapUnitSize;
		*(System.IntPtr*)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)parent);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_VisCreateObstacleTile_Private_Static_GameObject_Int32_Int32_Int32_Transform_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 240571, RefRangeEnd = 240572, XrefRangeStart = 240550, XrefRangeEnd = 240571, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void VisClearObstacleGen(GenerationMapData data)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_VisClearObstacleGen_Private_Static_Void_GenerationMapData_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 240576, RefRangeEnd = 240577, XrefRangeStart = 240572, XrefRangeEnd = 240576, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void ManualObstacleGenExecuteCellularAutomata(GenerationMapData data)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ManualObstacleGenExecuteCellularAutomata_Public_Static_Void_GenerationMapData_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 240595, RefRangeEnd = 240596, XrefRangeStart = 240577, XrefRangeEnd = 240595, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void ManualObstacleGenAddTile(GenerationMapData data, Vector2Int tilePos, int newTileId)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		*(Vector2Int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &tilePos;
		*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &newTileId;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ManualObstacleGenAddTile_Public_Static_Void_GenerationMapData_Vector2Int_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 240596, XrefRangeEnd = 240630, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void ExecuteSpawnPointGen(GenerationMapData data)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ExecuteSpawnPointGen_Private_Static_Void_GenerationMapData_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 240630, XrefRangeEnd = 240662, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void VisSpawnPointGen(GenerationMapData data)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_VisSpawnPointGen_Private_Static_Void_GenerationMapData_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 240683, RefRangeEnd = 240684, XrefRangeStart = 240662, XrefRangeEnd = 240683, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void VisClearSpawnPointGen(GenerationMapData data)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_VisClearSpawnPointGen_Private_Static_Void_GenerationMapData_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 240684, XrefRangeEnd = 240757, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void ExecuteGenerateTiles(GenerationMapData data)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ExecuteGenerateTiles_Public_Static_Void_GenerationMapData_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 240780, RefRangeEnd = 240781, XrefRangeStart = 240757, XrefRangeEnd = 240780, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static List<Vector2> CreateBiomePointsInRadius(int numPoints)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&numPoints);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CreateBiomePointsInRadius_Private_Static_List_1_Vector2_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<Vector2>>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 240781, XrefRangeEnd = 240790, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static List<Vector2> RandomizePointListIndexes(List<Vector2> pointList)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)pointList);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_RandomizePointListIndexes_Private_Static_List_1_Vector2_List_1_Vector2_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<Vector2>>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 240790, XrefRangeEnd = 240806, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Il2CppStructArray<Color> CreateColorsByBiome(BiomeData biomeData, Il2CppStructArray<int> selectedBiomeIds, int biomeNumber)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)biomeData);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)selectedBiomeIds);
		*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &biomeNumber;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CreateColorsByBiome_Public_Static_Il2CppStructArray_1_Color_BiomeData_Il2CppStructArray_1_Int32_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<Color>>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 240806, XrefRangeEnd = 240818, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Il2CppStructArray<Color> GetBiomeColorsByProcgenBiomeAsset(BiomeData biomeData, Il2CppStructArray<int> selectedBiomeIds)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)biomeData);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)selectedBiomeIds);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetBiomeColorsByProcgenBiomeAsset_Public_Static_Il2CppStructArray_1_Color_BiomeData_Il2CppStructArray_1_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<Color>>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 240818, XrefRangeEnd = 240826, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Il2CppObjectBase CreateBiomeIdGridFromBiomeMapTex(Texture2D biomeColorMap)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)biomeColorMap);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CreateBiomeIdGridFromBiomeMapTex_Public_Static_Il2CppObjectBase_Texture2D_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppObjectBase>(intPtr) : null;
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 240830, RefRangeEnd = 240832, XrefRangeStart = 240826, XrefRangeEnd = 240830, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static int GetBiomeIdByBiomeColor(Color biomeColor, Il2CppStructArray<int> colorHuesByBiome)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&biomeColor);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)colorHuesByBiome);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetBiomeIdByBiomeColor_Private_Static_Int32_Color_Il2CppStructArray_1_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(28)]
	[CachedScanResults(RefRangeStart = 240835, RefRangeEnd = 240863, XrefRangeStart = 240832, XrefRangeEnd = 240835, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static int SampleBiomeIdMap(Il2CppObjectBase biomeIdGrid, int xTiemapPos, int yTiemapPos)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr(biomeIdGrid);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &xTiemapPos;
		*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &yTiemapPos;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SampleBiomeIdMap_Public_Static_Int32_Il2CppObjectBase_Int32_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 240863, XrefRangeEnd = 240882, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static bool IsAreaCornerFullyInBiome(Il2CppObjectBase biomeIdGrid, Vector2Int position, Vector2Int size)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr(biomeIdGrid);
		*(Vector2Int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &position;
		*(Vector2Int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &size;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_IsAreaCornerFullyInBiome_Public_Static_Boolean_Il2CppObjectBase_Vector2Int_Vector2Int_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 240903, RefRangeEnd = 240905, XrefRangeStart = 240882, XrefRangeEnd = 240903, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static bool IsAreaFullyInBiome(Il2CppObjectBase biomeIdGrid, Vector2Int position, Vector2Int size, int originalBiomeId, Vector2Int tilemapSize)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[5];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr(biomeIdGrid);
		*(Vector2Int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &position;
		*(Vector2Int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &size;
		*(int**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &originalBiomeId;
		*(Vector2Int**)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(System.IntPtr)))) = &tilemapSize;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_IsAreaFullyInBiome_Public_Static_Boolean_Il2CppObjectBase_Vector2Int_Vector2Int_Int32_Vector2Int_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 240934, RefRangeEnd = 240935, XrefRangeStart = 240905, XrefRangeEnd = 240934, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static bool IsPointNextToBiome(Il2CppObjectBase biomeIdGrid, Vector2Int position, int biomeId)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr(biomeIdGrid);
		*(Vector2Int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &position;
		*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &biomeId;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_IsPointNextToBiome_Public_Static_Boolean_Il2CppObjectBase_Vector2Int_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 240964, RefRangeEnd = 240968, XrefRangeStart = 240935, XrefRangeEnd = 240964, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static int GetNextDifferentBiome(Il2CppObjectBase biomeIdGrid, Vector2Int position, int originalBiomeId)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr(biomeIdGrid);
		*(Vector2Int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &position;
		*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &originalBiomeId;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetNextDifferentBiome_Public_Static_Int32_Il2CppObjectBase_Vector2Int_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 240968, XrefRangeEnd = 240971, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void GetModuleListInSelectedBiomes(GenerationSettings settings)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)settings);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetModuleListInSelectedBiomes_Private_Static_Void_GenerationSettings_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 240971, XrefRangeEnd = 240974, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void GetModuleListInAllBiomes(GenerationSettings settings)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)settings);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetModuleListInAllBiomes_Private_Static_Void_GenerationSettings_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 240996, RefRangeEnd = 240997, XrefRangeStart = 240974, XrefRangeEnd = 240996, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void RemoveUnselectedModulesInAllModuleTypesAndBiomes(GenerationSettings settings)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)settings);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_RemoveUnselectedModulesInAllModuleTypesAndBiomes_Private_Static_Void_GenerationSettings_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 240997, XrefRangeEnd = 241000, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void RemoveUnselectedModulesInModuleTypes(Il2CppStructArray<bool> selectedModuleIds, List<string> moduleList)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)selectedModuleIds);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)moduleList);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_RemoveUnselectedModulesInModuleTypes_Private_Static_Void_Il2CppStructArray_1_Boolean_List_1_String_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 241000, XrefRangeEnd = 241008, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void RandomizeAllPOIModuleLists()
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_RandomizeAllPOIModuleLists_Private_Static_Void_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 241025, RefRangeEnd = 241026, XrefRangeStart = 241008, XrefRangeEnd = 241025, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void RandomizeAllModuleLists()
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_RandomizeAllModuleLists_Private_Static_Void_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 241041, RefRangeEnd = 241044, XrefRangeStart = 241026, XrefRangeEnd = 241041, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static ModulePoint GetModuleDataFromFilename(string moduleName)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(moduleName);
		Unsafe.SkipInit(out System.IntPtr intPtr);
		System.IntPtr pointer = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetModuleDataFromFilename_Private_Static_ModulePoint_String_0, (System.IntPtr)0, (void**)ptr, ref intPtr);
		Il2CppException.RaiseExceptionIfNecessary(intPtr);
		return new ModulePoint(pointer);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 241044, XrefRangeEnd = 241052, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static LevelData GetModuleByName(string moduleName)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(moduleName);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetModuleByName_Private_Static_LevelData_String_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<LevelData>(intPtr) : null;
	}

	[CallerCount(17738)]
	[CachedScanResults(RefRangeStart = 5595, RefRangeEnd = 23333, XrefRangeStart = 5595, XrefRangeEnd = 23333, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void LoadAllSerializedModulesInList(GenerationSettings settings)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)settings);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_LoadAllSerializedModulesInList_Private_Static_Void_GenerationSettings_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(17738)]
	[CachedScanResults(RefRangeStart = 5595, RefRangeEnd = 23333, XrefRangeStart = 5595, XrefRangeEnd = 23333, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void LoadSerializedModulesByNameAndPath(List<string> moduleNames, string path)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)moduleNames);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(path);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_LoadSerializedModulesByNameAndPath_Private_Static_Void_List_1_String_String_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 241055, RefRangeEnd = 241058, XrefRangeStart = 241052, XrefRangeEnd = 241055, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static string GetNextModuleFromList(List<string> moduleList)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)moduleList);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetNextModuleFromList_Private_Static_String_List_1_String_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 241062, RefRangeEnd = 241065, XrefRangeStart = 241058, XrefRangeEnd = 241062, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void SetModuleChoosenOnList(List<string> moduleList, string choosenModule)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)moduleList);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(choosenModule);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetModuleChoosenOnList_Private_Static_Void_List_1_String_String_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 241065, XrefRangeEnd = 241070, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static string GetPOIThemedModuleNameByPOIName(int biomeId, string poiModuleName)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&biomeId);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(poiModuleName);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetPOIThemedModuleNameByPOIName_Private_Static_String_Int32_String_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 241070, XrefRangeEnd = 241080, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void SetPOIThemedModuleChoosenByPOIName(int biomeId, string poiModuleName, string choosenModule)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = (nint)(&biomeId);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(poiModuleName);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(choosenModule);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetPOIThemedModuleChoosenByPOIName_Private_Static_Void_Int32_String_String_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 241088, RefRangeEnd = 241090, XrefRangeStart = 241080, XrefRangeEnd = 241088, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void InitializeSamplingPoints(GenerationMapData data, List<ModulePoint> moduleList, int biomeId, int pointUnitDensity = 20)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[4];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)moduleList);
		*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &biomeId;
		*(int**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &pointUnitDensity;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_InitializeSamplingPoints_Private_Static_Void_GenerationMapData_List_1_ModulePoint_Int32_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 241090, XrefRangeEnd = 241093, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void SampleAllPOIModuleDataInBiome(GenerationMapData data, int biomeId, Il2CppObjectBase spatialHash)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &biomeId;
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr(spatialHash);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SampleAllPOIModuleDataInBiome_Private_Static_Void_GenerationMapData_Int32_Il2CppObjectBase_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 241107, RefRangeEnd = 241108, XrefRangeStart = 241093, XrefRangeEnd = 241107, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void SampleAllNormalModuleDataInBiome(GenerationMapData data, int biomeId, Il2CppObjectBase spatialHash)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &biomeId;
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr(spatialHash);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SampleAllNormalModuleDataInBiome_Private_Static_Void_GenerationMapData_Int32_Il2CppObjectBase_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 241129, RefRangeEnd = 241131, XrefRangeStart = 241108, XrefRangeEnd = 241129, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void SamplePOIModules(GenerationMapData data, int biomeId, Il2CppObjectBase spatialHash)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &biomeId;
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr(spatialHash);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SamplePOIModules_Private_Static_Void_GenerationMapData_Int32_Il2CppObjectBase_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 241150, RefRangeEnd = 241151, XrefRangeStart = 241131, XrefRangeEnd = 241150, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void SamplePOIThemedModules(GenerationMapData data, int biomeId, Il2CppObjectBase spatialHash)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &biomeId;
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr(spatialHash);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SamplePOIThemedModules_Private_Static_Void_GenerationMapData_Int32_Il2CppObjectBase_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 241151, XrefRangeEnd = 241156, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void SampleLandmarkModules(GenerationMapData data, int biomeId, Il2CppObjectBase spatialHash)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &biomeId;
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr(spatialHash);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SampleLandmarkModules_Private_Static_Void_GenerationMapData_Int32_Il2CppObjectBase_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 241156, XrefRangeEnd = 241161, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void SampleReviveModules(GenerationMapData data, int biomeId, Il2CppObjectBase spatialHash)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &biomeId;
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr(spatialHash);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SampleReviveModules_Private_Static_Void_GenerationMapData_Int32_Il2CppObjectBase_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 241174, RefRangeEnd = 241175, XrefRangeStart = 241161, XrefRangeEnd = 241174, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void SampleGenericModules(GenerationMapData data, int biomeId, Il2CppObjectBase spatialHash)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &biomeId;
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr(spatialHash);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SampleGenericModules_Private_Static_Void_GenerationMapData_Int32_Il2CppObjectBase_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(8)]
	[CachedScanResults(RefRangeStart = 241215, RefRangeEnd = 241223, XrefRangeStart = 241175, XrefRangeEnd = 241215, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void SampleAllModuleDataInType(GenerationMapData data, List<string> moduleTypeList, List<ModulePoint> spawnPointSource, List<ModulePoint> newAddedModules, Il2CppObjectBase spatialHash, int biomeId, int minDistanceToOthers, int maxDistanceToOthers, int minTypeDistance, int maxTypeDistance, bool sampleInfinetily = true, int sampleIterations = 10)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[12];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)moduleTypeList);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)spawnPointSource);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)newAddedModules);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr(spatialHash);
		*(int**)((byte*)ptr + checked((nuint)5u * unchecked((nuint)sizeof(System.IntPtr)))) = &biomeId;
		*(int**)((byte*)ptr + checked((nuint)6u * unchecked((nuint)sizeof(System.IntPtr)))) = &minDistanceToOthers;
		*(int**)((byte*)ptr + checked((nuint)7u * unchecked((nuint)sizeof(System.IntPtr)))) = &maxDistanceToOthers;
		*(int**)((byte*)ptr + checked((nuint)8u * unchecked((nuint)sizeof(System.IntPtr)))) = &minTypeDistance;
		*(int**)((byte*)ptr + checked((nuint)9u * unchecked((nuint)sizeof(System.IntPtr)))) = &maxTypeDistance;
		*(bool**)((byte*)ptr + checked((nuint)10u * unchecked((nuint)sizeof(System.IntPtr)))) = &sampleInfinetily;
		*(int**)((byte*)ptr + checked((nuint)11u * unchecked((nuint)sizeof(System.IntPtr)))) = &sampleIterations;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SampleAllModuleDataInType_Private_Static_Void_GenerationMapData_List_1_String_List_1_ModulePoint_List_1_ModulePoint_Il2CppObjectBase_Int32_Int32_Int32_Int32_Int32_Boolean_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 241250, RefRangeEnd = 241251, XrefRangeStart = 241223, XrefRangeEnd = 241250, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void SampleAllModuleDataInTypeNumber(GenerationMapData data, List<string> moduleTypeList, List<ModulePoint> spawnPointsSource, List<ModulePoint> newPoints, Il2CppObjectBase spatialHash, int biomeId, int minDistance, int desiredNumberToSpawn, int sampleIterations = 10)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[9];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)moduleTypeList);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)spawnPointsSource);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)newPoints);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr(spatialHash);
		*(int**)((byte*)ptr + checked((nuint)5u * unchecked((nuint)sizeof(System.IntPtr)))) = &biomeId;
		*(int**)((byte*)ptr + checked((nuint)6u * unchecked((nuint)sizeof(System.IntPtr)))) = &minDistance;
		*(int**)((byte*)ptr + checked((nuint)7u * unchecked((nuint)sizeof(System.IntPtr)))) = &desiredNumberToSpawn;
		*(int**)((byte*)ptr + checked((nuint)8u * unchecked((nuint)sizeof(System.IntPtr)))) = &sampleIterations;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SampleAllModuleDataInTypeNumber_Private_Static_Void_GenerationMapData_List_1_String_List_1_ModulePoint_List_1_ModulePoint_Il2CppObjectBase_Int32_Int32_Int32_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 241292, RefRangeEnd = 241293, XrefRangeStart = 241251, XrefRangeEnd = 241292, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void SampleModulePointsDensity(GenerationMapData data, List<string> moduleTypeList, List<ModulePoint> spawnPointsSource, List<ModulePoint> newSampledModules, Il2CppObjectBase spatialHash, int biomeId, int distance, int generalPadding, int desiredNumberToSpawn, int sampleIterations = 10)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[10];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)moduleTypeList);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)spawnPointsSource);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)newSampledModules);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr(spatialHash);
		*(int**)((byte*)ptr + checked((nuint)5u * unchecked((nuint)sizeof(System.IntPtr)))) = &biomeId;
		*(int**)((byte*)ptr + checked((nuint)6u * unchecked((nuint)sizeof(System.IntPtr)))) = &distance;
		*(int**)((byte*)ptr + checked((nuint)7u * unchecked((nuint)sizeof(System.IntPtr)))) = &generalPadding;
		*(int**)((byte*)ptr + checked((nuint)8u * unchecked((nuint)sizeof(System.IntPtr)))) = &desiredNumberToSpawn;
		*(int**)((byte*)ptr + checked((nuint)9u * unchecked((nuint)sizeof(System.IntPtr)))) = &sampleIterations;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SampleModulePointsDensity_Private_Static_Void_GenerationMapData_List_1_String_List_1_ModulePoint_List_1_ModulePoint_Il2CppObjectBase_Int32_Int32_Int32_Int32_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 241305, RefRangeEnd = 241308, XrefRangeStart = 241293, XrefRangeEnd = 241305, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static List<AreaPoint> GetAreaPointsCopyFromModulePoints(List<ModulePoint> modulePoints)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)modulePoints);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetAreaPointsCopyFromModulePoints_Private_Static_List_1_AreaPoint_List_1_ModulePoint_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<AreaPoint>>(intPtr) : null;
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 241327, RefRangeEnd = 241328, XrefRangeStart = 241308, XrefRangeEnd = 241327, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Il2CppReferenceArray<MapSettings.MapNamedModule> GetAllMapNamedModules(GenerationMapData data)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetAllMapNamedModules_Private_Static_Il2CppReferenceArray_1_MapNamedModule_GenerationMapData_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<MapSettings.MapNamedModule>>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 241328, XrefRangeEnd = 241342, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void SpawnModuleOnPosition(GenerationMapData data, LevelData moduleLevelData, Vector2Int position, int modRotId)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[4];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)moduleLevelData);
		*(Vector2Int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &position;
		*(int**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &modRotId;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SpawnModuleOnPosition_Private_Static_Void_GenerationMapData_LevelData_Vector2Int_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 241377, RefRangeEnd = 241378, XrefRangeStart = 241342, XrefRangeEnd = 241377, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static List<Vector2Int> ProcessSpawnPoints(GenerationMapData data, Il2CppObjectBase spatialHash, int desiredPlayerSpawnNumber)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr(spatialHash);
		*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &desiredPlayerSpawnNumber;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ProcessSpawnPoints_Private_Static_List_1_Vector2Int_GenerationMapData_Il2CppObjectBase_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<Vector2Int>>(intPtr) : null;
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 241409, RefRangeEnd = 241410, XrefRangeStart = 241378, XrefRangeEnd = 241409, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void SamplePointsNumber(GenerationMapData data, Il2CppObjectBase spatialHash, List<AreaPoint> newAddedPoints, int desiredNumberToSpawn)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[4];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr(spatialHash);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)newAddedPoints);
		*(int**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &desiredNumberToSpawn;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SamplePointsNumber_Private_Static_Void_GenerationMapData_Il2CppObjectBase_List_1_AreaPoint_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 241439, RefRangeEnd = 241440, XrefRangeStart = 241410, XrefRangeEnd = 241439, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void SamplePointsNumberDistance(GenerationMapData data, Il2CppObjectBase spatialHash, List<AreaPoint> newAddedPoints, int distance, int areaPadding, int desiredPoints, int sampleIterations = 10)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[7];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr(spatialHash);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)newAddedPoints);
		*(int**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &distance;
		*(int**)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(System.IntPtr)))) = &areaPadding;
		*(int**)((byte*)ptr + checked((nuint)5u * unchecked((nuint)sizeof(System.IntPtr)))) = &desiredPoints;
		*(int**)((byte*)ptr + checked((nuint)6u * unchecked((nuint)sizeof(System.IntPtr)))) = &sampleIterations;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SamplePointsNumberDistance_Private_Static_Void_GenerationMapData_Il2CppObjectBase_List_1_AreaPoint_Int32_Int32_Int32_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 241440, XrefRangeEnd = 241448, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void SpawnAllPlayerSpawnPoints(GenerationMapData data)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SpawnAllPlayerSpawnPoints_Private_Static_Void_GenerationMapData_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 241448, XrefRangeEnd = 241457, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void RemoveAllSpawnPointsInMap(GenerationMapData data)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_RemoveAllSpawnPointsInMap_Private_Static_Void_GenerationMapData_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 241457, XrefRangeEnd = 241493, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void RemoveCloserSpawnPoints(GenerationMapData data, int minSpawnsRequiered = 8, int minDistancePerSpawn = 20)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &minSpawnsRequiered;
		*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &minDistancePerSpawn;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_RemoveCloserSpawnPoints_Private_Static_Void_GenerationMapData_Int32_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 241493, XrefRangeEnd = 241497, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Il2CppReferenceArray<BiomeData.BiomeConfig> GetBiomeConfigsByBiomeId(GenerationSettings settings)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)settings);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetBiomeConfigsByBiomeId_Private_Static_Il2CppReferenceArray_1_BiomeConfig_GenerationSettings_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<BiomeData.BiomeConfig>>(intPtr) : null;
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 241512, RefRangeEnd = 241515, XrefRangeStart = 241497, XrefRangeEnd = 241512, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static Dictionary<GameObject, int> GetAllPrefabIdsByPrefab(List<GameObject> assets, GenerationSettings settings)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)assets);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)settings);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetAllPrefabIdsByPrefab_Private_Static_Dictionary_2_GameObject_Int32_List_1_GameObject_GenerationSettings_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Dictionary<GameObject, int>>(intPtr) : null;
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 241570, RefRangeEnd = 241571, XrefRangeStart = 241515, XrefRangeEnd = 241570, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void CreateFloorBiomeTiles(GenerationMapData data)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CreateFloorBiomeTiles_Private_Static_Void_GenerationMapData_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 241616, RefRangeEnd = 241617, XrefRangeStart = 241571, XrefRangeEnd = 241616, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void CreateFloorPathBiomeTiles(GenerationMapData data)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CreateFloorPathBiomeTiles_Private_Static_Void_GenerationMapData_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 241777, RefRangeEnd = 241778, XrefRangeStart = 241617, XrefRangeEnd = 241777, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void CreateObstacleBiomeTiles(GenerationMapData data)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CreateObstacleBiomeTiles_Private_Static_Void_GenerationMapData_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 241813, RefRangeEnd = 241814, XrefRangeStart = 241778, XrefRangeEnd = 241813, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static AssetPalette.VariationAsset GetVariationAssetAutotileBiome(Il2CppObjectBase biomeIdGrid, int x, int y, int sampledBiomeId, AssetPalette.AutotileAsset autotileAsset, out int rotationId)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[6];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr(biomeIdGrid);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &x;
		*(int**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &y;
		*(int**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &sampledBiomeId;
		*(System.IntPtr*)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)autotileAsset);
		*(void**)((byte*)ptr + checked((nuint)5u * unchecked((nuint)sizeof(System.IntPtr)))) = Unsafe.AsPointer(ref rotationId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetVariationAssetAutotileBiome_Private_Static_VariationAsset_Il2CppObjectBase_Int32_Int32_Int32_AutotileAsset_byref_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AssetPalette.VariationAsset>(intPtr) : null;
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 241815, RefRangeEnd = 241817, XrefRangeStart = 241814, XrefRangeEnd = 241815, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static AssetPalette.VariationAsset GetVariationAssetAutotileHash(int x, int y, Il2CppObjectBase hash, AssetPalette.AutotileAsset autotileAsset, out int rotationId)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[5];
		*ptr = (nint)(&x);
		*(int**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &y;
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr(hash);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)autotileAsset);
		*(void**)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(System.IntPtr)))) = Unsafe.AsPointer(ref rotationId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetVariationAssetAutotileHash_Private_Static_VariationAsset_Int32_Int32_Il2CppObjectBase_AutotileAsset_byref_Int32_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AssetPalette.VariationAsset>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 241817, XrefRangeEnd = 241825, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static MapSettings BuildSerializedMapSettings(GenerationMapData data, Il2CppStructArray<Vector2> biomePointsNormalized, Il2CppReferenceArray<MapSettings.MapNamedModule> namedModules)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)biomePointsNormalized);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)namedModules);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_BuildSerializedMapSettings_Private_Static_MapSettings_GenerationMapData_Il2CppStructArray_1_Vector2_Il2CppReferenceArray_1_MapNamedModule_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<MapSettings>(intPtr) : null;
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 241825, XrefRangeEnd = 241829, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void CleanUp()
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CleanUp_Private_Static_Void_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 241848, RefRangeEnd = 241850, XrefRangeStart = 241829, XrefRangeEnd = 241848, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void CleanUpGenerationData()
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CleanUpGenerationData_Private_Static_Void_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 241860, RefRangeEnd = 241862, XrefRangeStart = 241850, XrefRangeEnd = 241860, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void ClearCurrentMap()
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ClearCurrentMap_Public_Static_Void_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 241886, RefRangeEnd = 241887, XrefRangeStart = 241862, XrefRangeEnd = 241886, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void VisualizeBiomeCentroidsOnScene(GenerationMapData data, Il2CppStructArray<Vector2> biomeCentroidsNormalized)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)data);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)biomeCentroidsNormalized);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_VisualizeBiomeCentroidsOnScene_Private_Static_Void_GenerationMapData_Il2CppStructArray_1_Vector2_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 241887, XrefRangeEnd = 241909, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void VisualizePointsOnScene(Il2CppStructArray<Vector2> pointsWp, string name = "debugPointsWp")
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)pointsWp);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.ManagedStringToIl2Cpp(name);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_VisualizePointsOnScene_Private_Static_Void_Il2CppStructArray_1_Vector2_String_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public ProceduralLevelGeneration(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
