using System;
using System.Collections.Generic;

namespace BAPBAP.Network
{
	[Serializable]
	public class MatchmakingScoreSheetData
	{
		public string tier;

		public int max;

		public List<int> placements;

		public int kills;

		public override string ToString()
		{
			return null;
		}
	}
}
