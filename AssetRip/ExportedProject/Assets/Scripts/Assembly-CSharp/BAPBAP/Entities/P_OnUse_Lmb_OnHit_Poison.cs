using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnUse_Lmb_OnHit_Poison : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public int poisonStacks;

			public float imbueDuration;

			public float poisonDuration;

			public PassiveSO additionalPassiveToActivate;

			[Header("FX")]
			public GameObject vfxReadyPrefab;

			public GameObject vfxTriggeredPrefab;

			public SFXData sfxReadyData;

			public GameObject vfxLoopPrefab;
		}

		public class CustomReadySubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_OnUse_Lmb_OnHit_Poison passive;

			[NonSerialized]
			public byte triggerFinished;

			public CustomReadySubroutine(P_OnUse_Lmb_OnHit_Poison _ability, byte _triggerFinished)
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

		public class CustomActiveSubroutine : NetworkedSimulationSubroutine
		{
			[NonSerialized]
			public P_OnUse_Lmb_OnHit_Poison passive;

			[NonSerialized]
			public byte triggerFinished;

			[NonSerialized]
			public float elapsedTime;

			public CustomActiveSubroutine(P_OnUse_Lmb_OnHit_Poison _ability, byte _triggerFinished)
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
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public bool passiveReady;

		[NonSerialized]
		public bool passiveActive;

		[NonSerialized]
		public bool passiveTriggered;

		[NonSerialized]
		public List<EntityManager> hitList;

		[NonSerialized]
		public int vfxLoopId;

		[NonSerialized]
		public byte EXT_TRIGGER_RESET;

		[NonSerialized]
		public P_CooldownSubroutine cdSubroutine;

		public override PassiveConfiguration passiveConfig => null;

		public P_OnUse_Lmb_OnHit_Poison(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnHitboxSpawned(GameObject g, EntityManager cM, int abilityId)
		{
		}

		public override void OnHitTrigger(EntityManager cM, HitboxBase hitboxBase, int abilityId)
		{
		}

		public override void ClCustomEvent0()
		{
		}

		public override void ActivatePassive()
		{
		}

		public override void DeactivatePassive()
		{
		}

		public override void ClActivatePassive()
		{
		}

		public override void ClDeactivatePassive()
		{
		}
	}
}
