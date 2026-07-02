using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_Gigantic_SO : PassiveSO
	{
		[SerializeField]
		public P_Gigantic.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
