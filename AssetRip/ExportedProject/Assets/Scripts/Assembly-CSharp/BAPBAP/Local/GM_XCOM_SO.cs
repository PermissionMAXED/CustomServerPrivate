using UnityEngine;

namespace BAPBAP.Local
{
	public class GM_XCOM_SO : GameModifierSO
	{
		[SerializeField]
		public GM_XCOM.Config configuration;

		public override GameModifier.GameModifierConfiguration config => null;

		public override GameModifier NewInstance()
		{
			return null;
		}
	}
}
