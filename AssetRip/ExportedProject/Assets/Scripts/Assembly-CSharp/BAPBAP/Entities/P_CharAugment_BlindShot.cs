using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_CharAugment_BlindShot : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float damageMultiplier;

			public float projectileSpread;
		}

		[NonSerialized]
		public Config config;

		public override PassiveConfiguration passiveConfig => null;

		public P_CharAugment_BlindShot(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnHitboxSpawned(GameObject hitboxObj, EntityManager entity, int abilityId)
		{
		}

		public void ModifyHitbox(GameObject hitboxObj)
		{
		}
	}
}
