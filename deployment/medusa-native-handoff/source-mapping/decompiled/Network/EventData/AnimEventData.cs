using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using Il2CppBAPBAP.Entities;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppSystem;

namespace Il2CppBAPBAP.Network.EventData;

[StructLayout(LayoutKind.Explicit)]
public struct AnimEventData
{
	private static readonly System.IntPtr NativeFieldInfoPtr_predTickNum;

	private static readonly System.IntPtr NativeFieldInfoPtr_layerIndex;

	private static readonly System.IntPtr NativeFieldInfoPtr_stateHash;

	private static readonly System.IntPtr NativeFieldInfoPtr_time;

	private static readonly System.IntPtr NativeMethodInfoPtr_ToString_Public_Virtual_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Equals_Public_Virtual_Final_New_Boolean_AnimEventData_0;

	[FieldOffset(0)]
	public int predTickNum;

	[FieldOffset(4)]
	public AnimLayerIndices layerIndex;

	[FieldOffset(8)]
	public int stateHash;

	[FieldOffset(12)]
	public float time;

	static AnimEventData()
	{
		Il2CppClassPointerStore<AnimEventData>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Network.EventData", "AnimEventData");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<AnimEventData>.NativeClassPtr);
		NativeFieldInfoPtr_predTickNum = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AnimEventData>.NativeClassPtr, "predTickNum");
		NativeFieldInfoPtr_layerIndex = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AnimEventData>.NativeClassPtr, "layerIndex");
		NativeFieldInfoPtr_stateHash = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AnimEventData>.NativeClassPtr, "stateHash");
		NativeFieldInfoPtr_time = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<AnimEventData>.NativeClassPtr, "time");
		NativeMethodInfoPtr_ToString_Public_Virtual_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<AnimEventData>.NativeClassPtr, 100666783);
		NativeMethodInfoPtr_Equals_Public_Virtual_Final_New_Boolean_AnimEventData_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<AnimEventData>.NativeClassPtr, 100666784);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 75883, XrefRangeEnd = 75898, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override string ToString()
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ToString_Public_Virtual_String_0, (System.IntPtr)(nint)Unsafe.AsPointer(ref this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	[CallerCount(0)]
	public unsafe virtual bool Equals(AnimEventData eventData)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&eventData);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Equals_Public_Virtual_Final_New_Boolean_AnimEventData_0, (System.IntPtr)(nint)Unsafe.AsPointer(ref this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	public unsafe Il2CppSystem.Object BoxIl2CppObject()
	{
		return new Il2CppSystem.Object(IL2CPP.il2cpp_value_box(Il2CppClassPointerStore<AnimEventData>.NativeClassPtr, (System.IntPtr)(nint)Unsafe.AsPointer(ref this)));
	}
}
