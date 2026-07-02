using System;
using BAPBAP.Local;
using BAPBAP.Network;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnUse_Space_LmbFreeze : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float startCooldownTime;

			public float baseCooldown;

			public float freezeDuration;

			public float imbueDuration;

			public GameObject vfxReadyPrefab;

			public SFXData sfxReadyData;
		}

		public class CustomReadySubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_OnUse_Space_LmbFreeze passive;

			[NonSerialized]
			public byte triggerFinished;

			public CustomReadySubroutine(P_OnUse_Space_LmbFreeze _ability, byte _triggerFinished)
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

		public class CustomPassiveSubroutine : SimulationSubroutine
		{
			[NonSerialized]
			public P_OnUse_Space_LmbFreeze passive;

			[NonSerialized]
			public byte triggerFinished;

			[NonSerialized]
			public float timer;

			public CustomPassiveSubroutine(P_OnUse_Space_LmbFreeze _ability, byte _triggerFinished)
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

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public bool passiveReady;

		[NonSerialized]
		public bool passiveActive;

		[NonSerialized]
		public int bufferCount;

		[NonSerialized]
		public bool startBuffer;

		[NonSerialized]
		public CastFlags ability3Flags;

		[NonSerialized]
		public int triggeredAbilityId;

		public override PassiveConfiguration passiveConfig => null;

		public P_OnUse_Space_LmbFreeze(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnHitboxSpawned(GameObject g, EntityManager cM, int abilityId)
		{
		}

		public override void OnBonusHitboxSpawned(GameObject g, EntityManager cM, int abilityId)
		{
		}

		public void ModifyHitbox(GameObject g, EntityManager cM)
		{
		}

		public bool IsAbility3Active(int abilityId)
		{
			return false;
		}
	}
}
