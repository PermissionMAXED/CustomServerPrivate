using System;

namespace BAPBAP.Entities
{
	public class P_Stats_All : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
		}

		[NonSerialized]
		public Config config;

		public override PassiveConfiguration passiveConfig => null;

		public P_Stats_All(EntityManager entityManager, Config config)
			: base(null)
		{
		}
	}
}
