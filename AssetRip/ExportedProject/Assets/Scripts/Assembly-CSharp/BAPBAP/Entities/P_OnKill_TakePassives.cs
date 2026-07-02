using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnKill_TakePassives : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public GameObject vfxReadyPrefab;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public int vfxReadyId;

		public override PassiveConfiguration passiveConfig => null;

		public P_OnKill_TakePassives(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnKillTrigger(EntityManager otherCharManager)
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
