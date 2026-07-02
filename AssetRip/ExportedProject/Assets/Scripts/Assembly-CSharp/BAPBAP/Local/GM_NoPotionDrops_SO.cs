using UnityEngine;

namespace BAPBAP.Local
{
	public class GM_NoPotionDrops_SO : GameModifierSO
	{
		[SerializeField]
		public GM_NoPotionDrops.Config configuration;

		public override GameModifier.GameModifierConfiguration config => null;

		public override GameModifier NewInstance()
		{
			return null;
		}
	}
}
