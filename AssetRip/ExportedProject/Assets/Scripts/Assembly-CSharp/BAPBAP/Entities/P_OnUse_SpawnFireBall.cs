using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnUse_SpawnFireBall : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public CommandId targetAbility;

			public float startCooldownTime;

			public float baseCooldown;

			public float forwardSpawnAmount;

			[Header("Rocket Config")]
			public GameObject spellPrefab;

			public int damage;

			public float damageScaling;

			public float ttl;

			public float speed;

			public List<StatusEffectInfo> statusEffects;

			[Header("FX Config")]
			public GameObject vfxReadyPrefab;
		}

		public class CustomPassiveSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_OnUse_SpawnFireBall passive;

			[NonSerialized]
			public byte triggerFinished;

			public CustomPassiveSubroutine(P_OnUse_SpawnFireBall _ability, byte _triggerFinished)
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

		[NonSerialized]
		public int triggeredAbilityId;

		[NonSerialized]
		public Ability targetAbility;

		public override PassiveConfiguration passiveConfig => null;

		public P_OnUse_SpawnFireBall(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnHitboxSpawned(GameObject g, EntityManager cM, int abilityId)
		{
		}

		public void SpawnHitbox(bool isCrit, int abilityId)
		{
		}
	}
}
