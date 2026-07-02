using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class NpcSkullBlobBigSlamAbility : Ability
	{
		public class CustomLookAtTargetSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public NpcSkullBlobBigSlamAbility ability;

			public CustomLookAtTargetSubroutine(NpcSkullBlobBigSlamAbility _ability)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		public class CustomEnableNavAgentSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public NpcSkullBlobBigSlamAbility ability;

			public CustomEnableNavAgentSubroutine(NpcSkullBlobBigSlamAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomSpawnIndicatorSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public NpcSkullBlobBigSlamAbility ability;

			public CustomSpawnIndicatorSubroutine(NpcSkullBlobBigSlamAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomDestroyIndicatorSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public NpcSkullBlobBigSlamAbility ability;

			public CustomDestroyIndicatorSubroutine(NpcSkullBlobBigSlamAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomJumpSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public NpcSkullBlobBigSlamAbility ability;

			[NonSerialized]
			public byte trigger;

			[NonSerialized]
			public float waitTime;

			[NonSerialized]
			public float timeElapsed;

			[NonSerialized]
			public Vector3 originalPos;

			[NonSerialized]
			public Vector3 jumpPoint;

			public CustomJumpSubroutine(NpcSkullBlobBigSlamAbility _ability, byte _trigger, float _waitTime)
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

		[SerializeField]
		[Header("General")]
		public GameObject spellPrefab;

		[SerializeField]
		public MotionLockType castMotionLockType;

		[SerializeField]
		public RotationLockType castingRotationLockType;

		[SerializeField]
		public RotationLockType jumpRotationLockType;

		[SerializeField]
		public bool applyAtkSpeedMultiplier;

		[SerializeField]
		public bool applyCooldownMultiplier;

		[SerializeField]
		public InputType inputType;

		[SerializeField]
		public float maxRange;

		[SerializeField]
		public float maxDistToCancelCast;

		[SerializeField]
		public GameObject visibleIndicatorPrefab;

		[Header("Hitbox-related")]
		[SerializeField]
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
		public float randomjumpOffset;

		[SerializeField]
		[Header("State-related")]
		public float castingTime;

		[SerializeField]
		public float jumpTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[SerializeField]
		public float offsetRngCooldown;

		[Header("VFX")]
		[SerializeField]
		public GameObject takeoffVfxId;

		[SerializeField]
		[Header("SFX")]
		public AudioClipData castSfx;

		[SerializeField]
		public AudioClipData jumpSfx;

		[SerializeField]
		[Header("Misc")]
		public AnimationCurve jumpLerpCurve;

		[SerializeField]
		public AnimationCurve baseShadowAlphaCurve;

		[SerializeField]
		public float jumpRadiusCheck;

		[Header("Animation")]
		[SerializeField]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public GameObject currentIndicator;

		[NonSerialized]
		public Vector3 targetPosition;

		[NonSerialized]
		public byte EXT_TRIGGER_DISABLE;

		[NonSerialized]
		public NpcBehaviour behaviour;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public void OnDestroy()
		{
		}

		public void ForceDisable()
		{
		}

		public void Shoot(Vector3 position, int predTickNum)
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

		static NpcSkullBlobBigSlamAbility()
		{
		}
	}
}
