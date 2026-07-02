using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BAPBAP.Network;

namespace BAPBAP.UI
{
	public class LoginController : ControllerBase
	{
		[Serializable]
		public class Config
		{
			public float ReloadTimeout;
		}

		[CompilerGenerated]
		public sealed class _003C_003Ec__DisplayClass20_0
		{
			public string @params;

			public string provider;

			public LoginController _003C_003E4__this;

			public string sid;

			public Action<LinkResponse> _003C_003E9__2;

			public void _003CBrowserLoginRoutine_003Eb__0(LinkResponse response)
			{
			}

			public void _003CBrowserLoginRoutine_003Eb__2(LinkResponse response)
			{
			}

			public void _003CBrowserLoginRoutine_003Eb__1(AuthReturnResponse response)
			{
			}
		}

		[CompilerGenerated]
		public sealed class _003C_003Ec__DisplayClass21_0
		{
			public string ticket;

			public LoginController _003C_003E4__this;

			public string sid;

			public void _003CSteamLoginRoutine_003Eb__0(string t)
			{
			}

			public void _003CSteamLoginRoutine_003Eb__1(AuthReturnResponse response)
			{
			}
		}

		[CompilerGenerated]
		public sealed class _003CBrowserLoginRoutine_003Ed__20 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public string provider;

			public LoginController _003C_003E4__this;

			[NonSerialized]
			public _003C_003Ec__DisplayClass20_0 _003C_003E8__1;

			[NonSerialized]
			public string _003CdeviceId_003E5__2;

			[NonSerialized]
			public UriBuilder _003Cbuilder_003E5__3;

			[NonSerialized]
			public float _003CcurrentRetryTimeout_003E5__4;

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
			public _003CBrowserLoginRoutine_003Ed__20(int _003C_003E1__state)
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
		public sealed class _003CGuestLoginRoutine_003Ed__22 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public LoginController _003C_003E4__this;

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
			public _003CGuestLoginRoutine_003Ed__22(int _003C_003E1__state)
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
		public sealed class _003CSteamLoginRoutine_003Ed__21 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public LoginController _003C_003E4__this;

			[NonSerialized]
			public _003C_003Ec__DisplayClass21_0 _003C_003E8__1;

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
			public _003CSteamLoginRoutine_003Ed__21(int _003C_003E1__state)
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

		public const string SESSION_ID_KEY = "SESSION_ID";

		public const string AUTO_LOGIN_KEY = "AUTO_LOGIN";

		[NonSerialized]
		public readonly Config _config;

		[NonSerialized]
		public float _lastReloadTime;

		public string SessionId
		{
			get
			{
				return null;
			}
			set
			{
			}
		}

		public bool AutoLogin
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public LoginController(Config config, ControllerManager controllerManager)
			: base(null)
		{
		}

		public void StartLoginFlow()
		{
		}

		public void TriggerReload()
		{
		}

		public void LoginGoogle()
		{
		}

		public void LoginDiscord()
		{
		}

		public void LoginFacebook()
		{
		}

		public void LoginSteam()
		{
		}

		public void LoginGuest()
		{
		}

		public void LinkTwitch()
		{
		}

		public void Logout()
		{
		}

		[IteratorStateMachine(typeof(_003CBrowserLoginRoutine_003Ed__20))]
		public IEnumerator BrowserLoginRoutine(string provider)
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CSteamLoginRoutine_003Ed__21))]
		public IEnumerator SteamLoginRoutine()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGuestLoginRoutine_003Ed__22))]
		public IEnumerator GuestLoginRoutine()
		{
			return null;
		}

		public void SendLoadRequest()
		{
		}

		public void SendInviteCodeValidate(string inviteCode)
		{
		}

		public void HandleLoadResponse(LoadResponse response)
		{
		}

		public void HandleUpdateAvailableCharacterList(int[] availableCharacters, bool forceUpdate)
		{
		}

		public void UpdateCookie(string sid)
		{
		}

		public void HandleChallengeTwitchLinkingResponse(string username)
		{
		}

		public void UpdateLoadoutData(LoadResponse response)
		{
		}

		public void HandleLogoutResponse(LogoutResponse response)
		{
		}

		public void HandleOpenLoginWindow()
		{
		}

		public void HandleCompleteLoginRequest(string username)
		{
		}

		public void SendCompleteRequest(string username)
		{
		}

		public void HandleCompleteResponse(CompleteResponse response, string username)
		{
		}

		public void HandleCompleteFailResponse(ErrorResponse response)
		{
		}

		public void HandleInviteCodeFailResponse(ErrorResponse error)
		{
		}

		public void HandleInviteCodeSuccessResponse(LoadResponse.InviteCode response)
		{
		}
	}
}
