using System;
using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Local
{
	public class AB_Turret : AB_Consumable_Base_Spawn
	{
		[Serializable]
		public new class Config : AB_Consumable_Base_Spawn.Config
		{
			[Header("Turret Config")]
			public GameObject turretPrefab;
		}

		[NonSerialized]
		public new Config config;

		public AB_Turret(Config _config = null)
			: base(null)
		{
		}

		public override void DoSpawnConsumable(EntityManager cM, Vector3 landingPoint, Quaternion rotation)
		{
		}
	}
}
