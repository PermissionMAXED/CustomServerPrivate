using System;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using UnityEngine;

namespace Il2CppBAPBAP.Maps;

[System.Serializable]
public sealed class MapChunkLevels : Il2CppSystem.ValueType
{
	private static readonly System.IntPtr NativeFieldInfoPtr_chunkSize;

	private static readonly System.IntPtr NativeFieldInfoPtr_halfChunkSize;

	private static readonly System.IntPtr NativeFieldInfoPtr_gridSize;

	private static readonly System.IntPtr NativeFieldInfoPtr_chunks;

	public unsafe int chunkSize
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_chunkSize);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_chunkSize)) = num;
		}
	}

	public unsafe int halfChunkSize
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_halfChunkSize);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_halfChunkSize)) = num;
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

	public unsafe Il2CppReferenceArray<Il2CppReferenceArray<MapChunk>> chunks
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_chunks);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<Il2CppReferenceArray<MapChunk>>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_chunks)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	static MapChunkLevels()
	{
		Il2CppClassPointerStore<MapChunkLevels>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Maps", "MapChunkLevels");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<MapChunkLevels>.NativeClassPtr);
		NativeFieldInfoPtr_chunkSize = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MapChunkLevels>.NativeClassPtr, "chunkSize");
		NativeFieldInfoPtr_halfChunkSize = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MapChunkLevels>.NativeClassPtr, "halfChunkSize");
		NativeFieldInfoPtr_gridSize = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MapChunkLevels>.NativeClassPtr, "gridSize");
		NativeFieldInfoPtr_chunks = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MapChunkLevels>.NativeClassPtr, "chunks");
	}

	public MapChunkLevels(System.IntPtr pointer)
		: base(pointer)
	{
	}

	public MapChunkLevels()
		: base(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<MapChunkLevels>.NativeClassPtr))
	{
	}
}
