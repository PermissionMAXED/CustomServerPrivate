using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Il2CppInterop.Runtime;
using Il2CppSystem;

namespace Il2CppBAPBAP.Entities;

[System.Serializable]
[StructLayout(LayoutKind.Explicit)]
public struct PushedPreset
{
	private static readonly System.IntPtr NativeFieldInfoPtr_impulseForce;

	private static readonly System.IntPtr NativeFieldInfoPtr_decel;

	private static readonly System.IntPtr NativeFieldInfoPtr_duration;

	[FieldOffset(0)]
	public float impulseForce;

	[FieldOffset(4)]
	public float decel;

	[FieldOffset(8)]
	public float duration;

	static PushedPreset()
	{
		Il2CppClassPointerStore<PushedPreset>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Entities", "PushedPreset");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<PushedPreset>.NativeClassPtr);
		NativeFieldInfoPtr_impulseForce = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PushedPreset>.NativeClassPtr, "impulseForce");
		NativeFieldInfoPtr_decel = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PushedPreset>.NativeClassPtr, "decel");
		NativeFieldInfoPtr_duration = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PushedPreset>.NativeClassPtr, "duration");
	}

	public unsafe Il2CppSystem.Object BoxIl2CppObject()
	{
		return new Il2CppSystem.Object(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<PushedPreset>.NativeClassPtr, (System.IntPtr)(nint)Unsafe.AsPointer(ref this)));
	}
}
