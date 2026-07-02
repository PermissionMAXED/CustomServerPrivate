using System;
using BAPBAP.Content;
using BAPBAP.Localisation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UILobbyBattlePassTabPage : UILobbyTabPage
	{
		public class Actions
		{
			public Action<int> battlePassClaimAction;
		}

		[Serializable]
		public class BattlePassPanel
		{
			public TMP_Text BattlePassText;

			public TMP_Text EndsInRemainingDaysText;

			public Image LevelContainer;

			public TMP_Text LevelText;

			public TMP_Text LevelBarExpText;

			public RectTransform ProgressBarRect;

			public LayoutFitParentPercentage LevelProgressBar;

			public CanvasGroup xpBarLevelUpAlpha;
		}

		[Serializable]
		public class RewardsPanel
		{
			public RectTransform RewardProgressBar;

			public RectTransform RewardProgressBarFill;

			public HorizontalLayoutGroup HorizontalLayout;

			public RectTransform EntryParentTransform;

			public RectTransform ViewportTransform;
		}

		[Serializable]
		public class SelectRewardPanel
		{
			public CanvasGroup CanvasGroup;

			public UIAlphaFade AlphaFade;

			public UIPosLerpFade PosLerpFade;

			public Image DisplayImage;

			public UIContentRarityStars rarityStars;

			public TMP_Text CategoryText;

			public TMP_Text TypeRarityText;

			public TMP_Text TitleText;

			public TMP_Text DescriptionText;

			public TMP_Text RewardStatusText;

			public Button ClaimButton;

			public TMP_Text ClaimButtonText;

			public GameObject ClaimButtonSpinner;

			public Button EquipButton;

			public TMP_Text EquipButtonText;

			public UIAlphaFade EquipButtonAlphaFade;
		}

		[Serializable]
		public class Configuration
		{
			public ContentConfiguration contentConfig;

			public EmoteData emoteData;

			public UILobbyBattlePassRewardEntry.Configuration rewardEntryConfiguration;

			public string battlePassTranslationKey;

			public string endsInXRemainingDaysTranslationKey;

			public string buttonClaimTranslationKey;

			public string buttonClaimedTranslationKey;

			public string buttonEquipTranslationKey;

			public string buttonEquipedTranslationKey;

			public string unlockedAtLevelTranslationKey;

			public string levelTranslationKey;

			public string maxLevelTranslationKey;

			[Header("Rewards Scroll")]
			public float rewardsOpenDelay;

			public float rewardScrollLerpDuration;

			public AnimationCurve rewardScrollLerpCurve;
		}

		[SerializeField]
		public CanvasGroup _canvasGroup;

		[SerializeField]
		public Selectable _canvasGroupSelectable;

		[SerializeField]
		public UIPosLerpFade _uiLerpFade;

		[SerializeField]
		public UIAlphaFade _uiAlphaFade;

		[SerializeField]
		public UIAlphaFade _backgroundUIFade;

		[SerializeField]
		public CanvasGroup loaderCanvasGroup;

		[SerializeField]
		public UIAlphaFade loaderAlphaFade;

		[SerializeField]
		public UIAlphaLoop loaderAlphaLoop;

		[SerializeField]
		public CanvasGroup contentsCanvasGroup;

		[SerializeField]
		public UIAlphaFade contentsAlphaFade;

		[SerializeField]
		public BattlePassPanel _battlePassPanel;

		[SerializeField]
		public RewardsPanel _rewardsPanel;

		[SerializeField]
		public SelectRewardPanel _selectRewardPanel;

		[NonSerialized]
		public Actions _actions;

		[NonSerialized]
		public BattlePassModel _data;

		[NonSerialized]
		public Configuration _configuration;

		[NonSerialized]
		public Translator _translator;

		[NonSerialized]
		public UILobbyBattlePassRewardEntry.Factory _rewardFactory;

		[NonSerialized]
		public UILobbyBattlePassRewardEntry[] _rewardEntries;

		[NonSerialized]
		public int selectedRewardEntryId;

		[NonSerialized]
		public int currentLevel;

		[NonSerialized]
		public int currentXp;

		[NonSerialized]
		public int currentXpNeeded;

		[NonSerialized]
		public int maxLevel;

		[NonSerialized]
		public DateTime endDate;

		[NonSerialized]
		public int dirtyRewardsScrollFrame;

		[NonSerialized]
		public bool _animateRewardScrollPos;

		[NonSerialized]
		public float _rewardsScrollTargetPos;

		[NonSerialized]
		public float _rewardsScrollPrevPos;

		[NonSerialized]
		public float _rewardsScrollAnimTime;

		[NonSerialized]
		public float _rewardsBarStartWidth;

		[NonSerialized]
		public string endsInXRemainingDaysStr;

		[NonSerialized]
		public string claimButtonStr;

		[NonSerialized]
		public string claimedButtonStr;

		[NonSerialized]
		public string equipButtonStr;

		[NonSerialized]
		public string equipedButtonStr;

		[NonSerialized]
		public string unlockedAtLevelStr;

		[NonSerialized]
		public string maxLevelStr;

		public override CanvasGroup CanvasGroup => null;

		public override Selectable CanvasGroupSelectable => null;

		public override UIPosLerpFade UILerpFade => null;

		public override UIAlphaFade UIAlphaFade => null;

		public override UIAlphaFade backgroundUIFade => null;

		public void Update()
		{
		}

		public void Build(Configuration configuration, Translator translator)
		{
		}

		public override void Localise(Translator translator)
		{
		}

		public void Initialise(BattlePassModel data, Actions actions)
		{
		}

		public override void OnPageOpen()
		{
		}

		public override void OnPageClose()
		{
		}

		public void UpdateData(BattlePassModel data)
		{
		}

		public void UpdateDataClaimedNewReward(int levelId)
		{
		}

		public void UpdateBapPassXp()
		{
		}

		public void SetCurrentBattlePassUI()
		{
		}

		public void UpdateTabNotification()
		{
		}

		public void ToggleLoader(bool isEnabled)
		{
		}

		public void SetRewardsBarProgress()
		{
		}

		public float GetRewardsEntryLevelPosition(int level)
		{
			return 0f;
		}

		public void MoveRewardsScrollToLevel(int level, bool animate = true)
		{
		}

		public void UnlockRewardEntry(int rewardIndex)
		{
		}

		public void SelectRewardEntry(int rewardIndex)
		{
		}

		public void OnClaimRewardButton()
		{
		}

		public void OnOpenEquipPageFromSelectedLevelReward()
		{
		}

		public void OnCloseObtainedRewardPage()
		{
		}

		public void InitializeSelectRewardPanel(int levelId)
		{
		}

		public void SetUpRewardButtons(int levelId)
		{
		}

		public void OpenSelectRewardPanel()
		{
		}

		public void CloseSelectRewardPanel()
		{
		}

		public void SetClaimButtonSpinnerEnabled(bool isEnabled)
		{
		}

		public bool IsLevelRewardUnlocked(int rewardLevelId)
		{
			return false;
		}

		public bool IsLevelRewardClaimed(int rewardLevelId)
		{
			return false;
		}

		public bool IsLevelRewardEquipable(int rewardLevelId)
		{
			return false;
		}

		public int GetRemainingBattlePassDays(DateTime endDate)
		{
			return 0;
		}

		public int GetLevelXpNeeded(int levelId)
		{
			return 0;
		}

		public int GetCurrentLevelXpNeeded(int level)
		{
			return 0;
		}

		public int GetAccountXp()
		{
			return 0;
		}

		public int GetBattlePassPreviousLevel()
		{
			return 0;
		}

		public int GetBattlePassLevel()
		{
			return 0;
		}

		public int GetAccountMaxLevel()
		{
			return 0;
		}

		public int GetBattlePassLevelFromXp(int xp)
		{
			return 0;
		}

		public ShopListingModel[] GetListingsFromLevelReward(int levelRewardId)
		{
			return null;
		}

		public bool TryGetBattlePassLevelIdFromListingId(string listingId, out int levelId)
		{
			levelId = default(int);
			return false;
		}
	}
}
