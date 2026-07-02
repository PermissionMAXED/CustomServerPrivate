using System;
using System.Collections.Generic;
using BAPBAP.Localisation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class View_Career_History : View
	{
		[Serializable]
		public class PlayerInfoPanel
		{
			[SerializeField]
			public Image CharacterFullDisplayImage;

			[SerializeField]
			public TMP_Text CharacterNameText;

			[SerializeField]
			public TMP_Text UsernameText;

			[SerializeField]
			public TMP_Text DmgDealtText;

			[SerializeField]
			public TMP_Text DmgTakenText;

			[SerializeField]
			public RectTransform StatsLayoutGroup;

			[SerializeField]
			public List<ItemDisplay> Items;
		}

		[Serializable]
		public class ItemDisplay
		{
			[SerializeField]
			public Image ItemImage;

			[SerializeField]
			public Image ItemBg;
		}

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

		[SerializeField]
		[Header("Detailed Info")]
		public UIAlphaFade _overviewAlphaFade;

		[SerializeField]
		public UILobbyHistoryPlayerInfo _selfPlayerInfo;

		[SerializeField]
		public List<UILobbyHistoryPlayerInfo> _teammateInfos;

		[SerializeField]
		public Transform _teammateInfoContainer;

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
		public UILobbyProfileTabPage.Configuration _config;

		[NonSerialized]
		public UILobbyProfileTabPage.Actions _actions;

		[NonSerialized]
		public ProfileModel _profileModel;

		[NonSerialized]
		public Translator _translator;

		[NonSerialized]
		public UILobbyHistoryEntry _currentSelectedEntry;

		public void Initialise(ProfileModel profileModel)
		{
		}

		public void SetActions(UILobbyProfileTabPage.Actions actions)
		{
		}

		public void Build(UILobbyProfileTabPage.Configuration profileConfig)
		{
		}

		public void Localise(Translator translator)
		{
		}

		public void OpenPage()
		{
		}

		public void RefreshView()
		{
		}

		public void PopulateHistoryList()
		{
		}

		public void SelectHistoryElement(UILobbyHistoryEntry entry, ProfileModel.History history)
		{
		}

		public void ToggleLoader(bool isEnabled)
		{
		}

		public void DisplayHistoryInfo(ProfileModel.History history)
		{
		}

		public void OnDisable()
		{
		}
	}
}
