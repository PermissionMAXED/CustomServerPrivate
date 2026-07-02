using System;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UILobbySubNavButton : MonoBehaviour
	{
		[SerializeField]
		[Header("References")]
		public TextMeshProUGUI _buttonText;

		[SerializeField]
		public Button _button;

		[SerializeField]
		public Image _icon;

		[SerializeField]
		public GameObject _notificationPing;

		[SerializeField]
		[Header("Options")]
		public bool _showIcon;

		[SerializeField]
		public Sprite _iconSprite;

		[SerializeField]
		public Color _selectedTextColor;

		[SerializeField]
		public Color _deselectedTextColor;

		[Header("Events")]
		public UnityEvent OnSelectAction;

		public UnityEvent OnDeselectAction;

		[NonSerialized]
		public bool _isSelected;

		[NonSerialized]
		public UnityAction _onClickAction;

		public void Initialize(UnityAction onClickAction)
		{
		}

		public void SetSelected(bool selected, bool forceAction = false)
		{
		}

		public void SetNotificationPing(bool toggle)
		{
		}

		public void Select()
		{
		}

		public void Deselect()
		{
		}
	}
}
