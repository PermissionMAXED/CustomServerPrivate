using System;
using BAPBAP.Content;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UILobbyCharacterMasteryRewardEntry : MonoBehaviour, ISelectHandler, IEventSystemHandler
	{
		[Serializable]
		public class Configuration
		{
			public ContentConfiguration contentConfig;

			public UILobbyCharacterMasteryRewardEntry Prefab;

			public float unselectedWidth;

			public float selectedWidth;

			public float unselectedHeight;

			public float selectedHeight;

			public float selectAnimDuration;

			public AnimationCurve selectHeightCurve;

			public Color rewardImageLockedColor;

			public Color lockedBgPanelColor;

			public Color unlockedBgPanelColor;

			public Color selectedBgPanelColor;

			public Color selectedTextColor;

			public Color unselectedTextColor;

			public Sprite emptyContentIcon;
		}

		public class Factory
		{
			[NonSerialized]
			public Configuration _configuration;

			[NonSerialized]
			public Transform _parentTransform;

			[NonSerialized]
			public RectTransform _viewportTransform;

			public Factory(Configuration configuration, Transform parentTransform, RectTransform viewportTransform)
			{
			}

			public UILobbyCharacterMasteryRewardEntry Create()
			{
				return null;
			}

			public UILobbyCharacterMasteryRewardEntry Create(BAPBAP.Content.Content content, Action selectAction, bool isUnlocked, bool isClaimed, int level, int cost)
			{
				return null;
			}
		}

		[SerializeField]
		public CanvasGroup _canvasGroup;

		[SerializeField]
		public UIPosLerpFade _posLerpFade;

		[SerializeField]
		public UIAlphaFade _alphaFade;

		[SerializeField]
		public RectTransform _rectTransform;

		[SerializeField]
		public RectTransform _panelRectTransform;

		[SerializeField]
		public LayoutElement _layoutElement;

		[SerializeField]
		public UISelectSfxElement _selectSfx;

		[SerializeField]
		public Button _rewardButton;

		[SerializeField]
		public Image _panelImage;

		[SerializeField]
		public Image _rarityColorBg;

		[SerializeField]
		public Image _lockedOverlayFill;

		[SerializeField]
		public Image _lockIcon;

		[SerializeField]
		public TMP_Text _levelText;

		[SerializeField]
		public TMP_Text _costText;

		[SerializeField]
		public GameObject _costObj;

		[SerializeField]
		public GameObject _obtainedIconObj;

		[SerializeField]
		public Image _displayImage;

		[SerializeField]
		public Image _selectedHighlight;

		[SerializeField]
		public GameObject _notificationObj;

		[NonSerialized]
		public Configuration _configuration;

		[NonSerialized]
		public Action _selectAction;

		[NonSerialized]
		public bool isSelected;

		[NonSerialized]
		public bool isUnlocked;

		[NonSerialized]
		public bool isClaimed;

		[NonSerialized]
		public bool fadeInDelay;

		[NonSerialized]
		public float fadeInDelayTime;

		[NonSerialized]
		public float fadeInDelayDuration;

		[NonSerialized]
		public bool animateSelect;

		[NonSerialized]
		public float selectTime;

		public void Update()
		{
		}

		public static UILobbyCharacterMasteryRewardEntry Build(UILobbyCharacterMasteryRewardEntry prefab, Transform parent)
		{
			return null;
		}

		public void Initialise(BAPBAP.Content.Content content, Action selectAction, bool isUnlocked, bool isClaimed, int levelId, int cost)
		{
		}

		public void Dispose()
		{
		}

		public void FadeInDelay(float delay)
		{
		}

		public void OnSelect(BaseEventData eventData)
		{
		}

		public void OnSelectButton()
		{
		}

		public void Select()
		{
		}

		public void Deselect()
		{
		}

		public void Unlock()
		{
		}

		public void Lock()
		{
		}

		public void SetClaimed()
		{
		}

		public void SetUnclaimed()
		{
		}

		public void SetLevel(int level)
		{
		}
	}
}
