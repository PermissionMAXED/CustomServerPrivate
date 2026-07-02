using System;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.Content
{
	[Serializable]
	public class Skin : Content
	{
		[Serializable]
		public class SkinConfig
		{
			public int charId;

			[Tooltip("The net spawnable character prefab for this skin")]
			public GameObject characterPrefab;
		}

		public float customDisplayScale;

		public bool isVaulted;

		public Rarity rarity;

		public GameObject visualizerPrefab;

		public SkinConfig config;

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
