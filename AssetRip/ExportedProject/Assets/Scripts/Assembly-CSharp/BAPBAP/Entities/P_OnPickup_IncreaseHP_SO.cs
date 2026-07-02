using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnPickup_IncreaseHP_SO : PassiveSO
	{
		[SerializeField]
		public P_OnPickup_IncreaseHP.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
