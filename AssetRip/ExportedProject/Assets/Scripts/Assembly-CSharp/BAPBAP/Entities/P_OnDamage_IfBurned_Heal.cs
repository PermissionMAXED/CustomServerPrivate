using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnDamage_IfBurned_Heal : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float healPercent;

			public GameObject vfxReadyPrefab;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public int vfxReadyId;

		public override PassiveConfiguration passiveConfig => null;

		public P_OnDamage_IfBurned_Heal(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnDealtDamageTrigger(EntityManager otherCharManager, int damage, bool isCrit, Vector3 hitDir)
		{
		}

		public override void ClActivatePassive()
		{
		}

		public override void ClDeactivatePassive()
		{
		}
	}
}
