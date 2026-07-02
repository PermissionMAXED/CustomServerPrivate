using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_Tile_Invuln : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float cooldown;

			public PassiveSO passivetoActivate;
		}

		public class CustomPassiveSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_Tile_Invuln passive;

			[NonSerialized]
			public bool done;

			public CustomPassiveSubroutine(P_Tile_Invuln _ability)
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

		public override PassiveConfiguration passiveConfig => null;

		public P_Tile_Invuln(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void ActivatePassive()
		{
		}
	}
}
