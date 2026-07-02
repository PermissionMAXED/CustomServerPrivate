using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_GoldRock_SO : PassiveSO
	{
		[SerializeField]
		public P_GoldRock.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
