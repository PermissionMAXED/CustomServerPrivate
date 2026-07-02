using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_Empty_SO : PassiveSO
	{
		[SerializeField]
		public Passive.PassiveConfiguration configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
