using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UILobbyRankIconEntry : MonoBehaviour
	{
		[Serializable]
		public class Configuration
		{
			public int PoolSize;

			public float selectedWidth;

			public float unselectedWidth;

			public UILobbyRankIconEntry Prefab;
		}

		public class Pool
		{
			[NonSerialized]
			public Configuration _configuration;

			[NonSerialized]
			public Queue<UILobbyRankIconEntry> _inactiveQueue;

			[NonSerialized]
			public Transform _parentTransform;

			[NonSerialized]
			public RectTransform _viewportTransform;

			public Pool(Configuration configuration, Transform parentTransform)
			{
			}

			public UILobbyRankIconEntry Spawn(Sprite iconSelected, Sprite iconUnselected, string labelString, Action clickAction)
			{
				return null;
			}

			public void Despawn(UILobbyRankIconEntry instance)
			{
			}
		}

		[SerializeField]
		public Image _iconImage;

		[SerializeField]
		public Image _selectHighlight;

		[SerializeField]
		public Button _button;

		[SerializeField]
		public TextMeshProUGUI _label;

		[SerializeField]
		public LayoutElement _layoutElement;

		[NonSerialized]
		public Pool _pool;

		[NonSerialized]
		public Configuration _configuration;

		[NonSerialized]
		public Sprite _iconSelected;

		[NonSerialized]
		public Sprite _iconUnselected;

		[NonSerialized]
		public string _labelString;

		[NonSerialized]
		public Action _clickAction;

		public void Build(Pool pool, Configuration configuration)
		{
		}

		public void Initialise(Sprite iconSelected, Sprite iconUnselected, string labelString, Action clickAction)
		{
		}

		public void Select()
		{
		}

		public void SelectUI()
		{
		}

		public void DeselectUI()
		{
		}

		public void Dispose()
		{
		}
	}
}
