using System;
using System.Collections.Generic;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class SpriestSnareAbility : Ability
	{
		public class CustomLoopVfxSubroutine : LoopVfxSubroutine
		{
			public CustomLoopVfxSubroutine(Ability ability, GameObject loopVfxPrefab, Transform attachTransform)
				: base((Ability)null, (GameObject)null, (Transform)null)
			{
			}

			public override void OnExit(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomDestroyLoopVfxSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public LoopVfxSubroutine loopVfx;

			public CustomDestroyLoopVfxSubroutine(LoopVfxSubroutine _loopVfx)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		public class CustomWaitDestroyLoopVfxSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public SpriestSnareAbility ability;

			[NonSerialized]
			public LoopVfxSubroutine loopVfx;

			[NonSerialized]
			public CastFlags blockedCastFlags;

			[NonSerialized]
			public float time;

			[NonSerialized]
			public bool destroyed;

			public CustomWaitDestroyLoopVfxSubroutine(SpriestSnareAbility _ability, LoopVfxSubroutine _loopVfx, CastFlags _blockedCastFlags)
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

		public class CustomShootSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public SpriestSnareAbility ability;

			public CustomShootSubroutine(SpriestSnareAbility _ability)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
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
		public float abilityRadius;

		[SerializeField]
		[Header("Hitbox-related")]
		public int damage;

		[SerializeField]
		public float damageScaling;

		[SerializeField]
		public float hitboxRadius;

		[SerializeField]
		public float ttl;

		[SerializeField]
		public List<StatusEffectInfo> statusEffects;

		[Header("State-related")]
		[SerializeField]
		public float castingTime;

		[SerializeField]
		public float recoveryTime;

		[SerializeField]
		public float baseCooldownTime;

		[Header("Indicator")]
		[SerializeField]
		public GameObject indicatorPrefab;

		[SerializeField]
		public Vector2 indicatorMouseHalfScale;

		[SerializeField]
		public Vector2 indicatorBaseHalfScale;

		[SerializeField]
		public float indicatorMaxDistance;

		[SerializeField]
		public bool indicatorRotateWithDirection;

		[Header("Misc")]
		[SerializeField]
		public float impactTime;

		[Header("Effects")]
		[SerializeField]
		public GameObject vfxHandLoopPrefab;

		[SerializeField]
		public Transform vfxHandSpawn;

		[SerializeField]
		public float vfxHandDestroyTime;

		[SerializeField]
		public float camKickPower;

		[Header("SFX")]
		[SerializeField]
		public AudioClipData castSfx;

		[Header("Animation")]
		[SerializeField]
		public AnimLayerIndices animLayer;

		[NonSerialized]
		public int stacks;

		[NonSerialized]
		public byte EXT_TRIGGER_CHARGE;

		[NonSerialized]
		public LoopVfxSubroutine loopVfxSubroutine;

		public override void PreAwake(EntityManager _entityManager)
		{
		}

		public void Shoot(Vector3 landingPoint, int predTickNum)
		{
		}

		public void DisplayStacksUI()
		{
		}

		public void ReduceCD(float amount)
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
