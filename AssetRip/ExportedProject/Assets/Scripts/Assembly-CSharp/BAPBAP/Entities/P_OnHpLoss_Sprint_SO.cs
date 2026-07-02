using UnityEngine;

namespace BAPBAP.Entities
{
	[CreateAssetMenu(fileName = "P_OnHpLoss_Sprint", menuName = "BAPBAP/Passives/P_OnHpLoss_Sprint")]
	public class P_OnHpLoss_Sprint_SO : PassiveSO
	{
		[SerializeField]
		public P_OnHpLoss_Sprint.Config configuration;

		public override Passive.PassiveConfiguration config => null;

		public override Passive NewInstance(EntityManager em)
		{
			return null;
		}
	}
}
