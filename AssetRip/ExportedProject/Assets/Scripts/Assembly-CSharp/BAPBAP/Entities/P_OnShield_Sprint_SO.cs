using UnityEngine;

namespace BAPBAP.Entities
{
	[CreateAssetMenu(fileName = "P_OnShield_Sprint", menuName = "BAPBAP/Passives/P_OnShield_Sprint")]
	public class P_OnShield_Sprint_SO : PassiveSO
	{
		[SerializeField]
		public P_OnShield_Sprint.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
