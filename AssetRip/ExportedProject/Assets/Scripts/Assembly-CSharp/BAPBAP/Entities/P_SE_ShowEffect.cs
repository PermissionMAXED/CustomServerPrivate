using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_SE_ShowEffect : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
		}

		public class CustomPassiveSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_SE_ShowEffect passive;

			[NonSerialized]
			public byte triggerFinished;

			public CustomPassiveSubroutine(P_SE_ShowEffect _ability, byte _triggerFinished)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		[NonSerialized]
		public Config config;

		public float duration;

		public float multiplier;

		public bool ready;

		[NonSerialized]
		public P_CooldownSubroutine cooldownSubroutine;

		public override PassiveConfiguration passiveConfig => null;

		public P_SE_ShowEffect(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void SetSharedData(float floatA = 0f, float floatB = 0f, Vector3 vectorA = default(Vector3))
		{
		}
	}
}
