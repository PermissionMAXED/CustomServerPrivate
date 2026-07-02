using UnityEngine;

namespace BAPBAP.Local
{
	public class GM_AngledMap_SO : GameModifierSO
	{
		[SerializeField]
		public GM_AngledMap.Config configuration;

		public override GameModifier.GameModifierConfiguration config => null;

		public override GameModifier NewInstance()
		{
			return null;
		}
	}
}
