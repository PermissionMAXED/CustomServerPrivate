using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_Debuff_Bleed : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float bleedDuration;

			public float bloodSpawnDistance;

			public GameObject puddle;

			public float puddleTtl;

			public List<StatusEffectInfo> statusEffects;
		}

		public class CustomPassiveSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_Debuff_Bleed passive;

			public CustomPassiveSubroutine(P_Debuff_Bleed _ability)
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
		public Vector3 lastTrailPosition;

		[NonSerialized]
		public float trailSpawnDistanceSqr;

		[NonSerialized]
		public P_CooldownSubroutine cooldownSubroutine;

		public override PassiveConfiguration passiveConfig => null;

		public P_Debuff_Bleed(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void Reactivate()
		{
		}

		public void SpawnTrailArea()
		{
		}

		public override void ActivatePassive()
		{
		}

		public override void DeactivatePassive()
		{
		}
	}
}
