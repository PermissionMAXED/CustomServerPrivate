using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.Content
{
	[CreateAssetMenu(fileName = "MasteryBadge", menuName = "BAPBAP/Content/MasteryBadges/MasteryBadge", order = 1)]
	public class MasteryBadgeSO : ContentSO
	{
		public MasteryBadge masteryBadge;

		public override Content content => null;
	}
}
