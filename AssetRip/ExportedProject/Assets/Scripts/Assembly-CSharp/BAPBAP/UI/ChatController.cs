using BAPBAP.Network;

namespace BAPBAP.UI
{
	public class ChatController : ControllerBase
	{
		public ChatController(ControllerManager controllerManager)
			: base(null)
		{
		}

		public void SendChatMessage(string msg)
		{
		}

		public void SendWhisperMessage(string accountId, string msg)
		{
		}

		public void HandleSendChatSuccessMessage(SendChatSuccessMessage msg)
		{
		}

		public void HandleSendChatFailMessage(SendChatFailMessage msg)
		{
		}

		public void HandleChatUpdatedMessage(ChatUpdatedMessage message)
		{
		}
	}
}
