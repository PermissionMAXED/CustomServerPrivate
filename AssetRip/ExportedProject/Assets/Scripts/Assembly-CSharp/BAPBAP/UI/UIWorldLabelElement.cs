using TMPro;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UIWorldLabelElement : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		public UIFollowWorldPosition worldFollowPos;

		[SerializeField]
		public UIAlphaFade alphaFade;

		[SerializeField]
		public TMP_Text title;

		public void SetUpLabel(string labelStr)
		{
		}
	}
}
