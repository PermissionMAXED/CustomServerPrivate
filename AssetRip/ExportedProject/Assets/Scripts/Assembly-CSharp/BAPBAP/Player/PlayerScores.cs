using System;
using Mirror;
using UnityEngine;

namespace BAPBAP.Player
{
	public class PlayerScores : NetworkBehaviour
	{
		[NonSerialized]
		public PlayerManager playerManager;

		[NonSerialized]
		public int kills;

		[NonSerialized]
		public int deaths;

		[NonSerialized]
		public int assists;

		[NonSerialized]
		public int damageDealt;

		[NonSerialized]
		public int damageReceived;

		[NonSerialized]
		public int fishingXp;

		[SerializeField]
		public int pointsPerKill;

		[SerializeField]
		public int pointsPerAssist;

		[SerializeField]
		public int pointsPerDmgDealt;

		[SerializeField]
		public int pointsPerDmgTaken;

		public void Initialize(PlayerManager _playerManager)
		{
		}

		public static string GetTotalKillsString(int totalKills)
		{
			return null;
		}

		public void ClearStats()
		{
		}

		public int GetMvpSquadMemberPlayerId()
		{
			return 0;
		}

		public int GetPlayerScore(PlayerScores playerScores)
		{
			return 0;
		}

		public override bool Weaved()
		{
			return false;
		}
	}
}
