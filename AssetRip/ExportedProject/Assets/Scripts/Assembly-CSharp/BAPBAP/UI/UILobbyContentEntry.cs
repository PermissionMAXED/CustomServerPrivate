using System;
using System.Collections.Generic;
using BAPBAP.Content;
using BAPBAP.Localisation;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UILobbyContentEntry : MonoBehaviour, ISelectHandler, IEventSystemHandler
	{
		[Serializable]
		public class Configuration
		{
			public ContentConfiguration contentConfig;

			public UILobbyContentEntry Prefab;

			public int PoolSize;

			public Color selectedEdgeColor;

			public string newLabelTranslationKey;
		}

		public class Pool
		{
			[NonSerialized]
			public Configuration _configuration;

			[NonSerialized]
			public Queue<UILobbyContentEntry> _inactiveQueue;

			[NonSerialized]
			public Transform _parentTransform;

			[NonSerialized]
			public RectTransform _viewportTransform;

			public Pool(Configuration configuration, Transform parentTransform, RectTransform viewportTransform)
			{
			}

			public UILobbyContentEntry Spawn(int contentAssetId, int contentGroupId, BAPBAP.Content.Content content, UnityAction<UILobbyContentEntry> submitAction, Action onSelectAction)
			{
				return null;
			}

			public void Despawn(UILobbyContentEntry instance)
			{
			}
		}

		[SerializeField]
		public CanvasGroup canvasGroup;

		[SerializeField]
		public UIPosLerpFade posLerpFade;

		[SerializeField]
		public UIAlphaFade alphaFade;

		[SerializeField]
		public Image rarityAccentImage;

		[SerializeField]
		public Image contentImage;

		[SerializeField]
		public Image selectedBorderImage;

		[SerializeField]
		public GameObject equipedIcon;

		[SerializeField]
		public GameObject newLabel;

		[SerializeField]
		public TMP_Text newLabelText;

		[SerializeField]
		public Button button;

		[NonSerialized]
		public string typeName;

		[NonSerialized]
		public string rarityName;

		[NonSerialized]
		public int assetId;

		[NonSerialized]
		public bool equiped;

		[NonSerialized]
		public int contentGroupId;

		[NonSerialized]
		public Rarity rarityTier;

		[NonSerialized]
		public int tierTypeId;

		[NonSerialized]
		public UnityAction<UILobbyContentEntry> _submitAction;

		[NonSerialized]
		public Configuration _configuration;

		[NonSerialized]
		public Action _onSelectAction;

		[NonSerialized]
		public Pool _pool;

		[NonSerialized]
		public string _rarityTranslationKey;

		[NonSerialized]
		public string _titleTranslationKey;

		[NonSerialized]
		public string _typeTranslationKey;

		[NonSerialized]
		public RectTransform _viewportTransform;

		[NonSerialized]
		public bool selected;

		[NonSerialized]
		public bool fadeInDelay;

		[NonSerialized]
		public float fadeInDelayTime;

		[NonSerialized]
		public float fadeInDelayDuration;

		public void Update()
		{
		}

		public static UILobbyContentEntry Build(Pool pool, Configuration configuration, Transform parent)
		{
			return null;
		}

		public void Initialise(int contentAssetId, int contentGroupId, BAPBAP.Content.Content content, UnityAction<UILobbyContentEntry> submitAction, Action onSelectAction)
		{
		}

		public virtual void Localise(Translator translator)
		{
		}

		public void OnSelect(BaseEventData eventData)
		{
		}

		public void Select()
		{
		}

		public void SelectUIButton()
		{
		}

		public void DeselectUIButton()
		{
		}

		public void SetEquiped()
		{
		}

		public void SetUnequiped()
		{
		}

		public void SetNewLabelEnabled(bool isEnabled)
		{
		}

		public void Enable()
		{
		}

		public void Disable()
		{
		}

		public void Dispose()
		{
		}

		public void FadeInDelay(float delay)
		{
		}
	}
}
