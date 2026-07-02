using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using BAPBAP.Content;
using BAPBAP.Local;
using BAPBAP.Localisation;
using BAPBAP.Network;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UILobbyPostGameSummaryPage : UILobbyTabPage
	{
		public delegate bool BoolAction();

		public class BreakdownStep
		{
			public string progressStr;

			public int amount;

			public BreakdownStep(string progressStr, int amount)
			{
			}
		}

		[Serializable]
		public class SummaryButton
		{
			public GameObject gameObject;

			public Button button;

			public TMP_Text text;
		}

		[Serializable]
		public class ProgressNav
		{
			public class NavEntry
			{
				public TMP_Text text;

				public GameObject selectedObj;
			}

			public CanvasGroup canvasGroup;

			public UIAlphaFade alphaFade;

			public NavEntry[] navEntries;
		}

		[Serializable]
		public class SummaryPanel
		{
			public CanvasGroup canvasGroup;

			public UIAlphaFade alphaFade;

			[NonSerialized]
			public bool isEnabled;

			[NonSerialized]
			public Action openAction;

			[NonSerialized]
			public Action closeAction;

			[NonSerialized]
			public BoolAction tryAdvance;

			public void Build(Action openAction, Action closeAction, BoolAction tryAdvance)
			{
			}

			public void Open()
			{
			}

			public void Close()
			{
			}

			public bool TryAdvance()
			{
				return false;
			}
		}

		[Serializable]
		public class StatsPanel : SummaryPanel
		{
			public HorizontalLayoutGroup statHorizontalLayout;

			public UILobbyGameSummaryPlayerStatsEntry localPlayerStatsElement;

			public UILobbyGameSummaryPlayerStatsEntry[] teammateStatsElements;
		}

		[Serializable]
		public class GameResultPanel : SummaryPanel
		{
			public GameObject victoryPanel;

			public TMP_Text victoryTitleText;

			public TMP_Text victoryPlacementText;

			public GameObject defeatPanel;

			public TMP_Text defeatTitleText;
		}

		[Serializable]
		public class ProgressPanel : SummaryPanel
		{
			public UIPosLerpFade charDisplayPosLerp;

			public Image characterDisplay;

			public VerticalLayoutGroup elementsLayout;

			public UILobbyGameSummaryXpProgressEntry charXpProgress;

			public Image charXpProgressIcon;

			public TMP_Text charCurrentLevelText;

			public TMP_Text charCurrentLevelValueText;

			public TMP_Text charNextLevelText;

			public TMP_Text charNextLevelValueText;

			public TMP_Text charTokenProgressTitleText;

			public UILobbyGameSummaryXpProgressEntry charTokenProgress;

			[NonSerialized]
			public UILobbyGameSummaryXpProgressEntry[] progressEntries;
		}

		[Serializable]
		public class RankingPanel : SummaryPanel
		{
			[Serializable]
			public class RankingUpdatePanel
			{
				public CanvasGroup canvasGroup;

				public UIAlphaFade alphaFade;

				public CanvasGroup lightGlowAlpha;

				public CanvasGroup lightRaysAlpha;

				public Image glowFxImage;

				public UIAlphaFade rankDisplayAlphaFade;

				public Image rankDisplay;

				public UIAlphaFade textAlphaFade;

				public TMP_Text rankUpdateText;

				public TMP_Text rankTitleText;

				public TMP_Text playerNameText;
			}

			public Image rankDisplay;

			public TMP_Text rankTitleText;

			public TMP_Text rankPointsText;

			public UILobbyPopUpElement rankPointPopUp;

			public UILobbyGameSummaryXpProgressEntry rankingXpProgress;

			public GameObject rankingXpProgressRoot;

			public RankingUpdatePanel rankUpdatePanel;
		}

		[Serializable]
		public class OBCWinPanel : SummaryPanel
		{
			public TMP_Text obcTitleText;

			public TMP_Text obcWinsText;

			public UIElementAnimation uiAnim;

			public UILobbyPopUpElement winsPopUp;

			public UIDigitAnimator winsDigitAnimator;

			public UIAlphaFade winsGlowFade;
		}

		[Serializable]
		public class OBCLosePanel : SummaryPanel
		{
			public TMP_Text obcTitleText;

			public TMP_Text obcLivesText;

			public UIElementAnimation uiAnim;

			public UIDigitAnimator livesDigitAnimator;

			public UILobbyPopUpElement livesPopUp;
		}

		[Serializable]
		public class DailyRewardPanel : SummaryPanel
		{
			public RectTransform CHBContentParent;

			public TMP_Text dailyRewardTitleText;

			public GridLayoutGroup contentLayout;

			public TMP_Text dailyRewardMaxedOutText;

			public TransformScaleSimpleAnimation dailyRewardMaxedOutAnim;

			public List<UILobbyPopUpElement> stepPopUps;

			public RectTransform CHBAnimStartParent;

			public RectTransform CHBAnimCenterParent;

			public RectTransform CHBAnimPivot;
		}

		[Serializable]
		public class Configuration
		{
			public UICharactersConfiguration characterConfig;

			public GameModesConfiguration gameModesConfig;

			public PlayerBannerData playerBannerData;

			public string buttonNextTranslationKey;

			public string buttonExitTranslationKey;

			public string victoryTranslationKey;

			public string defeatTranslationKey;

			public string accountXpProgressTranslationKey;

			public string xpBreakdownPlacementTranslationKey;

			public string xpBreakdownSquadKillsTranslationKey;

			public string xpBreakdownTimeAliveTranslationKey;

			public string xpBreakdownMmrAdjustmentTranslationKey;

			public string xpBreakdownEntryFeeTranslationKey;

			public string battlePassProgressTranslationKey;

			public string progressToLevelTranslationKey;

			public string currentLevelTranslationKey;

			public string nextLevelTranslationKey;

			public string charTokenProgressTitleTranslationKey;

			public string dailyRewardTitleTranslationKey;

			public string dailyRewardMaxedOutTranslationKey;

			public string obcTitleTranslationKey;

			public string obcWinsTranslationKey;

			public string obcLivesTranslationKey;

			public string placeTranslationKey;

			public string promotedTranslationKey;

			public string demotedTranslationKey;

			public string rpTranslationKey;

			[Tooltip("How much to wait for the first summary panel to show when the page opens after a game")]
			public float waitToOpenSummaryDuration;

			[Tooltip("How much to wait for the game result panel to show when the page opens after a game")]
			public float animateOpenGameResultDuration;

			public AnimationCurve openGameResultAlphaCurve;

			public string popUpXpColorHex;

			public SFXData advanceButtonClickSfx;

			public SFXData nextButtonClickSfx;

			public SFXData statsPanelOpenSfx;

			public float statElementsShowDelay;

			public UILobbyGameSummaryPlayerStatsEntry.Configuration playerStatEntryConfiguration;

			public float progressElementsFadeInDuration;

			public float progressElementsShowDelay;

			public float progressRewardSequenceTimeBetweenAnims;

			public UILobbyGameSummaryXpProgressEntry.Configuration progressEntryConfiguration;

			public float rankProgressShowDelay;

			public float rankUpgradeAnimDuration;

			public AnimationCurve rankUpgIconColorOverlayCurve;

			public AnimationCurve rankUpgIconAlphaCurve;

			public AnimationCurve rankUpgIconScaleCurve;

			public AnimationCurve rankUpgLightGlowAlphaCurve;

			public AnimationCurve rankUpgLightFxAlphaCurve;

			public AnimationCurve rankUpgGlowFxScaleCurve;

			public AnimationCurve rankUpgGlowFxAlphaCurve;

			public AnimationCurve rankUpgIconShineCurve;

			public AudioManager.SFX rankUpSfx;

			public float rankUpSfxVolume;

			public AudioManager.SFX rankPromotedSfx;

			public float rankPromotedSfxVolume;

			public int obcLiveAssetId;

			public float obcShowDelay;

			public float obcShowButtonsDelay;

			public AudioManager.SFX obcWinObtainedSfx;

			public float obcWinObtainedSfxVolume;

			public AudioManager.SFX obcLoseLiveSfx;

			public float obcLoseLiveSfxVolume;

			public SFXData dailyRewardPanelOpenSfx;

			public float dailyRewardInitialWaitDuration;

			public float dailyRewardShowDelay;

			public float dailyRewardAnimDuration;

			public float normLerpCenterTime;

			public AnimationCurve dailyRewardLerpCenterCurve;

			public AnimationCurve dailyRewardLerpTargetCurve;

			public float dailyRewardTimeBetweenAnims;

			public float dailyRewardTimeBetweenSteps;

			public AnimationCurve dailyRewardLerpTargetHeightCurve;

			public float dailyRewardLerpTargetHeightOffset;

			public AnimationCurve dailyRewardLerpCenterScaleCurve;

			public AnimationCurve dailyRewardLerpTargetScaleCurve;

			public SFXData dailyRewardAnimStartSfxData;

			public SFXData dailyRewardAnimSwooshSfxData;

			public float dailyRewardCompleteAnimDelay;

			public SFXData dailyRewardCompleteSfxData;

			public UILobbyGameSummaryDailyRewardEntry.Configuration dailyRewardEntryConfiguration;
		}

		[CompilerGenerated]
		public sealed class _003CDailyRewardSequenceCoroutine_003Ed__132 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public UILobbyPostGameSummaryPage _003C_003E4__this;

			[NonSerialized]
			public int _003Cs_003E5__2;

			[NonSerialized]
			public BreakdownStep _003Cstep_003E5__3;

			[NonSerialized]
			public int _003Ca_003E5__4;

			[NonSerialized]
			public float _003CanimateDailyRewardTime_003E5__5;

			[NonSerialized]
			public bool _003CplayedSfx_003E5__6;

			[NonSerialized]
			public float _003Ct_003E5__7;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CDailyRewardSequenceCoroutine_003Ed__132(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		public sealed class _003COBCLoseSequenceCoroutine_003Ed__125 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public UILobbyPostGameSummaryPage _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003COBCLoseSequenceCoroutine_003Ed__125(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		public sealed class _003COBCWinSequenceCoroutine_003Ed__119 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public UILobbyPostGameSummaryPage _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003COBCWinSequenceCoroutine_003Ed__119(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		public sealed class _003CProgressSequenceCoroutine_003Ed__101 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public float initialWaitTime;

			public UILobbyPostGameSummaryPage _003C_003E4__this;

			[NonSerialized]
			public UILobbyGameSummaryXpProgressEntry[] _003C_003E7__wrap1;

			[NonSerialized]
			public int _003C_003E7__wrap2;

			[NonSerialized]
			public UILobbyGameSummaryXpProgressEntry _003CprogressEntry_003E5__4;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CProgressSequenceCoroutine_003Ed__101(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[CompilerGenerated]
		public sealed class _003CRankProgressSequenceCoroutine_003Ed__110 : IEnumerator<object>, IEnumerator, IDisposable
		{
			[NonSerialized]
			public int _003C_003E1__state;

			[NonSerialized]
			public object _003C_003E2__current;

			public float initialWaitTime;

			public UILobbyPostGameSummaryPage _003C_003E4__this;

			object IEnumerator<object>.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			object IEnumerator.Current
			{
				[DebuggerHidden]
				get
				{
					return null;
				}
			}

			[DebuggerHidden]
			public _003CRankProgressSequenceCoroutine_003Ed__110(int _003C_003E1__state)
			{
			}

			[DebuggerHidden]
			void IDisposable.Dispose()
			{
			}

			private bool MoveNext()
			{
				return false;
			}

			bool IEnumerator.MoveNext()
			{
				//ILSpy generated this explicit interface implementation from .override directive in MoveNext
				return this.MoveNext();
			}

			[DebuggerHidden]
			void IEnumerator.Reset()
			{
			}
		}

		[SerializeField]
		public CanvasGroup canvasGroup;

		[SerializeField]
		public Selectable _canvasGroupSelectable;

		[SerializeField]
		public UIPosLerpFade lerpFade;

		[SerializeField]
		public UIAlphaFade alphaFade;

		[SerializeField]
		public UIAlphaFade _backgroundUIFade;

		[SerializeField]
		public GameResultPanel gameResultPanel;

		[SerializeField]
		public UIAlphaFade buttonsAlphaFade;

		[SerializeField]
		public SummaryButton nextButton;

		[SerializeField]
		public SummaryButton exitButton;

		[SerializeField]
		public Button fillButtonNext;

		[SerializeField]
		public Button fillButtonExit;

		[SerializeField]
		public StatsPanel statsPanel;

		[SerializeField]
		public ProgressPanel progressPanel;

		[SerializeField]
		public RankingPanel rankingPanel;

		[SerializeField]
		public OBCWinPanel obcWinPanel;

		[SerializeField]
		public OBCLosePanel obcLosePanel;

		[SerializeField]
		public DailyRewardPanel dailyRewardPanel;

		[NonSerialized]
		public Configuration _configuration;

		[NonSerialized]
		public Translator _translator;

		[NonSerialized]
		public SummaryPanel[] _panels;

		[NonSerialized]
		public int currentPanelId;

		[NonSerialized]
		public bool waitToOpenSummary;

		[NonSerialized]
		public float waitOpenSummaryTime;

		[NonSerialized]
		public bool animateOpenGameResult;

		[NonSerialized]
		public float animateOpenGameResultTime;

		[NonSerialized]
		public bool animateRankPromotion;

		[NonSerialized]
		public float animateRankPromtionTime;

		[NonSerialized]
		public Coroutine progressCoroutine;

		[NonSerialized]
		public Coroutine rankProgressCoroutine;

		[NonSerialized]
		public bool showRankUpdate;

		[NonSerialized]
		public bool showRankIsPromotion;

		[NonSerialized]
		public bool rankIsBelowRoyalIII;

		[NonSerialized]
		public float rankAnimCurrRpLerped;

		[NonSerialized]
		public int rankAnimTargetRp;

		[NonSerialized]
		public Coroutine obcProgressCoroutine;

		[NonSerialized]
		public bool isObcWin;

		[NonSerialized]
		public int obcNewWins;

		[NonSerialized]
		public int obcNewLives;

		[NonSerialized]
		public Coroutine dailyRewardCoroutine;

		[NonSerialized]
		public List<UILobbyGameSummaryDailyRewardEntry> dailyRewardEntries;

		[NonSerialized]
		public UILobbyGameSummaryDailyRewardEntry.Factory dailyRewardFactory;

		[NonSerialized]
		public BreakdownStep[] dailyCurrentBreakdown;

		[NonSerialized]
		public int dailyNewProgress;

		[NonSerialized]
		public int dailyPrevProgress;

		[NonSerialized]
		public int dailyMaxProgress;

		[NonSerialized]
		public int dailyAmount;

		[NonSerialized]
		public int animDailyCurrentStep;

		[NonSerialized]
		public int animDailyCurrentProgress;

		[NonSerialized]
		public bool showCharTokenObtain;

		[NonSerialized]
		public int showCharTokenObtainAmount;

		[NonSerialized]
		public string placeStr;

		[NonSerialized]
		public string promotedStr;

		[NonSerialized]
		public string demotedStr;

		[NonSerialized]
		public string rpStr;

		[NonSerialized]
		public string xpBreakdownPlacementStr;

		[NonSerialized]
		public string xpBreakdownSquadKillsStr;

		[NonSerialized]
		public string xpBreakdownMmrAdjustmentStr;

		[NonSerialized]
		public string xpBreakdownEntryFeeStr;

		[NonSerialized]
		public string xpBreakdownTimeAliveStr;

		public override CanvasGroup CanvasGroup => null;

		public override Selectable CanvasGroupSelectable => null;

		public override UIPosLerpFade UILerpFade => null;

		public override UIAlphaFade UIAlphaFade => null;

		public override UIAlphaFade backgroundUIFade => null;

		public void FixedUpdate()
		{
		}

		public void Update()
		{
		}

		public void Build(Configuration configuration, Translator translator)
		{
		}

		public override void Localise(Translator translator)
		{
		}

		public void InitializeSummaryPanels(GameCompletedMessage.SquadStats squadStatsData, GameCompletedMessage.Asset[] rewards, GameCompletedMessage.Asset[] costs, GameCompletedMessage.XP xp, GameCompletedMessage.RankStats rankStats, GameCompletedMessage.DailyReward dailyReward, string playerAccountId)
		{
		}

		public void OpenEndGameSummary()
		{
		}

		public void CloseEndGameSummary()
		{
		}

		public void OnNextButtonPressed()
		{
		}

		public void OnExitButtonPressed()
		{
		}

		public void SetSummaryButtonNext()
		{
		}

		public void SetSummaryButtonExit()
		{
		}

		public int GetNextPanel(int currentPanel)
		{
			return 0;
		}

		public void OpenSummaryPanel(int panelId)
		{
		}

		public void CloseSummaryPanel(int panelId)
		{
		}

		public void InitializeGameResult(int placement)
		{
		}

		public void AnimateOpenGameResult(float f)
		{
		}

		public void OpenGameResult()
		{
		}

		public void CloseGameResult()
		{
		}

		public void InitializeStatsPanel(GameCompletedMessage.SquadStats squadStats, string playerAccountId)
		{
		}

		public string GetMvpSquadMemberAccountId(GameCompletedMessage.SquadStats.PlayerStats playerStats, GameCompletedMessage.SquadStats.PlayerStats[] teammateStats)
		{
			return null;
		}

		public void OpenStatsPanel()
		{
		}

		public void CloseStatsPanel()
		{
		}

		public bool TryAdvanceStatsPanel()
		{
			return false;
		}

		public void InitializeProgressPanel(GameCompletedMessage.Asset[] rewards, GameCompletedMessage.XP xp)
		{
		}

		public void InitializeCharMasteryXpProgress(int charId, int amount, GameCompletedMessage.XP.Breakdown breakdown)
		{
		}

		public void InitializeCharTokenXpProgress(int amount)
		{
		}

		public void InitializeCharTokenObtain(int assetId, int amount)
		{
		}

		public void OpenProgressPanel()
		{
		}

		public void CloseProgressPanel()
		{
		}

		public void PlayProgressSequenceCoroutine(float initialWaitTime)
		{
		}

		[IteratorStateMachine(typeof(_003CProgressSequenceCoroutine_003Ed__101))]
		public IEnumerator ProgressSequenceCoroutine(float initialWaitTime)
		{
			return null;
		}

		public void OpenCharTokenRewardPage()
		{
		}

		public bool TryAdvanceProgressPanel()
		{
			return false;
		}

		public void InitializeRankingPanel(GameCompletedMessage.RankStats ranking, string playerUsername)
		{
		}

		public void InitializeRankingUpdatePanel(GameCompletedMessage.RankStats ranking, string playerUsername)
		{
		}

		public void RankingSetPointsText(int rp)
		{
		}

		public void OpenRankingPanel()
		{
		}

		public void CloseRankingPanel()
		{
		}

		public void PlayRankProgressSequenceCoroutine(float initialWaitTime)
		{
		}

		[IteratorStateMachine(typeof(_003CRankProgressSequenceCoroutine_003Ed__110))]
		public IEnumerator RankProgressSequenceCoroutine(float initialWaitTime)
		{
			return null;
		}

		public void AnimateRankPromotion(float t)
		{
		}

		public void ShowRankUpdatePanel()
		{
		}

		public bool TryAdvanceRankingPanel()
		{
			return false;
		}

		public void InitializeOBCWinPanel(GameCompletedMessage.RankStats obcStats)
		{
		}

		public void OpenOBCWinPanel()
		{
		}

		public void CloseOBCWinPanel()
		{
		}

		public bool TryAdvanceOBCWinPanel()
		{
			return false;
		}

		public void PlayOBCWinSequenceCoroutine()
		{
		}

		[IteratorStateMachine(typeof(_003COBCWinSequenceCoroutine_003Ed__119))]
		public IEnumerator OBCWinSequenceCoroutine()
		{
			return null;
		}

		public void InitializeOBCLosePanel(int livesLost, int livesBalance)
		{
		}

		public void OpenOBCLosePanel()
		{
		}

		public void CloseOBCLosePanel()
		{
		}

		public bool TryAdvanceOBCLosePanel()
		{
			return false;
		}

		public void PlayOBCLoseSequenceCoroutine()
		{
		}

		[IteratorStateMachine(typeof(_003COBCLoseSequenceCoroutine_003Ed__125))]
		public IEnumerator OBCLoseSequenceCoroutine()
		{
			return null;
		}

		public void InitializeDailyRewardPanel(GameCompletedMessage.DailyReward dailyReward)
		{
		}

		public void OpenDailyRewardPanel()
		{
		}

		public void CloseDailyRewardPanel()
		{
		}

		public bool TryAdvanceDailyRewardPanel()
		{
			return false;
		}

		public void AnimateDailyReward(float t)
		{
		}

		public void PlayDailyRewardSequenceCoroutine()
		{
		}

		[IteratorStateMachine(typeof(_003CDailyRewardSequenceCoroutine_003Ed__132))]
		public IEnumerator DailyRewardSequenceCoroutine()
		{
			return null;
		}

		public void PlayDailyRewardMaxObtainedAnim()
		{
		}

		public void DailyRewardInitializeStepPopUp(BreakdownStep step)
		{
		}
	}
}
