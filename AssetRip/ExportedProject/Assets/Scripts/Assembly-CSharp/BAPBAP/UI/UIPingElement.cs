using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIPingElement : MonoBehaviour
	{
		[Header("Image References")]
		public Image iconImage;

		public Image colorImage;

		public Image[] extraColorImages;

		[Header("Components")]
		public UIFollowWorldPosition worldFollow;

		public UIAlphaFadeTimed alphaFadeOut;

		public CanvasGroup canvasGroup;

		public void SetColor(Color color)
		{
		}
	}
}
