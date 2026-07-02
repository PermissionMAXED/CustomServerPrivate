using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnPickup_IncreaseHP : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float startCooldownTime;

			public float activeTime;

			public float bonusHpPercent;
		}

		[NonSerialized]
		public Config config;

		public override PassiveConfiguration passiveConfig => null;

		public P_OnPickup_IncreaseHP(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnPickUpTrigger()
		{
		}
	}
}
