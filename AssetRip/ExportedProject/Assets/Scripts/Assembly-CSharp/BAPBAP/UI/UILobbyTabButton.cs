using System;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UILobbyTabButton : MonoBehaviour
	{
		[Serializable]
		public class Configuration
		{
			public UILobbyTabButton Prefab;

			public float TabSelectedAlpha;

			public float TabUnselectedAlpha;

			public float TabSelectedNotificationAlpha;

			public float TabUnselectedNotificationAlpha;
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

			public UILobbyTabButton Create(string text, Action clickAction)
			{
				return null;
			}
		}

		[SerializeField]
		public Button _button;

		[SerializeField]
		public UIHoverCursor _uiHoverCursor;

		[SerializeField]
		public TMP_Text _text;

		[SerializeField]
		public GameObject notification;

		[SerializeField]
		public UIAnchorWidthLerp selectBarLerp;

		[SerializeField]
		public UIAlphaFade _selectedUIAlphaFade;

		[SerializeField]
		public UIAlphaFade _hoverUIAlphaFade;

		[SerializeField]
		public UIAlphaFade _textAlphaFade;

		[SerializeField]
		public UIUberGraphicEventHandler[] _graphicEventHandlers;

		[SerializeField]
		public UberSDFEventHandler[] _sdfEventHandlers;

		[NonSerialized]
		public Configuration _configuration;

		[NonSerialized]
		public Action _clickAction;

		[NonSerialized]
		public bool _selected;

		public bool Selected
		{
			get
			{
				return false;
			}
			set
			{
			}
		}

		public void Initialise(string text, Configuration configuration)
		{
		}

		public void Select()
		{
		}

		public void SelectUI()
		{
		}

		public void UnselectUI()
		{
		}

		public void OnEnter()
		{
		}

		public void OnExit()
		{
		}

		public void ToggleSelected(bool toggle)
		{
		}

		public void ToggleText(bool toggle)
		{
		}

		public void ToggleSelectHandlers(bool toggle)
		{
		}

		public void ToggleSelectHandlers(ISelectHandler[] handlers)
		{
		}

		public void ToggleDeselectHandlers(IDeselectHandler[] handlers)
		{
		}
	}
}
