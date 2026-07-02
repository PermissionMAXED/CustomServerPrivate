using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Il2CppInterop.Runtime;
using Il2CppSystem;

namespace Il2CppBAPBAP.Maps;

[StructLayout(LayoutKind.Explicit)]
public struct MapTile
{
	private static readonly System.IntPtr NativeFieldInfoPtr_rotPrefabId;

	[FieldOffset(0)]
	public int rotPrefabId;

	static MapTile()
	{
		Il2CppClassPointerStore<MapTile>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Maps", "MapTile");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<MapTile>.NativeClassPtr);
		NativeFieldInfoPtr_rotPrefabId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<MapTile>.NativeClassPtr, "rotPrefabId");
	}

	public unsafe Il2CppSystem.Object BoxIl2CppObject()
	{
		return new Il2CppSystem.Object(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<MapTile>.NativeClassPtr, (System.IntPtr)(nint)Unsafe.AsPointer(ref this)));
	}
}
