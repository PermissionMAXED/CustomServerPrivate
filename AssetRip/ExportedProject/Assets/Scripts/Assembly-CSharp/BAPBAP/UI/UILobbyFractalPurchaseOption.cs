using System;
using BAPBAP.Localisation;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace BAPBAP.UI
{
	public class UILobbyFractalPurchaseOption : MonoBehaviour
	{
		[SerializeField]
		public Button _button;

		[SerializeField]
		public CanvasGroup _bonusCanvasGroup;

		[SerializeField]
		public TMP_Text _fractalsText;

		[SerializeField]
		public TMP_Text _fractalsAmountText;

		[SerializeField]
		public TMP_Text _costText;

		[SerializeField]
		public TMP_Text _bonusText;

		[SerializeField]
		public TMP_Text _bonusAmountText;

		[SerializeField]
		public Image _icon;

		public Button Button => null;

		public void Initialise(int fractals, float cost, float bonus, Sprite icon, Action action)
		{
		}

		public void Localise(Translator translator, string fractalsKey, string bonusKey)
		{
		}
	}
}
