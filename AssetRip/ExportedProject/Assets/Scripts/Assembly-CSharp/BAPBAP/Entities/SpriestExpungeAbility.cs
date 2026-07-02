using System;
using System.Collections.Generic;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class SpriestExpungeAbility : Ability
	{
		public class CustomLoopVfxSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public Ability ability;

			[NonSerialized]
			public VFXStopParticles vfxStopParticlesAlly;

			[NonSerialized]
			public VFXStopParticles vfxStopParticlesEnemy;

			[NonSerialized]
			public bool isActive;

			[NonSerialized]
			public int teamId;

			public CustomLoopVfxSubroutine(Ability ability, GameObject loopVfxPrefabAlly, GameObject loopVfxPrefabEnemy, Transform attachTransform)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public void Stop()
			{
			}

			[ClientRpc]
			public void RpcStop()
			{
			}

			public void OnActiveChanged()
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

		public class CustomRecastSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public InputSystem inputSystem;

			[NonSerialized]
			public SpriestExpungeAbility ability;

			[NonSerialized]
			public byte finishedTrigger;

			[NonSerialized]
			public float dmgTimeElapsed;

			[NonSerialized]
			public bool animOff;

			public CustomRecastSubroutine(SpriestExpungeAbility ability, byte finishedTrigger)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}

			public void StopAnim()
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
		public RotationLockType castRotationLockType;

		[SerializeField]
		public bool applyAtkSpeedMultiplier;

		[SerializeField]
		public bool applyCooldownMultiplier;

		[SerializeField]
		public InputType inputType;

		[Header("Hitbox-related")]
		[SerializeField]
		public int damage;

		[SerializeField]
		public float damageRate;

		[SerializeField]
		public float damageScaling;

		[SerializeField]
		public float hitboxRadius;

		[SerializeField]
		public float playerHealPercent;

		[SerializeField]
		public float npcDmgPercent;

		[SerializeField]
		public float npcHealPercent;

		[SerializeField]
		public float lootboxDmgPercent;

		[SerializeField]
		public float lootboxHealPercent;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[SerializeField]
		[Header("State-related")]
		public float castingTime;

		[SerializeField]
		public float recoveryTime1;

		[SerializeField]
		public float recastDuration;

		[SerializeField]
		public float castingTime2;

		[SerializeField]
		public float recoveryTime2;

		[SerializeField]
		public float baseCooldownTime;

		[SerializeField]
		[Header("Indicator")]
		public GameObject indicatorPrefab;

		[SerializeField]
		public Vector2 indicatorMouseHalfScale;

		[SerializeField]
		public Vector2 indicatorBaseHalfScale;

		[SerializeField]
		public float indicatorMaxDistance;

		[SerializeField]
		public bool indicatorRotateWithDirection;

		[Header("Vfx")]
		[SerializeField]
		public GameObject ultLoopVfxAlly;

		[SerializeField]
		public GameObject ultLoopVfxEnemy;

		[SerializeField]
		public GameObject healVfx;

		[SerializeField]
		public float healVfxTime;

		[SerializeField]
		public Transform vfxAttachPoint;

		[SerializeField]
		[Header("Sfx")]
		public AudioClipData castSfx;

		[SerializeField]
		public AudioClipData detonateSfx;

		[SerializeField]
		public AudioClipData loopSfx;

		[SerializeField]
		public float detonateSfxWaitTime;

		[Header("Animation")]
		[SerializeField]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public float recastTimeElapsed;

		[NonSerialized]
		public bool ulting;

		[NonSerialized]
		public bool doHit;

		[NonSerialized]
		public CustomLoopVfxSubroutine loopVfxSubroutine;

		[NonSerialized]
		public List<EntityManager> entityHits;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public void Shoot(int predTickNum)
		{
		}

		public void Expunge()
		{
		}

		[Server]
		public override void OnTargetHit(EntityManager otherEntityManager, HitboxBase hitboxBase)
		{
		}

		[ClientRpc]
		public void RpcPlayHealFx()
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

		public void UserCode_RpcPlayHealFx()
		{
		}

		public static void InvokeUserCode_RpcPlayHealFx(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static SpriestExpungeAbility()
		{
		}
	}
}
