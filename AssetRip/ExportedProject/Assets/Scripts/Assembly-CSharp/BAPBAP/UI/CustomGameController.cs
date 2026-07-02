using BAPBAP.Network;

namespace BAPBAP.UI
{
	public class CustomGameController : ControllerBase
	{
		public CustomGameController(ControllerManager controllerManager)
			: base(null)
		{
		}

		public override void OnLoginComplete(LoadResponse response)
		{
		}

		public void SendJoinTeam(PlayerModel playerModel, int teamId)
		{
		}

		public void SendSwitchReady(bool isReady)
		{
		}

		public void SendUpdateSettings(string accountId, CustomGameSettingsModel settingsModel)
		{
		}

		public void SendStartCustomGame(bool forceStart = false)
		{
		}

		public void HandleSetTeamSuccessResponse(CustomSetTeamResponse response)
		{
		}

		public void HandleSetTeamFailResponse(CustomSetTeamResponse response)
		{
		}

		public void HandleSwitchCustomReadyResponse(SwitchCustomReadySuccessResponse response)
		{
		}

		public void HandleUpdateSettingsSuccessResponse(CustomUpdateSettingsResponse response)
		{
		}

		public void HandleUpdateSettingsFailResponse(CustomUpdateSettingsResponse response)
		{
		}

		public void HandleStartGameSuccess(StartCustomGameSuccessResponse response)
		{
		}

		public void HandleStartGameFail(StartCustomGameFailResponse response)
		{
		}
	}
}
