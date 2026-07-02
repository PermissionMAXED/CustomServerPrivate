using System;
using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnKill_Reset_All : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float percentCDToLower;

			public float assistTimerCutoff;

			public float sprintDuration;

			public float sprintMultiplier;

			public GameObject vfxReadyPrefab;

			public GameObject vfxTriggeredPrefab;

			public SFXData sfxTriggeredData;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public P_SpawnVfxSubroutine triggeredVfxSubroutine;

		[NonSerialized]
		public int vfxReadyId;

		public override PassiveConfiguration passiveConfig => null;

		public P_OnKill_Reset_All(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnKillTrigger(EntityManager otherCharManager)
		{
		}

		public override void OnAssistTrigger(EntityManager otherCharManager, float t)
		{
		}

		public void DoUse()
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
