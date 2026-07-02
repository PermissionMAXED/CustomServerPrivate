using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnUse_StickyBomb_SO : PassiveSO
	{
		[SerializeField]
		public P_OnUse_StickyBomb.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
