using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Build;
using Il2CppBAPBAP.Debugging;
using Il2CppBAPBAP.Network;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using UnityEngine;

namespace Il2CppBAPBAP.Local;

public class PreAwakeManager : MonoBehaviour
{
	private static readonly IntPtr NativeFieldInfoPtr_bapLogConfig;

	private static readonly IntPtr NativeFieldInfoPtr_networkConfig;

	private static readonly IntPtr NativeFieldInfoPtr_environment;

	private static readonly IntPtr NativeMethodInfoPtr_Awake_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe BapLogConfig bapLogConfig
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bapLogConfig);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<BapLogConfig>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_bapLogConfig)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)bapLogConfig));
		}
	}

	public unsafe NetworkConfig networkConfig
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_networkConfig);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<NetworkConfig>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_networkConfig)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)networkConfig));
		}
	}

	public unsafe static BuildEnvironment environment
	{
		get
		{
			Unsafe.SkipInit(out BuildEnvironment result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_environment, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_environment, (void*)(&buildEnvironment));
		}
	}

	static PreAwakeManager()
	{
		Il2CppClassPointerStore<PreAwakeManager>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Local", "PreAwakeManager");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<PreAwakeManager>.NativeClassPtr);
		NativeFieldInfoPtr_bapLogConfig = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PreAwakeManager>.NativeClassPtr, "bapLogConfig");
		NativeFieldInfoPtr_networkConfig = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PreAwakeManager>.NativeClassPtr, "networkConfig");
		NativeFieldInfoPtr_environment = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<PreAwakeManager>.NativeClassPtr, "environment");
		NativeMethodInfoPtr_Awake_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PreAwakeManager>.NativeClassPtr, 100684496);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<PreAwakeManager>.NativeClassPtr, 100684497);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 228272, XrefRangeEnd = 228378, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Awake()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Awake_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(72)]
	[CachedScanResults(RefRangeStart = 5521, RefRangeEnd = 5593, XrefRangeStart = 5521, XrefRangeEnd = 5593, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe PreAwakeManager()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<PreAwakeManager>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public PreAwakeManager(IntPtr pointer)
		: base(pointer)
	{
	}
}
