using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Gamekit3D
{
	public class InventoryController : MonoBehaviour
	{
		[Serializable]
		public class InventoryEvent
		{
			public string key;

			public UnityEvent OnAdd;

			public UnityEvent OnRemove;
		}

		[Serializable]
		public class InventoryChecker
		{
			public string[] inventoryItems;

			public UnityEvent OnHasItem;

			public UnityEvent OnDoesNotHaveItem;

			public bool CheckInventory(InventoryController inventory)
			{
				return false;
			}
		}

		public InventoryEvent[] inventoryEvents;

		[NonSerialized]
		public HashSet<string> inventoryItems;

		public void AddItem(string key)
		{
		}

		public void RemoveItem(string key)
		{
		}

		public bool HasItem(string key)
		{
			return false;
		}

		public void Clear()
		{
		}

		public InventoryEvent GetInventoryEvent(string key)
		{
			return null;
		}
	}
}
