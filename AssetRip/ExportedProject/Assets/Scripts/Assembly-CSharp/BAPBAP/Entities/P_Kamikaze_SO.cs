using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_Kamikaze_SO : PassiveSO
	{
		[SerializeField]
		public P_Kamikaze.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
