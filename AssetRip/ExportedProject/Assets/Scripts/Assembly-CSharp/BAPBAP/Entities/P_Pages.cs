using System;

namespace BAPBAP.Entities
{
	public class P_Pages : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
		}

		[NonSerialized]
		public Config config;

		public override PassiveConfiguration passiveConfig => null;

		public P_Pages(EntityManager entityManager, Config config)
			: base(null)
		{
		}
	}
}
