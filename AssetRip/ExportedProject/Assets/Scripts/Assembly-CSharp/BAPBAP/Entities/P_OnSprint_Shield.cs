using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnSprint_Shield : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float baseCooldownTime;

			public float shieldPercentHp;

			public float shieldHp;

			public float shieldDuration;
		}

		public class CustomPassiveReadySubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_OnSprint_Shield passive;

			[NonSerialized]
			public byte triggerFinished;

			public CustomPassiveReadySubroutine(P_OnSprint_Shield _ability, byte _triggerFinished)
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
			public P_OnSprint_Shield passive;

			[NonSerialized]
			public byte triggerFinished;

			public CustomPassiveSubroutine(P_OnSprint_Shield _ability, byte _triggerFinished)
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

		public P_OnSprint_Shield(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnStatusEffectAppliedToSelfTrigger(int statusEffectId)
		{
		}

		public override void ClDeactivatePassive()
		{
		}
	}
}
