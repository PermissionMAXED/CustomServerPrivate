using System;
using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Local
{
	public class GM_UseJuiceBoost : GameModifier
	{
		[Serializable]
		public class Config : GameModifierConfiguration
		{
			[Header("Custom Config")]
			public StatusEffectInfo[] statusEffect;

			public PassiveSO OnUsePotion_Invulnerable_Passive;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public int OnUsePotion_Invulnerable_PassiveId;

		public GM_UseJuiceBoost(Config _config = null)
		{
		}

		public override void Activate()
		{
		}

		public override void Deactivate()
		{
		}

		public override void OnPlayerCharSpawned(EntityManager entityManager)
		{
		}

		public void OnDisable(EntityManager entityManager)
		{
		}
	}
}
