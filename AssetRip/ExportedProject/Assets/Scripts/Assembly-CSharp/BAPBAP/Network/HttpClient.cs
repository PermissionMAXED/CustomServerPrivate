using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Networking;

namespace BAPBAP.Network
{
	public class HttpClient
	{
		[Serializable]
		public class Configuration
		{
			public string scheme;

			public string endpoint;

			public string apiPath;

			public int port;
		}

		[CompilerGenerated]
		public sealed class _003CSendGetRoutine_003Ed__11<TResponse> : IEnumerator<object>, IEnumerator, IDisposable where TResponse : class
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public HttpClient _003C_003E4__this;

			public string path;

			public string parameters;

			public Action<ErrorResponse> errorHandler;

			public Action<TResponse> handler;

			[NonSerialized]
			public Uri _003Curi_003E5__2;

			[NonSerialized]
			public UnityWebRequest _003Cuwr_003E5__3;

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
			public _003CSendGetRoutine_003Ed__11(int _003C_003E1__state)
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

			public void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		public sealed class _003CSendPostRoutine_003Ed__12<TResponse> : IEnumerator<object>, IEnumerator, IDisposable where TResponse : class
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public HttpClient _003C_003E4__this;

			public string path;

			public string parameters;

			public string body;

			public Action<ErrorResponse> errorHandler;

			public Action<TResponse> handler;

			[NonSerialized]
			public Uri _003Curi_003E5__2;

			[NonSerialized]
			public UnityWebRequest _003Cuwr_003E5__3;

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
			public _003CSendPostRoutine_003Ed__12(int _003C_003E1__state)
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

			public void _003C_003Em__Finally1()
			{
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[NonSerialized]
		public readonly MonoBehaviour _coroutineContext;

		[NonSerialized]
		public readonly bool _logs;

		[NonSerialized]
		public readonly UriBuilder _uriBuilder;

		[NonSerialized]
		public Cookie _cookie;

		[NonSerialized]
		public Dictionary<string, string> _responseHeaders;

		public Dictionary<string, string> ResponseHeaders => null;

		public HttpClient(MonoBehaviour coroutineContext, string host, bool logs)
		{
		}

		public void SetCookie(Cookie cookie)
		{
		}

		public void SendGetRequest<TResponse>(string path, Action<TResponse> handler, Action<ErrorResponse> errorHandler = null, string parameters = null) where TResponse : class
		{
		}

		public void SendPostRequest<TResponse>(string path, Action<TResponse> handler, Action<ErrorResponse> errorHandler, string body, string parameters = null) where TResponse : class
		{
		}

		[IteratorStateMachine(typeof(_003CSendGetRoutine_003Ed__11<>))]
		public IEnumerator SendGetRoutine<TResponse>(string path, Action<TResponse> handler, Action<ErrorResponse> errorHandler, string parameters) where TResponse : class
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CSendPostRoutine_003Ed__12<>))]
		public IEnumerator SendPostRoutine<TResponse>(string path, Action<TResponse> handler, Action<ErrorResponse> errorHandler, string body, string parameters) where TResponse : class
		{
			return null;
		}

		public static TResponse DeserializeJsonResponse<TResponse>(string data)
		{
			return default(TResponse);
		}
	}
}
