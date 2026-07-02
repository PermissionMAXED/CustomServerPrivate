using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_Aura_DamageReduction : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float startCooldownTime;

			public float baseCooldown;

			public float damageReduction;

			public float auraRange;

			public float tickRate;

			public GameObject spellPrefab;

			[Header("FX")]
			public GameObject vfxFollowPrefab;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public GameObject hitboxObj;

		[NonSerialized]
		public int vfxFollowId;

		public override PassiveConfiguration passiveConfig => null;

		public P_Aura_DamageReduction(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public void SpawnAuraObject()
		{
		}

		public override void ActivatePassive()
		{
		}

		public override void DeactivatePassive()
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
