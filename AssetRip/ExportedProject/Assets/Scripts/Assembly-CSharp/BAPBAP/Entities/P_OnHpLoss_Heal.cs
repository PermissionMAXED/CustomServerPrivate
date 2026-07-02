using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnHpLoss_Heal : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public GameObject vfxShieldBrokenPrefab;

			public float percentHealDamageTaken;

			public float healMaxAmountPercent;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public int vfxShieldBrokenId;

		public override PassiveConfiguration passiveConfig => null;

		public P_OnHpLoss_Heal(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnImmuneDamageTrigger(int damage)
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
