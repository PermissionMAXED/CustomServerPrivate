using BAPBAP.Network;

namespace BAPBAP.UI
{
	public class FriendsController : ControllerBase
	{
		public FriendsController(ControllerManager controllerManager)
			: base(null)
		{
		}

		public override void OnLoginComplete(LoadResponse response)
		{
		}

		public void SendFriendInviteLobby(string accountId, string lobbyId)
		{
		}

		public void SendFriendJoinLobby(string accountId)
		{
		}

		public void SendSwitchLobbyOpen(bool lobbyOpenStatus)
		{
		}

		public void SendFriendSendRequestRequest(string username, int discriminator)
		{
		}

		public void SendFriendRequestAcceptRequest(string accountId)
		{
		}

		public void SendFriendRequestDeclineRequest(string accountId)
		{
		}

		public void SendFriendRemoveRequest(string accountId)
		{
		}

		public void SendOpenFriendRequestsRequest(bool isEnabled)
		{
		}

		public void SendFriendsRequestsRequest()
		{
		}

		public void HandleSendFriendSendRequestSuccess(string usernameId)
		{
		}

		public void HandleSendFriendSendRequestFail(string errorStr)
		{
		}

		public void HandleSendFriendRequestAcceptRequest(string accountId)
		{
		}

		public void HandleSendFriendRequestDeclineRequest(string accountId)
		{
		}

		public void HandleFriendsRequestResponse(FriendsRequestsResponse response)
		{
		}

		public void HandleSetFriendResponse(SetFriendsResponse response)
		{
		}

		public void HandleFriendStatusResponse(FriendStatusResponse response)
		{
		}

		public void HandleUpdateLobbyPlayerCountResponse(UpdatePlayerCountResponse response)
		{
		}

		public void HandleSwitchFriendLobbyOpenResponse(SwitchFriendLobbyOpenResponse response)
		{
		}

		public void HandleFriendGameStartResponse(FriendGameTimeResponse response)
		{
		}

		public void HandleFriendGameEndResponse(FriendGameTimeResponse response)
		{
		}

		public void HandleFriendRemovedResponse(FriendRemovedResponse response)
		{
		}

		public void HandleSetFriendRequestsResponse(SetFriendRequestsResponse response)
		{
		}

		public void HandleUpdateFriendRequestsResponse(UpdateFriendRequestsResponse response)
		{
		}
	}
}
