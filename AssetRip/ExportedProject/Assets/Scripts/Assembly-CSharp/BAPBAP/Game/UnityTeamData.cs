using System;
using System.Collections.Generic;

namespace BAPBAP.Game
{
	[Serializable]
	public class UnityTeamData
	{
		public string gameId;

		public List<UnityPlayerData> players;

		public override string ToString()
		{
			return null;
		}
	}
}
