using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_MoneyIsPower_SO : PassiveSO
	{
		[SerializeField]
		public P_MoneyIsPower.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
