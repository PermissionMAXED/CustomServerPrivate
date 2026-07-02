using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Text;
using AOT;
using Steamworks;
using UnityEngine;

namespace BAPBAP.Steam
{
	public class SteamManager : MonoBehaviour
	{
		public class SteamFriend
		{
			[NonSerialized]
			public Dictionary<ulong, Texture2D> _avatarCache;

			[NonSerialized]
			public ulong _steamId;

			[NonSerialized]
			public string _personaName;

			[NonSerialized]
			public bool _online;

			public ulong SteamId => 0uL;

			public string PersonaName => null;

			public bool Online => false;

			public SteamFriend(Dictionary<ulong, Texture2D> avatarCache, ulong steamId, string personaName, bool online)
			{
			}

			public void TryGetAvatarTexture(out Texture2D texture)
			{
				texture = null;
			}
		}

		public class SteamAuthTicket
		{
			[NonSerialized]
			public byte[] _buffer;

			[NonSerialized]
			public uint _length;

			[NonSerialized]
			public EResult _result;

			[NonSerialized]
			public HAuthTicket _handle;

			public byte[] Buffer => null;

			public uint Length
			{
				set
				{
				}
			}

			public EResult Result
			{
				get
				{
					return default(EResult);
				}
				set
				{
				}
			}

			public HAuthTicket Handle
			{
				get
				{
					return default(HAuthTicket);
				}
				set
				{
				}
			}

			public string Hex => null;

			public string ByteArrayToHexString(byte[] byteArray)
			{
				return null;
			}
		}

		[CompilerGenerated]
		public sealed class _003CGetAuthTicket_003Ed__35 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public SteamManager _003C_003E4__this;

			public Action<string> callback;

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
			public _003CGetAuthTicket_003Ed__35(int _003C_003E1__state)
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

		public static SteamManager _instance;

		[NonSerialized]
		public bool _initialized;

		[NonSerialized]
		public string _launchLobbyCode;

		[NonSerialized]
		public List<SteamFriend> _friends;

		public const int TICKET_BUFFER_SIZE = 1024;

		public const int AVATAR_LARGE = 184;

		public const int PIXEL_SIZE = 4;

		public const int MAX_COMMAND_LENGTH = 256;

		[NonSerialized]
		public SteamAPIWarningMessageHook_t _warningHook;

		[NonSerialized]
		public Callback<GetAuthSessionTicketResponse_t> _authCallback;

		[NonSerialized]
		public Callback<AvatarImageLoaded_t> _avatarCallback;

		[NonSerialized]
		public Callback<GameRichPresenceJoinRequested_t> _inviteCallback;

		[NonSerialized]
		public Callback<MicroTxnAuthorizationResponse_t> _iapCallback;

		[NonSerialized]
		public SteamAuthTicket _authTicket;

		[NonSerialized]
		public Dictionary<ulong, CSteamID> _friendCache;

		[NonSerialized]
		public Dictionary<ulong, Texture2D> _avatarCache;

		[NonSerialized]
		public byte[] _largeAvatarBuffer;

		public static SteamManager Instance => null;

		public bool Initialized => false;

		public string LaunchLobbyCode => null;

		public List<SteamFriend> Friends => null;

		public event EventHandler<string> OnLobbyInviteAccepted
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

		public event EventHandler<ulong> OnSteamIapAuthorized
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

		public void PreAwake()
		{
		}

		public ulong GetSteamId()
		{
			return 0uL;
		}

		public uint GetAppId()
		{
			return 0u;
		}

		public string GetCurrentGameLanguage()
		{
			return null;
		}

		[IteratorStateMachine(typeof(_003CGetAuthTicket_003Ed__35))]
		public IEnumerator GetAuthTicket(Action<string> callback)
		{
			return null;
		}

		public void DisposeAuthTicket()
		{
		}

		public void LoadSteamFriends()
		{
		}

		public bool InviteFriendToLobby(ulong steamId, string lobbyCode)
		{
			return false;
		}

		public void OnAuthSessionTicketResponse(GetAuthSessionTicketResponse_t response)
		{
		}

		public void OnAvatarImageLoaded(AvatarImageLoaded_t avatar)
		{
		}

		public void OnGameRichPresenceJoinRequested(GameRichPresenceJoinRequested_t request)
		{
		}

		public void OnMicroTxnAuthorizationResponse(MicroTxnAuthorizationResponse_t response)
		{
		}

		public void LoadAvatarIntoTextureCache(ulong steamId, int image)
		{
		}

		public bool TryRegexLobbyCode(string input, out string code)
		{
			code = null;
			return false;
		}

		public void Init()
		{
		}

		public void OnDestroy()
		{
		}

		public void Update()
		{
		}

		[MonoPInvokeCallback(typeof(SteamAPIWarningMessageHook_t))]
		public static void SteamAPIDebugTextHook(int nSeverity, StringBuilder pchDebugText)
		{
		}
	}
}
