using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class AudioProximityMusicPlay : MonoBehaviour, IComparable
	{
		[SerializeField]
		[Tooltip("If enabled, this gameobject active state will be set based if the current application is a client or not.")]
		public bool setClientGameObjectActive;

		[Tooltip("Priority for multiple music audio, only the highest priority will play.")]
		[SerializeField]
		[Space(10f)]
		public int priority;

		[Space(10f)]
		[SerializeField]
		public AudioClip musicClip;

		[SerializeField]
		public float volume;

		[SerializeField]
		public float fadeDuration;

		[SerializeField]
		[Tooltip("Once entering the controller range, force an update to make it start playing instantly")]
		public bool enterInstantUpdate;

		[SerializeField]
		public bool loop;

		[Space(10f)]
		[SerializeField]
		[Tooltip("Provide an intro clip instead of fading in the music clip by fadeDuration.")]
		public bool hasIntro;

		[SerializeField]
		[Tooltip("After playing the intro once, dont play it again until this cd time.")]
		[ConditionalHide("hasIntro", true)]
		public float introCd;

		[SerializeField]
		[ConditionalHide("hasIntro", true)]
		public AudioClip introMusicClip;

		[SerializeField]
		[ConditionalHide("hasIntro", true)]
		public float introVolume;

		[ConditionalHide("hasIntro", true)]
		[SerializeField]
		public float introDuration;

		[NonSerialized]
		public float _introCdTimer;

		public bool IsInIntroCd => false;

		public void Start()
		{
		}

		public void SetIntroOnCd()
		{
		}

		public void Update()
		{
		}

		public int CompareTo(object obj)
		{
			return 0;
		}

		public int CompareTo(AudioProximityMusicPlay other)
		{
			return 0;
		}
	}
}
