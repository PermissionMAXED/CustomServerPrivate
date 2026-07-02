using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Local;
using Il2CppBAPBAP.Network;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;

namespace Il2CppBAPBAP.Entities;

public class DebugLogSubroutine : SimulationSubroutine
{
	private static readonly IntPtr NativeFieldInfoPtr_log;

	private static readonly IntPtr NativeFieldInfoPtr_logOnEnter;

	private static readonly IntPtr NativeFieldInfoPtr_logOnTick;

	private static readonly IntPtr NativeFieldInfoPtr_logOnExit;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_String_Boolean_Boolean_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnExit_Public_Virtual_Void_Single_Command_Boolean_0;

	public unsafe string log
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_log);
			return IL2CPP.Il2CppStringToManaged(*(IntPtr*)num);
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_log)), IL2CPP.ManagedStringToIl2Cpp(text));
		}
	}

	public unsafe bool logOnEnter
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_logOnEnter);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_logOnEnter)) = flag;
		}
	}

	public unsafe bool logOnTick
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_logOnTick);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_logOnTick)) = flag;
		}
	}

	public unsafe bool logOnExit
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_logOnExit);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_logOnExit)) = flag;
		}
	}

	static DebugLogSubroutine()
	{
		Il2CppClassPointerStore<DebugLogSubroutine>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Entities", "DebugLogSubroutine");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<DebugLogSubroutine>.NativeClassPtr);
		NativeFieldInfoPtr_log = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DebugLogSubroutine>.NativeClassPtr, "log");
		NativeFieldInfoPtr_logOnEnter = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DebugLogSubroutine>.NativeClassPtr, "logOnEnter");
		NativeFieldInfoPtr_logOnTick = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DebugLogSubroutine>.NativeClassPtr, "logOnTick");
		NativeFieldInfoPtr_logOnExit = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<DebugLogSubroutine>.NativeClassPtr, "logOnExit");
		NativeMethodInfoPtr__ctor_Public_Void_String_Boolean_Boolean_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DebugLogSubroutine>.NativeClassPtr, 100675025);
		NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DebugLogSubroutine>.NativeClassPtr, 100675026);
		NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DebugLogSubroutine>.NativeClassPtr, 100675027);
		NativeMethodInfoPtr_OnExit_Public_Virtual_Void_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<DebugLogSubroutine>.NativeClassPtr, 100675028);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 155895, RefRangeEnd = 155897, XrefRangeStart = 155894, XrefRangeEnd = 155895, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe DebugLogSubroutine(string log, bool logOnEnter = true, bool logOnTick = false, bool logOnExit = false)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<DebugLogSubroutine>.NativeClassPtr))
	{
		IntPtr* ptr = stackalloc IntPtr[4];
		*ptr = IL2CPP.ManagedStringToIl2Cpp(log);
		*(bool**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &logOnEnter;
		*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = &logOnTick;
		*(bool**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(IntPtr)))) = &logOnExit;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_String_Boolean_Boolean_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 155897, XrefRangeEnd = 155905, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void OnEnter(float fixedDt, Command cmd, bool isResim)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[3];
		*ptr = (nint)(&fixedDt);
		*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cmd);
		*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = &isResim;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 155905, XrefRangeEnd = 155913, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override byte OnTick(float fixedDt, Command cmd, bool isResim)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[3];
		*ptr = (nint)(&fixedDt);
		*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cmd);
		*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = &isResim;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(byte*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 155913, XrefRangeEnd = 155921, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void OnExit(float fixedDt, Command cmd, bool isResim)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[3];
		*ptr = (nint)(&fixedDt);
		*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cmd);
		*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = &isResim;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnExit_Public_Virtual_Void_Single_Command_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public DebugLogSubroutine(IntPtr pointer)
		: base(pointer)
	{
	}
}
