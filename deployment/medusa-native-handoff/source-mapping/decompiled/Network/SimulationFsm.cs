using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Local;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppMirror;
using Il2CppSystem;
using Il2CppSystem.Collections.Generic;
using Il2CppSystem.Text;

namespace Il2CppBAPBAP.Network;

public class SimulationFsm : Il2CppSystem.Object
{
	public class Builder : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr__fsm;

		private static readonly System.IntPtr NativeFieldInfoPtr_currentBuilderState;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_State_Public_Builder_Byte_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_AddSubroutine_Public_Builder_SimulationSubroutine_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_AddTransition_Public_Builder_Byte_Byte_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_Start_Public_Builder_Byte_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_Build_Public_SimulationFsm_0;

		public unsafe SimulationFsm _fsm
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__fsm);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<SimulationFsm>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr__fsm)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)simulationFsm));
			}
		}

		public unsafe byte currentBuilderState
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentBuilderState);
				return *(byte*)num;
			}
			set
			{
				*(byte*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentBuilderState)) = b;
			}
		}

		static Builder()
		{
			Il2CppClassPointerStore<Builder>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<SimulationFsm>.NativeClassPtr, "Builder");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<Builder>.NativeClassPtr);
			NativeFieldInfoPtr__fsm = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Builder>.NativeClassPtr, "_fsm");
			NativeFieldInfoPtr_currentBuilderState = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<Builder>.NativeClassPtr, "currentBuilderState");
			NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Builder>.NativeClassPtr, 100666670);
			NativeMethodInfoPtr_State_Public_Builder_Byte_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Builder>.NativeClassPtr, 100666671);
			NativeMethodInfoPtr_AddSubroutine_Public_Builder_SimulationSubroutine_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Builder>.NativeClassPtr, 100666672);
			NativeMethodInfoPtr_AddTransition_Public_Builder_Byte_Byte_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Builder>.NativeClassPtr, 100666673);
			NativeMethodInfoPtr_Start_Public_Builder_Byte_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Builder>.NativeClassPtr, 100666674);
			NativeMethodInfoPtr_Build_Public_SimulationFsm_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<Builder>.NativeClassPtr, 100666675);
		}

		[CallerCount(224)]
		[CachedScanResults(RefRangeStart = 65223, RefRangeEnd = 65447, XrefRangeStart = 65203, XrefRangeEnd = 65223, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe Builder()
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<Builder>.NativeClassPtr))
		{
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(1492)]
		[CachedScanResults(RefRangeStart = 65459, RefRangeEnd = 66951, XrefRangeStart = 65447, XrefRangeEnd = 65459, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe Builder State(byte state)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = (nint)(&state);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_State_Public_Builder_Byte_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Builder>(intPtr) : null;
		}

		[CallerCount(5480)]
		[CachedScanResults(RefRangeStart = 66961, RefRangeEnd = 72441, XrefRangeStart = 66951, XrefRangeEnd = 66961, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe Builder AddSubroutine(SimulationSubroutine subroutine)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)subroutine);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_AddSubroutine_Public_Builder_SimulationSubroutine_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Builder>(intPtr) : null;
		}

		[CallerCount(2232)]
		[CachedScanResults(RefRangeStart = 72445, RefRangeEnd = 74677, XrefRangeStart = 72441, XrefRangeEnd = 72445, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe Builder AddTransition(byte trigger, byte state)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[2];
			*ptr = (nint)(&trigger);
			*(byte**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &state;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_AddTransition_Public_Builder_Byte_Byte_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Builder>(intPtr) : null;
		}

		[CallerCount(220)]
		[CachedScanResults(RefRangeStart = 74677, RefRangeEnd = 74897, XrefRangeStart = 74677, XrefRangeEnd = 74677, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe Builder Start(byte startState)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = (nint)(&startState);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Start_Public_Builder_Byte_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Builder>(intPtr) : null;
		}

		[CallerCount(572)]
		[CachedScanResults(RefRangeStart = 33243, RefRangeEnd = 33815, XrefRangeStart = 33243, XrefRangeEnd = 33815, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe SimulationFsm Build()
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = null;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Build_Public_SimulationFsm_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<SimulationFsm>(intPtr) : null;
		}

		public Builder(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	private static readonly System.IntPtr NativeFieldInfoPtr_subroutinesByState;

	private static readonly System.IntPtr NativeFieldInfoPtr_transitionsByState;

	private static readonly System.IntPtr NativeFieldInfoPtr_allSubroutines;

	private static readonly System.IntPtr NativeFieldInfoPtr_networkedSubroutines;

	private static readonly System.IntPtr NativeFieldInfoPtr_initialized;

	private static readonly System.IntPtr NativeFieldInfoPtr_remainderFixedDt;

	private static readonly System.IntPtr NativeFieldInfoPtr_externalTrigger;

	private static readonly System.IntPtr NativeFieldInfoPtr_currentState;

	private static readonly System.IntPtr NativeMethodInfoPtr_Tick_Public_Void_Single_Command_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnTick_Private_Void_Command_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnEnter_Private_Void_Command_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnExit_Private_Void_Command_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Fire_Private_Void_Byte_Command_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_FireExternal_Public_Void_Byte_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_FireExternalImmediate_Public_Void_Byte_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_ChangeState_Public_Void_Byte_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetNewRemainderFixedDt_Public_Void_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_DeBuild_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnNetDeserialize_Public_Void_NetworkReader_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnNetSerialize_Public_Void_NetworkWriter_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnNetDebugCompare_Public_Boolean_NetworkReader_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnNetDebugLog_Public_Void_StringBuilder_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe Dictionary<byte, List<SimulationSubroutine>> subroutinesByState
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_subroutinesByState);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Dictionary<byte, List<SimulationSubroutine>>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_subroutinesByState)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)dictionary));
		}
	}

	public unsafe Dictionary<byte, Dictionary<byte, byte>> transitionsByState
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_transitionsByState);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Dictionary<byte, Dictionary<byte, byte>>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_transitionsByState)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)dictionary));
		}
	}

	public unsafe List<SimulationSubroutine> allSubroutines
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_allSubroutines);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<SimulationSubroutine>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_allSubroutines)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	public unsafe List<NetworkedSimulationSubroutine> networkedSubroutines
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_networkedSubroutines);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<List<NetworkedSimulationSubroutine>>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_networkedSubroutines)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	public unsafe bool initialized
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_initialized);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_initialized)) = flag;
		}
	}

	public unsafe float remainderFixedDt
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_remainderFixedDt);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_remainderFixedDt)) = num;
		}
	}

	public unsafe byte externalTrigger
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_externalTrigger);
			return *(byte*)num;
		}
		set
		{
			*(byte*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_externalTrigger)) = b;
		}
	}

	public unsafe byte currentState
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentState);
			return *(byte*)num;
		}
		set
		{
			*(byte*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentState)) = b;
		}
	}

	static SimulationFsm()
	{
		Il2CppClassPointerStore<SimulationFsm>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Network", "SimulationFsm");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<SimulationFsm>.NativeClassPtr);
		NativeFieldInfoPtr_subroutinesByState = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SimulationFsm>.NativeClassPtr, "subroutinesByState");
		NativeFieldInfoPtr_transitionsByState = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SimulationFsm>.NativeClassPtr, "transitionsByState");
		NativeFieldInfoPtr_allSubroutines = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SimulationFsm>.NativeClassPtr, "allSubroutines");
		NativeFieldInfoPtr_networkedSubroutines = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SimulationFsm>.NativeClassPtr, "networkedSubroutines");
		NativeFieldInfoPtr_initialized = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SimulationFsm>.NativeClassPtr, "initialized");
		NativeFieldInfoPtr_remainderFixedDt = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SimulationFsm>.NativeClassPtr, "remainderFixedDt");
		NativeFieldInfoPtr_externalTrigger = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SimulationFsm>.NativeClassPtr, "externalTrigger");
		NativeFieldInfoPtr_currentState = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SimulationFsm>.NativeClassPtr, "currentState");
		NativeMethodInfoPtr_Tick_Public_Void_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SimulationFsm>.NativeClassPtr, 100666655);
		NativeMethodInfoPtr_OnTick_Private_Void_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SimulationFsm>.NativeClassPtr, 100666656);
		NativeMethodInfoPtr_OnEnter_Private_Void_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SimulationFsm>.NativeClassPtr, 100666657);
		NativeMethodInfoPtr_OnExit_Private_Void_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SimulationFsm>.NativeClassPtr, 100666658);
		NativeMethodInfoPtr_Fire_Private_Void_Byte_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SimulationFsm>.NativeClassPtr, 100666659);
		NativeMethodInfoPtr_FireExternal_Public_Void_Byte_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SimulationFsm>.NativeClassPtr, 100666660);
		NativeMethodInfoPtr_FireExternalImmediate_Public_Void_Byte_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SimulationFsm>.NativeClassPtr, 100666661);
		NativeMethodInfoPtr_ChangeState_Public_Void_Byte_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SimulationFsm>.NativeClassPtr, 100666662);
		NativeMethodInfoPtr_SetNewRemainderFixedDt_Public_Void_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SimulationFsm>.NativeClassPtr, 100666663);
		NativeMethodInfoPtr_DeBuild_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SimulationFsm>.NativeClassPtr, 100666664);
		NativeMethodInfoPtr_OnNetDeserialize_Public_Void_NetworkReader_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SimulationFsm>.NativeClassPtr, 100666665);
		NativeMethodInfoPtr_OnNetSerialize_Public_Void_NetworkWriter_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SimulationFsm>.NativeClassPtr, 100666666);
		NativeMethodInfoPtr_OnNetDebugCompare_Public_Boolean_NetworkReader_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SimulationFsm>.NativeClassPtr, 100666667);
		NativeMethodInfoPtr_OnNetDebugLog_Public_Void_StringBuilder_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SimulationFsm>.NativeClassPtr, 100666668);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SimulationFsm>.NativeClassPtr, 100666669);
	}

	[CallerCount(14)]
	[CachedScanResults(RefRangeStart = 74911, RefRangeEnd = 74925, XrefRangeStart = 74897, XrefRangeEnd = 74911, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Tick(float fixedDt, Command cmd, bool isResim)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = (nint)(&fixedDt);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cmd);
		*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &isResim;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Tick_Public_Void_Single_Command_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 74936, RefRangeEnd = 74938, XrefRangeStart = 74925, XrefRangeEnd = 74936, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnTick(Command cmd, bool isResim)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cmd);
		*(bool**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &isResim;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnTick_Private_Void_Command_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 74944, RefRangeEnd = 74947, XrefRangeStart = 74938, XrefRangeEnd = 74944, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnEnter(Command cmd, bool isResim)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cmd);
		*(bool**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &isResim;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnEnter_Private_Void_Command_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 74953, RefRangeEnd = 74955, XrefRangeStart = 74947, XrefRangeEnd = 74953, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnExit(Command cmd, bool isResim)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cmd);
		*(bool**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &isResim;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnExit_Private_Void_Command_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 74962, RefRangeEnd = 74964, XrefRangeStart = 74955, XrefRangeEnd = 74962, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Fire(byte trigger, Command cmd, bool isResim)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = (nint)(&trigger);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cmd);
		*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &isResim;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Fire_Private_Void_Byte_Command_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 74964, RefRangeEnd = 74966, XrefRangeStart = 74964, XrefRangeEnd = 74964, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void FireExternal(byte trigger)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&trigger);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_FireExternal_Public_Void_Byte_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 74974, RefRangeEnd = 74976, XrefRangeStart = 74966, XrefRangeEnd = 74974, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void FireExternalImmediate(byte trigger)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&trigger);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_FireExternalImmediate_Public_Void_Byte_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 74978, RefRangeEnd = 74979, XrefRangeStart = 74976, XrefRangeEnd = 74978, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ChangeState(byte stateId)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&stateId);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ChangeState_Public_Void_Byte_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 74979, RefRangeEnd = 74980, XrefRangeStart = 74979, XrefRangeEnd = 74979, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetNewRemainderFixedDt(float _remainderFixedDt)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&_remainderFixedDt);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetNewRemainderFixedDt_Public_Void_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(4)]
	[CachedScanResults(RefRangeStart = 74984, RefRangeEnd = 74988, XrefRangeStart = 74980, XrefRangeEnd = 74984, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void DeBuild()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_DeBuild_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 74993, RefRangeEnd = 74995, XrefRangeStart = 74988, XrefRangeEnd = 74993, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnNetDeserialize(NetworkReader netReader)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)netReader);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnNetDeserialize_Public_Void_NetworkReader_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 75000, RefRangeEnd = 75002, XrefRangeStart = 74995, XrefRangeEnd = 75000, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnNetSerialize(NetworkWriter netWriter)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)netWriter);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnNetSerialize_Public_Void_NetworkWriter_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(6)]
	[CachedScanResults(RefRangeStart = 75009, RefRangeEnd = 75015, XrefRangeStart = 75002, XrefRangeEnd = 75009, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe bool OnNetDebugCompare(NetworkReader netReader)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)netReader);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnNetDebugCompare_Public_Boolean_NetworkReader_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(7)]
	[CachedScanResults(RefRangeStart = 75024, RefRangeEnd = 75031, XrefRangeStart = 75015, XrefRangeEnd = 75024, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void OnNetDebugLog(StringBuilder sb)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)sb);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_OnNetDebugLog_Public_Void_StringBuilder_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(5410)]
	[CachedScanResults(RefRangeStart = 11, RefRangeEnd = 5421, XrefRangeStart = 11, XrefRangeEnd = 5421, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe SimulationFsm()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<SimulationFsm>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public SimulationFsm(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
