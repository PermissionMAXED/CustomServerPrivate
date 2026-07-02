using System;
using BAPBAP.Game;
using BAPBAP.UI;
using Mirror;

namespace BAPBAP.Player
{
	public class PlayerChat : NetworkBehaviour
	{
		[NonSerialized]
		public UIManager uiManager;

		[NonSerialized]
		public UIChat uiChat;

		[NonSerialized]
		public GameManager gameManager;

		[NonSerialized]
		public PlayerManager playerManager;

		public void Initialize(PlayerManager _playerManager)
		{
		}

		[Command]
		public void CmdSendMessage(string msgString)
		{
		}

		[ClientRpc]
		public void RpcSendChatMessage(string msgString)
		{
		}

		public void ClSendChatMessage(string msgString, bool preventMsgRichText = true, bool checkProfanity = true)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_CmdSendMessage__String(string msgString)
		{
		}

		public static void InvokeUserCode_CmdSendMessage__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcSendChatMessage__String(string msgString)
		{
		}

		public static void InvokeUserCode_RpcSendChatMessage__String(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static PlayerChat()
		{
		}
	}
}
