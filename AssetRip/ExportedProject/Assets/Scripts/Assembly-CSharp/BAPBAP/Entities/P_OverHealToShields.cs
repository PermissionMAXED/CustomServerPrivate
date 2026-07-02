using System;

namespace BAPBAP.Entities
{
	public class P_OverHealToShields : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
		}

		[NonSerialized]
		public Config config;

		public override PassiveConfiguration passiveConfig => null;

		public P_OverHealToShields(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void ActivatePassive()
		{
		}

		public override void DeactivatePassive()
		{
		}
	}
}
