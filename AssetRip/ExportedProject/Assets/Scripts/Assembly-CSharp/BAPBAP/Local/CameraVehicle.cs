using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class CameraVehicle : CameraDriver
	{
		[Serializable]
		public class DriverVehiclePreset
		{
			public float baseFov;

			public float pitch;

			public float yHeight;

			public Vector3 posOffset;

			public float posSmoothTime;

			public float rotSmoothTime;
		}

		[Header("Positioning")]
		[SerializeField]
		public DriverVehiclePreset defaultPreset;

		[SerializeField]
		public DynamicChunkLoader.AreaConfig dynamicLoaderAreaConfig;

		[Header("Look Settings")]
		[SerializeField]
		public float sensitivity;

		[NonSerialized]
		public float baseFov;

		[NonSerialized]
		public float pitch;

		[NonSerialized]
		public float yHeight;

		[NonSerialized]
		public Vector3 posOffset;

		[NonSerialized]
		public float posSmoothTime;

		[NonSerialized]
		public float rotSmoothTime;

		[NonSerialized]
		public bool followTargetRotation;

		[NonSerialized]
		public float horLookRot;

		[NonSerialized]
		public Vector3 posDampVelocity;

		[NonSerialized]
		public Vector3 camPos;

		[NonSerialized]
		public Quaternion camRot;

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

		public void OnValidate()
		{
		}

		public void Awake()
		{
		}

		public override void Initialize(CameraController _controller)
		{
		}

		public void ApplyDefaultPreset()
		{
		}

		public void ApplyPreset(DriverVehiclePreset preset)
		{
		}

		public override void OnDriverEnable()
		{
		}

		public override void OnDriverDisable()
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

		public void CalculateBaseOffset()
		{
		}
	}
}
