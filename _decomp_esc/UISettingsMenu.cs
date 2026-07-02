using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Localisation;
using BAPBAP.Utilities;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI;

public class UISettingsMenu : MonoBehaviour
{
	public class UIProperty
	{
		public Transform parentHolder;

		public string propertyTranslationKey;

		public string descriptionTranslationKey;
	}

	[Serializable]
	public class UIPropertySelector : UIProperty
	{
		[NonSerialized]
		public UISelectorController controller;

		[SerializeField]
		public string enumTypeName;

		[NamedArrayParse("enumTypeName", 0)]
		public string[] optionTranslationKeys;
	}

	[Serializable]
	public class UIPropertyDropdown : UIProperty
	{
		[NonSerialized]
		public UIDropdownController controller;

		[SerializeField]
		public string enumTypeName;

		[NamedArrayParse("enumTypeName", 0)]
		public UIDropdown.DropdownOptionData[] optionData;
	}

	[Serializable]
	public class UIPropertySlider : UIProperty
	{
		[NonSerialized]
		public UISliderController controller;

		public RangeFloat controllerRange;

		public RangeFloat sliderRange;

		public bool wholeNumbers;

		public bool fireActionOnRelease;
	}

	[Serializable]
	public class UIPropertyToggle : UIProperty
	{
		[NonSerialized]
		public UIToggleController controller;
	}

	[NonSerialized]
	public LocalSavedData savedData;

	[NonSerialized]
	public UIManager uiManager;

	[NonSerialized]
	public UIChat uiChat;

	[NonSerialized]
	public InputManager inputManager;

	[NonSerialized]
	public InputSystem inputSystem;

	[Header("UI References")]
	[SerializeField]
	public UITabController[] tabControllers;

	[SerializeField]
	public Canvas canvas;

	[SerializeField]
	public CanvasGroup canvasGroup;

	[SerializeField]
	public GraphicRaycaster graphicRaycaster;

	[SerializeField]
	public RectMask2D contentMask;

	[SerializeField]
	public CustomScrollRect contentScrollRect;

	[SerializeField]
	public GameObject contentObj;

	[SerializeField]
	public Button fillBgCloseButton;

	[SerializeField]
	public Button closeButton;

	[SerializeField]
	public TMP_Text settingsHeaderText;

	[SerializeField]
	public UIModalWindowController logoutModalWindow;

	[SerializeField]
	public TMP_Text logOutButtonText;

	[SerializeField]
	public Button logOutButton;

	[SerializeField]
	public Button quitGameButton;

	[SerializeField]
	public TMP_Text quitGameButtonText;

	[SerializeField]
	public UIModalWindowController quitGameModalWindow;

	[SerializeField]
	public Button exitMatchButton;

	[SerializeField]
	public TMP_Text exitMatchButtonText;

	[SerializeField]
	public UIModalWindowController exitMatchModalWindow;

	[Header("Prefabs")]
	[SerializeField]
	public UIToggleController togglePrefab;

	[SerializeField]
	public UISelectorController selectorPrefab;

	[SerializeField]
	public UIDropdownController dropdownPrefab;

	[SerializeField]
	public UISliderController sliderPrefab;

	[SerializeField]
	public UIRebindKeyController bindKeyPrefab;

	[SerializeField]
	[Header("Settings References")]
	public TMP_Text sectionGeneralText;

	[SerializeField]
	public UIPropertyDropdown displayModeDropdown;

	[SerializeField]
	public UIPropertyDropdown resolutionDropdown;

	[SerializeField]
	public TMP_Text sectionInterfaceText;

	[SerializeField]
	public UIPropertyDropdown languageDropdown;

	[SerializeField]
	public UIPropertySlider uiScaleSlider;

	[SerializeField]
	public UIPropertyDropdown cursorModeDropdown;

	[SerializeField]
	public UIPropertyDropdown cursorDropdown;

	[SerializeField]
	public UIPropertyDropdown cursorColorDropdown;

	[SerializeField]
	public UIPropertyToggle displayPing;

	[SerializeField]
	public UIPropertyToggle displayFps;

	[SerializeField]
	public UIPropertyToggle displayGameVersion;

	[SerializeField]
	public UIPropertyToggle displayChatMessages;

	[SerializeField]
	public TMP_Text sectionPrivacyText;

	[SerializeField]
	public UIPropertyToggle anonymousMode;

	[SerializeField]
	public UIPropertyToggle openFriendRequest;

	[SerializeField]
	public UIPropertyToggle profanityFilter;

	[SerializeField]
	public UIPropertySlider cameraReach;

	[SerializeField]
	public UIPropertySlider cameraScrollSensitivity;

	[SerializeField]
	public UIPropertyToggle cameraMouseLock;

	[SerializeField]
	public UIPropertySelector quickCastAbilities;

	[SerializeField]
	[Header("Audio References")]
	public TMP_Text sectionVolumeText;

	[SerializeField]
	public UIPropertySlider generalVolumeSlider;

	[SerializeField]
	public UIPropertySlider musicVolumeSlider;

	[SerializeField]
	public UIPropertySlider gameMusicVolumeSlider;

	[SerializeField]
	public UIPropertySlider ambientVolumeSlider;

	[SerializeField]
	public UIPropertySlider sfxVolumeSlider;

	[SerializeField]
	public UIPropertySlider pingsVolumeSlider;

	[SerializeField]
	public UIPropertySlider voicelineVolumeSlider;

	[SerializeField]
	public UIPropertySlider uiVolumeSlider;

	[Header("Voice References")]
	[SerializeField]
	public UIPropertyDropdown voiceInputDeviceDropdown;

	[SerializeField]
	public UIPropertyDropdown voiceOutputDeviceDropdown;

	[SerializeField]
	public UIPropertySlider voiceInputVolumeSlider;

	[SerializeField]
	public UIPropertySlider voiceOutputVolumeSlider;

	[Header("Graphics References")]
	[SerializeField]
	public TMP_Text sectionDisplayText;

	[SerializeField]
	public UIPropertySelector frameRateLimitSelector;

	[SerializeField]
	public UIPropertySelector vSyncModeSelector;

	[SerializeField]
	public TMP_Text sectionQualityText;

	[SerializeField]
	public UIPropertySelector qualityPresetsSelector;

	[SerializeField]
	public UIPropertySlider renderScaleSlider;

	[SerializeField]
	public UIPropertySelector antialiasingSelector;

	[SerializeField]
	public UIPropertySelector realtimeShadowsSelector;

	[SerializeField]
	public UIPropertySelector ssaoSelector;

	[SerializeField]
	public UIPropertySelector bloomSelector;

	[SerializeField]
	public UIPropertySelector dofSelector;

	[SerializeField]
	public UIPropertySelector charLODSelector;

	[SerializeField]
	public UIPropertySelector charXRaySelector;

	[SerializeField]
	public UIPropertySelector reflectionsModeSelector;

	[SerializeField]
	public UIPropertySelector volumetricsModeSelector;

	[SerializeField]
	public UIPropertySelector environmentEffectsSelector;

	[Header("Controls References")]
	[SerializeField]
	public TMP_Text sectionInputText;

	[SerializeField]
	public UIPropertyDropdown inputDeviceDropdown;

	[SerializeField]
	public TMP_Text sectionGameplayKeysText;

	[SerializeField]
	public List<InputTarget> sectionGameplayKeysTargets;

	[SerializeField]
	public TMP_Text sectionMenuKeysText;

	[SerializeField]
	public List<InputTarget> sectionMenuKeysTargets;

	[Header("Settings")]
	[SerializeField]
	public AudioManager.SFX openWindowSfx;

	[SerializeField]
	public float openWindowSfxVolume;

	[SerializeField]
	public AudioManager.SFX closeWindowSfx;

	[SerializeField]
	public float closeWindowSfxVolume;

	[SerializeField]
	public Color tabSelectedColor;

	[Header("Translation Keys")]
	[SerializeField]
	public string settingsHeaderTranslationKey;

	[SerializeField]
	public string sectionGeneralTranslationKey;

	[SerializeField]
	public string sectionInterfaceTranslationKey;

	[SerializeField]
	public string sectionPrivacyTranslationKey;

	[SerializeField]
	public string sectionVolumeTranslationKey;

	[SerializeField]
	public string sectionDisplayTranslationKey;

	[SerializeField]
	public string sectionQualityTranslationKey;

	[SerializeField]
	public string sectionGameplayKeysTranslationKey;

	[SerializeField]
	public string sectionMenuKeysTranslationKey;

	[SerializeField]
	public string logOutButtonTranslationKey;

	[SerializeField]
	public string quitGameButtonTranslationKey;

	[SerializeField]
	public string logOutAreYourSureTranslationKey;

	[SerializeField]
	public string logOutProgressLostTranslationKey;

	[SerializeField]
	public string exitMatchButtonTranslationKey;

	[Header("Tab Bar Select")]
	[SerializeField]
	public float tabBarLerpSpeed;

	[SerializeField]
	public float tabBarWidthExtra;

	[SerializeField]
	public float tabSelectedAlpha;

	[SerializeField]
	public float tabUnselectedAlpha;

	[NonSerialized]
	public UITabController currentSelectedTab;

	[NonSerialized]
	public bool _isOpen;

	[NonSerialized]
	public bool _toggleKeyEnabled;

	[NonSerialized]
	public SystemLanguage _loadedLanguage;

	[NonSerialized]
	public Selectable lastFocusedSelectable;

	[NonSerialized]
	public bool _listeningForNewKey;

	[NonSerialized]
	public UIRebindKeyController _currentRebindButton;

	[NonSerialized]
	public Color tabNormalColor;

	[NonSerialized]
	public bool quitSettingEnabled;

	[NonSerialized]
	public bool changesDirty;

	[NonSerialized]
	public List<UIPropertyController> properties;

	[NonSerialized]
	public List<UIRebindKeyController> rebindProperties;

	[NonSerialized]
	public Translator translator;

	public bool IsOpen => false;

	public void Awake()
	{
	}

	public void SetPropertiesNavigation(UITabController tab)
	{
	}

	public void Start()
	{
	}

	public void OnVoiceInputDevicesAvailable(string[] deviceNames, int selected)
	{
	}

	public void OnVoiceOutputDevicesAvailable(string[] deviceNames, int selected)
	{
	}

	public void OnGuestChanged(bool isGuest)
	{
	}

	public void OpenLogoutModalWindow()
	{
	}

	public void OnFriendRequestsOpenChanged(bool isEnabled)
	{
	}

	public void OnInputModeChanged(InputMode inputMode)
	{
	}

	public void Localise(Translator translator)
	{
	}

	public void FixedUpdate()
	{
	}

	public void Update()
	{
	}

	public void OpenWindow()
	{
	}

	public void CloseWindow()
	{
	}

	public void OnModalWindowClosed()
	{
	}

	public void SetToggleWindowKeyEnabled(bool isEnabled)
	{
	}

	public void SelectTab(UITabController tabController)
	{
	}

	public void QuitGame()
	{
	}

	public void OnExitMatch()
	{
	}

	public void ShowExitMatchButton()
	{
	}

	public void HideExitMatchButton()
	{
	}

	public void UpdateLogOutButtonNavigation()
	{
	}

	public void OnPropertySelected(UIPropertyController propertyController)
	{
	}

	public void AddPropertySelector(UIPropertySelector selectorProperty, LocalSavedData.PropertyInt intProperty, Action<int> uiSetAction = null)
	{
	}

	public void AddPropertyDropdown(UIPropertyDropdown dropdownProperty, LocalSavedData.PropertyInt intProperty, Action<int> uiSetAction = null)
	{
	}

	public void AddPropertySlider(UIPropertySlider sliderProperty, LocalSavedData.PropertyFloat floatProperty, Action<float> uiSetAction = null)
	{
	}

	public void AddPropertyToggle(UIPropertyToggle toggleProperty, LocalSavedData.PropertyBool boolProperty, Action<bool> uiSetAction = null)
	{
	}

	public void AddKeyBindButton(Transform parent, InputTarget inputTarget)
	{
	}

	public void SetAudioMuted(bool isMuted)
	{
	}

	public void OnSetMusicVolume(float value)
	{
	}

	public void SetFullscreen(bool isFullscreen)
	{
	}

	public void OnSetDisplayMode(int selectedId)
	{
	}

	public void OnSetLanguage(int selectedId)
	{
	}

	public void UpdateCameraMouseLock(bool isEnabled)
	{
	}

	public void OnSetQualityPreset(int selectedId)
	{
	}

	public void ForceCustomQualityPreset()
	{
	}

	public void StartKeyBind(UIRebindKeyController rebindButton)
	{
	}

	public void UpdateListenForNewKeyBind()
	{
	}

	public void CompleteKeyBind()
	{
	}

	public bool TrySetNewKeyBind(InputBinding inputBinding, KeyCode newKey, UIRebindKeyController rebindButton)
	{
		return false;
	}

	public void SetKeyBind(InputBinding inputBinding, KeyCode newKey, UIRebindKeyController rebindButton, bool playSfx = true)
	{
	}

	public UIRebindKeyController GetRebindButtonByAction(InputBinding inputBinding)
	{
		return null;
	}
}
