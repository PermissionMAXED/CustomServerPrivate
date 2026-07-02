using System;
using BAPBAP.Local;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UILobbyGameSummaryDailyRewardEntry : MonoBehaviour
	{
		[Serializable]
		public class Configuration
		{
			public float enabledAlpha;

			public float disabledAlpha;

			public float animateObtainDuration;

			public float animateCompleteDuration;

			public AnimationCurve animateObtainFlashCurve;

			public AnimationCurve animateObtainScaleCurve;

			public AnimationCurve animateCompleteFlashCurve;

			public AnimationCurve animateCompleteYPosCurve;

			public SFXData obtainSfxData;

			public UILobbyGameSummaryDailyRewardEntry Prefab;
		}

		public class Factory
		{
			[NonSerialized]
			public Configuration _configuration;

			[NonSerialized]
			public Transform _parentTransform;

			public Factory(Configuration configuration, Transform parentTransform)
			{
			}

			public UILobbyGameSummaryDailyRewardEntry Create()
			{
				return null;
			}
		}

		[SerializeField]
		public RectTransform rectTransform;

		[SerializeField]
		public RectTransform completePivTransform;

		[SerializeField]
		public Image iconImage;

		[SerializeField]
		public CanvasGroup canvasGroup;

		[SerializeField]
		public UIAlphaFade uiAlphaFade;

		[SerializeField]
		public UIPosLerpFade posLerpFade;

		[NonSerialized]
		public Configuration _configuration;

		[NonSerialized]
		public bool isObtained;

		[NonSerialized]
		public float waitStartDelay;

		[NonSerialized]
		public float delayTimeElapsed;

		[NonSerialized]
		public bool animateObtain;

		[NonSerialized]
		public float animateObtainTime;

		[NonSerialized]
		public bool animateComplete;

		[NonSerialized]
		public float animateCompleteTime;

		public void Update()
		{
		}

		public void Initialise(Configuration configuration)
		{
		}

		public void StartFadeIn(float delay = 0f)
		{
		}

		public void DoFadeIn()
		{
		}

		public void PlayObtain(bool playSfx = true)
		{
		}

		public void PlayCompleteAnim(float delay = 0f)
		{
		}

		public void SetObtained()
		{
		}

		public void SetUnobtained()
		{
		}
	}
}
