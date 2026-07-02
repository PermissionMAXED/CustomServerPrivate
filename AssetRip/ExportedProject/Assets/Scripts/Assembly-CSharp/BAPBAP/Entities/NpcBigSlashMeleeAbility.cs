using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class NpcBigSlashMeleeAbility : Ability
	{
		public class CustomCastVfxSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public NpcBigSlashMeleeAbility ability;

			[NonSerialized]
			public int attackId;

			public CustomCastVfxSubroutine(NpcBigSlashMeleeAbility _ability, int _attackId)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomVisibleIndicatorSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public NpcBigSlashMeleeAbility ability;

			[NonSerialized]
			public bool setEnabled;

			public CustomVisibleIndicatorSubroutine(NpcBigSlashMeleeAbility _ability, bool _setEnabled)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public NpcBigSlashMeleeAbility ability;

			[NonSerialized]
			public int attackId;

			public CustomShootSubroutine(NpcBigSlashMeleeAbility _ability, int _attackId)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[SerializeField]
		[Header("General")]
		public GameObject spellPrefab;

		[SerializeField]
		public GameObject spellPrefab2;

		[SerializeField]
		public Transform firingPoint;

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
		public List<StatusEffectInfo> statusEffects;

		[Header("State-related")]
		[SerializeField]
		public float castingTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[SerializeField]
		[Header("Indicator")]
		public GameObject visibleIndicatorPrefab;

		[SerializeField]
		public float indicatorRadius;

		[SerializeField]
		public float indicatorHalfAngle;

		[SerializeField]
		[Header("Effects")]
		public AudioClipData sfxCast;

		[SerializeField]
		public float sfxCastDelay;

		[SerializeField]
		public ParticleSystem castVfxRight;

		[SerializeField]
		public ParticleSystem castVfxLeft;

		[SerializeField]
		[Header("Animation")]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public GameObject currentIndicator;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public void OnDestroy()
		{
		}

		public void CastSpell(Vector3 lookDir, int attackId)
		{
		}

		public void ClDestroyVisibleIndicator()
		{
		}

		[ClientRpc]
		public void RpcSpawnVisibleIndicator()
		{
		}

		[ClientRpc]
		public void RpcDestroyVisibleIndicator()
		{
		}

		[ClientRpc]
		public void RpcPlayCastVFX1()
		{
		}

		public void RpcPlayCastVFX2()
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcSpawnVisibleIndicator()
		{
		}

		public static void InvokeUserCode_RpcSpawnVisibleIndicator(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcDestroyVisibleIndicator()
		{
		}

		public static void InvokeUserCode_RpcDestroyVisibleIndicator(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcPlayCastVFX1()
		{
		}

		public static void InvokeUserCode_RpcPlayCastVFX1(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static NpcBigSlashMeleeAbility()
		{
		}
	}
}
