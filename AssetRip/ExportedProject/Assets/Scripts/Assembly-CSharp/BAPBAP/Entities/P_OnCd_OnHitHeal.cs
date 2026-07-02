using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnCd_OnHitHeal : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float startCooldownTime;

			public float baseCooldown;

			public CommandId[] targetAbilities;

			public bool applyOnlyOnPlayers;

			[Header("Heal Config")]
			public int flatHealAmount;

			[Range(0f, 1f)]
			public float healMaxHpPercentage;

			public int flatShieldAmount;

			[Range(0f, 1f)]
			public float shieldMaxHpPercentage;

			public int shieldDuration;

			[Header("FX")]
			public GameObject vfxReadyPrefab;
		}

		public class CustomPassiveSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_OnCd_OnHitHeal passive;

			[NonSerialized]
			public byte triggerFinished;

			public CustomPassiveSubroutine(P_OnCd_OnHitHeal _ability, byte _triggerFinished)
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

		public P_OnCd_OnHitHeal(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnHitTrigger(EntityManager hittedEntity, HitboxBase hitboxBase, int abilityId)
		{
		}

		public void ApplyHeal()
		{
		}
	}
}
