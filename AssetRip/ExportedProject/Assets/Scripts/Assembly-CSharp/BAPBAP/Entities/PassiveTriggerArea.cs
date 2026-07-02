using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class PassiveTriggerArea : NetworkBehaviour
	{
		[CompilerGenerated]
		public sealed class _003CWaitToDestroy_003Ed__6 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public PassiveTriggerArea _003C_003E4__this;

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
			public _003CWaitToDestroy_003Ed__6(int _003C_003E1__state)
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
		public EntityTriggerboxListener entityDetectCollidersHolder;

		[NonSerialized]
		public List<EntityManager> currentChars;

		[SerializeField]
		public PassiveSO passiveToActivate;

		[SerializeField]
		public bool destroyObject;

		public void Awake()
		{
		}

		public void OnEntityEnter(EntityManager entity)
		{
		}

		[IteratorStateMachine(typeof(_003CWaitToDestroy_003Ed__6))]
		public IEnumerator WaitToDestroy()
		{
			return null;
		}

		public void OnEntityExit(EntityManager entity)
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
