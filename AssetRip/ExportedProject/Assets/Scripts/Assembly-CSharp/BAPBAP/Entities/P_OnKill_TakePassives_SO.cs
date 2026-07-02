using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnKill_TakePassives_SO : PassiveSO
	{
		[SerializeField]
		public P_OnKill_TakePassives.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
