using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class TransformInterpolatedMove : MonoBehaviour
	{
		public Vector3 startPos;

		public Vector3 endPos;

		public float interpolationDuration;

		[NonSerialized]
		public float time;

		public AnimationCurve speedCurve;

		public void OnEnable()
		{
		}

		public void FixedUpdate()
		{
		}
	}
}
