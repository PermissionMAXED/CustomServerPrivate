using System;
using System.Collections.Generic;

namespace BAPBAP.Network
{
	[Serializable]
	public class MatchmakingGameData
	{
		public int reqId;

		public string queueId;

		public int matchmakingGameModeId;

		public int unityGameModeId;

		public int unityTeamSize;

		public float avgPoints;

		public List<MatchmakingScoreSheetData> scoreTable;

		public int mapId;

		public int[] gameModifierId;

		public List<MatchmakingDimensionData> dimensionData;

		public int charSelectMillis;

		public int spawnSelectMillis;

		public int spawnShowMillis;

		public override string ToString()
		{
			return null;
		}
	}
}
