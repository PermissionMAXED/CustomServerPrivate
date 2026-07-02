using System;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UIKillFeed : MonoBehaviour
	{
		[NonSerialized]
		public UIManager uiManager;

		[Header("References")]
		[SerializeField]
		public RectTransform entryParent;

		[Header("Configuration")]
		[SerializeField]
		public UIKillFeedEntry.Configuration entryConfig;

		[NonSerialized]
		public UIKillFeedEntry.Pool _killFeedEntryPool;

		public void Awake()
		{
		}

		public void Initialize()
		{
		}

		public void SpawnKillFeedElement(int killerPlayerId, int killerCharId, string killerName, int killerTeamId, int killedPlayerId, int killedCharId, string killedName, int killedTeamId, int actionId)
		{
		}
	}
}
