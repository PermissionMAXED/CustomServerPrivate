using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnCd_Freeze_SO : PassiveSO
	{
		[SerializeField]
		public P_OnCd_Freeze.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
