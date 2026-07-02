using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnKill_Reset_All_SO : PassiveSO
	{
		[SerializeField]
		public P_OnKill_Reset_All.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
