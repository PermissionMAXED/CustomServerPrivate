using System;
using BAPBAP.Items;
using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_Gain_Items : Passive
	{
		[Serializable]
		public class Config : PassiveConfiguration
		{
			[Header("Custom Config")]
			public LootDropEntry.GearDrop[] gearDrops;
		}

		[NonSerialized]
		public Config config;

		[NonSerialized]
		public ItemManager itemManager;

		public override PassiveConfiguration passiveConfig => null;

		public P_Gain_Items(EntityManager entityManager, Config config)
			: base(null)
		{
		}

		public override void ActivatePassive()
		{
		}

		public void SpawnRandomItems(LootDropEntry.GearDrop[] randomItemDrops, Vector3 spawnWorldPosition, float spawnRadius)
		{
		}

		public int[] GetRandomItemIds(LootDropEntry.GearDrop[] randomItemDrops)
		{
			return null;
		}

		public int GetRandomItemId(LootDropEntry.GearDrop randomItemDrop)
		{
			return 0;
		}

		public int GetRandomType()
		{
			return 0;
		}
	}
}
