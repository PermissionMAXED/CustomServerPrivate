using System;
using BAPBAP.Local;
using TMPro;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UILobbyChallengePlaceRewardEntry : MonoBehaviour
	{
		[Serializable]
		public class Configuration
		{
			public float priceEntryFadeInDelay;

			public SFXData cardFadeInSfxData;
		}

		[SerializeField]
		public UIAlphaFade alphaFade;

		[SerializeField]
		public UIPosLerpFade posLerpFade;

		[SerializeField]
		public TMP_Text headerText;

		[SerializeField]
		public TMP_Text rewardText;

		[SerializeField]
		public TMP_Text infoText;

		[NonSerialized]
		public bool fadeInDelay;

		[NonSerialized]
		public float fadeInDelayTime;

		[NonSerialized]
		public float fadeInDelayDuration;

		[NonSerialized]
		public Configuration config;

		public void Update()
		{
		}

		public void FadeInDelay(float delay)
		{
		}
	}
}
