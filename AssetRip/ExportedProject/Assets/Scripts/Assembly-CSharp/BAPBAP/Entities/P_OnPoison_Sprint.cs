using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnPoison_Sprint : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float sprintDuration;

			public float sprintMultiplier;
		}

		[NonSerialized]
		public Config config;

		public override PassiveConfiguration passiveConfig => null;

		public P_OnPoison_Sprint(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnStatusEffectAppliedToEnemyTrigger(int statusEffectId, bool alreadyApplied)
		{
		}
	}
}
