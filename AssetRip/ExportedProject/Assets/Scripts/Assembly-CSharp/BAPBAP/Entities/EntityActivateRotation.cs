using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class EntityActivateRotation : EntityActivateBase
	{
		[CompilerGenerated]
		public sealed class _003CRotateCoroutine_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public EntityActivateRotation _003C_003E4__this;

			[NonSerialized]
			public float _003CstartRotation_003E5__2;

			[NonSerialized]
			public float _003CtargetRotation_003E5__3;

			[NonSerialized]
			public float _003CstartTime_003E5__4;

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
			public _003CRotateCoroutine_003Ed__4(int _003C_003E1__state)
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
		public float rotationTime;

		[SerializeField]
		public float rotationAmount;

		[NonSerialized]
		public bool rotation;

		[ServerCallback]
		public override void Activate()
		{
		}

		[IteratorStateMachine(typeof(_003CRotateCoroutine_003Ed__4))]
		public IEnumerator RotateCoroutine()
		{
			return null;
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
