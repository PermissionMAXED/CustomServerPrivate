using System;
using BAPBAP.Localisation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI;

public class View_Lobby_ReadyButton : View
{
	public enum ReadyButtonState
	{
		WaitingToReady,
		Readied,
		InQueue,
		NoGameMode,
		Maintenance
	}

	[Serializable]
	public class Configuration
	{
		public Sprite StandardBG;

		public Sprite MaintenanceBG;

		public Color ReadyColor;

		public Color ReadyTextColor;

		public string ReadyText;

		public Color UnreadyColor;

		public Color UnreadyTextColor;

		public string UnreadyText;

		public Color CancelColor;

		public Color CancelTextColor;

		public string CancelText;

		public Color NoneColor;

		public Color NoneTextColor;

		public string NoneText;

		public Color MaintenanceColor;

		[TextArea]
		public string MaintenanceText;
	}

	[SerializeField]
	public Image _background;

	[SerializeField]
	public Image _buttonFill;

	[SerializeField]
	public TextMeshProUGUI _primaryText;

	[SerializeField]
	public TextMeshProUGUI _maintenanceText;

	[SerializeField]
	public Button _mainButton;

	[SerializeField]
	public Button _gameModeButton;

	[SerializeField]
	public GameObject _mainButtonParent;

	[SerializeField]
	public GameObject _maintenanceParent;

	[Header("GameMode")]
	[SerializeField]
	public GameObject _gameModeNameContainer;

	[SerializeField]
	public Image _gameModeImage;

	[SerializeField]
	public TextMeshProUGUI _gameModeNameText;

	[SerializeField]
	public TextMeshProUGUI _gameModeTypeText;

	[SerializeField]
	[Header("Timer UI")]
	public GameObject _timerContainer;

	[SerializeField]
	public TextMeshProUGUI _timerText;

	[SerializeField]
	public TextMeshProUGUI _playerCountText;

	[NonSerialized]
	public Configuration _config;

	[NonSerialized]
	public ReadyButtonState _currentState;

	[NonSerialized]
	public string _maintenanceMsgStr;

	[NonSerialized]
	public string _readyStr;

	[NonSerialized]
	public string _unreadyStr;

	[NonSerialized]
	public string _cancelStr;

	[NonSerialized]
	public string _noneStr;

	public ReadyButtonState CurrentState => default(ReadyButtonState);

	public Button MainButton => null;

	public Button GameModeButton => null;

	public void Build(Configuration configuration)
	{
	}

	public void Localise(Translator translator)
	{
	}

	public void SetState(ReadyButtonState newState)
	{
	}

	public void SetGameModeIcon(Sprite targetSprite)
	{
	}

	public void SetGameModeText(string nameString, string typeString)
	{
	}

	public void SetTimerText(string targetString)
	{
	}

	public void SetPlayerCountText(string targetString)
	{
	}
}
