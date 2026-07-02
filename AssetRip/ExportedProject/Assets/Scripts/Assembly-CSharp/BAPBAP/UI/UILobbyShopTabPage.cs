using System;
using System.Collections.Generic;
using BAPBAP.Content;
using BAPBAP.Local;
using BAPBAP.Localisation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UILobbyShopTabPage : UILobbyTabPage
	{
		public class Actions
		{
			public Action shopRequest;

			public Action<string> purchaseFreebieListingAction;

			public Action<string, int> purchaseRotationListingAction;

			public Action<string, int> purchaseRefreshAction;
		}

		[Serializable]
		public class ComingSoonPanel
		{
			public GameObject gameObject;

			public TMP_Text comingSoonText;

			public TMP_Text countdownTimeText;
		}

		[Serializable]
		public class StoreHeader
		{
			public TMP_Text featuredStoreText;

			public TMP_Text shopRefreshText;

			public TMP_Text shopRefreshTimeText;

			public Transform refreshRoot;

			public TMP_Text refreshText;

			public TMP_Text refreshCountText;

			public TMP_Text refreshButtonCostIconText;

			public TMP_Text refreshButtonCostAmountText;

			public Button refreshButton;

			public Button dropInfoButton;

			public TMP_Text dropInfoButtonText;
		}

		[Serializable]
		public class DropInfoPanel
		{
			public class Drop
			{
				public CanvasGroup canvasGroup;

				public UIAlphaFade alphaFade;

				public TMP_Text headerText;

				public TMP_Text descriptionText;

				public TMP_Text availableUntilText;

				public TMP_Text timeCountdownText;

				public HorizontalLayoutGroup layoutGroup;

				public virtual void OpenPanel()
				{
				}

				public virtual void ClosePanel()
				{
				}
			}

			[Serializable]
			public class BetaDrop1 : Drop
			{
				[Serializable]
				public class Configuration
				{
					public ContentSO betaTombstoneContent;
				}

				[NonSerialized]
				public Configuration config;

				public Image tombstoneDisplay;

				public override void OpenPanel()
				{
				}

				public override void ClosePanel()
				{
				}
			}

			[Serializable]
			public class BetaDrop2 : Drop
			{
				[Serializable]
				public class Configuration
				{
					public ContentSO arcadeTombstoneContent;
				}

				[NonSerialized]
				public Configuration config;

				public Image tombstoneDisplay;

				public override void OpenPanel()
				{
				}

				public override void ClosePanel()
				{
				}
			}

			public CanvasGroup canvasGroup;

			public UIAlphaFade alphaFade;

			public UIPosLerpFade posLerpFade;

			public Button closeFillButton;

			public Button closeButton;

			public Button nextButton;

			public Button prevButton;

			public BetaDrop1 betaDrop1;

			public BetaDrop2 betaDrop2;
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
		public class Configuration
		{
			public ContentConfiguration contentConfig;

			public EmoteData emoteData;

			public UILobbyShopListingEntry.Configuration rewardEntryConfiguration;

			public SFXData openCardsSfxData;

			public float listingsOpenDelay;

			public string comingSoonEndDate;

			public string refreshDateFormatStr;

			public string featuredStoreTranslationKey;

			public string refreshTranslationKey;

			public string comingSoonTranslationKey;

			public string dropInfoTranslationKey;

			public string drop1InfoHeaderTranslationKey;

			public string drop2InfoHeaderTranslationKey;

			public string dropInfoDescriptionTranslationKey;

			public string dropInfoAvailableUntilTranslationKey;

			public DropInfoPanel.BetaDrop1.Configuration drop1Configuration;

			public DropInfoPanel.BetaDrop2.Configuration drop2Configuration;

			public string shopRefreshTranslationKey;

			public string refreshingSoonTranslationKey;

			public string buttonClaimTranslationKey;

			public string buttonClaimedTranslationKey;

			public string buttonPurchasedTranslationKey;

			public string buttonEquipTranslationKey;

			public string buttonEquipedTranslationKey;
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
		public ComingSoonPanel comingSoonPanel;

		[SerializeField]
		public StoreHeader storeHeader;

		[SerializeField]
		public DropInfoPanel dropInfoPanel;

		[SerializeField]
		public Transform listingsParent;

		[SerializeField]
		public ConfirmPurchaseWindow confirmPurchaseWindow;

		[NonSerialized]
		public Actions _actions;

		[NonSerialized]
		public ShopModel _data;

		[NonSerialized]
		public Configuration _configuration;

		[NonSerialized]
		public Translator _translator;

		[NonSerialized]
		public UILobbyShopListingEntry.Pool shopListingEntryPool;

		[NonSerialized]
		public List<UILobbyShopListingEntry> currentShopListingEntries;

		[NonSerialized]
		public DateTime comingSoonEndDate;

		[NonSerialized]
		public bool comingSoonCountdownEnabled;

		[NonSerialized]
		public float comingSoonCountdownTimer;

		[NonSerialized]
		public DateTime refreshDate;

		[NonSerialized]
		public bool refreshCountdownEnabled;

		[NonSerialized]
		public float refreshCountdownTimer;

		[NonSerialized]
		public DateTime dropInfoEndDate;

		[NonSerialized]
		public bool dropInfoCountdownEnabled;

		[NonSerialized]
		public float dropInfoCountdownTimer;

		[NonSerialized]
		public UILobbyShopListingEntry selectedListingEntry;

		[NonSerialized]
		public string selectedListingIdToPurchase;

		[NonSerialized]
		public int selectedCostIndexForPurchase;

		[NonSerialized]
		public DropInfoPanel.Drop[] dropInfoPanels;

		[NonSerialized]
		public int selectedDropInfoPanelId;

		[NonSerialized]
		public string shopRefreshStr;

		[NonSerialized]
		public string refreshingSoonStr;

		[NonSerialized]
		public string purchasedButtonStr;

		[NonSerialized]
		public string claimButtonStr;

		[NonSerialized]
		public string claimedButtonStr;

		[NonSerialized]
		public string equipButtonStr;

		[NonSerialized]
		public string equipedButtonStr;

		public const string LatestShopTimestampKey = "LatestShopTimestamp";

		public const string ShopFlippedCardsKey = "ShopFlippedCards";

		public const string ShopAllFlippedCardsKey = "ShopAllFlippedCards";

		public const char ShopFlippedCardsSeparatorChar = ';';

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

		public void SetActions(Actions actions)
		{
		}

		public void Initialise(ShopModel data)
		{
		}

		public override void OnPageOpen()
		{
		}

		public override void OnPageClose()
		{
		}

		public void UpdateData(ShopModel data)
		{
		}

		public void FocusDefaultSelectable()
		{
		}

		public void SendShopRequest()
		{
		}

		public void OnRefreshButton()
		{
		}

		public void OpenFractalsPurchasePage()
		{
		}

		public void OnRotationRefreshSuccess()
		{
		}

		public void OnRotationRefreshFail()
		{
		}

		public void UpdateDataPurchasedFreebieListing(string listingId)
		{
		}

		public void UpdateDataPurchasedRotationListing(string listingId)
		{
		}

		public void UpdateTabNotification()
		{
		}

		public void ToggleLoader(bool isEnabled)
		{
		}

		public void OnEntryPurchase(UILobbyShopListingEntry entry, int costIndex)
		{
		}

		public void OnOnEntryFlip(UILobbyShopListingEntry entry)
		{
		}

		public void OnEntryFreebieClaim(UILobbyShopListingEntry entry)
		{
		}

		public void OnEntryEquip(UILobbyShopListingEntry entry)
		{
		}

		public void OnFreeRewardListingPurchaseSuccess(UILobbyShopListingEntry entry)
		{
		}

		public void OnFreeRewardListingPurchaseFail(UILobbyShopListingEntry entry)
		{
		}

		public void OnRotationListingPurchaseSuccess()
		{
		}

		public void OnRotationListingPurchaseFail()
		{
		}

		public void OpenDropInfoPanel()
		{
		}

		public void CloseDropInfoPanel()
		{
		}

		public void DropInfoPanelPrevPressed()
		{
		}

		public void DropInfoPanelNextPressed()
		{
		}

		public void DropInfoPanelUpdateButtons()
		{
		}

		public void OpenConfirmPurchaseWindow()
		{
		}

		public void CloseConfirmPurchaseWindow()
		{
		}

		public void InitializeConfirmPurchaseWindow(UILobbyShopListingEntry entry, int costIndex)
		{
		}

		public void OnRotationListingPurchaseConfirm()
		{
		}

		public void SetUnlockButtonSpinnerEnabled(bool isEnabled)
		{
		}

		public void AddShopFlippedCardListingNotification(string listingId)
		{
		}

		public string[] GetShopFlippedCardListingNotifications()
		{
			return null;
		}

		public void ClearSavedNotifications()
		{
		}

		public bool IsListingPurchased(string listingId)
		{
			return false;
		}

		public bool IsCardFlipped(string listingId)
		{
			return false;
		}

		public ShopListingModel GetListingFromRotationEntryId(string listingId)
		{
			return null;
		}

		public bool TryGetShopListingEntryFromListingId(string listingId, out UILobbyShopListingEntry shopListingEntry)
		{
			shopListingEntry = null;
			return false;
		}

		public string AssetIdToTextSprite(int assetId)
		{
			return null;
		}

		public int AssetIdToCurrencyBalance(int assetId)
		{
			return 0;
		}
	}
}
