using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class AudioPitchShift : MonoBehaviour
	{
		[SerializeField]
		public AudioSource audioSource;

		[SerializeField]
		public float pitchStepTime;

		[SerializeField]
		public float pitchStep;

		[NonSerialized]
		public float time;

		[NonSerialized]
		public bool pitchUp;

		public void Start()
		{
		}

		public void Update()
		{
		}
	}
}
