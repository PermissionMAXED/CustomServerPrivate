using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_WorkBench_SO : PassiveSO
	{
		[SerializeField]
		public P_WorkBench.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
