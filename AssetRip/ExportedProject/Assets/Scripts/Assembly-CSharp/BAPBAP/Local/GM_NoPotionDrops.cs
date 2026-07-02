using System;

namespace BAPBAP.Local
{
	public class GM_NoPotionDrops : GameModifier
	{
		[Serializable]
		public class Config : GameModifierConfiguration
		{
		}

		[NonSerialized]
		public Config config;

		public GM_NoPotionDrops(Config _config = null)
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
