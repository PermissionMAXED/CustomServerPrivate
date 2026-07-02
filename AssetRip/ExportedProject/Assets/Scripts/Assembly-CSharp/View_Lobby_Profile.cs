using System;
using System.Collections.Generic;
using BAPBAP.Content;
using BAPBAP.Localisation;
using BAPBAP.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class View_Lobby_Profile : View
{
	[SerializeField]
	public CanvasGroup _canvasGroup;

	[SerializeField]
	public UILobbyPlayerContainer _playerContainer;

	[SerializeField]
	public TMP_Text _logoutButtonText;

	[Header("Buttons")]
	public Button LogoutButton;

	public Button BannerEditButton;

	[Header("Loader")]
	[SerializeField]
	public CanvasGroup _loaderCanvasGroup;

	[SerializeField]
	public UIAlphaFade _loaderAlphaFade;

	[SerializeField]
	public UIAlphaLoop _loaderAlphaLoop;

	[Header("History")]
	[SerializeField]
	public TMP_Text _titleText;

	[SerializeField]
	public TMP_Text _noMatchHistoryFoundText;

	[SerializeField]
	public Transform _historyEntryParentTransform;

	[SerializeField]
	public RectTransform _historyViewportTransform;

	[Header("Stats")]
	[SerializeField]
	public Transform _statsEntryParentTransform;

	[SerializeField]
	public RectTransform _statsViewportTransform;

	[SerializeField]
	[Header("Contents")]
	public CanvasGroup _contentsCanvasGroup;

	[SerializeField]
	public UIAlphaFade _contentsAlphaFade;

	[NonSerialized]
	public UILobbyHistoryEntry.Pool _historyEntryPool;

	[NonSerialized]
	public List<UILobbyHistoryEntry> _historyEntries;

	[NonSerialized]
	public UILobbyStatsEntry.Pool _statsEntryPool;

	[NonSerialized]
	public List<UILobbyStatsEntry> _statsEntries;

	[NonSerialized]
	public UILobbyProfileTabPage.Configuration _config;

	[NonSerialized]
	public ProfileModel _profileModel;

	[NonSerialized]
	public Translator _translator;

	public void Initialise(ProfileModel profileModel)
	{
	}

	public void Build(UILobbyProfileTabPage.Configuration profileConfig)
	{
	}

	public void Localise(Translator translator)
	{
	}

	public void RefreshView()
	{
	}

	public void UpdateDisplayedPlayerInfo(PlayerBanner banner, PlayerBannerData playerBannerData)
	{
	}

	public void ToggleLoader(bool isEnabled)
	{
	}
}
