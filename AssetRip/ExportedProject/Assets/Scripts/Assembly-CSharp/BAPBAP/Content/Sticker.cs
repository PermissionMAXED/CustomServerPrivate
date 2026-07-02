using System;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.Content
{
	[Serializable]
	public class Sticker : Emote
	{
		public GameObject stickerPrefab;

		public TierType stickerTier;

		public bool SDFOutline;

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

		public override GameObject GetSpawnableVisualizer()
		{
			return null;
		}

		public override void InitializeSpawnedVisualizer(GameObject displayObj)
		{
		}

		public override void InitializeUIDisplay(Image displayImage, bool allowVisualizeSpawn = true)
		{
		}
	}
}
