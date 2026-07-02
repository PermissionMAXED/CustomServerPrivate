using UnityEngine;

namespace BAPBAP.Items
{
	[CreateAssetMenu(fileName = "LootTable", menuName = "BAPBAP/LootTables/New LootTable")]
	public class LootTableSO : ScriptableObject
	{
		[SerializeField]
		public LootTable lootTable;
	}
}
