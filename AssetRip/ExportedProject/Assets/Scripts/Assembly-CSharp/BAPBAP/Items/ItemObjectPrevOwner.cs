using System;
using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Items
{
	public class ItemObjectPrevOwner : MonoBehaviour
	{
		[NonSerialized]
		public ItemObject itemObject;

		[SerializeField]
		[Header("Settings")]
		public float prevOwnerCdDuration;

		[NonSerialized]
		public float prevOwnerTimer;

		[NonSerialized]
		public CharItems prevOwner;

		public void Awake()
		{
		}

		public void Initialize(ItemObject _itemObject, CharItems prevOwnerChar)
		{
		}

		public void Reset()
		{
		}

		public void StartCd()
		{
		}

		public bool IsPreviousOwner(CharItems charItems)
		{
			return false;
		}

		public void TryPrevOwnerPickup()
		{
		}

		public void Update()
		{
		}
	}
}
