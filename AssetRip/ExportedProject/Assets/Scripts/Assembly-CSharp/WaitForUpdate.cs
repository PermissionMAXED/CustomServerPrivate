using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class WaitForUpdate : CustomYieldInstruction
{
	public class MainThreadAwaiter : INotifyCompletion
	{
		[NonSerialized]
		public Action continuation;

		public bool IsCompleted { get; set; }

		public void GetResult()
		{
		}

		public void Complete()
		{
		}

		void INotifyCompletion.OnCompleted(Action continuation)
		{
		}
	}

	[CompilerGenerated]
	public sealed class _003CCoroutineWrapper_003Ed__4 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[NonSerialized]
		public int _003C_003E1__state;

		[NonSerialized]
		public object _003C_003E2__current;

		public IEnumerator theWorker;

		public MainThreadAwaiter awaiter;

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
		public _003CCoroutineWrapper_003Ed__4(int _003C_003E1__state)
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

	public override bool keepWaiting => false;

	public MainThreadAwaiter GetAwaiter()
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CCoroutineWrapper_003Ed__4))]
	public static IEnumerator CoroutineWrapper(IEnumerator theWorker, MainThreadAwaiter awaiter)
	{
		return null;
	}
}
