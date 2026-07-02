using System;
using System.Collections.Generic;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class FireyChargedProjectileAbility : Ability
	{
		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public FireyChargedProjectileAbility ability;

			public CustomShootSubroutine(FireyChargedProjectileAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomConsumeChargeSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public FireyChargedProjectileAbility ability;

			public CustomConsumeChargeSubroutine(FireyChargedProjectileAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomDestroyLoopVfxSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public FireyChargedProjectileAbility ability;

			[NonSerialized]
			public LoopVfxSubroutine loopVfx;

			public CustomDestroyLoopVfxSubroutine(FireyChargedProjectileAbility _ability, LoopVfxSubroutine _loopVfx)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomWaitForChargesSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public FireyChargedProjectileAbility ability;

			[NonSerialized]
			public byte triggerFinished;

			[NonSerialized]
			public float timeElapsed;

			public CustomWaitForChargesSubroutine(FireyChargedProjectileAbility _ability, byte _triggerFinished)
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
		public int maxCharges;

		[SerializeField]
		public int stacksToCharge;

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
		public bool singleTarget;

		[SerializeField]
		public bool destroyOnCollision;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[Header("State-related")]
		[SerializeField]
		public float castingTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[SerializeField]
		public float startCooldownTime;

		[Header("Effects")]
		[SerializeField]
		public float camShakeTrauma;

		[Header("VFX")]
		[SerializeField]
		public Transform vfxFiringPoint;

		[SerializeField]
		public GameObject castVfxId;

		[SerializeField]
		public GameObject muzzleVfxId;

		[SerializeField]
		public GameObject vfxUltReadyPrefab;

		[SerializeField]
		[Header("SFX")]
		public RandomAudioClipPool sfxCastPool;

		[SerializeField]
		[Header("Animation")]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public int stacks;

		[NonSerialized]
		public int currentCharges;

		[NonSerialized]
		public LoopVfxSubroutine loopVfxSubroutine;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public override void ResetCooldown()
		{
		}

		public override void LoadAbilityUI()
		{
		}

		public void Shoot(Vector3 lookDir, int predTickNum)
		{
		}

		public void AddStack()
		{
		}

		public void AddCharge()
		{
		}

		public void RemoveCharge()
		{
		}

		public void DisplayStacksUI()
		{
		}

		public void SetChargesState()
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

		public void OnStacksChanged()
		{
		}

		public void OnCurrentChargesChanged()
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
	}
}
