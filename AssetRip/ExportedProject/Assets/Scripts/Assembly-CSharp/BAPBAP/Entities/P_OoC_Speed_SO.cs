using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OoC_Speed_SO : PassiveSO
	{
		[SerializeField]
		public P_OoC_Speed.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
