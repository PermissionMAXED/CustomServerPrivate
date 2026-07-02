using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnCd_WaterShield : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float baseCooldown;

			public GameObject vfxReadyPrefab;

			public GameObject vfxShieldBrokenPrefab;

			public int shieldAmount;

			public float percentShieldAmount;

			public float duration;

			[Header("Hitbox")]
			public GameObject spellPrefab;

			public int damage;

			public float damageScaling;

			public float hitboxRadius;

			public List<StatusEffectInfo> statusEffects;
		}

		public class CustomPassiveSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_OnCd_WaterShield passive;

			[NonSerialized]
			public byte triggerFinished;

			public CustomPassiveSubroutine(P_OnCd_WaterShield _ability, byte _triggerFinished)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
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

		public class CustomShieldSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_OnCd_WaterShield passive;

			[NonSerialized]
			public byte trigger;

			public CustomShieldSubroutine(P_OnCd_WaterShield _ability, byte _trigger)
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
		public SE_Shield shield;

		[NonSerialized]
		public float shieldTimer;

		[NonSerialized]
		public int currentShield;

		[NonSerialized]
		public int shieldDamageTaken;

		[NonSerialized]
		public bool hit;

		[NonSerialized]
		public bool passiveReady;

		[NonSerialized]
		public Hitbox hitbox;

		[NonSerialized]
		public P_CooldownSubroutine cooldownSubroutine;

		public override PassiveConfiguration passiveConfig => null;

		public P_OnCd_WaterShield(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnTakeDamageTrigger(int damage, Vector3 hitDir)
		{
		}

		public void SpawnHitbox(int predTickNum)
		{
		}

		public override void DeactivatePassive()
		{
		}
	}
}
