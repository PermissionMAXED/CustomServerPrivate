using System;
using BAPBAP.Items;
using UnityEngine;

namespace BAPBAP.Local
{
	[Serializable]
	public class ModelSwaps
	{
		public Item item;

		public GameObject meshPrefab;

		public float percentChance;

		public bool useOverrideAnimator;
	}
}
