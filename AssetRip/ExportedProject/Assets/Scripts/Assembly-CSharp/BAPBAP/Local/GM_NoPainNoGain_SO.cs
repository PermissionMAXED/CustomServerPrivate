using UnityEngine;

namespace BAPBAP.Local
{
	public class GM_NoPainNoGain_SO : GameModifierSO
	{
		[SerializeField]
		public GM_NoPainNoGain.Config configuration;

		public override GameModifier.GameModifierConfiguration config => null;

		public override GameModifier NewInstance()
		{
			return null;
		}
	}
}
