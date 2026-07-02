using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_Gain_Shield : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float shieldDuration;

			public float percentHpShield;

			public int shieldAmount;

			public bool showCooldown;
		}

		public class CustomPassiveSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_Gain_Shield passive;

			[NonSerialized]
			public byte triggerFinished;

			[NonSerialized]
			public float timer;

			public CustomPassiveSubroutine(P_Gain_Shield _ability, byte _triggerFinished)
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
		public int shieldDamageTaken;

		[NonSerialized]
		public int amount;

		public override PassiveConfiguration passiveConfig => null;

		public P_Gain_Shield(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnTakeDamageTrigger(int damage, Vector3 hitDir)
		{
		}
	}
}
