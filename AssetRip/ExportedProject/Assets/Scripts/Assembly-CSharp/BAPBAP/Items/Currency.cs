using UnityEngine;

namespace BAPBAP.Items
{
	[CreateAssetMenu(fileName = "Currency", menuName = "BAPBAP/Items/Currency")]
	public class Currency : Item
	{
		public override Mesh GetMesh(int amount)
		{
			return null;
		}
	}
}
