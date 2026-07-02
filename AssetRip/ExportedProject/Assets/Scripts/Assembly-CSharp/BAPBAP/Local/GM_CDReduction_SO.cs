using UnityEngine;

namespace BAPBAP.Local
{
	public class GM_CDReduction_SO : GameModifierSO
	{
		[SerializeField]
		public GM_CDReduction.Config configuration;

		public override GameModifier.GameModifierConfiguration config => null;

		public override GameModifier NewInstance()
		{
			return null;
		}
	}
}
