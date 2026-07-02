using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OoC_Shield : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float baseCooldown;

			public float shieldAmount;

			public float shieldDuration;

			public GameObject vfxFollowPrefab;

			public SFXData sfxReadyData;
		}

		public class CustomShieldSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_OoC_Shield passive;

			public CustomShieldSubroutine(P_OoC_Shield _ability)
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
			public P_OoC_Shield passive;

			[NonSerialized]
			public byte triggerFinished;

			public CustomPassiveSubroutine(P_OoC_Shield _ability, byte _triggerFinished)
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
		public P_CooldownSubroutine cooldownSubroutine;

		[NonSerialized]
		public bool hit;

		[NonSerialized]
		public float shieldTimer;

		[NonSerialized]
		public int shieldDamageTaken;

		[NonSerialized]
		public SE_Shield shield;

		public override PassiveConfiguration passiveConfig => null;

		public P_OoC_Shield(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnTakeDamageTrigger(int damage, Vector3 hitDir)
		{
		}

		public override void ClDeactivatePassive()
		{
		}

		public override void DeactivatePassive()
		{
		}
	}
}
