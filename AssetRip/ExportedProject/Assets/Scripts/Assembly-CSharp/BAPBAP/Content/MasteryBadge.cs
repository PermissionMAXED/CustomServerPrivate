using System;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.Content
{
	[Serializable]
	public class MasteryBadge : Emote
	{
		public enum BadgeTier
		{
			Emerald = 0,
			Sapphire = 1
		}

		public GameObject visualizerPrefab;

		public MasteryBadgeData.MasteryTierType tierType;

		public BadgeTier badgeTier;

		public int masteryCharId;

		public bool SDFOutline;

		public override Rarity GetRarity()
		{
			return default(Rarity);
		}

		public override int GetTierTypeId()
		{
			return 0;
		}

		public override Color GetTierTypeColor()
		{
			return default(Color);
		}

		public override string GetTierTypeTranslationKey()
		{
			return null;
		}

		public override Sprite GetDisplaySprite()
		{
			return null;
		}

		public override float GetDisplayScale()
		{
			return 0f;
		}

		public override void InitializeSpawnedVisualizer(GameObject spawnedVisObj)
		{
		}

		public override void InitializeUIDisplay(Image displayImage, bool allowVisualizeSpawn = true)
		{
		}

		public override GameObject GetSpawnableVisualizer()
		{
			return null;
		}

		public override bool IsContentEquipable()
		{
			return false;
		}
	}
}
