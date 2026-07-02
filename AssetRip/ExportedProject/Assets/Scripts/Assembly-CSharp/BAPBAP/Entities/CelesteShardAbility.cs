using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class CelesteShardAbility : Ability
	{
		public class CustomAnimSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public Ability ability;

			[NonSerialized]
			public AnimLayerIndices animLayer;

			[NonSerialized]
			public int stateHash1;

			[NonSerialized]
			public int stateHash2;

			[NonSerialized]
			public int currentAnimId;

			public CustomAnimSubroutine(Ability ability, AnimAction action, string animState, AnimLayerIndices animLayer)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public CelesteShardAbility ability;

			public CustomShootSubroutine(CelesteShardAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[Header("General")]
		[SerializeField]
		public GameObject spellPrefab;

		[SerializeField]
		public GameObject shardSpellPrefab;

		[SerializeField]
		public Transform firingPoint;

		[SerializeField]
		public float spread;

		[SerializeField]
		public MotionLockType castMotionLockType;

		[SerializeField]
		public bool applyAtkSpeedMultiplier;

		[SerializeField]
		public bool applyCooldownMultiplier;

		[SerializeField]
		public InputType inputType;

		[Header("Hitbox-related")]
		[SerializeField]
		public int damage;

		[SerializeField]
		public float damageScaling;

		[SerializeField]
		public float speed;

		[SerializeField]
		public float ttl;

		[SerializeField]
		public float dmgScaling;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[Header("Shard Hitbox")]
		[SerializeField]
		public int shardDamage;

		[SerializeField]
		public float shardDmgScaling;

		[SerializeField]
		public float shardTtl;

		[SerializeField]
		public float shardSpeed;

		[SerializeField]
		public float shardRadius;

		[SerializeField]
		public float shardTargetRadius;

		[SerializeField]
		public float shardExpandDuration;

		[SerializeField]
		public List<StatusEffectInfo> shardStatusEffects;

		[Header("State-related")]
		[SerializeField]
		public float castingTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[SerializeField]
		[Header("Effects")]
		public float camKickPower;

		[SerializeField]
		[Header("Animation")]
		public AnimLayerIndices animLayer;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		[Server]
		public override void OnOtherHitboxHit(Hitbox otherHitbox, HitboxBase hitboxBase)
		{
		}

		public void Shoot(Vector3 lookDir, int predTickNum)
		{
		}

		public void SpawnShard(Transform spawnTr, int playerId, int teamId, GameObject otherChar, bool isCrit)
		{
		}

		[Server]
		public void OnHitSuccess(EntityManager hittedEntity, HitboxBase hitboxBase)
		{
		}

		public override string GetTooltipDescription()
		{
			return null;
		}

		public override string GetTooltipExpandedDescription()
		{
			return null;
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
