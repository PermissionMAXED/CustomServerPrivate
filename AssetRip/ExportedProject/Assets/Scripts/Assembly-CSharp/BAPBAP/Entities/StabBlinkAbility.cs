using System;
using System.Collections.Generic;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class StabBlinkAbility : Ability
	{
		public class CustomTeleportLerpSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public StabBlinkAbility ability;

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

			public CustomTeleportLerpSubroutine(StabBlinkAbility _ability, byte _trigger, float _waitTime)
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

		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public StabBlinkAbility ability;

			public CustomShootSubroutine(StabBlinkAbility _ability)
			{
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
		public RotationLockType jumpRotationLockType;

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
		public Vector2 indicatorHalfScale;

		[SerializeField]
		public Vector2 indicatorOffset;

		[SerializeField]
		public bool indicatorDoCollision;

		[SerializeField]
		public bool indicatorClampToMouse;

		[SerializeField]
		[Header("Hitbox-related")]
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
		public float teleportLerpTime;

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
		public GameObject vfxLerpFollowPrefab;

		[SerializeField]
		public GameObject vfxLerpEndPrefab;

		[SerializeField]
		public GameObject vfxTeleportIndicatorPrefab;

		[SerializeField]
		[Header("SFX")]
		public AudioClipData sfxCast;

		[SerializeField]
		[Header("Animation")]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public float teleportDistance;

		[NonSerialized]
		public bool isRendererDisabled;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public void Shoot(Vector3 lookDir, Vector3 targetPos, float teleportDistance, int predTickNum)
		{
		}

		[ClientRpc]
		public void RpcSpawnVisibleIndicator(Vector3 lookDir, Vector3 targetPos, float teleportDistance)
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

		public void SetRendererEnabled(bool isEnabled)
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

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcSpawnVisibleIndicator__Vector3__Vector3__Single(Vector3 lookDir, Vector3 targetPos, float teleportDistance)
		{
		}

		public static void InvokeUserCode_RpcSpawnVisibleIndicator__Vector3__Vector3__Single(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static StabBlinkAbility()
		{
		}
	}
}
