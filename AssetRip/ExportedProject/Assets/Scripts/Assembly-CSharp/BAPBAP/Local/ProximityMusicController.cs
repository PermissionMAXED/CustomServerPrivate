using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace BAPBAP.Local
{
	public class ProximityMusicController : MonoBehaviour
	{
		[CompilerGenerated]
		public sealed class _003CWaitForIntroClip_003Ed__23 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public float duration;

			public AudioSource audioSource;

			public AudioClip audioClip;

			public ProximityMusicController _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CWaitForIntroClip_003Ed__23(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[NonSerialized]
		public AudioManager audioManager;

		[SerializeField]
		public AudioSource musicAudioSource;

		[SerializeField]
		public AudioSource musicAudioSourceExtra;

		[Min(0.1f)]
		[SerializeField]
		public float updateRate;

		[Tooltip("When there is no more music players queued, the duration for the existing player to fade out")]
		[SerializeField]
		public float fadeOutDuration;

		[NonSerialized]
		public float _timer;

		[NonSerialized]
		public bool isEnabled;

		[NonSerialized]
		public AudioProximityMusicPlay _currentPlayer;

		[NonSerialized]
		public Coroutine _currentFadeOut;

		[NonSerialized]
		public Coroutine _currentFadeOutExtra;

		[NonSerialized]
		public IEnumerator _currentIntro;

		[NonSerialized]
		public Coroutine _currentCrossfade;

		[NonSerialized]
		public List<AudioProximityMusicPlay> _musicPlayers;

		public void Awake()
		{
		}

		public void OnTriggerEnter(Collider other)
		{
		}

		public void OnTriggerExit(Collider other)
		{
		}

		public void AddMusicPlayer(AudioProximityMusicPlay musicPlay)
		{
		}

		public void RemoveMusicPlayer(AudioProximityMusicPlay musicPlay)
		{
		}

		public void ReplaceMusicPlayer(AudioProximityMusicPlay targetMusicPlay, AudioProximityMusicPlay replaceMusicPlay)
		{
		}

		public void Update()
		{
		}

		public void Refresh()
		{
		}

		public void StopMusicPlay()
		{
		}

		public void PlayMusicPlayer(AudioProximityMusicPlay newPlayer)
		{
		}

		[IteratorStateMachine(typeof(_003CWaitForIntroClip_003Ed__23))]
		public IEnumerator WaitForIntroClip(AudioSource audioSource, AudioClip audioClip, float duration)
		{
			return null;
		}
	}
}
