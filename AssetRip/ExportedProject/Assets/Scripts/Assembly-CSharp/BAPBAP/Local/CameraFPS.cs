using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class CameraFPS : CameraDriver
	{
		[SerializeField]
		[Header("Config")]
		public float baseFov;

		[SerializeField]
		public float yHeight;

		[SerializeField]
		public Vector3 posOffset;

		[SerializeField]
		public DynamicChunkLoader.AreaConfig dynamicLoaderAreaConfig;

		[SerializeField]
		[Header("First Person")]
		public float sensitivity;

		[SerializeField]
		public float forwardOffset;

		[SerializeField]
		public float rotOffset;

		[Header("Head Bob Anim")]
		[SerializeField]
		public AnimationCurve headBobYPosCurve;

		[SerializeField]
		public AnimationCurve headBobRotCurve;

		[SerializeField]
		public float movingSpeedMult;

		[SerializeField]
		public float headBobAnimSpeed;

		[SerializeField]
		public float headBobPosIntensity;

		[SerializeField]
		public float headBobRotIntensity;

		[Header("Lateral Rotation Anim")]
		[SerializeField]
		public float lateralRotationLimit;

		[SerializeField]
		public float lateralRotationSpeed;

		[SerializeField]
		public float lateralRotationAimIntensity;

		[SerializeField]
		public float lateralRotationMoveIntensity;

		[NonSerialized]
		public Vector2 lookRot;

		[NonSerialized]
		public float headBobAnimTimer;

		[NonSerialized]
		public float bobMovingFactor;

		[NonSerialized]
		public float lateralRotLerped;

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

		public override Vector3 GetCameraPosition()
		{
			return default(Vector3);
		}
	}
}
