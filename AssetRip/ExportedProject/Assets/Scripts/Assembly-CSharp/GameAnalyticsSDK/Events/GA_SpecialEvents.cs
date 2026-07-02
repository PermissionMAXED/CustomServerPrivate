using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

namespace GameAnalyticsSDK.Events
{
	public class GA_SpecialEvents : MonoBehaviour
	{
		[CompilerGenerated]
		public sealed class _003CCheckCriticalFPSRoutine_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public GA_SpecialEvents _003C_003E4__this;

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
			public _003CCheckCriticalFPSRoutine_003Ed__8(int _003C_003E1__state)
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
		public sealed class _003CSubmitFPSRoutine_003Ed__7 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

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
			public _003CSubmitFPSRoutine_003Ed__7(int _003C_003E1__state)
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

		public static int _frameCountAvg;

		public static float _lastUpdateAvg;

		[NonSerialized]
		public int _frameCountCrit;

		[NonSerialized]
		public float _lastUpdateCrit;

		public static int _criticalFpsCount;

		public static int _fpsWaitTimeMultiplier;

		public void Start()
		{
		}

		[IteratorStateMachine(typeof(_003CSubmitFPSRoutine_003Ed__7))]
		public IEnumerator SubmitFPSRoutine()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CCheckCriticalFPSRoutine_003Ed__8))]
		public IEnumerator CheckCriticalFPSRoutine()
		{
			return null;
		}

		public void Update()
		{
		}

		public static void SubmitFPS()
		{
		}

		public void CheckCriticalFPS()
		{
		}
	}
}
