using System;
using System.Collections.Generic;

namespace BAPBAP.Network;

[Serializable]
public class MatchmakingTeamData
{
	public int reqId;

	public string gameId;

	public int botTeams;

	public int botDifficulty;

	public int[] spawnLocationPerTeam;

	public List<MatchmakingPlayerData> players;

	public override string ToString()
	{
		return null;
	}
}
