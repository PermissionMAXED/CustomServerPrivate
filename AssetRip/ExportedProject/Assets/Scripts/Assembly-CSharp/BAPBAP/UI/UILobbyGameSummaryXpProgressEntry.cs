using System;
using System.Collections.Generic;
using BAPBAP.Local;
using BAPBAP.Localisation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UILobbyGameSummaryXpProgressEntry : MonoBehaviour
	{
		public delegate int GetValueDelegate(int value);

		[Serializable]
		public class Configuration
		{
			public float xpBarLerpDuration;

			public AnimationCurve xpBarLerpCurve;

			public float xpBarLevelUpDuration;

			public AnimationCurve xpBarLevelUpAlphaCurve;

			public AnimationCurve xpBarLevelUpFillAlphaCurve;

			public AudioManager.SFX levelUpSfx;

			public float levelUpSfxVolume;

			public string popUpXpColorHex;

			public string levelTranslationKey;

			public string maxLevelTranslationKey;

			public float waitBetweenStepsDuration;

			public AnimationCurve progressDelayLerpDampCurve;

			public float progressDelayDampDuration;
		}

		[Serializable]
		public class ProgressStepPopUp
		{
			public Transform transform;

			public UIAlphaFade alphaFade;

			public UIPosLerpFade posLerpFade;

			public TMP_Text text;
		}

		[Header("Element References")]
		[SerializeField]
		public CanvasGroup canvasGroup;

		[SerializeField]
		public UIPosLerpFade lerpFade;

		[SerializeField]
		public UIAlphaFade alphaFade;

		[SerializeField]
		[Header("Progress Step Pool")]
		public List<UILobbyPopUpElement> progressStepPopUps;

		[SerializeField]
		[Header("UI References")]
		public RectTransform barProgressRect;

		[SerializeField]
		public Image barProgressFill;

		[SerializeField]
		public Image barProgressFillDelay;

		[SerializeField]
		public Image maxLevelFillImage;

		[SerializeField]
		public RectTransform progressStar;

		[SerializeField]
		public TMP_Text titleText;

		[SerializeField]
		public TMP_Text xpText;

		[SerializeField]
		public TMP_Text maxLevelText;

		[SerializeField]
		public CanvasGroup barFillAlpha;

		[SerializeField]
		public CanvasGroup xpBarLevelUpAlpha;

		[SerializeField]
		public TransformScaleSimpleAnimation levelTextAnim;

		[SerializeField]
		public TransformScaleSimpleAnimation[] extraLevelTextAnim;

		public GetValueDelegate getLevelXpNeededAction;

		[NonSerialized]
		public Action<int, int> onSetLevelAction;

		[NonSerialized]
		public Action<int, int> onSetXpAction;

		[NonSerialized]
		public Action<int, int> onStepStart;

		[NonSerialized]
		public UILobbyPostGameSummaryPage.BreakdownStep[] steps;

		[NonSerialized]
		public int animCurrentStep;

		[NonSerialized]
		public int currentStep;

		[NonSerialized]
		public bool isElementEnabled;

		[NonSerialized]
		public bool isMultipleLevel;

		[NonSerialized]
		public float waitStartDelay;

		[NonSerialized]
		public float delayTimeElapsed;

		[NonSerialized]
		public bool showXpPopUp;

		[NonSerialized]
		public bool showGoldPopUp;

		[NonSerialized]
		public bool showFractalsPopUp;

		[NonSerialized]
		public bool isMaxLevel;

		[NonSerialized]
		public int currentLevel;

		[NonSerialized]
		public int currentXp;

		[NonSerialized]
		public int maxLevel;

		[NonSerialized]
		public bool isAnimating;

		[NonSerialized]
		public float animateXpBarTime;

		[NonSerialized]
		public int animCurrentLevel;

		[NonSerialized]
		public int animCurrentXp;

		[NonSerialized]
		public int animCurrentXpNeeded;

		[NonSerialized]
		public float lerpedCurrentXp;

		[NonSerialized]
		public int xpObtainedAmount;

		[NonSerialized]
		public int currentXpRemainder;

		[NonSerialized]
		public int accumulativeAmount;

		[NonSerialized]
		public bool animateXpBarLevelComplete;

		[NonSerialized]
		public float animateXpBarLevelUpTime;

		[NonSerialized]
		public bool waitBetweenSteps;

		[NonSerialized]
		public float waitBetweenStepsTimer;

		[NonSerialized]
		public bool animateBarDelayLerping;

		[NonSerialized]
		public float progressDelayStart;

		[NonSerialized]
		public float progressDelayTimeElapsed;

		[NonSerialized]
		public Configuration configuration;

		[NonSerialized]
		public Color barFillDelayColor;

		[NonSerialized]
		public Color barFillColor;

		public void Update()
		{
		}

		public void AnimateProgress()
		{
		}

		public void Build(Translator translator, Configuration configuration, GetValueDelegate getLevelXpNeededAction)
		{
		}

		public void Localise(Translator translator)
		{
		}

		public void Initialize(int prevCurrentLevel, int prevCurrentXp, int currentLevel, int currentXp, int maxLevel, UILobbyPostGameSummaryPage.BreakdownStep[] steps, Action<int, int> onSetLevelAction = null, Action<int, int> onSetXpAction = null, Action<int, int> onStepStart = null, bool isMultipleLevel = true)
		{
		}

		public void StartProgressAnimation()
		{
		}

		public void InitializeStep(int stepId)
		{
		}

		public void StartStepAnimation(int stepId)
		{
		}

		public void StartBarProgressFillDelay(int lerpAmount)
		{
		}

		public void StartFadeIn(float delay = 0f)
		{
		}

		public void HideElement()
		{
		}

		public void DoFadeIn()
		{
		}

		public void AdvanceToEnd()
		{
		}

		public void OnDisable()
		{
		}

		public void SetUpTitleText(string titleStr)
		{
		}

		public void SetUpLevelText(int level)
		{
		}

		public void PlayLevelUpTextAnim()
		{
		}

		public void SetUpXpText(float xp, float maxXp)
		{
		}

		public void SetProgress(float normFactor)
		{
		}
	}
}
