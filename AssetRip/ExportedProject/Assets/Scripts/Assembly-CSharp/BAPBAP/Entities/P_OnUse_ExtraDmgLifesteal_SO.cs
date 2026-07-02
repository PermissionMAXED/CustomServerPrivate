using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnUse_ExtraDmgLifesteal_SO : PassiveSO
	{
		[SerializeField]
		public P_OnUse_ExtraDmgLifesteal.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
