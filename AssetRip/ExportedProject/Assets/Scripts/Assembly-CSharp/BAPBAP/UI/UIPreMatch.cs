using System;
using System.Collections.Generic;
using BAPBAP.Game;
using BAPBAP.Network;
using BAPBAP.Player;
using TMPro;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UIPreMatch : MonoBehaviour
	{
		public UILobbyConfiguration LobbyConfig;

		public View_PreMatch_CharSelect CharSelect;

		public View_PreMatch_SpawnSelect SpawnSelect;

		[Header("UI")]
		[SerializeField]
		public GameObject _preMatchParentObject;

		[SerializeField]
		public UIAlphaFade _loadingAlphaFade;

		[SerializeField]
		public Transform _chatParent;

		[SerializeField]
		public TMP_Text _timerText;

		[SerializeField]
		public GameObject _timerParentObject;

		[SerializeField]
		public GameObject _bannerParentObject;

		[SerializeField]
		public View_PreMatch_PlayerDisplay _localPlayerDisplay;

		[SerializeField]
		public List<View_PreMatch_PlayerDisplay> _teammateDisplays;

		[NonSerialized]
		public GameManager _gameManager;

		[NonSerialized]
		public UIManager _uiManager;

		public void Awake()
		{
		}

		public void LateUpdate()
		{
		}

		public void PopulatePreMatchUI(QueueMatchedData qmd)
		{
		}

		public void UpdatePreMatchUI(QueueMatchedData qmd)
		{
		}

		public void OpenLoadingPanel()
		{
		}

		public void OpenCharacterSelect()
		{
		}

		public void OpenSpawnSelect()
		{
		}

		public void TransitionToGame()
		{
		}

		public void SetLocalPlayerCharacter(int newCharId, bool animate = false)
		{
		}

		public void SetTeammateCharacter(PlayerManager teammate, int newCharId)
		{
		}

		public void SetLocalPlayerCharLocked()
		{
		}

		public void SetTeammateCharLocked(PlayerManager teammate)
		{
		}

		public void ForceClose()
		{
		}
	}
}
