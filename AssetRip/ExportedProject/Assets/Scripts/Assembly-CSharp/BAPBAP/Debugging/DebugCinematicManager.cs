using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.UI;
using BAPBAP.Utilities;
using UnityEngine;

namespace BAPBAP.Debugging
{
	public class DebugCinematicManager : MonoBehaviour
	{
		public class CameraSnapshot
		{
			public Vector3 position;

			public Quaternion rotation;

			public float fov;

			public float speedMultiplier;

			public Color uiColor;

			public CameraSnapshot(Vector3 position, Quaternion rotation, float fov)
			{
			}

			public override string ToString()
			{
				return null;
			}
		}

		[NonSerialized]
		public DebugManager debugManager;

		[NonSerialized]
		public DebugGameplayManager debugGmManager;

		[NonSerialized]
		public UIManager uiManager;

		[NonSerialized]
		public InputSystem inputSystem;

		[NonSerialized]
		public Camera cam;

		[NonSerialized]
		public CameraController cameraController;

		[NonSerialized]
		public CameraCinematicControler cineCam;

		[SerializeField]
		[Header("References")]
		public GUISkin guiSkin;

		[Header("GUI")]
		[SerializeField]
		public float interfaceWidthPercent;

		[SerializeField]
		public Vector2Int targetResolution;

		[SerializeField]
		[Header("Config")]
		public RangeFloat camMoveSpeedRange;

		[SerializeField]
		public float camMoveSpeedIncreaseMult;

		[Min(0.1f)]
		[SerializeField]
		public float camMoveSpeedSliderPower;

		[SerializeField]
		public RangeFloat camFollowFactorRange;

		[SerializeField]
		public RangeFloat camMoveSmoothRange;

		[SerializeField]
		public RangeFloat camLookSensitivityRange;

		[SerializeField]
		public RangeFloat camLookSmoothRange;

		[SerializeField]
		public RangeFloat camFovRange;

		[SerializeField]
		public RangeFloat camFovSpeedRange;

		[Min(0f)]
		[SerializeField]
		public int maxSnapshots;

		[Header("Cam Input")]
		[SerializeField]
		public KeyCode focusKeyInputToggle;

		[SerializeField]
		public KeyCode focusKeyInputHold;

		[SerializeField]
		public KeyCode camLockInput;

		[SerializeField]
		public KeyCode cineDisplayUIInput;

		[SerializeField]
		public KeyCode syncDirectionToCamInput;

		[SerializeField]
		public KeyCode charInputLockInput;

		[SerializeField]
		public KeyCode charRotationLockInput;

		[SerializeField]
		public KeyCode followPlayerInput;

		[SerializeField]
		public KeyCode horizontalLockInput;

		[SerializeField]
		public KeyCode cursorToggleInput;

		[SerializeField]
		[Header("Fov Input")]
		public KeyCode fovUpKey;

		[SerializeField]
		public KeyCode fovDownKey;

		[SerializeField]
		public KeyCode fovResetKey;

		[NonSerialized]
		public bool displayGUI;

		[NonSerialized]
		public bool camLock;

		[NonSerialized]
		public bool charInputLock;

		[NonSerialized]
		public bool allowCharInputWhileFocus;

		[NonSerialized]
		public bool followingPlayer;

		[NonSerialized]
		public bool syncDirectionToCam;

		[NonSerialized]
		public bool charRotationLock;

		[NonSerialized]
		public List<CameraSnapshot> snapshots;

		[NonSerialized]
		public Vector2Int currentRes;

		[NonSerialized]
		public Vector2 guiScrollPos;

		[NonSerialized]
		public bool mouseIsOnScene;

		[NonSerialized]
		public bool gameUtilitiesToggle;

		[NonSerialized]
		public bool uiUtilitiesToggle;

		[NonSerialized]
		public bool viewUtilitiesToggle;

		[NonSerialized]
		public bool snapshotToggle;

		public void Awake()
		{
		}

		public void SetEnabled(bool isEnabled)
		{
		}

		public void ManagedUpdate()
		{
		}

		public void FixedUpdate()
		{
		}

		public void ProcessInput()
		{
		}

		public void OnGUI()
		{
		}

		public void CineCamGUI(Rect rect)
		{
		}

		public void ToggleFocus()
		{
		}

		public void SetFocus(bool focused)
		{
		}

		public void SetDisplayGUI(bool display)
		{
		}

		public void SetCharInputLock()
		{
		}

		public void SetCharRotationLock()
		{
		}

		public void SetCamSpeed(float speed)
		{
		}

		public void SetCamFov(float fov)
		{
		}

		public static Vector3 RoundV3Decimals(Vector3 v, int dAmount = 10)
		{
			return default(Vector3);
		}

		public static float RoundDecimals(float f, int dAmount = 10)
		{
			return 0f;
		}

		public static float PowerToLinear(float powerValue, float power, float min, float max)
		{
			return 0f;
		}

		public static float LinearToPower(float linearValue, float power, float min, float max)
		{
			return 0f;
		}
	}
}
