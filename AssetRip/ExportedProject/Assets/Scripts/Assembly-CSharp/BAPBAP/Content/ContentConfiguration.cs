using UnityEngine;

namespace BAPBAP.Content
{
	[CreateAssetMenu(fileName = "ContentConfiguration", menuName = "BAPBAP/Content/ContentConfiguration", order = 1)]
	public class ContentConfiguration : ScriptableObject
	{
		[Header("Shared Config")]
		[NamedArray(typeof(Rarity), 0)]
		public Color[] rarityColors;

		[NamedArray(typeof(Rarity), 0)]
		public Color[] uiRarityColors;

		[NamedArray(typeof(Rarity), 0)]
		public string[] rarityNames;

		[NamedArray(typeof(Rarity), 0)]
		public string[] rarityTranslationKeys;

		[NamedArray(typeof(TierType), 0)]
		public string[] tierTypesTranslationKeys;

		[NamedArray(typeof(TierType), 0)]
		public Color[] tierTypesColors;

		[Header("Content Translation Keys")]
		public string emoteTranslationKey;

		public string stickerTranslationKey;

		public string animationTranslationKey;

		public string voicelineTranslationKey;

		public string playerBannerTranslationKey;

		public string tombstoneTranslationKey;

		public string currencyTranslationKey;

		public string masteryBadgeTranslationKey;

		public string skinTranslationKey;

		public string GetContentTypeTranslationKey(Content content)
		{
			return null;
		}

		public string GetEmoteTypeNameTranslationKey(Emote emote)
		{
			return null;
		}

		public Color GetRarityColorByRarity(Rarity rarity)
		{
			return default(Color);
		}

		public Color GetUIRarityColorByRarity(Rarity rarity)
		{
			return default(Color);
		}

		public string GetRarityName(Rarity rarity)
		{
			return null;
		}

		public string GetRarityTranslationKey(Rarity rarity)
		{
			return null;
		}

		public string GetTierTypeTranslationKey(TierType tierType)
		{
			return null;
		}

		public Color GetTierTypeColor(TierType tierType)
		{
			return default(Color);
		}
	}
}
