using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_SinCity_RespawnTracker_SO : PassiveSO
	{
		[SerializeField]
		public P_SinCity_RespawnTracker.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
