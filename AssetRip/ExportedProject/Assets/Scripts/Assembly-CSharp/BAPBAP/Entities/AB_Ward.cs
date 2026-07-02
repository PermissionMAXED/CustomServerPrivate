using System;
using System.Collections.Generic;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class AB_Ward : AB_Consumable_Base_Spawn
	{
		[Serializable]
		public new class Config : AB_Consumable_Base_Spawn.Config
		{
			[Header("Ward Config")]
			public GameObject spellPrefab;

			public float radius;

			public float ttl;

			public float endAnimDuration;

			public List<StatusEffectInfo> statusEffects;
		}

		[NonSerialized]
		public new Config config;

		public AB_Ward(Config _config = null)
			: base(null)
		{
		}

		public override void DoSpawnConsumable(EntityManager cM, Vector3 landingPoint, Quaternion rotation)
		{
		}
	}
}
