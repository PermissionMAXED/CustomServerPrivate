using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading;
using BAPBAP.Game;
using UnityEngine;
using UnityEngine.Networking;

namespace BAPBAP.Network
{
	public class WebServer : MonoBehaviour
	{
		public enum RequestType
		{
			None = 0,
			Mgd = 1,
			Mtd = 2,
			Rgd = 3,
			Qmd = 4
		}

		[CompilerGenerated]
		public sealed class _003CPingLoop_003Ed__34 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public WebServer _003C_003E4__this;

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
			public _003CPingLoop_003Ed__34(int _003C_003E1__state)
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
		public sealed class _003CPollStartMatch_003Ed__27 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public WebServer _003C_003E4__this;

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
			public _003CPollStartMatch_003Ed__27(int _003C_003E1__state)
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
		public sealed class _003CSendDoublePing_003Ed__35 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public WebServer _003C_003E4__this;

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
			public _003CSendDoublePing_003Ed__35(int _003C_003E1__state)
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
		public sealed class _003CSendGameEndedDataAsync_003Ed__32 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public WebServer _003C_003E4__this;

			public UnityGameData gameData;

			[NonSerialized]
			public int _003CreqId_003E5__2;

			[NonSerialized]
			public UnityWebRequest _003Creq_003E5__3;

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
			public _003CSendGameEndedDataAsync_003Ed__32(int _003C_003E1__state)
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
		public sealed class _003CSendPing_003Ed__33 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public WebServer _003C_003E4__this;

			public string endPoint;

			[NonSerialized]
			public int _003CreqId_003E5__2;

			[NonSerialized]
			public UnityWebRequest _003Creq_003E5__3;

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
			public _003CSendPing_003Ed__33(int _003C_003E1__state)
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
		public sealed class _003CSendTeamEndedDataAsync_003Ed__31 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public WebServer _003C_003E4__this;

			public UnityTeamData teamData;

			[NonSerialized]
			public int _003CreqId_003E5__2;

			[NonSerialized]
			public UnityWebRequest _003Creq_003E5__3;

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
			public _003CSendTeamEndedDataAsync_003Ed__31(int _003C_003E1__state)
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

		[SerializeField]
		public NetworkConfig _networkConfig;

		[NonSerialized]
		public string _internalApiEndpoint;

		[NonSerialized]
		public string _matchmakingEndpoint;

		[NonSerialized]
		public HttpListener _listener;

		[NonSerialized]
		public Thread _listenerThread;

		[NonSerialized]
		public string _secretHeader;

		[NonSerialized]
		public string _secret;

		[NonSerialized]
		public int _listenPort;

		[NonSerialized]
		public int _sendReqId;

		[NonSerialized]
		public int _recvReqId;

		[NonSerialized]
		public ConcurrentQueue<MatchmakingGameData> _mgdReceiveBuffer;

		[NonSerialized]
		public ConcurrentDictionary<int, MatchmakingGameDataResponse> _mgdResponseBuffer;

		[NonSerialized]
		public ConcurrentQueue<MatchmakingTeamData> _mtdReceiveBuffer;

		[NonSerialized]
		public ConcurrentDictionary<int, MatchmakingTeamDataResponse> _mtdResponseBuffer;

		[NonSerialized]
		public ConcurrentQueue<ResetGameData> _rgdReceiveBuffer;

		[NonSerialized]
		public ConcurrentDictionary<int, ResetGameDataResponse> _rgdResponseBuffer;

		[NonSerialized]
		public ConcurrentQueue<QueueMatchedData> _qmdReceiveBuffer;

		[NonSerialized]
		public ConcurrentDictionary<int, QueueMatchedDataResponse> _qmdResponseBuffer;

		[NonSerialized]
		public Stopwatch _stopwatchThread;

		[NonSerialized]
		public Stopwatch _stopwatchMain;

		[NonSerialized]
		public WaitForSeconds _pollWait;

		[NonSerialized]
		public GameNetworkManager _gameNetworkManager;

		[NonSerialized]
		public GameManager _gameManager;

		public void PreAwake(int listenPort)
		{
		}

		public void Awake()
		{
		}

		public void StartWebserver(GameManager gameManager)
		{
		}

		[IteratorStateMachine(typeof(_003CPollStartMatch_003Ed__27))]
		public IEnumerator PollStartMatch()
		{
			return null;
		}

		public void StopWebServer()
		{
		}

		public void StartHttpListener()
		{
		}

		public void ListenerCallback(IAsyncResult result)
		{
		}

		[IteratorStateMachine(typeof(_003CSendTeamEndedDataAsync_003Ed__31))]
		public IEnumerator SendTeamEndedDataAsync(UnityTeamData teamData)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CSendGameEndedDataAsync_003Ed__32))]
		public IEnumerator SendGameEndedDataAsync(UnityGameData gameData)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CSendPing_003Ed__33))]
		public IEnumerator SendPing(string endPoint)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CPingLoop_003Ed__34))]
		public IEnumerator PingLoop()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CSendDoublePing_003Ed__35))]
		public IEnumerator SendDoublePing()
		{
			return null;
		}
	}
}
