using System;
using System.Collections.Generic;
using BAPBAP.Localisation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UILobbyStatsEntry : MonoBehaviour
	{
		[Serializable]
		public class Configuration
		{
			public UILobbyStatsEntry Prefab;

			public int PoolSize;

			public float PreferredHeightViewportPercentage;

			public string WinsTranslationKey;

			public string KillsTranslationKey;

			public string KdaTranslationKey;
		}

		public class Pool
		{
			[NonSerialized]
			public Configuration _configuration;

			[NonSerialized]
			public Queue<UILobbyStatsEntry> _inactiveQueue;

			[NonSerialized]
			public Transform _parentTransform;

			[NonSerialized]
			public RectTransform _viewportTransform;

			public Pool(Configuration configuration, Transform parentTransform, RectTransform viewportTransform)
			{
			}

			public UILobbyStatsEntry Spawn(Translator translator, string gameModeTranslationKey, int wins, int kills, float kda)
			{
				return null;
			}

			public void Despawn(UILobbyStatsEntry instance)
			{
			}
		}

		[SerializeField]
		public TMP_Text _gameModeText;

		[SerializeField]
		public TMP_Text _winsTitleText;

		[SerializeField]
		public TMP_Text _killsTitleText;

		[SerializeField]
		public TMP_Text _kdaTitleText;

		[SerializeField]
		public TMP_Text _winsValueText;

		[SerializeField]
		public TMP_Text _killsValueText;

		[SerializeField]
		public TMP_Text _kdaValueText;

		[SerializeField]
		public LayoutElement _layoutElement;

		[NonSerialized]
		public Configuration _configuration;

		[NonSerialized]
		public string _gameModeTranslationKey;

		[NonSerialized]
		public Pool _pool;

		[NonSerialized]
		public RectTransform _viewportTransform;

		[NonSerialized]
		public bool _isInitialized;

		public void Update()
		{
		}

		public void Initialise(Pool pool, Configuration configuration, RectTransform viewportTransform, string gameModeTranslationKey, int wins, int kills, float kda)
		{
		}

		public void Localise(Translator translator)
		{
		}

		public void Dispose()
		{
		}
	}
}
