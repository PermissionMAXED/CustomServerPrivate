using System;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnUse_Potion_Invulnerable : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public float duration;
		}

		[NonSerialized]
		public Config config;

		public override PassiveConfiguration passiveConfig => null;

		public P_OnUse_Potion_Invulnerable(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnConsumeConsumableTrigger(EntityManager cM, int consumableItemId)
		{
		}
	}
}
