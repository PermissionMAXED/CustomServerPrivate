using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnUse_StickyBomb : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float startCooldownTime;

			public float baseCooldown;

			public CommandId[] targetAbilities;

			[Header("Rocket Config")]
			public float detonateDuration;

			public GameObject spellPrefab;

			public GameObject explosionSpellPrefab;

			public int damage;

			public float damageScaling;

			public float explosionTtl;

			public float explosionRadius;

			public float ttl;

			public List<StatusEffectInfo> statusEffects;

			[Header("FX Config")]
			public GameObject vfxReadyPrefab;
		}

		public class CustomPassiveSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_OnUse_StickyBomb passive;

			[NonSerialized]
			public byte triggerFinished;

			public CustomPassiveSubroutine(P_OnUse_StickyBomb _ability, byte _triggerFinished)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public bool passiveReady;

		public override PassiveConfiguration passiveConfig => null;

		public P_OnUse_StickyBomb(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnHitTrigger(EntityManager hittedEntity, HitboxBase hitboxBase, int abilityId)
		{
		}

		public void SpawnHitbox(EntityManager hittedEntity, int abilityId)
		{
		}
	}
}
