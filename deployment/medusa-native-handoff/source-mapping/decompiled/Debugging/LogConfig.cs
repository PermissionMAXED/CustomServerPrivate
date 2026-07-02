using System;
using System.Runtime.CompilerServices;
using Il2CppAYellowpaper.SerializedCollections;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using UnityEngine;

namespace Il2CppBAPBAP.Debugging;

[System.Serializable]
public class LogConfig : Il2CppSystem.Object
{
	private static readonly System.IntPtr NativeFieldInfoPtr_MinimumLogLevel;

	private static readonly System.IntPtr NativeFieldInfoPtr_LogTypeStackTraceMapping;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe BapLog.BapLogLevel MinimumLogLevel
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MinimumLogLevel);
			return *(BapLog.BapLogLevel*)num;
		}
		set
		{
			*(BapLog.BapLogLevel*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_MinimumLogLevel)) = bapLogLevel;
		}
	}

	public unsafe SerializedDictionary<LogType, StackTraceLogType> LogTypeStackTraceMapping
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LogTypeStackTraceMapping);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<SerializedDictionary<LogType, StackTraceLogType>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LogTypeStackTraceMapping)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)serializedDictionary));
		}
	}

	static LogConfig()
	{
		Il2CppClassPointerStore<LogConfig>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Debugging", "LogConfig");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<LogConfig>.NativeClassPtr);
		NativeFieldInfoPtr_MinimumLogLevel = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LogConfig>.NativeClassPtr, "MinimumLogLevel");
		NativeFieldInfoPtr_LogTypeStackTraceMapping = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<LogConfig>.NativeClassPtr, "LogTypeStackTraceMapping");
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<LogConfig>.NativeClassPtr, 100682536);
	}

	[CallerCount(5410)]
	[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe LogConfig()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<LogConfig>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public LogConfig(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
