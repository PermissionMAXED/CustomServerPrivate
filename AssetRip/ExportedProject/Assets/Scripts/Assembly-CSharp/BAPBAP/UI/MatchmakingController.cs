using System;
using BAPBAP.Localisation;
using BAPBAP.Network;

namespace BAPBAP.UI
{
	public class MatchmakingController : ControllerBase
	{
		[NonSerialized]
		public string _queuingStr;

		[NonSerialized]
		public string _inQueueStr;

		[NonSerialized]
		public string _inGameStr;

		[NonSerialized]
		public string _someoneLeftTheTeamStr;

		[NonSerialized]
		public string _gameStartingStr;

		public MatchmakingController(ControllerManager controllerManager)
			: base(null)
		{
		}

		public override void OnLocalise(Translator translator)
		{
		}

		public void HandleMatchmakingEnteredMessage(MatchmakingEnteredMessage msg)
		{
		}

		public void HandleMatchmakingExitedMessage(MatchmakingExitedMessage msg)
		{
		}

		public void HandleMatchmakingErroredMessage(MatchmakingErroredMessage msg)
		{
		}

		public void HandleCancelMatchmakingSuccessMessage(CancelMatchmakingSuccessMessage msg)
		{
		}

		public void HandleCancelMatchmakingFailMessage(CancelMatchmakingFailMessage msg)
		{
		}

		public void SetupPreMatchView(QueueMatchedMessage msg)
		{
		}

		public void HandleQueueMatchedMessage(QueueMatchedMessage msg)
		{
		}

		public void PlayMatchFoundSequence()
		{
		}

		public void HandleQueueUpdatedMessage(QueueUpdatedMessage msg)
		{
		}

		public void HandleQueueExitedMessage(QueueExitedMessage msg)
		{
		}

		public void HandleGameStartedMessage(GameStartedMessage msg)
		{
		}

		public void HandleGameCompletedMessage(GameCompletedMessage msg)
		{
		}

		public void HandleMatchMakingTimeoutFail()
		{
		}

		public void OnMatchMakingStop()
		{
		}

		public void SetupMatchmakingPlayerModels(PlayerData[] mmPlayers)
		{
		}
	}
}
