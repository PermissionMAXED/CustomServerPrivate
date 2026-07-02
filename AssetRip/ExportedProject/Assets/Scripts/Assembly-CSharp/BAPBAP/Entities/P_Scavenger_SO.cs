using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_Scavenger_SO : PassiveSO
	{
		[SerializeField]
		public P_Scavenger.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
