using System;
using BAPBAP.UI;
using UnityEngine;
using UnityEngine.UI;

public class View_Lobby_News : View
{
	public class NewsPanelEntry
	{
		public UIAlphaFade UIAlphaFade;

		public UIPosLerpFade UIPosLerpFade;
	}

	[Serializable]
	public class Configuration
	{
		public float NewsPreviewButtonCycleDuration;

		public Color NewsPreviewUnselectedColor;

		public Color NewsPreviewSelectedColor;

		public Color ProgressUnselectedColor;

		public Color ProgressSelectedColor;

		public string LatestNewsTimestamp;
	}

	[SerializeField]
	public CanvasGroup _canvasGroup;

	[SerializeField]
	public CanvasGroup _contentsCanvasGroup;

	[SerializeField]
	public GraphicRaycaster _graphicRaycaster;

	[SerializeField]
	public UIAlphaFade _uiAlphaFade;

	[SerializeField]
	public UIPosLerpFade _uiPosFade;

	[SerializeField]
	[Header("Panels & Progress UI")]
	public Transform _panelsContainer;

	[SerializeField]
	public Transform _progressContainerTransform;

	[SerializeField]
	public Image _newsPanelsProgressTemplate;

	[Header("Buttons")]
	[SerializeField]
	public Button _closeButton;

	[SerializeField]
	public Button _closeFillButton;

	[SerializeField]
	public Button _prevButton;

	[SerializeField]
	public Button _nextButton;

	[SerializeField]
	[Header("External References")]
	public Button _newsButton;

	[SerializeField]
	public GameObject _newsButtonNotification;

	[NonSerialized]
	public NewsPanelEntry[] _newsPanels;

	[NonSerialized]
	public Image[] _newsPanelsProgress;

	[NonSerialized]
	public int _newsPanelCurrentId;

	[NonSerialized]
	public Configuration _config;

	public void Build(Configuration newsConfig)
	{
	}

	public void Update()
	{
	}

	public void FixedUpdate()
	{
	}

	public void OpenNewsWindow()
	{
	}

	public void HideNewsWindow()
	{
	}

	public void OnNextButton()
	{
	}

	public void OnPrevButton()
	{
	}

	public void SetButtonsState()
	{
	}

	public void OpenPanel(int panelId, int direction = 0)
	{
	}

	public void ClosePanel(int panelId, bool instant = false)
	{
	}

	public void EnableInteractableContents()
	{
	}

	public void DisableInteractableContents()
	{
	}
}
