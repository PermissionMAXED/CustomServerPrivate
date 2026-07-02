using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_ExpertFishing : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public int xpNeededForLevel;

			public PassiveSO healthyFishingPassive;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public int healthyFishingPassiveId;

		[NonSerialized]
		public int currentLevel;

		public override PassiveConfiguration passiveConfig => null;

		public P_ExpertFishing(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void DeactivatePassive()
		{
		}

		public override void ActivatePassive()
		{
		}

		public override void AddFloat1(float f)
		{
		}
	}
}
