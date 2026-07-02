using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace BAPBAP.Local
{
	public class AudioPlayChangeVolumeAfterDelay : MonoBehaviour
	{
		[CompilerGenerated]
		public sealed class _003CDelay_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public AudioPlayChangeVolumeAfterDelay _003C_003E4__this;

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
			public _003CDelay_003Ed__7(int _003C_003E1__state)
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
		public float delay;

		[SerializeField]
		public AudioPlay audioPlay;

		[NonSerialized]
		public float originalVolume;

		[SerializeField]
		public float impactVolume;

		public void Start()
		{
		}

		public void OnDisable()
		{
		}

		public void OnEnable()
		{
		}

		[IteratorStateMachine(typeof(_003CDelay_003Ed__7))]
		public IEnumerator Delay()
		{
			return null;
		}
	}
}
