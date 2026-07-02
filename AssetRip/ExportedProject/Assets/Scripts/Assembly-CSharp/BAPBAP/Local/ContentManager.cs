using System;
using BAPBAP.Content;
using UnityEngine;

namespace BAPBAP.Local
{
	public class ContentManager : MonoBehaviour
	{
		[Serializable]
		public class ContentGroup
		{
			public ContentSO[] group;
		}

		[Header("References")]
		[SerializeField]
		public ContentConfiguration contentConfig;

		[SerializeField]
		public EmoteData emoteData;

		[SerializeField]
		public TombstoneData tombstoneData;

		[SerializeField]
		public PlayerBannerData playerBannerData;

		[SerializeField]
		public CurrencyData currencyData;

		[SerializeField]
		public MasteryBadgeData masteryBadgeData;

		[SerializeField]
		public SkinData skinData;

		[SerializeField]
		[Header("Editor References")]
		public ContentVisualizer3D contentVisualizer3DPrefab;

		public const int assetOffsetSize = 100000;

		public static BAPBAP.Content.Content GetContentFromAssetId(int assetId)
		{
			return null;
		}

		public static int GetAssetIdFromContent(BAPBAP.Content.Content content)
		{
			return 0;
		}

		public static bool AssetIdBelongsToAssetType(int assetId, int assetIdOffset)
		{
			return false;
		}

		public static int GetAssetOffset(int assetId)
		{
			return 0;
		}

		public static bool ContentBelongsToGroup(ContentGroup[] contentGroups, ContentSO target)
		{
			return false;
		}

		public static int GetContentGroupIdFromContent(ContentGroup[] contentGroups, ContentSO contentSO)
		{
			return 0;
		}

		public static BAPBAP.Content.Content GetPreviousContentTierContentOnGroup(ContentGroup contentGroup, BAPBAP.Content.Content content)
		{
			return null;
		}
	}
}
