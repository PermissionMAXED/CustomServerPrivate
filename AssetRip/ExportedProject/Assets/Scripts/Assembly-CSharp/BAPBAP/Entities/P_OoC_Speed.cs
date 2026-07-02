using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OoC_Speed : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float outOfCombatTime;

			public float bonusSpeed;

			public GameObject vfxReadyPrefab;

			public GameObject vfxActivePrefab;
		}

		public class CustomPassiveSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_OoC_Speed passive;

			[NonSerialized]
			public byte trigger;

			public CustomPassiveSubroutine(P_OoC_Speed _ability, byte _trigger)
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

		public class CustomActiveSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_OoC_Speed passive;

			[NonSerialized]
			public byte trigger;

			public CustomActiveSubroutine(P_OoC_Speed _ability, byte _trigger)
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
		public float timeSinceCombat;

		[NonSerialized]
		public bool isOutOfCombat;

		[NonSerialized]
		public bool bonusSpeedActive;

		public override PassiveConfiguration passiveConfig => null;

		public P_OoC_Speed(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnHitboxSpawned(GameObject g, EntityManager cM, int abilityId)
		{
		}

		public override void OnTakeDamageTrigger(int damage, Vector3 hitDir)
		{
		}

		public void CharIsInCombat()
		{
		}

		public void ActivateSpeedBuff()
		{
		}

		public void DeactivateSpeedBuff()
		{
		}

		public override void DeactivatePassive()
		{
		}
	}
}
