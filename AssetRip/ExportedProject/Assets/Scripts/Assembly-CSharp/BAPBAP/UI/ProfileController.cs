using BAPBAP.Network;

namespace BAPBAP.UI
{
	public class ProfileController : ControllerBase
	{
		public const string AUTO_LOGIN_KEY = "AUTO_LOGIN";

		public const string SESSION_ID_KEY = "SESSION_ID";

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

		public ProfileController(ControllerManager controllerManager)
			: base(null)
		{
		}

		public override void OnLoginComplete(LoadResponse response)
		{
		}

		public void SendProfileRequest()
		{
		}

		public void SendLogoutRequest()
		{
		}

		public void HandleLogoutResponse(LogoutResponse response)
		{
		}

		public void HandleProfileResponse(ProfileResponse response)
		{
		}

		public void UpdateProfileTabData(ProfileResponse response)
		{
		}

		public void UpdateProfileTabData(LoadResponse response)
		{
		}
	}
}
