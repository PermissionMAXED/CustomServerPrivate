using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class AnimatedLightIntensity : MonoBehaviour
	{
		[SerializeField]
		public Light _light;

		[SerializeField]
		public float _timeOffset;

		[SerializeField]
		public bool loop;

		[SerializeField]
		[Min(0.01f)]
		public float _duration;

		[SerializeField]
		public AnimationCurve lerpCurve;

		[SerializeField]
		public float _intensityMin;

		[SerializeField]
		public float _intensityMax;

		[NonSerialized]
		public float time;

		public void OnEnable()
		{
		}

		public void Update()
		{
		}
	}
}
