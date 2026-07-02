using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_Stat_Shred_SO : PassiveSO
	{
		[SerializeField]
		public P_Stat_Shred.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
