using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_Aura_Spawn_Gravity_SO : PassiveSO
	{
		[SerializeField]
		public P_Aura_Spawn_Gravity.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
