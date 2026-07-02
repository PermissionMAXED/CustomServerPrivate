using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class SlimeBossJumpAbility : Ability
	{
		public class CustomLookAtTargetSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public SlimeBossJumpAbility ability;

			public CustomLookAtTargetSubroutine(SlimeBossJumpAbility _ability)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		public class CustomEnableNavMeshSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public SlimeBossJumpAbility ability;

			public CustomEnableNavMeshSubroutine(SlimeBossJumpAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomSpawnIndicatorSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public SlimeBossJumpAbility ability;

			public CustomSpawnIndicatorSubroutine(SlimeBossJumpAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomDestroyIndicatorSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public SlimeBossJumpAbility ability;

			public CustomDestroyIndicatorSubroutine(SlimeBossJumpAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomJumpSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public SlimeBossJumpAbility ability;

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

			public CustomJumpSubroutine(SlimeBossJumpAbility _ability, byte _trigger, float _waitTime)
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

		[Header("State-related")]
		[SerializeField]
		public float castingTime;

		[SerializeField]
		public float jumpTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[SerializeField]
		public float offsetRngCooldown;

		[SerializeField]
		[Header("VFX")]
		public GameObject takeoffVfxId;

		[Header("SFX")]
		[SerializeField]
		public AudioClipData jumpSfx;

		[SerializeField]
		public AudioClipData castSfx;

		[SerializeField]
		public AudioClipData landVoSfx;

		[Header("Misc")]
		[SerializeField]
		public float zoomOutMultiplier;

		[SerializeField]
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
		public bool disabled;

		[NonSerialized]
		public byte EXT_TRIGGER_RESET;

		[NonSerialized]
		public NpcBehaviour behaviour;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public void SetCooldownToBase()
		{
		}

		public void ForceDisable()
		{
		}

		public void Shoot(Vector3 landingPosition, int predTickNum)
		{
		}

		public void ClDestroyVisibleIndicator()
		{
		}

		[ClientRpc]
		public void RpcSpawnVisibleIndicator(Vector3 position)
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

		public void UserCode_RpcSpawnVisibleIndicator__Vector3(Vector3 position)
		{
		}

		public static void InvokeUserCode_RpcSpawnVisibleIndicator__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcDestroyVisibleIndicator()
		{
		}

		public static void InvokeUserCode_RpcDestroyVisibleIndicator(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static SlimeBossJumpAbility()
		{
		}
	}
}
