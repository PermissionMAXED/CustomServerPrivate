using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_Buff_ApplyStatusEffectToHitboxes : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public StatusEffectInfo statusEffect;

			public bool divideMultiplierByAttackId;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public StatusEffectInfo sEffect;

		[NonSerialized]
		public int triggeredAbilityId;

		public override PassiveConfiguration passiveConfig => null;

		public P_Buff_ApplyStatusEffectToHitboxes(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnHitboxSpawned(GameObject g, EntityManager cM, int abilityId)
		{
		}

		public override void OnBonusHitboxSpawned(GameObject g, EntityManager cM, int abilityId)
		{
		}

		public void ModifyHitbox(GameObject g, EntityManager cM, int abilityId)
		{
		}
	}
}
