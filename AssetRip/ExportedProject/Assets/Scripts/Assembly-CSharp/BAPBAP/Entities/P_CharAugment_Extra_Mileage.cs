using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_CharAugment_Extra_Mileage : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float ttlMultiplier;

			public float addedTtl;
		}

		[NonSerialized]
		public Config config;

		public override PassiveConfiguration passiveConfig => null;

		public P_CharAugment_Extra_Mileage(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnHitboxSpawned(GameObject hitboxObj, EntityManager entity, int abilityId)
		{
		}
	}
}
