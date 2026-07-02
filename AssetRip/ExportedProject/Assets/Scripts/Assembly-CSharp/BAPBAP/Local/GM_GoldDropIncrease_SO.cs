using UnityEngine;

namespace BAPBAP.Local
{
	public class GM_GoldDropIncrease_SO : GameModifierSO
	{
		[SerializeField]
		public GM_GoldDropIncrease.Config configuration;

		public override GameModifier.GameModifierConfiguration config => null;

		public override GameModifier NewInstance()
		{
			return null;
		}
	}
}
