using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class EntityRepeatActivation : EntityActivateBase
	{
		[CompilerGenerated]
		public sealed class _003CRepeatCoroutine_003Ed__5 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public EntityRepeatActivation _003C_003E4__this;

			[NonSerialized]
			public int _003Ci_003E5__2;

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
			public _003CRepeatCoroutine_003Ed__5(int _003C_003E1__state)
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
		public EntityActivateBase[] activations;

		[SerializeField]
		public float timeBetween;

		[SerializeField]
		public int repetitions;

		public override void Activate()
		{
		}

		public void Repeat()
		{
		}

		[IteratorStateMachine(typeof(_003CRepeatCoroutine_003Ed__5))]
		public IEnumerator RepeatCoroutine()
		{
			return null;
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
