using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Il2CppInterop.Runtime;
using Il2CppSystem;
using UnityEngine;

namespace Il2CppBAPBAP.Maps;

[StructLayout(LayoutKind.Explicit)]
public struct TiledColliderInstance
{
	private static readonly System.IntPtr NativeFieldInfoPtr_layer;

	private static readonly System.IntPtr NativeFieldInfoPtr_worldPos;

	[FieldOffset(0)]
	public int layer;

	[FieldOffset(4)]
	public Vector2 worldPos;

	static TiledColliderInstance()
	{
		Il2CppClassPointerStore<TiledColliderInstance>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Maps", "TiledColliderInstance");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<TiledColliderInstance>.NativeClassPtr);
		NativeFieldInfoPtr_layer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TiledColliderInstance>.NativeClassPtr, "layer");
		NativeFieldInfoPtr_worldPos = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TiledColliderInstance>.NativeClassPtr, "worldPos");
	}

	public unsafe Il2CppSystem.Object BoxIl2CppObject()
	{
		return new Il2CppSystem.Object(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<TiledColliderInstance>.NativeClassPtr, (System.IntPtr)(nint)Unsafe.AsPointer(ref this)));
	}
}
