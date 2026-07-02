using System;
using System.Runtime.CompilerServices;
using Il2CppInterop.Common.Attributes;
using Il2CppInterop.Runtime;
using Il2CppInterop.Runtime.InteropTypes;
using Il2CppInterop.Runtime.Runtime;
using Il2CppSystem.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Il2CppBAPBAP.Local;

public class InputSystem : MonoBehaviour
{
	private static readonly IntPtr NativeFieldInfoPtr_aimAssistDetection;

	private static readonly IntPtr NativeFieldInfoPtr_aimAssistIndicator;

	private static readonly IntPtr NativeFieldInfoPtr_aimDirectionIndicator;

	private static readonly IntPtr NativeFieldInfoPtr_defaultAimDistance;

	private static readonly IntPtr NativeFieldInfoPtr_aimAssistRange;

	private static readonly IntPtr NativeFieldInfoPtr_aimAssistTimeout;

	private static readonly IntPtr NativeFieldInfoPtr_cardinalSensitivity;

	private static readonly IntPtr NativeFieldInfoPtr_lineOfSightMask;

	private static readonly IntPtr NativeFieldInfoPtr_assistAngleWeight;

	private static readonly IntPtr NativeFieldInfoPtr_assistDistanceWeight;

	private static readonly IntPtr NativeFieldInfoPtr_assistCharWeight;

	private static readonly IntPtr NativeFieldInfoPtr_assistNpcWeight;

	private static readonly IntPtr NativeFieldInfoPtr_assistLootWeight;

	private static readonly IntPtr NativeFieldInfoPtr_assistHpWeight;

	private static readonly IntPtr NativeFieldInfoPtr_assistCurrentTargetWeight;

	private static readonly IntPtr NativeFieldInfoPtr_aimAction;

	private static readonly IntPtr NativeFieldInfoPtr_moveAction;

	private static readonly IntPtr NativeFieldInfoPtr_faceAAction;

	private static readonly IntPtr NativeFieldInfoPtr_faceBAction;

	private static readonly IntPtr NativeFieldInfoPtr_faceXAction;

	private static readonly IntPtr NativeFieldInfoPtr_faceYAction;

	private static readonly IntPtr NativeFieldInfoPtr_selectAction;

	private static readonly IntPtr NativeFieldInfoPtr_startAction;

	private static readonly IntPtr NativeFieldInfoPtr_leftShoulderAction;

	private static readonly IntPtr NativeFieldInfoPtr_rightShoulderAction;

	private static readonly IntPtr NativeFieldInfoPtr_leftTriggerAction;

	private static readonly IntPtr NativeFieldInfoPtr_rightTriggerAction;

	private static readonly IntPtr NativeFieldInfoPtr_leftStickPressAction;

	private static readonly IntPtr NativeFieldInfoPtr_rightStickPressAction;

	private static readonly IntPtr NativeFieldInfoPtr_dPadLeftAction;

	private static readonly IntPtr NativeFieldInfoPtr_dPadRightAction;

	private static readonly IntPtr NativeFieldInfoPtr_dPadUpAction;

	private static readonly IntPtr NativeFieldInfoPtr_dPadDownAction;

	private static readonly IntPtr NativeFieldInfoPtr_inputMap;

	private static readonly IntPtr NativeFieldInfoPtr_defaultKeyBinds;

	private static readonly IntPtr NativeFieldInfoPtr_up;

	private static readonly IntPtr NativeFieldInfoPtr_down;

	private static readonly IntPtr NativeFieldInfoPtr_left;

	private static readonly IntPtr NativeFieldInfoPtr_right;

	private static readonly IntPtr NativeFieldInfoPtr_inputMode;

	private static readonly IntPtr NativeFieldInfoPtr_buttonUp;

	private static readonly IntPtr NativeFieldInfoPtr_moveAxis;

	private static readonly IntPtr NativeFieldInfoPtr_aimAxis;

	private static readonly IntPtr NativeFieldInfoPtr_combinedAxis;

	private static readonly IntPtr NativeFieldInfoPtr_aimAbility;

	private static readonly IntPtr NativeFieldInfoPtr_aimCardinal;

	private static readonly IntPtr NativeFieldInfoPtr_aimMove;

	private static readonly IntPtr NativeFieldInfoPtr_aimLock;

	private static readonly IntPtr NativeFieldInfoPtr_autoUpdateDevice;

	private static readonly IntPtr NativeFieldInfoPtr_aimRange;

	private static readonly IntPtr NativeFieldInfoPtr_aimAssist;

	private static readonly IntPtr NativeFieldInfoPtr_cachedAimCardinal;

	private static readonly IntPtr NativeFieldInfoPtr_assistTimeout;

	private static readonly IntPtr NativeFieldInfoPtr_lastMousePosition;

	private static readonly IntPtr NativeFieldInfoPtr_devicePrevMousePos;

	private static readonly IntPtr NativeFieldInfoPtr_cardinalOffset;

	private static readonly IntPtr NativeFieldInfoPtr_cachedAimAxis;

	private static readonly IntPtr NativeFieldInfoPtr_cachedOffset;

	private static readonly IntPtr NativeFieldInfoPtr_targets;

	private static readonly IntPtr NativeFieldInfoPtr_target;

	private static readonly IntPtr NativeMethodInfoPtr_get_InputMode_Public_get_InputMode_0;

	private static readonly IntPtr NativeMethodInfoPtr_get_MoveAxis_Public_get_Vector2_0;

	private static readonly IntPtr NativeMethodInfoPtr_get_AimAxis_Public_get_Vector2_0;

	private static readonly IntPtr NativeMethodInfoPtr_get_CombinedAxis_Public_get_Vector2_0;

	private static readonly IntPtr NativeMethodInfoPtr_get_VirtualCursor_Public_get_Vector3_0;

	private static readonly IntPtr NativeMethodInfoPtr_get_Target_Public_get_Target_0;

	private static readonly IntPtr NativeMethodInfoPtr_get_AssistIndicator_Public_get_AimAssistIndicator_0;

	private static readonly IntPtr NativeMethodInfoPtr_get_DirectionIndicator_Public_get_AimDirectionIndicator_0;

	private static readonly IntPtr NativeMethodInfoPtr_get_AimAssist_Public_get_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_set_AimAssist_Public_set_Void_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_get_AimAbility_Public_get_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_set_AimAbility_Public_set_Void_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_get_AimCardinal_Public_get_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_set_AimCardinal_Public_set_Void_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_get_AimRange_Public_get_Single_0;

	private static readonly IntPtr NativeMethodInfoPtr_set_AimRange_Public_set_Void_Single_0;

	private static readonly IntPtr NativeMethodInfoPtr_get_AimMove_Public_get_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_set_AimMove_Public_set_Void_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_get_AimLock_Public_get_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_set_AimLock_Public_set_Void_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_get_AutoUpdateDevice_Public_get_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_set_AutoUpdateDevice_Public_set_Void_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_get_FaceAAction_Public_get_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_get_FaceAReleaseAction_Public_get_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_get_FaceBAction_Public_get_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_get_FaceXAction_Public_get_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_get_FaceYAction_Public_get_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_get_SelectAction_Public_get_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_get_StartAction_Public_get_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_get_LeftShoulderAction_Public_get_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_get_RightShoulderAction_Public_get_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_get_LeftTriggerAction_Public_get_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_get_RightTriggerAction_Public_get_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_get_LeftStickPressAction_Public_get_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_get_RightStickPressAction_Public_get_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_get_DPadLeftActionPressed_Public_get_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_get_DPadRightActionPressed_Public_get_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_get_DPadUpActionPressed_Public_get_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_get_DPadDownActionPressed_Public_get_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_get_DPadUpInputAction_Public_get_InputAction_0;

	private static readonly IntPtr NativeMethodInfoPtr_get_DPadDownInputAction_Public_get_InputAction_0;

	private static readonly IntPtr NativeMethodInfoPtr_get_GamepadAnyButtonPressed_Public_get_Boolean_0;

	private static readonly IntPtr NativeMethodInfoPtr_ResetConstraints_Public_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_Awake_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_Update_Private_Void_0;

	private static readonly IntPtr NativeMethodInfoPtr_SetInputMode_Public_Void_InputMode_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetAimAssistTarget_Private_Target_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetVirtualCursor_Private_Vector3_0;

	private static readonly IntPtr NativeMethodInfoPtr_TryGetPlayerPosition_Private_Boolean_byref_Vector3_0;

	private static readonly IntPtr NativeMethodInfoPtr_ScoreTargetAngle_Private_Single_Target_Vector3_Vector3_0;

	private static readonly IntPtr NativeMethodInfoPtr_ScoreTargetDistance_Private_Single_Target_Vector3_Vector3_0;

	private static readonly IntPtr NativeMethodInfoPtr_ScoreTargetType_Private_Single_Target_0;

	private static readonly IntPtr NativeMethodInfoPtr_ScoreTargetHp_Private_Single_Target_0;

	private static readonly IntPtr NativeMethodInfoPtr_ScoreCurrentTarget_Private_Single_Target_0;

	private static readonly IntPtr NativeMethodInfoPtr_HasLineOfSight_Private_Boolean_Vector3_Vector3_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetDefaultInputKey_Public_KeyCode_InputBinding_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetKeyCodeName_Public_String_KeyCode_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetCurrentKeyNameByInputTarget_Public_String_InputTarget_0;

	private static readonly IntPtr NativeMethodInfoPtr_GetTargetTranslationKey_Public_String_InputTarget_0;

	private static readonly IntPtr NativeMethodInfoPtr__ctor_Public_Void_0;

	public unsafe AimAssistDetection aimAssistDetection
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_aimAssistDetection);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<AimAssistDetection>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_aimAssistDetection)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)aimAssistDetection));
		}
	}

	public unsafe AimAssistIndicator aimAssistIndicator
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_aimAssistIndicator);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<AimAssistIndicator>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_aimAssistIndicator)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)aimAssistIndicator));
		}
	}

	public unsafe AimDirectionIndicator aimDirectionIndicator
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_aimDirectionIndicator);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<AimDirectionIndicator>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_aimDirectionIndicator)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)aimDirectionIndicator));
		}
	}

	public unsafe float defaultAimDistance
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defaultAimDistance);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defaultAimDistance)) = num;
		}
	}

	public unsafe float aimAssistRange
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_aimAssistRange);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_aimAssistRange)) = num;
		}
	}

	public unsafe float aimAssistTimeout
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_aimAssistTimeout);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_aimAssistTimeout)) = num;
		}
	}

	public unsafe float cardinalSensitivity
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_cardinalSensitivity);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_cardinalSensitivity)) = num;
		}
	}

	public unsafe LayerMask lineOfSightMask
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lineOfSightMask);
			return *(LayerMask*)num;
		}
		set
		{
			*(LayerMask*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lineOfSightMask)) = layerMask;
		}
	}

	public unsafe float assistAngleWeight
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_assistAngleWeight);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_assistAngleWeight)) = num;
		}
	}

	public unsafe float assistDistanceWeight
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_assistDistanceWeight);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_assistDistanceWeight)) = num;
		}
	}

	public unsafe float assistCharWeight
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_assistCharWeight);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_assistCharWeight)) = num;
		}
	}

	public unsafe float assistNpcWeight
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_assistNpcWeight);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_assistNpcWeight)) = num;
		}
	}

	public unsafe float assistLootWeight
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_assistLootWeight);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_assistLootWeight)) = num;
		}
	}

	public unsafe float assistHpWeight
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_assistHpWeight);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_assistHpWeight)) = num;
		}
	}

	public unsafe float assistCurrentTargetWeight
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_assistCurrentTargetWeight);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_assistCurrentTargetWeight)) = num;
		}
	}

	public unsafe InputAction aimAction
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_aimAction);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<InputAction>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_aimAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)inputAction));
		}
	}

	public unsafe InputAction moveAction
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_moveAction);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<InputAction>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_moveAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)inputAction));
		}
	}

	public unsafe InputAction faceAAction
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_faceAAction);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<InputAction>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_faceAAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)inputAction));
		}
	}

	public unsafe InputAction faceBAction
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_faceBAction);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<InputAction>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_faceBAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)inputAction));
		}
	}

	public unsafe InputAction faceXAction
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_faceXAction);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<InputAction>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_faceXAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)inputAction));
		}
	}

	public unsafe InputAction faceYAction
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_faceYAction);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<InputAction>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_faceYAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)inputAction));
		}
	}

	public unsafe InputAction selectAction
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_selectAction);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<InputAction>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_selectAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)inputAction));
		}
	}

	public unsafe InputAction startAction
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_startAction);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<InputAction>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_startAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)inputAction));
		}
	}

	public unsafe InputAction leftShoulderAction
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_leftShoulderAction);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<InputAction>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_leftShoulderAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)inputAction));
		}
	}

	public unsafe InputAction rightShoulderAction
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rightShoulderAction);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<InputAction>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rightShoulderAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)inputAction));
		}
	}

	public unsafe InputAction leftTriggerAction
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_leftTriggerAction);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<InputAction>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_leftTriggerAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)inputAction));
		}
	}

	public unsafe InputAction rightTriggerAction
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rightTriggerAction);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<InputAction>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rightTriggerAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)inputAction));
		}
	}

	public unsafe InputAction leftStickPressAction
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_leftStickPressAction);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<InputAction>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_leftStickPressAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)inputAction));
		}
	}

	public unsafe InputAction rightStickPressAction
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rightStickPressAction);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<InputAction>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_rightStickPressAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)inputAction));
		}
	}

	public unsafe InputAction dPadLeftAction
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dPadLeftAction);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<InputAction>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dPadLeftAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)inputAction));
		}
	}

	public unsafe InputAction dPadRightAction
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dPadRightAction);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<InputAction>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dPadRightAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)inputAction));
		}
	}

	public unsafe InputAction dPadUpAction
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dPadUpAction);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<InputAction>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dPadUpAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)inputAction));
		}
	}

	public unsafe InputAction dPadDownAction
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dPadDownAction);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<InputAction>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_dPadDownAction)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)inputAction));
		}
	}

	public unsafe InputMap inputMap
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inputMap);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<InputMap>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inputMap)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)inputMap));
		}
	}

	public unsafe Dictionary<InputTarget, KeyCode> defaultKeyBinds
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defaultKeyBinds);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<Dictionary<InputTarget, KeyCode>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_defaultKeyBinds)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)dictionary));
		}
	}

	public unsafe InputBinding up
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_up);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<InputBinding>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_up)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)inputBinding));
		}
	}

	public unsafe InputBinding down
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_down);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<InputBinding>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_down)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)inputBinding));
		}
	}

	public unsafe InputBinding left
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_left);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<InputBinding>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_left)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)inputBinding));
		}
	}

	public unsafe InputBinding right
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_right);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<InputBinding>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_right)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)inputBinding));
		}
	}

	public unsafe InputMode inputMode
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inputMode);
			return *(InputMode*)num;
		}
		set
		{
			*(InputMode*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_inputMode)) = inputMode;
		}
	}

	public unsafe bool buttonUp
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_buttonUp);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_buttonUp)) = flag;
		}
	}

	public unsafe Vector2 moveAxis
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_moveAxis);
			return *(Vector2*)num;
		}
		set
		{
			*(Vector2*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_moveAxis)) = vector;
		}
	}

	public unsafe Vector2 aimAxis
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_aimAxis);
			return *(Vector2*)num;
		}
		set
		{
			*(Vector2*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_aimAxis)) = vector;
		}
	}

	public unsafe Vector2 combinedAxis
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_combinedAxis);
			return *(Vector2*)num;
		}
		set
		{
			*(Vector2*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_combinedAxis)) = vector;
		}
	}

	public unsafe bool aimAbility
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_aimAbility);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_aimAbility)) = flag;
		}
	}

	public unsafe bool aimCardinal
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_aimCardinal);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_aimCardinal)) = flag;
		}
	}

	public unsafe bool aimMove
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_aimMove);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_aimMove)) = flag;
		}
	}

	public unsafe bool aimLock
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_aimLock);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_aimLock)) = flag;
		}
	}

	public unsafe bool autoUpdateDevice
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_autoUpdateDevice);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_autoUpdateDevice)) = flag;
		}
	}

	public unsafe float aimRange
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_aimRange);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_aimRange)) = num;
		}
	}

	public unsafe bool aimAssist
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_aimAssist);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_aimAssist)) = flag;
		}
	}

	public unsafe bool cachedAimCardinal
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_cachedAimCardinal);
			return *(bool*)num;
		}
		set
		{
			*(bool*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_cachedAimCardinal)) = flag;
		}
	}

	public unsafe float assistTimeout
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_assistTimeout);
			return *(float*)num;
		}
		set
		{
			*(float*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_assistTimeout)) = num;
		}
	}

	public unsafe Vector3 lastMousePosition
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lastMousePosition);
			return *(Vector3*)num;
		}
		set
		{
			*(Vector3*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_lastMousePosition)) = vector;
		}
	}

	public unsafe Vector3 devicePrevMousePos
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_devicePrevMousePos);
			return *(Vector3*)num;
		}
		set
		{
			*(Vector3*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_devicePrevMousePos)) = vector;
		}
	}

	public unsafe Vector3 cardinalOffset
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_cardinalOffset);
			return *(Vector3*)num;
		}
		set
		{
			*(Vector3*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_cardinalOffset)) = vector;
		}
	}

	public unsafe Vector3 cachedAimAxis
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_cachedAimAxis);
			return *(Vector3*)num;
		}
		set
		{
			*(Vector3*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_cachedAimAxis)) = vector;
		}
	}

	public unsafe Vector3 cachedOffset
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_cachedOffset);
			return *(Vector3*)num;
		}
		set
		{
			*(Vector3*)((nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_cachedOffset)) = vector;
		}
	}

	public unsafe List<AimAssistDetection.Target> targets
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_targets);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<List<AimAssistDetection.Target>>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_targets)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)list));
		}
	}

	public unsafe AimAssistDetection.Target target
	{
		get
		{
			nint num = (nint)IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this) + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_target);
			IntPtr intPtr = *(IntPtr*)num;
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<AimAssistDetection.Target>(intPtr) : null;
		}
		set
		{
			IntPtr num = IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IL2CPP.il2cpp_gc_wbarrier_set_field(num, (IntPtr)((nint)num + (int)IL2CPP.il2cpp_field_get_offset(NativeFieldInfoPtr_target)), IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)target));
		}
	}

	public unsafe InputMode InputMode
	{
		[CallerCount(0)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_InputMode_Public_get_InputMode_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(InputMode*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	public unsafe Vector2 MoveAxis
	{
		[CallerCount(0)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_MoveAxis_Public_get_Vector2_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(Vector2*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	public unsafe Vector2 AimAxis
	{
		[CallerCount(0)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_AimAxis_Public_get_Vector2_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(Vector2*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	public unsafe Vector2 CombinedAxis
	{
		[CallerCount(0)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_CombinedAxis_Public_get_Vector2_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(Vector2*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	public unsafe Vector3 VirtualCursor
	{
		[CallerCount(6)]
		[CachedScanResults(RefRangeStart = 224637, RefRangeEnd = 224643, XrefRangeStart = 224636, XrefRangeEnd = 224637, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_VirtualCursor_Public_get_Vector3_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(Vector3*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	public unsafe AimAssistDetection.Target Target
	{
		[CallerCount(0)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_Target_Public_get_Target_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<AimAssistDetection.Target>(intPtr) : null;
		}
	}

	public unsafe AimAssistIndicator AssistIndicator
	{
		[CallerCount(48)]
		[CachedScanResults(RefRangeStart = 33131, RefRangeEnd = 33179, XrefRangeStart = 33131, XrefRangeEnd = 33179, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_AssistIndicator_Public_get_AimAssistIndicator_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<AimAssistIndicator>(intPtr) : null;
		}
	}

	public unsafe AimDirectionIndicator DirectionIndicator
	{
		[CallerCount(43)]
		[CachedScanResults(RefRangeStart = 45979, RefRangeEnd = 46022, XrefRangeStart = 45979, XrefRangeEnd = 46022, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_DirectionIndicator_Public_get_AimDirectionIndicator_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<AimDirectionIndicator>(intPtr) : null;
		}
	}

	public unsafe bool AimAssist
	{
		[CallerCount(0)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_AimAssist_Public_get_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
		[CallerCount(2)]
		[CachedScanResults(RefRangeStart = 224643, RefRangeEnd = 224645, XrefRangeStart = 224643, XrefRangeEnd = 224643, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		set
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = stackalloc IntPtr[1];
			*ptr = (nint)(&value);
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_set_AimAssist_Public_set_Void_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}
	}

	public unsafe bool AimAbility
	{
		[CallerCount(0)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_AimAbility_Public_get_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
		[CallerCount(0)]
		set
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = stackalloc IntPtr[1];
			*ptr = (nint)(&value);
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_set_AimAbility_Public_set_Void_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}
	}

	public unsafe bool AimCardinal
	{
		[CallerCount(0)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_AimCardinal_Public_get_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
		[CallerCount(0)]
		set
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = stackalloc IntPtr[1];
			*ptr = (nint)(&value);
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_set_AimCardinal_Public_set_Void_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}
	}

	public unsafe float AimRange
	{
		[CallerCount(0)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_AimRange_Public_get_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(float*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
		[CallerCount(0)]
		set
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = stackalloc IntPtr[1];
			*ptr = (nint)(&value);
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_set_AimRange_Public_set_Void_Single_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}
	}

	public unsafe bool AimMove
	{
		[CallerCount(0)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_AimMove_Public_get_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
		[CallerCount(0)]
		set
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = stackalloc IntPtr[1];
			*ptr = (nint)(&value);
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_set_AimMove_Public_set_Void_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}
	}

	public unsafe bool AimLock
	{
		[CallerCount(0)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_AimLock_Public_get_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
		[CallerCount(0)]
		set
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = stackalloc IntPtr[1];
			*ptr = (nint)(&value);
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_set_AimLock_Public_set_Void_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}
	}

	public unsafe bool AutoUpdateDevice
	{
		[CallerCount(0)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_AutoUpdateDevice_Public_get_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
		[CallerCount(0)]
		set
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = stackalloc IntPtr[1];
			*ptr = (nint)(&value);
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_set_AutoUpdateDevice_Public_set_Void_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		}
	}

	public unsafe bool FaceAAction
	{
		[CallerCount(4)]
		[CachedScanResults(RefRangeStart = 224647, RefRangeEnd = 224651, XrefRangeStart = 224645, XrefRangeEnd = 224647, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_FaceAAction_Public_get_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	public unsafe bool FaceAReleaseAction
	{
		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 224653, RefRangeEnd = 224654, XrefRangeStart = 224651, XrefRangeEnd = 224653, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_FaceAReleaseAction_Public_get_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	public unsafe bool FaceBAction
	{
		[CallerCount(18)]
		[CachedScanResults(RefRangeStart = 224656, RefRangeEnd = 224674, XrefRangeStart = 224654, XrefRangeEnd = 224656, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_FaceBAction_Public_get_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	public unsafe bool FaceXAction
	{
		[CallerCount(6)]
		[CachedScanResults(RefRangeStart = 224676, RefRangeEnd = 224682, XrefRangeStart = 224674, XrefRangeEnd = 224676, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_FaceXAction_Public_get_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	public unsafe bool FaceYAction
	{
		[CallerCount(3)]
		[CachedScanResults(RefRangeStart = 224684, RefRangeEnd = 224687, XrefRangeStart = 224682, XrefRangeEnd = 224684, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_FaceYAction_Public_get_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	public unsafe bool SelectAction
	{
		[CallerCount(2)]
		[CachedScanResults(RefRangeStart = 224689, RefRangeEnd = 224691, XrefRangeStart = 224687, XrefRangeEnd = 224689, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_SelectAction_Public_get_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	public unsafe bool StartAction
	{
		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 224693, RefRangeEnd = 224694, XrefRangeStart = 224691, XrefRangeEnd = 224693, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_StartAction_Public_get_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	public unsafe bool LeftShoulderAction
	{
		[CallerCount(5)]
		[CachedScanResults(RefRangeStart = 224696, RefRangeEnd = 224701, XrefRangeStart = 224694, XrefRangeEnd = 224696, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_LeftShoulderAction_Public_get_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	public unsafe bool RightShoulderAction
	{
		[CallerCount(5)]
		[CachedScanResults(RefRangeStart = 224703, RefRangeEnd = 224708, XrefRangeStart = 224701, XrefRangeEnd = 224703, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_RightShoulderAction_Public_get_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	public unsafe bool LeftTriggerAction
	{
		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 224710, RefRangeEnd = 224711, XrefRangeStart = 224708, XrefRangeEnd = 224710, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_LeftTriggerAction_Public_get_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	public unsafe bool RightTriggerAction
	{
		[CallerCount(1)]
		[CachedScanResults(RefRangeStart = 224713, RefRangeEnd = 224714, XrefRangeStart = 224711, XrefRangeEnd = 224713, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_RightTriggerAction_Public_get_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	public unsafe bool LeftStickPressAction
	{
		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 224714, XrefRangeEnd = 224716, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_LeftStickPressAction_Public_get_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	public unsafe bool RightStickPressAction
	{
		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 224716, XrefRangeEnd = 224718, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_RightStickPressAction_Public_get_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	public unsafe bool DPadLeftActionPressed
	{
		[CallerCount(2)]
		[CachedScanResults(RefRangeStart = 224720, RefRangeEnd = 224722, XrefRangeStart = 224718, XrefRangeEnd = 224720, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_DPadLeftActionPressed_Public_get_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	public unsafe bool DPadRightActionPressed
	{
		[CallerCount(2)]
		[CachedScanResults(RefRangeStart = 224724, RefRangeEnd = 224726, XrefRangeStart = 224722, XrefRangeEnd = 224724, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_DPadRightActionPressed_Public_get_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	public unsafe bool DPadUpActionPressed
	{
		[CallerCount(0)]
		[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 224726, XrefRangeEnd = 224728, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_DPadUpActionPressed_Public_get_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	public unsafe bool DPadDownActionPressed
	{
		[CallerCount(2)]
		[CachedScanResults(RefRangeStart = 224730, RefRangeEnd = 224732, XrefRangeStart = 224728, XrefRangeEnd = 224730, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_DPadDownActionPressed_Public_get_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	public unsafe InputAction DPadUpInputAction
	{
		[CallerCount(0)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_DPadUpInputAction_Public_get_InputAction_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<InputAction>(intPtr) : null;
		}
	}

	public unsafe InputAction DPadDownInputAction
	{
		[CallerCount(0)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_DPadDownInputAction_Public_get_InputAction_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<InputAction>(intPtr) : null;
		}
	}

	public unsafe bool GamepadAnyButtonPressed
	{
		[CallerCount(3)]
		[CachedScanResults(RefRangeStart = 224748, RefRangeEnd = 224751, XrefRangeStart = 224732, XrefRangeEnd = 224748, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
		get
		{
			IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
			IntPtr* ptr = null;
			Unsafe.SkipInit(out IntPtr intPtr2);
			IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_get_GamepadAnyButtonPressed_Public_get_Boolean_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
			Il2CppException.RaiseExceptionIfNecessary(intPtr2);
			return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
		}
	}

	static InputSystem()
	{
		Il2CppClassPointerStore<InputSystem>.NativeClassPtr = IL2CPP.GetIl2CppClass("Assembly-CSharp.dll", "BAPBAP.Local", "InputSystem");
		IL2CPP.il2cpp_runtime_class_init(Il2CppClassPointerStore<InputSystem>.NativeClassPtr);
		NativeFieldInfoPtr_aimAssistDetection = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "aimAssistDetection");
		NativeFieldInfoPtr_aimAssistIndicator = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "aimAssistIndicator");
		NativeFieldInfoPtr_aimDirectionIndicator = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "aimDirectionIndicator");
		NativeFieldInfoPtr_defaultAimDistance = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "defaultAimDistance");
		NativeFieldInfoPtr_aimAssistRange = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "aimAssistRange");
		NativeFieldInfoPtr_aimAssistTimeout = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "aimAssistTimeout");
		NativeFieldInfoPtr_cardinalSensitivity = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "cardinalSensitivity");
		NativeFieldInfoPtr_lineOfSightMask = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "lineOfSightMask");
		NativeFieldInfoPtr_assistAngleWeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "assistAngleWeight");
		NativeFieldInfoPtr_assistDistanceWeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "assistDistanceWeight");
		NativeFieldInfoPtr_assistCharWeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "assistCharWeight");
		NativeFieldInfoPtr_assistNpcWeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "assistNpcWeight");
		NativeFieldInfoPtr_assistLootWeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "assistLootWeight");
		NativeFieldInfoPtr_assistHpWeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "assistHpWeight");
		NativeFieldInfoPtr_assistCurrentTargetWeight = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "assistCurrentTargetWeight");
		NativeFieldInfoPtr_aimAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "aimAction");
		NativeFieldInfoPtr_moveAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "moveAction");
		NativeFieldInfoPtr_faceAAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "faceAAction");
		NativeFieldInfoPtr_faceBAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "faceBAction");
		NativeFieldInfoPtr_faceXAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "faceXAction");
		NativeFieldInfoPtr_faceYAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "faceYAction");
		NativeFieldInfoPtr_selectAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "selectAction");
		NativeFieldInfoPtr_startAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "startAction");
		NativeFieldInfoPtr_leftShoulderAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "leftShoulderAction");
		NativeFieldInfoPtr_rightShoulderAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "rightShoulderAction");
		NativeFieldInfoPtr_leftTriggerAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "leftTriggerAction");
		NativeFieldInfoPtr_rightTriggerAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "rightTriggerAction");
		NativeFieldInfoPtr_leftStickPressAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "leftStickPressAction");
		NativeFieldInfoPtr_rightStickPressAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "rightStickPressAction");
		NativeFieldInfoPtr_dPadLeftAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "dPadLeftAction");
		NativeFieldInfoPtr_dPadRightAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "dPadRightAction");
		NativeFieldInfoPtr_dPadUpAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "dPadUpAction");
		NativeFieldInfoPtr_dPadDownAction = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "dPadDownAction");
		NativeFieldInfoPtr_inputMap = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "inputMap");
		NativeFieldInfoPtr_defaultKeyBinds = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "defaultKeyBinds");
		NativeFieldInfoPtr_up = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "up");
		NativeFieldInfoPtr_down = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "down");
		NativeFieldInfoPtr_left = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "left");
		NativeFieldInfoPtr_right = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "right");
		NativeFieldInfoPtr_inputMode = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "inputMode");
		NativeFieldInfoPtr_buttonUp = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "buttonUp");
		NativeFieldInfoPtr_moveAxis = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "moveAxis");
		NativeFieldInfoPtr_aimAxis = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "aimAxis");
		NativeFieldInfoPtr_combinedAxis = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "combinedAxis");
		NativeFieldInfoPtr_aimAbility = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "aimAbility");
		NativeFieldInfoPtr_aimCardinal = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "aimCardinal");
		NativeFieldInfoPtr_aimMove = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "aimMove");
		NativeFieldInfoPtr_aimLock = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "aimLock");
		NativeFieldInfoPtr_autoUpdateDevice = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "autoUpdateDevice");
		NativeFieldInfoPtr_aimRange = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "aimRange");
		NativeFieldInfoPtr_aimAssist = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "aimAssist");
		NativeFieldInfoPtr_cachedAimCardinal = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "cachedAimCardinal");
		NativeFieldInfoPtr_assistTimeout = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "assistTimeout");
		NativeFieldInfoPtr_lastMousePosition = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "lastMousePosition");
		NativeFieldInfoPtr_devicePrevMousePos = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "devicePrevMousePos");
		NativeFieldInfoPtr_cardinalOffset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "cardinalOffset");
		NativeFieldInfoPtr_cachedAimAxis = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "cachedAimAxis");
		NativeFieldInfoPtr_cachedOffset = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "cachedOffset");
		NativeFieldInfoPtr_targets = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "targets");
		NativeFieldInfoPtr_target = IL2CPP.GetIl2CppField(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, "target");
		NativeMethodInfoPtr_get_InputMode_Public_get_InputMode_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684079);
		NativeMethodInfoPtr_get_MoveAxis_Public_get_Vector2_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684080);
		NativeMethodInfoPtr_get_AimAxis_Public_get_Vector2_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684081);
		NativeMethodInfoPtr_get_CombinedAxis_Public_get_Vector2_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684082);
		NativeMethodInfoPtr_get_VirtualCursor_Public_get_Vector3_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684083);
		NativeMethodInfoPtr_get_Target_Public_get_Target_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684084);
		NativeMethodInfoPtr_get_AssistIndicator_Public_get_AimAssistIndicator_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684085);
		NativeMethodInfoPtr_get_DirectionIndicator_Public_get_AimDirectionIndicator_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684086);
		NativeMethodInfoPtr_get_AimAssist_Public_get_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684087);
		NativeMethodInfoPtr_set_AimAssist_Public_set_Void_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684088);
		NativeMethodInfoPtr_get_AimAbility_Public_get_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684089);
		NativeMethodInfoPtr_set_AimAbility_Public_set_Void_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684090);
		NativeMethodInfoPtr_get_AimCardinal_Public_get_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684091);
		NativeMethodInfoPtr_set_AimCardinal_Public_set_Void_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684092);
		NativeMethodInfoPtr_get_AimRange_Public_get_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684093);
		NativeMethodInfoPtr_set_AimRange_Public_set_Void_Single_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684094);
		NativeMethodInfoPtr_get_AimMove_Public_get_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684095);
		NativeMethodInfoPtr_set_AimMove_Public_set_Void_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684096);
		NativeMethodInfoPtr_get_AimLock_Public_get_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684097);
		NativeMethodInfoPtr_set_AimLock_Public_set_Void_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684098);
		NativeMethodInfoPtr_get_AutoUpdateDevice_Public_get_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684099);
		NativeMethodInfoPtr_set_AutoUpdateDevice_Public_set_Void_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684100);
		NativeMethodInfoPtr_get_FaceAAction_Public_get_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684101);
		NativeMethodInfoPtr_get_FaceAReleaseAction_Public_get_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684102);
		NativeMethodInfoPtr_get_FaceBAction_Public_get_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684103);
		NativeMethodInfoPtr_get_FaceXAction_Public_get_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684104);
		NativeMethodInfoPtr_get_FaceYAction_Public_get_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684105);
		NativeMethodInfoPtr_get_SelectAction_Public_get_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684106);
		NativeMethodInfoPtr_get_StartAction_Public_get_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684107);
		NativeMethodInfoPtr_get_LeftShoulderAction_Public_get_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684108);
		NativeMethodInfoPtr_get_RightShoulderAction_Public_get_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684109);
		NativeMethodInfoPtr_get_LeftTriggerAction_Public_get_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684110);
		NativeMethodInfoPtr_get_RightTriggerAction_Public_get_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684111);
		NativeMethodInfoPtr_get_LeftStickPressAction_Public_get_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684112);
		NativeMethodInfoPtr_get_RightStickPressAction_Public_get_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684113);
		NativeMethodInfoPtr_get_DPadLeftActionPressed_Public_get_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684114);
		NativeMethodInfoPtr_get_DPadRightActionPressed_Public_get_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684115);
		NativeMethodInfoPtr_get_DPadUpActionPressed_Public_get_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684116);
		NativeMethodInfoPtr_get_DPadDownActionPressed_Public_get_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684117);
		NativeMethodInfoPtr_get_DPadUpInputAction_Public_get_InputAction_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684118);
		NativeMethodInfoPtr_get_DPadDownInputAction_Public_get_InputAction_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684119);
		NativeMethodInfoPtr_get_GamepadAnyButtonPressed_Public_get_Boolean_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684120);
		NativeMethodInfoPtr_ResetConstraints_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684121);
		NativeMethodInfoPtr_Awake_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684122);
		NativeMethodInfoPtr_Update_Private_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684123);
		NativeMethodInfoPtr_SetInputMode_Public_Void_InputMode_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684124);
		NativeMethodInfoPtr_GetAimAssistTarget_Private_Target_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684125);
		NativeMethodInfoPtr_GetVirtualCursor_Private_Vector3_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684126);
		NativeMethodInfoPtr_TryGetPlayerPosition_Private_Boolean_byref_Vector3_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684127);
		NativeMethodInfoPtr_ScoreTargetAngle_Private_Single_Target_Vector3_Vector3_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684128);
		NativeMethodInfoPtr_ScoreTargetDistance_Private_Single_Target_Vector3_Vector3_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684129);
		NativeMethodInfoPtr_ScoreTargetType_Private_Single_Target_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684130);
		NativeMethodInfoPtr_ScoreTargetHp_Private_Single_Target_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684131);
		NativeMethodInfoPtr_ScoreCurrentTarget_Private_Single_Target_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684132);
		NativeMethodInfoPtr_HasLineOfSight_Private_Boolean_Vector3_Vector3_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684133);
		NativeMethodInfoPtr_GetDefaultInputKey_Public_KeyCode_InputBinding_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684134);
		NativeMethodInfoPtr_GetKeyCodeName_Public_String_KeyCode_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684135);
		NativeMethodInfoPtr_GetCurrentKeyNameByInputTarget_Public_String_InputTarget_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684136);
		NativeMethodInfoPtr_GetTargetTranslationKey_Public_String_InputTarget_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684137);
		NativeMethodInfoPtr__ctor_Public_Void_0 = IL2CPP.GetIl2CppMethodByToken(Il2CppClassPointerStore<InputSystem>.NativeClassPtr, 100684138);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 224751, RefRangeEnd = 224752, XrefRangeStart = 224751, XrefRangeEnd = 224751, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void ResetConstraints()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ResetConstraints_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 224752, XrefRangeEnd = 224805, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Awake()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Awake_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 224805, XrefRangeEnd = 224851, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void Update()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_Update_Private_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 224857, RefRangeEnd = 224860, XrefRangeStart = 224851, XrefRangeEnd = 224857, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe void SetInputMode(InputMode mode)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&mode);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_SetInputMode_Public_Void_InputMode_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 224888, RefRangeEnd = 224889, XrefRangeStart = 224860, XrefRangeEnd = 224888, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe AimAssistDetection.Target GetAimAssistTarget()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetAimAssistTarget_Private_Target_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return (intPtr != (IntPtr)0) ? Il2CppObjectPool.Get<AimAssistDetection.Target>(intPtr) : null;
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 224899, RefRangeEnd = 224902, XrefRangeStart = 224889, XrefRangeEnd = 224899, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe Vector3 GetVirtualCursor()
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetVirtualCursor_Private_Vector3_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(Vector3*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(3)]
	[CachedScanResults(RefRangeStart = 224911, RefRangeEnd = 224914, XrefRangeStart = 224902, XrefRangeEnd = 224911, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe bool TryGetPlayerPosition(out Vector3 position)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)Unsafe.AsPointer(ref position);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_TryGetPlayerPosition_Private_Boolean_byref_Vector3_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 224923, RefRangeEnd = 224924, XrefRangeStart = 224914, XrefRangeEnd = 224923, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe float ScoreTargetAngle(AimAssistDetection.Target target, Vector3 player, Vector3 aim)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)target);
		*(Vector3**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &player;
		*(Vector3**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = &aim;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ScoreTargetAngle_Private_Single_Target_Vector3_Vector3_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(float*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 224924, XrefRangeEnd = 224925, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe float ScoreTargetDistance(AimAssistDetection.Target target, Vector3 player, Vector3 range)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[3];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)target);
		*(Vector3**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &player;
		*(Vector3**)((byte*)ptr + checked((nuint)2u * unchecked((nuint)sizeof(IntPtr)))) = &range;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ScoreTargetDistance_Private_Single_Target_Vector3_Vector3_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(float*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	public unsafe float ScoreTargetType(AimAssistDetection.Target target)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)target);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ScoreTargetType_Private_Single_Target_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(float*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	[CachedScanResults(RefRangeStart = 0, RefRangeEnd = 0, XrefRangeStart = 224925, XrefRangeEnd = 224928, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe float ScoreTargetHp(AimAssistDetection.Target target)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)target);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ScoreTargetHp_Private_Single_Target_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(float*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(0)]
	public unsafe float ScoreCurrentTarget(AimAssistDetection.Target target)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)target);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_ScoreCurrentTarget_Private_Single_Target_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(float*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 224932, RefRangeEnd = 224933, XrefRangeStart = 224928, XrefRangeEnd = 224932, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe bool HasLineOfSight(Vector3 p1, Vector3 p2)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[2];
		*ptr = (nint)(&p1);
		*(Vector3**)((byte*)ptr + checked((nuint)1u * unchecked((nuint)sizeof(IntPtr)))) = &p2;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_HasLineOfSight_Private_Boolean_Vector3_Vector3_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(bool*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(2)]
	[CachedScanResults(RefRangeStart = 224935, RefRangeEnd = 224937, XrefRangeStart = 224933, XrefRangeEnd = 224935, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe KeyCode GetDefaultInputKey(InputBinding input)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = IL2CPP.Il2CppObjectBaseToPtr((Il2CppObjectBase)(object)input);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetDefaultInputKey_Public_KeyCode_InputBinding_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return *(KeyCode*)IL2CPP.il2cpp_object_unbox(intPtr);
	}

	[CallerCount(10)]
	[CachedScanResults(RefRangeStart = 224969, RefRangeEnd = 224979, XrefRangeStart = 224937, XrefRangeEnd = 224969, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe string GetKeyCodeName(KeyCode key)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&key);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetKeyCodeName_Public_String_KeyCode_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	[CallerCount(13)]
	[CachedScanResults(RefRangeStart = 224981, RefRangeEnd = 224994, XrefRangeStart = 224979, XrefRangeEnd = 224981, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe string GetCurrentKeyNameByInputTarget(InputTarget target)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&target);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetCurrentKeyNameByInputTarget_Public_String_InputTarget_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	[CallerCount(1)]
	[CachedScanResults(RefRangeStart = 224995, RefRangeEnd = 224996, XrefRangeStart = 224994, XrefRangeEnd = 224995, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe string GetTargetTranslationKey(InputTarget inputTarget)
	{
		IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this);
		IntPtr* ptr = stackalloc IntPtr[1];
		*ptr = (nint)(&inputTarget);
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr_GetTargetTranslationKey_Public_String_InputTarget_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
		return IL2CPP.Il2CppStringToManaged(intPtr);
	}

	[CallerCount(72)]
	[CachedScanResults(RefRangeStart = 5521, RefRangeEnd = 5593, XrefRangeStart = 5521, XrefRangeEnd = 5593, MetadataInitTokenRva = 0L, MetadataInitFlagRva = 0L)]
	public unsafe InputSystem()
		: this(IL2CPP.il2cpp_object_new(Il2CppClassPointerStore<InputSystem>.NativeClassPtr))
	{
		IntPtr* ptr = null;
		Unsafe.SkipInit(out IntPtr intPtr2);
		IntPtr intPtr = IL2CPP.il2cpp_runtime_invoke(NativeMethodInfoPtr__ctor_Public_Void_0, IL2CPP.Il2CppObjectBaseToPtrNotNull((Il2CppObjectBase)(object)this), (void**)ptr, ref intPtr2);
		Il2CppException.RaiseExceptionIfNecessary(intPtr2);
	}

	public InputSystem(IntPtr pointer)
		: base(pointer)
	{
	}
}
