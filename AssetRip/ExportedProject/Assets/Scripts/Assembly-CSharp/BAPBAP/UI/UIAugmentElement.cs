using System;
using BAPBAP.Local;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UIAugmentElement : MonoBehaviour
	{
		[NonSerialized]
		public UIAugments _uiAugments;

		[Header("General References")]
		[SerializeField]
		public UIContentRarityStars rarityStars;

		[SerializeField]
		public Image rarityBgImage;

		[SerializeField]
		public Image rarityEdgeImage;

		[SerializeField]
		public TMP_Text titleText;

		[SerializeField]
		public TMP_Text descriptionText;

		[SerializeField]
		public CanvasGroup _canvasGroup;

		[SerializeField]
		public Animator _anim;

		[SerializeField]
		public Image _icon;

		[SerializeField]
		public Button _button;

		[NonSerialized]
		public int elementIndex;

		[NonSerialized]
		public int id;

		public void Awake()
		{
		}

		public void Initialize(int id, AugmentManager.SelectionData.SelectionType type, int tierId = -1)
		{
		}

		public void InitializeAugment(int augmentId, int tierId = -1)
		{
		}

		public void InitializeItem(int _itemId)
		{
		}

		public void SelectedAugment()
		{
		}

		public void ToggleAugmentInteractable(bool isInteractable)
		{
		}

		public void TriggerSelectionAnim(bool isSelected)
		{
		}

		public void TriggerRerollAnim()
		{
		}
	}
}
