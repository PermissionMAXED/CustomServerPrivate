using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_Pages_SO : PassiveSO
	{
		[SerializeField]
		public P_Pages.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
