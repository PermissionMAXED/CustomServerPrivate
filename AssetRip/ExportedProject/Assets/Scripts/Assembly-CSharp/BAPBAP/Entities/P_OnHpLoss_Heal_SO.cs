using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnHpLoss_Heal_SO : PassiveSO
	{
		[SerializeField]
		public P_OnHpLoss_Heal.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
