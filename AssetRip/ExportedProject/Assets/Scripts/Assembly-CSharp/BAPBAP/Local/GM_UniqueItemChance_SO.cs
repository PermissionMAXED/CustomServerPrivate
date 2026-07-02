using UnityEngine;

namespace BAPBAP.Local
{
	public class GM_UniqueItemChance_SO : GameModifierSO
	{
		[SerializeField]
		public GM_UniqueItemChance.Config configuration;

		public override GameModifier.GameModifierConfiguration config => null;

		public override GameModifier NewInstance()
		{
			return null;
		}
	}
}
