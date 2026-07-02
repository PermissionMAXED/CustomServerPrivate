using UnityEngine;

namespace BAPBAP.Entities
{
	[CreateAssetMenu(fileName = "P_OnSprint_Shield", menuName = "BAPBAP/Passives/P_OnSprint_Shield")]
	public class P_OnSprint_Shield_SO : PassiveSO
	{
		[SerializeField]
		public P_OnSprint_Shield.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
