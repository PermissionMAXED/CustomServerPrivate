using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class CameraShake : MonoBehaviour
	{
		[Header("Shake")]
		[Tooltip("What's the maximum movement/offset the camera can have? The higher it is, the more impactful the shake will be")]
		[SerializeField]
		public float maxShakeOffset;

		[Tooltip("How fast should the shake be? The higher it is, the faster the shake will be")]
		[SerializeField]
		public float shakeSpeed;

		[Tooltip("The rate at how fast trauma is decaying. Higher values will make shake stop quicker (0 for no decay)")]
		[SerializeField]
		public float traumaDecay;

		[NonSerialized]
		public float trauma;

		[NonSerialized]
		public float perlinNoiseOffset;

		[NonSerialized]
		public Vector3 shakeOffset;

		public float intensityMultiplier;

		[SerializeField]
		[Tooltip("The tweening/easing function for the kick")]
		[Header("Kick")]
		public AnimationCurve kickPowerCurve;

		[SerializeField]
		[Tooltip("How long should the kick be?")]
		public float kickDuration;

		[Tooltip("What's the maximum movement/offset the camera can have? The higher it is, the more impactful the kick will be")]
		[SerializeField]
		public float maxKickOffset;

		[NonSerialized]
		public float kickPower;

		[NonSerialized]
		public Vector3 kickOffset;

		[NonSerialized]
		public float kickElapsed;

		[NonSerialized]
		public Vector3 kickDirection;

		public void LateUpdate()
		{
		}

		public void ResetAllShakes()
		{
		}

		public void ResetShake()
		{
		}

		public void ResetKick()
		{
		}

		public void AddShakeTrauma(float _trauma, bool isTranslation = true, bool isRotational = false)
		{
		}

		public void DoKick(float power, Vector3 normDir)
		{
		}
	}
}
