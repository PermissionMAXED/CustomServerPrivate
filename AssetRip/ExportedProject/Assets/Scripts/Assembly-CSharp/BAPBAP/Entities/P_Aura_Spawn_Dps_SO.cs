using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_Aura_Spawn_Dps_SO : PassiveSO
	{
		[SerializeField]
		public P_Aura_Spawn_Dps.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
