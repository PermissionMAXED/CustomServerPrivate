using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_CharAugment_Extra_Mileage_SO : PassiveSO
	{
		[SerializeField]
		public P_CharAugment_Extra_Mileage.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
