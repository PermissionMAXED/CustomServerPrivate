using System;
using BAPBAP.Items;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnUse_Space_Spawn_Consumable : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public Consumable consumableToDrop;
		}

		[NonSerialized]
		public Config config;

		public override PassiveConfiguration passiveConfig => null;

		public P_OnUse_Space_Spawn_Consumable(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void OnHitboxSpawned(GameObject g, EntityManager cM, int abilityId)
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
