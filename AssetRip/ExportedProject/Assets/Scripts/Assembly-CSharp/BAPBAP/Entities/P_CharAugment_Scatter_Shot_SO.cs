using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_CharAugment_Scatter_Shot_SO : PassiveSO
	{
		[SerializeField]
		public P_CharAugment_Scatter_Shot.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
