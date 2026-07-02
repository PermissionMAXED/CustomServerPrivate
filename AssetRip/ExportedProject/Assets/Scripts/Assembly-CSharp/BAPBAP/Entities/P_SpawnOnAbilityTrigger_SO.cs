using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_SpawnOnAbilityTrigger_SO : PassiveSO
	{
		[SerializeField]
		public P_SpawnOnHitboxCreate.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
