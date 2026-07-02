using System;
using System.Collections.Generic;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UIMessages : MonoBehaviour
	{
		public struct KillMessageInfo
		{
			public string killedName;

			public string totalKills;

			public bool squadEliminated;

			public bool downed;

			public KillMessageInfo(string _killedName, string _totalKills, bool _squadEliminated, bool _downed)
			{
				killedName = null;
				totalKills = null;
				squadEliminated = false;
				downed = false;
			}
		}

		public struct GameMessage
		{
			public string messageStr;

			public GameMessageType messageType;

			public GameMessage(string messageStr, GameMessageType messageType)
			{
				this.messageStr = null;
				this.messageType = default(GameMessageType);
			}
		}

		public enum GameMessageType
		{
			Alert = 0,
			Neutral = 1,
			Epic = 2
		}

		[NonSerialized]
		public UIManager uiManager;

		[Header("References")]
		[SerializeField]
		public Canvas messagesCanvas;

		[SerializeField]
		public UIGameMessageElement gameModeMessage;

		[SerializeField]
		public UIKillMessageElement killMessageElement;

		[SerializeField]
		public UIGameMessageElement augmentMessage;

		[Header("Prefabs")]
		[SerializeField]
		public GameObject killFeedElementPrefab;

		[Header("Message Settings")]
		[SerializeField]
		public float messageDuration;

		[NamedArray(typeof(GameMessageType), 0)]
		[SerializeField]
		public Color[] gameMessageColors;

		[NonSerialized]
		public List<KillMessageInfo> killMessages;

		[NonSerialized]
		public List<GameMessage> gameModeMessages;

		public void Start()
		{
		}

		public void SpawnKillPopUpMessage(string str, string totalKills, bool squadEliminated = false, bool downed = false)
		{
		}

		public void SpawnGameModeMessage(string str, GameMessageType messageType)
		{
		}

		public void UpdateKillMessage()
		{
		}

		public void UpdateGameModeMessage()
		{
		}

		public void ShowAugmentMessage()
		{
		}

		public void OnGameModeMessageEnded()
		{
		}
	}
}
