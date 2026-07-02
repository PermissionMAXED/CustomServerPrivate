using System;

namespace BAPBAP.Local
{
	public class GM_AngledMap : GameModifier
	{
		[Serializable]
		public class Config : GameModifierConfiguration
		{
		}

		[NonSerialized]
		public Config config;

		public GM_AngledMap(Config _config = null)
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
