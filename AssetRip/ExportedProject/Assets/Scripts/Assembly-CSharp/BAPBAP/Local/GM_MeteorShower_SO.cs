using UnityEngine;

namespace BAPBAP.Local
{
	public class GM_MeteorShower_SO : GameModifierSO
	{
		[SerializeField]
		public GM_MeteorShower.Config configuration;

		public override GameModifier.GameModifierConfiguration config => null;

		public override GameModifier NewInstance()
		{
			return null;
		}
	}
}
