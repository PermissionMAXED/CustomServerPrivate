using System;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.Content
{
	[Serializable]
	public class Content
	{
		[ReadOnly]
		public int id;

		[TextArea(1, 1)]
		public string nameTranslationKey;

		[TextArea(1, 2)]
		public string descTranslationKey;

		[SpriteVisualizer]
		public Sprite displayIcon;

		public bool visualizeDoSpawn;

		public bool hasCustomTierType;

		[ConditionalHide("hasCustomTierType", true)]
		public bool includeTierTypeInTitle;

		public bool hasCategory;

		[ConditionalHide("hasCategory", true)]
		public string categoryTranslationKey;

		public virtual Rarity GetRarity()
		{
			return default(Rarity);
		}

		public virtual int GetTierTypeId()
		{
			return 0;
		}

		public virtual Color GetTierTypeColor()
		{
			return default(Color);
		}

		public virtual string GetTierTypeTranslationKey()
		{
			return null;
		}

		public virtual Sprite GetDisplaySprite()
		{
			return null;
		}

		public virtual float GetDisplayScale()
		{
			return 0f;
		}

		public virtual GameObject GetSpawnableVisualizer()
		{
			return null;
		}

		public virtual void InitializeSpawnedVisualizer(GameObject displayInstance)
		{
		}

		public virtual void InitializeUIDisplay(Image displayImage, bool allowVisualizeSpawn = true)
		{
		}

		public virtual bool Is3DVisualizer()
		{
			return false;
		}

		public virtual ContentVisualizer3D.VisualizerSettings Get3DVisualizerSettings()
		{
			return null;
		}

		public virtual string GetTitleTranslationKey()
		{
			return null;
		}

		public virtual string GetDescriptionTranslationKey()
		{
			return null;
		}

		public virtual bool IsContentEquipable()
		{
			return false;
		}
	}
}
