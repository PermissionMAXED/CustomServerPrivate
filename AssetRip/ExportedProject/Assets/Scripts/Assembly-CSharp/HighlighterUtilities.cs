using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public static class HighlighterUtilities
{
	[CompilerGenerated]
	public sealed class _003CImpulseCurve_003Ed__2 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[NonSerialized]
		public int _003C_003E1__state;

		[NonSerialized]
		public object _003C_003E2__current;

		public Action onStart;

		public AnimationCurve curve;

		public float duration;

		public Action<float> updateValues;

		public Action onEnd;

		[NonSerialized]
		public float _003CelapsedTime_003E5__2;

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
		public _003CImpulseCurve_003Ed__2(int _003C_003E1__state)
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

	[CompilerGenerated]
	public sealed class _003CImpulseGradient_003Ed__3 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[NonSerialized]
		public int _003C_003E1__state;

		[NonSerialized]
		public object _003C_003E2__current;

		public Action onStart;

		public Gradient gradient;

		public float duration;

		public Action<Color> updateValues;

		public Action onEnd;

		[NonSerialized]
		public float _003CelapsedTime_003E5__2;

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
		public _003CImpulseGradient_003Ed__3(int _003C_003E1__state)
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

	[CompilerGenerated]
	public sealed class _003CImpulseLinear_003Ed__1 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[NonSerialized]
		public int _003C_003E1__state;

		[NonSerialized]
		public object _003C_003E2__current;

		public Action onStart;

		public float from;

		public float to;

		public float duration;

		public Action<float> updateValues;

		public Action onEnd;

		[NonSerialized]
		public float _003CelapsedTime_003E5__2;

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
		public _003CImpulseLinear_003Ed__1(int _003C_003E1__state)
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

	[CompilerGenerated]
	public sealed class _003CImpulseSmoothstep_003Ed__0 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[NonSerialized]
		public int _003C_003E1__state;

		[NonSerialized]
		public object _003C_003E2__current;

		public Action onStart;

		public float from;

		public float to;

		public float duration;

		public Action<float> updateValues;

		public Action onEnd;

		[NonSerialized]
		public float _003CelapsedTime_003E5__2;

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
		public _003CImpulseSmoothstep_003Ed__0(int _003C_003E1__state)
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

	[IteratorStateMachine(typeof(_003CImpulseSmoothstep_003Ed__0))]
	public static IEnumerator ImpulseSmoothstep(float from, float to, float duration, Action<float> updateValues, Action onStart = null, Action onEnd = null)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CImpulseLinear_003Ed__1))]
	public static IEnumerator ImpulseLinear(float from, float to, float duration, Action<float> updateValues, Action onStart = null, Action onEnd = null)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CImpulseCurve_003Ed__2))]
	public static IEnumerator ImpulseCurve(AnimationCurve curve, float duration, Action<float> updateValues, Action onStart = null, Action onEnd = null)
	{
		return null;
	}

	[IteratorStateMachine(typeof(_003CImpulseGradient_003Ed__3))]
	public static IEnumerator ImpulseGradient(Gradient gradient, float duration, Action<Color> updateValues, Action onStart = null, Action onEnd = null)
	{
		return null;
	}
}
