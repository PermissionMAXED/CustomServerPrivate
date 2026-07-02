using System;

namespace BAPBAP.Entities
{
	public class P_D_Atlantis : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
		}

		[NonSerialized]
		public Config config;

		public override PassiveConfiguration passiveConfig => null;

		public P_D_Atlantis(EntityManager entityManager, Config config)
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
