using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_D_Atlantis_SO : PassiveSO
	{
		[SerializeField]
		public P_D_Atlantis.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
