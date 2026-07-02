using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_SE_ShowEffect_SO : PassiveSO
	{
		[SerializeField]
		public P_SE_ShowEffect.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
