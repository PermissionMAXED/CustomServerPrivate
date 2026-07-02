using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_CharAugment_MultiProjectile_SO : PassiveSO
	{
		[SerializeField]
		public P_CharAugment_MultiProjectile.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
