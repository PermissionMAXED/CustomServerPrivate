using System;
using System.Collections.Generic;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_CharAugment_BigShot : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public List<StatusEffectInfo> statusEffects;

			public float scaleMult;
		}

		[NonSerialized]
		public Config config;

		public override PassiveConfiguration passiveConfig => null;

		public P_CharAugment_BigShot(EntityManager entityManager, Config config)
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
