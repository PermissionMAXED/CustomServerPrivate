using System;
using System.Collections.Generic;
using BAPBAP.Localisation;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UILobbyHistoryEntry : MonoBehaviour
	{
		[Serializable]
		public class Configuration
		{
			public UICharactersConfiguration CharacterConfig;

			public UILobbyHistoryEntry Prefab;

			public int PoolSize;

			public float minPlacementToWin;

			public Color WinColour;

			public Color LossColour;

			public Color WinAccentColour;

			public Color LossAccentColour;

			public Color NeutralAccentColour;

			public string OutOfTranslationKey;

			public string KDATranslationKey;

			public string DmgDealtTranslationKey;

			public string DmgTakenTranslationKey;

			public Sprite EmptyItemSprite;

			public Color EmptyItemBgColor;

			public Color EmptyItemColor;
		}

		public class Pool
		{
			[NonSerialized]
			public Configuration _configuration;

			[NonSerialized]
			public Queue<UILobbyHistoryEntry> _inactiveQueue;

			[NonSerialized]
			public Transform _parentTransform;

			[NonSerialized]
			public RectTransform _viewportTransform;

			public Pool(Configuration configuration, Transform parentTransform, RectTransform viewportTransform)
			{
			}

			public UILobbyHistoryEntry Spawn(Translator translator, string gameModeTranslationKey, int placement, bool isMvp, int teamCount, int rankedPointsDelta, DateTime date, int kills, int deaths, int assists, int itemId1, int itemId2, int itemId3, int itemId4, int dmgDealt, int dmgTaken, int characterId, UnityAction onClickAction)
			{
				return null;
			}

			public void Despawn(UILobbyHistoryEntry instance)
			{
			}
		}

		[SerializeField]
		public LayoutElement _layoutElement;

		[SerializeField]
		public Button _button;

		[SerializeField]
		public GameObject _selectBarObject;

		[SerializeField]
		public Image _placementColorImage;

		[SerializeField]
		public Image _characterImage;

		[SerializeField]
		public TMP_Text _placementText;

		[SerializeField]
		public TMP_Text _outOfText;

		[SerializeField]
		public TMP_Text _characterText;

		[SerializeField]
		public TMP_Text _mvpText;

		[SerializeField]
		public TMP_Text _rankedPointsText;

		[SerializeField]
		public TMP_Text _gameModeText;

		[SerializeField]
		public TMP_Text _dateText;

		[SerializeField]
		public TMP_Text _kdaLabelText;

		[SerializeField]
		public TMP_Text _kdaValueText;

		[SerializeField]
		public Image _item1Image;

		[SerializeField]
		public Image _item1ImageBg;

		[SerializeField]
		public Image _item2Image;

		[SerializeField]
		public Image _item2ImageBg;

		[SerializeField]
		public Image _item3Image;

		[SerializeField]
		public Image _item3ImageBg;

		[SerializeField]
		public Image _item4Image;

		[SerializeField]
		public Image _item4ImageBg;

		[SerializeField]
		public TMP_Text _dmgDealtLabelText;

		[SerializeField]
		public TMP_Text _dmgDealtValueText;

		[SerializeField]
		public TMP_Text _dmgTakenLabelText;

		[SerializeField]
		public TMP_Text _dmgTakenValueText;

		[NonSerialized]
		public Configuration _configuration;

		[NonSerialized]
		public string _gameModeTranslationKey;

		[NonSerialized]
		public bool _isSelected;

		[NonSerialized]
		public UnityAction _onClickAction;

		[NonSerialized]
		public int gameTeamCount;

		[NonSerialized]
		public Pool _pool;

		[NonSerialized]
		public RectTransform _viewportTransform;

		public void Initialise(Pool pool, Configuration configuration, RectTransform viewportTransform, string gameModeTranslationKey, int placement, bool isMvp, int teamCount, int rankedPointsDelta, DateTime date, int kills, int deaths, int assists, int itemId1, int itemId2, int itemId3, int itemId4, int dmgDealt, int dmgTaken, int charId, UnityAction onClickAction)
		{
		}

		public void Localise(Translator translator)
		{
		}

		public void Dispose()
		{
		}

		public void SetSelected(bool selected, bool forceAction = false)
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
