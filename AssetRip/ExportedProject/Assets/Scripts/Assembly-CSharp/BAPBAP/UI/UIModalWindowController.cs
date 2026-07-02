using System;
using BAPBAP.Localisation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIModalWindowController : MonoBehaviour
	{
		[SerializeField]
		[Header("References")]
		public GraphicRaycaster graphicRaycaster;

		[SerializeField]
		public CanvasGroup canvasGroup;

		[SerializeField]
		public UIAlphaFade uiAlphaFade;

		[SerializeField]
		public UIPosLerpFade uiPosLerpFade;

		[SerializeField]
		public TMP_Text headerText;

		[SerializeField]
		public TMP_Text titleText;

		[SerializeField]
		public TMP_Text descriptionText;

		[SerializeField]
		public TMP_Text description2Text;

		[SerializeField]
		public Button fillButton;

		[SerializeField]
		public Button headerCloseButton;

		[SerializeField]
		public Button closeButton;

		[SerializeField]
		public TMP_Text closeButtonText;

		[SerializeField]
		public Button confirmButton;

		[SerializeField]
		public TMP_Text confirmButtonText;

		[Header("Settings")]
		[SerializeField]
		public string headerTranslationKey;

		[SerializeField]
		public string titleTranslationKey;

		[SerializeField]
		public string descTranslationKey;

		[SerializeField]
		public string desc2TranslationKey;

		[SerializeField]
		public string closeTranslationKey;

		[SerializeField]
		public string confirmTranslationKey;

		[NonSerialized]
		public Action _onCancelAction;

		[NonSerialized]
		public Action _onConfirmAction;

		[NonSerialized]
		public bool _allowCancel;

		[NonSerialized]
		public Selectable _lastFocusedSelectable;

		public void FixedUpdate()
		{
		}

		public void Update()
		{
		}

		public void Awake()
		{
		}

		public void Initialize(Action onConfirmAction, Action onCancelAction = null, bool allowCancel = true)
		{
		}

		public void InitializeLocalization(string headerTranslationKey, string titleTranslationKey, string confirmTranslationKey, string closeTranslationKey, string descTranslationKey = null, string desc2TranslationKey = null)
		{
		}

		public void Localize(Translator translator)
		{
		}

		public void Open()
		{
		}

		public void Close()
		{
		}

		public void Cancel()
		{
		}

		public void Confirm()
		{
		}
	}
}
