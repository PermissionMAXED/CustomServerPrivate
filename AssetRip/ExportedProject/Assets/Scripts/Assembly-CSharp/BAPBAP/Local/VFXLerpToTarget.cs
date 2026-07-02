using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class VFXLerpToTarget : MonoBehaviour
	{
		public AnimationCurve heightCurve;

		public float heightMultiplier;

		public float lerpSpeed;

		[NonSerialized]
		public Transform target;

		[NonSerialized]
		public Vector2 startingPosition;

		[NonSerialized]
		public Vector3 lastPosition;

		[NonSerialized]
		public float timer;

		public void Awake()
		{
		}

		public void SetTarget(Transform targetToFollow)
		{
		}

		public void LateUpdate()
		{
		}
	}
}
