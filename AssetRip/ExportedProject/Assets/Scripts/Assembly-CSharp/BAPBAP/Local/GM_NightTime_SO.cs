using UnityEngine;

namespace BAPBAP.Local
{
	public class GM_NightTime_SO : GameModifierSO
	{
		[SerializeField]
		public GM_NightTime.Config configuration;

		public override GameModifier.GameModifierConfiguration config => null;

		public override GameModifier NewInstance()
		{
			return null;
		}
	}
}
