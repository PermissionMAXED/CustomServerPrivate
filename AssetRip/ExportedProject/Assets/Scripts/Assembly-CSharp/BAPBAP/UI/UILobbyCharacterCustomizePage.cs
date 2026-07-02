using System;
using BAPBAP.Content;
using BAPBAP.Localisation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UILobbyCharacterCustomizePage : UILobbyTabPage
	{
		public class Actions
		{
			public Action<int, int> masteryRewardPurchaseAction;

			public Action<int, int> masteryRewardClaimAction;
		}

		[Serializable]
		public class Configuration
		{
			public UICharactersConfiguration CharacterConfiguration;

			public EmoteData emoteData;

			public PlayerBannerData playerBannerData;

			public MasteryBadgeData masteryBadgeData;

			public Sprite DefaultMasteryBadge;

			[Header("Character Mastery")]
			public ContentConfiguration contentConfig;

			public UILobbyCharacterMasteryRewardEntry.Configuration CharacterMasteryRewardEntryConfiguration;

			public int[] hideRewardsFromLevelIdRange;

			public float rewardsOpenDelay;

			public float rewardScrollLerpDuration;

			public float expBarLerpDuration;

			public string buttonPurchaseTranslationKey;

			public string buttonPurchasedTranslationKey;

			public string buttonClaimTranslationKey;

			public string buttonClaimedTranslationKey;

			public string buttonEquipTranslationKey;

			public string buttonEquipedTranslationKey;

			public string buttonCloseTranslationKey;

			public string unlockedAtLevelTranslationKey;

			public string needsRequiredRewardTranslationKey;

			public string levelTranslationKey;

			public string maxLevelTranslationKey;

			public AnimationCurve rewardScrollLerpCurve;

			public AnimationCurve expBarLerpCurve;
		}

		[Serializable]
		public class CharacterProgressionPanel
		{
			public TMP_Text CharacterTitle;

			public TMP_Text CharacterDescription;

			public Image MasteryBadgeDisplay;

			public TMP_Text MasteryLevelText;

			public TMP_Text MasteryLevelBarExpText;

			public LayoutFitParentPercentage MasteryLevelProgressBar;
		}

		[Serializable]
		public class MasterySelectRewardPanel
		{
			public CanvasGroup CanvasGroup;

			public UIAlphaFade AlphaFade;

			public UIPosLerpFade PosLerpFade;

			public Image DisplayImage;

			public UIContentRarityStars rarityStars;

			public TMP_Text TypeRarityText;

			public TMP_Text TitleText;

			public TMP_Text collectionText;

			public TMP_Text DescriptionText;

			public TMP_Text RewardStatusText;

			public Button ClaimButton;

			public GameObject ClaimButtonContent;

			public TMP_Text ClaimButtonText;

			public GameObject ClaimButtonSpinner;

			public CanvasGroup ClaimButtonCanvasGroup;

			public Button PurchaseButton;

			public TMP_Text PurchaseButtonText;

			public Button EquipButton;

			public TMP_Text EquipButtonText;

			public UIAlphaFade EquipButtonAlphaFade;
		}

		[Serializable]
		public class ConfirmPurchaseWindow
		{
			public CanvasGroup canvasGroup;

			public UIAlphaFade alphaFade;

			public UIPosLerpFade posLerpFade;

			public TMP_Text headerPurchaseText;

			public Image rarityBgImage;

			public TMP_Text categoryText;

			public TMP_Text tierRarityText;

			public TMP_Text titleText;

			public Image DisplayImage;

			public Button headerCloseButton;

			public Button fillCloseButton;

			public Button purchaseButton;

			public GameObject purchaseButtonSpinner;

			public TMP_Text purchaseButtonText;
		}

		[Serializable]
		public class MasteryRewardsPanel
		{
			public RectTransform RewardProgressBar;

			public RectTransform RewardProgressBarFill;

			public HorizontalLayoutGroup HorizontalLayout;

			public RectTransform EntryParentTransform;

			public RectTransform ViewportTransform;
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
		public Button closePageButton;

		[SerializeField]
		public TMP_Text closePageButtonText;

		[SerializeField]
		public CharacterProgressionPanel _characterProgressionPanel;

		[SerializeField]
		public MasterySelectRewardPanel _MasterySelectRewardPanel;

		[SerializeField]
		public MasteryRewardsPanel _masteryRewardsPanel;

		[SerializeField]
		public ConfirmPurchaseWindow confirmPurchaseWindow;

		[NonSerialized]
		public Configuration _configuration;

		[NonSerialized]
		public Translator _translator;

		[NonSerialized]
		public UILobbyCharacterSelectPage charSelectPage;

		[NonSerialized]
		public Actions _actions;

		[NonSerialized]
		public CharacterMasteryModel _data;

		[NonSerialized]
		public UILobbyCharacterMasteryRewardEntry[] _rewardEntries;

		[NonSerialized]
		public UILobbyCharacterMasteryRewardEntry.Factory _rewardFactory;

		[NonSerialized]
		public int selectedRewardEntryId;

		[NonSerialized]
		public string selectedListingIdToPurchase;

		[NonSerialized]
		public int selectedCharId;

		[NonSerialized]
		public int visibleMaxEntryId;

		[NonSerialized]
		public float _expBarAnimationTime;

		[NonSerialized]
		public bool _animateXpBar;

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
		public int dirtyRewardsScrollFrame;

		[NonSerialized]
		public string unlockedButtonStr;

		[NonSerialized]
		public string unlockButtonStr;

		[NonSerialized]
		public string claimButtonStr;

		[NonSerialized]
		public string claimedButtonStr;

		[NonSerialized]
		public string equipButtonStr;

		[NonSerialized]
		public string equipedButtonStr;

		[NonSerialized]
		public string needsRequiredRewardStr;

		[NonSerialized]
		public string unlockedAtLevelStr;

		[NonSerialized]
		public string levelStr;

		[NonSerialized]
		public string maxLevelStr;

		public override CanvasGroup CanvasGroup => null;

		public CanvasGroup ContentsCanvasGroup => null;

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

		public void SetActions(Actions actions)
		{
		}

		public void Initialise(CharacterMasteryModel data)
		{
		}

		public override void OnPageOpen()
		{
		}

		public void UpdateData(CharacterMasteryModel data)
		{
		}

		public void UpdateAvailableCharactersData()
		{
		}

		public void UpdateCharacterCustomizeData(CharacterMasteryModel data, int charId, bool doOpenPage = true)
		{
		}

		public void UpdateDataPurchasedReward(int charId, int rewardLevelId)
		{
		}

		public void SetSelectedCharacter(int charId)
		{
		}

		public void UpdateCharMasteryXp(int charId)
		{
		}

		public void UpdateCharMasteryBadge(int charId)
		{
		}

		public void SetCurrentCharProgressionUI(int charId)
		{
		}

		public void OnCloseObtainedRewardPage()
		{
		}

		public void OnCharPassXpChanged(int charId, int amount)
		{
		}

		public void UpdateTabNotification()
		{
		}

		public void CloseCharacterCustomizePage()
		{
		}

		public void TryCloseCharCustomizePage()
		{
		}

		public void ToggleLoader(bool isEnabled)
		{
		}

		public void SetRewardsBarProgress(int currentLevel)
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

		public void OnPurchaseRewardButton()
		{
		}

		public void OnClaimRewardButton()
		{
		}

		public void OnOpenEquipPageFromSelectedLevelReward()
		{
		}

		public void InitializeSelectRewardPanel(int charId, int levelId)
		{
		}

		public void SetUpRewardButtons(int levelId)
		{
		}

		public void OpenSelectRewardPanel(bool fadeIn = true)
		{
		}

		public void CloseSelectRewardPanel()
		{
		}

		public void SetClaimButtonSpinnerEnabled(bool isEnabled)
		{
		}

		public bool IsLevelRewardUnlocked(int charId, int rewardLevelId)
		{
			return false;
		}

		public bool IsLevelRewardClaimed(int charId, int rewardLevelId)
		{
			return false;
		}

		public bool OwnsPreviousTierContent(BAPBAP.Content.Content content)
		{
			return false;
		}

		public bool ListingMeetsRequirements(AssetModel[] requirements)
		{
			return false;
		}

		public bool IsLevelRewardPurchasable(int charId, int rewardLevelId)
		{
			return false;
		}

		public bool IsLevelRewardEquipable(int charId, int rewardLevelId)
		{
			return false;
		}

		public BAPBAP.Content.Content GetLevelRewardContent(int charId, int rewardLevelId)
		{
			return null;
		}

		public int GetCharLevelXpNeeded(int charId, int levelId)
		{
			return 0;
		}

		public int GetCurrentLevelXpNeeded(int charId, int level)
		{
			return 0;
		}

		public int GetCharXp(int charId)
		{
			return 0;
		}

		public int GetCharPrevXp(int charId)
		{
			return 0;
		}

		public int GetCharPrevLevel(int charId)
		{
			return 0;
		}

		public int GetCharLevel(int charId)
		{
			return 0;
		}

		public int GetCharMaxLevel(int charId)
		{
			return 0;
		}

		public int GetCharLevelFromXp(int charId, int xp)
		{
			return 0;
		}

		public CharacterMasteryModel.MasteryPass.Listing[] GetListingsFromLevelReward(int charId, int levelId)
		{
			return null;
		}

		public bool TryGetCharPassIdAndLevelIdFromListingId(string listingId, out int charId, out int levelId)
		{
			charId = default(int);
			levelId = default(int);
			return false;
		}

		public void OpenConfirmPurchaseWindow()
		{
		}

		public void CloseConfirmPurchaseWindow(bool clearVisualizer = true)
		{
		}

		public void InitializeConfirmPurchaseWindow(int charId, int rewardEntryId)
		{
		}

		public void OnRewardListingPurchaseConfirm()
		{
		}

		public void OnRewardListingPurchaseSuccess()
		{
		}

		public void OnRewardListingPurchaseFail()
		{
		}

		public void SetUnlockButtonSpinnerEnabled(bool isEnabled)
		{
		}

		public int GetOwnedHighestTierCharMasteryBadge(int charId)
		{
			return 0;
		}

		public bool IsMasteryAvailable(int charId)
		{
			return false;
		}
	}
}
