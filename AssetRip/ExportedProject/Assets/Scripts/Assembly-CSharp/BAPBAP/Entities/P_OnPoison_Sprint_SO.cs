using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_OnPoison_Sprint_SO : PassiveSO
	{
		[SerializeField]
		public P_OnPoison_Sprint.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
