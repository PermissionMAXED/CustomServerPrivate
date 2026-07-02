using System;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.Content
{
	[Serializable]
	public class Tombstone : Content
	{
		public Rarity rarity;

		public GameObject viewPrefab;

		public float customDisplayScale;

		public bool isVaulted;

		public override Rarity GetRarity()
		{
			return default(Rarity);
		}

		public override Sprite GetDisplaySprite()
		{
			return null;
		}

		public override float GetDisplayScale()
		{
			return 0f;
		}

		public override GameObject GetSpawnableVisualizer()
		{
			return null;
		}

		public override void InitializeUIDisplay(Image displayImage, bool allowVisualizeSpawn = true)
		{
		}

		public override bool Is3DVisualizer()
		{
			return false;
		}

		public override ContentVisualizer3D.VisualizerSettings Get3DVisualizerSettings()
		{
			return null;
		}

		public override bool IsContentEquipable()
		{
			return false;
		}
	}
}
