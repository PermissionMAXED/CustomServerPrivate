using System;
using System.Collections.Generic;
using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Local
{
	public class GM_MeteorShower : GameModifier
	{
		[Serializable]
		public class Config : GameModifierConfiguration
		{
			[Min(0.001f)]
			[Tooltip("Density of meteorites to be spawned per a 10x10 world unit area. This will multiply the spawn per second accordingly")]
			[Header("Custom Config")]
			public float spawnDensityPer10Unit;

			[Header("Impact Hitbox Settings")]
			public GameObject meteoritePrefab;

			public int damage;

			public float damagePercent;

			public float radius;

			[Tooltip("Time it takes for the meteorite to drop and the hitbox to activate")]
			public float activateTime;

			public float ttl;

			[Header("Fire Hitbox Settings")]
			public GameObject meteoriteFireAreaPrefab;

			public bool doSpawnFireArea;

			[ConditionalHide("doSpawnFireArea", true)]
			public int fireAreaDamage;

			[ConditionalHide("doSpawnFireArea", true)]
			public float fireAreaDmgRate;

			[ConditionalHide("doSpawnFireArea", true)]
			public float fireAreaRadius;

			[ConditionalHide("doSpawnFireArea", true)]
			public float fireAreaTtl;

			public List<StatusEffectInfo> fireAreaStatusEffects;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public float timer;

		[NonSerialized]
		public float spawnInterval;

		[NonSerialized]
		public float density;

		public GM_MeteorShower(Config _config = null)
		{
		}

		public override void Activate()
		{
		}

		public override void OnTick(float fdt)
		{
		}

		public void SpawnMeteorite()
		{
		}
	}
}
