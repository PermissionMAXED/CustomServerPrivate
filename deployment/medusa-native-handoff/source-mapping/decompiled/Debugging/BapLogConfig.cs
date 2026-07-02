using System;
using System.Runtime.CompilerServices;
using Il2CppAYellowpaper.SerializedCollections;
using Il2CppBAPBAP.Build;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.InteropTypes.Arrays;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using Il2CppSystem.Reflection;
using UnityEngine;

namespace Il2CppBAPBAP.Debugging;

public class BapLogConfig : ScriptableObject
{
	private sealed class MethodInfoStoreGeneric_LoadJsonFromResources_Private_T_String_0<T>
	{
		internal static System.IntPtr Pointer = IL2CPP.il2cpp_method_get_from_reflection(IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)new MethodInfo(IL2CPP.il2cpp_method_get_object(NativeMethodInfoPtr_LoadJsonFromResources_Private_T_String_0, Il2CppClassPointerStore<BapLogConfig>.NativeClassPtr)).MakeGenericMethod(new Il2CppReferenceArray<Il2CppSystem.Type>(new Il2CppSystem.Type[1] { Il2CppSystem.Type.internal_from_handle(IL2CPP.il2cpp_class_get_type(Il2CppClassPointerStore<T>.NativeClassPtr)) }))));
	}

	private static readonly System.IntPtr NativeFieldInfoPtr_RESOURCE_PATH;

	private static readonly System.IntPtr NativeFieldInfoPtr_LogLevelTypeMapping;

	private static readonly System.IntPtr NativeFieldInfoPtr__targetEnvironment;

	private static readonly System.IntPtr NativeFieldInfoPtr__logConfigList;

	private static readonly System.IntPtr NativeFieldInfoPtr__logConfig;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_TargetEnvironment_Public_get_BuildEnvironment_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_get_Config_Public_get_LogConfig_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_LoadJsonFromResources_Private_T_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetLogConfig_Public_LogConfig_BuildEnvironment_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe static string RESOURCE_PATH
	{
		get
		{
			Unsafe.SkipInit(out System.IntPtr intPtr);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr_RESOURCE_PATH, (void*)(&intPtr));
			return IL2CPP.Il2CppStringToManaged(intPtr);
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr_RESOURCE_PATH, (void*)IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe SerializedDictionary<BapLog.BapLogLevel, LogType> LogLevelTypeMapping
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LogLevelTypeMapping);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<SerializedDictionary<BapLog.BapLogLevel, LogType>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_LogLevelTypeMapping)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)serializedDictionary));
		}
	}

	public unsafe BuildEnvironment _targetEnvironment
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__targetEnvironment);
			return *(BuildEnvironment*)num;
		}
		set
		{
			*(BuildEnvironment*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__targetEnvironment)) = buildEnvironment;
		}
	}

	public unsafe Il2CppReferenceArray<LogConfig> _logConfigList
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__logConfigList);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Il2CppReferenceArray<LogConfig>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__logConfigList)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)val));
		}
	}

	public unsafe LogConfig _logConfig
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__logConfig);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<LogConfig>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__logConfig)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)logConfig));
		}
	}

	public unsafe BuildEnvironment TargetEnvironment
	{
		[CallerCount(35)]
		[CachedScanResults(RefRangeStart = 30135, RefRangeEnd = 30170, XrefRangeStart = 30135, XrefRangeEnd = 30170, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_TargetEnvironment_Public_get_BuildEnvironment_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(BuildEnvironment*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	public unsafe LogConfig Config
	{
		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 212311, RefRangeEnd = 212312, XrefRangeStart = 212308, XrefRangeEnd = 212311, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Config_Public_get_LogConfig_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<LogConfig>(intPtr) : null;
		}
	}

	static BapLogConfig()
	{
		Il2CppClassPointerStore<BapLogConfig>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Debugging", "BapLogConfig");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<BapLogConfig>.NativeClassPtr);
		NativeFieldInfoPtr_RESOURCE_PATH = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BapLogConfig>.NativeClassPtr, "RESOURCE_PATH");
		NativeFieldInfoPtr_LogLevelTypeMapping = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BapLogConfig>.NativeClassPtr, "LogLevelTypeMapping");
		NativeFieldInfoPtr__targetEnvironment = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BapLogConfig>.NativeClassPtr, "_targetEnvironment");
		NativeFieldInfoPtr__logConfigList = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BapLogConfig>.NativeClassPtr, "_logConfigList");
		NativeFieldInfoPtr__logConfig = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BapLogConfig>.NativeClassPtr, "_logConfig");
		NativeMethodInfoPtr_get_TargetEnvironment_Public_get_BuildEnvironment_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BapLogConfig>.NativeClassPtr, 100682531);
		NativeMethodInfoPtr_get_Config_Public_get_LogConfig_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BapLogConfig>.NativeClassPtr, 100682532);
		NativeMethodInfoPtr_LoadJsonFromResources_Private_T_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BapLogConfig>.NativeClassPtr, 100682533);
		NativeMethodInfoPtr_GetLogConfig_Public_LogConfig_BuildEnvironment_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BapLogConfig>.NativeClassPtr, 100682534);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BapLogConfig>.NativeClassPtr, 100682535);
	}

	[CallerCount(10)]
	[CachedScanResults(RefRangeStart = 65156, RefRangeEnd = 65166, XrefRangeStart = 65156, XrefRangeEnd = 65166, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe T LoadJsonFromResources<T>(string path)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(path);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(MethodInfoStoreGeneric_LoadJsonFromResources_Private_T_String_0<T>.Pointer, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.PointerToValueGeneric<T>(intPtr, false, true);
	}

	[CallerCount(0)]
	public unsafe LogConfig GetLogConfig(BuildEnvironment environment)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&environment);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetLogConfig_Public_LogConfig_BuildEnvironment_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<LogConfig>(intPtr) : null;
	}

	[CallerCount(183)]
	[CachedScanResults(RefRangeStart = 39484, RefRangeEnd = 39667, XrefRangeStart = 39484, XrefRangeEnd = 39667, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe BapLogConfig()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<BapLogConfig>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public BapLogConfig(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
