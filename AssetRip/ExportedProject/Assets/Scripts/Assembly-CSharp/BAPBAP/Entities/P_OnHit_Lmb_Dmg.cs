using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnHit_Lmb_Dmg : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public int countToBonusDmg;

			public int damage;

			public float timeOut;

			public float damageScaling;

			[Header("FX")]
			public GameObject vfxReadyPrefab;

			public GameObject vfxTriggeredPrefab;

			public GameObject vfxFollowPrefab;
		}

		public class CustomReadySubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_OnHit_Lmb_Dmg passive;

			[NonSerialized]
			public byte triggerFinished;

			[NonSerialized]
			public float timeElapsed;

			public CustomReadySubroutine(P_OnHit_Lmb_Dmg _ability, byte _triggerFinished)
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

		public class CustomActiveSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_OnHit_Lmb_Dmg passive;

			[NonSerialized]
			public byte triggerFinished;

			[NonSerialized]
			public float timeElapsed;

			public CustomActiveSubroutine(P_OnHit_Lmb_Dmg _ability, byte _triggerFinished)
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
		public bool passiveTriggered;

		[NonSerialized]
		public int count;

		[NonSerialized]
		public bool spawnedHitboxHit;

		[NonSerialized]
		public byte STATE_ACTIVE;

		[NonSerialized]
		public P_LoopVfxOrbitSubroutine readyVfxSubroutine;

		public override PassiveConfiguration passiveConfig => null;

		public P_OnHit_Lmb_Dmg(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnHitboxSpawned(GameObject g, EntityManager cM, int abilityId)
		{
		}

		public override void OnHitTrigger(EntityManager hittedEntity, HitboxBase hitboxBase, int abilityId)
		{
		}

		public void DoCount()
		{
		}

		public void DoActiveEffect(EntityManager hittedEntity, HitboxBase hitboxBase, int abilityId)
		{
		}

		public void ApplyBonusDamageHit(EntityManager entityToHit, int dmg, bool isCrit)
		{
		}

		public override void DeactivatePassive()
		{
		}

		public override void ClDeactivatePassive()
		{
		}

		public override void ClCustomEvent0()
		{
		}
	}
}
