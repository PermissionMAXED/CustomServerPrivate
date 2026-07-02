using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnDeath_Immune : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float startCooldownTime;

			public float baseCooldown;

			public float immuneDuration;

			public float healHpPercent;

			public GameObject vfxReadyPrefab;

			public GameObject vfxTriggeredPrefab;

			public GameObject vfxTriggeredLoopPrefab;
		}

		public class CustomPassiveSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_OnDeath_Immune ability;

			[NonSerialized]
			public byte triggerFinished;

			public CustomPassiveSubroutine(P_OnDeath_Immune _ability, byte _triggerFinished)
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
			public P_OnDeath_Immune passive;

			public CustomPassiveExitSubroutine(P_OnDeath_Immune _ability)
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

		public P_OnDeath_Immune(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnMinHpTrigger()
		{
		}

		public override void DeactivatePassive()
		{
		}
	}
}
