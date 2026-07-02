using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_Blood_ExtraDmg_SO : PassiveSO
	{
		[SerializeField]
		public P_Blood_ExtraDmg.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
