using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class GM_GoldDropIncrease : GameModifier
	{
		[Serializable]
		public class Config : GameModifierConfiguration
		{
			[Header("Custom Config")]
			public float additiveGoldDropAmountMult;
		}

		[NonSerialized]
		public Config config;

		public GM_GoldDropIncrease(Config _config = null)
		{
		}

		public override void Activate()
		{
		}

		public override void Deactivate()
		{
		}
	}
}
