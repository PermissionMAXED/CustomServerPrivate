using UnityEngine;

namespace BAPBAP.Local
{
	public class GM_HpReduction_SO : GameModifierSO
	{
		[SerializeField]
		public GM_HpReduction.Config configuration;

		public override GameModifier.GameModifierConfiguration config => null;

		public override GameModifier NewInstance()
		{
			return null;
		}
	}
}
