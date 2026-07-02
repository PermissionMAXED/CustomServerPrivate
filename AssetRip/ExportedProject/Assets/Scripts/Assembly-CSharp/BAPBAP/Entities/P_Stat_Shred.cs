using System;

namespace BAPBAP.Entities
{
	public class P_Stat_Shred : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			public float division;
		}

		[NonSerialized]
		public Config config;

		public override PassiveConfiguration passiveConfig => null;

		public P_Stat_Shred(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnHitTrigger(EntityManager entity, HitboxBase hitboxBase, int abilityId)
		{
		}
	}
}
