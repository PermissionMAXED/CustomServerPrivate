using System;
using System.Collections.Generic;
using BAPBAP.Items;

namespace BAPBAP.Local
{
	[Serializable]
	public struct GearData
	{
		public GearType type;

		public List<Item> tiers;
	}
}
