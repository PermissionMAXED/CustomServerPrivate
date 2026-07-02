using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UICompleteLoginWindow : MonoBehaviour
	{
		public GraphicRaycaster graphicRaycaster;

		public CanvasGroup canvasGroup;

		public UIAlphaFade uiAlphaFade;

		public UIPosLerpFade uiPosLerpFade;

		public Button confirmButton;

		public Button logoutButton;

		public TMP_Text confirmButtonText;

		public GameObject confirmButtonLoader;

		public TMP_Text headerText;

		public TMP_Text enterUsernameText;

		public TMP_InputField usernameField;

		public TMP_Text usernameCharsWarningText;

		public TMP_Text usernameProfanityWarningText;

		public TMP_Text usernameTakenWarningText;

		public Button termsOpenLinkButton;

		public Button privacyOpenLinkButton;

		public Toggle acceptTermsToggle;

		public TMP_Text acceptTermsToggleText;

		public TMP_Text needAcceptTermsWarningText;
	}
}
