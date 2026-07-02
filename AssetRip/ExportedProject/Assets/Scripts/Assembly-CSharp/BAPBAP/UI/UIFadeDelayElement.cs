using System;
using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UIFadeDelayElement : MonoBehaviour
	{
		[SerializeField]
		public UIAlphaFade alphaFade;

		[SerializeField]
		public UIPosLerpFade posLerpFade;

		[SerializeField]
		public bool playSfxOnFade;

		[ConditionalHide("playSfxOnFade", true)]
		[SerializeField]
		public SFXData sfxData;

		[NonSerialized]
		public bool fadeInDelay;

		[NonSerialized]
		public float fadeInDelayTime;

		[NonSerialized]
		public float fadeInDelayDuration;

		public void Update()
		{
		}

		public void FadeInDelay(float delay)
		{
		}
	}
}
