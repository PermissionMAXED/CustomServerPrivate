using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_MoneyIsPower : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float damagePerGold;

			public int maxGoldAmount;

			public GameObject vfxFollowPrefab;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public int prevGold;

		[NonSerialized]
		public int vfxLoopId;

		public override PassiveConfiguration passiveConfig => null;

		public P_MoneyIsPower(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnItemsChanged(EntityManager cM)
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
