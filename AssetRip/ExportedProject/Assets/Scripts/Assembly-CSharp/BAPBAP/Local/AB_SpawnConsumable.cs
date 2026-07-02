using System;
using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Local
{
	public class AB_SpawnConsumable : AB_Consumable_Base_Spawn
	{
		[Serializable]
		public new class Config : AB_Consumable_Base_Spawn.Config
		{
			[Header("Drop Config")]
			public GameObject consumablePrefab;
		}

		[NonSerialized]
		public new Config config;

		public AB_SpawnConsumable(Config _config = null)
			: base(null)
		{
		}

		public override void DoSpawnConsumable(EntityManager entity, Vector3 landingPoint, Quaternion rotation)
		{
		}
	}
}
