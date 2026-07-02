using System;
using UnityEngine;

namespace BAPBAP.Entities.View
{
	public class EntityWheels : MonoBehaviour
	{
		[Serializable]
		public class Wheel
		{
			[ObjectReferencesToString("wheel", true, true)]
			public string name;

			public Transform wheel;

			public Transform wheelHolder;

			public Vector3 rotationAxis;

			[NonSerialized]
			public Quaternion initialRotation;
		}

		[NonSerialized]
		[NonSerialized]
		public bool isMoving;

		[NonSerialized]
		[NonSerialized]
		public Vector3 velocity;

		public Wheel[] wheels;

		public float rotationSpeed;

		[NonSerialized]
		public Vector3 previousPosition;

		public void Start()
		{
		}

		public void FixedUpdate()
		{
		}

		public void StartMoving(Vector3 velocity)
		{
		}

		public void StopMoving()
		{
		}

		public void RotateWheels()
		{
		}

		public void ResetWheels()
		{
		}
	}
}
