using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class AB_CDReset : AB_Use_Base
	{
		[Serializable]
		public new class Config : AB_Use_Base.Config
		{
			[Header("Self Damage Config")]
			public bool allowKill;

			[Min(0f)]
			public int selfFlatDamage;

			[Range(0f, 1f)]
			public float selfPercentDamage;
		}

		public new class CustomUseSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public AB_CDReset behaviour;

			public CustomUseSubroutine(AB_CDReset _behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[NonSerialized]
		public new Config config;

		public AB_CDReset(Config config)
			: base(null)
		{
		}

		public override void Build(Ability ability, int itemId)
		{
		}

		public override void DoUse()
		{
		}
	}
}
