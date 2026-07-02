using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace BAPBAP.Local
{
	public class AudioPlayIntervals : MonoBehaviour
	{
		[CompilerGenerated]
		public sealed class _003CStopAfter_003Ed__13 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public float delay;

			public AudioPlayIntervals _003C_003E4__this;

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
			public _003CStopAfter_003Ed__13(int _003C_003E1__state)
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
		public bool playOnStart;

		[Header("References")]
		[SerializeField]
		public AudioSource audioSource;

		[Header("Clips")]
		[SerializeField]
		public AudioClip[] clips;

		[Header("Settings")]
		[Tooltip("Play the clips in sequential order, with a random start point")]
		[SerializeField]
		public bool randomSequentialClips;

		[SerializeField]
		public float interval;

		[SerializeField]
		public float destroyDelay;

		[NonSerialized]
		public int randomClipId;

		[NonSerialized]
		public float timer;

		public void Start()
		{
		}

		public void DoStart()
		{
		}

		public void Update()
		{
		}

		public void Play()
		{
		}

		public void DoDestroy()
		{
		}

		[IteratorStateMachine(typeof(_003CStopAfter_003Ed__13))]
		public IEnumerator StopAfter(float delay)
		{
			return null;
		}

		public void Stop()
		{
		}
	}
}
