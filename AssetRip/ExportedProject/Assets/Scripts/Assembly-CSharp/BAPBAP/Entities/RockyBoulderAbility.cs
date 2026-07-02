using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class RockyBoulderAbility : Ability
	{
		public class CustomCooldownSubroutine : CooldownSubroutine
		{
			[NonSerialized]
			public bool resetCDOnEnter;

			public CustomCooldownSubroutine(Ability ability, byte trigger, float time, bool applyCdMultiplier, bool applyAtkSpeedMultiplier)
				: base(null, 0, 0f, applyCdMultiplier: false, applyAtkSpeedMultiplier: false)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}

			public void DontResetCDTime()
			{
			}
		}

		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public RockyBoulderAbility ability;

			public CustomShootSubroutine(RockyBoulderAbility _ability)
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
		public GameObject boulderPickupPrefab;

		[SerializeField]
		public Transform firingPoint;

		[SerializeField]
		public MotionLockType castMotionLockType;

		[SerializeField]
		public bool applyAtkSpeedMultiplier;

		[SerializeField]
		public bool applyCooldownMultiplier;

		[SerializeField]
		public InputType inputType;

		[SerializeField]
		public float shieldAmount;

		[SerializeField]
		public float shieldHealthPercent;

		[SerializeField]
		public float shieldDuration;

		[Header("Hitbox-related")]
		[SerializeField]
		public int damage;

		[SerializeField]
		public float damageScaling;

		[SerializeField]
		public float speed;

		[SerializeField]
		public float ttl;

		[SerializeField]
		public float boulderPickupTtl;

		[SerializeField]
		public AnimationCurve speedCurve;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

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

		[Header("State-related")]
		[SerializeField]
		public float castingTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[SerializeField]
		public float cdReductionAmount;

		[SerializeField]
		[Header("Effects")]
		public float camKickPower;

		[SerializeField]
		public GameObject boulderPickupFX;

		[Header("SFX")]
		[SerializeField]
		public AudioClipData sfxCast;

		[Header("Animation")]
		[SerializeField]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public CustomCooldownSubroutine customCooldownSubroutine;

		public override void PreAwake(EntityManager _charManager)
		{
		}

		public void Shoot(Vector3 lookDir, int predTickNum)
		{
		}

		[Server]
		public void Pickup()
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

		[Server]
		public void OnBoulderHitSuccess(EntityManager hittedEntity, HitboxBase hitboxBase)
		{
		}

		[ClientRpc]
		public void RpcPlayPickupFx()
		{
		}

		public override bool Weaved()
		{
			return false;
		}

		public void UserCode_RpcPlayPickupFx()
		{
		}

		public static void InvokeUserCode_RpcPlayPickupFx(NetworkBehaviour obj, NetworkReader reader, NetworkConnectionToClient senderConnection)
		{
		}

		static RockyBoulderAbility()
		{
		}
	}
}
