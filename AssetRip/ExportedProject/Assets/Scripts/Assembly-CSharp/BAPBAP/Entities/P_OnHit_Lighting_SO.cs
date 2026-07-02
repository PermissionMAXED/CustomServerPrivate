using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnHit_Lighting_SO : PassiveSO
	{
		[SerializeField]
		public P_OnHit_Lighting.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
