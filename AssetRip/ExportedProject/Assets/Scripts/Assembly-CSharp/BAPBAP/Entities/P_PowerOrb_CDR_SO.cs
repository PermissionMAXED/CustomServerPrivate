using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_PowerOrb_CDR_SO : PassiveSO
	{
		[SerializeField]
		public P_PowerOrb_CDR.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
