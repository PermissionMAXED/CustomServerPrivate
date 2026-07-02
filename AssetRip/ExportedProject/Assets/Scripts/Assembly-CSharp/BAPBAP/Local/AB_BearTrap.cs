using System;
using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Local
{
	public class AB_BearTrap : AB_Consumable_Base_Spawn
	{
		[Serializable]
		public new class Config : AB_Consumable_Base_Spawn.Config
		{
			[Header("Custom Config")]
			public GameObject bearTrapPrefab;
		}

		[NonSerialized]
		public new Config config;

		public AB_BearTrap(Config _config = null)
			: base(null)
		{
		}

		public override void DoSpawnConsumable(EntityManager cM, Vector3 landingPoint, Quaternion rotation)
		{
		}
	}
}
