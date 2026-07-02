using System;
using UnityEngine.Scripting;

namespace BAPBAP.Network
{
	[Serializable]
	public class LeaderboardPreviewResponse
	{
		[Serializable]
		public class GameMode
		{
			[Preserve]
			public int gameModeId;

			[Preserve]
			public bool showRanks;

			[Preserve]
			public bool showPoints;

			[Preserve]
			public bool showCharacters;
		}

		[Preserve]
		public GameMode[] gameModes;
	}
}
