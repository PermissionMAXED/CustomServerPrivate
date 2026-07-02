using System;
using System.Collections.Generic;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class FireyEmpoweredDashAbility : Ability
	{
		public class CustomWaitForInputSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public InputSystem inputSystem;

			[NonSerialized]
			public FireyEmpoweredDashAbility ability;

			[NonSerialized]
			public byte castTrigger;

			[NonSerialized]
			public byte aimTrigger;

			[NonSerialized]
			public CastFlags blockedCastFlags;

			public CustomWaitForInputSubroutine(FireyEmpoweredDashAbility ability, byte castTrigger, byte aimTrigger)
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

		public class CustomDashLerpSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public FireyEmpoweredDashAbility ability;

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

			public CustomDashLerpSubroutine(FireyEmpoweredDashAbility _ability, byte _trigger, float _waitTime)
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
			public FireyEmpoweredDashAbility ability;

			public CustomShootSubroutine(FireyEmpoweredDashAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomRecastSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public InputSystem inputSystem;

			[NonSerialized]
			public FireyEmpoweredDashAbility ability;

			[NonSerialized]
			public byte castTrigger;

			[NonSerialized]
			public byte aimTrigger;

			[NonSerialized]
			public byte finishedTrigger;

			[NonSerialized]
			public bool checkedRecast;

			[NonSerialized]
			public CastFlags blockedCastFlags;

			public CustomRecastSubroutine(FireyEmpoweredDashAbility ability, byte castTrigger, byte aimTrigger, byte finishedTrigger)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}

			public void CheckRecast()
			{
			}

			public override void OnExit(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomEndRecastSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public FireyEmpoweredDashAbility ability;

			public CustomEndRecastSubroutine(FireyEmpoweredDashAbility ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomPostRecastSilenceSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public FireyEmpoweredDashAbility ability;

			[NonSerialized]
			public byte castTrigger;

			[NonSerialized]
			public byte finishedTrigger;

			public CustomPostRecastSilenceSubroutine(FireyEmpoweredDashAbility ability, byte castTrigger, byte finishedTrigger)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		[SerializeField]
		[Header("General")]
		public GameObject spellPrefab;

		[SerializeField]
		public RotationLockType jumpRotationLockType;

		[SerializeField]
		public bool applyAtkSpeedMultiplier;

		[SerializeField]
		public bool applyCooldownMultiplier;

		[SerializeField]
		public InputType inputType;

		[Header("Indicator")]
		[SerializeField]
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
		public float bonusDamagePercent;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[SerializeField]
		[Header("State-related")]
		public float castingTime;

		[SerializeField]
		public float teleportLerpTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[SerializeField]
		public float recastDuration;

		[SerializeField]
		public float recastDelay;

		[SerializeField]
		public int maxRecastCharges;

		[SerializeField]
		public float dashBufferLagTime;

		[SerializeField]
		[Header("Misc")]
		public AnimationCurve jumpLerpCurve;

		[SerializeField]
		public float teleportMaxDistance;

		[SerializeField]
		public float teleportRadiusCheck;

		[SerializeField]
		[Header("Effects")]
		public float camShakeTrauma;

		[SerializeField]
		public GameObject normalKatana;

		[SerializeField]
		public GameObject empoweredKatana;

		[SerializeField]
		[Header("VFX")]
		public GameObject vfxLerpFollowId;

		[SerializeField]
		public GameObject vfxLerpEndId;

		[SerializeField]
		public GameObject vfxTeleportIndicatorPrefab;

		[Header("SFX")]
		[SerializeField]
		public RandomAudioClipPool sfxCastPool;

		[Header("Animation")]
		[SerializeField]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public float teleportDistance;

		[NonSerialized]
		public int recastsCounter;

		[NonSerialized]
		public bool hitSuccess;

		[NonSerialized]
		public float recastTimeElapsed;

		[NonSerialized]
		public bool bonusEnabled;

		[NonSerialized]
		public KatanaMeleeAbility katanaMeleeAbility;

		[NonSerialized]
		public bool doReset;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		[ClientRpc]
		public void RpcSpawnVisibleIndicator(Vector3 lookDir, Vector3 targetPos, float teleportDistance)
		{
		}

		public override void ResetCooldown()
		{
		}

		public void Shoot(Vector3 lookDir, Vector3 targetPos, int predTickNum, float teleportDistance)
		{
		}

		[Server]
		public override void OnTargetHit(EntityManager otherCharManager, HitboxBase hitboxBase)
		{
		}

		public void StopRecastEffect()
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

		public void BonusChanged()
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

		static FireyEmpoweredDashAbility()
		{
		}
	}
}
