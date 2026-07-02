using System;
using BAPBAP.Items;
using BAPBAP.Local;
using BAPBAP.Localisation;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIItemSlotElement : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
	{
		[NonSerialized]
		public UIItems uiItems;

		[NonSerialized]
		public UITooltip uiTooltip;

		[NonSerialized]
		public RectTransform rectTransform;

		[NonSerialized]
		public Item item;

		[NonSerialized]
		public int amount;

		[NonSerialized]
		public bool tooltipDropPromptEnabled;

		[SerializeField]
		[Header("Key Settings")]
		public bool showAction;

		[ConditionalHide("showAction", true)]
		[SerializeField]
		public InputTarget target;

		[SerializeField]
		[Header("Empty Tooltip")]
		public bool showEmptyTooltip;

		[ConditionalHide("showEmptyTooltip", true)]
		[SerializeField]
		public string emptyTitleTranslationKey;

		[ConditionalHide("showEmptyTooltip", true)]
		[SerializeField]
		public string emptyDescTranslationKey;

		[SerializeField]
		[Header("Input Icon References")]
		public UIInputIcon inputIcon;

		[SerializeField]
		[Header("General References")]
		public Button button;

		[SerializeField]
		public OnPointerListener pointerListener;

		[SerializeField]
		public Image bgImage;

		[SerializeField]
		public Image outlineImage;

		[Header("Icon References")]
		[SerializeField]
		public Image icon;

		[SerializeField]
		public Image slotTypeIcon;

		[SerializeField]
		public GameObject itemActive;

		[Header("Item Count References")]
		[SerializeField]
		public Image countBgImage;

		[SerializeField]
		public Image countBgGlowImage;

		[SerializeField]
		public TMP_Text countText;

		[SerializeField]
		public TransformScaleSimpleAnimation countAnim;

		[Header("Other References")]
		[SerializeField]
		public GameObject pickupAnim;

		[SerializeField]
		public CanvasGroup canvasGroup;

		[NonSerialized]
		public bool tooltipIsOpened;

		[NonSerialized]
		public string emptyTitleStr;

		[NonSerialized]
		public string emptyDescStr;

		[NonSerialized]
		public int currentCount;

		public OnPointerListener PointerListener => null;

		public bool ShowAction => false;

		public bool TooltipIsOpened => false;

		public bool ShowEmptyTooltip => false;

		public void Awake()
		{
		}

		public void Localise(Translator translator)
		{
		}

		public void OnDisable()
		{
		}

		public void Initialize(Color maxCountColor)
		{
		}

		public void EnableItemSlot(Item item)
		{
		}

		public void DisableItemSlot()
		{
		}

		public void SetCountEnabled(bool isEnabled)
		{
		}

		public void SetCountText(int count)
		{
		}

		public void SetConsumableCountMax(bool isEnabled, Color countColor)
		{
		}

		public void SetIconMaterial(Material mat)
		{
		}

		public void SetOutlineColor(Color col)
		{
		}

		public void TriggerPickupAnim()
		{
		}

		public void TriggerCountPickupAnim()
		{
		}

		public void SetInputIcon(InputBinding inputBinding, bool isGamepad)
		{
		}

		public Color GetBackgroundColor()
		{
			return default(Color);
		}

		public Sprite GetIcon()
		{
			return null;
		}

		public void OnPointerEnter(PointerEventData eventData)
		{
		}

		public void OnPointerExit(PointerEventData eventData)
		{
		}

		public void OnElementEnter()
		{
		}

		public void OnElementExit()
		{
		}
	}
}
