using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIGameModifierStartPanelElement : MonoBehaviour
	{
		[Header("References")]
		[SerializeField]
		public CanvasGroup canvasGroup;

		[SerializeField]
		public UIPosLerpFade posLerpFade;

		[SerializeField]
		public UIAlphaFade alphaFade;

		[Header("Info References")]
		[SerializeField]
		public Image iconImage;

		[SerializeField]
		public TMP_Text titleText;

		[SerializeField]
		public TMP_Text descriptionText;

		[NonSerialized]
		public bool fadeInDelay;

		[NonSerialized]
		public float fadeInDelayTime;

		[NonSerialized]
		public float fadeInDelayDuration;

		public void Update()
		{
		}

		public void Initialize(Sprite icon, string title, string description)
		{
		}

		public void FadeInDelay(float delay)
		{
		}
	}
}
