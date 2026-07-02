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
	public class UILobbyShopListingEntry : MonoBehaviour
	{
		[Serializable]
		public class PurchaseButton
		{
			public Button button;

			public TMP_Text buttonText;

			public GameObject contents;
		}

		[Serializable]
		public class Configuration
		{
			public ContentConfiguration contentConfig;

			public UILobbyShopListingEntry prefab;

			public int poolSize;

			public string purchasedButtonTranslationKey;

			public string claimButtonTranslationKey;

			public string claimedButtonTranslationKey;

			public Color freebieAccentColor;

			[Tooltip("Apply a legendary item theme for any freebie rewards that exceeds this amount number (for example: 50 coins)")]
			public int freebieLegendaryAmountThreshold;

			public Color freebieLegendaryAccentColor;

			public SFXData cardFadeInSfxData;

			public float cardFlipAnimDuration;

			public SFXData flipGenericSfxData;

			public SFXData flipStickerSfxData;

			public SFXData flipPlayerBannerSfxData;

			public SFXData flipCurrencySfxData;

			public AnimationCurve cardFlipRotationCurve;

			public AnimationCurve cardFlipScaleCurve;

			public AnimationCurve cardFlipGlowFxAlphaCurve;
		}

		public class Pool
		{
			[NonSerialized]
			public Configuration _configuration;

			[NonSerialized]
			public Queue<UILobbyShopListingEntry> _inactiveQueue;

			[NonSerialized]
			public Transform _parentTransform;

			[NonSerialized]
			public Action<UILobbyShopListingEntry, int> _purchaseAction;

			[NonSerialized]
			public Action<UILobbyShopListingEntry> _freebieAction;

			[NonSerialized]
			public Action<UILobbyShopListingEntry> _equipAction;

			[NonSerialized]
			public Action<UILobbyShopListingEntry> _flipAction;

			public Pool(Configuration configuration, Transform parentTransform, Action<UILobbyShopListingEntry, int> purchaseAction, Action<UILobbyShopListingEntry> freebieAction, Action<UILobbyShopListingEntry> equipAction, Action<UILobbyShopListingEntry> flipAction)
			{
			}

			public void Create()
			{
			}

			public UILobbyShopListingEntry Spawn(Translator translator, BAPBAP.Content.Content content, int assetId, string listingId, int amount, bool purchased, bool flipped, int[] costAmounts, string[] costSprites)
			{
				return null;
			}

			public void Despawn(UILobbyShopListingEntry instance)
			{
			}
		}

		[SerializeField]
		public CanvasGroup canvasGroup;

		[SerializeField]
		public UIPosLerpFade posLerpFade;

		[SerializeField]
		public UIAlphaFade alphaFade;

		[SerializeField]
		public CanvasGroup cardFrontButtonCanvasGroup;

		[SerializeField]
		public CanvasGroup cardFrontCanvasGroup;

		[SerializeField]
		public CanvasGroup cardBackCanvasGroup;

		[SerializeField]
		public Transform cardFlipTransform;

		[SerializeField]
		public Image flipFxImageColor;

		[SerializeField]
		public CanvasGroup flipFxCanvasGroup;

		[SerializeField]
		public Image rarityBgImage;

		[SerializeField]
		public Image rarityHeaderImage;

		[SerializeField]
		public Image rarityEdgeImage;

		[SerializeField]
		public Image contentDisplayImage;

		[SerializeField]
		public Image disabledFillImage;

		[SerializeField]
		public UIContentRarityStars rarityStars;

		[SerializeField]
		public Button fullButton;

		[SerializeField]
		public Button buttonFlip;

		[SerializeField]
		public TMP_Text rarityTypeText;

		[SerializeField]
		public TMP_Text collectionText;

		[SerializeField]
		public TMP_Text titleText;

		[SerializeField]
		public GameObject claimButtonSpinner;

		[SerializeField]
		public Button equipButton;

		[SerializeField]
		public TMP_Text equipButtonText;

		[SerializeField]
		public PurchaseButton[] purchaseButtons;

		[NonSerialized]
		[NonSerialized]
		public string typeName;

		[NonSerialized]
		[NonSerialized]
		public string rarityName;

		[NonSerialized]
		public int assetId;

		[NonSerialized]
		public string listingId;

		[NonSerialized]
		public Pool pool;

		[NonSerialized]
		public Configuration configuration;

		[NonSerialized]
		public Action<UILobbyShopListingEntry, int> purchaseAction;

		[NonSerialized]
		public Action<UILobbyShopListingEntry> freebieAction;

		[NonSerialized]
		public Action<UILobbyShopListingEntry> equipAction;

		[NonSerialized]
		public Action<UILobbyShopListingEntry> flipAction;

		[NonSerialized]
		public Translator translator;

		[NonSerialized]
		public BAPBAP.Content.Content conent;

		[NonSerialized]
		public bool purchased;

		[NonSerialized]
		public int[] costAmounts;

		[NonSerialized]
		public string[] costSprites;

		[NonSerialized]
		public bool equipable;

		[NonSerialized]
		public bool freebie;

		[NonSerialized]
		public string purchasedStr;

		[NonSerialized]
		public string claimStr;

		[NonSerialized]
		public string claimedStr;

		[NonSerialized]
		public bool fadeInDelay;

		[NonSerialized]
		public float fadeInDelayTime;

		[NonSerialized]
		public float fadeInDelayDuration;

		[NonSerialized]
		public bool cardFlipAnimate;

		[NonSerialized]
		public float cardFlipTime;

		public void Update()
		{
		}

		public void Build(Configuration configuration, Pool pool, Action<UILobbyShopListingEntry, int> purchaseAction, Action<UILobbyShopListingEntry> freebieAction, Action<UILobbyShopListingEntry> equipAction, Action<UILobbyShopListingEntry> flipAction)
		{
		}

		public void Initialise(Translator translator, BAPBAP.Content.Content content, int assetId, string listingId, int amount, bool purchased, bool flipped, int[] costAmounts, string[] costSprites)
		{
		}

		public void Localise(Translator translator)
		{
		}

		public void OnPurchasePressed(int index)
		{
		}

		public void OnEquipPressed()
		{
		}

		public void SetPurchased()
		{
		}

		public void SetNotPurchased()
		{
		}

		public void Enable()
		{
		}

		public void Disable()
		{
		}

		public void UpdateButtonsState()
		{
		}

		public void FadeInDelay(float delay)
		{
		}

		public void SetClaimSpinnerEnabled(bool isEnabled)
		{
		}

		public void SetCardUnflipped()
		{
		}

		public void SetCardFlipped()
		{
		}

		public void OnCardFlip()
		{
		}

		public void AnimateCardFlip(float t)
		{
		}

		public void Dispose()
		{
		}

		public void OnDisable()
		{
		}

		public bool FocusSelectable()
		{
			return false;
		}

		public void DestroySpawnedVisualizer()
		{
		}
	}
}
