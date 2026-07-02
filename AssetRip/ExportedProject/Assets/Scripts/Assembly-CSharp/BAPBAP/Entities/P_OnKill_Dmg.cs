using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnKill_Dmg : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float assistTimerCutoff;

			public int bonusDmg;

			[Header("FX Config")]
			public GameObject vfxTriggeredPrefab;

			public GameObject vfxLoopPrefab;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public int vfxLoopId;

		[NonSerialized]
		public int vfxReadyId;

		public override PassiveConfiguration passiveConfig => null;

		public P_OnKill_Dmg(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnKillTrigger(EntityManager otherCharManager)
		{
		}

		public override void OnAssistTrigger(EntityManager otherCharManager, float t)
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
