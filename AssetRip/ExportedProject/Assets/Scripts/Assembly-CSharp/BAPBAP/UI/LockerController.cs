using BAPBAP.Network;

namespace BAPBAP.UI
{
	public class LockerController : ControllerBase
	{
		public LockerController(ControllerManager controllerManager)
			: base(null)
		{
		}

		public void SendEquipPlayerBannerRequest(int assetId)
		{
		}

		public void SendEquipSkinRequest(int charId, int assetId)
		{
		}

		public void HandleSkinUpdateResponse(SkinEquipResponse response, int charId, int assetId)
		{
		}
	}
}
