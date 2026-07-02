using UnityEngine;

namespace BAPBAP.Entities
{
	[CreateAssetMenu(fileName = "P_OnAirborne_Sprint", menuName = "BAPBAP/Passives/P_OnAirborne_Sprint")]
	public class P_OnAirborne_Sprint_SO : PassiveSO
	{
		[SerializeField]
		public P_OnAirborne_Sprint.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
