using System;
using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_GoldRock : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public int healthPerGold;

			public int minGold;

			public int maxGold;

			public AudioClipData sfxSpawnGold;

			public float distMultiplier;

			public float minDist;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public int prevHealth;

		public override PassiveConfiguration passiveConfig => null;

		public P_GoldRock(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnTakeDamageTrigger(int damage, Vector3 hitDir)
		{
		}
	}
}
