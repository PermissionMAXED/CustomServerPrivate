using System;
using UnityEngine;

namespace BAPBAP.Content
{
	[Serializable]
	public class Emote : Content
	{
		public float customDisplayScale;

		public bool isVaulted;

		public Rarity rarity;

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

		public override bool IsContentEquipable()
		{
			return false;
		}
	}
}
