using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class BossChadTeleportAbility : Ability
	{
		public class CustomSetSequenceSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public BossChadTeleportAbility ability;

			public CustomSetSequenceSubroutine(BossChadTeleportAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomJumpSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public BossChadTeleportAbility ability;

			[NonSerialized]
			public byte triggerFinished;

			[NonSerialized]
			public byte triggerNext;

			[NonSerialized]
			public float waitTime;

			[NonSerialized]
			public float currentWaitTime;

			[NonSerialized]
			public float timeElapsed;

			[NonSerialized]
			public Vector3 originalPos;

			[NonSerialized]
			public Vector3 jumpPoint;

			public CustomJumpSubroutine(BossChadTeleportAbility _ability, byte _triggerFinished, float _waitTime, byte _triggerNext)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}

			public override void OnExit(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomVisibleIndicatorSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public BossChadTeleportAbility ability;

			[NonSerialized]
			public bool setEnabled;

			public CustomVisibleIndicatorSubroutine(BossChadTeleportAbility _ability, bool _setEnabled)
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
		public MotionLockType castMotionLockType;

		[SerializeField]
		public RotationLockType castRotationLockType;

		[SerializeField]
		public bool applyAtkSpeedMultiplier;

		[SerializeField]
		public bool applyCooldownMultiplier;

		[SerializeField]
		public InputType inputType;

		[SerializeField]
		public float maxRange;

		[SerializeField]
		public GameObject visibleIndicatorPrefab;

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
		public float hitboxRadius;

		[SerializeField]
		public float hitboxActivateTime;

		[SerializeField]
		public float randomOffset;

		[Header("State-related")]
		[SerializeField]
		public float castingTime;

		[SerializeField]
		public float jumpTime;

		[SerializeField]
		public float recoveryTime1min;

		[SerializeField]
		public float recoveryTime1max;

		[SerializeField]
		public float recoveryTime2;

		[SerializeField]
		public float baseCooldownTime;

		[Header("VFX")]
		[SerializeField]
		public GameObject takeoffVfxId;

		[Header("SFX")]
		[SerializeField]
		public AudioClipData castSfx;

		[SerializeField]
		public AudioClipData jumpSfx;

		[SerializeField]
		[Header("Animation")]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public GameObject currentIndicator;

		[NonSerialized]
		public Vector3 targetPosition;

		[NonSerialized]
		public byte EXT_TRIGGER_DISABLE;

		[NonSerialized]
		public NpcBehaviour behaviour;

		[NonSerialized]
		public ChadBossBehaviour chadBossBehaviour;

		[NonSerialized]
		public int teleportCount;

		[NonSerialized]
		public int currentTeleportCount;

		[NonSerialized]
		public Vector3 originPos;

		[NonSerialized]
		public List<Vector3> targetPositions;

		[NonSerialized]
		public RecoverySubroutine recoverySubroutine1;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public void ForceDisable()
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

		static BossChadTeleportAbility()
		{
		}
	}
}
