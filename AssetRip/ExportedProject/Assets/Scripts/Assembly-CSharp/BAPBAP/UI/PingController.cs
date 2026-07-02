using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace BAPBAP.UI
{
	public class PingController : ControllerBase
	{
		[Serializable]
		public class Config
		{
			public float PingTimeSeconds;
		}

		[CompilerGenerated]
		public sealed class _003CWebsocketPingRoutine_003Ed__2 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public PingController _003C_003E4__this;

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
			public _003CWebsocketPingRoutine_003Ed__2(int _003C_003E1__state)
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
		public readonly Config _config;

		public PingController(Config config, ControllerManager controllerManager)
			: base(null)
		{
		}

		[IteratorStateMachine(typeof(_003CWebsocketPingRoutine_003Ed__2))]
		public IEnumerator WebsocketPingRoutine()
		{
			return null;
		}
	}
}
