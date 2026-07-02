using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_Blood_LifeSteal_SO : PassiveSO
	{
		[SerializeField]
		public P_Blood_LifeSteal.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
