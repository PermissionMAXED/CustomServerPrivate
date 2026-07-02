using System;

namespace BAPBAP.UI
{
	[Serializable]
	public class BattlePassLevelModel
	{
		public int level;

		public int xpNeeded;

		public ShopListingModel[] listings;
	}
}
