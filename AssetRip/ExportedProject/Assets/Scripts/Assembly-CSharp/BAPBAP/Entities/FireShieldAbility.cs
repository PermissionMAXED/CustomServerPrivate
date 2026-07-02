using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class FireShieldAbility : Ability
	{
		public class CustomShieldStartSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public FireShieldAbility ability;

			public CustomShieldStartSubroutine(FireShieldAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomShieldEndSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public FireShieldAbility ability;

			public CustomShieldEndSubroutine(FireShieldAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomShieldDestroyedSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public FireShieldAbility ability;

			[NonSerialized]
			public byte trigger;

			[NonSerialized]
			public int hp;

			public CustomShieldDestroyedSubroutine(FireShieldAbility _ability, byte _trigger)
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
		public MotionLockType castMotionLockType;

		[SerializeField]
		public bool applyAtkSpeedMultiplier;

		[SerializeField]
		public bool applyCooldownMultiplier;

		[SerializeField]
		public InputType inputType;

		[SerializeField]
		public int additiveShield;

		[SerializeField]
		public float additiveSpeed;

		[Header("Hitbox-related")]
		[SerializeField]
		public int damage;

		[SerializeField]
		public int damageRate;

		[SerializeField]
		public float damageScaling;

		[SerializeField]
		public float ttl;

		[SerializeField]
		public float hitboxActivateTime;

		[SerializeField]
		public float hitboxRadius;

		[Header("State-related")]
		[SerializeField]
		public float castingTime;

		[SerializeField]
		public float shieldTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[SerializeField]
		[Header("VFX")]
		public GameObject vfxLoopPrefab;

		[SerializeField]
		public Transform vfxLoopAttachTransform;

		[Header("SFX")]
		[SerializeField]
		public AudioClipData sfxCast;

		[SerializeField]
		public CharVoicelineConfig voicelineCast;

		[Header("Animation")]
		[SerializeField]
		public AnimLayerIndices animLayer;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public void Shoot()
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

		public override bool Weaved()
		{
			return false;
		}
	}
}
