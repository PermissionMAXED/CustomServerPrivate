using System;
using System.Collections.Generic;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class HeavyPunchAbility : Ability
	{
		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public HeavyPunchAbility ability;

			public CustomShootSubroutine(HeavyPunchAbility _ability)
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
		public int maxStacks;

		[SerializeField]
		public int maxCharges;

		[SerializeField]
		public InputType inputType;

		[SerializeField]
		public bool doStacks;

		[Header("Hitbox-related")]
		[SerializeField]
		public int damage;

		[SerializeField]
		public float damageScaling;

		[SerializeField]
		public int damagePerStack;

		[SerializeField]
		public float damagePerStackScaling;

		[SerializeField]
		public float ttl;

		[SerializeField]
		public float slowBase;

		[SerializeField]
		public float slowPerStack;

		[SerializeField]
		public float slowDuration;

		[SerializeField]
		public float CDRPerPunch;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[SerializeField]
		[Header("State-related")]
		public float castingTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[Header("Indicator")]
		[SerializeField]
		public GameObject indicatorPrefab;

		[SerializeField]
		public Vector2 indicatorHalfScale;

		[SerializeField]
		public Vector2 indicatorOffset;

		[SerializeField]
		public float indicatorMaxDistance;

		[SerializeField]
		public bool indicatorDoCollision;

		[SerializeField]
		public bool indicatorClampToMouse;

		[SerializeField]
		public bool followMouse;

		[SerializeField]
		[Header("Effects")]
		public float camKickPower;

		[Header("VFX")]
		[SerializeField]
		public GameObject vfxCastPrefab;

		[Header("SFX")]
		[SerializeField]
		public AudioClipData sfxCast;

		[SerializeField]
		[Header("Animation")]
		public AnimLayerIndices animLayer;

		public int stacks;

		[NonSerialized]
		public byte EXT_TRIGGER_RESET;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public override void ResetCooldown()
		{
		}

		public void Shoot(Vector3 lookDir, int predTickNum)
		{
		}

		public void AddStack()
		{
		}

		public void DisplayStacksUI()
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
