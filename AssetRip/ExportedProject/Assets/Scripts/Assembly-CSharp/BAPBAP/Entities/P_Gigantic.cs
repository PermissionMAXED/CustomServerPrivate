using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_Gigantic : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float scale;
		}

		[NonSerialized]
		public Config config;

		public override PassiveConfiguration passiveConfig => null;

		public P_Gigantic(EntityManager entityManager, Config config)
			: base(null)
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
