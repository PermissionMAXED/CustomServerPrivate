using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using UnityEngine;

namespace BAPBAP.Local
{
	public class AnalyticsManager : MonoBehaviour
	{
		public enum UIEventAction
		{
			Click = 0
		}

		public enum UIEventSection
		{
			Nav = 0,
			Play = 1,
			BP = 2,
			Rankings = 3,
			Locker = 4,
			Characters = 5,
			Mastery = 6,
			Profile = 7,
			Settings = 8,
			GameMode = 9,
			Friends = 10
		}

		public enum UIEventElement
		{
			Logo = 0,
			PlayTab = 1,
			BPTab = 2,
			RankingsTab = 3,
			LockerTab = 4,
			ProfileTab = 5,
			CharactersTab = 6,
			LoginButton = 7,
			DiscordButton = 8,
			MuteButton = 9,
			FullscreenButton = 10,
			SettingsButton = 11,
			SteamButton = 12,
			ReadyButton = 13,
			UnreadyButton = 14,
			CancelButton = 15,
			GameModeButton = 16,
			InviteButton = 17,
			ProfileButton = 18,
			StoreTab = 19,
			TwitterButton = 20,
			FractalsButton = 21
		}

		[CompilerGenerated]
		public sealed class _003CCheckPerformanceStartup_003Ed__8 : IEnumerator<object>, IEnumerator, IDisposable
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
			public _003CCheckPerformanceStartup_003Ed__8(int _003C_003E1__state)
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
		public struct _003CSetupAnalytics_003Ed__4 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncVoidMethodBuilder _003C_003Et__builder;

			public AnalyticsManager _003C_003E4__this;

			public int totalGames;

			public string accountId;

			public bool isGuest;

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
		public struct _003CSetupUnityAnalytics_003Ed__6 : IAsyncStateMachine
		{
			public int _003C_003E1__state;

			public AsyncTaskMethodBuilder _003C_003Et__builder;

			public AnalyticsManager _003C_003E4__this;

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
		public int totalGames;

		[NonSerialized]
		public bool enableUnityAnalytics;

		[NonSerialized]
		public bool enableGameAnalytics;

		public void Awake()
		{
		}

		[AsyncStateMachine(typeof(_003CSetupAnalytics_003Ed__4))]
		public void SetupAnalytics(string accountId = null, bool isGuest = true, int totalGames = 0)
		{
		}

		public void SetupGameAnalytics(string accountId = null, bool isGuest = true, int totalGames = 0)
		{
		}

		[AsyncStateMachine(typeof(_003CSetupUnityAnalytics_003Ed__6))]
		public Task SetupUnityAnalytics(string accountId = null, bool isGuest = true, int totalGames = 0)
		{
			return null;
		}

		public void SetGamesPlayedDimension()
		{
		}

		[IteratorStateMachine(typeof(_003CCheckPerformanceStartup_003Ed__8))]
		public IEnumerator CheckPerformanceStartup()
		{
			return null;
		}

		public void SendNewUserEvent(bool flush = false)
		{
		}

		public void SendStartupPerfEvent(int fps, bool flush = false)
		{
		}

		public void SendGameReadiedEvent(bool flush = false)
		{
		}

		public void SendGameQueuedEvent(bool flush = false)
		{
		}

		public void SendGameMatchedEvent(bool flush = false)
		{
		}

		public void SendGameStartedEvent(bool flush = false)
		{
		}

		public void SendGameJoinedEvent(bool flush = false)
		{
		}

		public void SendGameEndedEvent(int placement, int squadKills, int kills, bool flush = false)
		{
		}

		public void IncrementGamesPlayedAndSendGamesPlayedEvent(int placement, int squadKills, int kills, bool flush = false)
		{
		}

		public void SendUIEvent(UIEventAction action, UIEventSection section, UIEventElement element, bool flush = false)
		{
		}
	}
}
