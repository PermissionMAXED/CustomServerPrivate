using System;
using BAPBAP.Items;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_Give_Item : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public Item itemToGive;

			public bool allowDuplicates;

			[Header("FX Config")]
			public GameObject vfxLoopPrefab;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public int vfxLoopId;

		public override PassiveConfiguration passiveConfig => null;

		public P_Give_Item(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void ActivatePassive()
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
