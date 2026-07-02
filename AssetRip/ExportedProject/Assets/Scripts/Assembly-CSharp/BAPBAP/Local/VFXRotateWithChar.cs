using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class VFXRotateWithChar : MonoBehaviour
	{
		public Transform target;

		[NonSerialized]
		public float rotationLockDelay;

		[NonSerialized]
		public float time;

		[NonSerialized]
		public bool done;

		public void OnEnable()
		{
		}

		public void SetTarget(Transform targetToFollow, float snapDelay)
		{
		}

		public void LateUpdate()
		{
		}
	}
}
