using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class AudioFade : MonoBehaviour
	{
		[NonSerialized]
		public AudioSource audioSource;

		public float fadeDuration;

		[NonSerialized]
		public float time;

		public float targetVolume;

		[SerializeField]
		public bool stopAudioSourceOnFinished;

		[NonSerialized]
		public float originalVolume;

		public void Awake()
		{
		}

		public void StartFade(float startingVolume = -1f)
		{
		}

		public void Update()
		{
		}
	}
}
