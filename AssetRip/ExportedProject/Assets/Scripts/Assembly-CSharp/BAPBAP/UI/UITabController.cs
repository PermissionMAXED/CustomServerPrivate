using System;
using BAPBAP.Localisation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UITabController : MonoBehaviour
	{
		[Header("Button References")]
		[SerializeField]
		public Image tabIcon;

		[SerializeField]
		public TMP_Text tabText;

		[SerializeField]
		public MultiGraphicButton tabButton;

		[SerializeField]
		public UIAnchorWidthLerp selectBarLerp;

		[Header("Tab References")]
		[SerializeField]
		public GameObject tabObj;

		[SerializeField]
		public CanvasGroup canvasGroup;

		[SerializeField]
		public UIAlphaFade alphaFade;

		[SerializeField]
		public UIPosLerpFade posLerpFade;

		[Header("Settings")]
		[SerializeField]
		public string translationKey;

		public void Initialise(Action onSelectedAction)
		{
		}

		public void Localise(Translator translator)
		{
		}

		public void SetAlpha(float alpha)
		{
		}

		public void Open()
		{
		}

		public void Close()
		{
		}
	}
}
