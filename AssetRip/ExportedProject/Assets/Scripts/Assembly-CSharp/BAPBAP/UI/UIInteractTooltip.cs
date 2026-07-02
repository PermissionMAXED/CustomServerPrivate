using TMPro;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UIInteractTooltip : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		public UIInputIcon inputIcon;

		[SerializeField]
		public CanvasGroup canvasGroup;

		[SerializeField]
		public TMP_Text descText;

		[Header("Settings")]
		[SerializeField]
		public float inactiveAlpha;

		public void SetDescription(string keyStr)
		{
		}

		public void SetKeyEnabledState(bool isEnabled, bool interactable = true)
		{
		}
	}
}
