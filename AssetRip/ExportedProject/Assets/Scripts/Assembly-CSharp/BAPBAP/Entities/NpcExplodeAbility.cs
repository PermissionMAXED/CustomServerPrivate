using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class NpcExplodeAbility : Ability
	{
		public class CustomCastVfxSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public NpcExplodeAbility ability;

			public CustomCastVfxSubroutine(NpcExplodeAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public NpcExplodeAbility ability;

			public CustomShootSubroutine(NpcExplodeAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomSetMinHealthSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public NpcExplodeAbility ability;

			[NonSerialized]
			public bool set;

			public CustomSetMinHealthSubroutine(NpcExplodeAbility _ability, bool _set)
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
		public MotionLockType castMotionLockType;

		[SerializeField]
		public RotationLockType castRotationLockType;

		[SerializeField]
		public bool applyAtkSpeedMultiplier;

		[SerializeField]
		public bool applyCooldownMultiplier;

		[SerializeField]
		[Header("Hitbox-related")]
		public int damage;

		[SerializeField]
		public float hpPercentDamage;

		[SerializeField]
		public float damageScaling;

		[SerializeField]
		public float ttl;

		[SerializeField]
		public float hitboxRadius;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[Header("State-related")]
		[SerializeField]
		public float castingTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[SerializeField]
		[Header("Effects")]
		public GameObject destroyVfxPrefab;

		[SerializeField]
		public float camKickPower;

		[SerializeField]
		public GameObject muzzleVfx;

		[SerializeField]
		public ParticleSystem explodeCastVfx;

		[SerializeField]
		public ParticleSystem explodeShootVfx;

		[SerializeField]
		[Header("Animation")]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public NpcBehaviour blobBehaviour;

		[NonSerialized]
		public CharHpBar charHpBar;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public void Awake()
		{
		}

		public void Shoot(int predTickNum)
		{
		}

		[ClientRpc]
		public void RpcSpawnExplosionVfx()
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcSpawnExplosionVfx()
		{
		}

		public static void InvokeUserCode_RpcSpawnExplosionVfx(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static NpcExplodeAbility()
		{
		}
	}
}
