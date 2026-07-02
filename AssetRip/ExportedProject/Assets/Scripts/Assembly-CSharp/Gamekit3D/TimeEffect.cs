using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace Gamekit3D
{
	public class TimeEffect : MonoBehaviour
	{
		[CompilerGenerated]
		public sealed class _003CDisableAtEndOfAnimation_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public TimeEffect _003C_003E4__this;

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
			public _003CDisableAtEndOfAnimation_003Ed__4(int _003C_003E1__state)
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

		public Light staffLight;

		[NonSerialized]
		public Animation m_Animation;

		public void Awake()
		{
		}

		public void Activate()
		{
		}

		[IteratorStateMachine(typeof(_003CDisableAtEndOfAnimation_003Ed__4))]
		public IEnumerator DisableAtEndOfAnimation()
		{
			return null;
		}
	}
}
