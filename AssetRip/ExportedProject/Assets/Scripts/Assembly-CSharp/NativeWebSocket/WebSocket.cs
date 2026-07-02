using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net.WebSockets;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace NativeWebSocket
{
	public class WebSocket : IWebSocket
	{
		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		public struct _003CClose_003Ed__37 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public WebSocket _003C_003E4__this;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		public struct _003CConnect_003Ed__27 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public WebSocket _003C_003E4__this;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		public struct _003CHandleQueue_003Ed__33 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public WebSocket _003C_003E4__this;

			public List<ArraySegment<byte>> queue;

			public WebSocketMessageType messageType;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		public struct _003CReceive_003Ed__36 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public WebSocket _003C_003E4__this;

			[NonSerialized]
			public WebSocketCloseCode _003CcloseCode_003E5__2;

			[NonSerialized]
			public ArraySegment<byte> _003Cbuffer_003E5__3;

			[NonSerialized]
			public ConfiguredTaskAwaitable.ConfiguredTaskAwaiter _003C_003Eu__1;

			[NonSerialized]
			public object _003C_003E7__wrap3;

			[NonSerialized]
			public int _003C_003E7__wrap4;

			[NonSerialized]
			public WebSocketReceiveResult _003Cresult_003E5__6;

			[NonSerialized]
			public MemoryStream _003Cms_003E5__7;

			[NonSerialized]
			public TaskAwaiter<WebSocketReceiveResult> _003C_003Eu__2;

			[NonSerialized]
			public TaskAwaiter _003C_003Eu__3;

			[NonSerialized]
			public object _003C_003Eu__4;

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

		[StructLayout((LayoutKind)3)]
		[CompilerGenerated]
		public struct _003CSendMessage_003Ed__32 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public ArraySegment<byte> buffer;

			public WebSocket _003C_003E4__this;

			public WebSocketMessageType messageType;

			public List<ArraySegment<byte>> queue;

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

		[NonSerialized]
		public Uri uri;

		[NonSerialized]
		public Dictionary<string, string> headers;

		[NonSerialized]
		public List<string> subprotocols;

		[NonSerialized]
		public ClientWebSocket m_Socket;

		[NonSerialized]
		public CancellationTokenSource m_TokenSource;

		[NonSerialized]
		public CancellationToken m_CancellationToken;

		[NonSerialized]
		public readonly object OutgoingMessageLock;

		[NonSerialized]
		public readonly object IncomingMessageLock;

		[NonSerialized]
		public bool isSending;

		[NonSerialized]
		public List<ArraySegment<byte>> sendBytesQueue;

		[NonSerialized]
		public List<ArraySegment<byte>> sendTextQueue;

		[NonSerialized]
		public List<byte[]> m_MessageList;

		public WebSocketState State => default(WebSocketState);

		public event WebSocketOpenEventHandler OnOpen
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event WebSocketMessageEventHandler OnMessage
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event WebSocketErrorEventHandler OnError
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public event WebSocketCloseEventHandler OnClose
		{
			[CompilerGenerated]
			add
			{
			}
			[CompilerGenerated]
			remove
			{
			}
		}

		public WebSocket(string url, Dictionary<string, string> headers = null)
		{
		}

		public WebSocket(string url, string subprotocol, Dictionary<string, string> headers = null)
		{
		}

		public WebSocket(string url, List<string> subprotocols, Dictionary<string, string> headers = null)
		{
		}

		public void CancelConnection()
		{
		}

		[AsyncStateMachine(typeof(_003CConnect_003Ed__27))]
		public Task Connect()
		{
			return null;
		}

		public Task Send(byte[] bytes)
		{
			return null;
		}

		public Task SendText(string message)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CSendMessage_003Ed__32))]
		public Task SendMessage(List<ArraySegment<byte>> queue, WebSocketMessageType messageType, ArraySegment<byte> buffer)
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CHandleQueue_003Ed__33))]
		public Task HandleQueue(List<ArraySegment<byte>> queue, WebSocketMessageType messageType)
		{
			return null;
		}

		public void DispatchMessageQueue()
		{
		}

		[AsyncStateMachine(typeof(_003CReceive_003Ed__36))]
		public Task Receive()
		{
			return null;
		}

		[AsyncStateMachine(typeof(_003CClose_003Ed__37))]
		public Task Close()
		{
			return null;
		}
	}
}
