using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace BAPBAP.Local
{
	public class AudioPlay : MonoBehaviour
	{
		[CompilerGenerated]
		public sealed class _003CSpawnDelayed_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public float delay;

			public AudioPlay _003C_003E4__this;

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
			public _003CSpawnDelayed_003Ed__22(int _003C_003E1__state)
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

		[SerializeField]
		public float startDelay;

		[SerializeField]
		public float sourceSizeMultiplier;

		[Header("Cast SFX")]
		[ConditionalInverseHide("doRandomStartSfx", true)]
		[SerializeField]
		public AudioClipData sfxStart;

		[SerializeField]
		public bool doRandomStartSfx;

		[ConditionalHide("doRandomStartSfx", true)]
		[SerializeField]
		public AudioClipData[] randomSfxStart;

		[Header("Follow SFX")]
		[SerializeField]
		public AudioClipData sfxFollow;

		[SerializeField]
		public bool doLoop;

		[SerializeField]
		public bool destroyOnClipDuration;

		[SerializeField]
		public float fadeOutDestroyDuration;

		[SerializeField]
		[Header("Impact SFX")]
		public AudioClipData sfxImpact;

		[SerializeField]
		[Header("Destroy SFX")]
		public AudioClipData sfxDestroy;

		[NonSerialized]
		public bool playOnStart;

		[NonSerialized]
		public GameObject followAudioSourceObj;

		public float StartDelay
		{
			get
			{
				return 0f;
			}
			set
			{
			}
		}

		public bool PlayOnStart
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public void Start()
		{
		}

		public void DoStart()
		{
		}

		public void Spawn()
		{
		}

		[IteratorStateMachine(typeof(_003CSpawnDelayed_003Ed__22))]
		public IEnumerator SpawnDelayed(float delay)
		{
			return null;
		}

		public void DoDestroy(bool doHit)
		{
		}

		public void PlayOnImpact(Vector3 impactPosition)
		{
		}
	}
}
