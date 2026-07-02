using System;
using BAPBAP.Utilities;
using UnityEngine;

namespace BAPBAP.Items
{
	[Serializable]
	public class LootDropEntry
	{
		public enum RandomMode
		{
			Random = 0,
			WeightedChances = 1
		}

		public class Drop
		{
			[Range(0f, 1f)]
			public float dropChance;
		}

		[Serializable]
		public class GearDrop : Drop
		{
			public float[] tierProbability;

			[Tooltip("Should get a random gear type of the provided types? If empty, will default to all types")]
			[Space(10f)]
			public GearType[] overrideTierPool;

			[Range(0f, 1f)]
			[Tooltip("Random chance to spawn as unique gear")]
			[Space(10f)]
			public float uniqueChanceNorm;

			[Tooltip("Pool of unique items to replace all the spawned legendary gear items into")]
			public GearType[] overrideUniqueType;

			[Space(10f)]
			[Tooltip("Random chance to spawn as a gear pin")]
			[Range(0f, 1f)]
			public float pinChanceNorm;

			[Tooltip("If a random pin spawns Pool of pins to try to replace instead of gear")]
			public GearType[] overridePinGear;

			public static string TierLabel(int index)
			{
				return null;
			}
		}

		[Serializable]
		public class ItemDrop : Drop
		{
			public Item item;

			public IntRange amountRange;

			public bool HasAmount()
			{
				return false;
			}
		}

		[Serializable]
		public class ConsumableDrop : Drop
		{
			public Consumable consumable;
		}

		[Serializable]
		public class CurrencyDrop : Drop
		{
			public Currency currency;

			public IntRange amountRange;
		}

		[Serializable]
		public class HAXDrop : Drop
		{
			public LootableAbility lootableAbility;
		}

		[Tooltip("Editor only name of this loot drop, only for organizing purposes")]
		public string editorName;

		[Tooltip("The overall weight of this loot drop to be processed")]
		[Range(0f, 1f)]
		public float chance;

		[Tooltip("The random selection mode for the drop entries in this loot.\nRandom: Performs a random check to spawn for each entry.\nWeightedChances: Sums the chances of all entries, and selects a single one.")]
		public RandomMode randomMode;

		[Tooltip("The type of loot for this loot entry")]
		public LootType lootType;

		[Space(10f)]
		public ItemDrop[] items;

		[Space(10f)]
		public GearDrop[] gear;

		[Space(10f)]
		public ConsumableDrop[] consumables;

		[Space(10f)]
		public CurrencyDrop[] currency;

		[Space(10f)]
		public HAXDrop[] hax;

		public void DoRandomSelection(Drop[] array, Action<int> selectAction)
		{
		}
	}
}
