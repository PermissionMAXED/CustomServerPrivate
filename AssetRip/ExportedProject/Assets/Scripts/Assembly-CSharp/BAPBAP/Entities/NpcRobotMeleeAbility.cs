using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class NpcRobotMeleeAbility : Ability
	{
		public class CustomCastVfxSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public NpcRobotMeleeAbility ability;

			[NonSerialized]
			public bool setEnabled;

			public CustomCastVfxSubroutine(NpcRobotMeleeAbility _ability, bool _setEnabled)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomVisibleIndicatorSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public NpcRobotMeleeAbility ability;

			[NonSerialized]
			public bool setEnabled;

			public CustomVisibleIndicatorSubroutine(NpcRobotMeleeAbility _ability, bool _setEnabled)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public NpcRobotMeleeAbility ability;

			public CustomShootSubroutine(NpcRobotMeleeAbility _ability)
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
		public RotationLockType castRotationLockType;

		[SerializeField]
		public bool applyAtkSpeedMultiplier;

		[SerializeField]
		public bool applyCooldownMultiplier;

		[SerializeField]
		[Header("Hitbox-related")]
		public int damage;

		[SerializeField]
		public float damageScaling;

		[SerializeField]
		public float ttl;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[SerializeField]
		[Header("State-related")]
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
		public float castSfxDelay;

		[SerializeField]
		public GameObject castVfxRight;

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

		public void CastSpell(Vector3 lookDir)
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
		public void RpcPlayCastVFX()
		{
		}

		[ClientRpc]
		public void RpcStopCastVFX()
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

		public void UserCode_RpcPlayCastVFX()
		{
		}

		public static void InvokeUserCode_RpcPlayCastVFX(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcStopCastVFX()
		{
		}

		public static void InvokeUserCode_RpcStopCastVFX(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static NpcRobotMeleeAbility()
		{
		}
	}
}
