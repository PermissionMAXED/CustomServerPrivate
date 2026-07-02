using System;
using UnityEngine;

namespace Mirror.Examples.BilliardsPredicted
{
	public class WhiteBallPredicted : NetworkBehaviour
	{
		public LineRenderer dragIndicator;

		public float dragTolerance;

		public Rigidbody rigidBody;

		public float forceMultiplier;

		public float maxForce;

		[NonSerialized]
		public Vector3 startPosition;

		[NonSerialized]
		public bool draggingStartedOverObject;

		public bool MouseToWorld(out Vector3 position)
		{
			position = default(Vector3);
			return false;
		}

		public void Awake()
		{
		}

		[ClientCallback]
		public void Update()
		{
		}

		[ClientCallback]
		public void OnGUI()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
