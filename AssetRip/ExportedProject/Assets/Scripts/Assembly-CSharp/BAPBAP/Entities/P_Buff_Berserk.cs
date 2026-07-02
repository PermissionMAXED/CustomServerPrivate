using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_Buff_Berserk : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float duration;

			public float dmgBonus;

			public float sprintBonus;

			public float atkSpeedBuff;

			public float assistTimerCutoff;

			public GameObject vfxReadyPrefab;
		}

		public class CustomPassiveSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_Buff_Berserk passive;

			public CustomPassiveSubroutine(P_Buff_Berserk _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override void OnExit(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public bool passiveActive;

		[NonSerialized]
		public P_CooldownSubroutine cooldownSubroutine;

		public override PassiveConfiguration passiveConfig => null;

		public P_Buff_Berserk(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void DeactivatePassive()
		{
		}
	}
}
