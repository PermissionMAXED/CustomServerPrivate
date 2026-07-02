using System;
using BAPBAP.Local;

namespace BAPBAP.Entities
{
	public class P_Stat_Luck : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			public float goldTimer;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public float timeElapsed;

		public override PassiveConfiguration passiveConfig => null;

		public P_Stat_Luck(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void Tick(float fixedDt, Command cmd, bool isResim)
		{
		}
	}
}
