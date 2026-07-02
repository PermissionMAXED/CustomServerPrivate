using System;
using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.Content
{
	[CreateAssetMenu(fileName = "MasteryBadgeData", menuName = "BAPBAP/Content/MasteryBadges/MasteryBadgeData", order = 1)]
	public class MasteryBadgeData : ScriptableObject
	{
		public enum MasteryTierType
		{
			I = 0,
			II = 1,
			III = 2
		}

		[Serializable]
		public class TierConfig
		{
			public Color tierColor;

			public string nameTranslationKey;

			public Material badgeMaterial;
		}

		[SerializeField]
		[Header("Config")]
		public float defaultDisplayScale;

		[NamedArray(typeof(MasteryTierType), 0)]
		public TierConfig[] tierConfigs;

		[SerializeField]
		[Space(10f)]
		[InspectorButton("OnTriggerRebuild")]
		public bool TriggerRebuild;

		[SerializeField]
		[BeginReadOnlyGroup]
		public MasteryBadgeSO[] masteryBadges;

		[BeginReadOnlyGroup]
		[SerializeField]
		public ContentManager.ContentGroup[] masteryBadgeGroups;

		public const int assetMasteryBadgeOffset = 600000;

		public MasteryBadge GetMasteryBadgeByMasteryBadgeId(int masteryBadgeId)
		{
			return null;
		}

		public static int GetMasteryBadgeIdByMasteryBadge(MasteryBadge masteryBadge)
		{
			return 0;
		}

		public int GetMasteryBadgeIdByAssetId(int assetId)
		{
			return 0;
		}

		public MasteryBadge GetMasteryBadgeByAssetId(int assetId)
		{
			return null;
		}

		public int GetMasteryBadgeGroupIdByMasteryBadge(MasteryBadge masteryBadge)
		{
			return 0;
		}

		public MasteryBadge GetPreviousMasteryBadgeTierMasteryBadgeOnContentGroup(MasteryBadge masteryBadge)
		{
			return null;
		}

		public static int GetMasteryBadgeAssetIdByMasteryBadge(MasteryBadge masteryBadge)
		{
			return 0;
		}
	}
}
