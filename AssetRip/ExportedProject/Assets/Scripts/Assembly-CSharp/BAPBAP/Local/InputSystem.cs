using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

namespace BAPBAP.Local
{
	public class InputSystem : MonoBehaviour
	{
		[SerializeField]
		public AimAssistDetection aimAssistDetection;

		[SerializeField]
		public AimAssistIndicator aimAssistIndicator;

		[SerializeField]
		public AimDirectionIndicator aimDirectionIndicator;

		[SerializeField]
		public float defaultAimDistance;

		[SerializeField]
		public float aimAssistRange;

		[SerializeField]
		public float aimAssistTimeout;

		[SerializeField]
		public float cardinalSensitivity;

		[SerializeField]
		public LayerMask lineOfSightMask;

		[Range(0f, 1f)]
		[SerializeField]
		public float assistAngleWeight;

		[SerializeField]
		[Range(0f, 1f)]
		public float assistDistanceWeight;

		[SerializeField]
		[Range(0f, 1f)]
		public float assistCharWeight;

		[SerializeField]
		[Range(0f, 1f)]
		public float assistNpcWeight;

		[SerializeField]
		[Range(0f, 1f)]
		public float assistLootWeight;

		[SerializeField]
		[Range(0f, 1f)]
		public float assistHpWeight;

		[SerializeField]
		[Range(0f, 1f)]
		public float assistCurrentTargetWeight;

		[SerializeField]
		public InputAction aimAction;

		[SerializeField]
		public InputAction moveAction;

		[SerializeField]
		[Header("Gamepad Inputs")]
		public InputAction faceAAction;

		[SerializeField]
		public InputAction faceBAction;

		[SerializeField]
		public InputAction faceXAction;

		[SerializeField]
		public InputAction faceYAction;

		[SerializeField]
		public InputAction selectAction;

		[SerializeField]
		public InputAction startAction;

		[SerializeField]
		public InputAction leftShoulderAction;

		[SerializeField]
		public InputAction rightShoulderAction;

		[SerializeField]
		public InputAction leftTriggerAction;

		[SerializeField]
		public InputAction rightTriggerAction;

		[SerializeField]
		public InputAction leftStickPressAction;

		[SerializeField]
		public InputAction rightStickPressAction;

		[SerializeField]
		public InputAction dPadLeftAction;

		[SerializeField]
		public InputAction dPadRightAction;

		[SerializeField]
		public InputAction dPadUpAction;

		[SerializeField]
		public InputAction dPadDownAction;

		public InputMap inputMap;

		[NonSerialized]
		public Dictionary<InputTarget, KeyCode> defaultKeyBinds;

		[NonSerialized]
		public InputBinding up;

		[NonSerialized]
		public InputBinding down;

		[NonSerialized]
		public InputBinding left;

		[NonSerialized]
		public InputBinding right;

		[NonSerialized]
		public InputMode inputMode;

		[NonSerialized]
		public bool buttonUp;

		[NonSerialized]
		public Vector2 moveAxis;

		[NonSerialized]
		public Vector2 aimAxis;

		[NonSerialized]
		public Vector2 combinedAxis;

		[NonSerialized]
		public bool aimAbility;

		[NonSerialized]
		public bool aimCardinal;

		[NonSerialized]
		public bool aimMove;

		[NonSerialized]
		public bool aimLock;

		[NonSerialized]
		public bool autoUpdateDevice;

		[NonSerialized]
		public float aimRange;

		[NonSerialized]
		public bool aimAssist;

		[NonSerialized]
		public bool cachedAimCardinal;

		[NonSerialized]
		public float assistTimeout;

		[NonSerialized]
		public Vector3 lastMousePosition;

		[NonSerialized]
		public Vector3 devicePrevMousePos;

		[NonSerialized]
		public Vector3 cardinalOffset;

		[NonSerialized]
		public Vector3 cachedAimAxis;

		[NonSerialized]
		public Vector3 cachedOffset;

		[NonSerialized]
		public List<AimAssistDetection.Target> targets;

		[NonSerialized]
		public AimAssistDetection.Target target;

		public InputMode InputMode => default(InputMode);

		public Vector2 MoveAxis => default(Vector2);

		public Vector2 AimAxis => default(Vector2);

		public Vector2 CombinedAxis => default(Vector2);

		public Vector3 VirtualCursor => default(Vector3);

		public AimAssistDetection.Target Target => null;

		public AimAssistIndicator AssistIndicator => null;

		public AimDirectionIndicator DirectionIndicator => null;

		public bool AimAssist
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool AimAbility
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool AimCardinal
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public float AimRange
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool AimMove
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool AimLock
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool AutoUpdateDevice
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public bool FaceAAction => false;

		public bool FaceAReleaseAction => false;

		public bool FaceBAction => false;

		public bool FaceXAction => false;

		public bool FaceYAction => false;

		public bool SelectAction => false;

		public bool StartAction => false;

		public bool LeftShoulderAction => false;

		public bool RightShoulderAction => false;

		public bool LeftTriggerAction => false;

		public bool RightTriggerAction => false;

		public bool LeftStickPressAction => false;

		public bool RightStickPressAction => false;

		public bool DPadLeftActionPressed => false;

		public bool DPadRightActionPressed => false;

		public bool DPadUpActionPressed => false;

		public bool DPadDownActionPressed => false;

		public InputAction DPadUpInputAction => null;

		public InputAction DPadDownInputAction => null;

		public bool GamepadAnyButtonPressed => false;

		public void ResetConstraints()
		{
		}

		public void Awake()
		{
		}

		public void Update()
		{
		}

		public void SetInputMode(InputMode mode)
		{
		}

		public AimAssistDetection.Target GetAimAssistTarget()
		{
			return null;
		}

		public Vector3 GetVirtualCursor()
		{
			return default(Vector3);
		}

		public bool TryGetPlayerPosition(out Vector3 position)
		{
			position = default(Vector3);
			return false;
		}

		public float ScoreTargetAngle(AimAssistDetection.Target target, Vector3 player, Vector3 aim)
		{
			return 0f;
		}

		public float ScoreTargetDistance(AimAssistDetection.Target target, Vector3 player, Vector3 range)
		{
			return 0f;
		}

		public float ScoreTargetType(AimAssistDetection.Target target)
		{
			return 0f;
		}

		public float ScoreTargetHp(AimAssistDetection.Target target)
		{
			return 0f;
		}

		public float ScoreCurrentTarget(AimAssistDetection.Target target)
		{
			return 0f;
		}

		public bool HasLineOfSight(Vector3 p1, Vector3 p2)
		{
			return false;
		}

		public KeyCode GetDefaultInputKey(InputBinding input)
		{
			return default(KeyCode);
		}

		public string GetKeyCodeName(KeyCode key)
		{
			return null;
		}

		public string GetCurrentKeyNameByInputTarget(InputTarget target)
		{
			return null;
		}

		public string GetTargetTranslationKey(InputTarget inputTarget)
		{
			return null;
		}
	}
}
