using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class AnimatedLight : MonoBehaviour
	{
		public class LightBaseInfo
		{
			public float Intensity;

			public Vector3 LocalPosition;

			public Quaternion LocalRotation;

			public Color Color;
		}

		[SerializeField]
		public Light _light;

		[SerializeField]
		public bool _flicker;

		[SerializeField]
		public float _flickerIntensity;

		[SerializeField]
		public float _flickerMinTime;

		[SerializeField]
		public float _flickerMaxTime;

		[SerializeField]
		public float _flickerDuration;

		[SerializeField]
		public bool _animateColor;

		[SerializeField]
		public bool _randomSampleGradient;

		[SerializeField]
		public Gradient _colorGradient;

		[SerializeField]
		public float _colorMinTime;

		[SerializeField]
		public float _colorMaxTime;

		[SerializeField]
		public float _colorPingPongTime;

		[NonSerialized]
		public LightBaseInfo _lightBaseInfo;

		[NonSerialized]
		public bool _isFlickering;

		[NonSerialized]
		public float _lastFlickerTime;

		[NonSerialized]
		public float _nextFlickerTime;

		[NonSerialized]
		public float _flickerTime;

		[NonSerialized]
		public bool _isAnimatingColor;

		[NonSerialized]
		public float _lastColorTime;

		[NonSerialized]
		public float _nextColorTime;

		[NonSerialized]
		public float _colorTime;

		[NonSerialized]
		public float _targetIntensity;

		[NonSerialized]
		public Color _targetColor;

		[NonSerialized]
		public bool _isDimmed;

		[NonSerialized]
		public float _dimTime;

		[NonSerialized]
		public float _undimTime;

		[NonSerialized]
		public float _dimDuration;

		[NonSerialized]
		public float _intensityMultiplier;

		[NonSerialized]
		public float _colorMultiplier;

		public void OnEnable()
		{
		}

		public void Update()
		{
		}

		public void Dim(float duration)
		{
		}

		public void Undim(float duration)
		{
		}

		public void OnDisable()
		{
		}

		public void Restore()
		{
		}
	}
}
