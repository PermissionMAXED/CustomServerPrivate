using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BAPBAP.Localisation;
using BAPBAP.Network;

namespace BAPBAP.UI
{
	public class LobbyController : ControllerBase
	{
		[CompilerGenerated]
		public sealed class _003CCountUpElapsedTime_003Ed__69 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public LobbyController _003C_003E4__this;

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
			public _003CCountUpElapsedTime_003Ed__69(int _003C_003E1__state)
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
		public string _lobbyIsAlreadyFullStr;

		[NonSerialized]
		public string _lobbyWasInvalidStr;

		[NonSerialized]
		public string _kickedStr;

		[NonSerialized]
		public string _youJoinedTheLobbyStr;

		[NonSerialized]
		public string _joinedTheLobbyStr;

		[NonSerialized]
		public string _leftTheLobbyStr;

		[NonSerialized]
		public string _loginRequiredStr;

		public LobbyController(ControllerManager controllerManager)
			: base(null)
		{
		}

		public override void OnLocalise(Translator translator)
		{
		}

		public override void OnLoginComplete(LoadResponse response)
		{
		}

		public void SwitchGameMode(int id)
		{
		}

		public void SwitchGameModeWithPassword(int id, string password)
		{
		}

		public void ReadyMatchmaking()
		{
		}

		public void UnreadyMatchmaking()
		{
		}

		public void CancelMatchmaking()
		{
		}

		public void JoinLobby(string lobbyId, bool isInvite)
		{
		}

		public void KickTeammate(string accountId)
		{
		}

		public void CloseParty(bool isEnabled)
		{
		}

		public void SendSteamInvite(ulong steamId)
		{
		}

		public void HandleSteamInviteAccept(object sender, string lobbyId)
		{
		}

		public void GetInviteLink()
		{
		}

		public void CopyUsername()
		{
		}

		public void SendAccountPassRequest()
		{
		}

		public void SendCharTokensPassRequest()
		{
		}

		public void SendCharMasteryPreviewRequest()
		{
		}

		public void SendCharListingsRequest()
		{
		}

		public void SendDailyRewardRequest()
		{
		}

		public void HandleAccountPassPassResponse(PassResponse response)
		{
		}

		public void HandleCharTokensPassResponse(PassResponse response)
		{
		}

		public void HandleCharMasteryPreviewResponse(CharMasteryPreviewResponse response)
		{
		}

		public void HandleCharListingResponse(CharListingResponse response)
		{
		}

		public void HandleDailyRewardResponse(DailyResponse response)
		{
		}

		public void HandleSocketReadyMessage(SocketReadyMessage msg)
		{
		}

		public void HandleDuplicateConnectionMessage(DuplicateConnectionMessage msg)
		{
		}

		public void HandleJoinLobbySuccessMessage(JoinLobbySuccessMessage message)
		{
		}

		public void HandleJoinLobbyFailMessage(JoinLobbyFailMessage message)
		{
		}

		public void HandleLobbyJoinedMessage(LobbyJoinedMessage msg)
		{
		}

		public void HandleLobbyLeftMessage(LobbyLeftMessage msg)
		{
		}

		public void HandleSwitchGameModeSuccessMessage(SwitchGameModeSuccessMessage msg)
		{
		}

		public void HandleSwitchGameModeFailMessage(SwitchGameModeFailMessage msg)
		{
		}

		public void HandleGameModeUpdatedMessage(GameModeUpdatedMessage msg)
		{
		}

		public void HandleGameModesUpdatedMessage(GameModesUpdatedMessage message)
		{
		}

		public void HandleSwitchReadySuccessMessage(SwitchReadySuccessMessage msg)
		{
		}

		public void HandleSwitchReadyFailMessage(SwitchReadyFailMessage msg)
		{
		}

		public void HandleReadyUpdatedMessage(ReadyUpdatedMessage msg)
		{
		}

		public void HandleInviteLobbyResponse(InviteLobbyResponse response)
		{
		}

		public void HandleJoinFriendLobbySuccessResponse(JoinFriendLobbySuccessResponse response)
		{
		}

		public void HandleJoinFriendLobbyFailMessage(JoinLobbyFailMessage message)
		{
		}

		public void SendJoinLobbyMessage(string id, bool isInvite)
		{
		}

		public void HandlePlayersOnlineUpdatedMessage(PlayersOnlineUpdatedMessage message)
		{
		}

		public void HandleLiveFeedInitializedMessage(LiveFeedInitializedMessage message)
		{
		}

		public void HandleLiveFeedUpdatedMessage(LiveFeedUpdatedMessage message)
		{
		}

		public void HandleCharRotationUpdatedMessage(CharRotationUpdatedMessage message)
		{
		}

		public void HandlePlayerBannerUpdateResponse(BannerUpdatedResponse response)
		{
		}

		public void HandlePlayerLevelUpdateResponse(LevelUpdatedResponse response)
		{
		}

		public void SendSwitchGameModeMessage(int id, string password = "")
		{
		}

		public void SendSwitchReady(bool isReady)
		{
		}

		public void SendCancelMatchmaking()
		{
		}

		public void SendKickTeammateRequest(string accountId)
		{
		}

		public void SendSetClosedPartyRequest(bool isEnabled)
		{
		}

		public void SendSocketRequest()
		{
		}

		public void SendInternalServersRequest()
		{
		}

		public void HandleLobbySocketResponse(LobbySocketResponse response)
		{
		}

		public void HandleLobbySocketResponseError(ErrorResponse response)
		{
		}

		public void HandleInternalServersResponse(InternalServersResponse res)
		{
		}

		public void HandleLobbyOpenResponse(SwitchLobbyOpenSuccessResponse response)
		{
		}

		public void UpdatePlayTabData(LobbyData lobbyData)
		{
		}

		public void AddPlayerInPlayTabData(PlayerData player)
		{
		}

		public void RemovePlayerInPlayTabData(string accountId, string newLeaderAccountId)
		{
		}

		[IteratorStateMachine(typeof(_003CCountUpElapsedTime_003Ed__69))]
		public IEnumerator CountUpElapsedTime()
		{
			return null;
		}
	}
}
