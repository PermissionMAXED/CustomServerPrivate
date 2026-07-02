using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Items
{
	[CreateAssetMenu(fileName = "Gear", menuName = "BAPBAP/Items/Gear")]
	public class Gear : Item
	{
		[Header("Gear Settings")]
		public GearType gearType;

		public Stats primaryStatType;

		public ItemStat[] stats;

		public bool isUnique;

		public PassiveSO passive;
	}
}
