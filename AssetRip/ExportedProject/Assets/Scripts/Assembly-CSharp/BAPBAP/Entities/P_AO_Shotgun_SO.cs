using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_AO_Shotgun_SO : PassiveSO
	{
		[SerializeField]
		public P_AO_Shotgun.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
