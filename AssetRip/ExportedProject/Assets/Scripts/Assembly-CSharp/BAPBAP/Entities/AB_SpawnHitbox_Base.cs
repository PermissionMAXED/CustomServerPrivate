using System;
using System.Collections.Generic;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class AB_SpawnHitbox_Base : AB_Use_Base
	{
		[Serializable]
		public new class Config : AB_Use_Base.Config
		{
			[Header("Hitbox Config")]
			public GameObject hitboxPrefab;

			public float hitboxRadius;

			public int damage;

			public float damageScaling;

			public List<StatusEffectInfo> statusEffects;

			public float ttl;

			public bool hitboxDirectional;

			public bool destroyOnCharHit;

			public bool onlyAllies;

			public bool damageAllowedToOwnerPlayer;

			public bool destroyOnStaticCollision;

			public bool counterable;

			public bool stayOnOwnerDestroyed;
		}

		[NonSerialized]
		public new Config config;

		public AB_SpawnHitbox_Base(Config config)
			: base(null)
		{
		}

		public override void DoUse()
		{
		}
	}
}
