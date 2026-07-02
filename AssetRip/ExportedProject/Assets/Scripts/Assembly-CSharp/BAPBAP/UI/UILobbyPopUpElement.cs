using TMPro;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UILobbyPopUpElement : MonoBehaviour
	{
		[SerializeField]
		public RectTransform rectTransform;

		[SerializeField]
		public UIAlphaFade alphaFade;

		[SerializeField]
		public UIAlphaFadeTimed alphaFadeOut;

		[SerializeField]
		public UIPosLerpFade lerpFade;

		[SerializeField]
		public TMP_Text text;

		public void SetPointsText(int points, string pointTypeStr = "")
		{
		}

		public void SetText(string str)
		{
		}

		public void ShowAndHidePointPopUp(int points, string pointType = "", float duration = 1.5f)
		{
		}

		public void ShowAndHidePopUp(float hideDuration = 1.5f)
		{
		}

		public void ShowPopUp()
		{
		}

		public void Hide(bool instant = false)
		{
		}
	}
}
