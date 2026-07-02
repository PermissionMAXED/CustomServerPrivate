using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Items;
using Il2CppBAPBAP.Local;
using Il2CppBAPBAP.Network;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem;
using UnityEngine;
using UnityEngine.AI;

namespace Il2CppBAPBAP.Entities;

public class CharacterBotBehaviour : NpcBehaviour
{
	[System.Serializable]
	public class TransitionState : Il2CppSystem.Object
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_score;

		private static readonly System.IntPtr NativeFieldInfoPtr_state;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_BotStates_0;

		public unsafe float score
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_score);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_score)) = num;
			}
		}

		public unsafe BotStates state
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_state);
				return *(BotStates*)num;
			}
			set
			{
				*(BotStates*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_state)) = botStates;
			}
		}

		static TransitionState()
		{
			Il2CppClassPointerStore<TransitionState>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "TransitionState");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<TransitionState>.NativeClassPtr);
			NativeFieldInfoPtr_score = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TransitionState>.NativeClassPtr, "score");
			NativeFieldInfoPtr_state = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<TransitionState>.NativeClassPtr, "state");
			NativeMethodInfoPtr__ctor_Public_Void_BotStates_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<TransitionState>.NativeClassPtr, 100675532);
		}

		[CallerCount(5)]
		[CachedScanResults(RefRangeStart = 162892, RefRangeEnd = 162897, XrefRangeStart = 162891, XrefRangeEnd = 162892, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe TransitionState(BotStates _state)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<TransitionState>.NativeClassPtr))
		{
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = (nint)(&_state);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_BotStates_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public TransitionState(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[OriginalName("Assembly-CSharp.dll", "", "BotStates")]
	public enum BotStates
	{
		Idle,
		Wandering,
		MoveZoneCenter,
		CombatEnemy,
		SearchEnemy,
		Looting,
		Heal
	}

	public class BotEvaluateTransitionSubroutine : SimulationSubroutine
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_behaviour;

		private static readonly System.IntPtr NativeFieldInfoPtr_firstFrame;

		private static readonly System.IntPtr NativeFieldInfoPtr_triggerTransition;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_CharacterBotBehaviour_Byte_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0;

		public unsafe CharacterBotBehaviour behaviour
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_behaviour);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharacterBotBehaviour>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_behaviour)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)characterBotBehaviour));
			}
		}

		public unsafe bool firstFrame
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_firstFrame);
				return *(bool*)num;
			}
			set
			{
				*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_firstFrame)) = flag;
			}
		}

		public unsafe byte triggerTransition
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_triggerTransition);
				return *(byte*)num;
			}
			set
			{
				*(byte*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_triggerTransition)) = b;
			}
		}

		static BotEvaluateTransitionSubroutine()
		{
			Il2CppClassPointerStore<BotEvaluateTransitionSubroutine>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "BotEvaluateTransitionSubroutine");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<BotEvaluateTransitionSubroutine>.NativeClassPtr);
			NativeFieldInfoPtr_behaviour = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BotEvaluateTransitionSubroutine>.NativeClassPtr, "behaviour");
			NativeFieldInfoPtr_firstFrame = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BotEvaluateTransitionSubroutine>.NativeClassPtr, "firstFrame");
			NativeFieldInfoPtr_triggerTransition = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BotEvaluateTransitionSubroutine>.NativeClassPtr, "triggerTransition");
			NativeMethodInfoPtr__ctor_Public_Void_CharacterBotBehaviour_Byte_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BotEvaluateTransitionSubroutine>.NativeClassPtr, 100675533);
			NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BotEvaluateTransitionSubroutine>.NativeClassPtr, 100675534);
			NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BotEvaluateTransitionSubroutine>.NativeClassPtr, 100675535);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 162897, XrefRangeEnd = 162898, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe BotEvaluateTransitionSubroutine(CharacterBotBehaviour _behaviour, byte _triggerTransition)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<BotEvaluateTransitionSubroutine>.NativeClassPtr))
		{
			System.IntPtr* ptr = stackalloc System.IntPtr[2];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_behaviour);
			*(byte**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &_triggerTransition;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_CharacterBotBehaviour_Byte_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(11)]
		[CachedScanResults(RefRangeStart = 162898, RefRangeEnd = 162909, XrefRangeStart = 162898, XrefRangeEnd = 162898, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[3];
			*ptr = (nint)(&fixedDt);
			*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cmd);
			*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &isResim;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 162909, XrefRangeEnd = 162910, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe override byte OnTick(float fixedDt, Command cmd, bool isResim)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[3];
			*ptr = (nint)(&fixedDt);
			*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cmd);
			*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &isResim;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(byte*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		public BotEvaluateTransitionSubroutine(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	public class SetCurrentStateSubroutine : SimulationSubroutine
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_behaviour;

		private static readonly System.IntPtr NativeFieldInfoPtr_botState;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_CharacterBotBehaviour_BotStates_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0;

		public unsafe CharacterBotBehaviour behaviour
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_behaviour);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharacterBotBehaviour>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_behaviour)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)characterBotBehaviour));
			}
		}

		public unsafe BotStates botState
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_botState);
				return *(BotStates*)num;
			}
			set
			{
				*(BotStates*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_botState)) = botStates;
			}
		}

		static SetCurrentStateSubroutine()
		{
			Il2CppClassPointerStore<SetCurrentStateSubroutine>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "SetCurrentStateSubroutine");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<SetCurrentStateSubroutine>.NativeClassPtr);
			NativeFieldInfoPtr_behaviour = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SetCurrentStateSubroutine>.NativeClassPtr, "behaviour");
			NativeFieldInfoPtr_botState = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<SetCurrentStateSubroutine>.NativeClassPtr, "botState");
			NativeMethodInfoPtr__ctor_Public_Void_CharacterBotBehaviour_BotStates_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SetCurrentStateSubroutine>.NativeClassPtr, 100675536);
			NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<SetCurrentStateSubroutine>.NativeClassPtr, 100675537);
		}

		[CallerCount(110)]
		[CachedScanResults(RefRangeStart = 129576, RefRangeEnd = 129686, XrefRangeStart = 129576, XrefRangeEnd = 129686, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe SetCurrentStateSubroutine(CharacterBotBehaviour _behaviour, BotStates _botState)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<SetCurrentStateSubroutine>.NativeClassPtr))
		{
			System.IntPtr* ptr = stackalloc System.IntPtr[2];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_behaviour);
			*(BotStates**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &_botState;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_CharacterBotBehaviour_BotStates_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 162910, XrefRangeEnd = 162917, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[3];
			*ptr = (nint)(&fixedDt);
			*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cmd);
			*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &isResim;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public SetCurrentStateSubroutine(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	public class BotTransitionSubroutine : SimulationSubroutine
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_behaviour;

		private static readonly System.IntPtr NativeFieldInfoPtr_firstFrame;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_CharacterBotBehaviour_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0;

		public unsafe CharacterBotBehaviour behaviour
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_behaviour);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharacterBotBehaviour>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_behaviour)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)characterBotBehaviour));
			}
		}

		public unsafe bool firstFrame
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_firstFrame);
				return *(bool*)num;
			}
			set
			{
				*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_firstFrame)) = flag;
			}
		}

		static BotTransitionSubroutine()
		{
			Il2CppClassPointerStore<BotTransitionSubroutine>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "BotTransitionSubroutine");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<BotTransitionSubroutine>.NativeClassPtr);
			NativeFieldInfoPtr_behaviour = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BotTransitionSubroutine>.NativeClassPtr, "behaviour");
			NativeFieldInfoPtr_firstFrame = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BotTransitionSubroutine>.NativeClassPtr, "firstFrame");
			NativeMethodInfoPtr__ctor_Public_Void_CharacterBotBehaviour_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BotTransitionSubroutine>.NativeClassPtr, 100675538);
			NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BotTransitionSubroutine>.NativeClassPtr, 100675539);
			NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BotTransitionSubroutine>.NativeClassPtr, 100675540);
		}

		[CallerCount(534)]
		[CachedScanResults(RefRangeStart = 124041, RefRangeEnd = 124575, XrefRangeStart = 124041, XrefRangeEnd = 124575, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe BotTransitionSubroutine(CharacterBotBehaviour _behaviour)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<BotTransitionSubroutine>.NativeClassPtr))
		{
			System.IntPtr* ptr = stackalloc System.IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_behaviour);
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_CharacterBotBehaviour_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(11)]
		[CachedScanResults(RefRangeStart = 162898, RefRangeEnd = 162909, XrefRangeStart = 162898, XrefRangeEnd = 162909, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[3];
			*ptr = (nint)(&fixedDt);
			*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cmd);
			*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &isResim;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		public unsafe override byte OnTick(float fixedDt, Command cmd, bool isResim)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[3];
			*ptr = (nint)(&fixedDt);
			*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cmd);
			*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &isResim;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(byte*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		public BotTransitionSubroutine(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	public class NpcInterruptAbilityTargetDistSubroutine : SimulationSubroutine
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_behaviour;

		private static readonly System.IntPtr NativeFieldInfoPtr_ability;

		private static readonly System.IntPtr NativeFieldInfoPtr_castFlag;

		private static readonly System.IntPtr NativeFieldInfoPtr_triggered;

		private static readonly System.IntPtr NativeFieldInfoPtr_distSqr;

		private static readonly System.IntPtr NativeFieldInfoPtr_slot;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_CharacterBotBehaviour_Single_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0;

		public unsafe CharacterBotBehaviour behaviour
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_behaviour);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharacterBotBehaviour>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_behaviour)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)characterBotBehaviour));
			}
		}

		public unsafe Ability ability
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ability);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<Ability>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ability)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)ability));
			}
		}

		public unsafe CastFlags castFlag
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castFlag);
				return *(CastFlags*)num;
			}
			set
			{
				*(CastFlags*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castFlag)) = castFlags;
			}
		}

		public unsafe bool triggered
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_triggered);
				return *(bool*)num;
			}
			set
			{
				*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_triggered)) = flag;
			}
		}

		public unsafe float distSqr
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_distSqr);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_distSqr)) = num;
			}
		}

		public unsafe int slot
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_slot);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_slot)) = num;
			}
		}

		static NpcInterruptAbilityTargetDistSubroutine()
		{
			Il2CppClassPointerStore<NpcInterruptAbilityTargetDistSubroutine>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "NpcInterruptAbilityTargetDistSubroutine");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<NpcInterruptAbilityTargetDistSubroutine>.NativeClassPtr);
			NativeFieldInfoPtr_behaviour = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcInterruptAbilityTargetDistSubroutine>.NativeClassPtr, "behaviour");
			NativeFieldInfoPtr_ability = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcInterruptAbilityTargetDistSubroutine>.NativeClassPtr, "ability");
			NativeFieldInfoPtr_castFlag = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcInterruptAbilityTargetDistSubroutine>.NativeClassPtr, "castFlag");
			NativeFieldInfoPtr_triggered = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcInterruptAbilityTargetDistSubroutine>.NativeClassPtr, "triggered");
			NativeFieldInfoPtr_distSqr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcInterruptAbilityTargetDistSubroutine>.NativeClassPtr, "distSqr");
			NativeFieldInfoPtr_slot = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcInterruptAbilityTargetDistSubroutine>.NativeClassPtr, "slot");
			NativeMethodInfoPtr__ctor_Public_Void_CharacterBotBehaviour_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcInterruptAbilityTargetDistSubroutine>.NativeClassPtr, 100675541);
			NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcInterruptAbilityTargetDistSubroutine>.NativeClassPtr, 100675542);
			NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcInterruptAbilityTargetDistSubroutine>.NativeClassPtr, 100675543);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 162917, XrefRangeEnd = 162918, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe NpcInterruptAbilityTargetDistSubroutine(CharacterBotBehaviour _behaviour, float distance)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<NpcInterruptAbilityTargetDistSubroutine>.NativeClassPtr))
		{
			System.IntPtr* ptr = stackalloc System.IntPtr[2];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_behaviour);
			*(float**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &distance;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_CharacterBotBehaviour_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 162918, XrefRangeEnd = 162922, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[3];
			*ptr = (nint)(&fixedDt);
			*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cmd);
			*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &isResim;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 162922, XrefRangeEnd = 162930, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe override byte OnTick(float fixedDt, Command cmd, bool isResim)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[3];
			*ptr = (nint)(&fixedDt);
			*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cmd);
			*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &isResim;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(byte*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		public NpcInterruptAbilityTargetDistSubroutine(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	public class BotPickUpItemSubroutine : SimulationSubroutine
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_behaviour;

		private static readonly System.IntPtr NativeFieldInfoPtr_triggerInvalidItem;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_CharacterBotBehaviour_Byte_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0;

		public unsafe CharacterBotBehaviour behaviour
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_behaviour);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharacterBotBehaviour>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_behaviour)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)characterBotBehaviour));
			}
		}

		public unsafe byte triggerInvalidItem
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_triggerInvalidItem);
				return *(byte*)num;
			}
			set
			{
				*(byte*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_triggerInvalidItem)) = b;
			}
		}

		static BotPickUpItemSubroutine()
		{
			Il2CppClassPointerStore<BotPickUpItemSubroutine>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "BotPickUpItemSubroutine");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<BotPickUpItemSubroutine>.NativeClassPtr);
			NativeFieldInfoPtr_behaviour = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BotPickUpItemSubroutine>.NativeClassPtr, "behaviour");
			NativeFieldInfoPtr_triggerInvalidItem = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BotPickUpItemSubroutine>.NativeClassPtr, "triggerInvalidItem");
			NativeMethodInfoPtr__ctor_Public_Void_CharacterBotBehaviour_Byte_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BotPickUpItemSubroutine>.NativeClassPtr, 100675544);
			NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BotPickUpItemSubroutine>.NativeClassPtr, 100675545);
			NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BotPickUpItemSubroutine>.NativeClassPtr, 100675546);
		}

		[CallerCount(35)]
		[CachedScanResults(RefRangeStart = 123824, RefRangeEnd = 123859, XrefRangeStart = 123824, XrefRangeEnd = 123859, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe BotPickUpItemSubroutine(CharacterBotBehaviour _behaviour, byte _triggerInvalidItem)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<BotPickUpItemSubroutine>.NativeClassPtr))
		{
			System.IntPtr* ptr = stackalloc System.IntPtr[2];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_behaviour);
			*(byte**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &_triggerInvalidItem;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_CharacterBotBehaviour_Byte_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(17738)]
		[CachedScanResults(RefRangeStart = 5595, RefRangeEnd = 23333, XrefRangeStart = 5595, XrefRangeEnd = 23333, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[3];
			*ptr = (nint)(&fixedDt);
			*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cmd);
			*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &isResim;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 162930, XrefRangeEnd = 162938, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe override byte OnTick(float fixedDt, Command cmd, bool isResim)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[3];
			*ptr = (nint)(&fixedDt);
			*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cmd);
			*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &isResim;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(byte*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		public BotPickUpItemSubroutine(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	public class CustomNpcFollowItemTargetSubroutine : SimulationSubroutine
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_npcBehaviour;

		private static readonly System.IntPtr NativeFieldInfoPtr_triggerTargetLost;

		private static readonly System.IntPtr NativeFieldInfoPtr_agent;

		private static readonly System.IntPtr NativeFieldInfoPtr_maxDistFromSelfSqr;

		private static readonly System.IntPtr NativeFieldInfoPtr_followDist;

		private static readonly System.IntPtr NativeFieldInfoPtr_followDistSqr;

		private static readonly System.IntPtr NativeFieldInfoPtr_followDistMarginSqr;

		private static readonly System.IntPtr NativeFieldInfoPtr_doPivotAroundTarget;

		private static readonly System.IntPtr NativeFieldInfoPtr_pivotAxisDir;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_CharacterBotBehaviour_Byte_Single_Single_Single_Boolean_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_OnExit_Public_Virtual_Void_Single_Command_Boolean_0;

		public unsafe CharacterBotBehaviour npcBehaviour
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_npcBehaviour);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharacterBotBehaviour>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_npcBehaviour)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)characterBotBehaviour));
			}
		}

		public unsafe byte triggerTargetLost
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_triggerTargetLost);
				return *(byte*)num;
			}
			set
			{
				*(byte*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_triggerTargetLost)) = b;
			}
		}

		public unsafe NavMeshAgent agent
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_agent);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<NavMeshAgent>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_agent)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)navMeshAgent));
			}
		}

		public unsafe float maxDistFromSelfSqr
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_maxDistFromSelfSqr);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_maxDistFromSelfSqr)) = num;
			}
		}

		public unsafe float followDist
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_followDist);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_followDist)) = num;
			}
		}

		public unsafe float followDistSqr
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_followDistSqr);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_followDistSqr)) = num;
			}
		}

		public unsafe float followDistMarginSqr
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_followDistMarginSqr);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_followDistMarginSqr)) = num;
			}
		}

		public unsafe bool doPivotAroundTarget
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_doPivotAroundTarget);
				return *(bool*)num;
			}
			set
			{
				*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_doPivotAroundTarget)) = flag;
			}
		}

		public unsafe int pivotAxisDir
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pivotAxisDir);
				return *(int*)num;
			}
			set
			{
				*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pivotAxisDir)) = num;
			}
		}

		static CustomNpcFollowItemTargetSubroutine()
		{
			Il2CppClassPointerStore<CustomNpcFollowItemTargetSubroutine>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "CustomNpcFollowItemTargetSubroutine");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CustomNpcFollowItemTargetSubroutine>.NativeClassPtr);
			NativeFieldInfoPtr_npcBehaviour = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomNpcFollowItemTargetSubroutine>.NativeClassPtr, "npcBehaviour");
			NativeFieldInfoPtr_triggerTargetLost = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomNpcFollowItemTargetSubroutine>.NativeClassPtr, "triggerTargetLost");
			NativeFieldInfoPtr_agent = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomNpcFollowItemTargetSubroutine>.NativeClassPtr, "agent");
			NativeFieldInfoPtr_maxDistFromSelfSqr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomNpcFollowItemTargetSubroutine>.NativeClassPtr, "maxDistFromSelfSqr");
			NativeFieldInfoPtr_followDist = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomNpcFollowItemTargetSubroutine>.NativeClassPtr, "followDist");
			NativeFieldInfoPtr_followDistSqr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomNpcFollowItemTargetSubroutine>.NativeClassPtr, "followDistSqr");
			NativeFieldInfoPtr_followDistMarginSqr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomNpcFollowItemTargetSubroutine>.NativeClassPtr, "followDistMarginSqr");
			NativeFieldInfoPtr_doPivotAroundTarget = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomNpcFollowItemTargetSubroutine>.NativeClassPtr, "doPivotAroundTarget");
			NativeFieldInfoPtr_pivotAxisDir = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomNpcFollowItemTargetSubroutine>.NativeClassPtr, "pivotAxisDir");
			NativeMethodInfoPtr__ctor_Public_Void_CharacterBotBehaviour_Byte_Single_Single_Single_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomNpcFollowItemTargetSubroutine>.NativeClassPtr, 100675547);
			NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomNpcFollowItemTargetSubroutine>.NativeClassPtr, 100675548);
			NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomNpcFollowItemTargetSubroutine>.NativeClassPtr, 100675549);
			NativeMethodInfoPtr_OnExit_Public_Virtual_Void_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomNpcFollowItemTargetSubroutine>.NativeClassPtr, 100675550);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 162938, XrefRangeEnd = 162940, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe CustomNpcFollowItemTargetSubroutine(CharacterBotBehaviour _npcBehaviour, byte _triggerTargetLost, float _maxDistFromSelf, float _followDist = 0f, float followDistMargin = 2f, bool _doPivotAroundTarget = false)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CustomNpcFollowItemTargetSubroutine>.NativeClassPtr))
		{
			System.IntPtr* ptr = stackalloc System.IntPtr[6];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_npcBehaviour);
			*(byte**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &_triggerTargetLost;
			*(float**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &_maxDistFromSelf;
			*(float**)((byte*)ptr + checked((nuint)3u * unchecked((nuint)sizeof(System.IntPtr)))) = &_followDist;
			*(float**)((byte*)ptr + checked((nuint)4u * unchecked((nuint)sizeof(System.IntPtr)))) = &followDistMargin;
			*(bool**)((byte*)ptr + checked((nuint)5u * unchecked((nuint)sizeof(System.IntPtr)))) = &_doPivotAroundTarget;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_CharacterBotBehaviour_Byte_Single_Single_Single_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 162940, XrefRangeEnd = 162942, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[3];
			*ptr = (nint)(&fixedDt);
			*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cmd);
			*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &isResim;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 162942, XrefRangeEnd = 162966, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe override byte OnTick(float fixedDt, Command cmd, bool isResim)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[3];
			*ptr = (nint)(&fixedDt);
			*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cmd);
			*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &isResim;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(byte*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 0, XrefRangeEnd = 0, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe override void OnExit(float fixedDt, Command cmd, bool isResim)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[3];
			*ptr = (nint)(&fixedDt);
			*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cmd);
			*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &isResim;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnExit_Public_Virtual_Void_Single_Command_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public CustomNpcFollowItemTargetSubroutine(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	public class BotWanderingPosSubroutine : NpcWanderingPosSubroutine
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_behaviour;

		private static readonly System.IntPtr NativeFieldInfoPtr_trigger;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_NpcBehaviour_Byte_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0;

		public new unsafe NpcBehaviour behaviour
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_behaviour);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<NpcBehaviour>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_behaviour)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)npcBehaviour));
			}
		}

		public unsafe byte trigger
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_trigger);
				return *(byte*)num;
			}
			set
			{
				*(byte*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_trigger)) = b;
			}
		}

		static BotWanderingPosSubroutine()
		{
			Il2CppClassPointerStore<BotWanderingPosSubroutine>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "BotWanderingPosSubroutine");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<BotWanderingPosSubroutine>.NativeClassPtr);
			NativeFieldInfoPtr_behaviour = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BotWanderingPosSubroutine>.NativeClassPtr, "behaviour");
			NativeFieldInfoPtr_trigger = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<BotWanderingPosSubroutine>.NativeClassPtr, "trigger");
			NativeMethodInfoPtr__ctor_Public_Void_NpcBehaviour_Byte_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BotWanderingPosSubroutine>.NativeClassPtr, 100675551);
			NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BotWanderingPosSubroutine>.NativeClassPtr, 100675552);
			NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<BotWanderingPosSubroutine>.NativeClassPtr, 100675553);
		}

		[CallerCount(3)]
		[CachedScanResults(RefRangeStart = 162967, RefRangeEnd = 162970, XrefRangeStart = 162966, XrefRangeEnd = 162967, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe BotWanderingPosSubroutine(NpcBehaviour _behaviour, byte _trigger)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<BotWanderingPosSubroutine>.NativeClassPtr))
		{
			System.IntPtr* ptr = stackalloc System.IntPtr[2];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_behaviour);
			*(byte**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &_trigger;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_NpcBehaviour_Byte_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 162970, XrefRangeEnd = 162971, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[3];
			*ptr = (nint)(&fixedDt);
			*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cmd);
			*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &isResim;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 33130, RefRangeEnd = 33131, XrefRangeStart = 33130, XrefRangeEnd = 33131, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe override byte OnTick(float fixedDt, Command cmd, bool isResim)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[3];
			*ptr = (nint)(&fixedDt);
			*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cmd);
			*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &isResim;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(byte*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		public BotWanderingPosSubroutine(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	public class CustomNpcDefensiveCombatSubroutine : SimulationSubroutine
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_behaviour;

		private static readonly System.IntPtr NativeFieldInfoPtr_triggerCombat;

		private static readonly System.IntPtr NativeFieldInfoPtr_firstFrame;

		private static readonly System.IntPtr NativeFieldInfoPtr_timer;

		private static readonly System.IntPtr NativeFieldInfoPtr_currentCombatChance;

		private static readonly System.IntPtr NativeFieldInfoPtr_minDistanceToCombatSqr;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_CharacterBotBehaviour_Byte_Single_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0;

		public unsafe CharacterBotBehaviour behaviour
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_behaviour);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharacterBotBehaviour>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_behaviour)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)characterBotBehaviour));
			}
		}

		public unsafe byte triggerCombat
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_triggerCombat);
				return *(byte*)num;
			}
			set
			{
				*(byte*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_triggerCombat)) = b;
			}
		}

		public unsafe bool firstFrame
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_firstFrame);
				return *(bool*)num;
			}
			set
			{
				*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_firstFrame)) = flag;
			}
		}

		public unsafe float timer
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_timer);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_timer)) = num;
			}
		}

		public unsafe float currentCombatChance
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentCombatChance);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentCombatChance)) = num;
			}
		}

		public unsafe float minDistanceToCombatSqr
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minDistanceToCombatSqr);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minDistanceToCombatSqr)) = num;
			}
		}

		static CustomNpcDefensiveCombatSubroutine()
		{
			Il2CppClassPointerStore<CustomNpcDefensiveCombatSubroutine>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "CustomNpcDefensiveCombatSubroutine");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CustomNpcDefensiveCombatSubroutine>.NativeClassPtr);
			NativeFieldInfoPtr_behaviour = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomNpcDefensiveCombatSubroutine>.NativeClassPtr, "behaviour");
			NativeFieldInfoPtr_triggerCombat = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomNpcDefensiveCombatSubroutine>.NativeClassPtr, "triggerCombat");
			NativeFieldInfoPtr_firstFrame = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomNpcDefensiveCombatSubroutine>.NativeClassPtr, "firstFrame");
			NativeFieldInfoPtr_timer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomNpcDefensiveCombatSubroutine>.NativeClassPtr, "timer");
			NativeFieldInfoPtr_currentCombatChance = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomNpcDefensiveCombatSubroutine>.NativeClassPtr, "currentCombatChance");
			NativeFieldInfoPtr_minDistanceToCombatSqr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomNpcDefensiveCombatSubroutine>.NativeClassPtr, "minDistanceToCombatSqr");
			NativeMethodInfoPtr__ctor_Public_Void_CharacterBotBehaviour_Byte_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomNpcDefensiveCombatSubroutine>.NativeClassPtr, 100675554);
			NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomNpcDefensiveCombatSubroutine>.NativeClassPtr, 100675555);
			NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomNpcDefensiveCombatSubroutine>.NativeClassPtr, 100675556);
		}

		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 162972, RefRangeEnd = 162973, XrefRangeStart = 162971, XrefRangeEnd = 162972, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe CustomNpcDefensiveCombatSubroutine(CharacterBotBehaviour _behaviour, byte _triggerCombat, float _minDistanceToCombat)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CustomNpcDefensiveCombatSubroutine>.NativeClassPtr))
		{
			System.IntPtr* ptr = stackalloc System.IntPtr[3];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_behaviour);
			*(byte**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &_triggerCombat;
			*(float**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &_minDistanceToCombat;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_CharacterBotBehaviour_Byte_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		public unsafe override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[3];
			*ptr = (nint)(&fixedDt);
			*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cmd);
			*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &isResim;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 162973, XrefRangeEnd = 162974, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe override byte OnTick(float fixedDt, Command cmd, bool isResim)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[3];
			*ptr = (nint)(&fixedDt);
			*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cmd);
			*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &isResim;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(byte*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		public CustomNpcDefensiveCombatSubroutine(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	public class CustomNpcOffensiveCombatSubroutine : SimulationSubroutine
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_behaviour;

		private static readonly System.IntPtr NativeFieldInfoPtr_triggerDefense;

		private static readonly System.IntPtr NativeFieldInfoPtr_firstFrame;

		private static readonly System.IntPtr NativeFieldInfoPtr_timer;

		private static readonly System.IntPtr NativeFieldInfoPtr_minDistanceToDefenseSqr;

		private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_CharacterBotBehaviour_Byte_Single_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0;

		private static readonly System.IntPtr NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0;

		public unsafe CharacterBotBehaviour behaviour
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_behaviour);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharacterBotBehaviour>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_behaviour)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)characterBotBehaviour));
			}
		}

		public unsafe byte triggerDefense
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_triggerDefense);
				return *(byte*)num;
			}
			set
			{
				*(byte*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_triggerDefense)) = b;
			}
		}

		public unsafe bool firstFrame
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_firstFrame);
				return *(bool*)num;
			}
			set
			{
				*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_firstFrame)) = flag;
			}
		}

		public unsafe float timer
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_timer);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_timer)) = num;
			}
		}

		public unsafe float minDistanceToDefenseSqr
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minDistanceToDefenseSqr);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minDistanceToDefenseSqr)) = num;
			}
		}

		static CustomNpcOffensiveCombatSubroutine()
		{
			Il2CppClassPointerStore<CustomNpcOffensiveCombatSubroutine>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "CustomNpcOffensiveCombatSubroutine");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CustomNpcOffensiveCombatSubroutine>.NativeClassPtr);
			NativeFieldInfoPtr_behaviour = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomNpcOffensiveCombatSubroutine>.NativeClassPtr, "behaviour");
			NativeFieldInfoPtr_triggerDefense = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomNpcOffensiveCombatSubroutine>.NativeClassPtr, "triggerDefense");
			NativeFieldInfoPtr_firstFrame = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomNpcOffensiveCombatSubroutine>.NativeClassPtr, "firstFrame");
			NativeFieldInfoPtr_timer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomNpcOffensiveCombatSubroutine>.NativeClassPtr, "timer");
			NativeFieldInfoPtr_minDistanceToDefenseSqr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomNpcOffensiveCombatSubroutine>.NativeClassPtr, "minDistanceToDefenseSqr");
			NativeMethodInfoPtr__ctor_Public_Void_CharacterBotBehaviour_Byte_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomNpcOffensiveCombatSubroutine>.NativeClassPtr, 100675557);
			NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomNpcOffensiveCombatSubroutine>.NativeClassPtr, 100675558);
			NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomNpcOffensiveCombatSubroutine>.NativeClassPtr, 100675559);
		}

		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 162975, RefRangeEnd = 162976, XrefRangeStart = 162974, XrefRangeEnd = 162975, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe CustomNpcOffensiveCombatSubroutine(CharacterBotBehaviour _behaviour, byte _triggerDefense, float _minDistanceToDefense)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CustomNpcOffensiveCombatSubroutine>.NativeClassPtr))
		{
			System.IntPtr* ptr = stackalloc System.IntPtr[3];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_behaviour);
			*(byte**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = &_triggerDefense;
			*(float**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &_minDistanceToDefense;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_CharacterBotBehaviour_Byte_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		public unsafe override void OnEnter(float fixedDt, Command cmd, bool isResim)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[3];
			*ptr = (nint)(&fixedDt);
			*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cmd);
			*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &isResim;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 162976, XrefRangeEnd = 162977, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe override byte OnTick(float fixedDt, Command cmd, bool isResim)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			System.IntPtr* ptr = stackalloc System.IntPtr[3];
			*ptr = (nint)(&fixedDt);
			*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cmd);
			*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &isResim;
			Unsafe.SkipInit(out System.IntPtr intPtr2);
			System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(byte*)IL2CPP.il2cpp_object_unbox(intPtr);
		}

		public CustomNpcOffensiveCombatSubroutine(System.IntPtr pointer)
			: base(pointer)
		{
		}
	}

	[ObfuscatedName("BAPBAP.Entities.CharacterBotBehaviour+<>c__DisplayClass88_0")]
	public sealed class __c__DisplayClass88_0 : Il2CppSystem.ValueType
	{
		private static readonly System.IntPtr NativeFieldInfoPtr_additiveAmount;

		private static readonly System.IntPtr NativeFieldInfoPtr___4__this;

		public unsafe float additiveAmount
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_additiveAmount);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_additiveAmount)) = num;
			}
		}

		public unsafe CharacterBotBehaviour __4__this
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr___4__this);
				System.IntPtr intPtr = *(System.IntPtr*)num;
				return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<CharacterBotBehaviour>(intPtr) : null;
			}
			set
			{
				System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr___4__this)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)characterBotBehaviour));
			}
		}

		static __c__DisplayClass88_0()
		{
			Il2CppClassPointerStore<__c__DisplayClass88_0>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "<>c__DisplayClass88_0");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<__c__DisplayClass88_0>.NativeClassPtr);
			NativeFieldInfoPtr_additiveAmount = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass88_0>.NativeClassPtr, "additiveAmount");
			NativeFieldInfoPtr___4__this = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<__c__DisplayClass88_0>.NativeClassPtr, "<>4__this");
		}

		public __c__DisplayClass88_0(System.IntPtr pointer)
			: base(pointer)
		{
		}

		public __c__DisplayClass88_0()
			: base(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<__c__DisplayClass88_0>.NativeClassPtr))
		{
		}
	}

	private static readonly System.IntPtr NativeFieldInfoPtr_applyDifficulty;

	private static readonly System.IntPtr NativeFieldInfoPtr_difficultyMultiplier;

	private static readonly System.IntPtr NativeFieldInfoPtr_targetLerpVelocityScaling;

	private static readonly System.IntPtr NativeFieldInfoPtr_damageToPlayersScaling;

	private static readonly System.IntPtr NativeFieldInfoPtr_aggresivenessScaling;

	private static readonly System.IntPtr NativeFieldInfoPtr_abilityReactionScaling;

	private static readonly System.IntPtr NativeFieldInfoPtr_futurePredictUnaccuracyScaling;

	private static readonly System.IntPtr NativeFieldInfoPtr_updateRateScaling;

	private static readonly System.IntPtr NativeFieldInfoPtr_randomSpreadScaling;

	private static readonly System.IntPtr NativeFieldInfoPtr_extraCdScaling;

	private static readonly System.IntPtr NativeFieldInfoPtr_zoneMoveCenterTickRate;

	private static readonly System.IntPtr NativeFieldInfoPtr_enemySpottedTickRate;

	private static readonly System.IntPtr NativeFieldInfoPtr_searchForLootTickRate;

	private static readonly System.IntPtr NativeFieldInfoPtr_pickUpItemTickRate;

	private static readonly System.IntPtr NativeFieldInfoPtr_tryHealTickRate;

	private static readonly System.IntPtr NativeFieldInfoPtr_wanderingTickRate;

	private static readonly System.IntPtr NativeFieldInfoPtr_keepDistToEnemyHealing;

	private static readonly System.IntPtr NativeFieldInfoPtr_chanceOfHealingByNormHp;

	private static readonly System.IntPtr NativeFieldInfoPtr_minDistToStartHeal;

	private static readonly System.IntPtr NativeFieldInfoPtr_minDistToStopHeal;

	private static readonly System.IntPtr NativeFieldInfoPtr_keepDistToEnemy;

	private static readonly System.IntPtr NativeFieldInfoPtr_aggresiveness;

	private static readonly System.IntPtr NativeFieldInfoPtr_defenseDistAdded;

	private static readonly System.IntPtr NativeFieldInfoPtr_defensiveUpdateRate;

	private static readonly System.IntPtr NativeFieldInfoPtr_offensiveUpdateRate;

	private static readonly System.IntPtr NativeFieldInfoPtr_abilityReactionFactor;

	private static readonly System.IntPtr NativeFieldInfoPtr_maxDistanceToTarget;

	private static readonly System.IntPtr NativeFieldInfoPtr_engageInCombatMinDist;

	private static readonly System.IntPtr NativeFieldInfoPtr_chanceOfFightingByNormHp;

	private static readonly System.IntPtr NativeFieldInfoPtr_fighNpcChancePowerLevel;

	private static readonly System.IntPtr NativeFieldInfoPtr_fightNpcChanceMult;

	private static readonly System.IntPtr NativeFieldInfoPtr_futurePredictMultiplier;

	private static readonly System.IntPtr NativeFieldInfoPtr_futurePredictUnaccuracy;

	private static readonly System.IntPtr NativeFieldInfoPtr_abilityLMB;

	private static readonly System.IntPtr NativeFieldInfoPtr_abilityQ;

	private static readonly System.IntPtr NativeFieldInfoPtr_abilitySpace;

	private static readonly System.IntPtr NativeFieldInfoPtr_abilityUlt;

	private static readonly System.IntPtr NativeFieldInfoPtr_consumable1;

	private static readonly System.IntPtr NativeFieldInfoPtr_score_idle;

	private static readonly System.IntPtr NativeFieldInfoPtr_EXT_TRIGGER_IDLE;

	private static readonly System.IntPtr NativeFieldInfoPtr_score_wandering;

	private static readonly System.IntPtr NativeFieldInfoPtr_EXT_TRIGGER_WANDERING;

	private static readonly System.IntPtr NativeFieldInfoPtr_score_move_zone_center;

	private static readonly System.IntPtr NativeFieldInfoPtr_EXT_TRIGGER_MOVE_ZONE_CENTER;

	private static readonly System.IntPtr NativeFieldInfoPtr_score_enemy_spotted;

	private static readonly System.IntPtr NativeFieldInfoPtr_EXT_TRIGGER_COMBAT_ENEMY;

	private static readonly System.IntPtr NativeFieldInfoPtr_score_enemy_search;

	private static readonly System.IntPtr NativeFieldInfoPtr_score_search_for_loot;

	private static readonly System.IntPtr NativeFieldInfoPtr_EXT_TRIGGER_SEARCH_LOOT;

	private static readonly System.IntPtr NativeFieldInfoPtr_score_heal;

	private static readonly System.IntPtr NativeFieldInfoPtr_EXT_TRIGGER_HEAL;

	private static readonly System.IntPtr NativeFieldInfoPtr_currentState;

	private static readonly System.IntPtr NativeFieldInfoPtr_nextDesiredState;

	private static readonly System.IntPtr NativeFieldInfoPtr_stateTrigger;

	private static readonly System.IntPtr NativeFieldInfoPtr_isAbleToTransition;

	private static readonly System.IntPtr NativeFieldInfoPtr_currentItemTarget;

	private static readonly System.IntPtr NativeFieldInfoPtr_minDistToStartHealSqr;

	private static readonly System.IntPtr NativeFieldInfoPtr_defenseKeepDistToEnemy;

	private static readonly System.IntPtr NativeFieldInfoPtr_engageInCombatMinDistSqr;

	private static readonly System.IntPtr NativeMethodInfoPtr_PreAwake_Public_Virtual_Void_EntityManager_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_OnTick_Public_Virtual_Void_Single_Command_Boolean_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_TrySetAggro_Public_Virtual_Void_Transform_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CalculateScores_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_EvaluateScoresAndSetNextState_Private_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_EvaluateScore_Private_Void_TransitionState_byref_TransitionState_byref_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CalculateScore_Wandering_Private_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CalculateScore_MoveZoneCenter_Private_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CalculateScore_EnemySearch_Private_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CalculateScore_EnemySpotted_Private_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CalculateScore_SearchForLoot_Private_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_CalculateScore_Heal_Private_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_TrySetFoundChar_Private_Void_EntityManager_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetNewState_Private_Void_BotStates_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_SetState_Private_Void_BotStates_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_GetTransitionTriggerState_Private_Byte_BotStates_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_IsPositionOutOfBRRing_Private_Boolean_Vector3_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_BotCanPickupItem_Private_Boolean_Item_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_InitializeDifficulty_Private_Void_Single_0;

	private static readonly System.IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Method_Private_Void_AbilityTriggerData_byref___c__DisplayClass88_0_PDM_0;

	private static readonly System.IntPtr NativeMethodInfoPtr_Weaved_Public_Virtual_Boolean_0;

	public unsafe bool applyDifficulty
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_applyDifficulty);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_applyDifficulty)) = flag;
		}
	}

	public unsafe float difficultyMultiplier
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_difficultyMultiplier);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_difficultyMultiplier)) = num;
		}
	}

	public unsafe float targetLerpVelocityScaling
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_targetLerpVelocityScaling);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_targetLerpVelocityScaling)) = num;
		}
	}

	public unsafe float damageToPlayersScaling
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_damageToPlayersScaling);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_damageToPlayersScaling)) = num;
		}
	}

	public unsafe float aggresivenessScaling
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_aggresivenessScaling);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_aggresivenessScaling)) = num;
		}
	}

	public unsafe float abilityReactionScaling
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_abilityReactionScaling);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_abilityReactionScaling)) = num;
		}
	}

	public unsafe float futurePredictUnaccuracyScaling
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_futurePredictUnaccuracyScaling);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_futurePredictUnaccuracyScaling)) = num;
		}
	}

	public unsafe float updateRateScaling
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_updateRateScaling);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_updateRateScaling)) = num;
		}
	}

	public unsafe float randomSpreadScaling
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_randomSpreadScaling);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_randomSpreadScaling)) = num;
		}
	}

	public unsafe float extraCdScaling
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_extraCdScaling);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_extraCdScaling)) = num;
		}
	}

	public unsafe int zoneMoveCenterTickRate
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_zoneMoveCenterTickRate);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_zoneMoveCenterTickRate)) = num;
		}
	}

	public unsafe int enemySpottedTickRate
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_enemySpottedTickRate);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_enemySpottedTickRate)) = num;
		}
	}

	public unsafe int searchForLootTickRate
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_searchForLootTickRate);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_searchForLootTickRate)) = num;
		}
	}

	public unsafe int pickUpItemTickRate
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pickUpItemTickRate);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_pickUpItemTickRate)) = num;
		}
	}

	public unsafe int tryHealTickRate
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tryHealTickRate);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_tryHealTickRate)) = num;
		}
	}

	public unsafe int wanderingTickRate
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wanderingTickRate);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_wanderingTickRate)) = num;
		}
	}

	public unsafe float keepDistToEnemyHealing
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_keepDistToEnemyHealing);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_keepDistToEnemyHealing)) = num;
		}
	}

	public unsafe AnimationCurve chanceOfHealingByNormHp
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_chanceOfHealingByNormHp);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AnimationCurve>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_chanceOfHealingByNormHp)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)animationCurve));
		}
	}

	public unsafe float minDistToStartHeal
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minDistToStartHeal);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minDistToStartHeal)) = num;
		}
	}

	public unsafe float minDistToStopHeal
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minDistToStopHeal);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minDistToStopHeal)) = num;
		}
	}

	public unsafe float keepDistToEnemy
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_keepDistToEnemy);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_keepDistToEnemy)) = num;
		}
	}

	public unsafe float aggresiveness
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_aggresiveness);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_aggresiveness)) = num;
		}
	}

	public unsafe float defenseDistAdded
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defenseDistAdded);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defenseDistAdded)) = num;
		}
	}

	public unsafe float defensiveUpdateRate
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defensiveUpdateRate);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defensiveUpdateRate)) = num;
		}
	}

	public unsafe float offensiveUpdateRate
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_offensiveUpdateRate);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_offensiveUpdateRate)) = num;
		}
	}

	public unsafe float abilityReactionFactor
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_abilityReactionFactor);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_abilityReactionFactor)) = num;
		}
	}

	public unsafe float maxDistanceToTarget
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_maxDistanceToTarget);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_maxDistanceToTarget)) = num;
		}
	}

	public unsafe float engageInCombatMinDist
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_engageInCombatMinDist);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_engageInCombatMinDist)) = num;
		}
	}

	public unsafe AnimationCurve chanceOfFightingByNormHp
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_chanceOfFightingByNormHp);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AnimationCurve>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_chanceOfFightingByNormHp)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)animationCurve));
		}
	}

	public unsafe AnimationCurve fighNpcChancePowerLevel
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fighNpcChancePowerLevel);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AnimationCurve>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fighNpcChancePowerLevel)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)animationCurve));
		}
	}

	public unsafe float fightNpcChanceMult
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fightNpcChanceMult);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_fightNpcChanceMult)) = num;
		}
	}

	public unsafe float futurePredictMultiplier
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_futurePredictMultiplier);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_futurePredictMultiplier)) = num;
		}
	}

	public unsafe float futurePredictUnaccuracy
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_futurePredictUnaccuracy);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_futurePredictUnaccuracy)) = num;
		}
	}

	public unsafe AbilityTriggerData abilityLMB
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_abilityLMB);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AbilityTriggerData>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_abilityLMB)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)abilityTriggerData));
		}
	}

	public unsafe AbilityTriggerData abilityQ
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_abilityQ);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AbilityTriggerData>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_abilityQ)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)abilityTriggerData));
		}
	}

	public unsafe AbilityTriggerData abilitySpace
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_abilitySpace);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AbilityTriggerData>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_abilitySpace)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)abilityTriggerData));
		}
	}

	public unsafe AbilityTriggerData abilityUlt
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_abilityUlt);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AbilityTriggerData>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_abilityUlt)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)abilityTriggerData));
		}
	}

	public unsafe AbilityTriggerData consumable1
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_consumable1);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<AbilityTriggerData>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_consumable1)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)abilityTriggerData));
		}
	}

	public unsafe TransitionState score_idle
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_score_idle);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TransitionState>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_score_idle)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)transitionState));
		}
	}

	public unsafe byte EXT_TRIGGER_IDLE
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EXT_TRIGGER_IDLE);
			return *(byte*)num;
		}
		set
		{
			*(byte*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EXT_TRIGGER_IDLE)) = b;
		}
	}

	public unsafe TransitionState score_wandering
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_score_wandering);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TransitionState>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_score_wandering)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)transitionState));
		}
	}

	public unsafe byte EXT_TRIGGER_WANDERING
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EXT_TRIGGER_WANDERING);
			return *(byte*)num;
		}
		set
		{
			*(byte*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EXT_TRIGGER_WANDERING)) = b;
		}
	}

	public unsafe TransitionState score_move_zone_center
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_score_move_zone_center);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TransitionState>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_score_move_zone_center)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)transitionState));
		}
	}

	public unsafe byte EXT_TRIGGER_MOVE_ZONE_CENTER
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EXT_TRIGGER_MOVE_ZONE_CENTER);
			return *(byte*)num;
		}
		set
		{
			*(byte*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EXT_TRIGGER_MOVE_ZONE_CENTER)) = b;
		}
	}

	public unsafe TransitionState score_enemy_spotted
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_score_enemy_spotted);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TransitionState>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_score_enemy_spotted)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)transitionState));
		}
	}

	public unsafe byte EXT_TRIGGER_COMBAT_ENEMY
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EXT_TRIGGER_COMBAT_ENEMY);
			return *(byte*)num;
		}
		set
		{
			*(byte*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EXT_TRIGGER_COMBAT_ENEMY)) = b;
		}
	}

	public unsafe TransitionState score_enemy_search
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_score_enemy_search);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TransitionState>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_score_enemy_search)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)transitionState));
		}
	}

	public unsafe TransitionState score_search_for_loot
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_score_search_for_loot);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TransitionState>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_score_search_for_loot)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)transitionState));
		}
	}

	public unsafe byte EXT_TRIGGER_SEARCH_LOOT
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EXT_TRIGGER_SEARCH_LOOT);
			return *(byte*)num;
		}
		set
		{
			*(byte*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EXT_TRIGGER_SEARCH_LOOT)) = b;
		}
	}

	public unsafe TransitionState score_heal
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_score_heal);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<TransitionState>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_score_heal)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)transitionState));
		}
	}

	public unsafe byte EXT_TRIGGER_HEAL
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EXT_TRIGGER_HEAL);
			return *(byte*)num;
		}
		set
		{
			*(byte*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_EXT_TRIGGER_HEAL)) = b;
		}
	}

	public unsafe BotStates currentState
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentState);
			return *(BotStates*)num;
		}
		set
		{
			*(BotStates*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentState)) = botStates;
		}
	}

	public unsafe BotStates nextDesiredState
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_nextDesiredState);
			return *(BotStates*)num;
		}
		set
		{
			*(BotStates*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_nextDesiredState)) = botStates;
		}
	}

	public unsafe byte stateTrigger
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_stateTrigger);
			return *(byte*)num;
		}
		set
		{
			*(byte*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_stateTrigger)) = b;
		}
	}

	public unsafe bool isAbleToTransition
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isAbleToTransition);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_isAbleToTransition)) = flag;
		}
	}

	public unsafe ItemObject currentItemTarget
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentItemTarget);
			System.IntPtr intPtr = *(System.IntPtr*)num;
			return (intPtr != (System.IntPtr)0) ? Il2CppObjectPool.Get<ItemObject>(intPtr) : null;
		}
		set
		{
			System.IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (System.IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentItemTarget)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)itemObject));
		}
	}

	public unsafe float minDistToStartHealSqr
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minDistToStartHealSqr);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_minDistToStartHealSqr)) = num;
		}
	}

	public unsafe float defenseKeepDistToEnemy
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defenseKeepDistToEnemy);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defenseKeepDistToEnemy)) = num;
		}
	}

	public unsafe float engageInCombatMinDistSqr
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_engageInCombatMinDistSqr);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_engageInCombatMinDistSqr)) = num;
		}
	}

	static CharacterBotBehaviour()
	{
		Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Entities", "CharacterBotBehaviour");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr);
		NativeFieldInfoPtr_applyDifficulty = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "applyDifficulty");
		NativeFieldInfoPtr_difficultyMultiplier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "difficultyMultiplier");
		NativeFieldInfoPtr_targetLerpVelocityScaling = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "targetLerpVelocityScaling");
		NativeFieldInfoPtr_damageToPlayersScaling = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "damageToPlayersScaling");
		NativeFieldInfoPtr_aggresivenessScaling = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "aggresivenessScaling");
		NativeFieldInfoPtr_abilityReactionScaling = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "abilityReactionScaling");
		NativeFieldInfoPtr_futurePredictUnaccuracyScaling = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "futurePredictUnaccuracyScaling");
		NativeFieldInfoPtr_updateRateScaling = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "updateRateScaling");
		NativeFieldInfoPtr_randomSpreadScaling = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "randomSpreadScaling");
		NativeFieldInfoPtr_extraCdScaling = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "extraCdScaling");
		NativeFieldInfoPtr_zoneMoveCenterTickRate = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "zoneMoveCenterTickRate");
		NativeFieldInfoPtr_enemySpottedTickRate = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "enemySpottedTickRate");
		NativeFieldInfoPtr_searchForLootTickRate = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "searchForLootTickRate");
		NativeFieldInfoPtr_pickUpItemTickRate = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "pickUpItemTickRate");
		NativeFieldInfoPtr_tryHealTickRate = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "tryHealTickRate");
		NativeFieldInfoPtr_wanderingTickRate = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "wanderingTickRate");
		NativeFieldInfoPtr_keepDistToEnemyHealing = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "keepDistToEnemyHealing");
		NativeFieldInfoPtr_chanceOfHealingByNormHp = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "chanceOfHealingByNormHp");
		NativeFieldInfoPtr_minDistToStartHeal = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "minDistToStartHeal");
		NativeFieldInfoPtr_minDistToStopHeal = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "minDistToStopHeal");
		NativeFieldInfoPtr_keepDistToEnemy = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "keepDistToEnemy");
		NativeFieldInfoPtr_aggresiveness = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "aggresiveness");
		NativeFieldInfoPtr_defenseDistAdded = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "defenseDistAdded");
		NativeFieldInfoPtr_defensiveUpdateRate = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "defensiveUpdateRate");
		NativeFieldInfoPtr_offensiveUpdateRate = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "offensiveUpdateRate");
		NativeFieldInfoPtr_abilityReactionFactor = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "abilityReactionFactor");
		NativeFieldInfoPtr_maxDistanceToTarget = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "maxDistanceToTarget");
		NativeFieldInfoPtr_engageInCombatMinDist = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "engageInCombatMinDist");
		NativeFieldInfoPtr_chanceOfFightingByNormHp = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "chanceOfFightingByNormHp");
		NativeFieldInfoPtr_fighNpcChancePowerLevel = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "fighNpcChancePowerLevel");
		NativeFieldInfoPtr_fightNpcChanceMult = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "fightNpcChanceMult");
		NativeFieldInfoPtr_futurePredictMultiplier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "futurePredictMultiplier");
		NativeFieldInfoPtr_futurePredictUnaccuracy = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "futurePredictUnaccuracy");
		NativeFieldInfoPtr_abilityLMB = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "abilityLMB");
		NativeFieldInfoPtr_abilityQ = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "abilityQ");
		NativeFieldInfoPtr_abilitySpace = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "abilitySpace");
		NativeFieldInfoPtr_abilityUlt = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "abilityUlt");
		NativeFieldInfoPtr_consumable1 = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "consumable1");
		NativeFieldInfoPtr_score_idle = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "score_idle");
		NativeFieldInfoPtr_EXT_TRIGGER_IDLE = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "EXT_TRIGGER_IDLE");
		NativeFieldInfoPtr_score_wandering = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "score_wandering");
		NativeFieldInfoPtr_EXT_TRIGGER_WANDERING = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "EXT_TRIGGER_WANDERING");
		NativeFieldInfoPtr_score_move_zone_center = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "score_move_zone_center");
		NativeFieldInfoPtr_EXT_TRIGGER_MOVE_ZONE_CENTER = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "EXT_TRIGGER_MOVE_ZONE_CENTER");
		NativeFieldInfoPtr_score_enemy_spotted = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "score_enemy_spotted");
		NativeFieldInfoPtr_EXT_TRIGGER_COMBAT_ENEMY = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "EXT_TRIGGER_COMBAT_ENEMY");
		NativeFieldInfoPtr_score_enemy_search = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "score_enemy_search");
		NativeFieldInfoPtr_score_search_for_loot = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "score_search_for_loot");
		NativeFieldInfoPtr_EXT_TRIGGER_SEARCH_LOOT = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "EXT_TRIGGER_SEARCH_LOOT");
		NativeFieldInfoPtr_score_heal = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "score_heal");
		NativeFieldInfoPtr_EXT_TRIGGER_HEAL = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "EXT_TRIGGER_HEAL");
		NativeFieldInfoPtr_currentState = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "currentState");
		NativeFieldInfoPtr_nextDesiredState = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "nextDesiredState");
		NativeFieldInfoPtr_stateTrigger = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "stateTrigger");
		NativeFieldInfoPtr_isAbleToTransition = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "isAbleToTransition");
		NativeFieldInfoPtr_currentItemTarget = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "currentItemTarget");
		NativeFieldInfoPtr_minDistToStartHealSqr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "minDistToStartHealSqr");
		NativeFieldInfoPtr_defenseKeepDistToEnemy = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "defenseKeepDistToEnemy");
		NativeFieldInfoPtr_engageInCombatMinDistSqr = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, "engageInCombatMinDistSqr");
		NativeMethodInfoPtr_PreAwake_Public_Virtual_Void_EntityManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, 100675510);
		NativeMethodInfoPtr_OnTick_Public_Virtual_Void_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, 100675511);
		NativeMethodInfoPtr_TrySetAggro_Public_Virtual_Void_Transform_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, 100675512);
		NativeMethodInfoPtr_CalculateScores_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, 100675513);
		NativeMethodInfoPtr_EvaluateScoresAndSetNextState_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, 100675514);
		NativeMethodInfoPtr_EvaluateScore_Private_Void_TransitionState_byref_TransitionState_byref_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, 100675515);
		NativeMethodInfoPtr_CalculateScore_Wandering_Private_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, 100675516);
		NativeMethodInfoPtr_CalculateScore_MoveZoneCenter_Private_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, 100675517);
		NativeMethodInfoPtr_CalculateScore_EnemySearch_Private_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, 100675518);
		NativeMethodInfoPtr_CalculateScore_EnemySpotted_Private_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, 100675519);
		NativeMethodInfoPtr_CalculateScore_SearchForLoot_Private_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, 100675520);
		NativeMethodInfoPtr_CalculateScore_Heal_Private_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, 100675521);
		NativeMethodInfoPtr_TrySetFoundChar_Private_Void_EntityManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, 100675522);
		NativeMethodInfoPtr_SetNewState_Private_Void_BotStates_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, 100675523);
		NativeMethodInfoPtr_SetState_Private_Void_BotStates_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, 100675524);
		NativeMethodInfoPtr_GetTransitionTriggerState_Private_Byte_BotStates_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, 100675525);
		NativeMethodInfoPtr_IsPositionOutOfBRRing_Private_Boolean_Vector3_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, 100675526);
		NativeMethodInfoPtr_BotCanPickupItem_Private_Boolean_Item_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, 100675527);
		NativeMethodInfoPtr_InitializeDifficulty_Private_Void_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, 100675528);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, 100675529);
		NativeMethodInfoPtr_Method_Private_Void_AbilityTriggerData_byref___c__DisplayClass88_0_PDM_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, 100675530);
		NativeMethodInfoPtr_Weaved_Public_Virtual_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr, 100675531);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 162977, XrefRangeEnd = 163201, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void PreAwake(EntityManager e)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)e);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_PreAwake_Public_Virtual_Void_EntityManager_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 163201, XrefRangeEnd = 163206, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void OnTick(float fixedDt, Command cmd, bool isResim)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = (nint)(&fixedDt);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)cmd);
		*(bool**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = &isResim;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnTick_Public_Virtual_Void_Single_Command_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 163206, XrefRangeEnd = 163207, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void TrySetAggro(Transform target)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)target);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_TrySetAggro_Public_Virtual_Void_Transform_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 163227, RefRangeEnd = 163228, XrefRangeStart = 163207, XrefRangeEnd = 163227, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void CalculateScores()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CalculateScores_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	public unsafe void EvaluateScoresAndSetNextState()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_EvaluateScoresAndSetNextState_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	public unsafe void EvaluateScore(TransitionState stateToEvaluate, ref TransitionState bestTransition, ref float bestScore)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)stateToEvaluate);
		byte* num = (byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)));
		System.IntPtr intPtr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)bestTransition);
		*(System.IntPtr**)num = &intPtr;
		*(void**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(System.IntPtr)))) = Unsafe.AsPointer(ref bestScore);
		Unsafe.SkipInit(out System.IntPtr intPtr3);
		System.IntPtr intPtr2 = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_EvaluateScore_Private_Void_TransitionState_byref_TransitionState_byref_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr3);
		Il2CppException.RaiseExceptionIfNecessary(intPtr3);
		System.IntPtr intPtr4 = intPtr;
		bestTransition = ((intPtr4 == (System.IntPtr)0) ? null : new TransitionState(intPtr4));
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 163228, XrefRangeEnd = 163230, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe float CalculateScore_Wandering()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CalculateScore_Wandering_Private_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(float*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 163230, XrefRangeEnd = 163235, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe float CalculateScore_MoveZoneCenter()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CalculateScore_MoveZoneCenter_Private_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(float*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	public unsafe float CalculateScore_EnemySearch()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CalculateScore_EnemySearch_Private_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(float*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 163249, RefRangeEnd = 163250, XrefRangeStart = 163235, XrefRangeEnd = 163249, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe float CalculateScore_EnemySpotted()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CalculateScore_EnemySpotted_Private_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(float*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 163262, RefRangeEnd = 163263, XrefRangeStart = 163250, XrefRangeEnd = 163262, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe float CalculateScore_SearchForLoot()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CalculateScore_SearchForLoot_Private_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(float*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 163263, XrefRangeEnd = 163267, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe float CalculateScore_Heal()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_CalculateScore_Heal_Private_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(float*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 163280, RefRangeEnd = 163281, XrefRangeStart = 163267, XrefRangeEnd = 163280, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void TrySetFoundChar(EntityManager foundChar)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)foundChar);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_TrySetFoundChar_Private_Void_EntityManager_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 163281, XrefRangeEnd = 163288, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetNewState(BotStates newState)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&newState);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetNewState_Private_Void_BotStates_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	public unsafe void SetState(BotStates newState)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&newState);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetState_Private_Void_BotStates_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	public unsafe byte GetTransitionTriggerState(BotStates state)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&state);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetTransitionTriggerState_Private_Byte_BotStates_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(byte*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 163297, RefRangeEnd = 163298, XrefRangeStart = 163288, XrefRangeEnd = 163297, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe bool IsPositionOutOfBRRing(Vector3 pos)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&pos);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_IsPositionOutOfBRRing_Private_Boolean_Vector3_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 163301, RefRangeEnd = 163303, XrefRangeStart = 163298, XrefRangeEnd = 163301, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe bool BotCanPickupItem(Item item)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)item);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_BotCanPickupItem_Private_Boolean_Item_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 163306, RefRangeEnd = 163307, XrefRangeStart = 163303, XrefRangeEnd = 163306, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void InitializeDifficulty(float multiplier)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[1];
		*ptr = (nint)(&multiplier);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_InitializeDifficulty_Private_Void_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 163307, XrefRangeEnd = 163325, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe CharacterBotBehaviour()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CharacterBotBehaviour>.NativeClassPtr))
	{
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	public unsafe void Method_Private_Void_AbilityTriggerData_byref___c__DisplayClass88_0_PDM_0(AbilityTriggerData ab, ref __c__DisplayClass88_0 A_2)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = stackalloc System.IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)ab);
		*(System.IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(System.IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)A_2);
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Method_Private_Void_AbilityTriggerData_byref___c__DisplayClass88_0_PDM_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(24)]
	[CachedScanResults(RefRangeStart = 28750, RefRangeEnd = 28774, XrefRangeStart = 28750, XrefRangeEnd = 28774, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override bool Weaved()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		System.IntPtr* ptr = null;
		Unsafe.SkipInit(out System.IntPtr intPtr2);
		System.IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_Weaved_Public_Virtual_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	public CharacterBotBehaviour(System.IntPtr pointer)
		: base(pointer)
	{
	}
}
