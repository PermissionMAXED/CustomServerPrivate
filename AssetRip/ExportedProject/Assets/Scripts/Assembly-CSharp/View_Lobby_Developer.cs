using System;
using System.Collections.Generic;
using BAPBAP.Network;
using BAPBAP.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class View_Lobby_Developer : View
{
	public class Actions
	{
		public Action DeveloperLobbyAction;

		public Action<string, bool> JoinLobbyAction;
	}

	[SerializeField]
	public CanvasGroup _canvasGroup;

	[SerializeField]
	public Button _devLobbyButton;

	[SerializeField]
	public TMP_Dropdown _serversDropdown;

	[SerializeField]
	public TMP_InputField _lobbyIdInputField;

	[NonSerialized]
	public string _selectedDeveloperServerHostname;

	[NonSerialized]
	public int _selectedDeveloperServerWsPort;

	[NonSerialized]
	public InternalServerData _selectedServerData;

	[NonSerialized]
	public readonly List<InternalServerData> _cachedInternalServers;

	[NonSerialized]
	public bool IsDeveloperOptionsShown;

	[NonSerialized]
	public Actions _actions;

	[NonSerialized]
	public LobbyDataModel _lobbyDataModel;

	[NonSerialized]
	public UIManager uiManager;

	public void SetActions(Actions actions)
	{
	}

	public void Initialise(LobbyDataModel lobbyDataModel)
	{
	}

	public void Build()
	{
	}

	public void Update()
	{
	}

	public void ShowDeveloperPanel()
	{
	}

	public void HideDeveloperPanel()
	{
	}

	public void PopulateDeveloperServersDropdown(InternalServerData[] internalServers)
	{
	}

	public void ToggleDeveloperLobby()
	{
	}

	public void SendDeveloperLobbyId(string value)
	{
	}
}
