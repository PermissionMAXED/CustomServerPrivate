using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnHitboxSpawned_AddStatusEffect_SO : PassiveSO
	{
		[SerializeField]
		public P_OnHitboxSpawned_AddStatusEffect.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
