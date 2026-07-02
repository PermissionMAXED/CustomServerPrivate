using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_Well_Fed : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float startCooldownTime;

			public float duration;

			public float slowDuration;

			public float slowMultiplier;

			public float sprintSpeed;

			public float extraDamagePercent;

			public GameObject vfxReadyPrefab;
		}

		public class CustomPassiveSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_Well_Fed passive;

			[NonSerialized]
			public float timeElapsed;

			public CustomPassiveSubroutine(P_Well_Fed _ability)
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
		public bool passiveReady;

		[NonSerialized]
		public int triggeredAbilityId;

		public override PassiveConfiguration passiveConfig => null;

		public P_Well_Fed(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnHitboxSpawned(GameObject g, EntityManager cM, int abilityId)
		{
		}

		public override void OnBonusHitboxSpawned(GameObject g, EntityManager cM, int abilityId)
		{
		}

		public void ModifyHitbox(GameObject g, EntityManager cM)
		{
		}
	}
}
