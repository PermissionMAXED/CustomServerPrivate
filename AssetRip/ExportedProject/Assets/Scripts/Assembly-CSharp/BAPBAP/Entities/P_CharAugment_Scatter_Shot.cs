using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_CharAugment_Scatter_Shot : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float scatterAmount;
		}

		[NonSerialized]
		public Config config;

		public override PassiveConfiguration passiveConfig => null;

		public P_CharAugment_Scatter_Shot(EntityManager entityManager, Config config)
			: base(null)
		{
		}
	}
}
