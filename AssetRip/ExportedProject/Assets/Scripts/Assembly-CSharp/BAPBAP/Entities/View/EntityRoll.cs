using System;
using UnityEngine;

namespace BAPBAP.Entities.View
{
	public class EntityRoll : MonoBehaviour
	{
		[SerializeField]
		public Transform ballTransform;

		[SerializeField]
		public float ballRadius;

		[SerializeField]
		public float lerpSpeed;

		[NonSerialized]
		public bool isMoving;

		[NonSerialized]
		public Quaternion targetRotation;

		[NonSerialized]
		public Vector3 lastPosition;

		public void StartRolling(Vector3 pushDir)
		{
		}

		public void StopRolling()
		{
		}

		public void LateUpdate()
		{
		}

		public void OnEnable()
		{
		}

		public void ResetRollTransform()
		{
		}

		public Vector3 ProjectDirectionOnPlane(Vector3 direction, Vector3 normal)
		{
			return default(Vector3);
		}
	}
}
