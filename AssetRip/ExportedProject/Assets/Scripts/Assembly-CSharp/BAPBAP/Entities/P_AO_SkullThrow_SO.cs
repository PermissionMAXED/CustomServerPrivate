using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_AO_SkullThrow_SO : PassiveSO
	{
		[SerializeField]
		public P_AO_SkullThrow.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
