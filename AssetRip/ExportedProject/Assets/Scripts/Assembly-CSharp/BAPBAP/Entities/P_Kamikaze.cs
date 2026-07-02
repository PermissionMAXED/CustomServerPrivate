using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_Kamikaze : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public GameObject hitboxPrefab;

			public float explosionDelay;

			public float ttl;

			public int damage;

			[Range(0f, 1f)]
			public float percentHpDmg;

			public float damageScaling;

			public float hitboxRadius;

			[Header("FX")]
			public GameObject vfxLoopPrefab;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public int vfxLoopId;

		public override PassiveConfiguration passiveConfig => null;

		public P_Kamikaze(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnKilledTrigger(EntityManager killerCharManager)
		{
		}

		public void SpawnHitbox(Vector3 pos)
		{
		}

		public override void ClActivatePassive()
		{
		}

		public override void ClDeactivatePassive()
		{
		}
	}
}
