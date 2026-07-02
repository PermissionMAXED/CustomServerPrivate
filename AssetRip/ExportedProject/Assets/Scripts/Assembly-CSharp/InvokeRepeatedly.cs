using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class InvokeRepeatedly : MonoBehaviour
{
	[CompilerGenerated]
	public sealed class _003CInvokeCoroutine_003Ed__2 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[NonSerialized]
		public int _003C_003E1__state;

		[NonSerialized]
		public object _003C_003E2__current;

		public Action invokeAction;

		public float duration;

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
		public _003CInvokeCoroutine_003Ed__2(int _003C_003E1__state)
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

	public void Initialize(Action invokeAction, float duration)
	{
	}

	public void Stop()
	{
	}

	[IteratorStateMachine(typeof(_003CInvokeCoroutine_003Ed__2))]
	public IEnumerator InvokeCoroutine(Action invokeAction, float duration)
	{
		return null;
	}
}
