using System;
using BAPBAP.Local;
using BAPBAP.Localisation;
using BAPBAP.UI;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class View_Lobby_InviteCodePage : View
{
	[Serializable]
	public class Configuration
	{
		public string HeaderTranslationKey;

		public string SubheaderTranslationKey;

		public string InvalidCodeTranslationKey;

		public string HintTranslationKey;

		public string UnblockedTranslationKey;

		public float UnblockedNotificationTime;

		public SFXData IncorrectCodeSFXData;

		public SFXData CorrectCodeSFXData;
	}

	public class Actions
	{
		public Action<string> SubmitCodeAction;
	}

	[SerializeField]
	public UIAlphaFade _uiAlphaFade;

	[SerializeField]
	public UIAlphaFade _unblockedAlphaFade;

	[SerializeField]
	public CanvasGroup _canvasGroup;

	[SerializeField]
	public TextMeshProUGUI _headerText;

	[SerializeField]
	public TextMeshProUGUI _subheaderText;

	[SerializeField]
	public TextMeshProUGUI _hintText;

	[SerializeField]
	public TextMeshProUGUI _unblockedText;

	[SerializeField]
	public TMProUGUIHyperlinks _hintTextLinks;

	[SerializeField]
	public TMP_InputField _codeInputField;

	[SerializeField]
	public UIToggleSpriteSwap _muteButtonSpriteSwap;

	[SerializeField]
	public Toggle _muteButton;

	[SerializeField]
	public Button _settingsButton;

	[SerializeField]
	public Button _logoutButton;

	[SerializeField]
	public UIElementAnimation _subheaderAnim;

	[NonSerialized]
	public Actions _actions;

	[NonSerialized]
	public Configuration _config;

	[NonSerialized]
	public string _subheaderStr;

	[NonSerialized]
	public string _invalidCodeStr;

	public void Initialise()
	{
	}

	public void Localise(Translator translator)
	{
	}

	public void Build(Configuration config)
	{
	}

	public void SetActions(Actions actions)
	{
	}

	public void SetMuteButtonStateUI(bool isOn)
	{
	}

	public void OpenCodePage()
	{
	}

	public void CloseCodePage()
	{
	}

	public void ShowCorrectCodeFeedback()
	{
	}

	public void ShowIncorrectCodeFeedback(string errorCodeString)
	{
	}

	public void OnSubmitButton()
	{
	}

	public void OnSubmitCode(string code)
	{
	}

	public void OnMuteButtonToggle(bool isOn)
	{
	}

	public void OnDiscordLinkClicked()
	{
	}
}
