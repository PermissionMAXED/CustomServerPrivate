using System;
using BAPBAP.Game.Dimensions;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UILobbyDimensionIcon : MonoBehaviour
	{
		[Serializable]
		public class Configuration
		{
			public UILobbyDimensionIcon Prefab;
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

			public UILobbyDimensionIcon Create(Action clickAction)
			{
				return null;
			}
		}

		[SerializeField]
		public Image _iconImage;

		[SerializeField]
		public Image _selectHighlight;

		[SerializeField]
		public Button _button;

		[SerializeField]
		public CanvasGroup _canvasGroup;

		[SerializeField]
		[Header("Tooltip")]
		public UIHoverTooltip _hoverTooltip;

		[SerializeField]
		public UIAlphaFade _tooltipAlphaFade;

		[SerializeField]
		public TextMeshProUGUI _tooltipTitle;

		[SerializeField]
		public TextMeshProUGUI _tooltipDescription;

		[NonSerialized]
		public Configuration _configuration;

		[NonSerialized]
		public Action _clickAction;

		[NonSerialized]
		public bool _tooltipEnabled;

		public CanvasGroup CanvasGroup => null;

		public void Initialise(Configuration configuration)
		{
		}

		public void SetUp(DimensionBehaviourSO config)
		{
		}

		public void Select()
		{
		}

		public void Unselect()
		{
		}

		public void ToggleTooltipEnabled(bool tooltipEnabled)
		{
		}
	}
}
