using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_Buff_Dmg_Mod_01 : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float duration;

			public float dmgBonus;
		}

		public class CustomPassiveSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_Buff_Dmg_Mod_01 passive;

			public CustomPassiveSubroutine(P_Buff_Dmg_Mod_01 _ability)
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

		public P_Buff_Dmg_Mod_01(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void DeactivatePassive()
		{
		}
	}
}
