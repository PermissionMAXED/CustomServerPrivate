using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UILobbyHistoryPlayerInfo : MonoBehaviour
	{
		[Serializable]
		public class ItemDisplay
		{
			[SerializeField]
			public Image ItemImage;

			[SerializeField]
			public Image ItemBg;
		}

		[SerializeField]
		public Image _characterDisplayImage;

		[SerializeField]
		public TMP_Text _characterNameText;

		[SerializeField]
		public TMP_Text _usernameText;

		[SerializeField]
		public TMP_Text _dmgDealtText;

		[SerializeField]
		public TMP_Text _dmgTakenText;

		[SerializeField]
		public RectTransform _statsRectTransform;

		[SerializeField]
		public List<ItemDisplay> _items;

		[NonSerialized]
		public ProfileModel _profileModel;

		[NonSerialized]
		public UILobbyProfileTabPage.Configuration _config;

		public void Initialize(ProfileModel profileModel)
		{
		}

		public void Build(UILobbyProfileTabPage.Configuration config)
		{
		}

		public void UpdateInfo(ProfileModel.History history, bool useFullCharPortrait = false)
		{
		}

		public void UpdateInfo(ProfileModel.TeammateHistory playerHistory, bool useFullCharPortrait = false)
		{
		}

		public void SetDisplayItems(int[] items)
		{
		}
	}
}
