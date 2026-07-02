using System;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class EntityActivateHitboxDps : EntityActivateBase
	{
		[Header("Entity Configs")]
		[SerializeField]
		public bool activateOnStart;

		[SerializeField]
		public bool followEntity;

		[SerializeField]
		public bool destroyWithEntity;

		[Tooltip("Should assign this entity team id and owner player id to the spawned hitbox?")]
		[SerializeField]
		public bool setEntityTeam;

		[Header("Hitbox Settings")]
		[SerializeField]
		public GameObject hitboxPrefab;

		[SerializeField]
		public int dmg;

		[SerializeField]
		public float percentDmg;

		[SerializeField]
		public float dmgRate;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[SerializeField]
		public bool doTtl;

		[Min(0f)]
		[SerializeField]
		[ConditionalHide("doTtl", true)]
		public float ttl;

		[SerializeField]
		public float radius;

		[SerializeField]
		public float expandDuration;

		[SerializeField]
		[Header("Configs")]
		public bool stayOnOwnerDestroyed;

		[SerializeField]
		public bool onlyApplyHitOncePerChar;

		[SerializeField]
		public bool applyZeroDamageHit;

		[SerializeField]
		public bool alwaysHitInteractables;

		[SerializeField]
		public bool onlyDamageOnVisibility;

		[SerializeField]
		public bool enableTransformExpandRadius;

		[SerializeField]
		public float colEnableTime;

		[NonSerialized]
		public GameObject spawnedHitbox;

		public void Start()
		{
		}

		public void OnDestroy()
		{
		}

		[Server]
		public override void Activate()
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
