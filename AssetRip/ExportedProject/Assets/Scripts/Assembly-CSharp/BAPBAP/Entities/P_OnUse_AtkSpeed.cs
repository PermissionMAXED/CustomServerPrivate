using System;
using BAPBAP.Items;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnUse_AtkSpeed : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float startCooldownTime;

			public int numberOfPrimaryAttacks;

			public float atkSpeedBuff;

			public float buffDuration;
		}

		public class CustomPassiveSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_OnUse_AtkSpeed passive;

			public CustomPassiveSubroutine(P_OnUse_AtkSpeed _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}

			public override void OnExit(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public byte EXT_TRIGGER_RESET;

		[NonSerialized]
		public int primaryAttackCount;

		[NonSerialized]
		public int STATE_ACTIVE;

		[NonSerialized]
		public P_CooldownSubroutine cooldownSubroutine;

		[NonSerialized]
		public ItemStat stat;

		public override PassiveConfiguration passiveConfig => null;

		public P_OnUse_AtkSpeed(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnHitboxSpawned(GameObject hitboxObj, EntityManager entity, int abilityId)
		{
		}

		public override void OnAbilityTrigger(EntityManager entity, int abilityId)
		{
		}

		public void DoTrigger(EntityManager entity, int abilityId)
		{
		}

		public override void DeactivatePassive()
		{
		}

		public override void ClDeactivatePassive()
		{
		}
	}
}
