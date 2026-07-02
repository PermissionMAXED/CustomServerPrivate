using System;
using BAPBAP.Items;
using BAPBAP.Local;
using BAPBAP.Localisation;
using UnityEngine;

namespace BAPBAP.UI
{
	public class UIItemsWorldTooltip : MonoBehaviour
	{
		[NonSerialized]
		public UIItems uiItems;

		[NonSerialized]
		public ItemManager itemManager;

		[NonSerialized]
		public InputSystem inputSystem;

		[SerializeField]
		[Header("UI References")]
		public Transform itemWorldTooltipParent;

		[SerializeField]
		[Header("References")]
		public GameObject uiItemNearPrefab;

		[SerializeField]
		[Header("Settings")]
		public float timeToShowTooltip;

		[SerializeField]
		public Vector2 tooltipOffset;

		[SerializeField]
		public string potionsAreFullTranslationKey;

		[SerializeField]
		public string goldIsFullTranslationKey;

		[SerializeField]
		public string swapTranslationKey;

		[NonSerialized]
		public UIFollowWorldPosition itemWorldUIFollow;

		[NonSerialized]
		public UINearItemObjectElement itemWorldElement;

		[NonSerialized]
		public RectTransform currentTooltip;

		[NonSerialized]
		public ItemObject currentItemToFollow;

		[NonSerialized]
		public float tooltipElapsedTime;

		[NonSerialized]
		public string potionsAreFullStr;

		[NonSerialized]
		public string goldIsFullStr;

		[NonSerialized]
		public string swapStr;

		public void Awake()
		{
		}

		public void Start()
		{
		}

		public void Localise(Translator translator)
		{
		}

		public void LateUpdate()
		{
		}

		public void SpawnUIWorldTooltip()
		{
		}

		public void DisplayItemUI(ItemObject itemObject)
		{
		}

		public void DisplayTooltip(ItemObject itemObject)
		{
		}

		public void HideCurrentItemUI()
		{
		}

		public void HideCurrentTooltip()
		{
		}

		public void OnTooltipFadeFinished()
		{
		}

		public void InitializeTooltip(ItemObject itemObject)
		{
		}

		public bool CurrentCharHideTooltip()
		{
			return false;
		}

		public bool PlayerHasMaxConsumablesOfType(int itemId)
		{
			return false;
		}

		public bool PlayerHasMaxGold()
		{
			return false;
		}

		public void TryUpdateInteractKey(InputBinding inputBinding, bool isGamepad)
		{
		}
	}
}
