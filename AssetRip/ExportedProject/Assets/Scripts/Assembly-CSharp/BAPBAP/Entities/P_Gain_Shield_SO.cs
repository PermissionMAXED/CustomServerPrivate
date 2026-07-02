using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_Gain_Shield_SO : PassiveSO
	{
		[SerializeField]
		public P_Gain_Shield.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
