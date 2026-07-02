using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnUse_Space_Spawn_Consumable_SO : PassiveSO
	{
		[SerializeField]
		public P_OnUse_Space_Spawn_Consumable.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
