using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Local;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using UnityEngine;

namespace Il2CppBAPBAP.Maps;

public class BiomeData : ScriptableObject
{
	[System.Serializable]
	public class BiomeConfig : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_name;

		private static readonly System.IntPtr NativeFieldInfoPtr_groundSurfaceId;

		private static readonly System.IntPtr NativeFieldInfoPtr_bushSurfaceId;

		private static readonly System.IntPtr NativeFieldInfoPtr_ambienceId;

		private static readonly System.IntPtr NativeFieldInfoPtr_defaultGroundAsset;

		private static readonly System.IntPtr NativeFieldInfoPtr_pathGroundAsset;

		private static readonly System.IntPtr NativeFieldInfoPtr_obstacleAsset;

		private static readonly System.IntPtr NativeFieldInfoPtr_edgeObstacleAsset;

		private static readonly System.IntPtr NativeFieldInfoPtr_innerObstacleDecoAsset;

		private static readonly System.IntPtr NativeFieldInfoPtr_waterAutotileAsset;

		private static readonly System.IntPtr NativeFieldInfoPtr_biomeSettings;

		private static readonly System.IntPtr NativeFieldInfoPtr_colorMapValues;

		private static readonly System.IntPtr NativeFieldInfoPtr_bushColor;

		private static readonly System.IntPtr NativeFieldInfoPtr_minimapObstacleColor;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

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

		public unsafe SurfaceId groundSurfaceId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_groundSurfaceId);
				return *(SurfaceId*)num;
			}
			set
			{
				*(SurfaceId*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_groundSurfaceId)) = surfaceId;
			}
		}

		public unsafe SurfaceId bushSurfaceId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bushSurfaceId);
				return *(SurfaceId*)num;
			}
			set
			{
				*(SurfaceId*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bushSurfaceId)) = surfaceId;
			}
		}

		public unsafe AmbienceId ambienceId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ambienceId);
				return *(AmbienceId*)num;
			}
			set
			{
				*(AmbienceId*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ambienceId)) = ambienceId;
			}
		}

		public unsafe AssetPalette.AutotileAsset defaultGroundAsset
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defaultGroundAsset);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AssetPalette.AutotileAsset>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defaultGroundAsset)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)autotileAsset));
			}
		}

		public unsafe AssetPalette.AutotileAsset pathGroundAsset
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pathGroundAsset);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AssetPalette.AutotileAsset>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pathGroundAsset)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)autotileAsset));
			}
		}

		public unsafe AssetPalette.AutotileAsset obstacleAsset
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_obstacleAsset);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AssetPalette.AutotileAsset>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_obstacleAsset)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)autotileAsset));
			}
		}

		public unsafe AssetPalette.VariationAsset edgeObstacleAsset
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_edgeObstacleAsset);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AssetPalette.VariationAsset>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_edgeObstacleAsset)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)variationAsset));
			}
		}

		public unsafe AssetPalette.VariationAsset innerObstacleDecoAsset
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_innerObstacleDecoAsset);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AssetPalette.VariationAsset>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_innerObstacleDecoAsset)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)variationAsset));
			}
		}

		public unsafe AssetPalette.AutotileAsset waterAutotileAsset
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_waterAutotileAsset);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AssetPalette.AutotileAsset>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_waterAutotileAsset)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)autotileAsset));
			}
		}

		public unsafe ProceduralLevelGeneration.BiomeSettings biomeSettings
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_biomeSettings);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ProceduralLevelGeneration.BiomeSettings>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_biomeSettings)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)biomeSettings));
			}
		}

		public unsafe ColorMapValues colorMapValues
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_colorMapValues);
				return new ColorMapValues(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<ColorMapValues>.NativeClassPtr, (System.IntPtr)num));
			}
			set
			{
				// IL cpblk instruction
				Unsafe.CopyBlock((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_colorMapValues), IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)colorMapValues)), IL2CPP.il2cpp_class_value_size(Il2CppClassPointerStore<ColorMapValues>.NativeClassPtr, ref *(uint*)null));
			}
		}

		public unsafe Color bushColor
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bushColor);
				return *(Color*)num;
			}
			set
			{
				*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bushColor)) = color;
			}
		}

		public unsafe Color minimapObstacleColor
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minimapObstacleColor);
				return *(Color*)num;
			}
			set
			{
				*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minimapObstacleColor)) = color;
			}
		}

		static BiomeConfig()
		{
			Il2CppClassPointerStore<BiomeConfig>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<BiomeData>.NativeClassPtr, "BiomeConfig");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<BiomeConfig>.NativeClassPtr);
			NativeFieldInfoPtr_name = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BiomeConfig>.NativeClassPtr, "name");
			NativeFieldInfoPtr_groundSurfaceId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BiomeConfig>.NativeClassPtr, "groundSurfaceId");
			NativeFieldInfoPtr_bushSurfaceId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BiomeConfig>.NativeClassPtr, "bushSurfaceId");
			NativeFieldInfoPtr_ambienceId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BiomeConfig>.NativeClassPtr, "ambienceId");
			NativeFieldInfoPtr_defaultGroundAsset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BiomeConfig>.NativeClassPtr, "defaultGroundAsset");
			NativeFieldInfoPtr_pathGroundAsset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BiomeConfig>.NativeClassPtr, "pathGroundAsset");
			NativeFieldInfoPtr_obstacleAsset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BiomeConfig>.NativeClassPtr, "obstacleAsset");
			NativeFieldInfoPtr_edgeObstacleAsset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BiomeConfig>.NativeClassPtr, "edgeObstacleAsset");
			NativeFieldInfoPtr_innerObstacleDecoAsset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BiomeConfig>.NativeClassPtr, "innerObstacleDecoAsset");
			NativeFieldInfoPtr_waterAutotileAsset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BiomeConfig>.NativeClassPtr, "waterAutotileAsset");
			NativeFieldInfoPtr_biomeSettings = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BiomeConfig>.NativeClassPtr, "biomeSettings");
			NativeFieldInfoPtr_colorMapValues = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BiomeConfig>.NativeClassPtr, "colorMapValues");
			NativeFieldInfoPtr_bushColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BiomeConfig>.NativeClassPtr, "bushColor");
			NativeFieldInfoPtr_minimapObstacleColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BiomeConfig>.NativeClassPtr, "minimapObstacleColor");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BiomeConfig>.NativeClassPtr, 100685446);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 236739, XrefRangeEnd = 236740, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe BiomeConfig()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<BiomeConfig>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public BiomeConfig(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public class ProcgenAssets : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_defaultWaterAutotileAsset;

		private static readonly System.IntPtr NativeFieldInfoPtr_procgenFloorTransitionTile;

		private static readonly System.IntPtr NativeFieldInfoPtr_playerSpawnProxyPrefab;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe AssetPalette.AutotileAsset defaultWaterAutotileAsset
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defaultWaterAutotileAsset);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AssetPalette.AutotileAsset>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defaultWaterAutotileAsset)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)autotileAsset));
			}
		}

		public unsafe GameObject procgenFloorTransitionTile
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_procgenFloorTransitionTile);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_procgenFloorTransitionTile)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
			}
		}

		public unsafe GameObject playerSpawnProxyPrefab
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerSpawnProxyPrefab);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_playerSpawnProxyPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
			}
		}

		static ProcgenAssets()
		{
			Il2CppClassPointerStore<ProcgenAssets>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<BiomeData>.NativeClassPtr, "ProcgenAssets");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<ProcgenAssets>.NativeClassPtr);
			NativeFieldInfoPtr_defaultWaterAutotileAsset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ProcgenAssets>.NativeClassPtr, "defaultWaterAutotileAsset");
			NativeFieldInfoPtr_procgenFloorTransitionTile = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ProcgenAssets>.NativeClassPtr, "procgenFloorTransitionTile");
			NativeFieldInfoPtr_playerSpawnProxyPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ProcgenAssets>.NativeClassPtr, "playerSpawnProxyPrefab");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProcgenAssets>.NativeClassPtr, 100685447);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe ProcgenAssets()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<ProcgenAssets>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public ProcgenAssets(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public class ProcgenConfig : Il2CppSystem.Object
	{
		[System.Serializable]
		public class IslandGenSettings : Il2CppSystem.Object
		{
			private static readonly System.IntPtr NativeFieldInfoPtr_cellularAutomataIterations;

			private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

			public unsafe int cellularAutomataIterations
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_cellularAutomataIterations);
					return *(int*)num;
				}
				set
				{
					*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_cellularAutomataIterations)) = num;
				}
			}

			static IslandGenSettings()
			{
				Il2CppClassPointerStore<IslandGenSettings>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<ProcgenConfig>.NativeClassPtr, "IslandGenSettings");
				IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<IslandGenSettings>.NativeClassPtr);
				NativeFieldInfoPtr_cellularAutomataIterations = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<IslandGenSettings>.NativeClassPtr, "cellularAutomataIterations");
				NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<IslandGenSettings>.NativeClassPtr, 100685449);
			}

			[CallerCount(0)]
			[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 236740, XrefRangeEnd = 236741, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
			public unsafe IslandGenSettings()
				: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<IslandGenSettings>.NativeClassPtr))
			{
				System.IntPtr* ptr = null;
				Unsafe.SkipInit(out System.IntPtr intPtr2);
				System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
				Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			}

			public IslandGenSettings(System.IntPtr pointer)
				: base(pointer)
			{
			}
		}

		[System.Serializable]
		public class BiomeGenSettings : Il2CppSystem.Object
		{
			private static readonly System.IntPtr NativeFieldInfoPtr_flowMapAmplitude;

			private static readonly System.IntPtr NativeFieldInfoPtr_flowMapFrequency;

			private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

			public unsafe float flowMapAmplitude
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_flowMapAmplitude);
					return *(float*)num;
				}
				set
				{
					*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_flowMapAmplitude)) = num;
				}
			}

			public unsafe float flowMapFrequency
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_flowMapFrequency);
					return *(float*)num;
				}
				set
				{
					*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_flowMapFrequency)) = num;
				}
			}

			static BiomeGenSettings()
			{
				Il2CppClassPointerStore<BiomeGenSettings>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<ProcgenConfig>.NativeClassPtr, "BiomeGenSettings");
				IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<BiomeGenSettings>.NativeClassPtr);
				NativeFieldInfoPtr_flowMapAmplitude = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BiomeGenSettings>.NativeClassPtr, "flowMapAmplitude");
				NativeFieldInfoPtr_flowMapFrequency = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BiomeGenSettings>.NativeClassPtr, "flowMapFrequency");
				NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BiomeGenSettings>.NativeClassPtr, 100685450);
			}

			[CallerCount(5410)]
			[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
			public unsafe BiomeGenSettings()
				: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<BiomeGenSettings>.NativeClassPtr))
			{
				System.IntPtr* ptr = null;
				Unsafe.SkipInit(out System.IntPtr intPtr2);
				System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
				Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			}

			public BiomeGenSettings(System.IntPtr pointer)
				: base(pointer)
			{
			}
		}

		[System.Serializable]
		public class PathGenSettings : Il2CppSystem.Object
		{
			private static readonly System.IntPtr NativeFieldInfoPtr_flowMapTex;

			private static readonly System.IntPtr NativeFieldInfoPtr_flowMapAmplitude;

			private static readonly System.IntPtr NativeFieldInfoPtr_flowMapFrequency;

			private static readonly System.IntPtr NativeFieldInfoPtr_colliderThickness;

			private static readonly System.IntPtr NativeFieldInfoPtr_meshThickness;

			private static readonly System.IntPtr NativeFieldInfoPtr_drawMinDistance;

			private static readonly System.IntPtr NativeFieldInfoPtr_carveDrawMinDistance;

			private static readonly System.IntPtr NativeFieldInfoPtr_randomPathsAddPercentage;

			private static readonly System.IntPtr NativeFieldInfoPtr_cellularAutomataIterations;

			private static readonly System.IntPtr NativeFieldInfoPtr_carveBiomePadding;

			private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

			public unsafe Texture2D flowMapTex
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_flowMapTex);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Texture2D>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_flowMapTex)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)texture2D));
				}
			}

			public unsafe float flowMapAmplitude
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_flowMapAmplitude);
					return *(float*)num;
				}
				set
				{
					*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_flowMapAmplitude)) = num;
				}
			}

			public unsafe float flowMapFrequency
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_flowMapFrequency);
					return *(float*)num;
				}
				set
				{
					*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_flowMapFrequency)) = num;
				}
			}

			public unsafe int colliderThickness
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_colliderThickness);
					return *(int*)num;
				}
				set
				{
					*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_colliderThickness)) = num;
				}
			}

			public unsafe int meshThickness
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_meshThickness);
					return *(int*)num;
				}
				set
				{
					*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_meshThickness)) = num;
				}
			}

			public unsafe float drawMinDistance
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_drawMinDistance);
					return *(float*)num;
				}
				set
				{
					*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_drawMinDistance)) = num;
				}
			}

			public unsafe float carveDrawMinDistance
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_carveDrawMinDistance);
					return *(float*)num;
				}
				set
				{
					*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_carveDrawMinDistance)) = num;
				}
			}

			public unsafe float randomPathsAddPercentage
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_randomPathsAddPercentage);
					return *(float*)num;
				}
				set
				{
					*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_randomPathsAddPercentage)) = num;
				}
			}

			public unsafe int cellularAutomataIterations
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_cellularAutomataIterations);
					return *(int*)num;
				}
				set
				{
					*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_cellularAutomataIterations)) = num;
				}
			}

			public unsafe int carveBiomePadding
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_carveBiomePadding);
					return *(int*)num;
				}
				set
				{
					*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_carveBiomePadding)) = num;
				}
			}

			static PathGenSettings()
			{
				Il2CppClassPointerStore<PathGenSettings>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<ProcgenConfig>.NativeClassPtr, "PathGenSettings");
				IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<PathGenSettings>.NativeClassPtr);
				NativeFieldInfoPtr_flowMapTex = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PathGenSettings>.NativeClassPtr, "flowMapTex");
				NativeFieldInfoPtr_flowMapAmplitude = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PathGenSettings>.NativeClassPtr, "flowMapAmplitude");
				NativeFieldInfoPtr_flowMapFrequency = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PathGenSettings>.NativeClassPtr, "flowMapFrequency");
				NativeFieldInfoPtr_colliderThickness = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PathGenSettings>.NativeClassPtr, "colliderThickness");
				NativeFieldInfoPtr_meshThickness = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PathGenSettings>.NativeClassPtr, "meshThickness");
				NativeFieldInfoPtr_drawMinDistance = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PathGenSettings>.NativeClassPtr, "drawMinDistance");
				NativeFieldInfoPtr_carveDrawMinDistance = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PathGenSettings>.NativeClassPtr, "carveDrawMinDistance");
				NativeFieldInfoPtr_randomPathsAddPercentage = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PathGenSettings>.NativeClassPtr, "randomPathsAddPercentage");
				NativeFieldInfoPtr_cellularAutomataIterations = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PathGenSettings>.NativeClassPtr, "cellularAutomataIterations");
				NativeFieldInfoPtr_carveBiomePadding = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PathGenSettings>.NativeClassPtr, "carveBiomePadding");
				NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PathGenSettings>.NativeClassPtr, 100685451);
			}

			[CallerCount(0)]
			[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 236741, XrefRangeEnd = 236742, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
			public unsafe PathGenSettings()
				: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<PathGenSettings>.NativeClassPtr))
			{
				System.IntPtr* ptr = null;
				Unsafe.SkipInit(out System.IntPtr intPtr2);
				System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
				Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			}

			public PathGenSettings(System.IntPtr pointer)
				: base(pointer)
			{
			}
		}

		[System.Serializable]
		public class ObstacleGenSettings : Il2CppSystem.Object
		{
			private static readonly System.IntPtr NativeFieldInfoPtr_flowMapTex;

			private static readonly System.IntPtr NativeFieldInfoPtr_flowMapAmplitude;

			private static readonly System.IntPtr NativeFieldInfoPtr_flowMapFrequency;

			private static readonly System.IntPtr NativeFieldInfoPtr_modulePadding;

			private static readonly System.IntPtr NativeFieldInfoPtr_cellularAutomataIterations;

			private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

			public unsafe Texture2D flowMapTex
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_flowMapTex);
					System.IntPtr intPtr = *(System.IntPtr*)num;
					return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Texture2D>(intPtr) : null;
				}
				set
				{
					System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
					IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_flowMapTex)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)texture2D));
				}
			}

			public unsafe float flowMapAmplitude
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_flowMapAmplitude);
					return *(float*)num;
				}
				set
				{
					*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_flowMapAmplitude)) = num;
				}
			}

			public unsafe float flowMapFrequency
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_flowMapFrequency);
					return *(float*)num;
				}
				set
				{
					*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_flowMapFrequency)) = num;
				}
			}

			public unsafe int modulePadding
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_modulePadding);
					return *(int*)num;
				}
				set
				{
					*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_modulePadding)) = num;
				}
			}

			public unsafe int cellularAutomataIterations
			{
				get
				{
					nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_cellularAutomataIterations);
					return *(int*)num;
				}
				set
				{
					*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_cellularAutomataIterations)) = num;
				}
			}

			static ObstacleGenSettings()
			{
				Il2CppClassPointerStore<ObstacleGenSettings>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<ProcgenConfig>.NativeClassPtr, "ObstacleGenSettings");
				IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<ObstacleGenSettings>.NativeClassPtr);
				NativeFieldInfoPtr_flowMapTex = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ObstacleGenSettings>.NativeClassPtr, "flowMapTex");
				NativeFieldInfoPtr_flowMapAmplitude = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ObstacleGenSettings>.NativeClassPtr, "flowMapAmplitude");
				NativeFieldInfoPtr_flowMapFrequency = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ObstacleGenSettings>.NativeClassPtr, "flowMapFrequency");
				NativeFieldInfoPtr_modulePadding = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ObstacleGenSettings>.NativeClassPtr, "modulePadding");
				NativeFieldInfoPtr_cellularAutomataIterations = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ObstacleGenSettings>.NativeClassPtr, "cellularAutomataIterations");
				NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ObstacleGenSettings>.NativeClassPtr, 100685452);
			}

			[CallerCount(0)]
			[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 236742, XrefRangeEnd = 236743, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
			public unsafe ObstacleGenSettings()
				: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<ObstacleGenSettings>.NativeClassPtr))
			{
				System.IntPtr* ptr = null;
				Unsafe.SkipInit(out System.IntPtr intPtr2);
				System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
				Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			}

			public ObstacleGenSettings(System.IntPtr pointer)
				: base(pointer)
			{
			}
		}

		private static readonly System.IntPtr NativeFieldInfoPtr_islandGenSettings;

		private static readonly System.IntPtr NativeFieldInfoPtr_biomeGenSettings;

		private static readonly System.IntPtr NativeFieldInfoPtr_pathGenSettings;

		private static readonly System.IntPtr NativeFieldInfoPtr_obstacleGenSettings;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		public unsafe IslandGenSettings islandGenSettings
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_islandGenSettings);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<IslandGenSettings>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_islandGenSettings)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)islandGenSettings));
			}
		}

		public unsafe BiomeGenSettings biomeGenSettings
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_biomeGenSettings);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<BiomeGenSettings>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_biomeGenSettings)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)biomeGenSettings));
			}
		}

		public unsafe PathGenSettings pathGenSettings
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pathGenSettings);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<PathGenSettings>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pathGenSettings)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)pathGenSettings));
			}
		}

		public unsafe ObstacleGenSettings obstacleGenSettings
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_obstacleGenSettings);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ObstacleGenSettings>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_obstacleGenSettings)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)obstacleGenSettings));
			}
		}

		static ProcgenConfig()
		{
			Il2CppClassPointerStore<ProcgenConfig>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<BiomeData>.NativeClassPtr, "ProcgenConfig");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<ProcgenConfig>.NativeClassPtr);
			NativeFieldInfoPtr_islandGenSettings = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ProcgenConfig>.NativeClassPtr, "islandGenSettings");
			NativeFieldInfoPtr_biomeGenSettings = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ProcgenConfig>.NativeClassPtr, "biomeGenSettings");
			NativeFieldInfoPtr_pathGenSettings = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ProcgenConfig>.NativeClassPtr, "pathGenSettings");
			NativeFieldInfoPtr_obstacleGenSettings = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ProcgenConfig>.NativeClassPtr, "obstacleGenSettings");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<ProcgenConfig>.NativeClassPtr, 100685448);
		}

		[CallerCount(5410)]
		[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe ProcgenConfig()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<ProcgenConfig>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public ProcgenConfig(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[System.Serializable]
	public sealed class ColorMapValues : Il2CppSystem.ValueType
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_groundColor;

		private static readonly System.IntPtr NativeFieldInfoPtr_groundTexture;

		private static readonly System.IntPtr NativeFieldInfoPtr_groundTextureSplatR;

		private static readonly System.IntPtr NativeFieldInfoPtr_groundPaintRSurfaceId;

		private static readonly System.IntPtr NativeFieldInfoPtr_groundPaintRSurfaceThreshold;

		private static readonly System.IntPtr NativeFieldInfoPtr_groundTexAlpha;

		private static readonly System.IntPtr NativeFieldInfoPtr_groundTextureScale;

		private static readonly System.IntPtr NativeFieldInfoPtr_splatTextureScale;

		private static readonly System.IntPtr NativeFieldInfoPtr_heightBlendFactor;

		private static readonly System.IntPtr NativeFieldInfoPtr_heightBlendFalloff;

		private static readonly System.IntPtr NativeFieldInfoPtr_heightEdgeFalloff;

		public unsafe Color groundColor
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_groundColor);
				return *(Color*)num;
			}
			set
			{
				*(Color*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_groundColor)) = color;
			}
		}

		public unsafe Texture2D groundTexture
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_groundTexture);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Texture2D>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_groundTexture)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)texture2D));
			}
		}

		public unsafe Texture2D groundTextureSplatR
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_groundTextureSplatR);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Texture2D>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_groundTextureSplatR)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)texture2D));
			}
		}

		public unsafe SurfaceId groundPaintRSurfaceId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_groundPaintRSurfaceId);
				return *(SurfaceId*)num;
			}
			set
			{
				*(SurfaceId*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_groundPaintRSurfaceId)) = surfaceId;
			}
		}

		public unsafe float groundPaintRSurfaceThreshold
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_groundPaintRSurfaceThreshold);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_groundPaintRSurfaceThreshold)) = num;
			}
		}

		public unsafe float groundTexAlpha
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_groundTexAlpha);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_groundTexAlpha)) = num;
			}
		}

		public unsafe float groundTextureScale
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_groundTextureScale);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_groundTextureScale)) = num;
			}
		}

		public unsafe float splatTextureScale
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_splatTextureScale);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_splatTextureScale)) = num;
			}
		}

		public unsafe float heightBlendFactor
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_heightBlendFactor);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_heightBlendFactor)) = num;
			}
		}

		public unsafe float heightBlendFalloff
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_heightBlendFalloff);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_heightBlendFalloff)) = num;
			}
		}

		public unsafe float heightEdgeFalloff
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_heightEdgeFalloff);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_heightEdgeFalloff)) = num;
			}
		}

		static ColorMapValues()
		{
			Il2CppClassPointerStore<ColorMapValues>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<BiomeData>.NativeClassPtr, "ColorMapValues");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<ColorMapValues>.NativeClassPtr);
			NativeFieldInfoPtr_groundColor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ColorMapValues>.NativeClassPtr, "groundColor");
			NativeFieldInfoPtr_groundTexture = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ColorMapValues>.NativeClassPtr, "groundTexture");
			NativeFieldInfoPtr_groundTextureSplatR = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ColorMapValues>.NativeClassPtr, "groundTextureSplatR");
			NativeFieldInfoPtr_groundPaintRSurfaceId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ColorMapValues>.NativeClassPtr, "groundPaintRSurfaceId");
			NativeFieldInfoPtr_groundPaintRSurfaceThreshold = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ColorMapValues>.NativeClassPtr, "groundPaintRSurfaceThreshold");
			NativeFieldInfoPtr_groundTexAlpha = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ColorMapValues>.NativeClassPtr, "groundTexAlpha");
			NativeFieldInfoPtr_groundTextureScale = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ColorMapValues>.NativeClassPtr, "groundTextureScale");
			NativeFieldInfoPtr_splatTextureScale = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ColorMapValues>.NativeClassPtr, "splatTextureScale");
			NativeFieldInfoPtr_heightBlendFactor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ColorMapValues>.NativeClassPtr, "heightBlendFactor");
			NativeFieldInfoPtr_heightBlendFalloff = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ColorMapValues>.NativeClassPtr, "heightBlendFalloff");
			NativeFieldInfoPtr_heightEdgeFalloff = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<ColorMapValues>.NativeClassPtr, "heightEdgeFalloff");
		}

		public ColorMapValues(System.IntPtr pointer)
			: base(pointer)
		{
		}

		public ColorMapValues()
			: base(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<ColorMapValues>.NativeClassPtr))
		{
		}
	}

	private static readonly System.IntPtr NativeFieldInfoPtr_biomesConfig;

	private static readonly System.IntPtr NativeFieldInfoPtr_procgenAssets;

	private static readonly System.IntPtr NativeFieldInfoPtr_procgenConfig;

	private static readonly System.IntPtr NativeFieldInfoPtr_namedModuleColors;

	private static readonly System.IntPtr NativeFieldInfoPtr_miscColorMapValues;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetBiomeColor_Public_Color_Int32_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetBiomeId_Public_Int32_Color_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ColorDistance_Private_Single_Color_Color_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe Il2CppReferenceArray<BiomeConfig> biomesConfig
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_biomesConfig);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<BiomeConfig>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_biomesConfig)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe ProcgenAssets procgenAssets
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_procgenAssets);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ProcgenAssets>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_procgenAssets)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)procgenAssets));
		}
	}

	public unsafe ProcgenConfig procgenConfig
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_procgenConfig);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ProcgenConfig>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_procgenConfig)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)procgenConfig));
		}
	}

	public unsafe Il2CppStructArray<Color> namedModuleColors
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_namedModuleColors);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<Color>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_namedModuleColors)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppReferenceArray<ColorMapValues> miscColorMapValues
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_miscColorMapValues);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<ColorMapValues>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_miscColorMapValues)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	static BiomeData()
	{
		Il2CppClassPointerStore<BiomeData>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Maps", "BiomeData");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<BiomeData>.NativeClassPtr);
		NativeFieldInfoPtr_biomesConfig = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BiomeData>.NativeClassPtr, "biomesConfig");
		NativeFieldInfoPtr_procgenAssets = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BiomeData>.NativeClassPtr, "procgenAssets");
		NativeFieldInfoPtr_procgenConfig = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BiomeData>.NativeClassPtr, "procgenConfig");
		NativeFieldInfoPtr_namedModuleColors = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BiomeData>.NativeClassPtr, "namedModuleColors");
		NativeFieldInfoPtr_miscColorMapValues = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BiomeData>.NativeClassPtr, "miscColorMapValues");
		NativeMethodInfoPtr_GetBiomeColor_Public_Color_Int32_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BiomeData>.NativeClassPtr, 100685442);
		NativeMethodInfoPtr_GetBiomeId_Public_Int32_Color_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BiomeData>.NativeClassPtr, 100685443);
		NativeMethodInfoPtr_ColorDistance_Private_Single_Color_Color_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BiomeData>.NativeClassPtr, 100685444);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BiomeData>.NativeClassPtr, 100685445);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 236745, RefRangeEnd = 236747, XrefRangeStart = 236743, XrefRangeEnd = 236745, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Color GetBiomeColor(int biomeId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&biomeId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetBiomeColor_Public_Color_Int32_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(Color*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 236753, RefRangeEnd = 236754, XrefRangeStart = 236747, XrefRangeEnd = 236753, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe int GetBiomeId(Color color)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&color);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetBiomeId_Public_Int32_Color_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(int*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 236754, XrefRangeEnd = 236757, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe float ColorDistance(Color c1, Color c2)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = (nint)(&c1);
		*(Color**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &c2;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ColorDistance_Private_Single_Color_Color_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(float*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(183)]
	[CachedScanResults(RefRangeStart = 39484, RefRangeEnd = 39667, XrefRangeStart = 39484, XrefRangeEnd = 39667, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe BiomeData()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<BiomeData>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public BiomeData(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
