using System;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using UnityEngine;

namespace Il2CppBAPBAP.Maps;

public sealed class HideAreaGroup : Il2CppSystem.ValueType
{
	private static readonly System.IntPtr NativeFieldInfoPtr_tilePrefabs;

	private static readonly System.IntPtr NativeFieldInfoPtr_objHolder;

	private static readonly System.IntPtr NativeFieldInfoPtr_worldPos;

	private static readonly System.IntPtr NativeFieldInfoPtr_bounds;

	public unsafe Il2CppReferenceArray<TilePrefabInstance> tilePrefabs
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tilePrefabs);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<TilePrefabInstance>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tilePrefabs)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe LevelHideAreaHolder objHolder
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_objHolder);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<LevelHideAreaHolder>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_objHolder)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)levelHideAreaHolder));
		}
	}

	public unsafe Vector2 worldPos
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_worldPos);
			return *(Vector2*)num;
		}
		set
		{
			*(Vector2*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_worldPos)) = vector;
		}
	}

	public unsafe Bounds bounds
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bounds);
			return *(Bounds*)num;
		}
		set
		{
			*(Bounds*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bounds)) = bounds;
		}
	}

	static HideAreaGroup()
	{
		Il2CppClassPointerStore<HideAreaGroup>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Maps", "HideAreaGroup");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<HideAreaGroup>.NativeClassPtr);
		NativeFieldInfoPtr_tilePrefabs = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HideAreaGroup>.NativeClassPtr, "tilePrefabs");
		NativeFieldInfoPtr_objHolder = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HideAreaGroup>.NativeClassPtr, "objHolder");
		NativeFieldInfoPtr_worldPos = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HideAreaGroup>.NativeClassPtr, "worldPos");
		NativeFieldInfoPtr_bounds = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<HideAreaGroup>.NativeClassPtr, "bounds");
	}

	public HideAreaGroup(System.IntPtr pointer)
		: base(pointer)
	{
	}

	public HideAreaGroup()
		: base(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<HideAreaGroup>.NativeClassPtr))
	{
	}
}
