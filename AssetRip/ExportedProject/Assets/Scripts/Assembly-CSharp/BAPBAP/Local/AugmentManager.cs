using System;
using System.Collections.Generic;
using BAPBAP.Entities;
using BAPBAP.Game;
using BAPBAP.Items;
using UnityEngine;

namespace BAPBAP.Local
{
	public class AugmentManager : MonoBehaviour
	{
		[Serializable]
		public class TierAugments
		{
			public PassiveSO[] common;

			public PassiveSO[] uncommon;

			public PassiveSO[] rare;

			public PassiveSO[] epic;

			public PassiveSO[] legendary;

			public PassiveSO[] Tier(int tierId)
			{
				return null;
			}
		}

		public class SelectionData
		{
			public enum SelectionType
			{
				Augment = 0,
				Pin = 1
			}

			public SelectionType type;

			public int tierId;

			public SelectionData(SelectionType type, int tierId)
			{
			}
		}

		public class AugmentSelection
		{
			public SelectionData data;

			public int[] selectionIds;

			public AugmentSelection(SelectionData.SelectionType type, int tierId, int[] selectionIds)
			{
			}
		}

		[NonSerialized]
		public ItemManager itemManager;

		[SerializeField]
		[ReadOnly]
		[Header("Configs")]
		public int augmentChoicesNum;

		[Min(0f)]
		[SerializeField]
		public int goldCostToReroll;

		[Tooltip("For each player, any augments on this list will not appear again if currently obtained")]
		[SerializeField]
		[Header("Non Repeatable Augments")]
		public PassiveSO[] nonRepeatableObtainedAugments;

		[Header("Character Specific Augments")]
		[SerializeField]
		public TierAugments[] charAugmentsByCharId;

		[SerializeField]
		[Header("Generic Augments")]
		public TierAugments genericAugments;

		[Header("Item Pin Selection")]
		[SerializeField]
		public GearType[] pinDrop;

		[NonSerialized]
		public List<int> augmentPool;

		public string CharArrayDrawer(int i)
		{
			return null;
		}

		public void PreAwake()
		{
		}

		public void Awake()
		{
		}

		public AugmentSelection GetRandAugmentSelection(SelectionData.SelectionType type, int tierId, int charId = -1, int[] excludedIds = null)
		{
			return null;
		}

		public int GetRandomAugmentSelectionTier(GameMode.AugmentSelectionChances augmentChances)
		{
			return 0;
		}

		public int[] GetAugmentSelection(int tierId, int charId = -1, int[] excludedAugments = null)
		{
			return null;
		}

		public int[] GetItemSelection(int tierId, int[] excludedIds = null)
		{
			return null;
		}
	}
}
