using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnUse_ExtraPercentDmg : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float startCooldownTime;

			public float baseCooldown;

			public float bonusDuration;

			public float extraDamagePercent;

			[Header("FX")]
			public GameObject vfxReadyPrefab;

			public SFXData sfxReadyData;

			public GameObject vfxTriggeredPrefab;

			public GameObject vfxLoopPrefab;
		}

		public class CustomReadySubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_OnUse_ExtraPercentDmg passive;

			[NonSerialized]
			public byte triggerFinished;

			public CustomReadySubroutine(P_OnUse_ExtraPercentDmg _ability, byte _triggerFinished)
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

		public class CustomPassiveSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_OnUse_ExtraPercentDmg passive;

			[NonSerialized]
			public byte triggerFinished;

			[NonSerialized]
			public float timeElapsed;

			public CustomPassiveSubroutine(P_OnUse_ExtraPercentDmg _ability, byte _triggerFinished)
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
		public bool passiveActive;

		[NonSerialized]
		public bool passiveTriggered;

		[NonSerialized]
		public int triggeredAbilityId;

		[NonSerialized]
		public int vfxLoopId;

		public override PassiveConfiguration passiveConfig => null;

		public P_OnUse_ExtraPercentDmg(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnHitboxSpawned(GameObject g, EntityManager cM, int abilityId)
		{
		}

		public override void OnHitTrigger(EntityManager otherCM, HitboxBase hitboxBase, int abilityId)
		{
		}

		public override void ClCustomEvent0()
		{
		}

		public void DoHit(int damage, EntityManager otherCM, bool isCrit)
		{
		}

		public override void DeactivatePassive()
		{
		}

		public override void ClActivatePassive()
		{
		}

		public override void ClDeactivatePassive()
		{
		}
	}
}
