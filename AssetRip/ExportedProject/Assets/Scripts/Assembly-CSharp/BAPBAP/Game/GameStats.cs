using System;
using System.Collections.Generic;

namespace BAPBAP.Game
{
	[Serializable]
	public class GameStats
	{
		public string queueId;

		public int mapId;

		public int gameModeId;

		public string gameId;

		public int totalPlacements;

		public long startedAt;

		public long endedAt;

		[NonSerialized]
		public Dictionary<int, UnityPlayerData> playersCache;

		[NonSerialized]
		public HashSet<int> teamIdCache;

		public void Preload(string queueId, int mapId, int gameModeId)
		{
		}

		public void Start(string gameId)
		{
		}

		public void AddPlayer(int playerId, string username, int discriminator, string accountId, string lobbyCode, int points, int charId, int skinId, int teamId)
		{
		}

		public void AddPlayerConnected(int playerId)
		{
		}

		public void AddBot(int teamId)
		{
		}

		public void AddKill(int killerPlayerId, int killedPlayerId)
		{
		}

		public void AddAssist(int assistingPlayerId, int killedPlayerId)
		{
		}

		public void AddDamage(int atkPlayerId, int defPlayerId, int damage)
		{
		}

		public void AddHeal(int healedPlayerId, int amount)
		{
		}

		public void AddTeamEliminated(int teamId, int placement)
		{
		}

		public void AddFps(int playerId, int fps)
		{
		}

		public void AddPing(int playerId, int ping)
		{
		}

		public void RemoveAllItems(int playerId)
		{
		}

		public void AddItem(int playerId, int itemId)
		{
		}

		public void AddLootabableAbilityId(int playerId, int lootableId)
		{
		}

		public void RemoveAllAugments(int playerId)
		{
		}

		public void AddAugment(int playerId, int augmentId)
		{
		}

		public void MarkLeavePenalty(int playerId)
		{
		}

		public void End()
		{
		}

		public void Clear()
		{
		}

		public override string ToString()
		{
			return null;
		}
	}
}
