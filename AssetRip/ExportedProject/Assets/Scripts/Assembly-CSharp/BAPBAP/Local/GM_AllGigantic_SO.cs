using UnityEngine;

namespace BAPBAP.Local
{
	public class GM_AllGigantic_SO : GameModifierSO
	{
		[SerializeField]
		public GM_AllGigantic.Config configuration;

		public override GameModifier.GameModifierConfiguration config => null;

		public override GameModifier NewInstance()
		{
			return null;
		}
	}
}
