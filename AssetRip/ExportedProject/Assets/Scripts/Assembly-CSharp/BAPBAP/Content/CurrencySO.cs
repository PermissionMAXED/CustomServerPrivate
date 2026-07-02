using BAPBAP.Local;
using UnityEngine;

namespace BAPBAP.Content
{
	[CreateAssetMenu(fileName = "Currency", menuName = "BAPBAP/Content/Currency/Currency", order = 1)]
	public class CurrencySO : ContentSO
	{
		public Currency currency;

		public override Content content => null;
	}
}
