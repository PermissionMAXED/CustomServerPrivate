using System;
using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.Content
{
	[CreateAssetMenu(fileName = "PlayerBannerData", menuName = "BAPBAP/Content/PlayerBanners/PlayerBannerData", order = 1)]
	public class PlayerBannerData : ScriptableObject
	{
		[Serializable]
		public class PlayerBannerConfig
		{
			public Material bannerMaterial;

			public Material borderMaterial;

			public Color borderColor;

			public Color shadowColor;

			public Color textColor;
		}

		[SerializeField]
		[Header("Config")]
		public float defaultDisplayScale;

		[NamedArray(typeof(TierType), 0)]
		public PlayerBannerConfig[] tierConfigs;

		[SerializeField]
		public GameObject defaultPlayerBannerPrefab;

		[InspectorButton("OnTriggerRebuild")]
		[Space(10f)]
		[SerializeField]
		public bool TriggerRebuild;

		[BeginReadOnlyGroup]
		[SerializeField]
		public PlayerBannerSO[] playerBanners;

		[BeginReadOnlyGroup]
		[SerializeField]
		public ContentManager.ContentGroup[] playerBannerGroups;

		public const int assetPlayerBannerOffset = 500000;

		public PlayerBanner GetPlayerBannerByPlayerBannerId(int playerBannerId)
		{
			return null;
		}

		public int GetPlayerBannerIdByPlayerBanner(PlayerBanner playerBanner)
		{
			return 0;
		}

		public int GetPlayerBannerIdByAssetId(int assetId)
		{
			return 0;
		}

		public PlayerBanner GetPlayerBannerByAssetId(int assetId)
		{
			return null;
		}

		public int GetPlayerBannerGroupIdByPlayerBanner(PlayerBanner playerBanner)
		{
			return 0;
		}

		public PlayerBanner GetPreviousPlayerBannerTierPlayerBannerOnContentGroup(PlayerBanner playerBanner)
		{
			return null;
		}

		public static int GetPlayerBannerAssetIdByPlayerBanner(PlayerBanner playerBanner)
		{
			return 0;
		}
	}
}
