using System;
using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Local
{
	public class AB_VoidGrenade : AB_Consumable_Base_Spawn
	{
		[Serializable]
		public new class Config : AB_Consumable_Base_Spawn.Config
		{
			[Header("Custom Config")]
			public GameObject voidInAirPrefab;

			public GameObject voidGrenadeAreaPrefab;

			[Header("Config")]
			public float radius;

			public float ttl;

			[Header("Misc")]
			public float interpDuration;

			public float height;

			public AnimationCurve heightCurve;

			public float expandAnimDuration;

			public float endShrinkAnimDuration;
		}

		[NonSerialized]
		public new Config config;

		public AB_VoidGrenade(Config _config = null)
			: base(null)
		{
		}

		public override void DoSpawnConsumable(EntityManager cM, Vector3 landingPoint, Quaternion rotation)
		{
		}

		public void SpawnGrenade(EntityManager cM, Vector3 landingPoint)
		{
		}
	}
}
