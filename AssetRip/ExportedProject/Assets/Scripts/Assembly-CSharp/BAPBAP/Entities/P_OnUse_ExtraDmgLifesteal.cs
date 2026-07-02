using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnUse_ExtraDmgLifesteal : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float startCooldownTime;

			public float baseCooldown;

			public int extraDamage;

			public int extraDps;

			public GameObject vfxReadyPrefab;
		}

		public class CustomPassiveSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_OnUse_ExtraDmgLifesteal passive;

			[NonSerialized]
			public byte triggerFinished;

			public CustomPassiveSubroutine(P_OnUse_ExtraDmgLifesteal _ability, byte _triggerFinished)
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
		public bool secondaryEffectReady;

		[NonSerialized]
		public bool vampEffectReady;

		[NonSerialized]
		public int triggeredAbilityId;

		public override PassiveConfiguration passiveConfig => null;

		public P_OnUse_ExtraDmgLifesteal(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnHitboxSpawned(GameObject g, EntityManager cM, int abilityId)
		{
		}

		public override void OnBonusHitboxSpawned(GameObject g, EntityManager cM, int abilityId)
		{
		}

		public void ModifyHitbox(GameObject g, EntityManager cM)
		{
		}

		public override void OnDealtDamageTrigger(EntityManager otherCharManager, int damage, bool isCrit, Vector3 hitDir)
		{
		}
	}
}
