using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnCd_Block_SO : PassiveSO
	{
		[SerializeField]
		public P_OnCd_Block.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
