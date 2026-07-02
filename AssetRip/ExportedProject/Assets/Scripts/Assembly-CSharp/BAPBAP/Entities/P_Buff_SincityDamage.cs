using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_Buff_SincityDamage : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public int extraDamageOnKill;
		}

		[NonSerialized]
		public Config config;

		public override PassiveConfiguration passiveConfig => null;

		public P_Buff_SincityDamage(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void ActivatePassive()
		{
		}
	}
}
