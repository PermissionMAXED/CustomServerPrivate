using System;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UILobbyCharacterSelectAbility : MonoBehaviour
	{
		[Serializable]
		public class Configuration
		{
			public UILobbyCharacterSelectAbility Prefab;
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

			public UILobbyCharacterSelectAbility Create(Action clickAction)
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

		[NonSerialized]
		public Configuration _configuration;

		[NonSerialized]
		public Action _clickAction;

		public void Initialise(Configuration configuration)
		{
		}

		public void SetUp(Sprite icon)
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
