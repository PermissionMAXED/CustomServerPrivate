using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIGameModePasswordWindow : MonoBehaviour
	{
		public GameModeModel currentGameModeModel;

		public GraphicRaycaster graphicRaycaster;

		public CanvasGroup canvasGroup;

		public UIAlphaFade uiAlphaFade;

		public UIPosLerpFade uiPosLerpFade;

		public Button confirmButton;

		public Button closeButton;

		public TMP_Text confirmButtonText;

		public GameObject confirmButtonLoader;

		public TMP_Text headerText;

		public TMP_InputField passwordField;

		public TMP_Text passwordIncorrectWarningText;
	}
}
