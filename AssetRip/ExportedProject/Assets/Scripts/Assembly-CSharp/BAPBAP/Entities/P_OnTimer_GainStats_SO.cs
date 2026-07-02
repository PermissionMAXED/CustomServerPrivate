using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnTimer_GainStats_SO : PassiveSO
	{
		[SerializeField]
		public P_OnTimer_GainStats.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
