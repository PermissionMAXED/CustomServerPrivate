using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_Buff_AtkSpeed_To_Crit_SO : PassiveSO
	{
		[SerializeField]
		public P_Buff_AtkSpeed_To_Crit.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
