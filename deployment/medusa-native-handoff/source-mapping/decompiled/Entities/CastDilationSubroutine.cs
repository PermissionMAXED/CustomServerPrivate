using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Local;
using Il2CppBAPBAP.Network;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppMirror;
using Il2CppSystem.Text;

namespace Il2CppBAPBAP.Entities;

public class CastDilationSubroutine : NetworkedSimulationSubroutine
{
	private static readonly IntPtr NativeFieldInfoPtr_ability;

	private static readonly IntPtr NativeFieldInfoPtr_triggerFinished;

	private static readonly IntPtr NativeFieldInfoPtr_triggerSilenced;

	private static readonly IntPtr NativeFieldInfoPtr_timeElapsed;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_Ability_Byte_Byte_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnExit_Public_Virtual_Void_Single_Command_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnNetDeserialize_Public_Virtual_Void_NetworkReader_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnNetSerialize_Public_Virtual_Void_NetworkWriter_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnNetDebugCompare_Public_Virtual_Boolean_NetworkReader_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnNetDebugLog_Public_Virtual_Void_StringBuilder_0;

	public unsafe Ability ability
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ability);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Ability>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ability)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)ability));
		}
	}

	public unsafe byte triggerFinished
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_triggerFinished);
			return *(byte*)num;
		}
		set
		{
			*(byte*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_triggerFinished)) = b;
		}
	}

	public unsafe byte triggerSilenced
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_triggerSilenced);
			return *(byte*)num;
		}
		set
		{
			*(byte*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_triggerSilenced)) = b;
		}
	}

	public unsafe float timeElapsed
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_timeElapsed);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_timeElapsed)) = num;
		}
	}

	static CastDilationSubroutine()
	{
		Il2CppClassPointerStore<CastDilationSubroutine>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Entities", "CastDilationSubroutine");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CastDilationSubroutine>.NativeClassPtr);
		NativeFieldInfoPtr_ability = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CastDilationSubroutine>.NativeClassPtr, "ability");
		NativeFieldInfoPtr_triggerFinished = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CastDilationSubroutine>.NativeClassPtr, "triggerFinished");
		NativeFieldInfoPtr_triggerSilenced = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CastDilationSubroutine>.NativeClassPtr, "triggerSilenced");
		NativeFieldInfoPtr_timeElapsed = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CastDilationSubroutine>.NativeClassPtr, "timeElapsed");
		NativeMethodInfoPtr__ctor_Public_Void_Ability_Byte_Byte_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CastDilationSubroutine>.NativeClassPtr, 100674960);
		NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CastDilationSubroutine>.NativeClassPtr, 100674961);
		NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CastDilationSubroutine>.NativeClassPtr, 100674962);
		NativeMethodInfoPtr_OnExit_Public_Virtual_Void_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CastDilationSubroutine>.NativeClassPtr, 100674963);
		NativeMethodInfoPtr_OnNetDeserialize_Public_Virtual_Void_NetworkReader_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CastDilationSubroutine>.NativeClassPtr, 100674964);
		NativeMethodInfoPtr_OnNetSerialize_Public_Virtual_Void_NetworkWriter_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CastDilationSubroutine>.NativeClassPtr, 100674965);
		NativeMethodInfoPtr_OnNetDebugCompare_Public_Virtual_Boolean_NetworkReader_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CastDilationSubroutine>.NativeClassPtr, 100674966);
		NativeMethodInfoPtr_OnNetDebugLog_Public_Virtual_Void_StringBuilder_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CastDilationSubroutine>.NativeClassPtr, 100674967);
	}

	[CallerCount(73)]
	[CachedScanResults(RefRangeStart = 125832, RefRangeEnd = 125905, XrefRangeStart = 125832, XrefRangeEnd = 125905, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe CastDilationSubroutine(Ability ability, byte triggerFinished, byte triggerSilenced)
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CastDilationSubroutine>.NativeClassPtr))
	{
		IntPtr* ptr = stackalloc IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)ability);
		*(byte**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &triggerFinished;
		*(byte**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = &triggerSilenced;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_Ability_Byte_Byte_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
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

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 0, XrefRangeEnd = 0, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void OnNetDeserialize(NetworkReader netReader)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)netReader);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnNetDeserialize_Public_Virtual_Void_NetworkReader_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 0, XrefRangeEnd = 0, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void OnNetSerialize(NetworkWriter netWriter)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)netWriter);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnNetSerialize_Public_Virtual_Void_NetworkWriter_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 0, XrefRangeEnd = 0, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override bool OnNetDebugCompare(NetworkReader netReader)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)netReader);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnNetDebugCompare_Public_Virtual_Boolean_NetworkReader_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 155416, XrefRangeEnd = 155423, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void OnNetDebugLog(StringBuilder sb)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)sb);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnNetDebugLog_Public_Virtual_Void_StringBuilder_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public CastDilationSubroutine(IntPtr pointer)
		: base(pointer)
	{
	}
}
