using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_SpawnOnHitboxCreate : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public GameObject entityPrefab;

			public bool entityChangeTeams;
		}

		[NonSerialized]
		public Config config;

		public override PassiveConfiguration passiveConfig => null;

		public P_SpawnOnHitboxCreate(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnAbilityTrigger(EntityManager cM, int abilityId)
		{
		}

		public void SpawnEntity()
		{
		}
	}
}
