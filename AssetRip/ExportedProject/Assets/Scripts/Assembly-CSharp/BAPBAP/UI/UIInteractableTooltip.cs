using System;
using BAPBAP.Items;
using BAPBAP.Local;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIInteractableTooltip : MonoBehaviour
	{
		[Serializable]
		public class ItemDisplay
		{
			public Image colorBg;

			public Image icon;
		}

		[NonSerialized]
		public ItemManager itemManager;

		[NonSerialized]
		public UIItems uiItems;

		[NonSerialized]
		public InputSystem inputSystem;

		[Header("References")]
		[SerializeField]
		public UIFollowWorldPosition worldFollow;

		[SerializeField]
		public UIAlphaFade alphaFade;

		[SerializeField]
		public LayoutElement layoutElement;

		[SerializeField]
		public UIPosLerpFade failAnimation;

		[Header("UI References")]
		[SerializeField]
		public TMP_Text itemTypeText;

		[SerializeField]
		public TMP_Text titleText;

		[SerializeField]
		public GameObject itemDisplayContainer;

		[SerializeField]
		public GameObject itemUpgradeArrow;

		[SerializeField]
		public RectTransform originalItemObj;

		[SerializeField]
		public RectTransform upgradedItemObj;

		[SerializeField]
		public ItemDisplay originalItemDisplay;

		[SerializeField]
		public ItemDisplay upgradedItemDisplay;

		[SerializeField]
		public TMP_Text itemStatsText;

		[SerializeField]
		public TMP_Text statusText;

		[SerializeField]
		public GameObject interactContainer;

		[SerializeField]
		public TMP_Text interactText;

		[SerializeField]
		public TMP_Text interactCastingText;

		[SerializeField]
		public UIInputIcon inputIcon;

		[SerializeField]
		public Image castingProgressImage;

		[Header("Settings")]
		[SerializeField]
		public float preferedWidth;

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void Show(Transform follow)
		{
		}

		public void Hide()
		{
		}

		public void ResetWindow()
		{
		}

		public void SetItemType(string typeStr)
		{
		}

		public void SetTitle(string titleStr)
		{
		}

		public void SetTitleEnabled(bool isEnabled)
		{
		}

		public void SetStatusText(string statusStr, Color color)
		{
		}

		public void SetStatusTextEnabled(bool isEnabled)
		{
		}

		public void SetUpgradeLayout(bool v)
		{
		}

		public void SetItemsDisplay(Item originalItem, Item itemToUpgrade)
		{
		}

		public void SetItemDisplay(Item originalItem)
		{
		}

		public void DisplayItem(ItemDisplay display, Item item)
		{
		}

		public void SetIconDisplay(Sprite sprite, bool v)
		{
		}

		public void SetIconDisplayColor(int tier)
		{
		}

		public void EnableItemDisplayContainer(bool isEnabled)
		{
		}

		public void SetItemDeltaStats(Gear originalItem, Gear itemToUpgrade)
		{
		}

		public void SetInteractText(string interactStr, Color textColor)
		{
		}

		public void SetInteractCastingText(string keyStr)
		{
		}

		public void TryUpdateInteractKey(InputBinding inputBinding, bool isGamepad)
		{
		}

		public void SetInteractEnabled(bool isEnabled)
		{
		}

		public void SetInteractInputKey(InputTarget target)
		{
		}

		public void SetCastingProgress(float normFactor)
		{
		}

		public void ToggleInteractCastingState(bool isCasting)
		{
		}

		public void UpdateTextWrapLayout(float textWidth)
		{
		}
	}
}
