using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnHpLoss_HealZone_SO : PassiveSO
	{
		[SerializeField]
		public P_OnHpLoss_HealZone.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
