using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class CameraThirdPerson : CameraDriver
	{
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
		public DynamicChunkLoader.AreaConfig dynamicLoaderAreaConfig;

		[Header("Look Settings")]
		[SerializeField]
		public float sensitivity;

		[SerializeField]
		public float rotOffset;

		[NonSerialized]
		public Vector2 lookRot;

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

		public override void OnDriverEnable()
		{
		}

		public override void OnDriverDisable()
		{
		}

		public override void OnCamLockInputPressed()
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
