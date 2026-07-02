using System;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class SpawnHitboxOnDestroy : NetworkBehaviour
	{
		[NonSerialized]
		public GameObject hitboxPrefab;

		[NonSerialized]
		public int ownerPlayerId;

		[NonSerialized]
		public int ownerTeamId;

		[NonSerialized]
		public bool onlyAllies;

		[NonSerialized]
		public bool damageAllowedToOwnerPlayer;

		[NonSerialized]
		public GameObject otherChar;

		[NonSerialized]
		public int damage;

		[NonSerialized]
		public float dpsDmgPerTimeRate;

		[NonSerialized]
		public float damageToPlayersMultiplier;

		[NonSerialized]
		public bool isCriticalDamage;

		[NonSerialized]
		public bool stayOnOwnerDestroyed;

		[NonSerialized]
		public bool destroyOnCharHit;

		[NonSerialized]
		public bool destroyOnStaticCollision;

		[NonSerialized]
		public bool doTtl;

		[NonSerialized]
		public float ttl;

		[NonSerialized]
		public float speed;

		[NonSerialized]
		public List<StatusEffectInfo> statusEffects;

		[NonSerialized]
		public float radius;

		[NonSerialized]
		public float targetScale;

		[NonSerialized]
		public float expandDuration;

		[NonSerialized]
		public bool alwaysHitInteractables;

		[NonSerialized]
		public bool directional;

		[NonSerialized]
		public bool counterable;

		[NonSerialized]
		public bool secondaryHitbox;

		[NonSerialized]
		public bool checkForSuccessfulHit;

		[NonSerialized]
		public Action<HitboxBase> OnSpawnAction;

		public override void OnStopServer()
		{
		}

		[Server]
		public void SpawnHitbox()
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
