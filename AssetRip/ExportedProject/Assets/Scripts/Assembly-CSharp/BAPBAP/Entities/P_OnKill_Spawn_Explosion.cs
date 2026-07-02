using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnKill_Spawn_Explosion : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public int damage;

			[Range(0f, 1f)]
			public float percentHpDmg;

			public float damageScaling;

			public float hitboxRadius;

			public float hitboxActivateTime;

			public float ttl;

			public float assistTimerCutoff;

			public GameObject vfxReadyPrefab;

			public GameObject spellPrefab;

			public bool onlyPlayers;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public GameObject dmgHitboxObj;

		[NonSerialized]
		public int vfxReadyId;

		public override PassiveConfiguration passiveConfig => null;

		public P_OnKill_Spawn_Explosion(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public void SpawnDmgObject(Vector3 pos)
		{
		}

		public override void OnKillTrigger(EntityManager otherCharManager)
		{
		}

		public override void OnAssistTrigger(EntityManager otherCharManager, float t)
		{
		}

		public override void DeactivatePassive()
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
