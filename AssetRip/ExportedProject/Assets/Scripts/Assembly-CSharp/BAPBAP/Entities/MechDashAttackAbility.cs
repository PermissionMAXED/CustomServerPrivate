using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class MechDashAttackAbility : Ability
	{
		public class CustomCastVfxSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public MechDashAttackAbility ability;

			[NonSerialized]
			public bool setEnabled;

			public CustomCastVfxSubroutine(MechDashAttackAbility _ability, bool _setEnabled)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomVisibleIndicatorSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public MechDashAttackAbility ability;

			[NonSerialized]
			public bool setEnabled;

			public CustomVisibleIndicatorSubroutine(MechDashAttackAbility _ability, bool _setEnabled)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomDashSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public MechDashAttackAbility ability;

			[NonSerialized]
			public byte finishTrigger;

			[NonSerialized]
			public byte silenceTrigger;

			[NonSerialized]
			public float dashDurationTime;

			[NonSerialized]
			public AnimLayerIndices animLayer;

			[NonSerialized]
			public float timeElapsed;

			public CustomDashSubroutine(MechDashAttackAbility _ability, byte _finishTrigger, byte _silenceTrigger, float _dashDurationTime, AnimLayerIndices _animLayer)
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
		public Transform firingPoint;

		[SerializeField]
		public MotionLockType castMotionLockType;

		[SerializeField]
		public RotationLockType castRotationLockType;

		[SerializeField]
		public RotationLockType dashRotationLockType;

		[SerializeField]
		public bool applyAtkSpeedMultiplier;

		[SerializeField]
		public bool applyCooldownMultiplier;

		[SerializeField]
		public InputType inputType;

		[Header("Hitbox-related")]
		[SerializeField]
		public float followRotationSpeed;

		[SerializeField]
		public float dashSpeed;

		[SerializeField]
		public int damage;

		[SerializeField]
		public float damageScaling;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[Header("State-related")]
		[SerializeField]
		public float castingTime;

		[SerializeField]
		public float dashDurationTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[SerializeField]
		[Header("Indicator")]
		public GameObject visibleIndicatorPrefab;

		[SerializeField]
		public float indicatorWidth;

		[SerializeField]
		[Tooltip("The length of the hitbox, not to be mistaken by the dash length")]
		public float indicatorHitboxLength;

		[SerializeField]
		[Header("Effects")]
		public AudioClipData sfxCast;

		[SerializeField]
		public float castSfxDelay;

		[SerializeField]
		public GameObject castVfxRight;

		[SerializeField]
		public GameObject castVfxLeft;

		[Header("Animation")]
		[SerializeField]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public Hitbox spawnedHitbox;

		[NonSerialized]
		public GameObject currentVisibleIndicator;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public void CastSpell(Vector3 lookDir)
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

		public void OnDestroy()
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

		static MechDashAttackAbility()
		{
		}
	}
}
