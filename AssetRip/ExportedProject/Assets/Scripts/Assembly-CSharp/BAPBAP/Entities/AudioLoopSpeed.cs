using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class AudioLoopSpeed : MonoBehaviour
	{
		[SerializeField]
		public AudioSource audioSource;

		[SerializeField]
		public float minVolume;

		[SerializeField]
		public float maxVolume;

		[SerializeField]
		public float minPitch;

		[SerializeField]
		public float maxPitch;

		[SerializeField]
		public bool factorByDistance;

		[Min(0.001f)]
		[SerializeField]
		[Tooltip("The amount of distance that influences the effect. Lower factor means more sensibility to movement")]
		[ConditionalHide("factorByDistance", true)]
		public float distFactor;

		[SerializeField]
		[Tooltip("How fast to interpolate the audio factor")]
		[Min(0f)]
		public float lerpSpeed;

		[NonSerialized]
		public Vector3 prevPos;

		[NonSerialized]
		public float factor;

		[NonSerialized]
		public bool isEnabled;

		public void Awake()
		{
		}

		public void Activate()
		{
		}

		public void SetFactor(float _factor)
		{
		}

		public void FixedUpdate()
		{
		}

		public void OnEnable()
		{
		}

		public void OnDisable()
		{
		}
	}
}
