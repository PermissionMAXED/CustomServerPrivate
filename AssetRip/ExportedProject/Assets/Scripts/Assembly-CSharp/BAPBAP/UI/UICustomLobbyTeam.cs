using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UICustomLobbyTeam : MonoBehaviour
	{
		[SerializeField]
		[Header("Options")]
		public string _teamPrefixKey;

		[SerializeField]
		[Header("References")]
		public UICustomLobbyPlayer _playerPrefab;

		[SerializeField]
		public Transform _playersContainer;

		[SerializeField]
		public TextMeshProUGUI _teamNameText;

		[SerializeField]
		public Button _joinButton;

		[NonSerialized]
		public Dictionary<PlayerModel, UICustomLobbyPlayer> _spawnedPlayers;

		public const string STATUS_TEXT_LEADER = "Leader";

		public const string STATUS_TEXT_WAITING = "Waiting...";

		public const string STATUS_TEXT_READY = "Ready!";

		public void Init(int teamIndex, UnityAction<int> joinButtonAction)
		{
		}

		public void AddPlayer(PlayerModel player)
		{
		}

		public void UpdatePlayerStatus(PlayerModel player)
		{
		}

		public void RemovePlayer(PlayerModel player)
		{
		}

		public void ClearAllPlayers()
		{
		}
	}
}
