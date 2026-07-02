using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnDamage_Skull_SO : PassiveSO
	{
		[SerializeField]
		public P_OnDamage_Skull.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
