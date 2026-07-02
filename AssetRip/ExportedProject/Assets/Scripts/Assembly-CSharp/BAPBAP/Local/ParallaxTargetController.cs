using System;
using System.Collections.Generic;
using UnityEngine;

namespace BAPBAP.Local
{
	public class ParallaxTargetController : MonoBehaviour
	{
		public enum Axes
		{
			XY = 0,
			XZ = 1,
			YZ = 2,
			YX = 3,
			ZX = 4,
			ZY = 5
		}

		[Serializable]
		public class ParallaxTarget
		{
			public Transform target;

			public float speed;

			public Vector2 maxRotationOffset;

			public Vector2 maxPositionOffset;

			public Axes axes;

			public Quaternion OriginalRotation { get; set; }

			public Vector3 OriginalPosition { get; set; }
		}

		public float speedMultiplier;

		public Vector2 offsetMultiplier;

		[SerializeField]
		public List<ParallaxTarget> targets;

		public AnimationCurve movementCurve;

		[NonSerialized]
		public Vector2 position;

		public float speedMultiplierTarget;

		public void OnEnable()
		{
		}

		public virtual void OnDisable()
		{
		}

		public void SetMappedMousePosition()
		{
		}

		public void ApplyTransform(ParallaxTarget target, float toX, float toY, float toZ)
		{
		}

		public float CalcToX(ParallaxTarget target)
		{
			return 0f;
		}

		public float CalcToY(ParallaxTarget target)
		{
			return 0f;
		}

		public float CalcToZ(ParallaxTarget target)
		{
			return 0f;
		}

		public void Update()
		{
		}
	}
}
