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
public struct VfxEventData
{
	private static readonly System.IntPtr NativeFieldInfoPtr_predTickNum;

	private static readonly System.IntPtr NativeFieldInfoPtr_vfxId;

	private static readonly System.IntPtr NativeFieldInfoPtr_action;

	private static readonly System.IntPtr NativeFieldInfoPtr_target;

	private static readonly System.IntPtr NativeFieldInfoPtr_position;

	private static readonly System.IntPtr NativeFieldInfoPtr_rotation;

	private static readonly System.IntPtr NativeFieldInfoPtr_attachableId;

	private static readonly System.IntPtr NativeFieldInfoPtr_instanceId;

	private static readonly System.IntPtr NativeFieldInfoPtr_rotateFixDelay;

	private static readonly System.IntPtr NativeMethodInfoPtr_ToString_Public_Virtual_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Equals_Public_Virtual_Final_New_Boolean_VfxEventData_0;

	[FieldOffset(0)]
	public int predTickNum;

	[FieldOffset(4)]
	public int vfxId;

	[FieldOffset(8)]
	public VfxEventAction action;

	[FieldOffset(9)]
	public VfxTarget target;

	[FieldOffset(12)]
	public Vector3 position;

	[FieldOffset(24)]
	public Quaternion rotation;

	[FieldOffset(40)]
	public byte attachableId;

	[FieldOffset(44)]
	public int instanceId;

	[FieldOffset(48)]
	public float rotateFixDelay;

	static VfxEventData()
	{
		Il2CppClassPointerStore<VfxEventData>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Network.EventData", "VfxEventData");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<VfxEventData>.NativeClassPtr);
		NativeFieldInfoPtr_predTickNum = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<VfxEventData>.NativeClassPtr, "predTickNum");
		NativeFieldInfoPtr_vfxId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<VfxEventData>.NativeClassPtr, "vfxId");
		NativeFieldInfoPtr_action = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<VfxEventData>.NativeClassPtr, "action");
		NativeFieldInfoPtr_target = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<VfxEventData>.NativeClassPtr, "target");
		NativeFieldInfoPtr_position = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<VfxEventData>.NativeClassPtr, "position");
		NativeFieldInfoPtr_rotation = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<VfxEventData>.NativeClassPtr, "rotation");
		NativeFieldInfoPtr_attachableId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<VfxEventData>.NativeClassPtr, "attachableId");
		NativeFieldInfoPtr_instanceId = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<VfxEventData>.NativeClassPtr, "instanceId");
		NativeFieldInfoPtr_rotateFixDelay = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<VfxEventData>.NativeClassPtr, "rotateFixDelay");
		NativeMethodInfoPtr_ToString_Public_Virtual_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<VfxEventData>.NativeClassPtr, 100666787);
		NativeMethodInfoPtr_Equals_Public_Virtual_Final_New_Boolean_VfxEventData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<VfxEventData>.NativeClassPtr, 100666788);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 75928, XrefRangeEnd = 75957, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override string ToString()
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ToString_Public_Virtual_String_0, (System.IntPtr)(nint)Unsafe.AsPointer(ref this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	[CallerCount(0)]
	public unsafe virtual bool Equals(VfxEventData eventData)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&eventData);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Equals_Public_Virtual_Final_New_Boolean_VfxEventData_0, (System.IntPtr)(nint)Unsafe.AsPointer(ref this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	public unsafe Il2CppSystem.Object BoxIl2CppObject()
	{
		return new Il2CppSystem.Object(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<VfxEventData>.NativeClassPtr, (System.IntPtr)(nint)Unsafe.AsPointer(ref this)));
	}
}
