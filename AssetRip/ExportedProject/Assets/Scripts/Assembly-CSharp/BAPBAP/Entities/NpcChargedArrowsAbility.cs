using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class NpcChargedArrowsAbility : Ability
	{
		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public NpcChargedArrowsAbility ability;

			public CustomShootSubroutine(NpcChargedArrowsAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomVisibleIndicatorSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public NpcChargedArrowsAbility ability;

			[NonSerialized]
			public bool setEnabled;

			public CustomVisibleIndicatorSubroutine(NpcChargedArrowsAbility _ability, bool _setEnabled)
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
		public Transform firingPoint;

		[SerializeField]
		public MotionLockType castMotionLockType;

		[SerializeField]
		public bool applyAtkSpeedMultiplier;

		[SerializeField]
		public bool applyCooldownMultiplier;

		[SerializeField]
		public InputType inputType;

		[SerializeField]
		public float abilityRadius;

		[SerializeField]
		[Header("Indicator")]
		public GameObject indicatorPrefab;

		[SerializeField]
		[Header("Hitbox-related")]
		public int damage;

		[SerializeField]
		public float damageRate;

		[SerializeField]
		public float damageScaling;

		[SerializeField]
		public float speed;

		[SerializeField]
		public float ttl;

		[SerializeField]
		public float hitboxRadius;

		[SerializeField]
		public float hitboxActivateTime;

		[SerializeField]
		public float randomOffset;

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
		public float camKickPower;

		[SerializeField]
		[Header("VFX")]
		public GameObject vfxCastPrefab;

		[Header("SFX")]
		[SerializeField]
		public AudioClipData sfxCast;

		[Header("Animation")]
		[SerializeField]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public GameObject currentIndicator;

		[NonSerialized]
		public NpcBehaviour npcBehaviour;

		[NonSerialized]
		public List<Vector3> targetPositions;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public void Shoot(int predTickNum)
		{
		}

		public void ClDestroyVisibleIndicator()
		{
		}

		[ClientRpc]
		public void RpcSpawnVisibleIndicator(Vector3 position, Vector3 dir)
		{
		}

		[ClientRpc]
		public void RpcDestroyVisibleIndicator()
		{
		}

		public void OnDestroy()
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcSpawnVisibleIndicator__Vector3__Vector3(Vector3 position, Vector3 dir)
		{
		}

		public static void InvokeUserCode_RpcSpawnVisibleIndicator__Vector3__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcDestroyVisibleIndicator()
		{
		}

		public static void InvokeUserCode_RpcDestroyVisibleIndicator(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static NpcChargedArrowsAbility()
		{
		}
	}
}
