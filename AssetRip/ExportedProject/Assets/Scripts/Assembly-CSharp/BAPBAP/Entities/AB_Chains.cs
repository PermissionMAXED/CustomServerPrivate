using System;
using System.Collections.Generic;
using System.Text;
using BAPBAP.Local;
using BAPBAP.Network;
using Mirror;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class AB_Chains : AbilityBehaviour
	{
		[Serializable]
		public class Config : AbilityBehaviourConfig
		{
			[Header("Custom Config")]
			public MotionLockType motionLockType;

			public RotationLockType rotationLockType;

			public float startCooldownTime;

			public float castTime;

			[ConditionalHide("cancelable", true)]
			public float canceledTime;

			public float channelingTime;

			public float baseCooldown;

			[Header("VFX/SFX")]
			public GameObject vfxCast;

			public AudioClipData sfxCast;

			[Space(5f)]
			public GameObject loopVfx;

			public AudioClipData loopSfx;

			[Space(5f)]
			public GameObject vfxUse;

			public AudioClipData sfxUse;

			[Space(5f)]
			public GameObject vfxChanneling;

			public AudioClipData sfxChanneling;

			public GameObject vfxChannelEnd;

			[Header("Hitbox Config")]
			public float ttl;

			public GameObject hitboxChainPrefab;

			public float hitboxRadius;

			public int damage;

			public float damageScaling;

			public List<StatusEffectInfo> statusEffects;

			public bool counterable;

			[Header("Chain Apply Config")]
			public GameObject chainTetherPrefab;

			public float applyDuration;

			public float castChainRange;

			public float chainRange;

			public int applyDamage;

			public StatusEffectInfo[] applyStatusEffects;
		}

		public class CustomWaitForInputSubroutine : WaitForInputSubroutine
		{
			[NonSerialized]
			public AB_Chains behaviour;

			public CustomWaitForInputSubroutine(AB_Chains behaviour, Ability ability, byte trigger, InputType inputType, CastFlags blockedCastFlags = CastFlags.Ability1 | CastFlags.Ability2 | CastFlags.Ability3 | CastFlags.Ability4, InputSource inputSource = InputSource.Any, byte buttonUpTrigger = 0)
				: base(null, 0, default(InputType), default(CastFlags), default(InputSource), 0)
			{
			}

			public override void OnExit(float fixedDt, Command cmd, bool isResim)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		public class CustomUIInRangeSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public AB_Chains behaviour;

			public CustomUIInRangeSubroutine(AB_Chains _behaviour)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}
		}

		public class CustomDisableFXSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public AB_Chains behaviour;

			[NonSerialized]
			public float rangeSqr;

			[NonSerialized]
			public int count;

			public CustomDisableFXSubroutine(AB_Chains _behaviour)
			{
			}

			public override byte OnTick(float fixedDt, Command cmd, bool isResim)
			{
				return 0;
			}

			public void UpdateCount(int oldValue)
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

		public class CustomUseSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public AB_Chains behaviour;

			public CustomUseSubroutine(AB_Chains _behaviour)
			{
			}

			public override void OnEnter(float fixedDt, Command cmd, bool isResim)
			{
			}
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public Collider[] hits;

		[NonSerialized]
		public bool enemiesInRange;

		[NonSerialized]
		public List<EntityManager> hittedEntities;

		[NonSerialized]
		public LoopVfxSubroutine loopVfxSubroutine;

		[NonSerialized]
		public LoopSfxSubroutine loopSfxSubroutine;

		[NonSerialized]
		public LoopVfxSubroutine vfxChannelEnd;

		public AB_Chains(Config config)
		{
		}

		public override void Build(Ability ability, int itemId)
		{
		}

		public void ProcessEnemiesInRange()
		{
		}

		public void DoUse(int predTickNum)
		{
		}

		public override void OnTargetHit(EntityManager otherEntityManager, HitboxBase hitbox)
		{
		}
	}
}
