using System;
using System.Runtime.CompilerServices;
using Il2CppBAPBAP.Local;
using Il2CppBAPBAP.Network;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppMirror;
using Il2CppSystem.Collections.Generic;
using Il2CppSystem.Text;
using UnityEngine;

namespace Il2CppBAPBAP.Entities;

public class NpcRecoilAbility : Ability
{
	public class CustomShootSubroutine : SimulationSubroutine
	{
		private static readonly IntPtr NativeFieldInfoPtr_ability;

		private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_NpcRecoilAbility_0;

		private static readonly IntPtr NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0;

		public unsafe NpcRecoilAbility ability
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ability);
				IntPtr intPtr = *(IntPtr*)num;
				return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<NpcRecoilAbility>(intPtr) : null;
			}
			set
			{
				IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ability)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)npcRecoilAbility));
			}
		}

		static CustomShootSubroutine()
		{
			Il2CppClassPointerStore<CustomShootSubroutine>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, "CustomShootSubroutine");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CustomShootSubroutine>.NativeClassPtr);
			NativeFieldInfoPtr_ability = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomShootSubroutine>.NativeClassPtr, "ability");
			NativeMethodInfoPtr__ctor_Public_Void_NpcRecoilAbility_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomShootSubroutine>.NativeClassPtr, 100674123);
			NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomShootSubroutine>.NativeClassPtr, 100674124);
		}

		[CallerCount(534)]
		[CachedScanResults(RefRangeStart = 124041, RefRangeEnd = 124575, XrefRangeStart = 124041, XrefRangeEnd = 124575, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe CustomShootSubroutine(NpcRecoilAbility _ability)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CustomShootSubroutine>.NativeClassPtr))
		{
			IntPtr* ptr = stackalloc IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_ability);
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_NpcRecoilAbility_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 142247, XrefRangeEnd = 142257, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
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

		public CustomShootSubroutine(IntPtr pointer)
			: base(pointer)
		{
		}
	}

	public class CustomVisibleIndicatorSubroutine : SimulationSubroutine
	{
		private static readonly IntPtr NativeFieldInfoPtr_ability;

		private static readonly IntPtr NativeFieldInfoPtr_setEnabled;

		private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_NpcRecoilAbility_Boolean_0;

		private static readonly IntPtr NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0;

		public unsafe NpcRecoilAbility ability
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ability);
				IntPtr intPtr = *(IntPtr*)num;
				return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<NpcRecoilAbility>(intPtr) : null;
			}
			set
			{
				IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ability)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)npcRecoilAbility));
			}
		}

		public unsafe bool setEnabled
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_setEnabled);
				return *(bool*)num;
			}
			set
			{
				*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_setEnabled)) = flag;
			}
		}

		static CustomVisibleIndicatorSubroutine()
		{
			Il2CppClassPointerStore<CustomVisibleIndicatorSubroutine>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, "CustomVisibleIndicatorSubroutine");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CustomVisibleIndicatorSubroutine>.NativeClassPtr);
			NativeFieldInfoPtr_ability = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomVisibleIndicatorSubroutine>.NativeClassPtr, "ability");
			NativeFieldInfoPtr_setEnabled = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomVisibleIndicatorSubroutine>.NativeClassPtr, "setEnabled");
			NativeMethodInfoPtr__ctor_Public_Void_NpcRecoilAbility_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomVisibleIndicatorSubroutine>.NativeClassPtr, 100674125);
			NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomVisibleIndicatorSubroutine>.NativeClassPtr, 100674126);
		}

		[CallerCount(35)]
		[CachedScanResults(RefRangeStart = 123824, RefRangeEnd = 123859, XrefRangeStart = 123824, XrefRangeEnd = 123859, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe CustomVisibleIndicatorSubroutine(NpcRecoilAbility _ability, bool _setEnabled)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CustomVisibleIndicatorSubroutine>.NativeClassPtr))
		{
			IntPtr* ptr = stackalloc IntPtr[2];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_ability);
			*(bool**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &_setEnabled;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_NpcRecoilAbility_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 142257, XrefRangeEnd = 142267, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
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

		public CustomVisibleIndicatorSubroutine(IntPtr pointer)
			: base(pointer)
		{
		}
	}

	public class CustomJumpSubroutine : SimulationSubroutine
	{
		private static readonly IntPtr NativeFieldInfoPtr_ability;

		private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_NpcRecoilAbility_0;

		private static readonly IntPtr NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0;

		public unsafe NpcRecoilAbility ability
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ability);
				IntPtr intPtr = *(IntPtr*)num;
				return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<NpcRecoilAbility>(intPtr) : null;
			}
			set
			{
				IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ability)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)npcRecoilAbility));
			}
		}

		static CustomJumpSubroutine()
		{
			Il2CppClassPointerStore<CustomJumpSubroutine>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, "CustomJumpSubroutine");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CustomJumpSubroutine>.NativeClassPtr);
			NativeFieldInfoPtr_ability = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomJumpSubroutine>.NativeClassPtr, "ability");
			NativeMethodInfoPtr__ctor_Public_Void_NpcRecoilAbility_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomJumpSubroutine>.NativeClassPtr, 100674127);
			NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomJumpSubroutine>.NativeClassPtr, 100674128);
		}

		[CallerCount(534)]
		[CachedScanResults(RefRangeStart = 124041, RefRangeEnd = 124575, XrefRangeStart = 124041, XrefRangeEnd = 124575, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe CustomJumpSubroutine(NpcRecoilAbility _ability)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CustomJumpSubroutine>.NativeClassPtr))
		{
			IntPtr* ptr = stackalloc IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_ability);
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_NpcRecoilAbility_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 142267, XrefRangeEnd = 142271, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
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

		public CustomJumpSubroutine(IntPtr pointer)
			: base(pointer)
		{
		}
	}

	public class CustomFloatSubroutine : NetworkedSimulationSubroutine
	{
		private static readonly IntPtr NativeFieldInfoPtr_ability;

		private static readonly IntPtr NativeFieldInfoPtr_trigger;

		private static readonly IntPtr NativeFieldInfoPtr_jumpTime;

		private static readonly IntPtr NativeFieldInfoPtr_timeElapsed;

		private static readonly IntPtr NativeFieldInfoPtr_originalPos;

		private static readonly IntPtr NativeFieldInfoPtr_landingPos;

		private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_NpcRecoilAbility_Byte_Single_0;

		private static readonly IntPtr NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0;

		private static readonly IntPtr NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0;

		private static readonly IntPtr NativeMethodInfoPtr_OnExit_Public_Virtual_Void_Single_Command_Boolean_0;

		private static readonly IntPtr NativeMethodInfoPtr_OnNetDeserialize_Public_Virtual_Void_NetworkReader_0;

		private static readonly IntPtr NativeMethodInfoPtr_OnNetSerialize_Public_Virtual_Void_NetworkWriter_0;

		private static readonly IntPtr NativeMethodInfoPtr_OnNetDebugCompare_Public_Virtual_Boolean_NetworkReader_0;

		private static readonly IntPtr NativeMethodInfoPtr_OnNetDebugLog_Public_Virtual_Void_StringBuilder_0;

		public unsafe NpcRecoilAbility ability
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ability);
				IntPtr intPtr = *(IntPtr*)num;
				return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<NpcRecoilAbility>(intPtr) : null;
			}
			set
			{
				IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
				IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ability)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)npcRecoilAbility));
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

		public unsafe float jumpTime
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_jumpTime);
				return *(float*)num;
			}
			set
			{
				*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_jumpTime)) = num;
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

		public unsafe Vector3 originalPos
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_originalPos);
				return *(Vector3*)num;
			}
			set
			{
				*(Vector3*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_originalPos)) = vector;
			}
		}

		public unsafe Vector3 landingPos
		{
			get
			{
				nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_landingPos);
				return *(Vector3*)num;
			}
			set
			{
				*(Vector3*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_landingPos)) = vector;
			}
		}

		static CustomFloatSubroutine()
		{
			Il2CppClassPointerStore<CustomFloatSubroutine>.NativeClassPtr = IL2CPP.GetIl2CppNestedType(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, "CustomFloatSubroutine");
			IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<CustomFloatSubroutine>.NativeClassPtr);
			NativeFieldInfoPtr_ability = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomFloatSubroutine>.NativeClassPtr, "ability");
			NativeFieldInfoPtr_trigger = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomFloatSubroutine>.NativeClassPtr, "trigger");
			NativeFieldInfoPtr_jumpTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomFloatSubroutine>.NativeClassPtr, "jumpTime");
			NativeFieldInfoPtr_timeElapsed = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomFloatSubroutine>.NativeClassPtr, "timeElapsed");
			NativeFieldInfoPtr_originalPos = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomFloatSubroutine>.NativeClassPtr, "originalPos");
			NativeFieldInfoPtr_landingPos = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<CustomFloatSubroutine>.NativeClassPtr, "landingPos");
			NativeMethodInfoPtr__ctor_Public_Void_NpcRecoilAbility_Byte_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomFloatSubroutine>.NativeClassPtr, 100674129);
			NativeMethodInfoPtr_OnEnter_Public_Virtual_Void_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomFloatSubroutine>.NativeClassPtr, 100674130);
			NativeMethodInfoPtr_OnTick_Public_Virtual_Byte_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomFloatSubroutine>.NativeClassPtr, 100674131);
			NativeMethodInfoPtr_OnExit_Public_Virtual_Void_Single_Command_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomFloatSubroutine>.NativeClassPtr, 100674132);
			NativeMethodInfoPtr_OnNetDeserialize_Public_Virtual_Void_NetworkReader_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomFloatSubroutine>.NativeClassPtr, 100674133);
			NativeMethodInfoPtr_OnNetSerialize_Public_Virtual_Void_NetworkWriter_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomFloatSubroutine>.NativeClassPtr, 100674134);
			NativeMethodInfoPtr_OnNetDebugCompare_Public_Virtual_Boolean_NetworkReader_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomFloatSubroutine>.NativeClassPtr, 100674135);
			NativeMethodInfoPtr_OnNetDebugLog_Public_Virtual_Void_StringBuilder_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<CustomFloatSubroutine>.NativeClassPtr, 100674136);
		}

		[CallerCount(121)]
		[CachedScanResults(RefRangeStart = 123678, RefRangeEnd = 123799, XrefRangeStart = 123678, XrefRangeEnd = 123799, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe CustomFloatSubroutine(NpcRecoilAbility _ability, byte _trigger, float _jumpTime)
			: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<CustomFloatSubroutine>.NativeClassPtr))
		{
			IntPtr* ptr = stackalloc IntPtr[3];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_ability);
			*(byte**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &_trigger;
			*(float**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = &_jumpTime;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_NpcRecoilAbility_Byte_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 142271, XrefRangeEnd = 142280, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
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
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 142280, XrefRangeEnd = 142288, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
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
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 142288, XrefRangeEnd = 142290, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
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
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 142290, XrefRangeEnd = 142304, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		public unsafe override void OnNetDebugLog(StringBuilder sb)
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = stackalloc IntPtr[1];
			*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)sb);
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnNetDebugLog_Public_Virtual_Void_StringBuilder_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}

		public CustomFloatSubroutine(IntPtr pointer)
			: base(pointer)
		{
		}
	}

	private static readonly IntPtr NativeFieldInfoPtr_spellPrefab;

	private static readonly IntPtr NativeFieldInfoPtr_firingPoint;

	private static readonly IntPtr NativeFieldInfoPtr_castMotionLockType;

	private static readonly IntPtr NativeFieldInfoPtr_castRotationLockType;

	private static readonly IntPtr NativeFieldInfoPtr_jumpRotationLockType;

	private static readonly IntPtr NativeFieldInfoPtr_applyAtkSpeedMultiplier;

	private static readonly IntPtr NativeFieldInfoPtr_applyCooldownMultiplier;

	private static readonly IntPtr NativeFieldInfoPtr_inputType;

	private static readonly IntPtr NativeFieldInfoPtr_numProjectiles;

	private static readonly IntPtr NativeFieldInfoPtr_angleSpread;

	private static readonly IntPtr NativeFieldInfoPtr_visibleIndicatorPrefab;

	private static readonly IntPtr NativeFieldInfoPtr_indicatorHalfScale;

	private static readonly IntPtr NativeFieldInfoPtr_damage;

	private static readonly IntPtr NativeFieldInfoPtr_damageScaling;

	private static readonly IntPtr NativeFieldInfoPtr_speed;

	private static readonly IntPtr NativeFieldInfoPtr_ttl;

	private static readonly IntPtr NativeFieldInfoPtr_statusEffects;

	private static readonly IntPtr NativeFieldInfoPtr_castingTime;

	private static readonly IntPtr NativeFieldInfoPtr_jumpTime;

	private static readonly IntPtr NativeFieldInfoPtr_floatTime;

	private static readonly IntPtr NativeFieldInfoPtr_recoveryTime;

	private static readonly IntPtr NativeFieldInfoPtr_baseCooldownTime;

	private static readonly IntPtr NativeFieldInfoPtr_jumpLerpCurve;

	private static readonly IntPtr NativeFieldInfoPtr_baseShadowAlphaCurve;

	private static readonly IntPtr NativeFieldInfoPtr_jumpDistance;

	private static readonly IntPtr NativeFieldInfoPtr_jumpRadiusCheck;

	private static readonly IntPtr NativeFieldInfoPtr_camKickPower;

	private static readonly IntPtr NativeFieldInfoPtr_vfxCastPrefab;

	private static readonly IntPtr NativeFieldInfoPtr_vfxJumpPrefab;

	private static readonly IntPtr NativeFieldInfoPtr_vfxLandPrefab;

	private static readonly IntPtr NativeFieldInfoPtr_sfxCast;

	private static readonly IntPtr NativeFieldInfoPtr_animLayer;

	private static readonly IntPtr NativeFieldInfoPtr_npcBehaviour;

	private static readonly IntPtr NativeFieldInfoPtr_currentIndicatorObj;

	private static readonly IntPtr NativeFieldInfoPtr_targetDir;

	private static readonly IntPtr NativeFieldInfoPtr_charsToHurt;

	private static readonly IntPtr NativeMethodInfoPtr_PreAwake_Public_Virtual_Void_EntityManager_0;

	private static readonly IntPtr NativeMethodInfoPtr_Shoot_Private_Void_Vector3_0;

	private static readonly IntPtr NativeMethodInfoPtr_ShootProjectile_Private_Void_Vector3_0;

	private static readonly IntPtr NativeMethodInfoPtr_OnTargetHit_Public_Virtual_Void_EntityManager_HitboxBase_0;

	private static readonly IntPtr NativeMethodInfoPtr_RpcSpawnVisibleIndicator_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_RpcDestroyVisibleIndicator_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_Weaved_Public_Virtual_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_UserCode_RpcSpawnVisibleIndicator_Protected_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_InvokeUserCode_RpcSpawnVisibleIndicator_Protected_Static_Void_NetworkBehaviour_NetworkReader_NetworkConnectionToClient_0;

	private static readonly IntPtr NativeMethodInfoPtr_UserCode_RpcDestroyVisibleIndicator_Protected_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_InvokeUserCode_RpcDestroyVisibleIndicator_Protected_Static_Void_NetworkBehaviour_NetworkReader_NetworkConnectionToClient_0;

	public unsafe GameObject spellPrefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spellPrefab);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_spellPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe Transform firingPoint
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_firingPoint);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Transform>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_firingPoint)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)transform));
		}
	}

	public unsafe MotionLockType castMotionLockType
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castMotionLockType);
			return *(MotionLockType*)num;
		}
		set
		{
			*(MotionLockType*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castMotionLockType)) = motionLockType;
		}
	}

	public unsafe RotationLockType castRotationLockType
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castRotationLockType);
			return *(RotationLockType*)num;
		}
		set
		{
			*(RotationLockType*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castRotationLockType)) = rotationLockType;
		}
	}

	public unsafe RotationLockType jumpRotationLockType
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_jumpRotationLockType);
			return *(RotationLockType*)num;
		}
		set
		{
			*(RotationLockType*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_jumpRotationLockType)) = rotationLockType;
		}
	}

	public unsafe bool applyAtkSpeedMultiplier
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_applyAtkSpeedMultiplier);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_applyAtkSpeedMultiplier)) = flag;
		}
	}

	public unsafe bool applyCooldownMultiplier
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_applyCooldownMultiplier);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_applyCooldownMultiplier)) = flag;
		}
	}

	public unsafe InputType inputType
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inputType);
			return *(InputType*)num;
		}
		set
		{
			*(InputType*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inputType)) = inputType;
		}
	}

	public unsafe int numProjectiles
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_numProjectiles);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_numProjectiles)) = num;
		}
	}

	public unsafe float angleSpread
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_angleSpread);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_angleSpread)) = num;
		}
	}

	public unsafe GameObject visibleIndicatorPrefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_visibleIndicatorPrefab);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_visibleIndicatorPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe Vector2 indicatorHalfScale
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_indicatorHalfScale);
			return *(Vector2*)num;
		}
		set
		{
			*(Vector2*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_indicatorHalfScale)) = vector;
		}
	}

	public unsafe int damage
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_damage);
			return *(int*)num;
		}
		set
		{
			*(int*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_damage)) = num;
		}
	}

	public unsafe float damageScaling
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_damageScaling);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_damageScaling)) = num;
		}
	}

	public unsafe float speed
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_speed);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_speed)) = num;
		}
	}

	public unsafe float ttl
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ttl);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_ttl)) = num;
		}
	}

	public unsafe List<StatusEffectInfo> statusEffects
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_statusEffects);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<List<StatusEffectInfo>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_statusEffects)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	public unsafe float castingTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castingTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_castingTime)) = num;
		}
	}

	public unsafe float jumpTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_jumpTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_jumpTime)) = num;
		}
	}

	public unsafe float floatTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_floatTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_floatTime)) = num;
		}
	}

	public unsafe float recoveryTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_recoveryTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_recoveryTime)) = num;
		}
	}

	public unsafe float baseCooldownTime
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_baseCooldownTime);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_baseCooldownTime)) = num;
		}
	}

	public unsafe AnimationCurve jumpLerpCurve
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_jumpLerpCurve);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<AnimationCurve>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_jumpLerpCurve)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)animationCurve));
		}
	}

	public unsafe AnimationCurve baseShadowAlphaCurve
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_baseShadowAlphaCurve);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<AnimationCurve>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_baseShadowAlphaCurve)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)animationCurve));
		}
	}

	public unsafe float jumpDistance
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_jumpDistance);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_jumpDistance)) = num;
		}
	}

	public unsafe float jumpRadiusCheck
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_jumpRadiusCheck);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_jumpRadiusCheck)) = num;
		}
	}

	public unsafe float camKickPower
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_camKickPower);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_camKickPower)) = num;
		}
	}

	public unsafe GameObject vfxCastPrefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vfxCastPrefab);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vfxCastPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe GameObject vfxJumpPrefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vfxJumpPrefab);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vfxJumpPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe GameObject vfxLandPrefab
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vfxLandPrefab);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_vfxLandPrefab)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe AudioClipData sfxCast
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sfxCast);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<AudioClipData>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_sfxCast)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)audioClipData));
		}
	}

	public unsafe AnimLayerIndices animLayer
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_animLayer);
			return *(AnimLayerIndices*)num;
		}
		set
		{
			*(AnimLayerIndices*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_animLayer)) = animLayerIndices;
		}
	}

	public unsafe NpcBehaviour npcBehaviour
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_npcBehaviour);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<NpcBehaviour>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_npcBehaviour)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)npcBehaviour));
		}
	}

	public unsafe GameObject currentIndicatorObj
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentIndicatorObj);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<GameObject>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_currentIndicatorObj)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)gameObject));
		}
	}

	public unsafe Vector3 targetDir
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_targetDir);
			return *(Vector3*)num;
		}
		set
		{
			*(Vector3*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_targetDir)) = vector;
		}
	}

	public unsafe List<CharHurtbox> charsToHurt
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charsToHurt);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<List<CharHurtbox>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_charsToHurt)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	static NpcRecoilAbility()
	{
		Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Entities", "NpcRecoilAbility");
		NativeFieldInfoPtr_spellPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, "spellPrefab");
		NativeFieldInfoPtr_firingPoint = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, "firingPoint");
		NativeFieldInfoPtr_castMotionLockType = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, "castMotionLockType");
		NativeFieldInfoPtr_castRotationLockType = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, "castRotationLockType");
		NativeFieldInfoPtr_jumpRotationLockType = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, "jumpRotationLockType");
		NativeFieldInfoPtr_applyAtkSpeedMultiplier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, "applyAtkSpeedMultiplier");
		NativeFieldInfoPtr_applyCooldownMultiplier = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, "applyCooldownMultiplier");
		NativeFieldInfoPtr_inputType = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, "inputType");
		NativeFieldInfoPtr_numProjectiles = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, "numProjectiles");
		NativeFieldInfoPtr_angleSpread = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, "angleSpread");
		NativeFieldInfoPtr_visibleIndicatorPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, "visibleIndicatorPrefab");
		NativeFieldInfoPtr_indicatorHalfScale = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, "indicatorHalfScale");
		NativeFieldInfoPtr_damage = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, "damage");
		NativeFieldInfoPtr_damageScaling = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, "damageScaling");
		NativeFieldInfoPtr_speed = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, "speed");
		NativeFieldInfoPtr_ttl = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, "ttl");
		NativeFieldInfoPtr_statusEffects = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, "statusEffects");
		NativeFieldInfoPtr_castingTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, "castingTime");
		NativeFieldInfoPtr_jumpTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, "jumpTime");
		NativeFieldInfoPtr_floatTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, "floatTime");
		NativeFieldInfoPtr_recoveryTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, "recoveryTime");
		NativeFieldInfoPtr_baseCooldownTime = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, "baseCooldownTime");
		NativeFieldInfoPtr_jumpLerpCurve = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, "jumpLerpCurve");
		NativeFieldInfoPtr_baseShadowAlphaCurve = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, "baseShadowAlphaCurve");
		NativeFieldInfoPtr_jumpDistance = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, "jumpDistance");
		NativeFieldInfoPtr_jumpRadiusCheck = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, "jumpRadiusCheck");
		NativeFieldInfoPtr_camKickPower = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, "camKickPower");
		NativeFieldInfoPtr_vfxCastPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, "vfxCastPrefab");
		NativeFieldInfoPtr_vfxJumpPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, "vfxJumpPrefab");
		NativeFieldInfoPtr_vfxLandPrefab = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, "vfxLandPrefab");
		NativeFieldInfoPtr_sfxCast = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, "sfxCast");
		NativeFieldInfoPtr_animLayer = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, "animLayer");
		NativeFieldInfoPtr_npcBehaviour = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, "npcBehaviour");
		NativeFieldInfoPtr_currentIndicatorObj = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, "currentIndicatorObj");
		NativeFieldInfoPtr_targetDir = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, "targetDir");
		NativeFieldInfoPtr_charsToHurt = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, "charsToHurt");
		NativeMethodInfoPtr_PreAwake_Public_Virtual_Void_EntityManager_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, 100674110);
		NativeMethodInfoPtr_Shoot_Private_Void_Vector3_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, 100674111);
		NativeMethodInfoPtr_ShootProjectile_Private_Void_Vector3_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, 100674112);
		NativeMethodInfoPtr_OnTargetHit_Public_Virtual_Void_EntityManager_HitboxBase_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, 100674113);
		NativeMethodInfoPtr_RpcSpawnVisibleIndicator_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, 100674114);
		NativeMethodInfoPtr_RpcDestroyVisibleIndicator_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, 100674115);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, 100674116);
		NativeMethodInfoPtr_Weaved_Public_Virtual_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, 100674117);
		NativeMethodInfoPtr_UserCode_RpcSpawnVisibleIndicator_Protected_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, 100674118);
		NativeMethodInfoPtr_InvokeUserCode_RpcSpawnVisibleIndicator_Protected_Static_Void_NetworkBehaviour_NetworkReader_NetworkConnectionToClient_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, 100674119);
		NativeMethodInfoPtr_UserCode_RpcDestroyVisibleIndicator_Protected_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, 100674120);
		NativeMethodInfoPtr_InvokeUserCode_RpcDestroyVisibleIndicator_Protected_Static_Void_NetworkBehaviour_NetworkReader_NetworkConnectionToClient_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr, 100674121);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 142304, XrefRangeEnd = 142481, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void PreAwake(EntityManager _entityManager)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)_entityManager);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_PreAwake_Public_Virtual_Void_EntityManager_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 142481, XrefRangeEnd = 142487, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Shoot(Vector3 lookDir)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&lookDir);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Shoot_Private_Void_Vector3_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 142516, RefRangeEnd = 142518, XrefRangeStart = 142487, XrefRangeEnd = 142516, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ShootProjectile(Vector3 lookDir)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&lookDir);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ShootProjectile_Private_Void_Vector3_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 142518, XrefRangeEnd = 142544, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override void OnTargetHit(EntityManager otherEntityManager, HitboxBase hitboxBase)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[2];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)otherEntityManager);
		*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)hitboxBase);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_OnTargetHit_Public_Virtual_Void_EntityManager_HitboxBase_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 142544, XrefRangeEnd = 142553, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void RpcSpawnVisibleIndicator()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_RpcSpawnVisibleIndicator_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 142553, XrefRangeEnd = 142562, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void RpcDestroyVisibleIndicator()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_RpcDestroyVisibleIndicator_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 142562, XrefRangeEnd = 142571, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe NpcRecoilAbility()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<NpcRecoilAbility>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(24)]
	[CachedScanResults(RefRangeStart = 28750, RefRangeEnd = 28774, XrefRangeStart = 28750, XrefRangeEnd = 28774, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe override bool Weaved()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(IL2CPP.il2cpp_object_get_virtual_method(IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)this), NativeMethodInfoPtr_Weaved_Public_Virtual_Boolean_0), IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 142618, RefRangeEnd = 142619, XrefRangeStart = 142571, XrefRangeEnd = 142618, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UserCode_RpcSpawnVisibleIndicator()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UserCode_RpcSpawnVisibleIndicator_Protected_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 142619, XrefRangeEnd = 142626, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void InvokeUserCode_RpcSpawnVisibleIndicator(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		IntPtr* ptr = stackalloc IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)obj);
		*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)reader);
		*(IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)senderConnection);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_InvokeUserCode_RpcSpawnVisibleIndicator_Protected_Static_Void_NetworkBehaviour_NetworkReader_NetworkConnectionToClient_0, (IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 142626, XrefRangeEnd = 142631, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void UserCode_RpcDestroyVisibleIndicator()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_UserCode_RpcDestroyVisibleIndicator_Protected_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 142631, XrefRangeEnd = 142642, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe static void InvokeUserCode_RpcDestroyVisibleIndicator(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
	{
		IntPtr* ptr = stackalloc IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)obj);
		*(IntPtr*)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)reader);
		*(IntPtr*)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)senderConnection);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_InvokeUserCode_RpcDestroyVisibleIndicator_Protected_Static_Void_NetworkBehaviour_NetworkReader_NetworkConnectionToClient_0, (IntPtr)0, (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public NpcRecoilAbility(IntPtr pointer)
		: base(pointer)
	{
	}
}
