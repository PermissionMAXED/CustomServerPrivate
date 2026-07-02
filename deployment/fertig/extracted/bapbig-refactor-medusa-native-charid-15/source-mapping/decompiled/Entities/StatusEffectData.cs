using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Il2CppInterop.Runtime;
using Il2CppSystem;
using UnityEngine;

namespace Il2CppBAPBAP.Entities;

[StructLayout(LayoutKind.Explicit)]
public struct StatusEffectData
{
	private static readonly System.IntPtr NativeFieldInfoPtr_statusEffectId;

	private static readonly System.IntPtr NativeFieldInfoPtr_timeRemaining;

	private static readonly System.IntPtr NativeFieldInfoPtr_totalTime;

	private static readonly System.IntPtr NativeFieldInfoPtr_stacks;

	private static readonly System.IntPtr NativeFieldInfoPtr_color;

	private static readonly System.IntPtr NativeFieldInfoPtr_hideTime;

	private static readonly System.IntPtr NativeFieldInfoPtr_priority;

	[FieldOffset(0)]
	public int statusEffectId;

	[FieldOffset(4)]
	public float timeRemaining;

	[FieldOffset(8)]
	public float totalTime;

	[FieldOffset(12)]
	public int stacks;

	[FieldOffset(16)]
	public Color color;

	[FieldOffset(32)]
	[MarshalAs(UnmanagedType.U1)]
	public bool hideTime;

	[FieldOffset(36)]
	public int priority;

	static StatusEffectData()
	{
		Il2CppClassPointerStore<StatusEffectData>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Entities", "StatusEffectData");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<StatusEffectData>.NativeClassPtr);
		NativeFieldInfoPtr_statusEffectId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<StatusEffectData>.NativeClassPtr, "statusEffectId");
		NativeFieldInfoPtr_timeRemaining = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<StatusEffectData>.NativeClassPtr, "timeRemaining");
		NativeFieldInfoPtr_totalTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<StatusEffectData>.NativeClassPtr, "totalTime");
		NativeFieldInfoPtr_stacks = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<StatusEffectData>.NativeClassPtr, "stacks");
		NativeFieldInfoPtr_color = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<StatusEffectData>.NativeClassPtr, "color");
		NativeFieldInfoPtr_hideTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<StatusEffectData>.NativeClassPtr, "hideTime");
		NativeFieldInfoPtr_priority = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<StatusEffectData>.NativeClassPtr, "priority");
	}

	public unsafe Il2CppSystem.Object BoxIl2CppObject()
	{
		return new Il2CppSystem.Object(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<StatusEffectData>.NativeClassPtr, (System.IntPtr)(nint)Unsafe.AsPointer(ref this)));
	}
}
