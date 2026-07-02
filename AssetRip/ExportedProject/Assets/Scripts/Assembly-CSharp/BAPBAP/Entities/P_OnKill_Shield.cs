using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnKill_Shield : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float assistTimerCutoff;

			public int shieldAmount;

			public float shieldDuration;

			public int maxHpAmount;
		}

		[NonSerialized]
		public Config config;

		public override PassiveConfiguration passiveConfig => null;

		public P_OnKill_Shield(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnKillTrigger(EntityManager otherCharManager)
		{
		}

		public override void OnAssistTrigger(EntityManager otherCharManager, float t)
		{
		}

		public override void DeactivatePassive()
		{
		}

		public override void ClDeactivatePassive()
		{
		}
	}
}
