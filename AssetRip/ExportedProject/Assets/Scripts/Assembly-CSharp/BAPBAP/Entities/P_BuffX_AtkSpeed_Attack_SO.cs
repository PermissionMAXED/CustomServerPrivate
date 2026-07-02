using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_BuffX_AtkSpeed_Attack_SO : PassiveSO
	{
		[SerializeField]
		public P_BuffX_AtkSpeed_Attack.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
