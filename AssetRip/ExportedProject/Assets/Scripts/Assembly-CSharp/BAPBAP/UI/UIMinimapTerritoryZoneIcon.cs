using UnityEngine;

namespace BAPBAP.UI
{
	public class UIMinimapTerritoryZoneIcon : UIMinimapDirIcon
	{
		[SerializeField]
		public Color allyColor;

		[SerializeField]
		public Color enemyColor;

		[SerializeField]
		public Color uncapturedColor;

		[SerializeField]
		public Color inactiveColor;

		public void SetColorByTeam(int teamId)
		{
		}
	}
}
