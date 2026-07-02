using System;
using BAPBAP.Items;

namespace BAPBAP.Entities
{
	public class P_BuffX_AtkSpeed_Attack : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			public float bonusDmgPerAtkSpeed;

			public float bonusPercentDamagePerAtkSpeed;

			public float flatPercentDamageIncrease;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public float baseAtkSpeed;

		[NonSerialized]
		public float bonusDmg;

		[NonSerialized]
		public float bonusPercentDamage;

		public override PassiveConfiguration passiveConfig => null;

		public P_BuffX_AtkSpeed_Attack(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void ActivatePassive()
		{
		}

		public override void OnStatsChanged(bool added, ItemStat stat)
		{
		}

		public override void DeactivatePassive()
		{
		}
	}
}
