using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Il2CppBAPBAP.Local;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppSystem;
using UnityEngine;

namespace Il2CppBAPBAP.Network.EventData;

[StructLayout(LayoutKind.Explicit)]
public struct SfxEventData
{
	private static readonly System.IntPtr NativeFieldInfoPtr_predTickNum;

	private static readonly System.IntPtr NativeFieldInfoPtr_sfxId;

	private static readonly System.IntPtr NativeFieldInfoPtr_action;

	private static readonly System.IntPtr NativeFieldInfoPtr_target;

	private static readonly System.IntPtr NativeFieldInfoPtr_position;

	private static readonly System.IntPtr NativeFieldInfoPtr_pitchSpread;

	private static readonly System.IntPtr NativeFieldInfoPtr_volume;

	private static readonly System.IntPtr NativeFieldInfoPtr_doLoop;

	private static readonly System.IntPtr NativeFieldInfoPtr_sourceSizeMultiplier;

	private static readonly System.IntPtr NativeFieldInfoPtr_instanceId;

	private static readonly System.IntPtr NativeMethodInfoPtr_ToString_Public_Virtual_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Equals_Public_Virtual_Final_New_Boolean_SfxEventData_0;

	[FieldOffset(0)]
	public int predTickNum;

	[FieldOffset(4)]
	public int sfxId;

	[FieldOffset(8)]
	public SfxEventAction action;

	[FieldOffset(9)]
	public SfxTarget target;

	[FieldOffset(12)]
	public Vector3 position;

	[FieldOffset(24)]
	public float pitchSpread;

	[FieldOffset(28)]
	public float volume;

	[FieldOffset(32)]
	public byte doLoop;

	[FieldOffset(36)]
	public float sourceSizeMultiplier;

	[FieldOffset(40)]
	public int instanceId;

	static SfxEventData()
	{
		Il2CppClassPointerStore<SfxEventData>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Network.EventData", "SfxEventData");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<SfxEventData>.NativeClassPtr);
		NativeFieldInfoPtr_predTickNum = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SfxEventData>.NativeClassPtr, "predTickNum");
		NativeFieldInfoPtr_sfxId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SfxEventData>.NativeClassPtr, "sfxId");
		NativeFieldInfoPtr_action = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SfxEventData>.NativeClassPtr, "action");
		NativeFieldInfoPtr_target = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SfxEventData>.NativeClassPtr, "target");
		NativeFieldInfoPtr_position = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SfxEventData>.NativeClassPtr, "position");
		NativeFieldInfoPtr_pitchSpread = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SfxEventData>.NativeClassPtr, "pitchSpread");
		NativeFieldInfoPtr_volume = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SfxEventData>.NativeClassPtr, "volume");
		NativeFieldInfoPtr_doLoop = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SfxEventData>.NativeClassPtr, "doLoop");
		NativeFieldInfoPtr_sourceSizeMultiplier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SfxEventData>.NativeClassPtr, "sourceSizeMultiplier");
		NativeFieldInfoPtr_instanceId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SfxEventData>.NativeClassPtr, "instanceId");
		NativeMethodInfoPtr_ToString_Public_Virtual_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SfxEventData>.NativeClassPtr, 100666785);
		NativeMethodInfoPtr_Equals_Public_Virtual_Final_New_Boolean_SfxEventData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SfxEventData>.NativeClassPtr, 100666786);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 75898, XrefRangeEnd = 75928, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override string ToString()
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ToString_Public_Virtual_String_0, (System.IntPtr)(nint)Unsafe.AsPointer(ref this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	[CallerCount(0)]
	public unsafe virtual bool Equals(SfxEventData eventData)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&eventData);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Equals_Public_Virtual_Final_New_Boolean_SfxEventData_0, (System.IntPtr)(nint)Unsafe.AsPointer(ref this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	public unsafe Il2CppSystem.Object BoxIl2CppObject()
	{
		return new Il2CppSystem.Object(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<SfxEventData>.NativeClassPtr, (System.IntPtr)(nint)Unsafe.AsPointer(ref this)));
	}
}
