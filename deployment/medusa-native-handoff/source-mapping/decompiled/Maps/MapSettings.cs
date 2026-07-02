using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Game;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using UnityEngine;

namespace Il2CppBAPBAP.Maps;

[System.Serializable]
public class MapSettings : Il2CppSystem.Object
{
	[System.Serializable]
	public sealed class MapNamedModule : Il2CppSystem.ValueType
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_moduleName;

		private static readonly System.IntPtr NativeFieldInfoPtr_moduleCenterPos;

		private static readonly System.IntPtr NativeFieldInfoPtr_size;

		private static readonly System.IntPtr NativeFieldInfoPtr_colorId;

		private static readonly System.IntPtr NativeMethodInfoPtr_ToString_Public_Virtual_String_0;

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

		public unsafe Vector2 moduleCenterPos
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_moduleCenterPos);
				return *(Vector2*)num;
			}
			set
			{
				*(Vector2*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_moduleCenterPos)) = vector;
			}
		}

		public unsafe Vector2 size
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_size);
				return *(Vector2*)num;
			}
			set
			{
				*(Vector2*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_size)) = vector;
			}
		}

		public unsafe ushort colorId
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_colorId);
				return *(ushort*)num;
			}
			set
			{
				*(ushort*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_colorId)) = num;
			}
		}

		static MapNamedModule()
		{
			Il2CppClassPointerStore<MapNamedModule>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<MapSettings>.NativeClassPtr, "MapNamedModule");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<MapNamedModule>.NativeClassPtr);
			NativeFieldInfoPtr_moduleName = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MapNamedModule>.NativeClassPtr, "moduleName");
			NativeFieldInfoPtr_moduleCenterPos = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MapNamedModule>.NativeClassPtr, "moduleCenterPos");
			NativeFieldInfoPtr_size = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MapNamedModule>.NativeClassPtr, "size");
			NativeFieldInfoPtr_colorId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MapNamedModule>.NativeClassPtr, "colorId");
			NativeMethodInfoPtr_ToString_Public_Virtual_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapNamedModule>.NativeClassPtr, 100685897);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 243439, XrefRangeEnd = 243443, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe override string ToString()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ToString_Public_Virtual_String_0, IL2CPP.il2cpp_object_unbox(IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this)), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return IL2CPP.Il2CppStringToManaged(intPtr);
		}

		public MapNamedModule(System.IntPtr pointer)
			: base(pointer)
		{
		}

		public MapNamedModule()
			: base(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<MapNamedModule>.NativeClassPtr))
		{
		}
	}

	private static readonly System.IntPtr NativeFieldInfoPtr_AmbienceMapUnitSize;

	private static readonly System.IntPtr NativeFieldInfoPtr_size;

	private static readonly System.IntPtr NativeFieldInfoPtr_includeInBuild;

	private static readonly System.IntPtr NativeFieldInfoPtr_mapType;

	private static readonly System.IntPtr NativeFieldInfoPtr_displayName;

	private static readonly System.IntPtr NativeFieldInfoPtr_excludeNavMeshFloor;

	private static readonly System.IntPtr NativeFieldInfoPtr_exclueWaterPerimeter;

	private static readonly System.IntPtr NativeFieldInfoPtr_biomeMap;

	private static readonly System.IntPtr NativeFieldInfoPtr_ambienceMap;

	private static readonly System.IntPtr NativeFieldInfoPtr_splatMap;

	private static readonly System.IntPtr NativeFieldInfoPtr_serializedBiomeMap;

	private static readonly System.IntPtr NativeFieldInfoPtr_serializedAmbienceMap;

	private static readonly System.IntPtr NativeFieldInfoPtr_serializedSplatMap;

	private static readonly System.IntPtr NativeFieldInfoPtr_namedModules;

	private static readonly System.IntPtr NativeFieldInfoPtr_customZoneRounds;

	private static readonly System.IntPtr NativeFieldInfoPtr_zoneRounds;

	private static readonly System.IntPtr NativeFieldInfoPtr_colorId;

	private static readonly System.IntPtr NativeFieldInfoPtr_biomeId;

	private static readonly System.IntPtr NativeFieldInfoPtr_isSelected;

	private static readonly System.IntPtr NativeFieldInfoPtr_rotationAllowed;

	private static readonly System.IntPtr NativeFieldInfoPtr_biomeMapTex;

	private static readonly System.IntPtr NativeFieldInfoPtr_tempSplatMapTex;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_Vector2Int_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_MapSettings_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Serialize_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Deserialize_Public_Void_0;

	public unsafe static int AmbienceMapUnitSize
	{
		get
		{
			Unsafe.SkipInit(out int result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_AmbienceMapUnitSize, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_AmbienceMapUnitSize, (void*)(&num));
		}
	}

	public unsafe Vector2Int size
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_size);
			return *(Vector2Int*)num;
		}
		set
		{
			*(Vector2Int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_size)) = vector2Int;
		}
	}

	public unsafe bool includeInBuild
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_includeInBuild);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_includeInBuild)) = flag;
		}
	}

	public unsafe int mapType
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_mapType);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_mapType)) = num;
		}
	}

	public unsafe string displayName
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_displayName);
			return IL2CPP.Il2CppStringToManaged(*(System.IntPtr*)num);
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_displayName)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe bool excludeNavMeshFloor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_excludeNavMeshFloor);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_excludeNavMeshFloor)) = flag;
		}
	}

	public unsafe bool exclueWaterPerimeter
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_exclueWaterPerimeter);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_exclueWaterPerimeter)) = flag;
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

	public unsafe Il2CppObjectBase ambienceMap
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ambienceMap);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppObjectBase>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ambienceMap)), IL2CPP.Il2CppObjectBaseToPtr(val));
		}
	}

	public unsafe Il2CppObjectBase splatMap
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_splatMap);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppObjectBase>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_splatMap)), IL2CPP.Il2CppObjectBaseToPtr(val));
		}
	}

	public unsafe Il2CppStructArray<int> serializedBiomeMap
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_serializedBiomeMap);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<int>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_serializedBiomeMap)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppStructArray<byte> serializedAmbienceMap
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_serializedAmbienceMap);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<byte>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_serializedAmbienceMap)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppStructArray<byte> serializedSplatMap
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_serializedSplatMap);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<byte>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_serializedSplatMap)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppReferenceArray<MapNamedModule> namedModules
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_namedModules);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<MapNamedModule>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_namedModules)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe bool customZoneRounds
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_customZoneRounds);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_customZoneRounds)) = flag;
		}
	}

	public unsafe GameModeBattleRoyale.SerializedMapZones zoneRounds
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_zoneRounds);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<GameModeBattleRoyale.SerializedMapZones>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_zoneRounds)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)serializedMapZones));
		}
	}

	public unsafe ushort colorId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_colorId);
			return *(ushort*)num;
		}
		set
		{
			*(ushort*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_colorId)) = num;
		}
	}

	public unsafe ushort biomeId
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_biomeId);
			return *(ushort*)num;
		}
		set
		{
			*(ushort*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_biomeId)) = num;
		}
	}

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

	public unsafe bool rotationAllowed
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rotationAllowed);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rotationAllowed)) = flag;
		}
	}

	public unsafe Texture2D biomeMapTex
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_biomeMapTex);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Texture2D>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_biomeMapTex)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)texture2D));
		}
	}

	public unsafe Texture2D tempSplatMapTex
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tempSplatMapTex);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Texture2D>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tempSplatMapTex)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)texture2D));
		}
	}

	static MapSettings()
	{
		Il2CppClassPointerStore<MapSettings>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Maps", "MapSettings");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<MapSettings>.NativeClassPtr);
		NativeFieldInfoPtr_AmbienceMapUnitSize = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MapSettings>.NativeClassPtr, "AmbienceMapUnitSize");
		NativeFieldInfoPtr_size = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MapSettings>.NativeClassPtr, "size");
		NativeFieldInfoPtr_includeInBuild = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MapSettings>.NativeClassPtr, "includeInBuild");
		NativeFieldInfoPtr_mapType = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MapSettings>.NativeClassPtr, "mapType");
		NativeFieldInfoPtr_displayName = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MapSettings>.NativeClassPtr, "displayName");
		NativeFieldInfoPtr_excludeNavMeshFloor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MapSettings>.NativeClassPtr, "excludeNavMeshFloor");
		NativeFieldInfoPtr_exclueWaterPerimeter = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MapSettings>.NativeClassPtr, "exclueWaterPerimeter");
		NativeFieldInfoPtr_biomeMap = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MapSettings>.NativeClassPtr, "biomeMap");
		NativeFieldInfoPtr_ambienceMap = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MapSettings>.NativeClassPtr, "ambienceMap");
		NativeFieldInfoPtr_splatMap = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MapSettings>.NativeClassPtr, "splatMap");
		NativeFieldInfoPtr_serializedBiomeMap = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MapSettings>.NativeClassPtr, "serializedBiomeMap");
		NativeFieldInfoPtr_serializedAmbienceMap = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MapSettings>.NativeClassPtr, "serializedAmbienceMap");
		NativeFieldInfoPtr_serializedSplatMap = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MapSettings>.NativeClassPtr, "serializedSplatMap");
		NativeFieldInfoPtr_namedModules = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MapSettings>.NativeClassPtr, "namedModules");
		NativeFieldInfoPtr_customZoneRounds = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MapSettings>.NativeClassPtr, "customZoneRounds");
		NativeFieldInfoPtr_zoneRounds = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MapSettings>.NativeClassPtr, "zoneRounds");
		NativeFieldInfoPtr_colorId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MapSettings>.NativeClassPtr, "colorId");
		NativeFieldInfoPtr_biomeId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MapSettings>.NativeClassPtr, "biomeId");
		NativeFieldInfoPtr_isSelected = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MapSettings>.NativeClassPtr, "isSelected");
		NativeFieldInfoPtr_rotationAllowed = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MapSettings>.NativeClassPtr, "rotationAllowed");
		NativeFieldInfoPtr_biomeMapTex = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MapSettings>.NativeClassPtr, "biomeMapTex");
		NativeFieldInfoPtr_tempSplatMapTex = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MapSettings>.NativeClassPtr, "tempSplatMapTex");
		NativeMethodInfoPtr__ctor_Public_Void_Vector2Int_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapSettings>.NativeClassPtr, 100685893);
		NativeMethodInfoPtr__ctor_Public_Void_MapSettings_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapSettings>.NativeClassPtr, 100685894);
		NativeMethodInfoPtr_Serialize_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapSettings>.NativeClassPtr, 100685895);
		NativeMethodInfoPtr_Deserialize_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<MapSettings>.NativeClassPtr, 100685896);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 243458, RefRangeEnd = 243460, XrefRangeStart = 243443, XrefRangeEnd = 243458, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe MapSettings(Vector2Int size)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<MapSettings>.NativeClassPtr))
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&size);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_Vector2Int_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 243490, RefRangeEnd = 243493, XrefRangeStart = 243460, XrefRangeEnd = 243490, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe MapSettings(MapSettings source)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<MapSettings>.NativeClassPtr))
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)source);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_MapSettings_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 243493, XrefRangeEnd = 243502, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Serialize()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Serialize_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 243518, RefRangeEnd = 243520, XrefRangeStart = 243502, XrefRangeEnd = 243518, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Deserialize()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Deserialize_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public MapSettings(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
