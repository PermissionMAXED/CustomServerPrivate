using System;
using BAPBAP.Localisation;
using BAPBAP.UI;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class View_Lobby_OpenLobbyToggle : View, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
{
	[Serializable]
	public class Configuration
	{
		public string LobbyLabelTranslationKey;

		public string OpenLobbyTranslationKey;

		public string ClosedLobbyTranslationKey;

		public Color OpenLobbyTextColor;

		public Color ClosedLobbyTextColor;
	}

	public class Actions
	{
		public Action<bool> SwitchLobbyOpenAction;
	}

	[SerializeField]
	public TextMeshProUGUI _lobbyStatusText;

	[SerializeField]
	public TextMeshProUGUI _lobbyStatusPlayTabText;

	[SerializeField]
	public Toggle _lobbyStatusToggle;

	[SerializeField]
	public UIToggle _lobbyStatusUIToggle;

	[SerializeField]
	public CanvasGroup _lobbyStatusCanvasGroup;

	[SerializeField]
	public UIHoverTooltip _tooltipHover;

	[SerializeField]
	public UIAlphaFade _tooltipAlphaFade;

	[NonSerialized]
	public Actions _actions;

	[NonSerialized]
	public Configuration _config;

	[NonSerialized]
	public LobbyDataModel _lobbyDataModel;

	[NonSerialized]
	public string _lobbyLabelPrefixStr;

	[NonSerialized]
	public string _lobbyOpenStr;

	[NonSerialized]
	public string _lobbyClosedStr;

	public void Initialise(LobbyDataModel lobbyDataModel)
	{
	}

	public void Localise(Translator translator)
	{
	}

	public void Build(Configuration toggleConfig)
	{
	}

	public void SetActions(Actions actions)
	{
	}

	public void ForceUpdateToggleState(bool isOn)
	{
	}

	public void UpdateToggleUI(LobbyDataModel lobbyDataModel)
	{
	}

	public void UpdateOpenStatusText(bool isOpen)
	{
	}

	public void OnLobbyOpenToggle(bool isOpen)
	{
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
	}

	public void OnPointerExit(PointerEventData eventData)
	{
	}
}
