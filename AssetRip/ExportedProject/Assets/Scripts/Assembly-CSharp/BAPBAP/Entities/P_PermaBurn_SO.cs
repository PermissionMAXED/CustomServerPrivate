using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_PermaBurn_SO : PassiveSO
	{
		[SerializeField]
		public P_PermaBurn.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
