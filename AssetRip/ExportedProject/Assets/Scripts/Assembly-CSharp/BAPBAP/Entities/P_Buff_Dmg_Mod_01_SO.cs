using UnityEngine;

namespace BAPBAP.Entities
{
	public class P_Buff_Dmg_Mod_01_SO : PassiveSO
	{
		[SerializeField]
		public P_Buff_Dmg_Mod_01.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
