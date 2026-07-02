using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class NpcSkullBlobArtillaryAbility : Ability
	{
		public class CustomCastVfxSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public NpcSkullBlobArtillaryAbility ability;

			[NonSerialized]
			public int attackId;

			public CustomCastVfxSubroutine(NpcSkullBlobArtillaryAbility _ability, int _attackId)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public NpcSkullBlobArtillaryAbility ability;

			[NonSerialized]
			public float fireRate;

			[NonSerialized]
			public float fireRateTimer;

			[NonSerialized]
			public byte trigger;

			[NonSerialized]
			public byte silencedTrigger;

			public CustomShootSubroutine(NpcSkullBlobArtillaryAbility _ability, byte _trigger, byte _silenced)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
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

		[Header("Hitbox-related")]
		[SerializeField]
		public int damage;

		[SerializeField]
		public float damageScaling;

		[SerializeField]
		public float ttl;

		[SerializeField]
		public float hitboxRadius;

		[SerializeField]
		public int numProjectiles;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[SerializeField]
		public float randomOffset;

		[Header("State-related")]
		[SerializeField]
		public float castingTime;

		[SerializeField]
		public float hitboxImpactTime;

		[SerializeField]
		public float shootDurationTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[Header("Effects")]
		[SerializeField]
		public float castSfxDelay;

		[SerializeField]
		[Header("Sfx")]
		public AudioClipData sfxCast;

		[Header("Vfx")]
		[SerializeField]
		public ParticleSystem castVfx;

		[SerializeField]
		public ParticleSystem shootVfx;

		[SerializeField]
		[Header("Animation")]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public NpcBehaviour npcBehaviour;

		[NonSerialized]
		public GameObject currentVisibleIndicator;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public void CastSpell(int predTickNum)
		{
		}

		[ClientRpc]
		public void RpcDestroyVisibleIndicator()
		{
		}

		[ClientRpc]
		public void RpcPlayCastVFX()
		{
		}

		public void RpcPlayShootVFX()
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcDestroyVisibleIndicator()
		{
		}

		public static void InvokeUserCode_RpcDestroyVisibleIndicator(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcPlayCastVFX()
		{
		}

		public static void InvokeUserCode_RpcPlayCastVFX(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static NpcSkullBlobArtillaryAbility()
		{
		}
	}
}
