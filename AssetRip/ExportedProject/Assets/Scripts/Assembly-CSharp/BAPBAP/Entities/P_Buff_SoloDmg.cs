using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_Buff_SoloDmg : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float startCooldownTime;

			public float baseCooldown;

			public float bonusDmgPercent;

			public float auraRange;

			public float tickRate;

			public GameObject vfxReadyPrefab;
		}

		public class CustomPassiveSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_Buff_SoloDmg passive;

			public CustomPassiveSubroutine(P_Buff_SoloDmg _ability)
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
		public float timeElapsed;

		[NonSerialized]
		public bool dmgApplied;

		[NonSerialized]
		public P_LoopVfxSubroutine readyVfxSubroutine;

		public override PassiveConfiguration passiveConfig => null;

		public P_Buff_SoloDmg(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public void TryDRTeamates()
		{
		}

		public override void DeactivatePassive()
		{
		}
	}
}
