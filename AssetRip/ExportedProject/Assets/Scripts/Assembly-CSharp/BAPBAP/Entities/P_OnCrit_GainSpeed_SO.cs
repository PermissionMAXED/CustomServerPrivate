using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnCrit_GainSpeed_SO : PassiveSO
	{
		[SerializeField]
		public P_OnCrit_GainSpeed.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
