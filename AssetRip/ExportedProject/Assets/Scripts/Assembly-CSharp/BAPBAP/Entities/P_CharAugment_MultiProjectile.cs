using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_CharAugment_MultiProjectile : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float projectileSpreadDistance;
		}

		[NonSerialized]
		public Config config;

		public override PassiveConfiguration passiveConfig => null;

		public P_CharAugment_MultiProjectile(EntityManager entityManager, Config config)
			: base(null)
		{
		}
	}
}
