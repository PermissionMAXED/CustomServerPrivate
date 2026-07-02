using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.Content
{
	[CreateAssetMenu(fileName = "Tombstone", menuName = "BAPBAP/Content/Tombstones/Tombstone", order = 1)]
	public class TombstoneSO : ContentSO
	{
		public Tombstone tombstone;

		public override Content content => null;
	}
}
