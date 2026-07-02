using System;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.Content
{
	[Serializable]
	public class PlayerBanner : Content
	{
		public GameObject visualizerPrefab;

		public float customDisplayScale;

		public bool isVaulted;

		public Rarity rarity;

		public TierType tierType;

		public Vector2 avatarUvOffset;

		public Vector2 avatarUvScale;

		[Tooltip("Should this banner use a custom config? Note that this will act in the same way a custom visualizer would, overriding any tier configuration.")]
		public bool useCustomConfig;

		[ConditionalHide("useCustomConfig", true)]
		public PlayerBannerData.PlayerBannerConfig customConfig;

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
