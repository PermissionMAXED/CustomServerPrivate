using System;
using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Local
{
	public class AB_MachineGun : AB_Consumable_Base_Spawn
	{
		[Serializable]
		public new class Config : AB_Consumable_Base_Spawn.Config
		{
			[Header("Custom Config")]
			public PassiveSO passive;
		}

		[NonSerialized]
		public new Config config;

		public AB_MachineGun(Config _config = null)
			: base(null)
		{
		}

		public override void DoSpawnConsumable(EntityManager cM, Vector3 landingPoint, Quaternion rotation)
		{
		}
	}
}
