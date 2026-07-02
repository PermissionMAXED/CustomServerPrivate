using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_AbilityCrit_SO : PassiveSO
	{
		[SerializeField]
		public P_AbilityCrit.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
