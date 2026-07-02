using System;
using UnityEngine;

namespace BAPBAP.Local
{
	public class GM_UniqueItemChance : GameModifier
	{
		[Serializable]
		public class Config : GameModifierConfiguration
		{
			[Header("Custom Config")]
			public float additiveUniqueChanceMult;
		}

		[NonSerialized]
		public Config config;

		public GM_UniqueItemChance(Config _config = null)
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
