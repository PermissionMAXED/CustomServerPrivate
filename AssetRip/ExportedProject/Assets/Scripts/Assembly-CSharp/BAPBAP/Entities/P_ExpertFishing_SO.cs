using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_ExpertFishing_SO : PassiveSO
	{
		[SerializeField]
		public P_ExpertFishing.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
