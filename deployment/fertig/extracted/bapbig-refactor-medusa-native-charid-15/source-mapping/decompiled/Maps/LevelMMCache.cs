using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using UnityEngine;

namespace Il2CppBAPBAP.Maps;

[System.Serializable]
public class LevelMMCache : Il2CppSystem.Object
{
	private static readonly System.IntPtr NativeFieldInfoPtr_mapSettings;

	private static readonly System.IntPtr NativeFieldInfoPtr_spawnPoints;

	private static readonly System.IntPtr NativeFieldInfoPtr_dimensionSpawnPoints;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_MapSettings_Il2CppStructArray_1_Vector2_Il2CppStructArray_1_Vector2_0;

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

	public unsafe Il2CppStructArray<Vector2> spawnPoints
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spawnPoints);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<Vector2>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spawnPoints)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe Il2CppStructArray<Vector2> dimensionSpawnPoints
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dimensionSpawnPoints);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppStructArray<Vector2>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dimensionSpawnPoints)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	static LevelMMCache()
	{
		Il2CppClassPointerStore<LevelMMCache>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Maps", "LevelMMCache");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<LevelMMCache>.NativeClassPtr);
		NativeFieldInfoPtr_mapSettings = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelMMCache>.NativeClassPtr, "mapSettings");
		NativeFieldInfoPtr_spawnPoints = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelMMCache>.NativeClassPtr, "spawnPoints");
		NativeFieldInfoPtr_dimensionSpawnPoints = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LevelMMCache>.NativeClassPtr, "dimensionSpawnPoints");
		NativeMethodInfoPtr__ctor_Public_Void_MapSettings_Il2CppStructArray_1_Vector2_Il2CppStructArray_1_Vector2_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LevelMMCache>.NativeClassPtr, 100685456);
	}

	[CallerCount(365)]
	[CachedScanResults(RefRangeStart = 43192, RefRangeEnd = 43557, XrefRangeStart = 43192, XrefRangeEnd = 43557, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe LevelMMCache(MapSettings mapSettings, Il2CppStructArray<Vector2> spawnPoints, Il2CppStructArray<Vector2> dimensionSpawnPoints)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<LevelMMCache>.NativeClassPtr))
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)mapSettings);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)spawnPoints);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)dimensionSpawnPoints);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_MapSettings_Il2CppStructArray_1_Vector2_Il2CppStructArray_1_Vector2_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public LevelMMCache(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
