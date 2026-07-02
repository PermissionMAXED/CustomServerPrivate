using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using UnityEngine;

namespace Il2CppBAPBAP.Local;

public class VFXCallbackDespawn : MonoBehaviour
{
	private static readonly IntPtr NativeMethodInfoPtr_OnParticleSystemStopped_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	static VFXCallbackDespawn()
	{
		Il2CppClassPointerStore<VFXCallbackDespawn>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Local", "VFXCallbackDespawn");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<VFXCallbackDespawn>.NativeClassPtr);
		NativeMethodInfoPtr_OnParticleSystemStopped_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<VFXCallbackDespawn>.NativeClassPtr, 100684906);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<VFXCallbackDespawn>.NativeClassPtr, 100684907);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 231159, XrefRangeEnd = 231167, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnParticleSystemStopped()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnParticleSystemStopped_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(72)]
	[CachedScanResults(RefRangeStart = 5521, RefRangeEnd = 5593, XrefRangeStart = 5521, XrefRangeEnd = 5593, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe VFXCallbackDespawn()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<VFXCallbackDespawn>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public VFXCallbackDespawn(IntPtr pointer)
		: base(pointer)
	{
	}
}
