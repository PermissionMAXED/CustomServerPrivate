using BAPBAP.Content;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UILobbyPlayerContainer : MonoBehaviour
	{
		[SerializeField]
		public RectTransform rectTransform;

		[SerializeField]
		public Image borderBgImage;

		[SerializeField]
		public Image levelBorderBgImage;

		[SerializeField]
		public Image bannerImage;

		[SerializeField]
		public TMP_Text levelText;

		[SerializeField]
		public TMP_Text playerName;

		[SerializeField]
		public GameObject leaderIcon;

		public void InitializeBanner(PlayerBanner banner, PlayerBannerData playerBannerData)
		{
		}

		public void SetBannerTier(PlayerBannerData.PlayerBannerConfig config)
		{
		}
	}
}
