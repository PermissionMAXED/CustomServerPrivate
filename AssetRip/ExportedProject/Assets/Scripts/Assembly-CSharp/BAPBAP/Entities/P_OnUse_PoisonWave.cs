using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnUse_PoisonWave : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float startCooldownTime;

			public int numberOfAbilitiesToTrigger;

			public int damage;

			public float damageScaling;

			public float hitboxRadius;

			public float ttl;

			public List<StatusEffectInfo> statusEffects;

			public GameObject spellPrefab;

			public GameObject vfxReadyPrefab;
		}

		public class CustomPassiveReadySubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_OnUse_PoisonWave passive;

			[NonSerialized]
			public byte triggerFinished;

			public CustomPassiveReadySubroutine(P_OnUse_PoisonWave _ability, byte _triggerFinished)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		public class CustomPassiveSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_OnUse_PoisonWave passive;

			[NonSerialized]
			public byte triggerFinished;

			public CustomPassiveSubroutine(P_OnUse_PoisonWave _ability, byte _triggerFinished)
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
		public int currentUseCount;

		[NonSerialized]
		public float bufferTime;

		[NonSerialized]
		public float bufferTimer;

		[NonSerialized]
		public int bufferAbilityId;

		public override PassiveConfiguration passiveConfig => null;

		public P_OnUse_PoisonWave(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public void SpawnDmgObject(int predTickNum)
		{
		}

		public override void OnHitboxSpawned(GameObject g, EntityManager cM, int abilityId)
		{
		}

		public override void ActivatePassive()
		{
		}
	}
}
