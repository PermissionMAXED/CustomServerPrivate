using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using NativeWebSocket;

namespace BAPBAP.Network
{
	public class WebSocketClient
	{
		public interface IMessageHandlerCollection
		{
			void Invoke(string json);

			void AddHandler(object handler);
		}

		public class MessageHandlerCollection<T> : IMessageHandlerCollection
		{
			[NonSerialized]
			public readonly List<Action<T>> _handlers;

			public void Invoke(string json)
			{
			}

			public void AddHandler(object handler)
			{
			}
		}

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		public struct _003CConnect_003Ed__7 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public WebSocketClient _003C_003E4__this;

			public string url;

			[NonSerialized]
			public TaskAwaiter _003C_003Eu__1;

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

		[CompilerGenerated]
		public sealed class _003CServiceSocket_003Ed__14 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public WebSocketClient _003C_003E4__this;

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
			public _003CServiceSocket_003Ed__14(int _003C_003E1__state)
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
		public WebSocket _socket;

		[NonSerialized]
		public Cookie _cookie;

		[NonSerialized]
		public readonly bool _outputLogs;

		[NonSerialized]
		public readonly Dictionary<string, IMessageHandlerCollection> _handlers;

		public WebSocketOpenEventHandler OnSocketConnected;

		public WebSocketCloseEventHandler OnSocketDisconnected;

		public WebSocketClient(bool outputLogs)
		{
		}

		[AsyncStateMachine(typeof(_003CConnect_003Ed__7))]
		public void Connect(string url)
		{
		}

		public void Disconnect()
		{
		}

		public void SetCookie(Cookie cookie)
		{
		}

		public void Send(object message)
		{
		}

		public void Send(string @event)
		{
		}

		public void Handle(string @event, Action handler)
		{
		}

		public void Handle<T>(string @event, Action<T> handler)
		{
		}

		[IteratorStateMachine(typeof(_003CServiceSocket_003Ed__14))]
		public IEnumerator ServiceSocket()
		{
			return null;
		}

		public void OnMessage(byte[] message)
		{
		}
	}
}
