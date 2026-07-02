using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class RotateTransformMoveDist : MonoBehaviour
	{
		public float radius;

		public Vector3 axis;

		[NonSerialized]
		public Vector3 lastPosition;

		public void LateUpdate()
		{
		}
	}
}
