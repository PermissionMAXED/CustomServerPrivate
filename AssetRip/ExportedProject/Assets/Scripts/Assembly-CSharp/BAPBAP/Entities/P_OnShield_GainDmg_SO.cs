using UnityEngine;

namespace BAPBAP.Entities
{
	[CreateAssetMenu(fileName = "P_OnShield_GainDmg", menuName = "BAPBAP/Passives/P_OnShield_GainDmg")]
	public class P_OnShield_GainDmg_SO : PassiveSO
	{
		[SerializeField]
		public P_OnShield_GainDmg.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
