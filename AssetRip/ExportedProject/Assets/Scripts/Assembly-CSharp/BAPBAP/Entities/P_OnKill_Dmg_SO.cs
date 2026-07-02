using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnKill_Dmg_SO : PassiveSO
	{
		[SerializeField]
		public P_OnKill_Dmg.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
