using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppSystem;

namespace Il2CppBAPBAP.Debugging;

public static class BapLog : Il2CppSystem.Object
{
	[OriginalName("Assembly-CSharp.dll", "", "BapLogLevel")]
	public enum BapLogLevel
	{
		Trace,
		Debug,
		Info,
		Warning,
		Error
	}

	private static readonly System.IntPtr NativeFieldInfoPtr__currentLogLevel;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetSettings_Public_Static_Void_LogConfig_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetLogLevel_Public_Static_Void_BapLogLevel_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Trace_Public_Static_Void_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Debug_Public_Static_Void_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Info_Public_Static_Void_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Warning_Public_Static_Void_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Error_Public_Static_Void_String_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Exception_Public_Static_Void_Exception_0;

	public unsafe static BapLogLevel _currentLogLevel
	{
		get
		{
			Unsafe.SkipInit(out BapLogLevel result);
			IL2CPP.il2cpp_field_static_get_value(NativeFieldInfoPtr__currentLogLevel, (void*)(&result));
			return result;
		}
		set
		{
			IL2CPP.il2cpp_field_static_set_value(NativeFieldInfoPtr__currentLogLevel, (void*)(&bapLogLevel));
		}
	}

	static BapLog()
	{
		Il2CppClassPointerStore<BapLog>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Debugging", "BapLog");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<BapLog>.NativeClassPtr);
		NativeFieldInfoPtr__currentLogLevel = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BapLog>.NativeClassPtr, "_currentLogLevel");
		NativeMethodInfoPtr_SetSettings_Public_Static_Void_LogConfig_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BapLog>.NativeClassPtr, 100682523);
		NativeMethodInfoPtr_SetLogLevel_Public_Static_Void_BapLogLevel_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BapLog>.NativeClassPtr, 100682524);
		NativeMethodInfoPtr_Trace_Public_Static_Void_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BapLog>.NativeClassPtr, 100682525);
		NativeMethodInfoPtr_Debug_Public_Static_Void_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BapLog>.NativeClassPtr, 100682526);
		NativeMethodInfoPtr_Info_Public_Static_Void_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BapLog>.NativeClassPtr, 100682527);
		NativeMethodInfoPtr_Warning_Public_Static_Void_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BapLog>.NativeClassPtr, 100682528);
		NativeMethodInfoPtr_Error_Public_Static_Void_String_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BapLog>.NativeClassPtr, 100682529);
		NativeMethodInfoPtr_Exception_Public_Static_Void_Exception_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BapLog>.NativeClassPtr, 100682530);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 212263, RefRangeEnd = 212264, XrefRangeStart = 212249, XrefRangeEnd = 212263, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void SetSettings(LogConfig config)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)config);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetSettings_Public_Static_Void_LogConfig_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 212273, RefRangeEnd = 212275, XrefRangeStart = 212264, XrefRangeEnd = 212273, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void SetLogLevel(BapLogLevel logLevel)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&logLevel);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetLogLevel_Public_Static_Void_BapLogLevel_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(8)]
	[CachedScanResults(RefRangeStart = 212279, RefRangeEnd = 212287, XrefRangeStart = 212275, XrefRangeEnd = 212279, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void Trace(string msg)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(msg);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Trace_Public_Static_Void_String_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 212287, XrefRangeEnd = 212291, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void Debug(string msg)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(msg);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Debug_Public_Static_Void_String_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 212291, XrefRangeEnd = 212295, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void Info(string msg)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(msg);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Info_Public_Static_Void_String_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 212299, RefRangeEnd = 212300, XrefRangeStart = 212295, XrefRangeEnd = 212299, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void Warning(string msg)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(msg);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Warning_Public_Static_Void_String_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 212300, XrefRangeEnd = 212304, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void Error(string msg)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(msg);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Error_Public_Static_Void_String_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 212304, XrefRangeEnd = 212308, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void Exception(Il2CppSystem.Exception e)
	{
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)e);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Exception_Public_Static_Void_Exception_0, (System.IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public BapLog(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
