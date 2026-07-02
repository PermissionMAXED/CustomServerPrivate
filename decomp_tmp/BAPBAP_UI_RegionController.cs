using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using BAPBAP.Network;
using NativeWebSocket;

namespace BAPBAP.UI;

public class RegionController : ControllerBase
{
	[Serializable]
	public class Config
	{
		public int DefaultRegionIndex;

		public RegionConfig[] Regions;
	}

	[Serializable]
	public class RegionConfig
	{
		public string Name;

		public string Id;
	}

	public class PingerRegion
	{
		public WebSocket WebSocket;

		public Stopwatch Stopwatch;

		public int Index;

		public long[] Pings;

		public int AvgPing;

		public bool Done;
	}

	[CompilerGenerated]
	public sealed class <DispatchMessageQueue>d__19 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[NonSerialized]
		public int <>1__state;

		[NonSerialized]
		public object <>2__current;

		public RegionController <>4__this;

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
		public <DispatchMessageQueue>d__19(int <>1__state)
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
	public sealed class <ForceAllDone>d__20 : IEnumerator<object>, IEnumerator, IDisposable
	{
		[NonSerialized]
		public int <>1__state;

		[NonSerialized]
		public object <>2__current;

		public RegionController <>4__this;

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
		public <ForceAllDone>d__20(int <>1__state)
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

	[StructLayout((LayoutKind)3)]
	[CompilerGenerated]
	public struct <StartPinger>d__12 : IAsyncStateMachine
	{
		public int <>1__state;

		public AsyncVoidMethodBuilder <>t__builder;

		public PingerData pinger;

		public RegionController <>4__this;

		[NonSerialized]
		public TaskAwaiter <>u__1;

		private void MoveNext()
		{
		}

		void IAsyncStateMachine.MoveNext()
		{
			//ILSpy generated this explicit interface implementation from .override directive in MoveNext
			this.MoveNext();
		}

		[DebuggerHidden]
		private void SetStateMachine(IAsyncStateMachine stateMachine)
		{
		}

		void IAsyncStateMachine.SetStateMachine(IAsyncStateMachine stateMachine)
		{
			//ILSpy generated this explicit interface implementation from .override directive in SetStateMachine
			this.SetStateMachine(stateMachine);
		}
	}

	public const int MAX_PINGS = 10;

	[NonSerialized]
	public readonly Config _config;

	[NonSerialized]
	public readonly Dictionary<string, PingerRegion> _pingersByRegion;

	[NonSerialized]
	public bool _notified;

	public RegionController(Config config, ControllerManager controllerManager)
		: base(null)
	{
	}

	public override void OnLoginComplete(LoadResponse response)
	{
	}

	public void SwitchRegion(int index)
	{
	}

	public void SendSwitchRegionMessage(string id)
	{
	}

	public override void Dispose()
	{
	}

	[AsyncStateMachine(typeof(<StartPinger>d__12))]
	public void StartPinger(PingerData pinger)
	{
	}

	public WebSocketOpenEventHandler HandleOpen(string regionId)
	{
		return null;
	}

	public WebSocketMessageEventHandler HandleWebSocketMessage(string regionId)
	{
		return null;
	}

	public void HandleRegionUpdatedMessage(RegionUpdatedMessage regionUpdatedMessage)
	{
	}

	public void CheckAndNotifyIfAllPinged()
	{
	}

	public void NotifyAllPinged()
	{
	}

	public void NotifyAllPinged(string bestRegionId)
	{
	}

	[IteratorStateMachine(typeof(<DispatchMessageQueue>d__19))]
	public IEnumerator DispatchMessageQueue()
	{
		return null;
	}

	[IteratorStateMachine(typeof(<ForceAllDone>d__20))]
	public IEnumerator ForceAllDone()
	{
		return null;
	}

	public void CloseSockets()
	{
	}
}
