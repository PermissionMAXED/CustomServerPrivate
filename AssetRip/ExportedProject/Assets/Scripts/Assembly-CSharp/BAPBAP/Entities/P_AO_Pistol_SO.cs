using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_AO_Pistol_SO : PassiveSO
	{
		[SerializeField]
		public P_AO_Pistol.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
