using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnHealed_DmgReduction : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float startCooldownTime;

			public float baseCooldown;

			public float dmgReduction;

			public float dmgReductionDuration;

			public GameObject vfxTriggeredPrefab;
		}

		public class CustomPassiveSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_OnHealed_DmgReduction passive;

			[NonSerialized]
			public byte triggerFinished;

			public CustomPassiveSubroutine(P_OnHealed_DmgReduction _ability, byte _triggerFinished)
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

		public class CustomPassiveExitSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_OnHealed_DmgReduction passive;

			public CustomPassiveExitSubroutine(P_OnHealed_DmgReduction _ability)
			{
			}

			public override void OnExit(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public bool passiveReady;

		public override PassiveConfiguration passiveConfig => null;

		public P_OnHealed_DmgReduction(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnHealedTrigger(EntityManager cM)
		{
		}

		public override void DeactivatePassive()
		{
		}
	}
}
