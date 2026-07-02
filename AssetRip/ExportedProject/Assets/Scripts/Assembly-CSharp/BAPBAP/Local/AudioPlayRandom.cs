using System;
using BAPBAP.Utilities;
using UnityEngine;

namespace BAPBAP.Local
{
	public class AudioPlayRandom : MonoBehaviour
	{
		[SerializeField]
		[Header("References")]
		public AudioSource audioSource;

		[SerializeField]
		[Header("Clips")]
		public AudioClip[] clips;

		[Header("Settings")]
		[SerializeField]
		public bool playOnce;

		[SerializeField]
		public bool playOnEnable;

		[Tooltip("Only allow to play one clip at a time. If enabled, wont play until the current clip has finished playing.")]
		[SerializeField]
		public bool onlyPlayAtOnce;

		[Tooltip("Play the clips in sequential order, with a random start point")]
		[SerializeField]
		public bool randomSequentialClips;

		[SerializeField]
		public RangeFloat randomIntervals;

		[SerializeField]
		public float volume;

		[SerializeField]
		public float pitchSpread;

		[NonSerialized]
		public int randomClipId;

		[NonSerialized]
		public float currentInterval;

		[NonSerialized]
		public float timer;

		[NonSerialized]
		public float originalPitch;

		public void Awake()
		{
		}

		public void OnEnable()
		{
		}

		public void Update()
		{
		}

		public void Play()
		{
		}

		public float GetRandomIntervalDuration()
		{
			return 0f;
		}
	}
}
