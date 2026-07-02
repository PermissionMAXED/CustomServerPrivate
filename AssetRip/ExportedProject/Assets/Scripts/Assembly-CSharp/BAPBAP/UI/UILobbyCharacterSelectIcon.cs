using System;
using BAPBAP.Localisation;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UILobbyCharacterSelectIcon : MonoBehaviour
	{
		[Serializable]
		public class Configuration
		{
			public UILobbyCharacterSelectIcon Prefab;

			[Range(0f, 5f)]
			public float BorderColorMultiplier;

			public float AnimationInDuration;

			public float AnimationOutDuration;

			public AnimationCurve AnimationCurve;

			public float SizeYUnselected;

			public float SizeYSelected;

			public Color borderHighlightColor;

			public Material greyscaleMaterial;

			public Color rotationIconColor;

			public Color rotationIconDisabledColor;

			public Color selectedButtonColor;

			public Color unselectedButtonColor;

			public Color disabledButtonColor;

			public Color DisabledCharColor;

			public Color LockedCharColor;
		}

		[Serializable]
		public class PlayerSelectionIndicator
		{
			public GameObject IndicatorObject;

			public Image Fill;
		}

		public class Factory
		{
			[NonSerialized]
			public Configuration _configuration;

			[NonSerialized]
			public Transform _parentTransform;

			public Factory(Configuration configuration, Transform parentTransform)
			{
			}

			public UILobbyCharacterSelectIcon Create(Translator translator, string name, Color color, Sprite sprite, UnityAction<UILobbyCharacterSelectIcon> action)
			{
				return null;
			}
		}

		[SerializeField]
		public RectTransform rectTransform;

		[SerializeField]
		public Image _containerImage;

		[SerializeField]
		public Image _backgroundImage;

		[SerializeField]
		public Image _charImage;

		[SerializeField]
		public Image _highlightSelected;

		[SerializeField]
		public Image _highlightCharSelected;

		[SerializeField]
		public Image _highlightHover;

		[SerializeField]
		public Image _lockIcon;

		[SerializeField]
		public Image _rotationIcon;

		[SerializeField]
		public TMP_Text _levelText;

		[SerializeField]
		public Image _xpProgressImage;

		[SerializeField]
		public GameObject _notificationIcon;

		[SerializeField]
		public Button _button;

		[SerializeField]
		public RectTransform _iconContainerRect;

		[SerializeField]
		public LayoutElement _layoutElement;

		[Header("Char Select")]
		public PlayerSelectionIndicator[] SelectionIndicators;

		[SerializeField]
		public Animator _lockInPortraitEffect;

		[SerializeField]
		public TMP_Text _lockButtonProfileNameText;

		[SerializeField]
		public Image _lockButtonFill;

		[SerializeField]
		public Image _lockButtonOutline;

		[NonSerialized]
		public UnityAction<UILobbyCharacterSelectIcon> _action;

		[NonSerialized]
		public Configuration _configuration;

		[NonSerialized]
		public bool isEnabled;

		[NonSerialized]
		public bool selected;

		[NonSerialized]
		public bool locked;

		[NonSerialized]
		public bool _animate;

		[NonSerialized]
		public float _time;

		[NonSerialized]
		public string _lvlXStr;

		public void Update()
		{
		}

		public void Animate(float tn)
		{
		}

		public void Initialise(Configuration configuration, string name, Color color, Sprite sprite, UnityAction<UILobbyCharacterSelectIcon> action)
		{
		}

		public void Localise(Translator translator)
		{
		}

		public void Select()
		{
		}

		public void SelectUIButton(bool playAnim = true)
		{
		}

		public void DeselectUIButton(bool playAnim = true)
		{
		}

		public void CharacterSetSelected()
		{
		}

		public void CharacterSetDeselected()
		{
		}

		public void SetInteractable(bool isInteractable)
		{
		}

		public void SetLocked()
		{
		}

		public void SetUnlocked()
		{
		}

		public void SetRotationEnabled(bool isEnabled)
		{
		}

		public void Enable()
		{
		}

		public void Disable()
		{
		}

		public void SetIndicatorColor(int index, Color targetColor)
		{
		}

		public void ToggleIndicatorAtIndex(int index, bool isActive)
		{
		}

		public void ToggleAllIndicators(bool isActive)
		{
		}

		public void SetPlayerInfo(string playerName, Sprite playerIcon, Color targetColor)
		{
		}

		public void PlayLockInEffect()
		{
		}

		public void SetNotificationIcon(bool isEnabled)
		{
		}

		public bool NotificationIsEnabled()
		{
			return false;
		}

		public void UpdateXpProgress(float value)
		{
		}

		public void UpdateLevel(int level)
		{
		}
	}
}
