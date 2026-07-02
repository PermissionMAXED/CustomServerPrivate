using System;
using BAPBAP.UI;
using UnityEngine;

namespace BAPBAP.Local
{
	public class CameraTopDown : CameraDriver
	{
		[NonSerialized]
		public UIManager uiManager;

		[Header("Positioning")]
		[SerializeField]
		public float baseFov;

		[SerializeField]
		public float pitch;

		[SerializeField]
		public float yHeight;

		[SerializeField]
		public Vector3 posOffset;

		[SerializeField]
		public float smoothTime;

		[SerializeField]
		public float mouseOffsetDistance;

		[SerializeField]
		[Header("Obscurance")]
		public bool checkObscurance;

		[SerializeField]
		public float obscuredPitch;

		[SerializeField]
		public float obscuredPitchTime;

		[SerializeField]
		public float checkObscuranceTickRate;

		[Header("ScrollWheel")]
		[SerializeField]
		public bool doScrollWheel;

		[SerializeField]
		public float outBaseFov;

		[SerializeField]
		public float outPitch;

		[SerializeField]
		public float outYHeight;

		[SerializeField]
		public Vector3 outPosOffset;

		[Min(0.1f)]
		[Header("Proximity Offset")]
		[SerializeField]
		public float proximityZoomWorldRange;

		[NonSerialized]
		public float minBaseFov;

		[NonSerialized]
		public float minPitch;

		[NonSerialized]
		public float minYHeight;

		[NonSerialized]
		public Vector3 minPosOffset;

		[NonSerialized]
		public float dampVelocity1;

		[NonSerialized]
		public Vector3 dampVelocity2;

		[NonSerialized]
		public float currentYHeight;

		[NonSerialized]
		public Vector3 currentPosOffset;

		[NonSerialized]
		public Vector3 mouseOffset;

		[NonSerialized]
		public Vector3 posDampVelocity;

		[NonSerialized]
		public Vector3 camPos;

		[NonSerialized]
		public float zoomMultiplier;

		[NonSerialized]
		public float fovMultiplier;

		[NonSerialized]
		public Vector3 baseOffset;

		[NonSerialized]
		public float invPitch;

		[NonSerialized]
		public float baseOffsetZ;

		[NonSerialized]
		public float currentCamLerpValue;

		[NonSerialized]
		public bool obscured;

		[NonSerialized]
		public float obscuredCurrentTime;

		[NonSerialized]
		public float obscuredLerp;

		[NonSerialized]
		public float lastObscuredCheckTime;

		public float Pitch => 0f;

		public float BaseFov => 0f;

		public void Awake()
		{
		}

		public override void Initialize(CameraController _controller)
		{
		}

		public override void OnDriverEnable()
		{
		}

		public void ResetCameraLerp()
		{
		}

		public void ToggleCheckObscurance()
		{
		}

		public void UpdateObscured()
		{
		}

		public override void OnLateUpdate()
		{
		}

		public override void Snap()
		{
		}

		public override void Zoom(float _zoomMultiplier)
		{
		}

		public override void ResetZoom()
		{
		}

		public override void SetFoVMultiplier(float _fovMultiplier)
		{
		}

		public override Vector3 GetCameraPosition()
		{
			return default(Vector3);
		}

		public void GetProximityTargetAvgOffset(Vector3 sourceWorldPos, out Vector3 avgOffset, out float additiveZoom)
		{
			avgOffset = default(Vector3);
			additiveZoom = default(float);
		}

		public float GetCameraFov()
		{
			return 0f;
		}

		public void CalculateBaseOffset()
		{
		}

		public void CalculateFairCenterMultiplier()
		{
		}

		public Vector3 CalculateMouseOffset()
		{
			return default(Vector3);
		}
	}
}
