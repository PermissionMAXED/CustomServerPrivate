using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.Content
{
	[CreateAssetMenu(fileName = "PlayerBanner", menuName = "BAPBAP/Content/PlayerBanners/PlayerBanner", order = 1)]
	public class PlayerBannerSO : ContentSO
	{
		public PlayerBanner playerBanner;

		public override Content content => null;
	}
}
