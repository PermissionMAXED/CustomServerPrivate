using System;
using System.Collections.Generic;

namespace BAPBAP.Network
{
	[Serializable]
	public class QueueMatchedData
	{
		public int reqId;

		public string gameId;

		public List<MatchmakingPlayerData> players;

		public int botTeams;

		public int botDifficulty;

		public int[] availableCharacters;

		public override string ToString()
		{
			return null;
		}
	}
}
