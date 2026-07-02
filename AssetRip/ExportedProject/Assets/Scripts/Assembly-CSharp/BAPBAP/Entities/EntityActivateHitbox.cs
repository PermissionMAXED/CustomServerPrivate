using System;
using System.Collections.Generic;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class EntityActivateHitbox : EntityActivateBase
	{
		[Header("Entity Configs")]
		[SerializeField]
		public bool activateOnStart;

		[SerializeField]
		public bool followEntity;

		[SerializeField]
		public bool destroyWithEntity;

		[Tooltip("Should the spawned hitbox forward axis be set to look towards the last entity hit direction?")]
		[SerializeField]
		public bool lookTowardsEntityHitDir;

		[SerializeField]
		[Tooltip("Should assign this entity team id and owner player id to the spawned hitbox?")]
		public bool setEntityTeam;

		[Header("Hitbox Settings")]
		[SerializeField]
		public GameObject hitboxPrefab;

		[SerializeField]
		public Transform firingPoint;

		[SerializeField]
		public bool damageAllies;

		[SerializeField]
		public int dmg;

		[SerializeField]
		[Range(0f, 1f)]
		public float dmgHpPercentage;

		[SerializeField]
		[Range(0f, 1f)]
		public float dmgHpPercentageVehicle;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[SerializeField]
		public bool doTtl;

		[ConditionalHide("doTtl", true)]
		[SerializeField]
		[Min(0f)]
		public float ttl;

		[SerializeField]
		public float radius;

		[Header("Configs")]
		[SerializeField]
		public bool destroyOnCharHit;

		[SerializeField]
		public bool destroyOnStaticCollision;

		[SerializeField]
		public bool allowLifesteal;

		[SerializeField]
		public bool allowThorns;

		[Tooltip("For npc targets, only add up to this flat amount of the percentage of their maxHp to the damage. If -1, limit wont be applied")]
		[SerializeField]
		public int addDamageHpPercentageNpcsLimit;

		[SerializeField]
		public bool alwaysHitInteractables;

		[SerializeField]
		public bool counterable;

		[SerializeField]
		public float colEnableTime;

		[SerializeField]
		public bool forceTriggerImmune;

		[SerializeField]
		public bool onlyHitCharOnce;

		[SerializeField]
		public bool pullToPosition;

		[ConditionalHide("pullToPosition", true)]
		[SerializeField]
		public float pullTime;

		[NonSerialized]
		public GameObject spawnedHitbox;

		public override void Awake()
		{
		}

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

		public void SpawnHitbox(Vector3 position, Quaternion rotation)
		{
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
