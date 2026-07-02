using System;
using System.Collections.Generic;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnHitboxSpawned_AddStatusEffect : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public List<StatusEffectInfo> statusEffects;
		}

		[NonSerialized]
		public Config config;

		public override PassiveConfiguration passiveConfig => null;

		public P_OnHitboxSpawned_AddStatusEffect(EntityManager entityManager, Config config)
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
