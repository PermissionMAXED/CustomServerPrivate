using BAPBAP.Entities;
using UnityEngine;

namespace BAPBAP.Items
{
	[CreateAssetMenu(fileName = "LootableAbility", menuName = "BAPBAP/Items/LootableAbility")]
	public class LootableAbility : Item
	{
		[Header("Lootable Ability Settings")]
		public AbilityBehaviourSO behaviour;
	}
}
