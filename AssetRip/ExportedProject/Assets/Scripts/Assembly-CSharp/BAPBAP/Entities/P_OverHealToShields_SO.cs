using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OverHealToShields_SO : PassiveSO
	{
		[SerializeField]
		public P_OverHealToShields.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
