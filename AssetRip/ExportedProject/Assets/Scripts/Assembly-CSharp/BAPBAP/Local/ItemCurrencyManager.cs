using BAPBAP.Content;
using BAPBAP.Items;
using UnityEngine;

namespace BAPBAP.Local
{
	public class ItemCurrencyManager : MonoBehaviour
	{
		[SerializeField]
		[Header("References")]
		public CurrencyData currencyData;

		[Header("Data")]
		[SerializeField]
		public Mesh[] goldMeshes;

		[Header("Currency Thresholds")]
		[SerializeField]
		public int maxSmallAmount;

		[SerializeField]
		public int maxMedAmount;

		[SerializeField]
		[NamedArray(typeof(ItemTiers), 0)]
		[Header("Upgrade Station")]
		public int[] upgradeAmount;

		[NamedArray(typeof(ItemTiers), 0)]
		[SerializeField]
		public int[] upgradeAmountPin;

		[Header("Shop Station")]
		[NamedArray(typeof(ItemTiers), 0)]
		[SerializeField]
		public int[] shopPrices;

		[Header("Sell Station")]
		[SerializeField]
		[NamedArray(typeof(ItemTiers), 0)]
		public int[] sellPrices;

		public int GetUpgradeAmount(int tierId)
		{
			return 0;
		}

		public int GetUpgradeAmountPin(int tierId)
		{
			return 0;
		}

		public int GetShopPrices(Item itemToPurchase)
		{
			return 0;
		}

		public int GetSellPrices(int tierId)
		{
			return 0;
		}

		public Mesh GetCurrencyAmountMesh(Item currency, int amount)
		{
			return null;
		}
	}
}
