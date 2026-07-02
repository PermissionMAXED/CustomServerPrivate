using System;
using System.Collections.Generic;
using BAPBAP.Entities.View;
using BAPBAP.UI;
using BAPBAP.Utilities;
using UnityEngine;
using UnityEngine.Rendering.Universal;

namespace BAPBAP.Local
{
	public class CameraController : MonoBehaviour
	{
		[NonSerialized]
		public UIManager uiManager;

		[NonSerialized]
		public InputManager inputManager;

		[NonSerialized]
		public Camera cam;

		[NonSerialized]
		public CameraShake camScreenShake;

		[Header("Drivers")]
		[SerializeField]
		public CameraTopDown cameraTopDown;

		[SerializeField]
		public CameraThirdPerson cameraThirdPerson;

		[SerializeField]
		public CameraFPS cameraFps;

		[SerializeField]
		public CameraVehicle cameraVehicle;

		[Header("Shared Config")]
		[SerializeField]
		public bool isFixedCamera;

		[SerializeField]
		public bool isFairlyCentered;

		[SerializeField]
		[Range(0f, 1f)]
		public float fairCenterFactor;

		[SerializeField]
		[Range(0f, 2f)]
		public float scrollSensitivity;

		[SerializeField]
		public LayerMask cameraCollisionMask;

		[SerializeField]
		public float cameraCollisionRadius;

		[SerializeField]
		public float cameraCollisionHeight;

		[SerializeField]
		public float cameraCollisionOffsetDistance;

		[NonSerialized]
		public float fairCenterMultiplier;

		[SerializeField]
		[Header("Depth Of Field Auto Focus")]
		public RangeFloat dofFocusDistanceRange;

		[SerializeField]
		public RangeFloat dofFocalLengthRange;

		[NonSerialized]
		public Transform _target;

		[NonSerialized]
		public Vector3 prevTargetPos;

		[NonSerialized]
		public CameraDriver currentDriver;

		[NonSerialized]
		public bool isInputDisabled;

		[NonSerialized]
		public bool camRotated45;

		[NonSerialized]
		public InputBinding camLockInput;

		[NonSerialized]
		public List<SnapLerpData> snapTicks;

		[NonSerialized]
		public List<CameraProximityTarget> proximityTargets;

		[NonSerialized]
		public bool lockMouseCamEnabled;

		[NonSerialized]
		public DepthOfField depthOfField;

		[NonSerialized]
		public float baseFocusDistance;

		[NonSerialized]
		public float baseFocalLength;

		[NonSerialized]
		public float currentZoom;

		public Camera Cam => null;

		public Transform Target => null;

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void Update()
		{
		}

		public void LateUpdate()
		{
		}

		public void ResetCameraLerp()
		{
		}

		public void ResetDefaultDriver()
		{
		}

		public void SetTopDownDriver()
		{
		}

		public void SetThirdPersonDriver()
		{
		}

		public void SetFPSDriver()
		{
		}

		public void SetVehicleDriver(bool doSnap = true)
		{
		}

		public void SetDriver(CameraDriver driver, bool doSnap = true)
		{
		}

		public void SetTarget(Transform _target)
		{
		}

		public void Snap()
		{
		}

		public void Zoom(float zoomMultiplier)
		{
		}

		public float GetCurrentZoom()
		{
			return 0f;
		}

		public void ResetZoom()
		{
		}

		public void SetFoVMultiplier(float fowMult)
		{
		}

		public virtual Vector3 GetCameraPosition()
		{
			return default(Vector3);
		}

		public void DepthOfFieldAutoFocus()
		{
		}

		public void SetDepthOfFieldFocus(float focusDistance)
		{
		}

		public void AddSnap(int tickNum)
		{
		}

		public void RemoveSnap(int tickNum)
		{
		}

		public bool GetAndPruneSnapTicks(int playbackTickNum)
		{
			return false;
		}

		public void TryAddProximityTarget(CameraProximityTarget target)
		{
		}

		public void TryRemoveProximityTarget(CameraProximityTarget target)
		{
		}
	}
}
