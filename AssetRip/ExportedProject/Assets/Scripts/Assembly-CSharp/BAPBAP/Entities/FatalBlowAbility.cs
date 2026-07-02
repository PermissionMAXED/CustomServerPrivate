using System;
using System.Collections.Generic;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class FatalBlowAbility : Ability
	{
		public class CustomTeleportSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public FatalBlowAbility ability;

			[NonSerialized]
			public byte trigger;

			[NonSerialized]
			public float waitTime;

			[NonSerialized]
			public LayerMask obstacleMask;

			[NonSerialized]
			public float timeElapsed;

			[NonSerialized]
			public Vector3 originalPos;

			[NonSerialized]
			public Vector3 targetPos;

			public CustomTeleportSubroutine(FatalBlowAbility _ability, byte _trigger, float _waitTime)
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

		public class CustomAttackSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public FatalBlowAbility ability;

			public CustomAttackSubroutine(FatalBlowAbility _ability)
			{
			}

			public override void OnExit(float fixedDt, Command cmd, bool isResim)
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
		[Header("Indicator")]
		public GameObject indicatorPrefab;

		[SerializeField]
		public Vector2 indicatorMouseHalfScale;

		[SerializeField]
		public Vector2 indicatorBaseHalfScale;

		[SerializeField]
		public Vector2 indicatorOffset;

		[SerializeField]
		public float indicatorMaxDistance;

		[SerializeField]
		public bool indicatorRotateWithDirection;

		[SerializeField]
		public GameObject visibleIndicatorPrefab;

		[SerializeField]
		public GameObject visibleIndicatorEnemyPrefab;

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
		public float hitboxZOffset;

		[SerializeField]
		public float hitboxConeAngleHalf;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[Header("State-related")]
		[SerializeField]
		public float castingTime;

		[SerializeField]
		public float teleportTime;

		[SerializeField]
		public float attackTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[SerializeField]
		public float startCooldownTime;

		[Header("Misc")]
		[SerializeField]
		public AnimationCurve jumpLerpCurve;

		[SerializeField]
		public float teleportMaxDistance;

		[SerializeField]
		public float teleportRadiusCheck;

		[Header("Effects")]
		[SerializeField]
		public float camShakeTrauma;

		[Header("VFX")]
		[SerializeField]
		public GameObject vfxCastPrefab;

		[SerializeField]
		public GameObject vfxTeleportPrefab;

		[SerializeField]
		public GameObject vfxTeleportEndPrefab;

		[SerializeField]
		[Header("SFX")]
		public AudioClipData sfxCast;

		[SerializeField]
		public AudioClipData sfxTeleport;

		[Header("Animation")]
		[SerializeField]
		public AnimLayerIndices animLayer;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public void Shoot(Vector3 lookDir, int predTickNum)
		{
		}

		public override string GetTooltipDescription()
		{
			return null;
		}

		public override string GetTooltipExpandedDescription()
		{
			return null;
		}

		[ClientRpc]
		public void RpcSpawnVisibleIndicator(Vector3 position, Vector3 forward)
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcSpawnVisibleIndicator__Vector3__Vector3(Vector3 position, Vector3 forward)
		{
		}

		public static void InvokeUserCode_RpcSpawnVisibleIndicator__Vector3__Vector3(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static FatalBlowAbility()
		{
		}
	}
}
