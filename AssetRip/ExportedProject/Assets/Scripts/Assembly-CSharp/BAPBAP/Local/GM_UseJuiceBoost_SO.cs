using UnityEngine;

namespace BAPBAP.Local
{
	public class GM_UseJuiceBoost_SO : GameModifierSO
	{
		[SerializeField]
		public GM_UseJuiceBoost.Config configuration;

		public override GameModifier.GameModifierConfiguration config => null;

		public override GameModifier NewInstance()
		{
			return null;
		}
	}
}
