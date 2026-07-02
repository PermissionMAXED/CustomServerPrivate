using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnHit_Lmb_Dmg_SO : PassiveSO
	{
		[SerializeField]
		public P_OnHit_Lmb_Dmg.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
