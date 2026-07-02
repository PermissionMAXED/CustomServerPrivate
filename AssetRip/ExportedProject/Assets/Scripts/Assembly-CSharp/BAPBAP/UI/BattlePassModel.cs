using System.Collections.Generic;

namespace BAPBAP.UI
{
	public class BattlePassModel : Model
	{
		public int currentExp;

		public HashSet<int> claimedLevels;

		public BattlePassConfigModel battlePassConfigModel;
	}
}
