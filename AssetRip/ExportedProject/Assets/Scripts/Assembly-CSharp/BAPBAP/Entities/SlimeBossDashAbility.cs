using System;
using System.Collections.Generic;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class SlimeBossDashAbility : Ability
	{
		public class CustomLookAtTargetSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public SlimeBossDashAbility ability;

			public CustomLookAtTargetSubroutine(SlimeBossDashAbility _ability)
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

		public class CustomSpawnIndicatorSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public SlimeBossDashAbility ability;

			public CustomSpawnIndicatorSubroutine(SlimeBossDashAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomVisibleIndicatorSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public SlimeBossDashAbility ability;

			[NonSerialized]
			public bool setEnabled;

			public CustomVisibleIndicatorSubroutine(SlimeBossDashAbility _ability, bool _setEnabled)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomDashSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public SlimeBossDashAbility ability;

			[NonSerialized]
			public byte finishTrigger;

			[NonSerialized]
			public float jumpTime;

			[NonSerialized]
			public float timeElapsed;

			public CustomDashSubroutine(SlimeBossDashAbility ability, byte finishTrigger, float jumpTime)
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

			public override void OnNetDeserialize(NetworkReader netReader)
			{
			}

			public override void OnNetSerialize(NetworkWriter netWriter)
			{
			}

			public override bool OnNetDebugCompare(NetworkReader netReader)
			{
				return false;
			}

			public override void OnNetDebugLog(StringBuilder sb)
			{
			}
		}

		[SerializeField]
		[Header("General")]
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
		public InputType inputType;

		[SerializeField]
		public float maxRange;

		[SerializeField]
		public float impulseSpeed;

		[SerializeField]
		public float impulseDeceleration;

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
		[Header("State-related")]
		public float castingTime;

		[SerializeField]
		public float jumpTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[Header("Indicator")]
		[SerializeField]
		public GameObject visibleIndicatorPrefab;

		[SerializeField]
		public float indicatorLength;

		[SerializeField]
		public float indicatorWidth;

		[Header("VFX")]
		[SerializeField]
		public GameObject castVfxId;

		[Header("SFX")]
		[SerializeField]
		public AudioClipData jumpSfx;

		[SerializeField]
		public AudioClipData jumpVoSfx;

		[SerializeField]
		public AudioClipData jumpEndSfx;

		[Header("Animation")]
		[SerializeField]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public NpcBehaviour behaviour;

		[NonSerialized]
		public GameObject currentVisibleIndicator;

		[NonSerialized]
		public Vector3 targetPosition;

		[NonSerialized]
		public bool disabled;

		[NonSerialized]
		public byte EXT_TRIGGER_RESET;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public void ForceDisable()
		{
		}

		public void Shoot(Vector3 lookDir, int predTickNum)
		{
		}

		public void ClDestroyVisibleIndicator()
		{
		}

		[ClientRpc]
		public void RpcSpawnVisibleIndicator(float duration, Vector3 targetPos)
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

		public void UserCode_RpcSpawnVisibleIndicator__Single__Vector3(float duration, Vector3 targetPos)
		{
		}

		public static void InvokeUserCode_RpcSpawnVisibleIndicator__Single__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		public void UserCode_RpcDestroyVisibleIndicator()
		{
		}

		public static void InvokeUserCode_RpcDestroyVisibleIndicator(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static SlimeBossDashAbility()
		{
		}
	}
}
