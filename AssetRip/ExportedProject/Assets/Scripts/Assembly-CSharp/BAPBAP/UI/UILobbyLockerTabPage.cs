using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BAPBAP.Content;
using BAPBAP.Local;
using BAPBAP.Localisation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UILobbyLockerTabPage : UILobbyTabPage
	{
		public enum LockerPageIndex
		{
			Emotes = 0,
			Tombstones = 1,
			PlayerBanners = 2,
			Skins = 3
		}

		public enum ContentSortCriteria
		{
			Rarity = 0,
			Name = 1
		}

		public class Actions
		{
			public Action<int> equipPlayerBannerAction;

			public Action<int, int> equipSkinAction;
		}

		[Serializable]
		public class ContentSelectPanel
		{
			[Serializable]
			public class ContentTierButton
			{
				public GameObject gameObject;

				public Button button;

				public Image image;
			}

			public CanvasGroup canvasGroup;

			public UIPosLerpFade lerpFade;

			public UIAlphaFade alphaFade;

			public TMP_Text collectionText;

			public TMP_Text typeRarityText;

			public TMP_Text titleText;

			public TMP_Text descriptionText;

			public TMP_Text equipedText;

			public Image displayImage;

			public UIContentRarityStars rarityStars;

			public GameObject tierTypeButtonsContainer;

			public ContentTierButton[] tierTypeButtons;

			public Button equipButton;

			public TMP_Text equipButtonText;
		}

		[Serializable]
		public class LockerPage
		{
			public CanvasGroup canvasGroup;

			public UIPosLerpFade lerpFade;

			public UIAlphaFade alphaFade;

			public TMP_Text contentHeaderText;

			public TMP_Text emptyLockerText;

			public CustomScrollRect contentListScrollRect;

			public Transform contentParentTransform;

			public RectTransform viewportTransform;

			public Action OnOpenAction;

			public Action OnCloseAction;
		}

		[Serializable]
		public class EmotePanel : LockerPage
		{
			[Serializable]
			public class WheelPanel
			{
				public CanvasGroup canvasGroup;

				public UIPosLerpFade lerpFade;

				public UIAlphaFade alphaFade;

				public TMP_Text HeaderText;

				public GameObject MouseDescObj;

				public TMP_Text MouseDescText;

				public GameObject ControllerDescObj;

				public GameObject ControllerSlotObj;

				public TMP_Text AssignSlotControllerText;

				public TMP_Text ClearSlotControllerText;

				public TMP_Text CancelControllerText;

				public UISelectionWheel selectionWheel;

				public RectTransform selectionWheelTransform;
			}

			public WheelPanel EmoteWheelPanel;
		}

		[Serializable]
		public class TombstonePanel : LockerPage
		{
		}

		[Serializable]
		public class PlayerBannerPanel : LockerPage
		{
		}

		[Serializable]
		public class SkinsPanel : LockerPage
		{
			public UIDropdown CharacterDropdown;
		}

		[Serializable]
		public class Configuration
		{
			public ContentConfiguration contentConfig;

			public EmoteData emoteData;

			public TombstoneData tombstoneData;

			public PlayerBannerData playerBannerData;

			public SkinData skinsData;

			public UICharactersConfiguration CharactersConfiguration;

			public UILobbyContentEntry.Configuration EmoteEntryConfiguration;

			public UILobbyContentEntry.Configuration TombstoneEntryConfiguration;

			public UILobbyContentEntry.Configuration PlayerBannerEntryConfiguration;

			public UILobbyContentEntry.Configuration SkinsEntryConfiguration;

			public float wheelSelectWaitDuration;

			public float lockerEntryOpenDelay;

			public Color navButtonNormalColor;

			public Color navButtonPressedColor;

			public SFXData equipSfxData;

			[Header("Colors")]
			public float TabSelectedAlpha;

			public float TabUnselectedAlpha;

			public float TabSelectedNotificationAlpha;

			public float TabUnselectedNotificationAlpha;

			[NamedArray(typeof(ThemeMode), 0)]
			public ColorPalette[] originalThemePalette;

			[NamedArray(typeof(ThemeMode), 0)]
			public ColorPalette[] tabNotificationColor;

			[Header("Translation Keys")]
			public string EmptyLockerTranslationKey;

			public string EmoteHeaderTranslationKey;

			public string EmoteEquipedInWheelTranslationKey;

			public string TombstoneHeaderTranslationKey;

			public string TombstoneEquipedTranslationKey;

			public string PlayerBannerHeaderTranslationKey;

			public string PlayerBannerEquipedTranslationKey;

			public string SkinsHeaderTranslationKey;

			public string SkinsEquippedTranslationKey;

			public string ContentEquipButtonTranslationKey;

			public string ContentEquipedButtonTranslationKey;

			public string WheelClickToAssignToSlotTranslationKey;

			public string WheelClickToCancelTranslationKey;

			public string WheelAssignSlotControllerTranslationKey;

			public string WheelClearSlotControllerTranslationKey;

			public string WheelCancelControllerTranslationKey;
		}

		[CompilerGenerated]
		public sealed class _003CSearchRoutine_003Ed__148 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public UILobbyLockerTabPage _003C_003E4__this;

			public string searchStr;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CSearchRoutine_003Ed__148(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[SerializeField]
		public CanvasGroup _canvasGroup;

		[SerializeField]
		public Selectable _canvasGroupSelectable;

		[SerializeField]
		public UIPosLerpFade _uiLerpFade;

		[SerializeField]
		public UIAlphaFade _uiAlphaFade;

		[SerializeField]
		public UIAlphaFade _backgroundUIFade;

		[SerializeField]
		[Space(5f)]
		public CanvasGroup contentsCanvasGroup;

		[SerializeField]
		public UILobbySubNavButton emoteNavButton;

		[SerializeField]
		public UILobbySubNavButton tombstoneNavButton;

		[SerializeField]
		public UILobbySubNavButton playerBannerNavButton;

		[SerializeField]
		public UILobbySubNavButton skinsNavButton;

		[SerializeField]
		public ContentSelectPanel contentSelectPanel;

		[SerializeField]
		public EmotePanel emotePanel;

		[SerializeField]
		public TombstonePanel tombstonePanel;

		[SerializeField]
		public PlayerBannerPanel playerBannerPanel;

		[SerializeField]
		public SkinsPanel skinsPanel;

		[SerializeField]
		public List<UIDropdown> sortDropdowns;

		[NonSerialized]
		public Configuration _configuration;

		[NonSerialized]
		public Translator _translator;

		[NonSerialized]
		public LockerModel _data;

		[NonSerialized]
		public Actions _actions;

		public const string notificationKey = "NotifLocker=";

		[NonSerialized]
		public List<int> lockerAssetNotifications;

		[NonSerialized]
		public int currentLobbyPageId;

		[NonSerialized]
		public UILobbyContentEntry selectedContentEntry;

		[NonSerialized]
		public BAPBAP.Content.Content currentSelectedContent;

		[NonSerialized]
		public UILobbyContentEntry.Pool emotePool;

		[NonSerialized]
		public List<UILobbyContentEntry> emoteEntries;

		[NonSerialized]
		public string contentEquipButtonStr;

		[NonSerialized]
		public string contentEquipedButtonStr;

		[NonSerialized]
		public string emoteEquipedInWheelStr;

		[NonSerialized]
		public bool emoteWheelIsOpened;

		[NonSerialized]
		public float emoteWheelSuccessTimer;

		[NonSerialized]
		public string clickToAssignToSlotStr;

		[NonSerialized]
		public string clickToCancelStr;

		[NonSerialized]
		public UILobbyContentEntry.Pool tombstonePool;

		[NonSerialized]
		public List<UILobbyContentEntry> tombstoneEntries;

		[NonSerialized]
		public string tombstoneEquipedStr;

		[NonSerialized]
		public UILobbyContentEntry.Pool playerBannerPool;

		[NonSerialized]
		public List<UILobbyContentEntry> playerBannerEntries;

		[NonSerialized]
		public string playerBannerEquipedStr;

		[NonSerialized]
		public UILobbyContentEntry.Pool skinsPool;

		[NonSerialized]
		public List<UILobbyContentEntry> skinsEntries;

		[NonSerialized]
		public string skinsEquipedStr;

		[NonSerialized]
		public List<int> currentOwnedGroupAssetIds;

		[NonSerialized]
		public UIDropdown.DropdownOptionData[] _characterDropdownOptions;

		[NonSerialized]
		public UIDropdown.DropdownOptionData[] _sortDropdownOptions;

		[NonSerialized]
		public LockerPageIndex _currentLockerPage;

		[NonSerialized]
		public LockerPage[] lockerPages;

		[NonSerialized]
		public ContentSortCriteria _currentSortCriteria;

		[NonSerialized]
		public bool _sortDescending;

		[NonSerialized]
		public int dirtyFrameCountDefaultTab;

		[NonSerialized]
		public Coroutine _searchRoutine;

		[NonSerialized]
		public UILobbyPlayTabPage playTabPage;

		public override CanvasGroup CanvasGroup => null;

		public override Selectable CanvasGroupSelectable => null;

		public override UIPosLerpFade UILerpFade => null;

		public override UIAlphaFade UIAlphaFade => null;

		public override UIAlphaFade backgroundUIFade => null;

		public void FixedUpdate()
		{
		}

		public void Update()
		{
		}

		public void Build(Configuration configuration, Translator translator)
		{
		}

		public void LoadEmoteWheelOptions()
		{
		}

		public override void Localise(Translator translator)
		{
		}

		public void SetActions(Actions actions)
		{
		}

		public void Initialise(LockerModel data)
		{
		}

		public override void OnPageOpen()
		{
		}

		public override void OnPageClose()
		{
		}

		public override void OnInputModeChanged(InputMode inputMode)
		{
		}

		public void UpdateData(LockerModel data)
		{
		}

		public void UpdateAvailableCharactersData()
		{
		}

		public void AddContentEntry(BAPBAP.Content.Content content, List<UILobbyContentEntry> entryList, LockerPage panel, UILobbyContentEntry.Pool entryPool)
		{
		}

		public void RemoveContentEntry(int entryId, List<UILobbyContentEntry> entryList, LockerPage panel, UILobbyContentEntry.Pool entryPool)
		{
		}

		public void AddEmoteEntry(int assetId)
		{
		}

		public void AddEmoteEntry(Emote emote)
		{
		}

		public void RemoveEmoteEntry(int entryId)
		{
		}

		public void AddTombstoneEntry(int assetId)
		{
		}

		public void AddTombstoneEntry(Tombstone tombstone)
		{
		}

		public void RemoveTombstoneEntry(int entryId)
		{
		}

		public void AddPlayerBannerEntry(int assetId)
		{
		}

		public void AddPlayerBannerEntry(PlayerBanner playerBanner)
		{
		}

		public void RemovePlayerBannerEntry(int entryId)
		{
		}

		public void AddSkinEntry(int assetId)
		{
		}

		public void AddSkinEntry(Skin skin)
		{
		}

		public void RemoveSkinEntry(int entryId)
		{
		}

		public void AddContentEntryNotification(int assetId)
		{
		}

		public void RemoveContentEntryNotification(int assetId)
		{
		}

		public void UpdateContentEntryNotificationUI(UILobbyContentEntry entry, bool doShow)
		{
		}

		public void UpdateLockerTabNotifications()
		{
		}

		public bool NotificationAssetOffsetExists(int assetIdOffset)
		{
			return false;
		}

		public void GetAllSavedLockerAssetNotifications()
		{
		}

		public void SaveLockerAssetNotification(int assetId)
		{
		}

		public void DeleteLockerAssetNotification(int assetId)
		{
		}

		public void SetLockerPage(LockerPageIndex pageIndex)
		{
		}

		public void SetLockerNavButtonNotification(LockerPageIndex page, bool isEnabled)
		{
		}

		public void InitializeSelectPanelContent(BAPBAP.Content.Content content)
		{
		}

		public void OpenSelectPanel(bool fadePosLerp = true)
		{
		}

		public void CloseSelectPanel(bool instant = false)
		{
		}

		public void CloseSelectPanelAndClear()
		{
		}

		public void InitializeSelectPanelTierContentButtons(BAPBAP.Content.Content content)
		{
		}

		public void OnContentTierGroupButtonPressed(int buttonId)
		{
		}

		public void OnContentEquipButton()
		{
		}

		public void PlayEquipSfx()
		{
		}

		public void OpenAndSelectContent(BAPBAP.Content.Content content)
		{
		}

		public void SelectContentEntryByAssetId(List<UILobbyContentEntry> entryList, int assetId)
		{
		}

		public void OnContentEntrySelected(UILobbyContentEntry entry)
		{
		}

		public void OpenEmotePanel()
		{
		}

		public void CloseEmotePanel()
		{
		}

		public void InitializeEmoteEquipButtonState()
		{
		}

		public void OnEmoteEquipButton()
		{
		}

		public void OpenWheelPanel()
		{
		}

		public void CloseWheelPanel()
		{
		}

		public void TriggerWheelPanelSuccess()
		{
		}

		public void TriggerWheelPanelCancel()
		{
		}

		public void OnWheelOptionHovered(int optionId)
		{
		}

		public void OnWheelOptionUnhovered()
		{
		}

		public void OnWheelSelectClick()
		{
		}

		public void OnWheelRemoveClick()
		{
		}

		public void OnWheelOptionSelected(int optionId)
		{
		}

		public void OpenTombstonePanel()
		{
		}

		public void CloseTombstonePanel()
		{
		}

		public void SetTombstoneEquipButtonState()
		{
		}

		public void OnTombstoneEquipButton()
		{
		}

		public void OpenPlayerBannerPanel()
		{
		}

		public void ClosePlayerBannerPanel()
		{
		}

		public void SetPlayerBannerEquipButtonState()
		{
		}

		public void OnPlayerBannerEquipButton()
		{
		}

		public void OpenSkinsPanel()
		{
		}

		public void CloseSkinsPanel()
		{
		}

		public void OnSelectCharacterButton(int selectedIndex)
		{
		}

		public void SetSkinsEquipButtonState()
		{
		}

		public void OnSkinsEquipButton()
		{
		}

		public void UpdateDisplayedSkins(int selectedIndex)
		{
		}

		public void UpdateSkinsFromData()
		{
		}

		public bool ContentHasEntry(List<UILobbyContentEntry> entriesList, int assetId)
		{
			return false;
		}

		public bool TryGetContentEntryByAssetId(List<UILobbyContentEntry> entriesList, int assetId, out UILobbyContentEntry entry)
		{
			entry = null;
			return false;
		}

		public bool IsAssetUnlocked(int assetId)
		{
			return false;
		}

		public int GetContentGroupId(int assetId)
		{
			return 0;
		}

		public bool IsContentAssetIdEquipped(int assetId)
		{
			return false;
		}

		public Skin GetCharacterDefaultSkin(int charId)
		{
			return null;
		}

		public bool IsSkinADefaultSkin(Skin skin)
		{
			return false;
		}

		public void SearchContent(string searchStr)
		{
		}

		[IteratorStateMachine(typeof(_003CSearchRoutine_003Ed__148))]
		public IEnumerator SearchRoutine(string searchStr)
		{
			return null;
		}

		public void SelectSortOption(int sortTypeIndex)
		{
		}

		public void SortCurrentContent(ContentSortCriteria sortCriteria)
		{
		}

		public void ToggleAscendingSort()
		{
		}

		public void SortContent(List<UILobbyContentEntry> content, ContentSortCriteria sortCriteria)
		{
		}
	}
}
