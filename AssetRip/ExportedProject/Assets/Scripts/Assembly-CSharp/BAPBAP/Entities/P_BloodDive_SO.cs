using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_BloodDive_SO : PassiveSO
	{
		[SerializeField]
		public P_BloodDive.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
