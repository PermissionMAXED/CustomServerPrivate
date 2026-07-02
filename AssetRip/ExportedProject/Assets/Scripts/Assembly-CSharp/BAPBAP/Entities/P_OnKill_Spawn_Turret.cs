using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnKill_Spawn_Turret : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float assistTimerCutoff;

			public int consumableTier;

			public GameObject turret;
		}

		[NonSerialized]
		public Config config;

		public override PassiveConfiguration passiveConfig => null;

		public P_OnKill_Spawn_Turret(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnKillTrigger(EntityManager otherEntity)
		{
		}

		public override void OnAssistTrigger(EntityManager otherEntity, float timer)
		{
		}

		public void SpawnTurret(Vector3 pos)
		{
		}
	}
}
