using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_Give_Item_SO : PassiveSO
	{
		[SerializeField]
		public P_Give_Item.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
