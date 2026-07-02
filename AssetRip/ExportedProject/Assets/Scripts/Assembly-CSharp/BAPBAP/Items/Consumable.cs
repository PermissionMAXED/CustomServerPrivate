using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Items
{
	[CreateAssetMenu(fileName = "Consumable", menuName = "BAPBAP/Items/Consumable")]
	public class Consumable : Item
	{
		[Header("Consumable Settings")]
		public AbilityBehaviourSO consumableBehaviour;

		[Min(1f)]
		public int maxCount;

		[Min(1f)]
		public bool droppable;
	}
}
