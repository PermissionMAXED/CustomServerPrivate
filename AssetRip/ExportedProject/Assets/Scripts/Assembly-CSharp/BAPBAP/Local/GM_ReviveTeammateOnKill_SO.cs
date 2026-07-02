using UnityEngine;

namespace BAPBAP.Local
{
	public class GM_ReviveTeammateOnKill_SO : GameModifierSO
	{
		[SerializeField]
		public GM_ReviveTeammateOnKill.Config configuration;

		public override GameModifier.GameModifierConfiguration config => null;

		public override GameModifier NewInstance()
		{
			return null;
		}
	}
}
