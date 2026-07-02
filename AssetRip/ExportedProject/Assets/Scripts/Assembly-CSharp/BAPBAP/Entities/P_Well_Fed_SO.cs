using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_Well_Fed_SO : PassiveSO
	{
		[SerializeField]
		public P_Well_Fed.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
