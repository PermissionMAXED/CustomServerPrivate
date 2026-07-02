using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class RotateTransformZCurve : MonoBehaviour
	{
		public float duration;

		public bool loop;

		public AnimationCurve rotationCurve;

		[NonSerialized]
		public float timer;

		public void Play()
		{
		}

		public void LateUpdate()
		{
		}
	}
}
